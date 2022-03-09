
//namespace CoTuong
//{
//    partial class fBanCo
//    {
//        /// <summary>
//        ///  Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        ///  Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        ///  Required method for Designer support - do not modify
//        ///  the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBanCo));
//            this.undo = new System.Windows.Forms.PictureBox();
//            this.NewGame = new System.Windows.Forms.Button();
//            lichSuDen = new System.Windows.Forms.TextBox();
//            lichSuDo = new System.Windows.Forms.TextBox();
//            this.btChat = new System.Windows.Forms.Button();
//            labelTimerDo = new System.Windows.Forms.Label();
//            labelTimerDen = new System.Windows.Forms.Label();
//            ((System.ComponentModel.ISupportInitialize)(this.undo)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // undo
//            // 
//            this.undo.BackColor = System.Drawing.Color.Transparent;
//            this.undo.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.undo.Image = ((System.Drawing.Image)(resources.GetObject("undo.Image")));
//            this.undo.Name = "undo";
//            this.undo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
//            this.undo.TabIndex = 0;
//            this.undo.TabStop = false;
//            this.undo.Click += new System.EventHandler(this.undo_Click);
//            this.undo.Top = 37;
//            this.undo.Left = 569;
//            this.undo.Width = 48;
//            this.undo.Height = 48;
//            // 
//            // NewGame
//            // 
//            this.NewGame.AutoSize = true;
//            this.NewGame.BackColor = System.Drawing.Color.SaddleBrown;
//            this.NewGame.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.NewGame.Font = new System.Drawing.Font("Showcard Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
//            this.NewGame.Name = "NewGame";
//            this.NewGame.TabIndex = 1;
//            this.NewGame.Text = "NEWGAME";
//            this.NewGame.UseVisualStyleBackColor = false;
//            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
//            this.NewGame.Top = 37;
//            this.NewGame.Left = 660;
//            this.NewGame.Width = 120;
//            this.NewGame.Height = 48;
//            // 
//            // lichSuDen
//            // 
//            lichSuDen.BackColor = System.Drawing.Color.NavajoWhite;
//            lichSuDen.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            lichSuDen.Margin = new System.Windows.Forms.Padding(2);
//            lichSuDen.Multiline = true;
//            lichSuDen.Name = "lichSuDen";
//            lichSuDen.ReadOnly = true;
//            lichSuDen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
//            lichSuDen.TabIndex = 3;
//            lichSuDen.Width = 200;
//            lichSuDen.Height = 101;
//            lichSuDen.Top = 177;
//            lichSuDen.Left = 610;
//            // 
//            // lichSuDo
//            // 
//            lichSuDo.BackColor = System.Drawing.Color.NavajoWhite;
//            lichSuDo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            lichSuDo.Margin = new System.Windows.Forms.Padding(2);
//            lichSuDo.Multiline = true;
//            lichSuDo.Name = "lichSuDo";
//            lichSuDo.ReadOnly = true;
//            lichSuDo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
//            lichSuDo.TabIndex = 4;
//            lichSuDo.Width = 200;
//            lichSuDo.Height = 101;
//            lichSuDo.Top = 377;
//            lichSuDo.Left = 610;
//            // 
//            // btChat
//            // 
//            this.btChat.BackColor = System.Drawing.Color.Moccasin;
//            this.btChat.BackgroundImage = global::CoTuong.Properties.Resources.iconMess;
//            this.btChat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
//            this.btChat.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.btChat.Name = "btChat";
//            this.btChat.TabIndex = 5;
//            this.btChat.UseVisualStyleBackColor = false;
//            this.btChat.Top = 500;
//            this.btChat.Left = 740;
//            this.btChat.Width = 60;
//            this.btChat.Height = 60;
//            this.btChat.Click += new System.EventHandler(this.btChat_Click);
//            // 
//            // labelTimerDo
//            // 
//            labelTimerDo.AutoSize = true;
//            labelTimerDo.BackColor = System.Drawing.Color.Transparent;
//            labelTimerDo.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
//            labelTimerDo.ForeColor = System.Drawing.SystemColors.ControlText;
//            labelTimerDo.Name = "labelTimerDo";
//            labelTimerDo.TabIndex = 6;
//            labelTimerDo.Tag = "";
//            labelTimerDo.Width = 0;
//            labelTimerDo.Height = 32;
//            labelTimerDo.Top = 335;
//            labelTimerDo.Left = 518;
//            // 
//            // labelTimerDen
//            // 
//            labelTimerDen.AutoSize = true;
//            labelTimerDen.BackColor = System.Drawing.Color.Transparent;
//            labelTimerDen.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
//            labelTimerDen.ForeColor = System.Drawing.SystemColors.ControlText;
//            labelTimerDen.Name = "labelTimerDen";
//            labelTimerDen.TabIndex = 8;
//            labelTimerDen.Tag = "";
//            labelTimerDen.Width = 0;
//            labelTimerDen.Height = 32;
//            labelTimerDen.Top = 133;
//            labelTimerDen.Left = 518;
//            // 
//            // fBanCo
//            // 
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.NavajoWhite;
//            this.BackgroundImage = global::CoTuong.Properties.Resources.bk1;
//            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
//            this.Controls.Add(labelTimerDen);
//            this.Controls.Add(labelTimerDo);
//            this.Controls.Add(this.btChat);
//            this.Controls.Add(lichSuDo);
//            this.Controls.Add(lichSuDen);
//            this.Controls.Add(this.NewGame);
//            this.Controls.Add(this.undo);
//            this.DoubleBuffered = true;
//            this.MaximizeBox = false;
//            this.Name = "fBanCo";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
//            this.Text = "CoTuong";
//            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.closeFormBanCo);
//            ((System.ComponentModel.ISupportInitialize)(this.undo)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();
//            this.Width = 820;
//            this.Height = 560;

//        }

//        #endregion

//        private System.Windows.Forms.PictureBox undo;
//        private System.Windows.Forms.Button NewGame;
//        private System.Windows.Forms.Button btChat;
//        public static System.Windows.Forms.Label labelTimerDo;
//        public static System.Windows.Forms.Label labelTimerDen;
//        public static System.Windows.Forms.TextBox lichSuDen;
//        public static System.Windows.Forms.TextBox lichSuDo;
//    }
//}

