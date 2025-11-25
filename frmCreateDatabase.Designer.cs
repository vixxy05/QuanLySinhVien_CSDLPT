namespace QuanLySinhVienPhanTan
{
	partial class frmCreateDatabase
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblTitle = new System.Windows.Forms.Label();
			this.cmbServer = new System.Windows.Forms.ComboBox();
			this.lblServer = new System.Windows.Forms.Label();
			this.txtScript = new System.Windows.Forms.TextBox();
			this.lblScript = new System.Windows.Forms.Label();
			this.btnExecute = new System.Windows.Forms.Button();
			this.btnLoadFile = new System.Windows.Forms.Button();
			this.rtbOutput = new System.Windows.Forms.RichTextBox();
			this.lblOutput = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTitle.Location = new System.Drawing.Point(12, 15);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(250, 25);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Tạo Database từ Script SQL";
			// 
			// cmbServer
			// 
			this.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbServer.FormattingEnabled = true;
			this.cmbServer.Location = new System.Drawing.Point(100, 50);
			this.cmbServer.Name = "cmbServer";
			this.cmbServer.Size = new System.Drawing.Size(250, 24);
			this.cmbServer.TabIndex = 1;
			// 
			// lblServer
			// 
			this.lblServer.AutoSize = true;
			this.lblServer.Location = new System.Drawing.Point(12, 53);
			this.lblServer.Name = "lblServer";
			this.lblServer.Size = new System.Drawing.Size(82, 16);
			this.lblServer.TabIndex = 2;
			this.lblServer.Text = "Chọn Server:";
			// 
			// txtScript
			// 
			this.txtScript.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtScript.Location = new System.Drawing.Point(12, 100);
			this.txtScript.Multiline = true;
			this.txtScript.Name = "txtScript";
			this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtScript.Size = new System.Drawing.Size(760, 200);
			this.txtScript.TabIndex = 3;
			this.txtScript.WordWrap = false;
			// 
			// lblScript
			// 
			this.lblScript.AutoSize = true;
			this.lblScript.Location = new System.Drawing.Point(12, 81);
			this.lblScript.Name = "lblScript";
			this.lblScript.Size = new System.Drawing.Size(89, 16);
			this.lblScript.TabIndex = 4;
			this.lblScript.Text = "Script SQL:";
			// 
			// btnExecute
			// 
			this.btnExecute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnExecute.Location = new System.Drawing.Point(12, 306);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new System.Drawing.Size(150, 35);
			this.btnExecute.TabIndex = 5;
			this.btnExecute.Text = "Chạy Script";
			this.btnExecute.UseVisualStyleBackColor = false;
			this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
			// 
			// btnLoadFile
			// 
			this.btnLoadFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.btnLoadFile.Location = new System.Drawing.Point(622, 306);
			this.btnLoadFile.Name = "btnLoadFile";
			this.btnLoadFile.Size = new System.Drawing.Size(150, 35);
			this.btnLoadFile.TabIndex = 6;
			this.btnLoadFile.Text = "Tải file SQL...";
			this.btnLoadFile.UseVisualStyleBackColor = false;
			this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
			// 
			// rtbOutput
			// 
			this.rtbOutput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbOutput.Location = new System.Drawing.Point(12, 365);
			this.rtbOutput.Name = "rtbOutput";
			this.rtbOutput.ReadOnly = true;
			this.rtbOutput.Size = new System.Drawing.Size(760, 150);
			this.rtbOutput.TabIndex = 7;
			this.rtbOutput.Text = "";
			// 
			// lblOutput
			// 
			this.lblOutput.AutoSize = true;
			this.lblOutput.Location = new System.Drawing.Point(12, 346);
			this.lblOutput.Name = "lblOutput";
			this.lblOutput.Size = new System.Drawing.Size(58, 16);
			this.lblOutput.TabIndex = 8;
			this.lblOutput.Text = "Kết quả:";
			// 
			// btnClose
			// 
			this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.btnClose.Location = new System.Drawing.Point(622, 521);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(150, 35);
			this.btnClose.TabIndex = 9;
			this.btnClose.Text = "Đóng";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// frmCreateDatabase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 568);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.lblOutput);
			this.Controls.Add(this.rtbOutput);
			this.Controls.Add(this.btnLoadFile);
			this.Controls.Add(this.btnExecute);
			this.Controls.Add(this.lblScript);
			this.Controls.Add(this.txtScript);
			this.Controls.Add(this.lblServer);
			this.Controls.Add(this.cmbServer);
			this.Controls.Add(this.lblTitle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCreateDatabase";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tạo Database từ Script SQL";
			this.Load += new System.EventHandler(this.frmCreateDatabase_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.ComboBox cmbServer;
		private System.Windows.Forms.Label lblServer;
		private System.Windows.Forms.TextBox txtScript;
		private System.Windows.Forms.Label lblScript;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.Button btnLoadFile;
		private System.Windows.Forms.RichTextBox rtbOutput;
		private System.Windows.Forms.Label lblOutput;
		private System.Windows.Forms.Button btnClose;
	}
}



