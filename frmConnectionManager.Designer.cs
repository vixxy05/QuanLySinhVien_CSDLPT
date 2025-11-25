namespace QuanLySinhVienPhanTan
{
    partial class frmConnectionManager
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
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSetActive = new System.Windows.Forms.Button();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(31, 32);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(161, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chọn máy chủ kết nối";
            // 
            // cmbServer
            // 
            this.cmbServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbServer.Location = new System.Drawing.Point(31, 64);
            this.cmbServer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(307, 28);
            this.cmbServer.TabIndex = 1;
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTest.Location = new System.Drawing.Point(31, 117);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(116, 37);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = false;
            // 
            // btnSetActive
            // 
            this.btnSetActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSetActive.Location = new System.Drawing.Point(154, 117);
            this.btnSetActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSetActive.Name = "btnSetActive";
            this.btnSetActive.Size = new System.Drawing.Size(185, 37);
            this.btnSetActive.TabIndex = 3;
            this.btnSetActive.Text = "Đặt làm mặc định";
            this.btnSetActive.UseVisualStyleBackColor = false;
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(31, 176);
            this.lblCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(203, 20);
            this.lblCurrent.TabIndex = 4;
            this.lblCurrent.Text = "Máy chủ hiện tại: (chưa đặt)";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnClose.Location = new System.Drawing.Point(31, 219);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(309, 40);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // frmConnectionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 285);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.btnSetActive);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.cmbServer);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConnectionManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý kết nối";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnSetActive;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Button btnClose;
    }
}