using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QuanLySinhVienPhanTan
{
	public partial class frmCreateDatabase : Form
	{
		public frmCreateDatabase()
		{
			InitializeComponent();
		}

		private void frmCreateDatabase_Load(object sender, EventArgs e)
		{
			// Load connection strings
			string connectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"]?.ConnectionString;
			cmbServer.Items.Add("Main Server");
			cmbServer.Items.Add("Server 1 (SA1)");
			cmbServer.Items.Add("Server 2 (SA2)");
			cmbServer.SelectedIndex = 0;

			// Load script file - ưu tiên CreateAllStoredProcedures.sql nếu chỉ cần tạo stored procedures
			if (File.Exists("CreateAllStoredProcedures.sql"))
			{
				txtScript.Text = File.ReadAllText("CreateAllStoredProcedures.sql", Encoding.UTF8);
			}
			else if (File.Exists("DatabaseScript.sql"))
			{
				txtScript.Text = File.ReadAllText("DatabaseScript.sql", Encoding.UTF8);
			}
			else if (File.Exists("AddMissingStoredProcedures.sql"))
			{
				txtScript.Text = File.ReadAllText("AddMissingStoredProcedures.sql", Encoding.UTF8);
			}
			else
			{
				txtScript.Text = "Không tìm thấy file script SQL. Vui lòng sử dụng nút 'Tải file SQL...' để chọn file.";
				btnExecute.Enabled = false;
			}
		}

		private void btnExecute_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtScript.Text))
			{
				MessageBox.Show("Script SQL không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Lấy connection string
			string connectionString = GetConnectionString();
			if (string.IsNullOrEmpty(connectionString))
			{
				MessageBox.Show("Không tìm thấy connection string!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Kiểm tra script có chứa DROP DATABASE không để cảnh báo phù hợp
			string scriptUpper = txtScript.Text.ToUpper();
			bool isFullScript = scriptUpper.Contains("DROP DATABASE") || 
			                    scriptUpper.Contains("CREATE DATABASE");
			
			string warningMessage = isFullScript 
				? $"Bạn có chắc chắn muốn chạy script SQL trên {cmbServer.Text}?\n\n" +
				  "LƯU Ý: Script này sẽ XÓA database cũ và tạo lại từ đầu!"
				: $"Bạn có chắc chắn muốn chạy script SQL trên {cmbServer.Text}?\n\n" +
				  "Script này sẽ tạo/bổ sung các stored procedures (không ảnh hưởng dữ liệu).";
			
			DialogResult result = MessageBox.Show(
				warningMessage,
				"Xác nhận",
				MessageBoxButtons.YesNo,
				isFullScript ? MessageBoxIcon.Warning : MessageBoxIcon.Question);

			if (result != DialogResult.Yes)
				return;

			btnExecute.Enabled = false;
			rtbOutput.Clear();
			rtbOutput.AppendText($"=== BẮT ĐẦU CHẠY SCRIPT SQL ===\n");
			rtbOutput.AppendText($"Server: {cmbServer.Text}\n");
			rtbOutput.AppendText($"Thời gian: {DateTime.Now:yyyy-MM-dd HH:mm:ss}\n\n");

			try
			{
				// Chạy script
				ExecuteScript(connectionString, txtScript.Text);
				rtbOutput.AppendText("\n=== HOÀN TẤT ===\n");
				MessageBox.Show("Chạy script SQL thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				rtbOutput.AppendText($"\n❌ LỖI: {ex.Message}\n");
				MessageBox.Show($"Lỗi khi chạy script: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				btnExecute.Enabled = true;
			}
		}

		private string GetConnectionString()
		{
			switch (cmbServer.SelectedIndex)
			{
				case 0:
					return ConfigurationManager.ConnectionStrings["MainServer"]?.ConnectionString;
				case 1:
					return ConfigurationManager.ConnectionStrings["Server1"]?.ConnectionString;
				case 2:
					return ConfigurationManager.ConnectionStrings["Server2"]?.ConnectionString;
				default:
					return null;
			}
		}

		private void ExecuteScript(string connectionString, string script)
		{
			// Tách script thành các batch (theo GO)
			// Xử lý nhiều dạng GO statements
			string[] separators = new[] { "\r\nGO\r\n", "\r\nGO\n", "\nGO\r\n", "\nGO\n", "\r\nGO ", "\nGO ", "\r\nGO\t", "\nGO\t" };
			string[] batches = script.Split(separators, StringSplitOptions.RemoveEmptyEntries);

			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				rtbOutput.AppendText("✅ Kết nối thành công!\n\n");

				int successCount = 0;
				int failCount = 0;

				for (int i = 0; i < batches.Length; i++)
				{
					string batch = batches[i].Trim();
					if (string.IsNullOrWhiteSpace(batch) || batch.ToUpper() == "GO")
						continue;

					try
					{
						using (var command = new SqlCommand(batch, connection))
						{
							command.CommandTimeout = 300; // 5 phút
							command.ExecuteNonQuery();
						}
						successCount++;
						rtbOutput.AppendText($"✅ Batch {i + 1}/{batches.Length} đã chạy thành công\n");
					}
					catch (SqlException ex)
					{
						// Bỏ qua một số lỗi thông thường khi object đã tồn tại
						if (ex.Number == 2714 || ex.Number == 3701 || ex.Number == 1801 || ex.Number == 2627)
						{
							// 2714: Object already exists
							// 3701: Cannot drop the object
							// 1801: Database already exists
							// 2627: Violation of PRIMARY KEY constraint (duplicate key)
							rtbOutput.AppendText($"⚠️ Batch {i + 1}: {ex.Message}\n");
							rtbOutput.AppendText($"   (Bỏ qua: Object đã tồn tại hoặc dữ liệu đã có)\n");
							// Không tính là lỗi nghiêm trọng
						}
						else if (ex.Number == 515 || ex.Number == 207)
						{
							// 515: Cannot insert NULL value
							// 207: Invalid column name
							failCount++;
							rtbOutput.AppendText($"❌ Lỗi ở batch {i + 1}: {ex.Message}\n");
						}
						else
						{
							failCount++;
							rtbOutput.AppendText($"❌ Lỗi ở batch {i + 1}: {ex.Message}\n");
						}
					}
					catch (Exception ex)
					{
						failCount++;
						rtbOutput.AppendText($"❌ Lỗi ở batch {i + 1}: {ex.Message}\n");
					}
				}

				rtbOutput.AppendText($"\n📊 Tổng kết: {successCount} thành công, {failCount} lỗi\n");
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnLoadFile_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				dlg.Filter = "SQL Files (*.sql)|*.sql|All Files (*.*)|*.*";
				dlg.Title = "Chọn file SQL";
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					try
					{
						txtScript.Text = File.ReadAllText(dlg.FileName, Encoding.UTF8);
						btnExecute.Enabled = true;
					}
					catch (Exception ex)
					{
						MessageBox.Show($"Lỗi đọc file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
	}
}

