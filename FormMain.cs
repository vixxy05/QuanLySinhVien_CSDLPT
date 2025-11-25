using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace QuanLySinhVienWinForms
{
	public partial class FormMain : Form
	{
		private readonly StudentRepository _repo = new();

		public FormMain()
		{
			InitializeComponent();
			rbMuc1.Checked = true;
			LoadClasses();
		}

		private void LoadClasses()
		{
			cmbLop.Items.Clear();
			cmbLop.Items.Add("L1");
			cmbLop.Items.Add("L2");
			cmbLop.SelectedIndex = 0;
			cmbPhai.Items.Clear();
			cmbPhai.Items.Add("Nam");
			cmbPhai.Items.Add("Nữ");
			cmbPhai.SelectedIndex = 0;
		}

		private void btnTimKiem_Click(object? sender, EventArgs e)
		{
			try
			{
				var mslop = cmbLop.Text.Trim();
				DataTable dt = rbMuc1.Checked ? _repo.GetByClass_Level1(mslop)
											  : _repo.GetByClass_Level2(mslop);
				grid.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
			}
		}

		private void btnThem_Click(object? sender, EventArgs e)
		{
			try
			{
				var mssv = txtMssv.Text.Trim();
				var hoten = txtHoten.Text.Trim();
				var phai = cmbPhai.Text.Trim();
				var mslop = cmbLop.Text.Trim();
				var ngaysinh = dtpNgaySinh.Value.Date;

				if (!decimal.TryParse(txtHocBong.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out var hocbong))
				{
					MessageBox.Show("Học bổng không hợp lệ.");
					return;
				}

				_repo.Insert(mssv, hoten, phai, ngaysinh, mslop, hocbong);
				MessageBox.Show("Thêm thành công.");
				btnTimKiem.PerformClick();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi thêm: " + ex.Message);
			}
		}

		private void btnSua_Click(object? sender, EventArgs e)
		{
			try
			{
				var mssv = txtMssv.Text.Trim();
				var hoten = txtHoten.Text.Trim();
				var phai = cmbPhai.Text.Trim();
				var mslop = cmbLop.Text.Trim();
				var ngaysinh = dtpNgaySinh.Value.Date;

				if (!decimal.TryParse(txtHocBong.Text.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out var hocbong))
				{
					MessageBox.Show("Học bổng không hợp lệ.");
					return;
				}

				_repo.Update(mssv, hoten, phai, ngaysinh, mslop, hocbong);
				MessageBox.Show("Sửa thành công.");
				btnTimKiem.PerformClick();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi sửa: " + ex.Message);
			}
		}

		private void btnXoa_Click(object? sender, EventArgs e)
		{
			try
			{
				var mssv = txtMssv.Text.Trim();
				if (MessageBox.Show($"Xóa sinh viên {mssv}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					_repo.Delete(mssv);
					MessageBox.Show("Xóa thành công.");
					btnTimKiem.PerformClick();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi xóa: " + ex.Message);
			}
		}

		private void btnChuyenLop_Click(object? sender, EventArgs e)
		{
			try
			{
				var mssv = "sv01";
				var newLop = rbChuyenL1toL2.Checked ? "L2" : "L1";

				if (rbMuc1.Checked)
					_repo.ChangeClass_Level1(mssv, newLop);
				else
					_repo.ChangeClass_Level2(mssv, newLop);

				MessageBox.Show("Đã chuyển lớp.");
				btnTimKiem.PerformClick();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi chuyển lớp: " + ex.Message);
			}
		}

		private void grid_SelectionChanged(object? sender, EventArgs e)
		{
			if (grid.CurrentRow == null) return;
			var r = grid.CurrentRow;
			txtMssv.Text = r.Cells["mssv"]?.Value?.ToString() ?? string.Empty;
			txtHoten.Text = r.Cells["hoten"]?.Value?.ToString() ?? string.Empty;
			cmbPhai.Text = r.Cells["phai"]?.Value?.ToString() ?? cmbPhai.Text;
			cmbLop.Text = r.Cells["mslop"]?.Value?.ToString() ?? cmbLop.Text;
			txtHocBong.Text = r.Cells["hocbong"]?.Value?.ToString() ?? txtHocBong.Text;
			if (DateTime.TryParse(r.Cells["ngaysinh"]?.Value?.ToString(), out var d))
				dtpNgaySinh.Value = d;
		}
	}
}



