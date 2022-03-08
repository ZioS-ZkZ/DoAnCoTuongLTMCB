using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace CoTuong
{
    class VanCo
    {
        public static NguoiChoi[] player = new NguoiChoi[2];
        public static bool DangChoi = false;
        public static int LuotDi = 0;
        public static bool isMarked = false; //  kiem tra da chon quan co hay chua 
        public static QuanCo.QuanCo temp;// de tham chieu den quuan co duoc chon trong 1 nuoc di chuyen
        public static Bitmap BackBuffer = null;
        public static bool isWin = false;
		private static int toaDoMoDo_x = 0;//toa do hien thi quan co bi an
		private static int toaDoMoDo_y = 0;//toa do hien thi quan co bi an
		private static int toaDoMoDen_x = 0;//toa do hien thi quan co bi an
		private static int toaDoMoDen_y = 0;//toa do hien thi quan co bi an
		private static int soLanDi_Do = 1;
		private static int soLanDi_Den = 1;
		public static Timer timerDen;
		public static Timer timerDo;
		private static int secondsDo = 3600;
		private static int secondsDen = 3600;
       


        static VanCo()
        {
            player[0] = new NguoiChoi(0);
            player[1] = new NguoiChoi(1);
			timerDo = new Timer();
			timerDen = new Timer();
			timerDo.Tick += (sender1, e1) => Count_down(sender1, e1, 1);
			timerDen.Tick += (sender1, e1) => Count_down(sender1, e1, 0);
		}
        public static void NewGame()
        {
            if (DangChoi)
            {
                // xoa quan cho tren ban co 
                for(int i =0; i<2; i++)
                {
                    player[0].qXe[i].picQuanCo.Visible = false;
                    player[0].qMa[i].picQuanCo.Visible = false;
                    player[0].qVoi[i].picQuanCo.Visible = false;
                    player[0].qSi[i].picQuanCo.Visible = false;
                    player[0].qPhao[i].picQuanCo.Visible = false;
                }
                for (int i = 0; i < 5; i++)
                    player[0].qTot[i].picQuanCo.Visible = false;
                player[0].qTuong.picQuanCo.Visible = false;
                //=========================================
                for (int i = 0; i < 2; i++)
                {
                    player[1].qXe[i].picQuanCo.Visible = false;
                    player[1].qMa[i].picQuanCo.Visible = false;
                    player[1].qVoi[i].picQuanCo.Visible = false;
                    player[1].qSi[i].picQuanCo.Visible = false;
                    player[1].qPhao[i].picQuanCo.Visible = false;
                }
                for (int i = 0; i < 5; i++)
                    player[1].qTot[i].picQuanCo.Visible = false;
                player[1].qTuong.picQuanCo.Visible = false;

                // xoa hai ng choi
                Array.Resize<CoTuong.NguoiChoi>(ref player, 0);
                // khoi tao lai hai ng choi
                Array.Resize<CoTuong.NguoiChoi>(ref player, 2);
                player[0] = new NguoiChoi(0);
                player[1] = new NguoiChoi(1);
                // khoi tao ban co
                BanCo.ResetBanCo();
                LuotDi = 0;
                // dat quan co vao vi tri
                for (int i = 0; i < 2; i++)
                {
                    player[0].qXe[i].draw();
                    player[0].qMa[i].draw();
                    player[0].qVoi[i].draw();
                    player[0].qSi[i].draw();
                    player[0].qPhao[i].draw();
                }
                for (int i = 0; i < 5; i++)
                    player[0].qTot[i].draw();
                player[0].qTuong.draw();

                //=======================
                for (int i = 0; i < 2; i++)
                {
                    player[1].qXe[i].draw();
                    player[1].qMa[i].draw();
                    player[1].qVoi[i].draw();
                    player[1].qSi[i].draw();
                    player[1].qPhao[i].draw();
                }
                for (int i = 0; i < 5; i++)
                    player[1].qTot[i].draw();
                player[1].qTuong.draw();

				//Reset toạ độ mộ
				toaDoMoDen_x = 0;
				toaDoMoDen_x = 0;
				toaDoMoDo_x = 0;
				toaDoMoDo_y = 0;

				//Reset lịch sử nước đi
				fBanCo.lichSuDo.Text = "";
				fBanCo.lichSuDen.Text = "";
				soLanDi_Den = 1;
				soLanDi_Do = 1;

				//Reset timer
				secondsDen = 3600;
				secondsDo = 3600;
				timerDo.Stop();
				timerDen.Stop();
				fBanCo.labelTimerDen.Text = "";
				fBanCo.labelTimerDo.Text = "";
			}
            else
            {
                // tao ban co trong
                BanCo.ResetBanCo();
                VanCo.DangChoi = true;
                // dat quan co vao vi tri
                for (int i = 0; i < 2; i++)
                {
                    player[0].qXe[i].draw();
                    player[0].qMa[i].draw();
                    player[0].qVoi[i].draw();
                    player[0].qSi[i].draw();
                    player[0].qPhao[i].draw();
                }
                for (int i = 0; i < 5; i++)
                    player[0].qTot[i].draw();
                player[0].qTuong.draw();
                //========================
                for (int i = 0; i < 2; i++)
                {
                    player[1].qXe[i].draw();
                    player[1].qMa[i].draw();
                    player[1].qVoi[i].draw();
                    player[1].qSi[i].draw();
                    player[1].qPhao[i].draw();
                }
                for (int i = 0; i < 5; i++)
                    player[1].qTot[i].draw();
                player[1].qTuong.draw();
            }

        }
        public static void DoiLuotDi()
        {
            if (LuotDi == 0)
			{
				LuotDi = 1;
				timerDo.Interval = 1000;
				timerDo.Start();
				timerDen.Stop();
			}
            else if(LuotDi == 1)
			{
				LuotDi = 0;
				timerDen.Interval = 1000;
				timerDen.Start();
				timerDo.Stop();
			}
            if(VanCo.LuotDi == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    player[0].qXe[i].isLock = false;
                    player[0].qMa[i].isLock = false;
                    player[0].qVoi[i].isLock = false;
                    player[0].qSi[i].isLock = false;
                    player[0].qPhao[i].isLock = false;
                }
                for (int i = 0; i < 5; i++)
                    player[0].qTot[i].isLock = false;
                player[0].qTuong.isLock = false;

                //khoa quan co lai
                for (int i = 0; i < 2; i++)
                {
                    player[1].qXe[i].isLock = true;
                    player[1].qMa[i].isLock = true;
                    player[1].qVoi[i].isLock = true;
                    player[1].qSi[i].isLock = true;
                    player[1].qPhao[i].isLock = true;
                }
                for (int i = 0; i < 5; i++)
                    player[1].qTot[i].isLock = true;
                player[1].qTuong.isLock = true;
            }
            else if(LuotDi == 1)
            {


                for (int i = 0; i < 2; i++)
                {
                    player[1].qXe[i].isLock = false;
                    player[1].qMa[i].isLock = false;
                    player[1].qVoi[i].isLock = false;
                    player[1].qSi[i].isLock = false;
                    player[1].qPhao[i].isLock = false;
                }
                for (int i = 0; i < 5; i++)
                    player[1].qTot[i].isLock = false;
                player[1].qTuong.isLock = false;
                //==========================
                for (int i = 0; i < 2; i++)
                {
                    player[0].qXe[i].isLock = true;
                    player[0].qMa[i].isLock = true;
                    player[0].qVoi[i].isLock = true;
                    player[0].qSi[i].isLock = true;
                    player[0].qPhao[i].isLock = true;
                }
                for (int i = 0; i < 5; i++)
                    player[0].qTot[i].isLock = true;
                player[0].qTuong.isLock = true;
            }
        }
        public static void setOCoTrong(int row, int col)
        {
            BanCo.ViTri[row, col].Trong = true;
            BanCo.ViTri[row, col].Ten = "";
            BanCo.ViTri[row, col].Phia = "";
            BanCo.ViTri[row, col].Phe = 2;
        }
        public static void DatQuanCo(Object sender, QuanCo.QuanCo qc, int row, int col)
        {
            //  dat quan co len ban co 
            if(sender.GetType() == typeof(CoTuong.fBanCo))
            {
                qc.Hang = row;
                qc.Cot = col;
                qc.draw();
            }
            // dat quan co len 1 quan co khac 
            if(sender.GetType() == typeof(System.Windows.Forms.PictureBox))
            {
                BanCo.ViTri[row, col].Trong = false;
                BanCo.ViTri[row, col].Phe = temp.Phe;
                BanCo.ViTri[row, col].Ten = temp.Ten;
                BanCo.ViTri[row, col].Phia = temp.Phia;
                temp.Hang = row;
                temp.Cot = col;
                temp.picQuanCo.Top = row * 50 + 35;
                temp.picQuanCo.Left = col * 50 + 10;
            }
            VanCo.clickSound("chon");
        }

		public static void InLichSu(QuanCo.QuanCo qc, int row, int col)
		{
            string tenTiengViet = "";
            if (qc.Ten == "xe")
                tenTiengViet = "XE";
            else if (qc.Ten == "ma")
                tenTiengViet = "MÃ";
            else if (qc.Ten == "voi")
                tenTiengViet = "TƯỢNG";
            else if (qc.Ten == "si")
                tenTiengViet = "Sỹ";
            else if (qc.Ten == "tuong")
                tenTiengViet = "TƯỚNG";
            else if (qc.Ten == "phao")
                tenTiengViet = "PHÁO";
            else if (qc.Ten == "tot")
                tenTiengViet = "TỐT";
            string content = $"{tenTiengViet}({qc.Hang + 1},{qc.Cot + 1})->({row + 1},{col + 1})";
			
			if (qc.Phe == 0)
			{
				fBanCo.lichSuDen.AppendText($"{soLanDi_Den}. {content}\r\n");
				soLanDi_Den++;
			} else
			{
				fBanCo.lichSuDo.AppendText($"{soLanDi_Do}. {content}\r\n");
				soLanDi_Do++;
			}
		}

		public static void AnQuanCo(QuanCo.QuanCo qc)
        {
            qc.TrangThai = 0;
            qc.picQuanCo.Cursor = Cursors.Arrow;
			qc.picQuanCo.Width = 29;
			qc.picQuanCo.Height = 29;
			qc.picQuanCo.SizeMode = PictureBoxSizeMode.Zoom;


			if (qc.Phe == 0) {
				qc.picQuanCo.Top = toaDoMoDen_y * 32 + 181;
				qc.picQuanCo.Left = toaDoMoDen_x * 29 + 463;
				toaDoMoDen_x++;
				if (toaDoMoDen_x == 5)
				{
					toaDoMoDen_x = 0;
					toaDoMoDen_y++;
				} 
			}
			else {
				qc.picQuanCo.Top = toaDoMoDo_y * 32 + 382;
				qc.picQuanCo.Left = toaDoMoDo_x * 29 + 463;
				toaDoMoDo_x++;
				if (toaDoMoDo_x == 5)
				{
					toaDoMoDo_x = 0;
					toaDoMoDo_y++;
				}
			}
		}

		//private void CountDownTimer(object sender, EventArgs e, int phe)
		//{
			
		//}

		public static void Count_down(object sender, EventArgs e, int phe)
		{
			if (phe == 0)
			{
				secondsDen--;
				if (secondsDen <= 10) fBanCo.labelTimerDen.ForeColor = Color.Red;
				else fBanCo.labelTimerDen.ForeColor = SystemColors.ControlText;
				fBanCo.labelTimerDen.Text = $"{secondsDen / 60}:{secondsDen % 60}";
				if (secondsDen == 0)
				{
					timerDen.Stop();
					VanCo.isWin = true; VanCo.NewGame();
					fEnd end = new fEnd();
					end.ShowDialog();
				}
			}
			else
			{
				secondsDo--;
				if (secondsDo <= 10) fBanCo.labelTimerDo.ForeColor = Color.Red;
				else fBanCo.labelTimerDo.ForeColor = SystemColors.ControlText;
				fBanCo.labelTimerDo.Text = $"{secondsDo / 60}:{secondsDo % 60}";
				if (secondsDo == 0)
				{
					timerDo.Stop();
					VanCo.isWin = true;
					VanCo.NewGame();
					fEnd end = new fEnd();
					end.ShowDialog();
				}
			}
		}
        public static void clickSound(string name)
        {
            if(name == "chon")
            {
                SoundPlayer sound = new SoundPlayer(CoTuong.Properties.Resources.Mark);
                sound.Play();
            }
            if(name == "chieu")
            {
                SoundPlayer sound = new SoundPlayer(CoTuong.Properties.Resources.Chieu);
                sound.Play();
            }
            if(name == "ready")
            {
                SoundPlayer sound = new SoundPlayer(CoTuong.Properties.Resources.Ready);
                sound.Play();
            }
            if(name == "click")
            {
                SoundPlayer sound = new SoundPlayer(CoTuong.Properties.Resources.clickChon);
                sound.Play();
            }
    }

	}
}
