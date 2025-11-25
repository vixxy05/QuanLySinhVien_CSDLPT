using System;
using System.Windows.Forms;

namespace QuanLySinhVienPhanTan
{
	public partial class frmStart : Form
	{
		public frmStart()
		{
			InitializeComponent();
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			using (var f = new frmLogin())
			{
				f.ShowDialog(this);
			}
		}

		private void btnDangKy_Click(object sender, EventArgs e)
		{
			using (var f = new frmDangKy())
			{
				f.ShowDialog(this);
			}
		}

		private void btnConn_Click(object sender, EventArgs e)
		{
			using (var f = new frmConnectionManager())
			{
				f.ShowDialog(this);
			}
		}
	}
}



