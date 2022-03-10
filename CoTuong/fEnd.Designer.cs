
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
            this.SuspendLayout();
            // 
            // rePlay
            // 
            this.rePlay.BackColor = System.Drawing.Color.Firebrick;
            this.rePlay.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rePlay.Location = new System.Drawing.Point(265, 285);
            this.rePlay.Name = "rePlay";
            this.rePlay.Size = new System.Drawing.Size(289, 68);
            this.rePlay.TabIndex = 0;
            this.rePlay.Text = "CHƠI LẠI";
            this.rePlay.UseVisualStyleBackColor = false;
            this.rePlay.Click += new System.EventHandler(this.rePlay_Click);
            // 
            // fEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CoTuong.Properties.Resources.Draw;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(813, 620);
            this.Controls.Add(this.rePlay);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MaximizeBox = false;
            this.Name = "fEnd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CỜ TƯỚNG";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button rePlay;
    }
}