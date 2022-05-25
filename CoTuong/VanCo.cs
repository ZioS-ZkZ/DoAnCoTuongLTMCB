using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace CoTuong
{
    public static class VanCo
    {
        public static NguoiChoi[] player = new NguoiChoi[2];
        public static bool DangChoi = false;
        public static int LuotDi = 0;
        public static bool isMarked = false; //  kiem tra da chon quan co hay chua 
        public static QuanCo.QuanCo temp;// de tham chieu den quuan co duoc chon trong 1 nuoc di chuyen
        public static Bitmap BackBuffer = null;
        public static string isWin = "none";
		private static ToaDo toaDoMoDo = new ToaDo(0,0);
		private static ToaDo toaDoMoDen = new ToaDo(0, 0);
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
			timerDo = new Timer
			{
				Interval = 1000
			};
			timerDen = new Timer
			{
				Interval = 1000
			};
			timerDo.Tick += (sender1, e1) => Count_down(sender1, e1, 1);
			timerDen.Tick += (sender1, e1) => Count_down(sender1, e1, 0);
		}
        public static void NewGame()
        {
			
            if (DangChoi)
            {
				// xoa quan cho tren ban co 
				for (int i =0; i<2; i++)
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
				isWin = "none";
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
				toaDoMoDen.x = 0;
				toaDoMoDen.y = 0;
				toaDoMoDo.x = 0;
				toaDoMoDo.y = 0;

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

		public static void DoiLuotDi(int luotdi)
		{
			if (luotdi == 0) LuotDi = 1;
			else LuotDi = 0;

			if(VanCo.LuotDi == 0)
			{
				timerDen.Enabled = true;
				timerDen.Start();
				timerDo.Enabled = false;
				timerDo.Stop();
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
			else if (LuotDi == 1)
			{
				timerDo.Enabled = true;
				timerDo.Start();
				timerDen.Enabled = false;
				timerDen.Stop();
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
		public static void DatQuanCo(int qcHang,int qcCot,string qcTen, int qcPhe, string qcPhia, int row, int col)
		{
			
			BanCo.ViTri[row, col].Trong = false;
			BanCo.ViTri[row, col].Phe = qcPhe;
			BanCo.ViTri[row, col].Ten = qcTen;
			BanCo.ViTri[row, col].Phia = qcPhia;
			if (qcTen == "xe")
			{
				if (qcPhia == "trai")
                {
					VanCo.player[qcPhe].qXe[0].Hang = row;
					VanCo.player[qcPhe].qXe[0].Cot = col;
					VanCo.player[qcPhe].qXe[0].picQuanCo.Top = row * 107 + 28;
					VanCo.player[qcPhe].qXe[0].picQuanCo.Left = col * 105 + 500;
				}
				if (qcPhia == "phai")
                {
					VanCo.player[qcPhe].qXe[1].Hang = row;
					VanCo.player[qcPhe].qXe[1].Cot = col;
					VanCo.player[qcPhe].qXe[1].picQuanCo.Top = row * 107 + 28;
					VanCo.player[qcPhe].qXe[1].picQuanCo.Left = col * 105 + 500;
				}
			}
			if (qcTen == "ma")
			{
				if (qcPhia == "trai")
				{
					VanCo.player[qcPhe].qMa[0].Hang = row;
					VanCo.player[qcPhe].qMa[0].Cot = col;
					VanCo.player[qcPhe].qMa[0].picQuanCo.Top = row * 107 + 28;
					VanCo.player[qcPhe].qMa[0].picQuanCo.Left = col * 105 + 500;
				}
				if (qcPhia == "phai")
				{
					VanCo.player[qcPhe].qMa[1].Hang = row;
					VanCo.player[qcPhe].qMa[1].Cot = col;
					VanCo.player[qcPhe].qMa[1].picQuanCo.Top = row * 107 + 28;
					VanCo.player[qcPhe].qMa[1].picQuanCo.Left = col * 105 + 500;
				}
			}
			if (qcTen == "voi")
			{
				if (qcPhia == "trai")
				{
					VanCo.player[qcPhe].qVoi[0].Hang = row;
					VanCo.player[qcPhe].qVoi[0].Cot = col;
					VanCo.player[qcPhe].qVoi[0].picQuanCo.Top = row * 107 + 28;
					VanCo.player[qcPhe].qVoi[0].picQuanCo.Left = col * 105 + 500;
				}
				if (qcPhia == "phai")
				{
					VanCo.player[qcPhe].qVoi[1].Hang = row;
					VanCo.player[qcPhe].qVoi[1].Cot = col;
					VanCo.player[qcPhe].qVoi[1].picQuanCo.Top = row * 107 + 28;
					VanCo.player[qcPhe].qVoi[1].picQuanCo.Left = col * 105 + 500;
				}
			}
			if (qcTen == "si")
			{
				if (qcPhia == "trai")
				{
					VanCo.player[qcPhe].qSi[0].Hang = row;
					VanCo.player[qcPhe].qSi[0].Cot = col;
					VanCo.player[qcPhe].qSi[0].picQuanCo.Top = row * 107 + 28;
					VanCo.player[qcPhe].qSi[0].picQuanCo.Left = col * 105 + 500;
				}
				if (qcPhia == "phai")
				{
					VanCo.player[qcPhe].qSi[1].Hang = row;
					VanCo.player[qcPhe].qSi[1].Cot = col;
					VanCo.player[qcPhe].qSi[1].picQuanCo.Top = row * 107 + 28;
					VanCo.player[qcPhe].qSi[1].picQuanCo.Left = col * 105 + 500;
				}
			}
			if (qcTen == "phao")
			{
				if (qcPhia == "trai")
				{
					VanCo.player[qcPhe].qPhao[0].Hang = row;
					VanCo.player[qcPhe].qPhao[0].Cot = col;
					VanCo.player[qcPhe].qPhao[0].picQuanCo.Top = row * 107 + 28;
					VanCo.player[qcPhe].qPhao[0].picQuanCo.Left = col * 105 + 500;
				}
				if (qcPhia == "phai")
				{
					VanCo.player[qcPhe].qPhao[1].Hang = row;
					VanCo.player[qcPhe].qPhao[1].Cot = col;
					VanCo.player[qcPhe].qPhao[1].picQuanCo.Top = row * 107 + 28;
					VanCo.player[qcPhe].qPhao[1].picQuanCo.Left = col * 105 + 500;
				}
			}
			if (qcTen == "tot")
			{
				if (qcPhia == "1")
                {
					VanCo.player[qcPhe].qTot[0].Hang = row;
					VanCo.player[qcPhe].qTot[0].Cot = col;
					VanCo.player[qcPhe].qTot[0].picQuanCo.Top = row * 107 + 28;
					VanCo.player[qcPhe].qTot[0].picQuanCo.Left = col * 105 + 500;
				}
				if (qcPhia == "2")
				{
					VanCo.player[qcPhe].qTot[1].Hang = row;
					VanCo.player[qcPhe].qTot[1].Cot = col;
					VanCo.player[qcPhe].qTot[1].picQuanCo.Top = row * 107 + 28;
					VanCo.player[qcPhe].qTot[1].picQuanCo.Left = col * 105 + 500;
				}
				if (qcPhia == "3")
				{
					VanCo.player[qcPhe].qTot[2].Hang = row;
					VanCo.player[qcPhe].qTot[2].Cot = col;
					VanCo.player[qcPhe].qTot[2].picQuanCo.Top = row * 107 + 28;
					VanCo.player[qcPhe].qTot[2].picQuanCo.Left = col * 105 + 500;
				}
				if (qcPhia == "4")
				{
					VanCo.player[qcPhe].qTot[3].Hang = row;
					VanCo.player[qcPhe].qTot[3].Cot = col;
					VanCo.player[qcPhe].qTot[3].picQuanCo.Top = row * 107 + 28;
					VanCo.player[qcPhe].qTot[3].picQuanCo.Left = col * 105 + 500;
				}
				if (qcPhia == "5")
				{
					VanCo.player[qcPhe].qTot[4].Hang = row;
					VanCo.player[qcPhe].qTot[4].Cot = col;
					VanCo.player[qcPhe].qTot[4].picQuanCo.Top = row * 107 + 28;
					VanCo.player[qcPhe].qTot[4].picQuanCo.Left = col * 105 + 500;
				}

			}
			if (qcTen == "tuong")
			{
				VanCo.player[qcPhe].qTuong.Hang = row;
				VanCo.player[qcPhe].qTuong.Cot = col;
				VanCo.player[qcPhe].qTuong.picQuanCo.Top = row * 107 + 28;
				VanCo.player[qcPhe].qTuong.picQuanCo.Left = col * 105 + 500;
			}
			
			
			VanCo.clickSound("chon");
		}

		public static void InLichSu(string ten, int phe, int rowCo, int colCo, int row, int col)
		{
			string tenTiengViet = "";
			if (ten == "xe")
				tenTiengViet = "XE";
			else if (ten == "ma")
				tenTiengViet = "MÃ";
			else if (ten == "voi")
				tenTiengViet = "TƯỢNG";
			else if (ten == "si")
				tenTiengViet = "Sỹ";
			else if (ten == "tuong")
				tenTiengViet = "TƯỚNG";
			else if (ten == "phao")
				tenTiengViet = "PHÁO";
			else if (ten == "tot")
				tenTiengViet = "TỐT";
			string content = $"{tenTiengViet}({rowCo + 1},{colCo + 1})->({row + 1},{col + 1})";

			if (phe == 0)
			{
				fBanCo.lichSuDen.AppendText($"{soLanDi_Den}. {content}\r\n");
				soLanDi_Den++;
			}
			else
			{
				fBanCo.lichSuDo.AppendText($"{soLanDi_Do}. {content}\r\n");
				soLanDi_Do++;
			}
		}

		public static void AnQuanCo(string qcTen,int qcPhe,string qcPhia)
		{
			if (qcTen == "xe")
			{
				if (qcPhia == "trai")
                {
					VanCo.player[qcPhe].qXe[0].TrangThai = 0;
					VanCo.player[qcPhe].qXe[0].picQuanCo.Cursor = Cursors.Arrow;
					VanCo.player[qcPhe].qXe[0].picQuanCo.Width = 67;
					VanCo.player[qcPhe].qXe[0].picQuanCo.Height = 67;
					VanCo.player[qcPhe].qXe[0].picQuanCo.SizeMode = PictureBoxSizeMode.Zoom;
					if (qcPhe == 0)
					{
						VanCo.player[qcPhe].qXe[0].picQuanCo.Top = toaDoMoDen.y * 67 + 114;
						VanCo.player[qcPhe].qXe[0].picQuanCo.Left = toaDoMoDen.x * 69 + 80;
						toaDoMoDen.x++;
						if (toaDoMoDen.x == 5)
						{
							toaDoMoDen.x = 0;
							toaDoMoDen.y++;
						}
					}
					else
					{
						VanCo.player[qcPhe].qXe[0].picQuanCo.Top = toaDoMoDo.y * 67 + 774;
						VanCo.player[qcPhe].qXe[0].picQuanCo.Left = toaDoMoDo.x * 69 + 80;
						toaDoMoDo.x++;
						if (toaDoMoDo.x == 5)
						{
							toaDoMoDo.x = 0;
							toaDoMoDo.y++;
						}
					}
				}
				if (qcPhia == "phai")
				{
					VanCo.player[qcPhe].qXe[1].TrangThai = 0;
					VanCo.player[qcPhe].qXe[1].picQuanCo.Cursor = Cursors.Arrow;
					VanCo.player[qcPhe].qXe[1].picQuanCo.Width = 67;
					VanCo.player[qcPhe].qXe[1].picQuanCo.Height = 67;
					VanCo.player[qcPhe].qXe[1].picQuanCo.SizeMode = PictureBoxSizeMode.Zoom;
					if (qcPhe == 0)
					{
						VanCo.player[qcPhe].qXe[1].picQuanCo.Top = toaDoMoDen.y * 67 + 114;
						VanCo.player[qcPhe].qXe[1].picQuanCo.Left = toaDoMoDen.x * 69 + 80;
						toaDoMoDen.x++;
						if (toaDoMoDen.x == 5)
						{
							toaDoMoDen.x = 0;
							toaDoMoDen.y++;
						}
					}
					else
					{
						VanCo.player[qcPhe].qXe[1].picQuanCo.Top = toaDoMoDo.y * 67 + 774;
						VanCo.player[qcPhe].qXe[1].picQuanCo.Left = toaDoMoDo.x * 69 + 80;
						toaDoMoDo.x++;
						if (toaDoMoDo.x == 5)
						{
							toaDoMoDo.x = 0;
							toaDoMoDo.y++;
						}
					}
				}
			}
			if (qcTen == "ma")
			{
				if (qcPhia == "trai")
				{
					VanCo.player[qcPhe].qMa[0].TrangThai = 0;
					VanCo.player[qcPhe].qMa[0].picQuanCo.Cursor = Cursors.Arrow;
					VanCo.player[qcPhe].qMa[0].picQuanCo.Width = 67;
					VanCo.player[qcPhe].qMa[0].picQuanCo.Height = 67;
					VanCo.player[qcPhe].qMa[0].picQuanCo.SizeMode = PictureBoxSizeMode.Zoom;
					if (qcPhe == 0)
					{
						VanCo.player[qcPhe].qMa[0].picQuanCo.Top = toaDoMoDen.y * 67 + 114;
						VanCo.player[qcPhe].qMa[0].picQuanCo.Left = toaDoMoDen.x * 69 + 80;
						toaDoMoDen.x++;
						if (toaDoMoDen.x == 5)
						{
							toaDoMoDen.x = 0;
							toaDoMoDen.y++;
						}
					}
					else
					{
						VanCo.player[qcPhe].qMa[0].picQuanCo.Top = toaDoMoDo.y * 67 + 774;
						VanCo.player[qcPhe].qMa[0].picQuanCo.Left = toaDoMoDo.x * 69 + 80;
						toaDoMoDo.x++;
						if (toaDoMoDo.x == 5)
						{
							toaDoMoDo.x = 0;
							toaDoMoDo.y++;
						}
					}
				}
				if (qcPhia == "phai")
				{
					VanCo.player[qcPhe].qMa[1].TrangThai = 0;
					VanCo.player[qcPhe].qMa[1].picQuanCo.Cursor = Cursors.Arrow;
					VanCo.player[qcPhe].qMa[1].picQuanCo.Width = 67;
					VanCo.player[qcPhe].qMa[1].picQuanCo.Height = 67;
					VanCo.player[qcPhe].qMa[1].picQuanCo.SizeMode = PictureBoxSizeMode.Zoom;
					if (qcPhe == 0)
					{
						VanCo.player[qcPhe].qMa[1].picQuanCo.Top = toaDoMoDen.y * 67 + 114;
						VanCo.player[qcPhe].qMa[1].picQuanCo.Left = toaDoMoDen.x * 69 + 80;
						toaDoMoDen.x++;
						if (toaDoMoDen.x == 5)
						{
							toaDoMoDen.x = 0;
							toaDoMoDen.y++;
						}
					}
					else
					{
						VanCo.player[qcPhe].qMa[1].picQuanCo.Top = toaDoMoDo.y * 67 + 774;
						VanCo.player[qcPhe].qMa[1].picQuanCo.Left = toaDoMoDo.x * 69 + 80;
						toaDoMoDo.x++;
						if (toaDoMoDo.x == 5)
						{
							toaDoMoDo.x = 0;
							toaDoMoDo.y++;
						}
					}
				}
			}
			if (qcTen == "voi")
			{
				if (qcPhia == "trai")
				{
					VanCo.player[qcPhe].qVoi[0].TrangThai = 0;
					VanCo.player[qcPhe].qVoi[0].picQuanCo.Cursor = Cursors.Arrow;
					VanCo.player[qcPhe].qVoi[0].picQuanCo.Width = 67;
					VanCo.player[qcPhe].qVoi[0].picQuanCo.Height = 67;
					VanCo.player[qcPhe].qVoi[0].picQuanCo.SizeMode = PictureBoxSizeMode.Zoom;
					if (qcPhe == 0)
					{
						VanCo.player[qcPhe].qVoi[0].picQuanCo.Top = toaDoMoDen.y * 67 + 114;
						VanCo.player[qcPhe].qVoi[0].picQuanCo.Left = toaDoMoDen.x * 69 + 80;
						toaDoMoDen.x++;
						if (toaDoMoDen.x == 5)
						{
							toaDoMoDen.x = 0;
							toaDoMoDen.y++;
						}
					}
					else
					{
						VanCo.player[qcPhe].qVoi[0].picQuanCo.Top = toaDoMoDo.y * 67 + 774;
						VanCo.player[qcPhe].qVoi[0].picQuanCo.Left = toaDoMoDo.x * 69 + 80;
						toaDoMoDo.x++;
						if (toaDoMoDo.x == 5)
						{
							toaDoMoDo.x = 0;
							toaDoMoDo.y++;
						}
					}
				}
				if (qcPhia == "phai")
				{
					VanCo.player[qcPhe].qVoi[1].TrangThai = 0;
					VanCo.player[qcPhe].qVoi[1].picQuanCo.Cursor = Cursors.Arrow;
					VanCo.player[qcPhe].qVoi[1].picQuanCo.Width = 67;
					VanCo.player[qcPhe].qVoi[1].picQuanCo.Height = 67;
					VanCo.player[qcPhe].qVoi[1].picQuanCo.SizeMode = PictureBoxSizeMode.Zoom;
					if (qcPhe == 0)
					{
						VanCo.player[qcPhe].qVoi[1].picQuanCo.Top = toaDoMoDen.y * 67 + 114;
						VanCo.player[qcPhe].qVoi[1].picQuanCo.Left = toaDoMoDen.x * 69 + 80;
						toaDoMoDen.x++;
						if (toaDoMoDen.x == 5)
						{
							toaDoMoDen.x = 0;
							toaDoMoDen.y++;
						}
					}
					else
					{
						VanCo.player[qcPhe].qVoi[1].picQuanCo.Top = toaDoMoDo.y * 67 + 774;
						VanCo.player[qcPhe].qVoi[1].picQuanCo.Left = toaDoMoDo.x * 69 + 80;
						toaDoMoDo.x++;
						if (toaDoMoDo.x == 5)
						{
							toaDoMoDo.x = 0;
							toaDoMoDo.y++;
						}
					}
				}
			}
			if (qcTen == "si")
			{
				if (qcPhia == "trai")
				{
					VanCo.player[qcPhe].qSi[0].TrangThai = 0;
					VanCo.player[qcPhe].qSi[0].picQuanCo.Cursor = Cursors.Arrow;
					VanCo.player[qcPhe].qSi[0].picQuanCo.Width = 67;
					VanCo.player[qcPhe].qSi[0].picQuanCo.Height = 67;
					VanCo.player[qcPhe].qSi[0].picQuanCo.SizeMode = PictureBoxSizeMode.Zoom;
					if (qcPhe == 0)
					{
						VanCo.player[qcPhe].qSi[0].picQuanCo.Top = toaDoMoDen.y * 67 + 114;
						VanCo.player[qcPhe].qSi[0].picQuanCo.Left = toaDoMoDen.x * 69 + 80;
						toaDoMoDen.x++;
						if (toaDoMoDen.x == 5)
						{
							toaDoMoDen.x = 0;
							toaDoMoDen.y++;
						}
					}
					else
					{
						VanCo.player[qcPhe].qSi[0].picQuanCo.Top = toaDoMoDo.y * 67 + 774;
						VanCo.player[qcPhe].qSi[0].picQuanCo.Left = toaDoMoDo.x * 69 + 80;
						toaDoMoDo.x++;
						if (toaDoMoDo.x == 5)
						{
							toaDoMoDo.x = 0;
							toaDoMoDo.y++;
						}
					}
				}
				if (qcPhia == "phai")
				{
					VanCo.player[qcPhe].qSi[1].TrangThai = 0;
					VanCo.player[qcPhe].qSi[1].picQuanCo.Cursor = Cursors.Arrow;
					VanCo.player[qcPhe].qSi[1].picQuanCo.Width = 67;
					VanCo.player[qcPhe].qSi[1].picQuanCo.Height = 67;
					VanCo.player[qcPhe].qSi[1].picQuanCo.SizeMode = PictureBoxSizeMode.Zoom;
					if (qcPhe == 0)
					{
						VanCo.player[qcPhe].qSi[1].picQuanCo.Top = toaDoMoDen.y * 67 + 114;
						VanCo.player[qcPhe].qSi[1].picQuanCo.Left = toaDoMoDen.x * 69 + 80;
						toaDoMoDen.x++;
						if (toaDoMoDen.x == 5)
						{
							toaDoMoDen.x = 0;
							toaDoMoDen.y++;
						}
					}
					else
					{
						VanCo.player[qcPhe].qSi[1].picQuanCo.Top = toaDoMoDo.y * 67 + 774;
						VanCo.player[qcPhe].qSi[1].picQuanCo.Left = toaDoMoDo.x * 69 + 80;
						toaDoMoDo.x++;
						if (toaDoMoDo.x == 5)
						{
							toaDoMoDo.x = 0;
							toaDoMoDo.y++;
						}
					}
				}
			}
			if (qcTen == "phao")
			{
				if (qcPhia == "trai")
				{
					VanCo.player[qcPhe].qPhao[0].TrangThai = 0;
					VanCo.player[qcPhe].qPhao[0].picQuanCo.Cursor = Cursors.Arrow;
					VanCo.player[qcPhe].qPhao[0].picQuanCo.Width = 67;
					VanCo.player[qcPhe].qPhao[0].picQuanCo.Height = 67;
					VanCo.player[qcPhe].qPhao[0].picQuanCo.SizeMode = PictureBoxSizeMode.Zoom;
					if (qcPhe == 0)
					{
						VanCo.player[qcPhe].qPhao[0].picQuanCo.Top = toaDoMoDen.y * 67 + 114;
						VanCo.player[qcPhe].qPhao[0].picQuanCo.Left = toaDoMoDen.x * 69 + 80;
						toaDoMoDen.x++;
						if (toaDoMoDen.x == 5)
						{
							toaDoMoDen.x = 0;
							toaDoMoDen.y++;
						}
					}
					else
					{
						VanCo.player[qcPhe].qPhao[0].picQuanCo.Top = toaDoMoDo.y * 67 + 774;
						VanCo.player[qcPhe].qPhao[0].picQuanCo.Left = toaDoMoDo.x * 69 + 80;
						toaDoMoDo.x++;
						if (toaDoMoDo.x == 5)
						{
							toaDoMoDo.x = 0;
							toaDoMoDo.y++;
						}
					}
				}
				if (qcPhia == "phai")
				{
					VanCo.player[qcPhe].qPhao[1].TrangThai = 0;
					VanCo.player[qcPhe].qPhao[1].picQuanCo.Cursor = Cursors.Arrow;
					VanCo.player[qcPhe].qPhao[1].picQuanCo.Width = 67;
					VanCo.player[qcPhe].qPhao[1].picQuanCo.Height = 67;
					VanCo.player[qcPhe].qPhao[1].picQuanCo.SizeMode = PictureBoxSizeMode.Zoom;
					if (qcPhe == 0)
					{
						VanCo.player[qcPhe].qPhao[1].picQuanCo.Top = toaDoMoDen.y * 67 + 114;
						VanCo.player[qcPhe].qPhao[1].picQuanCo.Left = toaDoMoDen.x * 69 + 80;
						toaDoMoDen.x++;
						if (toaDoMoDen.x == 5)
						{
							toaDoMoDen.x = 0;
							toaDoMoDen.y++;
						}
					}
					else
					{
						VanCo.player[qcPhe].qPhao[1].picQuanCo.Top = toaDoMoDo.y * 67 + 774;
						VanCo.player[qcPhe].qPhao[1].picQuanCo.Left = toaDoMoDo.x * 69 + 80;
						toaDoMoDo.x++;
						if (toaDoMoDo.x == 5)
						{
							toaDoMoDo.x = 0;
							toaDoMoDo.y++;
						}
					}
				}
			}
			if (qcTen == "tot")
			{
				if (qcPhia == "1") 
				{
					
					VanCo.player[qcPhe].qTot[0].TrangThai = 0;
					VanCo.player[qcPhe].qTot[0].picQuanCo.Cursor = Cursors.Arrow;
					VanCo.player[qcPhe].qTot[0].picQuanCo.Width = 67;
					VanCo.player[qcPhe].qTot[0].picQuanCo.Height = 67;
					VanCo.player[qcPhe].qTot[0].picQuanCo.SizeMode = PictureBoxSizeMode.Zoom;
					if (qcPhe == 0)
					{
						VanCo.player[qcPhe].qTot[0].picQuanCo.Top = toaDoMoDen.y * 67 + 114;
						VanCo.player[qcPhe].qTot[0].picQuanCo.Left = toaDoMoDen.x * 69 + 80;
						toaDoMoDen.x++;
						if (toaDoMoDen.x == 5)
						{
							toaDoMoDen.x = 0;
							toaDoMoDen.y++;
						}
					}
					else
					{
						VanCo.player[qcPhe].qTot[0].picQuanCo.Top = toaDoMoDo.y * 67 + 774;
						VanCo.player[qcPhe].qTot[0].picQuanCo.Left = toaDoMoDo.x * 69 + 80;
						toaDoMoDo.x++;
						if (toaDoMoDo.x == 5)
						{
							toaDoMoDo.x = 0;
							toaDoMoDo.y++;
						}
					}
				}
				if (qcPhia == "2")
                {
					VanCo.player[qcPhe].qTot[1].TrangThai = 0;
					VanCo.player[qcPhe].qTot[1].picQuanCo.Cursor = Cursors.Arrow;
					VanCo.player[qcPhe].qTot[1].picQuanCo.Width = 67;
					VanCo.player[qcPhe].qTot[1].picQuanCo.Height = 67;
					VanCo.player[qcPhe].qTot[1].picQuanCo.SizeMode = PictureBoxSizeMode.Zoom;
					if (qcPhe == 0)
					{
						VanCo.player[qcPhe].qTot[1].picQuanCo.Top = toaDoMoDen.y * 67 + 114;
						VanCo.player[qcPhe].qTot[1].picQuanCo.Left = toaDoMoDen.x * 69 + 80;
						toaDoMoDen.x++;
						if (toaDoMoDen.x == 5)
						{
							toaDoMoDen.x = 0;
							toaDoMoDen.y++;
						}
					}
					else
					{
						VanCo.player[qcPhe].qTot[1].picQuanCo.Top = toaDoMoDo.y * 67 + 774;
						VanCo.player[qcPhe].qTot[1].picQuanCo.Left = toaDoMoDo.x * 69 + 80;
						toaDoMoDo.x++;
						if (toaDoMoDo.x == 5)
						{
							toaDoMoDo.x = 0;
							toaDoMoDo.y++;
						}
					}
				}
				if (qcPhia == "3")
				{
					VanCo.player[qcPhe].qTot[2].TrangThai = 0;
					VanCo.player[qcPhe].qTot[2].picQuanCo.Cursor = Cursors.Arrow;
					VanCo.player[qcPhe].qTot[2].picQuanCo.Width = 67;
					VanCo.player[qcPhe].qTot[2].picQuanCo.Height = 67;
					VanCo.player[qcPhe].qTot[2].picQuanCo.SizeMode = PictureBoxSizeMode.Zoom;
					if (qcPhe == 0)
					{
						VanCo.player[qcPhe].qTot[2].picQuanCo.Top = toaDoMoDen.y * 67 + 114;
						VanCo.player[qcPhe].qTot[2].picQuanCo.Left = toaDoMoDen.x * 69 + 80;
						toaDoMoDen.x++;
						if (toaDoMoDen.x == 5)
						{
							toaDoMoDen.x = 0;
							toaDoMoDen.y++;
						}
					}
					else
					{
						VanCo.player[qcPhe].qTot[2].picQuanCo.Top = toaDoMoDo.y * 67 + 774;
						VanCo.player[qcPhe].qTot[2].picQuanCo.Left = toaDoMoDo.x * 69 + 80;
						toaDoMoDo.x++;
						if (toaDoMoDo.x == 5)
						{
							toaDoMoDo.x = 0;
							toaDoMoDo.y++;
						}
					}
				}
				if (qcPhia == "4")
                {
					VanCo.player[qcPhe].qTot[3].TrangThai = 0;
					VanCo.player[qcPhe].qTot[3].picQuanCo.Cursor = Cursors.Arrow;
					VanCo.player[qcPhe].qTot[3].picQuanCo.Width = 67;
					VanCo.player[qcPhe].qTot[3].picQuanCo.Height = 67;
					VanCo.player[qcPhe].qTot[3].picQuanCo.SizeMode = PictureBoxSizeMode.Zoom;
					if (qcPhe == 0)
					{
						VanCo.player[qcPhe].qTot[3].picQuanCo.Top = toaDoMoDen.y * 67 + 114;
						VanCo.player[qcPhe].qTot[3].picQuanCo.Left = toaDoMoDen.x * 69 + 80;
						toaDoMoDen.x++;
						if (toaDoMoDen.x == 5)
						{
							toaDoMoDen.x = 0;
							toaDoMoDen.y++;
						}
					}
					else
					{
						VanCo.player[qcPhe].qTot[3].picQuanCo.Top = toaDoMoDo.y * 67 + 774;
						VanCo.player[qcPhe].qTot[3].picQuanCo.Left = toaDoMoDo.x * 69 + 80;
						toaDoMoDo.x++;
						if (toaDoMoDo.x == 5)
						{
							toaDoMoDo.x = 0;
							toaDoMoDo.y++;
						}
					}
				}
				if (qcPhia == "5")
				{
					VanCo.player[qcPhe].qTot[4].TrangThai = 0;
					VanCo.player[qcPhe].qTot[4].picQuanCo.Cursor = Cursors.Arrow;
					VanCo.player[qcPhe].qTot[4].picQuanCo.Width = 67;
					VanCo.player[qcPhe].qTot[4].picQuanCo.Height = 67;
					VanCo.player[qcPhe].qTot[4].picQuanCo.SizeMode = PictureBoxSizeMode.Zoom;
					if (qcPhe == 0)
					{
						VanCo.player[qcPhe].qTot[4].picQuanCo.Top = toaDoMoDen.y * 67 + 114;
						VanCo.player[qcPhe].qTot[4].picQuanCo.Left = toaDoMoDen.x * 69 + 80;
						toaDoMoDen.x++;
						if (toaDoMoDen.x == 5)
						{
							toaDoMoDen.x = 0;
							toaDoMoDen.y++;
						}
					}
					else
					{
						VanCo.player[qcPhe].qTot[4].picQuanCo.Top = toaDoMoDo.y * 67 + 774;
						VanCo.player[qcPhe].qTot[4].picQuanCo.Left = toaDoMoDo.x * 69 + 80;
						toaDoMoDo.x++;
						if (toaDoMoDo.x == 5)
						{
							toaDoMoDo.x = 0;
							toaDoMoDo.y++;
						}
					}
				}
			}
			
			

			
		}


		public static void Count_down(object sender, EventArgs e, int phe)
		{
			if (phe == 0)
			{
				secondsDen--;

				int m = secondsDen / 60;
				int s = secondsDen % 60;
				string mi, se;

				if (secondsDen <= 10) fBanCo.labelTimerDen.ForeColor = Color.Red;
				else fBanCo.labelTimerDen.ForeColor = SystemColors.ControlText;

				if (m > 9) mi = $"{m}";
				else mi = $"0{m}";
				if (s > 9) se = $"{s}";
				else se = $"0{s}";

				fBanCo.labelTimerDen.Text = $"{mi}:{se}";
				
				if (secondsDen == 0)
				{
					timerDen.Stop();
					fBanCo.labelTimerDen.ForeColor = SystemColors.ControlText;
					VanCo.isWin = "do";
					VanCo.NewGame();
					fEnd end = new fEnd();
					end.ShowDialog();
				}
			}
			else
			{
				secondsDo--;

				int m = secondsDo / 60;
				int s = secondsDo % 60;
				string mi, se;

				if (secondsDo <= 10) fBanCo.labelTimerDo.ForeColor = Color.Red;
				else fBanCo.labelTimerDo.ForeColor = SystemColors.ControlText;

				if (m > 9) mi = $"{m}";
				else mi = $"0{m}";
				if (s > 9) se = $"{s}";
				else se = $"0{s}";

				fBanCo.labelTimerDo.Text = $"{mi}:{se}";
				
				if (secondsDo == 0)
				{
					timerDo.Stop();
					fBanCo.labelTimerDo.ForeColor = SystemColors.ControlText;
					VanCo.isWin = "den";
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
		public static byte[] Serialize(object obj)
		{
			//khởi tạo stream để lưu các byte phân mảnh
			MemoryStream stream = new MemoryStream();
			//khởi tạo đối tượng BinaryFormatter để phân mảnh dữ liệu sang kiểu byte
			BinaryFormatter formatter = new BinaryFormatter();
			//phân mảnh rồi ghi vào stream
			formatter.Serialize(stream, obj);
			//từ stream chuyển các các byte thành dãy rồi cbi gửi đi
			return stream.ToArray();
		}

		//Hàm gom mảnh các byte nhận được rồi chuyển sang kiểu string để hiện thị lên màn hình
		public static object Deseriliaze(byte[] data)
		{
			//khởi tạo stream đọc kết quả của quá trình phân mảnh 
			MemoryStream stream = new MemoryStream(data);
			//khởi tạo đối tượng chuyển đổi
			BinaryFormatter formatter = new BinaryFormatter();
			//chuyển đổi dữ liệu và lưu lại kết quả 
			return formatter.Deserialize(stream);
		}

	}
}
