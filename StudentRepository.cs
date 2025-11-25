using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuanLySinhVienWinForms
{
	public class StudentRepository
	{
		private readonly List<string> _linkedServers = new();

		public bool ExistsByMssv(string mssv)
		{
			var dt = Db.Query("SELECT 1 FROM sinhvien WHERE mssv = @mssv",
				new SqlParameter("@mssv", SqlDbType.VarChar, 10) { Value = mssv });
			if (dt.Rows.Count > 0) return true;

			foreach (var svr in _linkedServers)
			{
				var sql = $"SELECT 1 FROM OPENQUERY([{svr}], 'SELECT 1 FROM QuanLySinhVien.dbo.sinhvien WHERE mssv = ''{mssv}''')";
				try
				{
					var dt2 = Db.Query(sql);
					if (dt2.Rows.Count > 0) return true;
				}
				catch { }
			}
			return false;
		}

		public DataTable GetByClass_Level1(string mslop)
		{
			return Db.ExecProc("sp_Cau3_Muc1",
				new SqlParameter("@mslop", SqlDbType.VarChar, 10) { Value = mslop });
		}

		public DataTable GetByClass_Level2(string mslop)
		{
			return Db.ExecProc("sp_Cau3_Muc2",
				new SqlParameter("@mslop", SqlDbType.VarChar, 10) { Value = mslop });
		}

		public void Insert(string mssv, string hoten, string phai, DateTime ngaysinh, string mslop, decimal hocbong)
		{
			if (ExistsByMssv(mssv))
				throw new InvalidOperationException("Mã sinh viên đã tồn tại (có thể ở server khác).");

			Db.Execute(
				"INSERT INTO sinhvien(mssv, hoten, phai, ngaysinh, mslop, hocbong) VALUES(@mssv, @hoten, @phai, @ngaysinh, @mslop, @hocbong)",
				new SqlParameter("@mssv", SqlDbType.VarChar, 10) { Value = mssv },
				new SqlParameter("@hoten", SqlDbType.NVarChar, 100) { Value = hoten },
				new SqlParameter("@phai", SqlDbType.NVarChar, 10) { Value = phai },
				new SqlParameter("@ngaysinh", SqlDbType.Date) { Value = ngaysinh },
				new SqlParameter("@mslop", SqlDbType.VarChar, 10) { Value = mslop },
				new SqlParameter("@hocbong", SqlDbType.Decimal) { Precision = 10, Scale = 2, Value = hocbong }
			);
		}

		public void Update(string mssv, string hoten, string phai, DateTime ngaysinh, string mslop, decimal hocbong)
		{
			Db.Execute(
				@"UPDATE sinhvien 
				  SET hoten=@hoten, phai=@phai, ngaysinh=@ngaysinh, mslop=@mslop, hocbong=@hocbong
				  WHERE mssv=@mssv",
				new SqlParameter("@mssv", SqlDbType.VarChar, 10) { Value = mssv },
				new SqlParameter("@hoten", SqlDbType.NVarChar, 100) { Value = hoten },
				new SqlParameter("@phai", SqlDbType.NVarChar, 10) { Value = phai },
				new SqlParameter("@ngaysinh", SqlDbType.Date) { Value = ngaysinh },
				new SqlParameter("@mslop", SqlDbType.VarChar, 10) { Value = mslop },
				new SqlParameter("@hocbong", SqlDbType.Decimal) { Precision = 10, Scale = 2, Value = hocbong }
			);
		}

		public void Delete(string mssv)
		{
			Db.Execute("DELETE FROM dangky WHERE mssv=@mssv",
				new SqlParameter("@mssv", SqlDbType.VarChar, 10) { Value = mssv });

			Db.Execute("DELETE FROM sinhvien WHERE mssv=@mssv",
				new SqlParameter("@mssv", SqlDbType.VarChar, 10) { Value = mssv });
		}

		public void ChangeClass_Level1(string mssv, string newMslop)
		{
			Db.ExecProcNonQuery("sp_Cau4_Muc1",
				new SqlParameter("@mssv", SqlDbType.VarChar, 10) { Value = mssv },
				new SqlParameter("@mslop_moi", SqlDbType.VarChar, 10) { Value = newMslop }
			);
		}

		public void ChangeClass_Level2(string mssv, string newMslop)
		{
			Db.ExecProcNonQuery("sp_Cau4_Muc2",
				new SqlParameter("@mssv", SqlDbType.VarChar, 10) { Value = mssv },
				new SqlParameter("@mslop_moi", SqlDbType.VarChar, 10) { Value = newMslop }
			);
		}
	}
}



