using System.Windows.Forms;

namespace QuanLySinhVienWinForms
{
	partial class FormMain
	{
		private Label labelMssv;
		private TextBox txtMssv;
		private Label labelHoten;
		private TextBox txtHoten;
		private Label labelPhai;
		private ComboBox cmbPhai;
		private Label labelNgaySinh;
		private DateTimePicker dtpNgaySinh;
		private Label labelLop;
		private ComboBox cmbLop;
		private Label labelHocBong;
		private TextBox txtHocBong;
		private Button btnThem;
		private Button btnXoa;
		private Button btnSua;
		private Button btnTimKiem;
		private DataGridView grid;
		private GroupBox gbMuc;
		private RadioButton rbMuc1;
		private RadioButton rbMuc2;
		private GroupBox gbChuyen;
		private RadioButton rbChuyenL1toL2;
		private RadioButton rbChuyenL2toL1;
		private Button btnChuyenLop;

		private void InitializeComponent()
		{
			labelMssv = new Label();
			txtMssv = new TextBox();
			labelHoten = new Label();
			txtHoten = new TextBox();
			labelPhai = new Label();
			cmbPhai = new ComboBox();
			labelNgaySinh = new Label();
			dtpNgaySinh = new DateTimePicker();
			labelLop = new Label();
			cmbLop = new ComboBox();
			labelHocBong = new Label();
			txtHocBong = new TextBox();
			btnThem = new Button();
			btnXoa = new Button();
			btnSua = new Button();
			btnTimKiem = new Button();
			grid = new DataGridView();
			gbMuc = new GroupBox();
			rbMuc1 = new RadioButton();
			rbMuc2 = new RadioButton();
			gbChuyen = new GroupBox();
			rbChuyenL1toL2 = new RadioButton();
			rbChuyenL2toL1 = new RadioButton();
			btnChuyenLop = new Button();
			((System.ComponentModel.ISupportInitialize)grid).BeginInit();
			gbMuc.SuspendLayout();
			gbChuyen.SuspendLayout();
			SuspendLayout();
			// 
			// labelMssv
			// 
			labelMssv.AutoSize = true;
			labelMssv.Location = new System.Drawing.Point(16, 16);
			labelMssv.Name = "labelMssv";
			labelMssv.Size = new System.Drawing.Size(38, 15);
			labelMssv.TabIndex = 0;
			labelMssv.Text = "MSSV";
			// 
			// txtMssv
			// 
			txtMssv.Location = new System.Drawing.Point(88, 13);
			txtMssv.Name = "txtMssv";
			txtMssv.Size = new System.Drawing.Size(160, 23);
			txtMssv.TabIndex = 1;
			// 
			// labelHoten
			// 
			labelHoten.AutoSize = true;
			labelHoten.Location = new System.Drawing.Point(264, 16);
			labelHoten.Name = "labelHoten";
			labelHoten.Size = new System.Drawing.Size(47, 15);
			labelHoten.TabIndex = 2;
			labelHoten.Text = "Họ tên";
			// 
			// txtHoten
			// 
			txtHoten.Location = new System.Drawing.Point(328, 13);
			txtHoten.Name = "txtHoten";
			txtHoten.Size = new System.Drawing.Size(200, 23);
			txtHoten.TabIndex = 3;
			// 
			// labelPhai
			// 
			labelPhai.AutoSize = true;
			labelPhai.Location = new System.Drawing.Point(16, 52);
			labelPhai.Name = "labelPhai";
			labelPhai.Size = new System.Drawing.Size(30, 15);
			labelPhai.TabIndex = 4;
			labelPhai.Text = "Phái";
			// 
			// cmbPhai
			// 
			cmbPhai.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbPhai.Location = new System.Drawing.Point(88, 49);
			cmbPhai.Name = "cmbPhai";
			cmbPhai.Size = new System.Drawing.Size(160, 23);
			cmbPhai.TabIndex = 5;
			// 
			// labelNgaySinh
			// 
			labelNgaySinh.AutoSize = true;
			labelNgaySinh.Location = new System.Drawing.Point(264, 52);
			labelNgaySinh.Name = "labelNgaySinh";
			labelNgaySinh.Size = new System.Drawing.Size(62, 15);
			labelNgaySinh.TabIndex = 6;
			labelNgaySinh.Text = "Ngày sinh";
			// 
			// dtpNgaySinh
			// 
			dtpNgaySinh.Location = new System.Drawing.Point(328, 49);
			dtpNgaySinh.Name = "dtpNgaySinh";
			dtpNgaySinh.Size = new System.Drawing.Size(200, 23);
			dtpNgaySinh.TabIndex = 7;
			// 
			// labelLop
			// 
			labelLop.AutoSize = true;
			labelLop.Location = new System.Drawing.Point(16, 88);
			labelLop.Name = "labelLop";
			labelLop.Size = new System.Drawing.Size(26, 15);
			labelLop.TabIndex = 8;
			labelLop.Text = "Lớp";
			// 
			// cmbLop
			// 
			cmbLop.DropDownStyle = ComboBoxStyle.DropDownList;
			cmbLop.Location = new System.Drawing.Point(88, 85);
			cmbLop.Name = "cmbLop";
			cmbLop.Size = new System.Drawing.Size(160, 23);
			cmbLop.TabIndex = 9;
			// 
			// labelHocBong
			// 
			labelHocBong.AutoSize = true;
			labelHocBong.Location = new System.Drawing.Point(264, 88);
			labelHocBong.Name = "labelHocBong";
			labelHocBong.Size = new System.Drawing.Size(58, 15);
			labelHocBong.TabIndex = 10;
			labelHocBong.Text = "Học bổng";
			// 
			// txtHocBong
			// 
			txtHocBong.Location = new System.Drawing.Point(328, 85);
			txtHocBong.Name = "txtHocBong";
			txtHocBong.Size = new System.Drawing.Size(200, 23);
			txtHocBong.TabIndex = 11;
			// 
			// btnThem
			// 
			btnThem.Location = new System.Drawing.Point(552, 12);
			btnThem.Name = "btnThem";
			btnThem.Size = new System.Drawing.Size(96, 28);
			btnThem.TabIndex = 12;
			btnThem.Text = "THÊM";
			btnThem.UseVisualStyleBackColor = true;
			btnThem.Click += btnThem_Click;
			// 
			// btnXoa
			// 
			btnXoa.Location = new System.Drawing.Point(552, 46);
			btnXoa.Name = "btnXoa";
			btnXoa.Size = new System.Drawing.Size(96, 28);
			btnXoa.TabIndex = 13;
			btnXoa.Text = "XÓA";
			btnXoa.UseVisualStyleBackColor = true;
			btnXoa.Click += btnXoa_Click;
			// 
			// btnSua
			// 
			btnSua.Location = new System.Drawing.Point(552, 80);
			btnSua.Name = "btnSua";
			btnSua.Size = new System.Drawing.Size(96, 28);
			btnSua.TabIndex = 14;
			btnSua.Text = "SỬA";
			btnSua.UseVisualStyleBackColor = true;
			btnSua.Click += btnSua_Click;
			// 
			// btnTimKiem
			// 
			btnTimKiem.Location = new System.Drawing.Point(552, 114);
			btnTimKiem.Name = "btnTimKiem";
			btnTimKiem.Size = new System.Drawing.Size(96, 28);
			btnTimKiem.TabIndex = 15;
			btnTimKiem.Text = "TÌM KIẾM";
			btnTimKiem.UseVisualStyleBackColor = true;
			btnTimKiem.Click += btnTimKiem_Click;
			// 
			// grid
			// 
			grid.AllowUserToAddRows = false;
			grid.AllowUserToDeleteRows = false;
			grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			grid.Location = new System.Drawing.Point(16, 200);
			grid.MultiSelect = false;
			grid.Name = "grid";
			grid.ReadOnly = true;
			grid.RowHeadersVisible = false;
			grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			grid.Size = new System.Drawing.Size(760, 280);
			grid.TabIndex = 16;
			grid.SelectionChanged += grid_SelectionChanged;
			// 
			// gbMuc
			// 
			gbMuc.Controls.Add(rbMuc2);
			gbMuc.Controls.Add(rbMuc1);
			gbMuc.Location = new System.Drawing.Point(16, 120);
			gbMuc.Name = "gbMuc";
			gbMuc.Size = new System.Drawing.Size(240, 64);
			gbMuc.TabIndex = 17;
			gbMuc.TabStop = false;
			gbMuc.Text = "Mức thực thi";
			// 
			// rbMuc1
			// 
			rbMuc1.AutoSize = true;
			rbMuc1.Location = new System.Drawing.Point(16, 28);
			rbMuc1.Name = "rbMuc1";
			rbMuc1.Size = new System.Drawing.Size(103, 19);
			rbMuc1.TabIndex = 0;
			rbMuc1.TabStop = true;
			rbMuc1.Text = "Mức 1 (global)";
			rbMuc1.UseVisualStyleBackColor = true;
			// 
			// rbMuc2
			// 
			rbMuc2.AutoSize = true;
			rbMuc2.Location = new System.Drawing.Point(128, 28);
			rbMuc2.Name = "rbMuc2";
			rbMuc2.Size = new System.Drawing.Size(95, 19);
			rbMuc2.TabIndex = 1;
			rbMuc2.Text = "Mức 2 (view)";
			rbMuc2.UseVisualStyleBackColor = true;
			// 
			// gbChuyen
			// 
			gbChuyen.Controls.Add(rbChuyenL2toL1);
			gbChuyen.Controls.Add(rbChuyenL1toL2);
			gbChuyen.Location = new System.Drawing.Point(272, 120);
			gbChuyen.Name = "gbChuyen";
			gbChuyen.Size = new System.Drawing.Size(256, 64);
			gbChuyen.TabIndex = 18;
			gbChuyen.TabStop = false;
			gbChuyen.Text = "Chuyển lớp sv01";
			// 
			// rbChuyenL1toL2
			// 
			rbChuyenL1toL2.AutoSize = true;
			rbChuyenL1toL2.Location = new System.Drawing.Point(16, 28);
			rbChuyenL1toL2.Name = "rbChuyenL1toL2";
			rbChuyenL1toL2.Size = new System.Drawing.Size(98, 19);
			rbChuyenL1toL2.TabIndex = 0;
			rbChuyenL1toL2.TabStop = true;
			rbChuyenL1toL2.Text = "L1 → L2";
			rbChuyenL1toL2.UseVisualStyleBackColor = true;
			// 
			// rbChuyenL2toL1
			// 
			rbChuyenL2toL1.AutoSize = true;
			rbChuyenL2toL1.Location = new System.Drawing.Point(128, 28);
			rbChuyenL2toL1.Name = "rbChuyenL2toL1";
			rbChuyenL2toL1.Size = new System.Drawing.Size(98, 19);
			rbChuyenL2toL1.TabIndex = 1;
			rbChuyenL2toL1.Text = "L2 → L1";
			rbChuyenL2toL1.UseVisualStyleBackColor = true;
			// 
			// btnChuyenLop
			// 
			btnChuyenLop.Location = new System.Drawing.Point(552, 148);
			btnChuyenLop.Name = "btnChuyenLop";
			btnChuyenLop.Size = new System.Drawing.Size(96, 28);
			btnChuyenLop.TabIndex = 19;
			btnChuyenLop.Text = "Chuyển lớp";
			btnChuyenLop.UseVisualStyleBackColor = true;
			btnChuyenLop.Click += btnChuyenLop_Click;
			// 
			// FormMain
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(800, 500);
			Controls.Add(btnChuyenLop);
			Controls.Add(gbChuyen);
			Controls.Add(gbMuc);
			Controls.Add(grid);
			Controls.Add(btnTimKiem);
			Controls.Add(btnSua);
			Controls.Add(btnXoa);
			Controls.Add(btnThem);
			Controls.Add(txtHocBong);
			Controls.Add(labelHocBong);
			Controls.Add(cmbLop);
			Controls.Add(labelLop);
			Controls.Add(dtpNgaySinh);
			Controls.Add(labelNgaySinh);
			Controls.Add(cmbPhai);
			Controls.Add(labelPhai);
			Controls.Add(txtHoten);
			Controls.Add(labelHoten);
			Controls.Add(txtMssv);
			Controls.Add(labelMssv);
			Name = "FormMain";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Quản lý Sinh viên";
			((System.ComponentModel.ISupportInitialize)grid).EndInit();
			gbMuc.ResumeLayout(false);
			gbMuc.PerformLayout();
			gbChuyen.ResumeLayout(false);
			gbChuyen.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}



