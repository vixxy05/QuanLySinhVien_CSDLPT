using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using QuanLySinhVienPhanTan.Models;
using QuanLySinhVienPhanTan.Services;

namespace QuanLySinhVienPhanTan
{
	public partial class frmSinhVien : Form
	{
		private readonly DatabaseService _db = new DatabaseService();

		public frmSinhVien()
		{
			InitializeComponent();
			LoadLookups();
			WireEvents();
		}

		private void LoadLookups()
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

		private void WireEvents()
		{
			btnThem.Click += btnThem_Click;
			btnXoa.Click += btnXoa_Click;
			btnSua.Click += btnSua_Click;
			btnTimKiem.Click += btnTimKiem_Click;
			grid.SelectionChanged += grid_SelectionChanged;
		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			try
			{
				var keyword = txtKeyword.Text.Trim();
				DataTable dt = string.IsNullOrEmpty(keyword)
					? _db.GetAllSinhVien()
					: _db.TimKiemSinhVien(keyword);
				grid.DataSource = dt;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
			}
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			try
			{
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
					MessageBox.Show("Thêm thành công.");
					btnTimKiem.PerformClick();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi thêm: " + ex.Message);
			}
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			try
			{
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
					MessageBox.Show("Sửa thành công.");
					btnTimKiem.PerformClick();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi sửa: " + ex.Message);
			}
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			try
			{
				var mssv = txtMssv.Text.Trim();
				if (MessageBox.Show($"Xóa sinh viên {mssv}?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					if (_db.XoaSinhVien(mssv))
					{
						MessageBox.Show("Xóa thành công.");
						btnTimKiem.PerformClick();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi xóa: " + ex.Message);
			}
		}

		private void grid_SelectionChanged(object sender, EventArgs e)
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
