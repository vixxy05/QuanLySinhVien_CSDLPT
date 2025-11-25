using System;
using System.Windows.Forms;
using QuanLySinhVienPhanTan.Services;

namespace QuanLySinhVienPhanTan
{
    public partial class frmLogin : Form
    {
        private DatabaseService dbService;

        public frmLogin()
        {
            InitializeComponent();
            dbService = new DatabaseService();

        }

        // Đã bỏ nút Kết nối theo yêu cầu

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Kiểm tra kết nối database (sử dụng server hiện tại)
            if (!dbService.TestConnection(dbService.GetCurrentServer()))
            {
                var result = MessageBox.Show("Không thể kết nối đến database! Bạn có muốn mở trình quản lý kết nối để cấu hình lại?", "Lỗi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (var connForm = new frmConnectionManager())
                    {
                        connForm.ShowDialog();
                    }

                    // Thử kết nối lại sau khi đóng trình quản lý kết nối
                    if (!dbService.TestConnection(dbService.GetCurrentServer()))
                    {
                        MessageBox.Show("Vẫn không thể kết nối đến database. Vui lòng kiểm tra cấu hình.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            // Tài khoản demo theo yêu cầu (mật khẩu mới)
            bool isValid =
                (username == "Vỹ" && password == "123") ||
                (username == "Trinh" && password == "123") ||
                (username == "Long" && password == "12345");

            if (isValid)
            {
                this.Hide();
                using (var mainForm = new frmMenu())
                {
                    mainForm.ShowDialog();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}