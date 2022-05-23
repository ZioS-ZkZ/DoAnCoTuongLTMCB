
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
//            labelTimerDo = new System.Windows.Forms.Label();
//            labelTimerDen = new System.Windows.Forms.Label();
//            this.plLobby = new System.Windows.Forms.Panel();
//            this.btTimPhong = new System.Windows.Forms.Button();
//            this.btTaoPhong = new System.Windows.Forms.Button();
//            this.lbDanhSachPhong = new System.Windows.Forms.ListBox();
//            this.rtbBoxSend = new System.Windows.Forms.RichTextBox();
//            this.rtbContentChat = new System.Windows.Forms.RichTextBox();
//            ((System.ComponentModel.ISupportInitialize)(this.undo)).BeginInit();
//            this.plLobby.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // undo
//            // 
//            this.undo.BackColor = System.Drawing.Color.Transparent;
//            this.undo.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.undo.Image = ((System.Drawing.Image)(resources.GetObject("undo.Image")));
//            this.undo.Location = new System.Drawing.Point(1503, 37);
//            this.undo.Name = "undo";
//            this.undo.Size = new System.Drawing.Size(74, 74);
//            this.undo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
//            this.undo.TabIndex = 0;
//            this.undo.TabStop = false;
//            this.undo.Click += new System.EventHandler(this.undo_Click);
//            // 
//            // NewGame
//            // 
//            this.NewGame.AutoSize = true;
//            this.NewGame.BackColor = System.Drawing.Color.Chocolate;
//            this.NewGame.Cursor = System.Windows.Forms.Cursors.Hand;
//            this.NewGame.Font = new System.Drawing.Font("Showcard Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
//            this.NewGame.Location = new System.Drawing.Point(1629, 37);
//            this.NewGame.Name = "NewGame";
//            this.NewGame.Size = new System.Drawing.Size(215, 73);
//            this.NewGame.TabIndex = 1;
//            this.NewGame.Text = "NEWGAME";
//            this.NewGame.UseVisualStyleBackColor = false;
//            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
//            // 
//            // lichSuDen
//            // 
//            lichSuDen.BackColor = System.Drawing.Color.NavajoWhite;
//            lichSuDen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            lichSuDen.Location = new System.Drawing.Point(81, 335);
//            lichSuDen.Margin = new System.Windows.Forms.Padding(2);
//            lichSuDen.Multiline = true;
//            lichSuDen.Name = "lichSuDen";
//            lichSuDen.ReadOnly = true;
//            lichSuDen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
//            lichSuDen.Size = new System.Drawing.Size(342, 190);
//            lichSuDen.TabIndex = 3;
//            // 
//            // lichSuDo
//            // 
//            lichSuDo.BackColor = System.Drawing.Color.NavajoWhite;
//            lichSuDo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//            lichSuDo.Location = new System.Drawing.Point(81, 565);
//            lichSuDo.Margin = new System.Windows.Forms.Padding(2);
//            lichSuDo.Multiline = true;
//            lichSuDo.Name = "lichSuDo";
//            lichSuDo.ReadOnly = true;
//            lichSuDo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
//            lichSuDo.Size = new System.Drawing.Size(342, 190);
//            lichSuDo.TabIndex = 4;
//            // 
//            // labelTimerDo
//            // 
//            labelTimerDo.AutoSize = true;
//            labelTimerDo.BackColor = System.Drawing.Color.Transparent;
//            labelTimerDo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
//            labelTimerDo.ForeColor = System.Drawing.SystemColors.ControlText;
//            labelTimerDo.Location = new System.Drawing.Point(189, 1005);
//            labelTimerDo.Name = "labelTimerDo";
//            labelTimerDo.Size = new System.Drawing.Size(0, 37);
//            labelTimerDo.TabIndex = 6;
//            labelTimerDo.Tag = "";
//            // 
//            // labelTimerDen
//            // 
//            labelTimerDen.AutoSize = true;
//            labelTimerDen.BackColor = System.Drawing.Color.Transparent;
//            labelTimerDen.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
//            labelTimerDen.ForeColor = System.Drawing.SystemColors.ControlText;
//            labelTimerDen.Location = new System.Drawing.Point(189, 43);
//            labelTimerDen.Name = "labelTimerDen";
//            labelTimerDen.Size = new System.Drawing.Size(0, 37);
//            labelTimerDen.TabIndex = 8;
//            labelTimerDen.Tag = "";
//            // 
//            // plLobby
//            // 
//            this.plLobby.Controls.Add(this.btTimPhong);
//            this.plLobby.Controls.Add(this.btTaoPhong);
//            this.plLobby.Controls.Add(this.lbDanhSachPhong);
//            this.plLobby.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.plLobby.Location = new System.Drawing.Point(0, 0);
//            this.plLobby.Name = "plLobby";
//            this.plLobby.Size = new System.Drawing.Size(1920, 1080);
//            this.plLobby.TabIndex = 9;
//            // 
//            // btTimPhong
//            // 
//            this.btTimPhong.Location = new System.Drawing.Point(824, 736);
//            this.btTimPhong.Name = "btTimPhong";
//            this.btTimPhong.Size = new System.Drawing.Size(169, 66);
//            this.btTimPhong.TabIndex = 2;
//            this.btTimPhong.Text = "Tìm Phòng";
//            this.btTimPhong.UseVisualStyleBackColor = true;
//            this.btTimPhong.Click += new System.EventHandler(this.btTimPhong_Click);
//            // 
//            // btTaoPhong
//            // 
//            this.btTaoPhong.Location = new System.Drawing.Point(532, 736);
//            this.btTaoPhong.Name = "btTaoPhong";
//            this.btTaoPhong.Size = new System.Drawing.Size(169, 66);
//            this.btTaoPhong.TabIndex = 1;
//            this.btTaoPhong.Text = "Tạo Phòng";
//            this.btTaoPhong.UseVisualStyleBackColor = true;
//            this.btTaoPhong.Click += new System.EventHandler(this.btTaoPhong_Click);
//            // 
//            // lbDanhSachPhong
//            // 
//            this.lbDanhSachPhong.FormattingEnabled = true;
//            this.lbDanhSachPhong.ItemHeight = 20;
//            this.lbDanhSachPhong.Location = new System.Drawing.Point(532, 92);
//            this.lbDanhSachPhong.Name = "lbDanhSachPhong";
//            this.lbDanhSachPhong.Size = new System.Drawing.Size(461, 624);
//            this.lbDanhSachPhong.TabIndex = 0;
//            // rtbBoxSend
//            // 
//            this.rtbBoxSend.Location = new System.Drawing.Point(1535, 993);
//            this.rtbBoxSend.Name = "rtbBoxSend";
//            this.rtbBoxSend.Size = new System.Drawing.Size(344, 49);
//            this.rtbBoxSend.TabIndex = 10;
//            this.rtbBoxSend.Text = "";
//            // 
//            // rtbContentChat
//            // 
//            this.rtbContentChat.Location = new System.Drawing.Point(1535, 320);
//            this.rtbContentChat.Name = "rtbContentChat";
//            this.rtbContentChat.Size = new System.Drawing.Size(344, 620);
//            this.rtbContentChat.TabIndex = 11;
//            this.rtbContentChat.Text = "";
//            // 
//            // fBanCo
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.NavajoWhite;
//            this.BackgroundImage = global::CoTuong.Properties.Resources.board;
//            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
//            this.ClientSize = new System.Drawing.Size(1920, 1080);
//            this.Controls.Add(this.plLobby);
//            this.Controls.Add(labelTimerDen);
//            this.Controls.Add(labelTimerDo);
//            this.Controls.Add(lichSuDo);
//            this.Controls.Add(lichSuDen);
//            this.Controls.Add(NewGame);
//            this.Controls.Add(undo);
//            this.Controls.Add(rtbBoxSend);
//            this.Controls.Add(rtbContentChat);
//            this.DoubleBuffered = true;
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
//            this.MaximizeBox = false;
//            this.Name = "fBanCo";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Text = "CoTuong";
//            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.closeFormBanCo);
//            this.Load += new System.EventHandler(this.fBanCo_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.undo)).EndInit();
//            this.plLobby.ResumeLayout(false);
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.RichTextBox rtbBoxSend;
//        private System.Windows.Forms.RichTextBox rtbContentChat;
//        private System.Windows.Forms.PictureBox undo;
//        private System.Windows.Forms.Button NewGame;
//        private System.Windows.Forms.Panel plLobby;
//        private System.Windows.Forms.Button btTimPhong;
//        private System.Windows.Forms.Button btTaoPhong;
//        private System.Windows.Forms.ListBox lbDanhSachPhong;
//        public static System.Windows.Forms.Label labelTimerDo;
//        public static System.Windows.Forms.Label labelTimerDen;
//        public static System.Windows.Forms.TextBox lichSuDen;
//        public static System.Windows.Forms.TextBox lichSuDo;
//    }
//}

