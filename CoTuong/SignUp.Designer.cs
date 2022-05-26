namespace CoTuong
{
	partial class SignUp
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
			this.lbName = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lbSex = new System.Windows.Forms.Label();
			this.txtYear = new System.Windows.Forms.TextBox();
			this.lbYear = new System.Windows.Forms.Label();
			this.txtUsr = new System.Windows.Forms.TextBox();
			this.lbUsername = new System.Windows.Forms.Label();
			this.txtPsw = new System.Windows.Forms.TextBox();
			this.lbPsw = new System.Windows.Forms.Label();
			this.txtRePsw = new System.Windows.Forms.TextBox();
			this.lbRePsw = new System.Windows.Forms.Label();
			this.btnSignUp = new System.Windows.Forms.Button();
			this.checkListGender = new System.Windows.Forms.CheckedListBox();
			this.cbHienThiPass = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// lbName
			// 
			this.lbName.AutoSize = true;
			this.lbName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbName.Location = new System.Drawing.Point(43, 42);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(95, 36);
			this.lbName.TabIndex = 0;
			this.lbName.Text = "Họ Tên";
			// 
			// txtName
			// 
			this.txtName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txtName.Location = new System.Drawing.Point(144, 39);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(339, 42);
			this.txtName.TabIndex = 1;
			// 
			// lbSex
			// 
			this.lbSex.AutoSize = true;
			this.lbSex.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbSex.Location = new System.Drawing.Point(526, 42);
			this.lbSex.Name = "lbSex";
			this.lbSex.Size = new System.Drawing.Size(113, 36);
			this.lbSex.TabIndex = 2;
			this.lbSex.Text = "Giới tính";
			// 
			// txtYear
			// 
			this.txtYear.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txtYear.Location = new System.Drawing.Point(615, 109);
			this.txtYear.Name = "txtYear";
			this.txtYear.Size = new System.Drawing.Size(129, 42);
			this.txtYear.TabIndex = 5;
			// 
			// lbYear
			// 
			this.lbYear.AutoSize = true;
			this.lbYear.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbYear.Location = new System.Drawing.Point(486, 109);
			this.lbYear.Name = "lbYear";
			this.lbYear.Size = new System.Drawing.Size(123, 36);
			this.lbYear.TabIndex = 4;
			this.lbYear.Text = "Năm sinh";
			// 
			// txtUsr
			// 
			this.txtUsr.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txtUsr.Location = new System.Drawing.Point(200, 170);
			this.txtUsr.Name = "txtUsr";
			this.txtUsr.Size = new System.Drawing.Size(339, 42);
			this.txtUsr.TabIndex = 7;
			// 
			// lbUsername
			// 
			this.lbUsername.AutoSize = true;
			this.lbUsername.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbUsername.Location = new System.Drawing.Point(43, 170);
			this.lbUsername.Name = "lbUsername";
			this.lbUsername.Size = new System.Drawing.Size(131, 36);
			this.lbUsername.TabIndex = 6;
			this.lbUsername.Text = "Username";
			// 
			// txtPsw
			// 
			this.txtPsw.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txtPsw.Location = new System.Drawing.Point(200, 231);
			this.txtPsw.Name = "txtPsw";
			this.txtPsw.Size = new System.Drawing.Size(339, 42);
			this.txtPsw.TabIndex = 9;
			this.txtPsw.UseSystemPasswordChar = true;
			// 
			// lbPsw
			// 
			this.lbPsw.AutoSize = true;
			this.lbPsw.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbPsw.Location = new System.Drawing.Point(43, 231);
			this.lbPsw.Name = "lbPsw";
			this.lbPsw.Size = new System.Drawing.Size(122, 36);
			this.lbPsw.TabIndex = 8;
			this.lbPsw.Text = "Password";
			// 
			// txtRePsw
			// 
			this.txtRePsw.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txtRePsw.Location = new System.Drawing.Point(200, 291);
			this.txtRePsw.Name = "txtRePsw";
			this.txtRePsw.Size = new System.Drawing.Size(339, 42);
			this.txtRePsw.TabIndex = 11;
			this.txtRePsw.UseSystemPasswordChar = true;
			this.txtRePsw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRePsw_KeyDown);
			// 
			// lbRePsw
			// 
			this.lbRePsw.AutoSize = true;
			this.lbRePsw.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbRePsw.Location = new System.Drawing.Point(43, 294);
			this.lbRePsw.Name = "lbRePsw";
			this.lbRePsw.Size = new System.Drawing.Size(151, 36);
			this.lbRePsw.TabIndex = 10;
			this.lbRePsw.Text = "RePasswrod";
			// 
			// btnSignUp
			// 
			this.btnSignUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.btnSignUp.Location = new System.Drawing.Point(646, 369);
			this.btnSignUp.Name = "btnSignUp";
			this.btnSignUp.Size = new System.Drawing.Size(142, 69);
			this.btnSignUp.TabIndex = 12;
			this.btnSignUp.Text = "Sign Up";
			this.btnSignUp.UseVisualStyleBackColor = true;
			this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
			// 
			// checkListGender
			// 
			this.checkListGender.FormattingEnabled = true;
			this.checkListGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
			this.checkListGender.Location = new System.Drawing.Point(661, 27);
			this.checkListGender.Name = "checkListGender";
			this.checkListGender.Size = new System.Drawing.Size(83, 60);
			this.checkListGender.TabIndex = 26;
			this.checkListGender.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkListGender_ItemCheck);
			// 
			// cbHienThiPass
			// 
			this.cbHienThiPass.AutoSize = true;
			this.cbHienThiPass.Location = new System.Drawing.Point(557, 242);
			this.cbHienThiPass.Name = "cbHienThiPass";
			this.cbHienThiPass.Size = new System.Drawing.Size(82, 29);
			this.cbHienThiPass.TabIndex = 27;
			this.cbHienThiPass.Text = "Show";
			this.cbHienThiPass.UseVisualStyleBackColor = true;
			this.cbHienThiPass.CheckedChanged += new System.EventHandler(this.cbHienThiPass_CheckedChanged);
			// 
			// SignUp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.cbHienThiPass);
			this.Controls.Add(this.checkListGender);
			this.Controls.Add(this.btnSignUp);
			this.Controls.Add(this.txtRePsw);
			this.Controls.Add(this.lbRePsw);
			this.Controls.Add(this.txtPsw);
			this.Controls.Add(this.lbPsw);
			this.Controls.Add(this.txtUsr);
			this.Controls.Add(this.lbUsername);
			this.Controls.Add(this.txtYear);
			this.Controls.Add(this.lbYear);
			this.Controls.Add(this.lbSex);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.lbName);
			this.Name = "SignUp";
			this.Text = "SignUp";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbName;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lbSex;
		private System.Windows.Forms.TextBox txtYear;
		private System.Windows.Forms.Label lbYear;
		private System.Windows.Forms.TextBox txtUsr;
		private System.Windows.Forms.Label lbUsername;
		private System.Windows.Forms.TextBox txtPsw;
		private System.Windows.Forms.Label lbPsw;
		private System.Windows.Forms.TextBox txtRePsw;
		private System.Windows.Forms.Label lbRePsw;
		private System.Windows.Forms.Button btnSignUp;
		public System.Windows.Forms.CheckedListBox checkListGender;
		private System.Windows.Forms.CheckBox cbHienThiPass;
	}
}