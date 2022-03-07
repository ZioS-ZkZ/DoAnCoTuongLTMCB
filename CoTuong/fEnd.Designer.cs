
namespace CoTuong
{
    partial class fEnd
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
			this.rePlay = new System.Windows.Forms.Button();
			this.YOUWIN = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.YOUWIN)).BeginInit();
			this.SuspendLayout();
			// 
			// rePlay
			// 
			this.rePlay.BackColor = System.Drawing.Color.Firebrick;
			this.rePlay.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.rePlay.Location = new System.Drawing.Point(340, 368);
			this.rePlay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.rePlay.Name = "rePlay";
			this.rePlay.Size = new System.Drawing.Size(361, 155);
			this.rePlay.TabIndex = 0;
			this.rePlay.Text = "CHƠI LẠI";
			this.rePlay.UseVisualStyleBackColor = false;
			this.rePlay.Click += new System.EventHandler(this.rePlay_Click);
			// 
			// YOUWIN
			// 
			this.YOUWIN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.YOUWIN.BackColor = System.Drawing.Color.Transparent;
			this.YOUWIN.BackgroundImage = global::CoTuong.Properties.Resources.youwin;
			this.YOUWIN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.YOUWIN.Location = new System.Drawing.Point(92, 124);
			this.YOUWIN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.YOUWIN.Name = "YOUWIN";
			this.YOUWIN.Size = new System.Drawing.Size(830, 236);
			this.YOUWIN.TabIndex = 2;
			this.YOUWIN.TabStop = false;
			// 
			// fEnd
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::CoTuong.Properties.Resources.menucuoigame;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(1016, 775);
			this.Controls.Add(this.YOUWIN);
			this.Controls.Add(this.rePlay);
			this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.Name = "fEnd";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CỜ TƯỚNG";
			((System.ComponentModel.ISupportInitialize)(this.YOUWIN)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button rePlay;
        private System.Windows.Forms.PictureBox YOUWIN;
    }
}