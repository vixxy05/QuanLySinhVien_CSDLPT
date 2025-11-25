using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QuanLySinhVienPhanTan.Models;

namespace QuanLySinhVienPhanTan.Services
{
    public class DatabaseService
    {
        public static string GlobalCurrentServer = "MAIN";

        private string connectionStringMain;
        private string connectionStringServer1;
        private string connectionStringServer2;

        public DatabaseService()
        {
            connectionStringMain = ConfigurationManager.ConnectionStrings["MainServer"].ConnectionString;
            connectionStringServer1 = ConfigurationManager.ConnectionStrings["Server1"].ConnectionString;
            connectionStringServer2 = ConfigurationManager.ConnectionStrings["Server2"].ConnectionString;
        }

        public void SetCurrentServer(string server)
        {
            GlobalCurrentServer = server;
        }

        public string GetCurrentServer()
        {
            return GlobalCurrentServer;
        }

        private string GetConnectionString()
        {
            switch (GlobalCurrentServer)
            {
                case "SERVER1":
                    return connectionStringServer1;
                case "SERVER2":
                    return connectionStringServer2;
                case "MAIN":
                default:
                    return connectionStringMain;
            }
        }
        
        // Public method để các form khác có thể lấy connection string
        public string GetConnectionStringPublic()
        {
            return GetConnectionString();
        }

