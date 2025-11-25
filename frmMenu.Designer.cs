namespace QuanLySinhVienPhanTan
{
	partial class frmMenu
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) components.Dispose();
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.btnQuanLySV = new System.Windows.Forms.Button();
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gridPreview = new System.Windows.Forms.DataGridView();
            this.lblServer = new System.Windows.Forms.Label();
            this.btnDangKyMon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuanLySV
            // 
            this.btnQuanLySV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnQuanLySV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnQuanLySV.Location = new System.Drawing.Point(31, 85);
            this.btnQuanLySV.Margin = new System.Windows.Forms.Padding(4);
            this.btnQuanLySV.Name = "btnQuanLySV";
            this.btnQuanLySV.Size = new System.Drawing.Size(206, 48);
            this.btnQuanLySV.TabIndex = 0;
            this.btnQuanLySV.Text = "Quản lý Sinh viên";
            this.btnQuanLySV.UseVisualStyleBackColor = false;
            this.btnQuanLySV.Click += new System.EventHandler(this.btnQuanLySV_Click);
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnKetNoi.Location = new System.Drawing.Point(300, 90);
            this.btnKetNoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(206, 43);
            this.btnKetNoi.TabIndex = 2;
            this.btnKetNoi.Text = "Quản lý kết nối";
            this.btnKetNoi.UseVisualStyleBackColor = false;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnThoat.Location = new System.Drawing.Point(554, 90);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(206, 43);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Đăng xuất";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(-4, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(352, 20);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Chọn chức năng. Bảng dưới xem nhanh sinh viên";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // gridPreview
            // 
            this.gridPreview.AllowUserToAddRows = false;
            this.gridPreview.AllowUserToDeleteRows = false;
            this.gridPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPreview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridPreview.ColumnHeadersHeight = 34;
            this.gridPreview.Location = new System.Drawing.Point(31, 213);
            this.gridPreview.Margin = new System.Windows.Forms.Padding(4);
            this.gridPreview.MultiSelect = false;
            this.gridPreview.Name = "gridPreview";
            this.gridPreview.ReadOnly = true;
            this.gridPreview.RowHeadersVisible = false;
            this.gridPreview.RowHeadersWidth = 62;
            this.gridPreview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPreview.Size = new System.Drawing.Size(727, 507);
            this.gridPreview.TabIndex = 5;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(31, 187);
            this.lblServer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(0, 20);
            this.lblServer.TabIndex = 6;
            // 
            // btnDangKyMon
            // 
            this.btnDangKyMon.Location = new System.Drawing.Point(0, 0);
            this.btnDangKyMon.Name = "btnDangKyMon";
            this.btnDangKyMon.Size = new System.Drawing.Size(348, 20);
            this.btnDangKyMon.TabIndex = 7;
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 747);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.gridPreview);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnKetNoi);
            this.Controls.Add(this.btnDangKyMon);
            this.Controls.Add(this.btnQuanLySV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.gridPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private System.Windows.Forms.Button btnQuanLySV;
		private System.Windows.Forms.Button btnKetNoi;
		private System.Windows.Forms.Button btnThoat;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.DataGridView gridPreview;
		private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Button btnDangKyMon;
    }
}


