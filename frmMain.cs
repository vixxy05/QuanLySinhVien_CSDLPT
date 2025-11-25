using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using QuanLySinhVienPhanTan.Models;
using QuanLySinhVienPhanTan.Services;

namespace QuanLySinhVienPhanTan
{
    public partial class frmMain : Form
    {
        private readonly DatabaseService _db = new DatabaseService();

        public frmMain()
        {
            InitializeComponent();
            rbMuc1.Checked = true;

            // Ẩn nút đăng ký (đã bỏ tính năng)
            btnDangKy.Visible = false;

            // Kiểm tra kết nối database trước khi load
            if (!CheckDatabaseConnection())
            {
                return; // Không tiếp tục nếu database không sẵn sàng
            }
            
            LoadLookups();
        }
        
        private bool CheckDatabaseConnection()
        {
            try
            {
                // Kiểm tra kết nối đến server hiện tại
                string currentServer = _db.GetCurrentServer();
                if (!_db.TestConnection(currentServer))
                {
                    var result = MessageBox.Show(
                        $"Không thể kết nối đến {currentServer}!\n\n" +
                        $"Bạn có muốn mở trình quản lý kết nối để chọn server khác không?",
                        "Lỗi kết nối",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Error);
                    
                    if (result == DialogResult.Yes)
                    {
                        using (var frm = new frmConnectionManager())
                        {
                            frm.ShowDialog();
                        }
                        // Kiểm tra lại sau khi chọn server
                        return CheckDatabaseConnection();
                    }
                    return false;
                }
                
                // Kiểm tra xem có bảng sinhvien không
                using (var connection = new SqlConnection(_db.GetConnectionStringPublic()))
                {
                    connection.Open();
                    using (var command = new SqlCommand(
                        "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'sinhvien'", connection))
                    {
                        int tableExists = (int)command.ExecuteScalar();
                        if (tableExists == 0)
                        {
                            var result = MessageBox.Show(
                                $"Database trên {currentServer} chưa có bảng 'sinhvien'!\n\n" +
                                $"Bạn có muốn mở form tạo database từ script SQL không?",
                                "Database chưa được tạo",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);
                            
                            if (result == DialogResult.Yes)
                            {
                                using (var frm = new frmCreateDatabase())
                                {
                                    frm.ShowDialog();
                                }
                                // Kiểm tra lại sau khi tạo database
                                return CheckDatabaseConnection();
                            }
                            return false;
                        }
                    }
                }
                
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi kiểm tra database: {ex.Message}\n\n" +
                    $"Vui lòng kiểm tra kết nối và cấu hình database.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }
        
        private string GetConnectionString()
        {
            // Lấy connection string từ DatabaseService
            return _db.GetConnectionStringPublic();
        }

        private void LoadLookups()
        {
            cmbLop.Items.Clear();
            cmbLop.Items.Add("L1");
            cmbLop.Items.Add("L2");
            if (cmbLop.Items.Count > 0)
                cmbLop.SelectedIndex = 0;

            cmbPhai.Items.Clear();
            cmbPhai.Items.Add("Nam");
            cmbPhai.Items.Add("Nữ");
            if (cmbPhai.Items.Count > 0)
                cmbPhai.SelectedIndex = 0;

            // Load dữ liệu mặc định
            LoadDefaultData();
        }

        /// <summary>
        /// Load danh sách sinh viên theo lựa chọn hiện tại.
        /// </summary>
        /// <param name="showInfo">True nếu cần hiện thông báo kết quả.</param>
        private void LoadStudentsBySelection(bool showInfo)
        {
            try
            {
                var mslop = cmbLop.Text.Trim();
                if (string.IsNullOrEmpty(mslop))
                {
                    MessageBox.Show("Vui lòng chọn lớp để tìm kiếm.");
                    return;
                }

                DataTable dt = rbMuc1.Checked
                    ? _db.GetSinhVienByLop(mslop)
                    : _db.GetSinhVienByLopPhanManh(mslop);

                grid.DataSource = dt;

                if (showInfo)
                {
                    string muc = rbMuc1.Checked ? "Mức 1 (Toàn cục)" : "Mức 2 (Phân mảnh)";
                    MessageBox.Show($"Đã tìm thấy {dt.Rows.Count} sinh viên lớp {mslop}\nThực thi: {muc}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void LoadDefaultData()
        {
            try
            {
                // Load toàn bộ sinh viên hoặc lớp L1 mặc định
                DataTable dt = _db.GetSinhVienByLop("L1");
                grid.DataSource = dt;

                if (dt.Rows.Count > 0)
                {
                    grid.Rows[0].Selected = true;
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                if (ex.Number == 208) // Invalid object name
                {
                    var result = MessageBox.Show(
                        $"Database chưa được tạo hoặc thiếu bảng 'sinhvien'!\n\n" +
                        $"Bạn có muốn mở form tạo database từ script SQL không?",
                        "Database chưa được tạo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    
                    if (result == DialogResult.Yes)
                    {
                        // Mở form tạo database
                        using (var frm = new frmCreateDatabase())
                        {
                            frm.ShowDialog();
                            // Thử load lại sau khi tạo database
                            LoadDefaultData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadStudentsBySelection(true);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput())
                    return;

                if (!decimal.TryParse(txtHocBong.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out var hocbong))
                {
                    MessageBox.Show("Học bổng không hợp lệ.");
                    return;
                }

                var sv = new SinhVien
                {
                    Mssv = txtMssv.Text.Trim(),
                    Hoten = txtHoten.Text.Trim(),
                    Phai = cmbPhai.Text.Trim(),
                    Ngaysinh = dtpNgaySinh.Value.Date,
                    Mslop = cmbLop.Text.Trim(),
                    Hocbong = hocbong
                };

                if (_db.ThemSinhVien(sv))
                {
                    MessageBox.Show("Thêm sinh viên thành công.");
                    ClearForm();
                    LoadStudentsBySelection(false);
                }
                else
                {
                    MessageBox.Show("Thêm sinh viên thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sinh viên: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMssv.Text.Trim()))
                {
                    MessageBox.Show("Vui lòng chọn sinh viên để sửa.");
                    return;
                }

                if (!ValidateInput())
                    return;

                if (!decimal.TryParse(txtHocBong.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out var hocbong))
                {
                    MessageBox.Show("Học bổng không hợp lệ.");
                    return;
                }

                var sv = new SinhVien
                {
                    Mssv = txtMssv.Text.Trim(),
                    Hoten = txtHoten.Text.Trim(),
                    Phai = cmbPhai.Text.Trim(),
                    Ngaysinh = dtpNgaySinh.Value.Date,
                    Mslop = cmbLop.Text.Trim(),
                    Hocbong = hocbong
                };

                if (_db.SuaSinhVien(sv))
                {
                    MessageBox.Show("Sửa thông tin sinh viên thành công.");
                    LoadStudentsBySelection(false);
                }
                else
                {
                    MessageBox.Show("Sửa thông tin sinh viên thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa sinh viên: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var mssv = txtMssv.Text.Trim();
                if (string.IsNullOrEmpty(mssv))
                {
                    MessageBox.Show("Vui lòng chọn sinh viên để xóa.");
                    return;
                }

                if (MessageBox.Show($"Bạn có chắc muốn xóa sinh viên {mssv} - {txtHoten.Text}?",
                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_db.XoaSinhVien(mssv))
                    {
                        MessageBox.Show("Xóa sinh viên thành công.");
                        ClearForm();
                        LoadStudentsBySelection(false);
                    }
                    else
                    {
                        MessageBox.Show("Xóa sinh viên thất bại.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa sinh viên: " + ex.Message);
            }
        }

        private void btnChuyenLop_Click(object sender, EventArgs e)
        {
            try
            {
                var mssv = txtMssv.Text.Trim();
                if (string.IsNullOrEmpty(mssv))
                {
                    MessageBox.Show("Vui lòng chọn sinh viên để chuyển lớp.");
                    return;
                }

                var currentLop = cmbLop.Text.Trim();
                var newLop = rbChuyenL1toL2.Checked ? "L2" : "L1";

                // Kiểm tra nếu đang chuyển cùng lớp
                if (currentLop == newLop)
                {
                    MessageBox.Show($"Sinh viên đã ở lớp {currentLop}, không cần chuyển.");
                    return;
                }

                string muc = rbMuc1.Checked ? "Mức 1 (Toàn cục)" : "Mức 2 (Phân mảnh)";
                bool success = rbMuc1.Checked
                    ? _db.ChuyenLopMuc1(mssv, newLop)
                    : _db.ChuyenLopMuc2(mssv, newLop);

                if (success)
                {
                    MessageBox.Show($"Chuyển lớp thành công!\nSinh viên {mssv} đã chuyển từ {currentLop} sang {newLop}\nThực thi: {muc}",
                        "Chuyển lớp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudentsBySelection(false);
                }
                else
                {
                    MessageBox.Show("Chuyển lớp thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển lớp: " + ex.Message);
            }
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.CurrentRow == null || grid.CurrentRow.IsNewRow) return;

            try
            {
                var r = grid.CurrentRow;
                txtMssv.Text = r.Cells["mssv"]?.Value?.ToString() ?? string.Empty;
                txtHoten.Text = r.Cells["hoten"]?.Value?.ToString() ?? string.Empty;
                cmbPhai.Text = r.Cells["phai"]?.Value?.ToString() ?? "Nam";
                cmbLop.Text = r.Cells["mslop"]?.Value?.ToString() ?? "L1";
                txtHocBong.Text = r.Cells["hocbong"]?.Value?.ToString() ?? "0";

                if (DateTime.TryParse(r.Cells["ngaysinh"]?.Value?.ToString(), out var ngaySinh))
                    dtpNgaySinh.Value = ngaySinh;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load thông tin sinh viên: " + ex.Message);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtMssv.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên.");
                txtMssv.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtHoten.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập họ tên.");
                txtHoten.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(cmbLop.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn lớp.");
                cmbLop.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtMssv.Text = string.Empty;
            txtHoten.Text = string.Empty;
            txtHocBong.Text = "0";
            cmbPhai.SelectedIndex = 0;
            cmbLop.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now.AddYears(-18); // Mặc định 18 tuổi
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý sự kiện click cell nếu cần
        }

        // ĐÃ XÓA method btnDangKy_Click vì không cần đăng ký môn học
        // ĐÃ XÓA method Dispose vì DatabaseService không cần Dispose
    }
}