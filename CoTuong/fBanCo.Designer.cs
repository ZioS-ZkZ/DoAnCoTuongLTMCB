
namespace CoTuong
{
	partial class fBanCo
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBanCo));
			this.undo = new System.Windows.Forms.PictureBox();
			this.NewGame = new System.Windows.Forms.Button();
			lichSuDen = new System.Windows.Forms.TextBox();
			lichSuDo = new System.Windows.Forms.TextBox();
			labelTimerDo = new System.Windows.Forms.Label();
			labelTimerDen = new System.Windows.Forms.Label();
			this.plLobby = new System.Windows.Forms.Panel();
			this.btTimPhong = new System.Windows.Forms.Button();
			this.btTaoPhong = new System.Windows.Forms.Button();
			this.lbDanhSachPhong = new System.Windows.Forms.ListBox();
			this.rtbBoxSend = new System.Windows.Forms.RichTextBox();
			this.rtbContentChat = new System.Windows.Forms.RichTextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.lbDetail = new System.Windows.Forms.Label();
			this.lbHistory = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.lbName = new System.Windows.Forms.Label();
			this.lbSex = new System.Windows.Forms.Label();
			this.lbBirth = new System.Windows.Forms.Label();
			this.lbWin = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.Label();
			this.txtSex = new System.Windows.Forms.Label();
			this.txtBirth = new System.Windows.Forms.Label();
			this.txtWin = new System.Windows.Forms.Label();
			this.txtLose = new System.Windows.Forms.Label();
			this.lbLose = new System.Windows.Forms.Label();
			this.txtDraw = new System.Windows.Forms.Label();
			this.lbDraw = new System.Windows.Forms.Label();
			this.listViewHistory = new System.Windows.Forms.ListView();
			this.Enemy = new System.Windows.Forms.ColumnHeader();
			this.Result = new System.Windows.Forms.ColumnHeader();
			this.Nums = new System.Windows.Forms.ColumnHeader();
			this.Time = new System.Windows.Forms.ColumnHeader();
			cmbSelectColor = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.undo)).BeginInit();
			this.plLobby.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// undo
			// 
			this.undo.BackColor = System.Drawing.Color.Transparent;
			this.undo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.undo.Image = ((System.Drawing.Image)(resources.GetObject("undo.Image")));
			this.undo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.undo.Name = "undo";
			this.undo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.undo.TabIndex = 0;
			this.undo.TabStop = false;
			this.undo.Click += new System.EventHandler(this.undo_Click);
			this.undo.Top = 37;
			this.undo.Left = 1503;
			this.undo.Width = 74;
			this.undo.Height = 74;
			// 
			// NewGame
			// 
			this.NewGame.AutoSize = true;
			this.NewGame.BackColor = System.Drawing.Color.Chocolate;
			this.NewGame.Cursor = System.Windows.Forms.Cursors.Hand;
			this.NewGame.Font = new System.Drawing.Font("Showcard Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.NewGame.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.NewGame.Name = "NewGame";
			this.NewGame.TabIndex = 1;
			this.NewGame.Text = "NEWGAME";
			this.NewGame.UseVisualStyleBackColor = false;
			this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
			this.NewGame.Top = 37;
			this.NewGame.Left = 1629;
			this.NewGame.Width = 215;
			this.NewGame.Height = 73;
			// 
			// lichSuDen
			// 
			lichSuDen.BackColor = System.Drawing.Color.NavajoWhite;
			lichSuDen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			lichSuDen.Margin = new System.Windows.Forms.Padding(2);
			lichSuDen.Multiline = true;
			lichSuDen.Name = "lichSuDen";
			lichSuDen.ReadOnly = true;
			lichSuDen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			lichSuDen.TabIndex = 3;
			lichSuDen.Width = 342;
			lichSuDen.Height = 190;
			lichSuDen.Top = 335;
			lichSuDen.Left = 81;
			// 
			// lichSuDo
			// 
			lichSuDo.BackColor = System.Drawing.Color.NavajoWhite;
			lichSuDo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			lichSuDo.Margin = new System.Windows.Forms.Padding(2);
			lichSuDo.Multiline = true;
			lichSuDo.Name = "lichSuDo";
			lichSuDo.ReadOnly = true;
			lichSuDo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			lichSuDo.TabIndex = 4;
			lichSuDo.Width = 342;
			lichSuDo.Height = 190;
			lichSuDo.Top = 565;
			lichSuDo.Left = 81;
			// 
			// labelTimerDo
			// 
			labelTimerDo.AutoSize = true;
			labelTimerDo.BackColor = System.Drawing.Color.Transparent;
			labelTimerDo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			labelTimerDo.ForeColor = System.Drawing.SystemColors.ControlText;
			labelTimerDo.Name = "labelTimerDo";
			labelTimerDo.TabIndex = 6;
			labelTimerDo.Tag = "";
			labelTimerDo.Width = 101;
			labelTimerDo.Height = 45;
			labelTimerDo.Top = 1005;
			labelTimerDo.Left = 189;
			// 
			// labelTimerDen
			// 
			labelTimerDen.AutoSize = true;
			labelTimerDen.BackColor = System.Drawing.Color.Transparent;
			labelTimerDen.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			labelTimerDen.ForeColor = System.Drawing.SystemColors.ControlText;
			labelTimerDen.Name = "labelTimerDen";
			labelTimerDen.TabIndex = 8;
			labelTimerDen.Tag = "";
			labelTimerDen.Width = 101;
			labelTimerDen.Height = 45;
			labelTimerDen.Top = 43;
			labelTimerDen.Left = 189;
			// 
			// plLobby
			// 
			this.plLobby.Controls.Add(this.lbHistory);
			this.plLobby.Controls.Add(this.panel2);
			this.plLobby.Controls.Add(this.lbDetail);
			this.plLobby.Controls.Add(this.panel1);
			this.plLobby.Controls.Add(this.btTimPhong);
			this.plLobby.Controls.Add(this.btTaoPhong);
			this.plLobby.Controls.Add(this.lbDanhSachPhong);
			this.plLobby.Dock = System.Windows.Forms.DockStyle.Fill;
			this.plLobby.Location = new System.Drawing.Point(0, 0);
			this.plLobby.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.plLobby.Name = "plLobby";
			this.plLobby.Size = new System.Drawing.Size(1946, 1106);
			this.plLobby.TabIndex = 9;
			// 
			// btTimPhong
			// 
			this.btTimPhong.Location = new System.Drawing.Point(1030, 920);
			this.btTimPhong.Name = "btTimPhong";
			this.btTimPhong.Size = new System.Drawing.Size(211, 82);
			this.btTimPhong.TabIndex = 2;
			this.btTimPhong.Text = "Tìm Phòng";
			this.btTimPhong.UseVisualStyleBackColor = true;
			this.btTimPhong.Click += new System.EventHandler(this.btTimPhong_Click);
			// 
			// btTaoPhong
			// 
			this.btTaoPhong.Location = new System.Drawing.Point(665, 920);
			this.btTaoPhong.Name = "btTaoPhong";
			this.btTaoPhong.Size = new System.Drawing.Size(211, 82);
			this.btTaoPhong.TabIndex = 1;
			this.btTaoPhong.Text = "Tạo Phòng";
			this.btTaoPhong.UseVisualStyleBackColor = true;
			this.btTaoPhong.Click += new System.EventHandler(this.btTaoPhong_Click);
			// 
			// lbDanhSachPhong
			// 
			this.lbDanhSachPhong.FormattingEnabled = true;
			this.lbDanhSachPhong.ItemHeight = 25;
			this.lbDanhSachPhong.Location = new System.Drawing.Point(665, 115);
			this.lbDanhSachPhong.Name = "lbDanhSachPhong";
			this.lbDanhSachPhong.Size = new System.Drawing.Size(575, 779);
			this.lbDanhSachPhong.TabIndex = 0;
			this.lbDanhSachPhong.SelectedIndexChanged += new System.EventHandler(this.lbDanhSachPhong_SelectedIndexChanged);
			// 
			// rtbBoxSend
			// 
			this.rtbBoxSend.Location = new System.Drawing.Point(1415, 990);
			this.rtbBoxSend.Name = "rtbBoxSend";
			this.rtbBoxSend.Size = new System.Drawing.Size(429, 60);
			this.rtbBoxSend.TabIndex = 10;
			this.rtbBoxSend.Text = "";
			this.rtbBoxSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbBoxSend_KeyPress);
			// 
			// rtbContentChat
			// 
			this.rtbContentChat.Location = new System.Drawing.Point(1415, 202);
			this.rtbContentChat.Name = "rtbContentChat";
			this.rtbContentChat.Size = new System.Drawing.Size(429, 774);
			this.rtbContentChat.TabIndex = 11;
			this.rtbContentChat.Text = "";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txtBirth);
			this.panel1.Controls.Add(this.txtSex);
			this.panel1.Controls.Add(this.txtName);
			this.panel1.Controls.Add(this.lbBirth);
			this.panel1.Controls.Add(this.lbSex);
			this.panel1.Controls.Add(this.lbName);
			this.panel1.Location = new System.Drawing.Point(1339, 115);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(516, 162);
			this.panel1.TabIndex = 3;
			// 
			// lbDetail
			// 
			this.lbDetail.AutoSize = true;
			this.lbDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbDetail.Location = new System.Drawing.Point(1402, 99);
			this.lbDetail.Name = "lbDetail";
			this.lbDetail.Size = new System.Drawing.Size(239, 32);
			this.lbDetail.TabIndex = 4;
			this.lbDetail.Text = "Thông tin người chơi";
			// 
			// lbHistory
			// 
			this.lbHistory.AutoSize = true;
			this.lbHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbHistory.Location = new System.Drawing.Point(1402, 344);
			this.lbHistory.Name = "lbHistory";
			this.lbHistory.Size = new System.Drawing.Size(169, 32);
			this.lbHistory.TabIndex = 6;
			this.lbHistory.Text = "Lịch sử thi đấu";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.listViewHistory);
			this.panel2.Controls.Add(this.txtDraw);
			this.panel2.Controls.Add(this.txtLose);
			this.panel2.Controls.Add(this.lbDraw);
			this.panel2.Controls.Add(this.lbLose);
			this.panel2.Controls.Add(this.txtWin);
			this.panel2.Controls.Add(this.lbWin);
			this.panel2.Location = new System.Drawing.Point(1339, 360);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(516, 471);
			this.panel2.TabIndex = 5;
			// 
			// lbName
			// 
			this.lbName.AutoSize = true;
			this.lbName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbName.Location = new System.Drawing.Point(11, 38);
			this.lbName.Name = "lbName";
			this.lbName.Size = new System.Drawing.Size(95, 32);
			this.lbName.TabIndex = 0;
			this.lbName.Text = "Họ Tên:";
			// 
			// lbSex
			// 
			this.lbSex.AutoSize = true;
			this.lbSex.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbSex.Location = new System.Drawing.Point(11, 90);
			this.lbSex.Name = "lbSex";
			this.lbSex.Size = new System.Drawing.Size(110, 32);
			this.lbSex.TabIndex = 2;
			this.lbSex.Text = "Giới tính:";
			// 
			// lbBirth
			// 
			this.lbBirth.AutoSize = true;
			this.lbBirth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbBirth.Location = new System.Drawing.Point(245, 90);
			this.lbBirth.Name = "lbBirth";
			this.lbBirth.Size = new System.Drawing.Size(116, 32);
			this.lbBirth.TabIndex = 4;
			this.lbBirth.Text = "Năm sinh";
			// 
			// lbWin
			// 
			this.lbWin.AutoSize = true;
			this.lbWin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbWin.Location = new System.Drawing.Point(11, 34);
			this.lbWin.Name = "lbWin";
			this.lbWin.Size = new System.Drawing.Size(81, 32);
			this.lbWin.TabIndex = 6;
			this.lbWin.Text = "Thắng";
			// 
			// txtName
			// 
			this.txtName.AutoSize = true;
			this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txtName.Location = new System.Drawing.Point(107, 38);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(140, 32);
			this.txtName.TabIndex = 6;
			this.txtName.Text = "Trần Trí Đức";
			// 
			// txtSex
			// 
			this.txtSex.AutoSize = true;
			this.txtSex.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txtSex.Location = new System.Drawing.Point(127, 90);
			this.txtSex.Name = "txtSex";
			this.txtSex.Size = new System.Drawing.Size(65, 32);
			this.txtSex.TabIndex = 7;
			this.txtSex.Text = "Nam";
			// 
			// txtBirth
			// 
			this.txtBirth.AutoSize = true;
			this.txtBirth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txtBirth.Location = new System.Drawing.Point(367, 90);
			this.txtBirth.Name = "txtBirth";
			this.txtBirth.Size = new System.Drawing.Size(66, 32);
			this.txtBirth.TabIndex = 8;
			this.txtBirth.Text = "2002";
			// 
			// txtWin
			// 
			this.txtWin.AutoSize = true;
			this.txtWin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txtWin.Location = new System.Drawing.Point(98, 34);
			this.txtWin.Name = "txtWin";
			this.txtWin.Size = new System.Drawing.Size(53, 32);
			this.txtWin.TabIndex = 12;
			this.txtWin.Text = "999";
			// 
			// txtLose
			// 
			this.txtLose.AutoSize = true;
			this.txtLose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txtLose.Location = new System.Drawing.Point(274, 34);
			this.txtLose.Name = "txtLose";
			this.txtLose.Size = new System.Drawing.Size(53, 32);
			this.txtLose.TabIndex = 14;
			this.txtLose.Text = "999";
			// 
			// lbLose
			// 
			this.lbLose.AutoSize = true;
			this.lbLose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbLose.Location = new System.Drawing.Point(201, 34);
			this.lbLose.Name = "lbLose";
			this.lbLose.Size = new System.Drawing.Size(67, 32);
			this.lbLose.TabIndex = 13;
			this.lbLose.Text = "Thua";
			// 
			// txtDraw
			// 
			this.txtDraw.AutoSize = true;
			this.txtDraw.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.txtDraw.Location = new System.Drawing.Point(430, 34);
			this.txtDraw.Name = "txtDraw";
			this.txtDraw.Size = new System.Drawing.Size(53, 32);
			this.txtDraw.TabIndex = 14;
			this.txtDraw.Text = "999";
			// 
			// lbDraw
			// 
			this.lbDraw.AutoSize = true;
			this.lbDraw.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lbDraw.Location = new System.Drawing.Point(367, 34);
			this.lbDraw.Name = "lbDraw";
			this.lbDraw.Size = new System.Drawing.Size(57, 32);
			this.lbDraw.TabIndex = 13;
			this.lbDraw.Text = "Hoà";
			// 
			// listViewHistory
			// 
			this.listViewHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.Enemy,
			this.Result,
			this.Nums,
			this.Time});
			this.listViewHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.listViewHistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewHistory.HideSelection = false;
			this.listViewHistory.Location = new System.Drawing.Point(23, 80);
			this.listViewHistory.Name = "listViewHistory";
			this.listViewHistory.Size = new System.Drawing.Size(460, 362);
			this.listViewHistory.TabIndex = 15;
			this.listViewHistory.UseCompatibleStateImageBehavior = false;
			this.listViewHistory.View = System.Windows.Forms.View.Details;
			// 
			// Enemy
			// 
			this.Enemy.Text = "Đối thủ";
			this.Enemy.Width = 160;
			// 
			// Result
			// 
			this.Result.Text = "Kết quả";
			this.Result.Width = 95;
			// 
			// Nums
			// 
			this.Nums.Text = "Số lượt đi";
			this.Nums.Width = 80;
			// 
			// Time
			// 
			this.Time.Text = "Tổng thời gian";
			this.Time.Width = 121;
			// 
			// cmbSelectColor
			// 
			cmbSelectColor.Cursor = System.Windows.Forms.Cursors.Hand;
			cmbSelectColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cmbSelectColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
			cmbSelectColor.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			cmbSelectColor.FormattingEnabled = true;
			cmbSelectColor.Items.AddRange(new object[] {
			"Default",
			"Black",
			"Blue",
			"Grey",
			"Paper"});
			cmbSelectColor.Location = new System.Drawing.Point(1627, 130);
			cmbSelectColor.Name = "cmbSelectColor";
			cmbSelectColor.Size = new System.Drawing.Size(219, 33);
			cmbSelectColor.TabIndex = 9;
			cmbSelectColor.SelectedIndexChanged += new System.EventHandler(cmbSelectColor_SelectedIndexChanged);
			// 
			// fBanCo
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.NavajoWhite;
			this.BackgroundImage = global::CoTuong.Properties.Resources.board_default;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Width = 1920;
			this.Height = 1080;
			this.Controls.Add(this.plLobby);
			this.Controls.Add(labelTimerDen);
			this.Controls.Add(labelTimerDo);
			this.Controls.Add(lichSuDo);
			this.Controls.Add(lichSuDen);
			this.Controls.Add(this.NewGame);
			this.Controls.Add(this.undo);
			this.Controls.Add(this.rtbBoxSend);
			this.Controls.Add(this.rtbContentChat);
			this.Controls.Add(cmbSelectColor);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.MaximizeBox = false;
			this.Name = "fBanCo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CoTuong";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.closeFormBanCo);
			this.Load += new System.EventHandler(this.fBanCo_Load);
			((System.ComponentModel.ISupportInitialize)(this.undo)).EndInit();
			this.plLobby.ResumeLayout(false);
			this.plLobby.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox rtbBoxSend;
		private System.Windows.Forms.RichTextBox rtbContentChat;
		private System.Windows.Forms.PictureBox undo;
		private System.Windows.Forms.Button NewGame;
		private System.Windows.Forms.Panel plLobby;
		private System.Windows.Forms.Button btTimPhong;
		private System.Windows.Forms.Button btTaoPhong;
		private System.Windows.Forms.ListBox lbDanhSachPhong;
		private System.Windows.Forms.Label lbHistory;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListView listViewHistory;
		private System.Windows.Forms.ColumnHeader Enemy;
		private System.Windows.Forms.ColumnHeader Result;
		private System.Windows.Forms.ColumnHeader Nums;
		private System.Windows.Forms.ColumnHeader Time;
		private System.Windows.Forms.Label txtDraw;
		private System.Windows.Forms.Label txtLose;
		private System.Windows.Forms.Label lbDraw;
		private System.Windows.Forms.Label lbLose;
		private System.Windows.Forms.Label txtWin;
		private System.Windows.Forms.Label lbWin;
		private System.Windows.Forms.Label lbDetail;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label txtBirth;
		private System.Windows.Forms.Label txtSex;
		private System.Windows.Forms.Label txtName;
		private System.Windows.Forms.Label lbBirth;
		private System.Windows.Forms.Label lbSex;
		private System.Windows.Forms.Label lbName;
		public static System.Windows.Forms.Label labelTimerDo;
		public static System.Windows.Forms.Label labelTimerDen;
		public static System.Windows.Forms.TextBox lichSuDen;
		public static System.Windows.Forms.TextBox lichSuDo;
		public static System.Windows.Forms.ComboBox cmbSelectColor;
	}
}

