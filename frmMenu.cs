using System;
using System.Data;
using System.Windows.Forms;
using QuanLySinhVienPhanTan.Services;

namespace QuanLySinhVienPhanTan
{
	public partial class frmMenu : Form
	{
		private readonly DatabaseService _db = new DatabaseService();
		public frmMenu()
		{
			InitializeComponent();
			Load += frmMenu_Load;
		}

		private void frmMenu_Load(object sender, EventArgs e)
		{
			try
			{
				DataTable dt = _db.GetAllSinhVien();
				gridPreview.DataSource = dt;
				lblServer.Text = "Server hiện tại: " + DatabaseService.GlobalCurrentServer + 
					$" | Tổng SV: {dt.Rows.Count}";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Không tải được dữ liệu sinh viên: " + ex.Message);
			}
		}

		private void btnQuanLySV_Click(object sender, EventArgs e)
		{
			using (var f = new frmMain())
			{
				f.ShowDialog(this);
			}
		}
		private void btnKetNoi_Click(object sender, EventArgs e)
		{
			using (var f = new frmConnectionManager())
			{
				f.ShowDialog(this);
			}
		}

		private void btnThoat_Click(object sender, EventArgs e)
		{
			Close();
		}

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}


