using System.Data;
using System.Data.SqlClient;

namespace QuanLySinhVienWinForms
{
	public static class Db
	{
		private static string _connectionString = string.Empty;

		public static void SetConnectionString(string connectionString)
		{
			_connectionString = connectionString;
		}

		public static SqlConnection OpenConnection()
		{
			var conn = new SqlConnection(_connectionString);
			conn.Open();
			return conn;
		}

		public static DataTable Query(string sql, params SqlParameter[] parameters)
		{
			using var conn = OpenConnection();
			using var cmd = new SqlCommand(sql, conn);
			if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
			using var da = new SqlDataAdapter(cmd);
			var dt = new DataTable();
			da.Fill(dt);
			return dt;
		}

		public static int Execute(string sql, params SqlParameter[] parameters)
		{
			using var conn = OpenConnection();
			using var cmd = new SqlCommand(sql, conn);
			if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
			return cmd.ExecuteNonQuery();
		}

		public static DataTable ExecProc(string procName, params SqlParameter[] parameters)
		{
			using var conn = OpenConnection();
			using var cmd = new SqlCommand(procName, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
			using var da = new SqlDataAdapter(cmd);
			var dt = new DataTable();
			da.Fill(dt);
			return dt;
		}

		public static int ExecProcNonQuery(string procName, params SqlParameter[] parameters)
		{
			using var conn = OpenConnection();
			using var cmd = new SqlCommand(procName, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
			return cmd.ExecuteNonQuery();
		}
	}
}



