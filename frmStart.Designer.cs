namespace QuanLySinhVienPhanTan
{
	partial class frmStart
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnLogin = new System.Windows.Forms.Button();
			this.btnDangKy = new System.Windows.Forms.Button();
			this.btnConn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Location = new System.Drawing.Point(24, 20);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(251, 15);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Chọn chức năng để bắt đầu (Login / Đăng ký)";
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(24, 52);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(120, 36);
			this.btnLogin.TabIndex = 1;
			this.btnLogin.Text = "Đăng nhập";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// btnDangKy
			// 
			this.btnDangKy.Location = new System.Drawing.Point(160, 52);
			this.btnDangKy.Name = "btnDangKy";
			this.btnDangKy.Size = new System.Drawing.Size(120, 36);
			this.btnDangKy.TabIndex = 2;
			this.btnDangKy.Text = "Đăng ký môn";
			this.btnDangKy.UseVisualStyleBackColor = true;
			this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
			// 
			// btnConn
			// 
			this.btnConn.Location = new System.Drawing.Point(24, 100);
			this.btnConn.Name = "btnConn";
			this.btnConn.Size = new System.Drawing.Size(256, 30);
			this.btnConn.TabIndex = 3;
			this.btnConn.Text = "Quản lý kết nối";
			this.btnConn.UseVisualStyleBackColor = true;
			this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
			// 
			// frmStart
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(306, 148);
			this.Controls.Add(this.btnConn);
			this.Controls.Add(this.btnDangKy);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.lblTitle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmStart";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bắt đầu";
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Button btnDangKy;
		private System.Windows.Forms.Button btnConn;
	}
}



