using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using Newtonsoft.Json;

namespace CoTuong
{
	public partial class fBanCo : Form
	{
		private delegate void SafeCallDelegate1(string text);
		private delegate void SafeCallDelegate2(ListViewItem item);
		public static dynamic SelectedColor_board;
		public static dynamic SelectedColor_TuongDo;
		public static dynamic SelectedColor_TuongDen;
		public static dynamic SelectedColor_SiDo;
		public static dynamic SelectedColor_SiDen;
		public static dynamic SelectedColor_VoiDo;
		public static dynamic SelectedColor_VoiDen;
		public static dynamic SelectedColor_XeDo;
		public static dynamic SelectedColor_XeDen;
		public static dynamic SelectedColor_PhaoDo;
		public static dynamic SelectedColor_PhaoDen;
		public static dynamic SelectedColor_MaDo;
		public static dynamic SelectedColor_MaDen;
		public static dynamic SelectedColor_TotDo;
		public static dynamic SelectedColor_TotDen;
		public static dynamic SelectedColor_SelectTuongDo;
		public static dynamic SelectedColor_SelectTuongDen;
		public static dynamic SelectedColor_SelectSiDo;
		public static dynamic SelectedColor_SelectSiDen;
		public static dynamic SelectedColor_SelectVoiDo;
		public static dynamic SelectedColor_SelectVoiDen;
		public static dynamic SelectedColor_SelectXeDo;
		public static dynamic SelectedColor_SelectXeDen;
		public static dynamic SelectedColor_SelectPhaoDo;
		public static dynamic SelectedColor_SelectPhaoDen;
		public static dynamic SelectedColor_SelectMaDo;
		public static dynamic SelectedColor_SelectMaDen;
		public static dynamic SelectedColor_SelectTotDo;
		public static dynamic SelectedColor_SelectTotDen;
		private bool undoClicked = false;

		public fBanCo()
		{
			CheckForIllegalCrossThreadCalls = false;
			InitializeComponent();
			cmbSelectColor.SelectedIndex = 0;
		}
		public static playerSocket player = new playerSocket();
		fEnd end;
		private void fBanCo_Load(object sender, EventArgs e)
		{
			player.socket.Send(VanCo.Serialize("LAYDANHSACHPHONG|,"));
			Thread threadListen = new Thread(LangNgheServer);
			threadListen.IsBackground = true;
			threadListen.Start();
			ShowPlayerInfo();
			ShowMatchHistory();
		}
		public static string mess;
		public static string[] itemMess;
		byte[] dataNhan = new byte[1024 * 500000];
		private string enemy;
		private string host;

