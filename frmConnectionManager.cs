using System;
using System.Windows.Forms;
using QuanLySinhVienPhanTan.Services;

namespace QuanLySinhVienPhanTan
{
	public partial class frmConnectionManager : Form
	{
		private readonly DatabaseService _db = new DatabaseService();

		public frmConnectionManager()
		{
			InitializeComponent();
			cmbServer.Items.Clear();
			cmbServer.Items.Add("MAIN");
			cmbServer.Items.Add("SERVER1");
			cmbServer.Items.Add("SERVER2");
			cmbServer.SelectedIndex = 0;
			lblCurrent.Text = "Máy chủ hiện tại: " + DatabaseService.GlobalCurrentServer;

			btnTest.Click += btnTest_Click;
			btnSetActive.Click += btnSetActive_Click;
			btnClose.Click += (s, e) => this.Close();
		}

		private void btnTest_Click(object sender, EventArgs e)
		{
			var server = cmbServer.Text;
            if (_db.TestConnection(server))
            {
                var info = _db.GetServerInfo(server);
                MessageBox.Show(info, "Thông tin server");
            }
		}

		private void btnSetActive_Click(object sender, EventArgs e)
		{
			var server = cmbServer.Text;
			_db.SetCurrentServer(server);
			lblCurrent.Text = "Máy chủ hiện tại: " + DatabaseService.GlobalCurrentServer;
			MessageBox.Show("Đã đặt máy chủ mặc định: " + server);
		}
	}
}
