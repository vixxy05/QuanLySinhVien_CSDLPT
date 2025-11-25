using System.Windows.Forms;

namespace QuanLySinhVienWinForms
{
	partial class FormLogin
	{
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private TextBox txtServer;
		private TextBox txtDatabase;
		private RadioButton rbWindows;
		private RadioButton rbSql;
		private TextBox txtUser;
		private TextBox txtPassword;
		private Button btnLogin;

		private void InitializeComponent()
		{
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			txtServer = new TextBox();
			txtDatabase = new TextBox();
			rbWindows = new RadioButton();
			rbSql = new RadioButton();
			txtUser = new TextBox();
			txtPassword = new TextBox();
			btnLogin = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(24, 24);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(47, 15);
			label1.TabIndex = 0;
			label1.Text = "Server:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(24, 61);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(61, 15);
			label2.TabIndex = 1;
			label2.Text = "Database:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(24, 134);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(33, 15);
			label3.TabIndex = 2;
			label3.Text = "User:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(24, 170);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(63, 15);
			label4.TabIndex = 3;
			label4.Text = "Password:";
			// 
			// txtServer
			// 
			txtServer.Location = new System.Drawing.Point(112, 21);
			txtServer.Name = "txtServer";
			txtServer.Size = new System.Drawing.Size(240, 23);
			txtServer.TabIndex = 4;
			txtServer.Text = ".\\SQLEXPRESS";
			// 
			// txtDatabase
			// 
			txtDatabase.Location = new System.Drawing.Point(112, 58);
			txtDatabase.Name = "txtDatabase";
			txtDatabase.Size = new System.Drawing.Size(240, 23);
			txtDatabase.TabIndex = 5;
			txtDatabase.Text = "QuanLySinhVien";
			// 
			// rbWindows
			// 
			rbWindows.AutoSize = true;
			rbWindows.Location = new System.Drawing.Point(112, 96);
			rbWindows.Name = "rbWindows";
			rbWindows.Size = new System.Drawing.Size(121, 19);
			rbWindows.TabIndex = 6;
			rbWindows.TabStop = true;
			rbWindows.Text = "Windows Auth";
			rbWindows.UseVisualStyleBackColor = true;
			// 
			// rbSql
			// 
			rbSql.AutoSize = true;
			rbSql.Location = new System.Drawing.Point(239, 96);
			rbSql.Name = "rbSql";
			rbSql.Size = new System.Drawing.Size(77, 19);
			rbSql.TabIndex = 7;
			rbSql.Text = "SQL Auth";
			rbSql.UseVisualStyleBackColor = true;
			// 
			// txtUser
			// 
			txtUser.Location = new System.Drawing.Point(112, 131);
			txtUser.Name = "txtUser";
			txtUser.Size = new System.Drawing.Size(240, 23);
			txtUser.TabIndex = 8;
			// 
			// txtPassword
			// 
			txtPassword.Location = new System.Drawing.Point(112, 167);
			txtPassword.Name = "txtPassword";
			txtPassword.PasswordChar = '*';
			txtPassword.Size = new System.Drawing.Size(240, 23);
			txtPassword.TabIndex = 9;
			// 
			// btnLogin
			// 
			btnLogin.Location = new System.Drawing.Point(112, 209);
			btnLogin.Name = "btnLogin";
			btnLogin.Size = new System.Drawing.Size(240, 32);
			btnLogin.TabIndex = 10;
			btnLogin.Text = "LOGIN";
			btnLogin.UseVisualStyleBackColor = true;
			btnLogin.Click += btnLogin_Click;
			// 
			// FormLogin
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(384, 264);
			Controls.Add(btnLogin);
			Controls.Add(txtPassword);
			Controls.Add(txtUser);
			Controls.Add(rbSql);
			Controls.Add(rbWindows);
			Controls.Add(txtDatabase);
			Controls.Add(txtServer);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "FormLogin";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Đăng nhập SQL Server";
			ResumeLayout(false);
			PerformLayout();
		}
	}
}



