using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLySinhVienWinForms
{
	public partial class FormLogin : Form
	{
		public FormLogin()
		{
			InitializeComponent();
			rbWindows.Checked = true;
		}

		private void btnLogin_Click(object? sender, EventArgs e)
		{
			try
			{
				var csb = new SqlConnectionStringBuilder
				{
					DataSource = txtServer.Text.Trim(),
					InitialCatalog = txtDatabase.Text.Trim(),
					TrustServerCertificate = true,
					Encrypt = false
				};

				if (rbWindows.Checked)
				{
					csb.IntegratedSecurity = true;
				}
				else
				{
					csb.IntegratedSecurity = false;
					csb.UserID = txtUser.Text.Trim();
					csb.Password = txtPassword.Text.Trim();
				}

				using (var conn = new SqlConnection(csb.ConnectionString))
				{
					conn.Open();
				}

				Db.SetConnectionString(csb.ConnectionString);

				var main = new FormMain();
				main.Show();
				Hide();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Kết nối thất bại: " + ex.Message);
			}
		}
	}
}



