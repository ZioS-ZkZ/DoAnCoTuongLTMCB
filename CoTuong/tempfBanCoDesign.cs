
//namespace CoTuong
//{
//	partial class fBanCo
//	{
//		/// <summary>
//		///  Required designer variable.
//		/// </summary>
//		private System.ComponentModel.IContainer components = null;

//		/// <summary>
//		///  Clean up any resources being used.
//		/// </summary>
//		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//		protected override void Dispose(bool disposing)
//		{
//			if (disposing && (components != null))
//			{
//				components.Dispose();
//			}
//			base.Dispose(disposing);
//		}

//		#region Windows Form Designer generated code

//		/// <summary>
//		///  Required method for Designer support - do not modify
//		///  the contents of this method with the code editor.
//		/// </summary>
//		private void InitializeComponent()
//		{
//			this.components = new System.ComponentModel.Container();
//			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBanCo));
//			this.undo = new System.Windows.Forms.PictureBox();
//			this.NewGame = new System.Windows.Forms.Button();
//			lichSuDen = new System.Windows.Forms.TextBox();
//			lichSuDo = new System.Windows.Forms.TextBox();
//			this.btChat = new System.Windows.Forms.Button();
//			timerDo = new System.Windows.Forms.Label();
//			timerDen = new System.Windows.Forms.Label();
//			countDownTimer = new System.Windows.Forms.Timer(this.components);
//			((System.ComponentModel.ISupportInitialize)(this.undo)).BeginInit();
//			this.SuspendLayout();
//			// 
//			// undo
//			// 
//			this.undo.BackColor = System.Drawing.Color.Transparent;
//			this.undo.Cursor = System.Windows.Forms.Cursors.Hand;
//			this.undo.Image = ((System.Drawing.Image)(resources.GetObject("undo.Image")));
//			this.undo.Location = new System.Drawing.Point(569, 37);
//			this.undo.Name = "undo";
//			this.undo.Size = new System.Drawing.Size(48, 48);
//			this.undo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
//			this.undo.TabIndex = 0;
//			this.undo.TabStop = false;
//			this.undo.Click += new System.EventHandler(this.undo_Click);
//			// 
//			// NewGame
//			// 
//			this.NewGame.AutoSize = true;
//			this.NewGame.BackColor = System.Drawing.Color.SaddleBrown;
//			this.NewGame.Cursor = System.Windows.Forms.Cursors.Hand;
//			this.NewGame.Font = new System.Drawing.Font("Showcard Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
//			this.NewGame.Location = new System.Drawing.Point(660, 37);
//			this.NewGame.Name = "NewGame";
//			this.NewGame.Size = new System.Drawing.Size(135, 48);
//			this.NewGame.TabIndex = 1;
//			this.NewGame.Text = "NEWGAME";
//			this.NewGame.UseVisualStyleBackColor = false;
//			this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
//			// 
//			// lichSuDen
//			// 
//			lichSuDen.BackColor = System.Drawing.Color.NavajoWhite;
//			lichSuDen.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//			lichSuDen.Location = new System.Drawing.Point(610, 177);
//			lichSuDen.Margin = new System.Windows.Forms.Padding(2);
//			lichSuDen.Multiline = true;
//			lichSuDen.Name = "lichSuDen";
//			lichSuDen.ReadOnly = true;
//			lichSuDen.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
//			lichSuDen.Size = new System.Drawing.Size(200, 101);
//			lichSuDen.TabIndex = 3;
//			// 
//			// lichSuDo
//			// 
//			lichSuDo.BackColor = System.Drawing.Color.NavajoWhite;
//			lichSuDo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
//			lichSuDo.Location = new System.Drawing.Point(610, 377);
//			lichSuDo.Margin = new System.Windows.Forms.Padding(2);
//			lichSuDo.Multiline = true;
//			lichSuDo.Name = "lichSuDo";
//			lichSuDo.ReadOnly = true;
//			lichSuDo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
//			lichSuDo.Size = new System.Drawing.Size(200, 101);
//			lichSuDo.TabIndex = 4;
//			// 
//			// btChat
//			// 
//			this.btChat.BackColor = System.Drawing.Color.Moccasin;
//			this.btChat.BackgroundImage = global::CoTuong.Properties.Resources.iconMess;
//			this.btChat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
//			this.btChat.Cursor = System.Windows.Forms.Cursors.Hand;
//			this.btChat.Location = new System.Drawing.Point(740, 500);
//			this.btChat.Name = "btChat";
//			this.btChat.Size = new System.Drawing.Size(60, 60);
//			this.btChat.TabIndex = 5;
//			this.btChat.UseVisualStyleBackColor = false;
//			// 
//			// timerDo
//			// 
//			timerDo.AutoSize = true;
//			timerDo.BackColor = System.Drawing.Color.Transparent;
//			timerDo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
//			timerDo.ForeColor = System.Drawing.SystemColors.ControlText;
//			timerDo.Location = new System.Drawing.Point(521, 135);
//			timerDo.Name = "timerDo";
//			timerDo.Size = new System.Drawing.Size(0, 32);
//			timerDo.TabIndex = 6;
//			timerDo.Tag = "";
//			// 
//			// timerDen
//			// 
//			timerDen.AutoSize = true;
//			timerDen.BackColor = System.Drawing.Color.Transparent;
//			timerDen.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
//			timerDen.ForeColor = System.Drawing.SystemColors.ControlText;
//			timerDen.Location = new System.Drawing.Point(521, 337);
//			timerDen.Name = "timerDen";
//			timerDen.Size = new System.Drawing.Size(0, 32);
//			timerDen.TabIndex = 8;
//			timerDen.Tag = "";
//			// 
//			// countDownTimer
//			// 
//			countDownTimer.Interval = 1000;
//			countDownTimer.Tick += new System.EventHandler(this.timer1_Tick);
//			// 
//			// fBanCo
//			// 
//			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
//			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//			this.BackColor = System.Drawing.Color.NavajoWhite;
//			this.BackgroundImage = global::CoTuong.Properties.Resources.bk1;
//			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
//			this.ClientSize = new System.Drawing.Size(818, 560);
//			this.Controls.Add(timerDen);
//			this.Controls.Add(timerDo);
//			this.Controls.Add(this.btChat);
//			this.Controls.Add(lichSuDo);
//			this.Controls.Add(lichSuDen);
//			this.Controls.Add(this.NewGame);
//			this.Controls.Add(this.undo);
//			this.DoubleBuffered = true;
//			this.MaximizeBox = false;
//			this.Name = "fBanCo";
//			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//			this.Text = "CoTuong";
//			((System.ComponentModel.ISupportInitialize)(this.undo)).EndInit();
//			this.ResumeLayout(false);
//			this.PerformLayout();

//		}

//		#endregion

//		private System.Windows.Forms.PictureBox undo;
//		private System.Windows.Forms.Button NewGame;
//		private System.Windows.Forms.Button btChat;
//		public static System.Windows.Forms.Timer countDownTimer;
//		public static System.Windows.Forms.Label timerDo;
//		public static System.Windows.Forms.Label timerDen;
//		public static System.Windows.Forms.TextBox lichSuDen;
//		public static System.Windows.Forms.TextBox lichSuDo;
//	}
//}

