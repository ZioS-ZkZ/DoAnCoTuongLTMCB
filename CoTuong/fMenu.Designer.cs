
namespace CoTuong
{
    partial class fMenu
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
			this.PlayGame = new System.Windows.Forms.Button();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.txtPass = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// PlayGame
			// 
			this.PlayGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.PlayGame.BackColor = System.Drawing.Color.Tomato;
			this.PlayGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.PlayGame.Cursor = System.Windows.Forms.Cursors.Hand;
			this.PlayGame.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.PlayGame.ForeColor = System.Drawing.Color.MistyRose;
			this.PlayGame.Location = new System.Drawing.Point(327, 444);
			this.PlayGame.Margin = new System.Windows.Forms.Padding(4);
			this.PlayGame.Name = "PlayGame";
			this.PlayGame.Size = new System.Drawing.Size(250, 97);
			this.PlayGame.TabIndex = 0;
			this.PlayGame.Text = "LOGIN";
			this.PlayGame.UseVisualStyleBackColor = false;
			this.PlayGame.Click += new System.EventHandler(this.PlayGame_Click);
			// 
			// txtUsername
			// 
			this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txtUsername.Location = new System.Drawing.Point(381, 247);
			this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(290, 39);
			this.txtUsername.TabIndex = 1;
			// 
			// txtPass
			// 
			this.txtPass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txtPass.Location = new System.Drawing.Point(381, 303);
			this.txtPass.Margin = new System.Windows.Forms.Padding(4);
			this.txtPass.Name = "txtPass";
			this.txtPass.Size = new System.Drawing.Size(290, 39);
			this.txtPass.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label1.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label1.ForeColor = System.Drawing.Color.AntiqueWhite;
			this.label1.Location = new System.Drawing.Point(229, 251);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(137, 32);
			this.label1.TabIndex = 3;
			this.label1.Text = "Username";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.label2.ForeColor = System.Drawing.Color.AntiqueWhite;
			this.label2.Location = new System.Drawing.Point(229, 307);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(145, 32);
			this.label2.TabIndex = 4;
			this.label2.Text = "Password";
			// 
			// fMenu
			// 
			this.AccessibleName = "Co Tuong";
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::CoTuong.Properties.Resources.menu;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(875, 736);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPass);
			this.Controls.Add(this.txtUsername);
			this.Controls.Add(this.PlayGame);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximizeBox = false;
			this.Name = "fMenu";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Menu Game Cờ Tướng";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMenu_FormClosing);
			this.Load += new System.EventHandler(this.fMenu_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button PlayGame;
        private System.Windows.Forms.TextBox txtUsername;
		private System.Windows.Forms.TextBox txtPass;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}