        public bool TestConnection(string serverType = "MAIN")
        {
            string testConnectionString = "";
            string serverName = "";

            switch (serverType)
            {
                case "SERVER1":
                    testConnectionString = connectionStringServer1;
                    serverName = "Server 1 (SA1)";
                    break;
                case "SERVER2":
                    testConnectionString = connectionStringServer2;
                    serverName = "Server 2 (SA2)";
                    break;
                case "MAIN":
                default:
                    testConnectionString = connectionStringMain;
                    serverName = "Main Server";
                    break;
            }

            try
            {
                using (var connection = new SqlConnection(testConnectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối đến {serverName}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public string GetServerInfo(string serverType = "MAIN")
        {
            string cs = connectionStringMain;
            string name = "Main Server";
            switch (serverType)
            {
                case "SERVER1":
                    cs = connectionStringServer1; name = "Server 1 (SA1)"; break;
                case "SERVER2":
                    cs = connectionStringServer2; name = "Server 2 (SA2)"; break;
            }
            try
            {
                using (var conn = new SqlConnection(cs))
                {
                    conn.Open();

                    // Thông tin server
                    string infoText = string.Empty;
                    using (var cmd = new SqlCommand(@"SELECT
    @@SERVERNAME AS ServerName,
    CAST(SERVERPROPERTY('MachineName') AS nvarchar(128)) AS MachineName,
    CAST(SERVERPROPERTY('InstanceName') AS nvarchar(128)) AS InstanceName,
    CAST(SERVERPROPERTY('ProductVersion') AS nvarchar(128)) AS ProductVersion,
    CAST(SERVERPROPERTY('Edition') AS nvarchar(128)) AS Edition", conn))
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            var serverName = r[0]?.ToString();
                            var machine = r[1]?.ToString();
                            var instance = r[2]?.ToString();
                            var version = r[3]?.ToString();
                            var edition = r[4]?.ToString();
                            infoText = $"{name}\nServerName: {serverName}\nMachine: {machine}\nInstance: {instance}\nVersion: {version}\nEdition: {edition}";
                        }
                    }

                    // Danh sách database + kiểm tra QuanLySinhVien
                    bool hasDb = false;
                    string dbList = string.Empty;
                    using (var cmdDb = new SqlCommand(@"SELECT name FROM sys.databases ORDER BY name", conn))
                    using (var rdb = cmdDb.ExecuteReader())
                    {
                        int count = 0;
                        while (rdb.Read())
                        {
                            var n = rdb.GetString(0);
                            if (n.Equals("QuanLySinhVien", StringComparison.OrdinalIgnoreCase)) hasDb = true;
                            if (count < 20) // tránh quá dài
                            {
                                dbList += (count == 0 ? "" : ", ") + n;
                            }
                            count++;
                        }
                    }

                    infoText += $"\n\nDatabases ({(string.IsNullOrEmpty(dbList) ? 0 : dbList.Split(',').Length)}): {dbList}";
                    infoText += hasDb ? "\nQuanLySinhVien: TỒN TẠI" : "\nQuanLySinhVien: CHƯA CÓ";

                    return infoText;
                }
            }
            catch (Exception ex)
            {
                return $"Không lấy được thông tin: {ex.Message}";
            }
            return "Không lấy được thông tin.";
        }

        public DataTable GetSinhVienByLop(string mslop)
        {
            var dt = new DataTable();
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                using (var command = new SqlCommand("sp_Cau3_Muc1", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@mslop", mslop);
                    connection.Open();
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 208) // Invalid object name
                {
                    var result = MessageBox.Show(
                        $"Stored procedure 'sp_Cau3_Muc1' hoặc bảng 'sinhvien' chưa tồn tại!\n\n" +
                        $"Bạn có muốn mở form tạo database từ script SQL không?",
                        "Database chưa được tạo đầy đủ",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    
                    if (result == DialogResult.Yes)
                    {
                        using (var frm = new frmCreateDatabase())
                        {
                            frm.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public DataTable GetSinhVienByLopPhanManh(string mslop)
        {
            var dt = new DataTable();
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                using (var command = new SqlCommand("sp_Cau3_Muc2", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@mslop", mslop);
                    connection.Open();
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public bool ChuyenLopMuc1(string mssv, string mslopMoi)
        {
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                using (var command = new SqlCommand("sp_Cau4_Muc1", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@mssv", mssv);
                    command.Parameters.AddWithValue("@mslop_moi", mslopMoi);
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ChuyenLopMuc2(string mssv, string mslopMoi)
        {
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                using (var command = new SqlCommand("sp_Cau4_Muc2", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@mssv", mssv);
                    command.Parameters.AddWithValue("@mslop_moi", mslopMoi);
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable GetAllSinhVien()
        {
            var dt = new DataTable();
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                using (var command = new SqlCommand("SELECT * FROM sinhvien", connection))
                {
                    connection.Open();
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 208) // Invalid object name
                {
                    var result = MessageBox.Show(
                        $"Bảng 'sinhvien' chưa tồn tại trong database!\n\n" +
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
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public DataTable GetDangKyByMssv(string mssv)
        {
            var dt = new DataTable();
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                using (var command = new SqlCommand("SELECT * FROM dangky WHERE mssv = @mssv", connection))
                {
                    command.Parameters.AddWithValue("@mssv", mssv);
                    connection.Open();
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public DataTable GetAllMonHoc()
        {
            var dt = new DataTable();
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                using (var command = new SqlCommand("SELECT msmon, tenmon FROM monhoc ORDER BY msmon", connection))
                {
                    connection.Open();
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        public bool ThemDangKy(string mssv, string msmon, decimal d1, decimal d2, decimal d3)
        {
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                using (var command = new SqlCommand(
                    "INSERT INTO dangky(mssv, msmon, diem1, diem2, diem3) VALUES(@mssv, @msmon, @d1, @d2, @d3)", connection))
                {
                    command.Parameters.AddWithValue("@mssv", mssv);
                    command.Parameters.AddWithValue("@msmon", msmon);
                    command.Parameters.AddWithValue("@d1", d1);
                    command.Parameters.AddWithValue("@d2", d2);
                    command.Parameters.AddWithValue("@d3", d3);
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm đăng ký: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SuaDangKy(string mssv, string msmon, decimal d1, decimal d2, decimal d3)
        {
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                using (var command = new SqlCommand(
                    "UPDATE dangky SET diem1=@d1, diem2=@d2, diem3=@d3 WHERE mssv=@mssv AND msmon=@msmon", connection))
                {
                    command.Parameters.AddWithValue("@mssv", mssv);
                    command.Parameters.AddWithValue("@msmon", msmon);
                    command.Parameters.AddWithValue("@d1", d1);
                    command.Parameters.AddWithValue("@d2", d2);
                    command.Parameters.AddWithValue("@d3", d3);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi sửa đăng ký: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaDangKy(string mssv, string msmon)
        {
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                using (var command = new SqlCommand("DELETE FROM dangky WHERE mssv=@mssv AND msmon=@msmon", connection))
                {
                    command.Parameters.AddWithValue("@mssv", mssv);
                    command.Parameters.AddWithValue("@msmon", msmon);
                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa đăng ký: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ThemSinhVien(SinhVien sv)
        {
            try
            {
                if (KiemTraSinhVienTonTai(sv.Mssv))
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Kiểm tra giá trị học bổng hợp lệ (DECIMAL(10,2) = tối đa 99,999,999.99)
                if (sv.Hocbong > 99999999.99m || sv.Hocbong < 0)
                {
                    MessageBox.Show("Học bổng phải trong khoảng 0 đến 99,999,999.99!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                using (var connection = new SqlConnection(GetConnectionString()))
                using (var command = new SqlCommand(
                    "INSERT INTO sinhvien (mssv, hoten, phai, ngaysinh, mslop, hocbong) VALUES (@mssv, @hoten, @phai, @ngaysinh, @mslop, @hocbong)", connection))
                {
                    command.Parameters.AddWithValue("@mssv", sv.Mssv);
                    command.Parameters.AddWithValue("@hoten", sv.Hoten);
                    command.Parameters.AddWithValue("@phai", sv.Phai);
                    command.Parameters.AddWithValue("@ngaysinh", sv.Ngaysinh);
                    command.Parameters.AddWithValue("@mslop", sv.Mslop);
                    // Đảm bảo giá trị học bổng được làm tròn đến 2 chữ số thập phân
                    command.Parameters.AddWithValue("@hocbong", Math.Round(sv.Hocbong, 2));

                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 8115) // Arithmetic overflow
                {
                    MessageBox.Show("Lỗi: Giá trị học bổng quá lớn! Học bổng phải trong khoảng 0 đến 99,999,999.99", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Lỗi thêm sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool XoaSinhVien(string mssv)
        {
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                {
                    connection.Open();
                    
                    // Bắt đầu transaction để đảm bảo tính nhất quán
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // 1. Xóa tất cả đăng ký môn học của sinh viên trước
                            using (var cmdDeleteDangKy = new SqlCommand("DELETE FROM dangky WHERE mssv = @mssv", connection, transaction))
                            {
                                cmdDeleteDangKy.Parameters.AddWithValue("@mssv", mssv);
                                cmdDeleteDangKy.ExecuteNonQuery();
                            }
                            
                            // 2. Sau đó mới xóa sinh viên
                            using (var cmdDeleteSV = new SqlCommand("DELETE FROM sinhvien WHERE mssv = @mssv", connection, transaction))
                            {
                                cmdDeleteSV.Parameters.AddWithValue("@mssv", mssv);
                                int result = cmdDeleteSV.ExecuteNonQuery();
                                
                                if (result > 0)
                                {
                                    transaction.Commit();
                                    return true;
                                }
                                else
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // Foreign key constraint violation
                {
                    MessageBox.Show($"Không thể xóa sinh viên vì còn dữ liệu liên quan!\n\n" +
                        $"Vui lòng xóa tất cả đăng ký môn học của sinh viên này trước.", 
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Lỗi xóa sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool SuaSinhVien(SinhVien sv)
        {
            try
            {
                // Kiểm tra giá trị học bổng hợp lệ (DECIMAL(10,2) = tối đa 99,999,999.99)
                if (sv.Hocbong > 99999999.99m || sv.Hocbong < 0)
                {
                    MessageBox.Show("Học bổng phải trong khoảng 0 đến 99,999,999.99!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                using (var connection = new SqlConnection(GetConnectionString()))
                using (var command = new SqlCommand(
                    "UPDATE sinhvien SET hoten = @hoten, phai = @phai, ngaysinh = @ngaysinh, mslop = @mslop, hocbong = @hocbong WHERE mssv = @mssv", connection))
                {
                    command.Parameters.AddWithValue("@mssv", sv.Mssv);
                    command.Parameters.AddWithValue("@hoten", sv.Hoten);
                    command.Parameters.AddWithValue("@phai", sv.Phai);
                    command.Parameters.AddWithValue("@ngaysinh", sv.Ngaysinh);
                    command.Parameters.AddWithValue("@mslop", sv.Mslop);
                    // Đảm bảo giá trị học bổng được làm tròn đến 2 chữ số thập phân
                    command.Parameters.AddWithValue("@hocbong", Math.Round(sv.Hocbong, 2));

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 8115) // Arithmetic overflow
                {
                    MessageBox.Show("Lỗi: Giá trị học bổng quá lớn! Học bổng phải trong khoảng 0 đến 99,999,999.99", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show($"Lỗi sửa sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi sửa sinh viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable TimKiemSinhVien(string keyword)
        {
            var dt = new DataTable();
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                using (var command = new SqlCommand(
                    "SELECT * FROM sinhvien WHERE mssv LIKE @keyword OR hoten LIKE @keyword OR mslop LIKE @keyword", connection))
                {
                    command.Parameters.AddWithValue("@keyword", $"%{keyword}%");

                    connection.Open();
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        private bool KiemTraSinhVienTonTai(string mssv)
        {
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                using (var command = new SqlCommand("SELECT COUNT(*) FROM sinhvien WHERE mssv = @mssv", connection))
                {
                    command.Parameters.AddWithValue("@mssv", mssv);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        public void DongBoDuLieu()
        {
            try
            {
                DataTable dtSinhVien = GetAllSinhVien();
                DataTable dtLop = GetAllLop();

                DongBoBang("sinhvien", dtSinhVien);
                DongBoBang("lop", dtLop);

                MessageBox.Show("Đồng bộ dữ liệu thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đồng bộ: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetAllLop()
        {
            var dt = new DataTable();
            try
            {
                using (var connection = new SqlConnection(GetConnectionString()))
                using (var command = new SqlCommand("SELECT * FROM lop", connection))
                {
                    connection.Open();
                    var adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        private void DongBoBang(string tableName, DataTable data)
        {
            string[] servers = { "SERVER1", "SERVER2" };

            foreach (string server in servers)
            {
                if (server != GlobalCurrentServer)
                {
                    string connectionString = "";
                    if (server == "SERVER1")
                        connectionString = connectionStringServer1;
                    else if (server == "SERVER2")
                        connectionString = connectionStringServer2;

                    try
                    {
                        using (var connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            using (var deleteCommand = new SqlCommand($"DELETE FROM {tableName}", connection))
                            {
                                deleteCommand.ExecuteNonQuery();
                            }

                            using (var bulkCopy = new SqlBulkCopy(connection))
                            {
                                bulkCopy.DestinationTableName = tableName;
                                bulkCopy.WriteToServer(data);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi đồng bộ {tableName} sang {server}: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}