		private void LangNgheServer()
		{
			while (true)
			{
				try
				{
					player.socket.Receive(dataNhan);
					mess = (string)VanCo.Deseriliaze(dataNhan);
					itemMess = mess.Split('|');
					XulyMessage(itemMess[0], mess);
				}
				catch
				{
					rtbContentChat.SelectionColor = Color.Red;
					rtbContentChat.AppendText("Mất kết nối với máy chủ\n");
					rtbContentChat.ScrollToCaret();
					rtbBoxSend.Select();

					break;
				}
			}
		}
		private void XulyMessage(string itemMess, string mess)
		{
			switch (itemMess)
			{
				case "DANHSACHPHONGGAME":
					hienThiDanhSachPhongGame(mess);
					break;
				case "NGUOICHOIMOIVAOPHONG":
					coNguoiVaoPhong();
					break;
				case "PHONGDADAY":
					MessageBox.Show("Phòng Đã Đầy, Vui Lòng Chọn Phòng Khác");
					break;
				case "CHATPHONG":
					chat(mess);
					break;
				case "THOAT":
					rtbContentChat.AppendText(mess.Split(',')[1] + "\n");
					break;
				case "NEWGAME":
					newGame();
					break;
				case "DANHCO":
					fBanCo.itemMess = mess.Split(',');
					VanCo.setOCoTrong(int.Parse(fBanCo.itemMess[1]), int.Parse(fBanCo.itemMess[2]));
					VanCo.DatQuanCo(int.Parse(fBanCo.itemMess[1]),int.Parse(fBanCo.itemMess[2]), fBanCo.itemMess[3],int.Parse(fBanCo.itemMess[4]), 
									fBanCo.itemMess[5] ,int.Parse(fBanCo.itemMess[6]), int.Parse(fBanCo.itemMess[7]));
					if(fBanCo.itemMess[9] != "0")
                    {
						VanCo.AnQuanCo(fBanCo.itemMess[9], int.Parse(fBanCo.itemMess[10]), fBanCo.itemMess[11]);
					}
					VanCo.InLichSu(fBanCo.itemMess[3], int.Parse(fBanCo.itemMess[4]), int.Parse(fBanCo.itemMess[1]), int.Parse(fBanCo.itemMess[2]), int.Parse(fBanCo.itemMess[6]), int.Parse(fBanCo.itemMess[7]));
					VanCo.DoiLuotDi(int.Parse(fBanCo.itemMess[8]));
					break;
				case "DOWIN":
					DoWinHandler();
					break;
				case "DENWIN":
					DenWinHandler();
					break;
				case "HOA":
					HoaHandler();
					break;
				case "DOen":
					VanCo.timerDo.Enabled = true;
					break;
				case "TENCHUPHONG":
					LayTenChuPhong();
					break;
				case "REQUESTNEWGAME":
					if (MessageBox.Show($"{mess.Split(',')[1]} Muốn bắt đầu ván cờ mới.\nBạn có chấp nhận không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
						player.socket.Send(VanCo.Serialize("NEWGAME|,"));
					break;
				case "REQUESTDRAW":
					if(MessageBox.Show($"{mess.Split(',')[1]} cầu hoà. Bạn có muốn chấp nhận không?", "Thông báo", MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
					{
						VanCo.isWin = "Hoa";
						player.socket.Send(VanCo.Serialize("HOA|,"));
					} 
					break;
				case "CHUADUNGUOICHOI":
					MessageBox.Show("Phòng chưa đủ người chơi", "Thông báo !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
					break;
			}
		}

		private void btTaoPhong_Click(object sender, EventArgs e)
		{
			plLobby.Visible = false;
			player.chuPhong = true;
			player.socket.Send(VanCo.Serialize("TAOPHONGMOI|,"));
			rtbContentChat.AppendText("Tạo Phòng Thành Công\n");
			rtbContentChat.AppendText("Vào Phòng Thành Công\n");
		}
		private void btTimPhong_Click(object sender, EventArgs e)
		{
			player.socket.Send(VanCo.Serialize("LAYDANHSACHPHONG|,"));
		}
		private void hienThiDanhSachPhongGame(string str)
		{
			lbDanhSachPhong.Items.Clear();
			itemMess = str.Split(',');
			for (int i = 1; i < itemMess.Length - 1; i++)
			{
				lbDanhSachPhong.Items.Add("Phòng " + itemMess[i]);
			}
		}
		private void lbDanhSachPhong_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (lbDanhSachPhong.SelectedItem != null)
            {
				mess = lbDanhSachPhong.SelectedItem.ToString();
				itemMess = mess.Split('(');
				mess = itemMess[0].Replace("Phòng", "").Trim();
				try
				{
					player.socket.Send(VanCo.Serialize("VAOPHONGGAME|," + mess + ","));
					plLobby.Visible = false;
					player.chuPhong = false;
					rtbContentChat.AppendText("Vào Phòng Thành Công\n");
				}
				catch
				{
					player.socket.Close();
				}
			}
			
		}
		private void coNguoiVaoPhong()
		{
			itemMess = mess.Split(',');
			rtbContentChat.AppendText(itemMess[1] + " đã vào phòng\n");
			enemy = itemMess[1];
		}

		private void LayTenChuPhong()
		{
			itemMess = mess.Split(',');
			host = itemMess[1];
		}

		private void rtbBoxSend_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13)
			{
				player.socket.Send(VanCo.Serialize("CHATPHONG|," + player.ten + "," + rtbBoxSend.Text.Trim()));
				rtbBoxSend.Clear();
			}
		}
		private void chat(string str)
		{
			itemMess = mess.Split(',');
			rtbContentChat.SelectionColor = Color.Blue;
			rtbContentChat.AppendText("\n" + "-->> " + itemMess[1] + " : ");
			rtbContentChat.SelectionColor = Color.Green;
			rtbContentChat.AppendText(itemMess[2] + "\n");
			rtbContentChat.SelectionColor = Color.Black;
		}
		private void undo_Click(object sender, EventArgs e)
		{
			VanCo.clickSound("click");
			if (MessageBox.Show("BAN MUON QUAY TRO LAI MENU ???", "THONG BAO", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
			{
				VanCo.timerDen.Stop();
				VanCo.timerDo.Stop();
				try
				{
					if(VanCo.DangChoi )
                    {
						undoClicked = true;
						if(player.chuPhong)
                        {
							player.socket.Send(VanCo.Serialize("DENWIN|,"));
							VanCo.isWin = "den";
						}
                        else
                        {
							player.socket.Send(VanCo.Serialize("DOWIN|,"));
							VanCo.isWin = "do";
						}
					}
					else
					{
						player.socket.Send(VanCo.Serialize("THOATKHOIPHONGGAME|," + ((player.chuPhong == true) ? "1" : "0") + ","));
						plLobby.Visible = true;
						player.chuPhong = false;
						player.room = null;
						rtbContentChat.Clear();
						player.socket.Send(VanCo.Serialize("LAYDANHSACHPHONG|,"));
						ShowMatchHistory();
					}
				}
				catch
				{
					player.socket.Close();
				}
			}

		}


		private void closeFormBanCo(object sender, FormClosedEventArgs e)
		{
			VanCo.timerDen.Stop();
			VanCo.timerDo.Stop();
		}
		private void NewGame_Click(object sender, EventArgs e)
		{
			player.socket.Send(VanCo.Serialize("REQUESTNEWGAME|," + player.ten + ","));

		}
		private void newGame()
		{
			rtbContentChat.AppendText("Đã bắt đầu ván cờ mới !!!\n");
			VanCo.NewGame();
			VanCo.clickSound("ready");
			
			if (VanCo.LuotDi == 0)
				VanCo.LuotDi = 1;

			if (player.chuPhong)
			{
				for (int i = 0; i < 2; i++)
				{
					VanCo.player[0].qXe[i].isLock = true;
					VanCo.player[0].qMa[i].isLock = true;
					VanCo.player[0].qVoi[i].isLock = true;
					VanCo.player[0].qSi[i].isLock = true;
					VanCo.player[0].qPhao[i].isLock = true;
				}
				for (int i = 0; i < 5; i++)
					VanCo.player[0].qTot[i].isLock = true;
				VanCo.player[0].qTuong.isLock = true;
			} else
			{
				VanCo.LockAllChess();
			}

			if (this.InvokeRequired)
			{
				this.BeginInvoke((MethodInvoker)delegate ()
				{
					for (int i = 0; i < 10; i++)
						for (int j = 0; j < 9; j++)
						{
							this.Controls.Add(BanCo.ViTri[i, j].CanMove);
							BanCo.ViTri[i, j].CanMove.MouseClick += new MouseEventHandler(CanMove_MouseClick);
						}

				});
			}
			else
			{
				for (int i = 0; i < 10; i++)
					for (int j = 0; j < 9; j++)
					{
						this.Controls.Add(BanCo.ViTri[i, j].CanMove);
						BanCo.ViTri[i, j].CanMove.MouseClick += new MouseEventHandler(CanMove_MouseClick);
					}
			}

			addQuanCo();
			
			fBanCo.labelTimerDen.Text = "60:00";
			fBanCo.labelTimerDo.Text = "60:00";
		}
		private void CanMove_MouseClick(Object sender, MouseEventArgs e)
		{
			for (int i = 0; i <= 9; i++)
			{
				for (int j = 0; j <= 8; j++)
				{
					if (sender.Equals(BanCo.ViTri[i, j].CanMove))
					{
						if (VanCo.isMarked)
						{
							switch (BanCo.ViTri[i, j].Trong)
							{
								case true:
									if (VanCo.temp.Phe == 0)
									{
										if (VanCo.temp.Ten == "xe") VanCo.temp.picQuanCo.Image = SelectedColor_XeDen;
										if (VanCo.temp.Ten == "ma") VanCo.temp.picQuanCo.Image = SelectedColor_MaDen;
										if (VanCo.temp.Ten == "voi") VanCo.temp.picQuanCo.Image = SelectedColor_VoiDen;
										if (VanCo.temp.Ten == "si") VanCo.temp.picQuanCo.Image = SelectedColor_SiDen;
										if (VanCo.temp.Ten == "tuong") VanCo.temp.picQuanCo.Image = SelectedColor_TuongDen;
										if (VanCo.temp.Ten == "phao") VanCo.temp.picQuanCo.Image = SelectedColor_PhaoDen;
										if (VanCo.temp.Ten == "tot") VanCo.temp.picQuanCo.Image = SelectedColor_TotDen;
									}
									else if (VanCo.temp.Phe == 1)
									{
										if (VanCo.temp.Ten == "xe") VanCo.temp.picQuanCo.Image = SelectedColor_XeDo;
										if (VanCo.temp.Ten == "ma") VanCo.temp.picQuanCo.Image = SelectedColor_MaDo;
										if (VanCo.temp.Ten == "voi") VanCo.temp.picQuanCo.Image = SelectedColor_VoiDo;
										if (VanCo.temp.Ten == "si") VanCo.temp.picQuanCo.Image = SelectedColor_SiDo;
										if (VanCo.temp.Ten == "tuong") VanCo.temp.picQuanCo.Image = SelectedColor_TuongDo;
										if (VanCo.temp.Ten == "phao") VanCo.temp.picQuanCo.Image = SelectedColor_PhaoDo;
										if (VanCo.temp.Ten == "tot") VanCo.temp.picQuanCo.Image = SelectedColor_TotDo;
									}
									//Bỏ chọn quân cờ
									VanCo.isMarked = false;
									fBanCo.player.socket.Send(VanCo.Serialize("DANHCO|," + VanCo.temp.Hang + "," + VanCo.temp.Cot + "," + VanCo.temp.Ten + "," + VanCo.temp.Phe + "," + VanCo.temp.Phia + "," + i + "," + j+","+VanCo.LuotDi+","+"0,0,0"));
									BanCo.ResetCanMove();
									break;
								case false:
									if (VanCo.temp.Phe == 0)
									{
										if (VanCo.temp.Ten == "xe") VanCo.temp.picQuanCo.Image = SelectedColor_XeDen;
										if (VanCo.temp.Ten == "ma") VanCo.temp.picQuanCo.Image = SelectedColor_MaDen;
										if (VanCo.temp.Ten == "voi") VanCo.temp.picQuanCo.Image = SelectedColor_VoiDen;
										if (VanCo.temp.Ten == "si") VanCo.temp.picQuanCo.Image = SelectedColor_SiDen;
										if (VanCo.temp.Ten == "tuong") VanCo.temp.picQuanCo.Image = SelectedColor_TuongDen;
										if (VanCo.temp.Ten == "phao") VanCo.temp.picQuanCo.Image = SelectedColor_PhaoDen;
										if (VanCo.temp.Ten == "tot") VanCo.temp.picQuanCo.Image = SelectedColor_TotDen;
									}
									else if (VanCo.temp.Phe == 1)
									{
										if (VanCo.temp.Ten == "xe") VanCo.temp.picQuanCo.Image = SelectedColor_XeDo;
										if (VanCo.temp.Ten == "ma") VanCo.temp.picQuanCo.Image = SelectedColor_MaDo;
										if (VanCo.temp.Ten == "voi") VanCo.temp.picQuanCo.Image = SelectedColor_VoiDo;
										if (VanCo.temp.Ten == "si") VanCo.temp.picQuanCo.Image = SelectedColor_SiDo;
										if (VanCo.temp.Ten == "tuong") VanCo.temp.picQuanCo.Image = SelectedColor_TuongDo;
										if (VanCo.temp.Ten == "phao") VanCo.temp.picQuanCo.Image = SelectedColor_PhaoDo;
										if (VanCo.temp.Ten == "tot") VanCo.temp.picQuanCo.Image = SelectedColor_TotDo;
									}

									int PheConLai = (VanCo.temp.Phe == 0) ? 1 : 0;
									QuanCo.QuanCo QuanCoBiAn = new QuanCo.QuanCo();

									if (BanCo.ViTri[i, j].Ten == "xe")
									{
										if (BanCo.ViTri[i, j].Phia == "trai") QuanCoBiAn = VanCo.player[PheConLai].qXe[0];
										if (BanCo.ViTri[i, j].Phia == "phai") QuanCoBiAn = VanCo.player[PheConLai].qXe[1];
									}
									if (BanCo.ViTri[i, j].Ten == "ma")
									{
										if (BanCo.ViTri[i, j].Phia == "trai") QuanCoBiAn = VanCo.player[PheConLai].qMa[0];
										if (BanCo.ViTri[i, j].Phia == "phai") QuanCoBiAn = VanCo.player[PheConLai].qMa[1];
									}
									if (BanCo.ViTri[i, j].Ten == "voi")
									{
										if (BanCo.ViTri[i, j].Phia == "trai") QuanCoBiAn = VanCo.player[PheConLai].qVoi[0];
										if (BanCo.ViTri[i, j].Phia == "phai") QuanCoBiAn = VanCo.player[PheConLai].qVoi[1];
									}
									if (BanCo.ViTri[i, j].Ten == "si")
									{
										if (BanCo.ViTri[i, j].Phia == "trai") QuanCoBiAn = VanCo.player[PheConLai].qSi[0];
										if (BanCo.ViTri[i, j].Phia == "phai") QuanCoBiAn = VanCo.player[PheConLai].qSi[1];
									}
									if (BanCo.ViTri[i, j].Ten == "phao")
									{
										if (BanCo.ViTri[i, j].Phia == "trai") QuanCoBiAn = VanCo.player[PheConLai].qPhao[0];
										if (BanCo.ViTri[i, j].Phia == "phai") QuanCoBiAn = VanCo.player[PheConLai].qPhao[1];
									}
									if (BanCo.ViTri[i, j].Ten == "tot")
									{
										if (BanCo.ViTri[i, j].Phia == "1") QuanCoBiAn = VanCo.player[PheConLai].qTot[0];
										if (BanCo.ViTri[i, j].Phia == "2") QuanCoBiAn = VanCo.player[PheConLai].qTot[1];
										if (BanCo.ViTri[i, j].Phia == "3") QuanCoBiAn = VanCo.player[PheConLai].qTot[2];
										if (BanCo.ViTri[i, j].Phia == "4") QuanCoBiAn = VanCo.player[PheConLai].qTot[3];
										if (BanCo.ViTri[i, j].Phia == "5") QuanCoBiAn = VanCo.player[PheConLai].qTot[4];
									}
									if (BanCo.ViTri[i, j].Ten == "tuong")
									{
										QuanCoBiAn = VanCo.player[PheConLai].qTuong;
										if (BanCo.ViTri[i, j].Phe == 0)
											VanCo.isWin = "do";
										else if (BanCo.ViTri[i, j].Phe == 1)
											VanCo.isWin = "den";
									}
									//Bỏ chọn quân cờ
									VanCo.isMarked = false;

									//Ăn quân cờ của đối phương
									string inforQuanCoBiAn = QuanCoBiAn.Ten+ "," + QuanCoBiAn.Phe + "," + QuanCoBiAn.Phia;
									fBanCo.player.socket.Send(VanCo.Serialize("DANHCO|," + VanCo.temp.Hang + "," + VanCo.temp.Cot + "," + VanCo.temp.Ten + "," + VanCo.temp.Phe + "," + VanCo.temp.Phia + "," + i + "," + j + "," + VanCo.LuotDi + "," + inforQuanCoBiAn));

									if (VanCo.isWin == "do")
									{
										player.socket.Send(VanCo.Serialize("DOWIN|,"));
									}
									if (VanCo.isWin == "den")
									{
										player.socket.Send(VanCo.Serialize("DENWIN|,"));
									}
									if (VanCo.isWin == "hoa")
									{
										player.socket.Send(VanCo.Serialize("HOA|,"));
									}
									BanCo.ResetCanMove();
									break;
							}
						}
					}
				}

			}

		}

		private void addQuanCo()
		{
			PictureBox temp = new PictureBox();
			if (this.InvokeRequired)
			{

				this.BeginInvoke((MethodInvoker)delegate ()
				{
					for (int i = 0; i < 2; i++)
					{
						this.Controls.Add(VanCo.player[0].qXe[i].picQuanCo);
						this.Controls.Add(VanCo.player[0].qMa[i].picQuanCo);
						this.Controls.Add(VanCo.player[0].qVoi[i].picQuanCo);
						this.Controls.Add(VanCo.player[0].qSi[i].picQuanCo);
						this.Controls.Add(VanCo.player[0].qPhao[i].picQuanCo);
					}
				});

			}
			else
			{

				for (int i = 0; i < 2; i++)
				{
					this.Controls.Add(VanCo.player[0].qXe[i].picQuanCo);
					this.Controls.Add(VanCo.player[0].qMa[i].picQuanCo);
					this.Controls.Add(VanCo.player[0].qVoi[i].picQuanCo);
					this.Controls.Add(VanCo.player[0].qSi[i].picQuanCo);
					this.Controls.Add(VanCo.player[0].qPhao[i].picQuanCo);
				}
			}

			if (this.InvokeRequired)
			{
				this.BeginInvoke((MethodInvoker)delegate ()
				{
					for (int i = 0; i < 5; i++)
					{
						this.Controls.Add(VanCo.player[0].qTot[i].picQuanCo);
					}
				});
			}
			else
			{
				for (int i = 0; i < 5; i++)
				{
					this.Controls.Add(VanCo.player[0].qTot[i].picQuanCo);
				}
			}
			if (this.InvokeRequired)
			{
				this.BeginInvoke((MethodInvoker)delegate ()
				{
					this.Controls.Add(VanCo.player[0].qTuong.picQuanCo);
				});
			}
			else
			{
				this.Controls.Add(VanCo.player[0].qTuong.picQuanCo);
			}


			//====================================================

			if (this.InvokeRequired)
			{
				this.BeginInvoke((MethodInvoker)delegate ()
				{
					for (int i = 0; i < 2; i++)
					{
						this.Controls.Add(VanCo.player[1].qXe[i].picQuanCo);
						this.Controls.Add(VanCo.player[1].qMa[i].picQuanCo);
						this.Controls.Add(VanCo.player[1].qVoi[i].picQuanCo);
						this.Controls.Add(VanCo.player[1].qSi[i].picQuanCo);
						this.Controls.Add(VanCo.player[1].qPhao[i].picQuanCo);
					}

				});
			}
			else
			{
				for (int i = 0; i < 2; i++)
				{
					this.Controls.Add(VanCo.player[1].qXe[i].picQuanCo);
					this.Controls.Add(VanCo.player[1].qMa[i].picQuanCo);
					this.Controls.Add(VanCo.player[1].qVoi[i].picQuanCo);
					this.Controls.Add(VanCo.player[1].qSi[i].picQuanCo);
					this.Controls.Add(VanCo.player[1].qPhao[i].picQuanCo);
				}
			}

			if (this.InvokeRequired)
			{
				this.BeginInvoke((MethodInvoker)delegate ()
				{
					for (int i = 0; i < 5; i++)
					{
						this.Controls.Add(VanCo.player[1].qTot[i].picQuanCo);
					}
				});
			}
			else
			{
				for (int i = 0; i < 5; i++)
				{
					this.Controls.Add(VanCo.player[1].qTot[i].picQuanCo);
				}
			}

			if (this.InvokeRequired)
			{
				this.BeginInvoke((MethodInvoker)delegate ()
				{
					this.Controls.Add(VanCo.player[1].qTuong.picQuanCo);
				});
			}
			else
			{
				this.Controls.Add(VanCo.player[1].qTuong.picQuanCo);

			}
		}

		private void cmbSelectColor_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox cmb = (ComboBox)sender;
			string selectedItem = (string)(cmb.SelectedItem);
			if (selectedItem == "Default")
			{
				SelectedColor_board = CoTuong.Properties.Resources.board_default;
				SelectedColor_TuongDen = CoTuong.Properties.Resources.TuongDenDefault;
				SelectedColor_TuongDo = CoTuong.Properties.Resources.TuongDoDefault;
				SelectedColor_SiDen = CoTuong.Properties.Resources.SiDenDefault;
				SelectedColor_SiDo = CoTuong.Properties.Resources.SiDoDefault;
				SelectedColor_VoiDen = CoTuong.Properties.Resources.VoiDenDefault;
				SelectedColor_VoiDo = CoTuong.Properties.Resources.VoiDoDefault;
				SelectedColor_XeDen = CoTuong.Properties.Resources.XeDenDefault;
				SelectedColor_XeDo = CoTuong.Properties.Resources.XeDoDefault;
				SelectedColor_PhaoDen = CoTuong.Properties.Resources.PhaoDenDefault;
				SelectedColor_PhaoDo = CoTuong.Properties.Resources.PhaoDoDefault;
				SelectedColor_MaDen = CoTuong.Properties.Resources.MaDenDefault;
				SelectedColor_MaDo = CoTuong.Properties.Resources.MaDoDefault;
				SelectedColor_TotDen = CoTuong.Properties.Resources.TotDenDefault;
				SelectedColor_TotDo = CoTuong.Properties.Resources.TotDoDefault;
				SelectedColor_SelectTuongDen = CoTuong.Properties.Resources.SelectTuongDenDefault;
				SelectedColor_SelectTuongDo = CoTuong.Properties.Resources.SelectTuongDoDefault;
				SelectedColor_SelectSiDen = CoTuong.Properties.Resources.SelectSiDenDefault;
				SelectedColor_SelectSiDo = CoTuong.Properties.Resources.SelectSiDoDefault;
				SelectedColor_SelectVoiDen = CoTuong.Properties.Resources.SelectVoiDenDefault;
				SelectedColor_SelectVoiDo = CoTuong.Properties.Resources.SelectVoiDoDefault;
				SelectedColor_SelectXeDen = CoTuong.Properties.Resources.SelectXeDenDefault;
				SelectedColor_SelectXeDo = CoTuong.Properties.Resources.SelectXeDoDefault;
				SelectedColor_SelectPhaoDen = CoTuong.Properties.Resources.SelectPhaoDenDefault;
				SelectedColor_SelectPhaoDo = CoTuong.Properties.Resources.SelectPhaoDoDefault;
				SelectedColor_SelectMaDen = CoTuong.Properties.Resources.SelectMaDenDefault;
				SelectedColor_SelectMaDo = CoTuong.Properties.Resources.SelectMaDoDefault;
				SelectedColor_SelectTotDen = CoTuong.Properties.Resources.SelectTotDenDefault;
				SelectedColor_SelectTotDo = CoTuong.Properties.Resources.SelectTotDoDefault;

				lichSuDen.BackColor = lichSuDo.BackColor = System.Drawing.Color.NavajoWhite;
				lichSuDen.ForeColor = lichSuDo.ForeColor = System.Drawing.SystemColors.WindowText;
				labelTimerDen.ForeColor = labelTimerDo.ForeColor = System.Drawing.SystemColors.WindowText;

				undo.Image = CoTuong.Properties.Resources.Undo;
			}
			else if (selectedItem == "Black")
			{
				SelectedColor_board = CoTuong.Properties.Resources.board_black;
				SelectedColor_TuongDen = CoTuong.Properties.Resources.TuongDenBlack;
				SelectedColor_TuongDo = CoTuong.Properties.Resources.TuongDoBlack;
				SelectedColor_SiDen = CoTuong.Properties.Resources.SiDenBlack;
				SelectedColor_SiDo = CoTuong.Properties.Resources.SiDoBlack;
				SelectedColor_VoiDen = CoTuong.Properties.Resources.VoiDenBlack;
				SelectedColor_VoiDo = CoTuong.Properties.Resources.VoiDoBlack;
				SelectedColor_XeDen = CoTuong.Properties.Resources.XeDenBlack;
				SelectedColor_XeDo = CoTuong.Properties.Resources.XeDoBlack;
				SelectedColor_PhaoDen = CoTuong.Properties.Resources.PhaoDenBlack;
				SelectedColor_PhaoDo = CoTuong.Properties.Resources.PhaoDoBlack;
				SelectedColor_MaDen = CoTuong.Properties.Resources.MaDenBlack;
				SelectedColor_MaDo = CoTuong.Properties.Resources.MaDoBlack;
				SelectedColor_TotDen = CoTuong.Properties.Resources.TotDenBlack;
				SelectedColor_TotDo = CoTuong.Properties.Resources.TotDoBlack;
				SelectedColor_SelectTuongDen = CoTuong.Properties.Resources.SelectTuongDenBlack;
				SelectedColor_SelectTuongDo = CoTuong.Properties.Resources.SelectTuongDoBlack;
				SelectedColor_SelectSiDen = CoTuong.Properties.Resources.SelectSiDenBlack;
				SelectedColor_SelectSiDo = CoTuong.Properties.Resources.SelectSiDoBlack;
				SelectedColor_SelectVoiDen = CoTuong.Properties.Resources.SelectVoiDenBlack;
				SelectedColor_SelectVoiDo = CoTuong.Properties.Resources.SelectVoiDoBlack;
				SelectedColor_SelectXeDen = CoTuong.Properties.Resources.SelectXeDenBlack;
				SelectedColor_SelectXeDo = CoTuong.Properties.Resources.SelectXeDoBlack;
				SelectedColor_SelectPhaoDen = CoTuong.Properties.Resources.SelectPhaoDenBlack;
				SelectedColor_SelectPhaoDo = CoTuong.Properties.Resources.SelectPhaoDoBlack;
				SelectedColor_SelectMaDen = CoTuong.Properties.Resources.SelectMaDenBlack;
				SelectedColor_SelectMaDo = CoTuong.Properties.Resources.SelectMaDoBlack;
				SelectedColor_SelectTotDen = CoTuong.Properties.Resources.SelectTotDenBlack;
				SelectedColor_SelectTotDo = CoTuong.Properties.Resources.SelectTotDoBlack;

				lichSuDen.BackColor = lichSuDo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
				lichSuDen.ForeColor = lichSuDo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
				labelTimerDen.ForeColor = labelTimerDo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

				undo.Image = CoTuong.Properties.Resources.BackYellow;
			}
			else if (selectedItem == "Blue")
			{
				SelectedColor_board = CoTuong.Properties.Resources.board_blue;
				SelectedColor_TuongDen = CoTuong.Properties.Resources.TuongDenBlue;
				SelectedColor_TuongDo = CoTuong.Properties.Resources.TuongDoBlue;
				SelectedColor_SiDen = CoTuong.Properties.Resources.SiDenBlue;
				SelectedColor_SiDo = CoTuong.Properties.Resources.SiDoBlue;
				SelectedColor_VoiDen = CoTuong.Properties.Resources.VoiDenBlue;
				SelectedColor_VoiDo = CoTuong.Properties.Resources.VoiDoBlue;
				SelectedColor_XeDen = CoTuong.Properties.Resources.XeDenBlue;
				SelectedColor_XeDo = CoTuong.Properties.Resources.XeDoBlue;
				SelectedColor_PhaoDen = CoTuong.Properties.Resources.PhaoDenBlue;
				SelectedColor_PhaoDo = CoTuong.Properties.Resources.PhaoDoBlue;
				SelectedColor_MaDen = CoTuong.Properties.Resources.MaDenBlue;
				SelectedColor_MaDo = CoTuong.Properties.Resources.MaDoBlue;
				SelectedColor_TotDen = CoTuong.Properties.Resources.TotDenBlue;
				SelectedColor_TotDo = CoTuong.Properties.Resources.TotDoBlue;
				SelectedColor_SelectTuongDen = CoTuong.Properties.Resources.SelectTuongDenBlue;
				SelectedColor_SelectTuongDo = CoTuong.Properties.Resources.SelectTuongDoBlue;
				SelectedColor_SelectSiDen = CoTuong.Properties.Resources.SelectSiDenBlue;
				SelectedColor_SelectSiDo = CoTuong.Properties.Resources.SelectSiDoBlue;
				SelectedColor_SelectVoiDen = CoTuong.Properties.Resources.SelectVoiDenBlue;
				SelectedColor_SelectVoiDo = CoTuong.Properties.Resources.SelectVoiDoBlue;
				SelectedColor_SelectXeDen = CoTuong.Properties.Resources.SelectXeDenBlue;
				SelectedColor_SelectXeDo = CoTuong.Properties.Resources.SelectXeDoBlue;
				SelectedColor_SelectPhaoDen = CoTuong.Properties.Resources.SelectPhaoDenBlue;
				SelectedColor_SelectPhaoDo = CoTuong.Properties.Resources.SelectPhaoDoBlue;
				SelectedColor_SelectMaDen = CoTuong.Properties.Resources.SelectMaDenBlue;
				SelectedColor_SelectMaDo = CoTuong.Properties.Resources.SelectMaDoBlue;
				SelectedColor_SelectTotDen = CoTuong.Properties.Resources.SelectTotDenBlue;
				SelectedColor_SelectTotDo = CoTuong.Properties.Resources.SelectTotDoBlue;

				lichSuDen.BackColor = lichSuDo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(160)))), ((int)(((byte)(215)))));
				lichSuDen.ForeColor = lichSuDo.ForeColor = System.Drawing.SystemColors.WindowText;
				labelTimerDo.ForeColor = labelTimerDen.ForeColor = System.Drawing.SystemColors.WindowText;

				undo.Image = CoTuong.Properties.Resources.Undo;
			}
			else if (selectedItem == "Grey")
			{
				SelectedColor_board = CoTuong.Properties.Resources.board_grey;
				SelectedColor_TuongDen = CoTuong.Properties.Resources.TuongDenGrey;
				SelectedColor_TuongDo = CoTuong.Properties.Resources.TuongDoGrey;
				SelectedColor_SiDen = CoTuong.Properties.Resources.SiDenGrey;
				SelectedColor_SiDo = CoTuong.Properties.Resources.SiDoGrey;
				SelectedColor_VoiDen = CoTuong.Properties.Resources.VoiDenGrey;
				SelectedColor_VoiDo = CoTuong.Properties.Resources.VoiDoGrey;
				SelectedColor_XeDen = CoTuong.Properties.Resources.XeDenGrey;
				SelectedColor_XeDo = CoTuong.Properties.Resources.XeDoGrey;
				SelectedColor_PhaoDen = CoTuong.Properties.Resources.PhaoDenGrey;
				SelectedColor_PhaoDo = CoTuong.Properties.Resources.PhaoDoGrey;
				SelectedColor_MaDen = CoTuong.Properties.Resources.MaDenGrey;
				SelectedColor_MaDo = CoTuong.Properties.Resources.MaDoGrey;
				SelectedColor_TotDen = CoTuong.Properties.Resources.TotDenGrey;
				SelectedColor_TotDo = CoTuong.Properties.Resources.TotDoGrey;
				SelectedColor_SelectTuongDen = CoTuong.Properties.Resources.SelectTuongDenGrey;
				SelectedColor_SelectTuongDo = CoTuong.Properties.Resources.SelectTuongDoGrey;
				SelectedColor_SelectSiDen = CoTuong.Properties.Resources.SelectSiDenGrey;
				SelectedColor_SelectSiDo = CoTuong.Properties.Resources.SelectSiDoGrey;
				SelectedColor_SelectVoiDen = CoTuong.Properties.Resources.SelectVoiDenGrey;
				SelectedColor_SelectVoiDo = CoTuong.Properties.Resources.SelectVoiDoGrey;
				SelectedColor_SelectXeDen = CoTuong.Properties.Resources.SelectXeDenGrey;
				SelectedColor_SelectXeDo = CoTuong.Properties.Resources.SelectXeDoGrey;
				SelectedColor_SelectPhaoDen = CoTuong.Properties.Resources.SelectPhaoDenGrey;
				SelectedColor_SelectPhaoDo = CoTuong.Properties.Resources.SelectPhaoDoGrey;
				SelectedColor_SelectMaDen = CoTuong.Properties.Resources.SelectMaDenGrey;
				SelectedColor_SelectMaDo = CoTuong.Properties.Resources.SelectMaDoGrey;
				SelectedColor_SelectTotDen = CoTuong.Properties.Resources.SelectTotDenGrey;
				SelectedColor_SelectTotDo = CoTuong.Properties.Resources.SelectTotDoGrey;

				lichSuDen.BackColor = lichSuDo.BackColor = System.Drawing.SystemColors.ControlLight;
				lichSuDen.ForeColor = lichSuDo.ForeColor = System.Drawing.SystemColors.WindowText;

				labelTimerDen.ForeColor = labelTimerDo.ForeColor = System.Drawing.SystemColors.WindowText;

				undo.Image = CoTuong.Properties.Resources.Undo;
			}
			else if (selectedItem == "Paper")
			{
				SelectedColor_board = CoTuong.Properties.Resources.board_paper;
				SelectedColor_TuongDen = CoTuong.Properties.Resources.TuongDenPaper;
				SelectedColor_TuongDo = CoTuong.Properties.Resources.TuongDoPaper;
				SelectedColor_SiDen = CoTuong.Properties.Resources.SiDenPaper;
				SelectedColor_SiDo = CoTuong.Properties.Resources.SiDoPaper;
				SelectedColor_VoiDen = CoTuong.Properties.Resources.VoiDenPaper;
				SelectedColor_VoiDo = CoTuong.Properties.Resources.VoiDoPaper;
				SelectedColor_XeDen = CoTuong.Properties.Resources.XeDenPaper;
				SelectedColor_XeDo = CoTuong.Properties.Resources.XeDoPaper;
				SelectedColor_PhaoDen = CoTuong.Properties.Resources.PhaoDenPaper;
				SelectedColor_PhaoDo = CoTuong.Properties.Resources.PhaoDoPaper;
				SelectedColor_MaDen = CoTuong.Properties.Resources.MaDenPaper;
				SelectedColor_MaDo = CoTuong.Properties.Resources.MaDoPaper;
				SelectedColor_TotDen = CoTuong.Properties.Resources.TotDenPaper;
				SelectedColor_TotDo = CoTuong.Properties.Resources.TotDoPaper;
				SelectedColor_SelectTuongDen = CoTuong.Properties.Resources.SelectTuongDenPaper;
				SelectedColor_SelectTuongDo = CoTuong.Properties.Resources.SelectTuongDoPaper;
				SelectedColor_SelectSiDen = CoTuong.Properties.Resources.SelectSiDenPaper;
				SelectedColor_SelectSiDo = CoTuong.Properties.Resources.SelectSiDoPaper;
				SelectedColor_SelectVoiDen = CoTuong.Properties.Resources.SelectVoiDenPaper;
				SelectedColor_SelectVoiDo = CoTuong.Properties.Resources.SelectVoiDoPaper;
				SelectedColor_SelectXeDen = CoTuong.Properties.Resources.SelectXeDenPaper;
				SelectedColor_SelectXeDo = CoTuong.Properties.Resources.SelectXeDoPaper;
				SelectedColor_SelectPhaoDen = CoTuong.Properties.Resources.SelectPhaoDenPaper;
				SelectedColor_SelectPhaoDo = CoTuong.Properties.Resources.SelectPhaoDoPaper;
				SelectedColor_SelectMaDen = CoTuong.Properties.Resources.SelectMaDenPaper;
				SelectedColor_SelectMaDo = CoTuong.Properties.Resources.SelectMaDoPaper;
				SelectedColor_SelectTotDen = CoTuong.Properties.Resources.SelectTotDenPaper;
				SelectedColor_SelectTotDo = CoTuong.Properties.Resources.SelectTotDoPaper;

				lichSuDen.BackColor = lichSuDo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(224)))), ((int)(((byte)(212)))));
				lichSuDen.ForeColor = lichSuDo.ForeColor = System.Drawing.SystemColors.WindowText;
				labelTimerDen.ForeColor = labelTimerDo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(226)))), ((int)(((byte)(214)))));

				undo.Image = CoTuong.Properties.Resources.Undo;
			}

			this.BackgroundImage = SelectedColor_board;
			RenderBackGroundBoard();

			for (int i = 0; i < 2; i++)
			{
				VanCo.player[0].qXe[i].picQuanCo.Image = SelectedColor_XeDen;
				VanCo.player[0].qMa[i].picQuanCo.Image = SelectedColor_MaDen;
				VanCo.player[0].qVoi[i].picQuanCo.Image = SelectedColor_VoiDen;
				VanCo.player[0].qSi[i].picQuanCo.Image = SelectedColor_SiDen;
				VanCo.player[0].qPhao[i].picQuanCo.Image = SelectedColor_PhaoDen;

				VanCo.player[1].qXe[i].picQuanCo.Image = SelectedColor_XeDo;
				VanCo.player[1].qMa[i].picQuanCo.Image = SelectedColor_MaDo;
				VanCo.player[1].qVoi[i].picQuanCo.Image = SelectedColor_VoiDo;
				VanCo.player[1].qSi[i].picQuanCo.Image = SelectedColor_SiDo;
				VanCo.player[1].qPhao[i].picQuanCo.Image = SelectedColor_PhaoDo;
			}
			for (int i = 0; i < 5; i++)
			{
				VanCo.player[0].qTot[i].picQuanCo.Image = SelectedColor_TotDen;
				VanCo.player[1].qTot[i].picQuanCo.Image = SelectedColor_TotDo;
			}
			VanCo.player[0].qTuong.picQuanCo.Image = SelectedColor_TuongDen;
			VanCo.player[1].qTuong.picQuanCo.Image = SelectedColor_TuongDo;
		}

		private void RenderBackGroundBoard()
		{
			VanCo.BackBuffer = new Bitmap(this.Width, this.Height);
			Bitmap bg = new Bitmap(SelectedColor_board);
			Graphics g = Graphics.FromImage(VanCo.BackBuffer);
			g.Clear(this.BackColor);
			g.DrawImage(bg, 0, 0);
			g.Dispose();
		}

		IFirebaseConfig fcon = new FirebaseConfig()
		{
			AuthSecret = "LbuStsX6U5KYTSGKHlLOKGeOlN2XOqA3SCvyd0O0",
			BasePath = "https://ltmcb-cotuong-default-rtdb.firebaseio.com/"
		};

		IFirebaseClient client;

		public void WriteNameSafe(string text)
		{
			if (txtName.InvokeRequired)
			{
				var d = new SafeCallDelegate1(WriteNameSafe);
				txtName.Invoke(d, new object[] { text });
			}
			else
			{
				txtName.Text = text;
			}
		}

		public void WriteSexSafe(string text)
		{
			if (txtSex.InvokeRequired)
			{
				var d = new SafeCallDelegate1(WriteSexSafe);
				txtSex.Invoke(d, new object[] { text });
			}
			else
			{
				txtSex.Text = text;
			}
		}

		public void WriteBirthYearSafe(string text)
		{
			if (txtBirth.InvokeRequired)
			{
				var d = new SafeCallDelegate1(WriteBirthYearSafe);
				txtBirth.Invoke(d, new object[] { text });
			}
			else
			{
				txtBirth.Text = text;
			}
		}

		public void AddItemSafe(ListViewItem item)
		{

			if (listViewHistory.InvokeRequired)
			{
				var d = new SafeCallDelegate2(AddItemSafe);
				listViewHistory.Invoke(d, new object[] { item });
			}
			else
			{
				listViewHistory.Items.Add(item);
			}
		}

		private void ShowPlayerInfo()
		{
			try
			{
				client = new FireSharp.FirebaseClient(fcon);
				FirebaseResponse data = client.Get("PlayerInfo/" + player.ten);
				if (data.Body != "null")
				{
					PlayerInfo player = data.ResultAs<PlayerInfo>();
					WriteNameSafe(player.FullName);
					WriteSexSafe(player.Sex);
					WriteBirthYearSafe(player.BirthYear);
				} else
				{
					MessageBox.Show("Can't get player info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch
			{
				MessageBox.Show("There was a problem in the internet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void ShowMatchHistory()
		{
			listViewHistory.Items.Clear();
			try
			{
				client = new FireSharp.FirebaseClient(fcon);
				FirebaseResponse data = client.Get("MatchHistory/" + player.ten);
				
				if (data.Body != "null")
				{
					Dictionary<string, MatchInfo> treatedData = JsonConvert.DeserializeObject<Dictionary<string, MatchInfo>>(data.Body);
					int win = 0, lose = 0, draw = 0;

					foreach(var item in treatedData)
					{
						if (item.Value.Result == "Thắng")
							win++;
						else if (item.Value.Result == "Thua")
							lose++;
						else if (item.Value.Result == "Hoà")
							draw++;

						ListViewItem enemy = new ListViewItem(item.Value.Enemy);

						ListViewItem.ListViewSubItem result = new ListViewItem.ListViewSubItem(enemy, item.Value.Result);
						enemy.SubItems.Add(result);

						ListViewItem.ListViewSubItem numgo = new ListViewItem.ListViewSubItem(enemy, item.Value.NumGo);
						enemy.SubItems.Add(numgo);

						ListViewItem.ListViewSubItem totaltime = new ListViewItem.ListViewSubItem(enemy, item.Value.TotalTime);
						enemy.SubItems.Add(totaltime);

						AddItemSafe(enemy);
					}

					txtWin.Text = win.ToString();
					txtLose.Text = lose.ToString();
					txtDraw.Text = draw.ToString();
				}
				else
				{
					txtWin.Text = txtLose.Text = txtDraw.Text = "0";
				}
			}
			catch
			{
				MessageBox.Show("There was a problem in the internet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void SaveMatchInfo(MatchInfo matchInfo)
		{
			SetResponse setter = client.Set("MatchHistory/" + $"{player.ten}/" + matchInfo.ID, matchInfo);
			if (setter.StatusCode.ToString() == "OK")
			{
				MessageBox.Show("Saved match info");
			}
			else
			{
				MessageBox.Show("Can't save match info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void DoWinHandler()
		{
			MatchInfo matchInfo = new MatchInfo()
			{
				ID = DateTime.Now.ToString("hh:mm:ss tt")
			};

			if (player.chuPhong)
			{
				int m = (3600 - VanCo.secondsDo) / 60;
				int s = (3600 - VanCo.secondsDo) % 60;
				string mi, se;
				if (m > 9) mi = $"{m}";
				else mi = $"0{m}";
				if (s > 9) se = $"{s}";
				else se = $"0{s}";

				matchInfo.Result = "Thắng";
				matchInfo.NumGo = VanCo.soLanDi_Do.ToString();
				matchInfo.TotalTime = $"{mi}:{se}";
				matchInfo.Enemy = enemy;
			} else
			{
				int m = (3600 - VanCo.secondsDen) / 60;
				int s = (3600 - VanCo.secondsDen) % 60;
				string mi, se;
				if (m > 9) mi = $"{m}";
				else mi = $"0{m}";
				if (s > 9) se = $"{s}";
				else se = $"0{s}";

				matchInfo.Result = "Thua";
				matchInfo.NumGo = VanCo.soLanDi_Den.ToString();
				matchInfo.TotalTime = $"{mi}:{se}";
				matchInfo.Enemy = host;
			}

			VanCo.NewGame();
			end = new fEnd();
			end.BackgroundImage = global::CoTuong.Properties.Resources.DoThang;
			end.ShowDialog();
			VanCo.DangChoi = false;
			SaveMatchInfo(matchInfo);
			if(undoClicked)
			{
				undoClicked = false;
				player.socket.Send(VanCo.Serialize("THOATKHOIPHONGGAME|," + ((player.chuPhong == true) ? "1" : "0") + ","));
				plLobby.Visible = true;
				player.chuPhong = false;
				player.room = null;
				rtbContentChat.Clear();
				player.socket.Send(VanCo.Serialize("LAYDANHSACHPHONG|,"));
				ShowMatchHistory();
			}
		}

		private void DenWinHandler()
		{
			MatchInfo matchInfo = new MatchInfo()
			{
				ID = DateTime.Now.ToString("hh:mm:ss tt")
			};

			if (player.chuPhong)
			{
				int m = (3600 - VanCo.secondsDo) / 60;
				int s = (3600 - VanCo.secondsDo) % 60;
				string mi, se;
				if (m > 9) mi = $"{m}";
				else mi = $"0{m}";
				if (s > 9) se = $"{s}";
				else se = $"0{s}";

				matchInfo.Result = "Thua";
				matchInfo.NumGo = VanCo.soLanDi_Do.ToString();
				matchInfo.TotalTime = $"{mi}:{se}";
				matchInfo.Enemy = enemy;
			}
			else
			{
				int m = (3600 - VanCo.secondsDen) / 60;
				int s = (3600 - VanCo.secondsDen) % 60;
				string mi, se;
				if (m > 9) mi = $"{m}";
				else mi = $"0{m}";
				if (s > 9) se = $"{s}";
				else se = $"0{s}";

				matchInfo.Result = "Thắng";
				matchInfo.NumGo = VanCo.soLanDi_Den.ToString();
				matchInfo.TotalTime = $"{mi}:{se}";
				matchInfo.Enemy = host;
			}

			VanCo.NewGame();
			end = new fEnd();
			end.BackgroundImage = global::CoTuong.Properties.Resources.DenThang;
			end.ShowDialog();
			VanCo.DangChoi = false;
			SaveMatchInfo(matchInfo);
			if(undoClicked)
			{
				undoClicked = false;
				player.socket.Send(VanCo.Serialize("THOATKHOIPHONGGAME|," + ((player.chuPhong == true) ? "1" : "0") + ","));
				plLobby.Visible = true;
				player.chuPhong = false;
				player.room = null;
				rtbContentChat.Clear();
				player.socket.Send(VanCo.Serialize("LAYDANHSACHPHONG|,"));
				ShowMatchHistory();
			}
		}

		private void HoaHandler()
		{
			MatchInfo matchInfo = new MatchInfo()
			{
				ID = DateTime.Now.ToString("hh:mm:ss tt")
			};

			if (player.chuPhong)
			{
				int m = (3600 - VanCo.secondsDo) / 60;
				int s = (3600 - VanCo.secondsDo) % 60;
				string mi, se;
				if (m > 9) mi = $"{m}";
				else mi = $"0{m}";
				if (s > 9) se = $"{s}";
				else se = $"0{s}";

				matchInfo.Result = "Hoà";
				matchInfo.NumGo = VanCo.soLanDi_Do.ToString();
				matchInfo.TotalTime = $"{mi}:{se}";
				matchInfo.Enemy = enemy;
			}
			else
			{
				int m = (3600 - VanCo.secondsDen) / 60;
				int s = (3600 - VanCo.secondsDen) % 60;
				string mi, se;
				if (m > 9) mi = $"{m}";
				else mi = $"0{m}";
				if (s > 9) se = $"{s}";
				else se = $"0{s}";

				matchInfo.Result = "Hoà";
				matchInfo.NumGo = VanCo.soLanDi_Den.ToString();
				matchInfo.TotalTime = $"{mi}:{se}";
				matchInfo.Enemy = host;
			}

			VanCo.NewGame();
			end = new fEnd();
			end.BackgroundImage = global::CoTuong.Properties.Resources.Draw;
			end.ShowDialog();
			VanCo.DangChoi = false;
			SaveMatchInfo(matchInfo);
		}

		private void btnDraw_Click(object sender, EventArgs e)
		{
			player.socket.Send(VanCo.Serialize("REQUESTDRAW|," + player.ten));
		}

		private void btnCancelLobby_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
