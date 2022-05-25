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

namespace CoTuong
{
	public partial class fBanCo : Form
	{
		public fBanCo()
		{
			CheckForIllegalCrossThreadCalls = false;
			InitializeComponent();
		}
		public static playerSocket player = new playerSocket();
		fEnd end;
		private void fBanCo_Load(object sender, EventArgs e)
		{
			player.socket.Send(VanCo.Serialize("LAYDANHSACHPHONG|,"));
			Thread threadListen = new Thread(LangNgheServer);
			threadListen.IsBackground = true;
			threadListen.Start();
		}
		public static string mess;
		public static string[] itemMess;
		byte[] dataNhan = new byte[1024 * 500000];
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
					newGame(mess);
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
					VanCo.NewGame();
					end = new fEnd();
					end.BackgroundImage = global::CoTuong.Properties.Resources.DoThang;
					end.ShowDialog();
					break;
				case "DENWIN":
					VanCo.NewGame();
					end = new fEnd();
					end.BackgroundImage = global::CoTuong.Properties.Resources.DenThang;
					end.ShowDialog();
					break;
				case "HOA":
					VanCo.NewGame();
					end = new fEnd();
					end.BackgroundImage = global::CoTuong.Properties.Resources.Draw;
					end.ShowDialog();
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
		private void coNguoiVaoPhong()
		{
			itemMess = mess.Split(',');
			rtbContentChat.AppendText(itemMess[1] + " đã vào phòng\n");
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
					player.socket.Send(VanCo.Serialize("THOATKHOIPHONGGAME|," + ((player.chuPhong == true) ? "1" : "0") + ","));
					plLobby.Visible = true;
					player.chuPhong = false;
					player.room = null;
					rtbContentChat.Clear();
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
			player.socket.Send(VanCo.Serialize("NEWGAME|," + player.ten + ","));

		}
		private void newGame(string mess)
		{
			itemMess = mess.Split(',');
			rtbContentChat.AppendText(itemMess[1] + " đã bắt đầu ván cờ mới !!!\n");
			VanCo.NewGame();
			VanCo.clickSound("ready");
			if (VanCo.LuotDi == 0)
			{
				VanCo.LuotDi = 1;// VanCo.DoiLuotDi();
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
										if (VanCo.temp.Ten == "xe") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.xeDen;
										if (VanCo.temp.Ten == "ma") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.maDen;
										if (VanCo.temp.Ten == "voi") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.voiDen;
										if (VanCo.temp.Ten == "si") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.siDen;
										if (VanCo.temp.Ten == "tuong") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.tuongDen;
										if (VanCo.temp.Ten == "phao") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.phaoDen;
										if (VanCo.temp.Ten == "tot") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.totDen;
									}
									else if (VanCo.temp.Phe == 1)
									{
										if (VanCo.temp.Ten == "xe") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.xeDo;
										if (VanCo.temp.Ten == "ma") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.maDo;
										if (VanCo.temp.Ten == "voi") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.voiDo;
										if (VanCo.temp.Ten == "si") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.siDo;
										if (VanCo.temp.Ten == "tuong") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.tuongDo;
										if (VanCo.temp.Ten == "phao") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.phaoDo;
										if (VanCo.temp.Ten == "tot") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.totDo;
									}
									//Bỏ chọn quân cờ
									VanCo.isMarked = false;
									fBanCo.player.socket.Send(VanCo.Serialize("DANHCO|," + VanCo.temp.Hang + "," + VanCo.temp.Cot + "," + VanCo.temp.Ten + "," + VanCo.temp.Phe + "," + VanCo.temp.Phia + "," + i + "," + j+","+VanCo.LuotDi+","+"0,0,0"));
									BanCo.ResetCanMove();
									//sendStatus();
									break;
								case false:
									if (VanCo.temp.Phe == 0)
									{
										if (VanCo.temp.Ten == "xe") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.xeDen;
										if (VanCo.temp.Ten == "ma") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.maDen;
										if (VanCo.temp.Ten == "voi") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.voiDen;
										if (VanCo.temp.Ten == "si") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.siDen;
										if (VanCo.temp.Ten == "tuong") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.tuongDen;
										if (VanCo.temp.Ten == "phao") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.phaoDen;
										if (VanCo.temp.Ten == "tot") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.totDen;
									}
									else if (VanCo.temp.Phe == 1)
									{
										if (VanCo.temp.Ten == "xe") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.xeDo;
										if (VanCo.temp.Ten == "ma") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.maDo;
										if (VanCo.temp.Ten == "voi") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.voiDo;
										if (VanCo.temp.Ten == "si") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.siDo;
										if (VanCo.temp.Ten == "tuong") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.tuongDo;
										if (VanCo.temp.Ten == "phao") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.phaoDo;
										if (VanCo.temp.Ten == "tot") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.totDo;
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
									//sendStatus();
									break;
							}
						}
					}
				}

			}

		}
		public static void sendStatus()
		{
			// gui thong tin cac quan co den player khac
			//quan xe
			string infoXe_00 = VanCo.player[0].qXe[0].Hang + "," + VanCo.player[0].qXe[0].Cot + "," + VanCo.player[0].qXe[0].Ten
							+ "," + VanCo.player[0].qXe[0].Phe + "," + VanCo.player[0].qXe[0].Phia + "," + VanCo.player[0].qXe[0].TrangThai;
			string infoXe_01 = VanCo.player[0].qXe[1].Hang + "," + VanCo.player[0].qXe[1].Cot + "," + VanCo.player[0].qXe[1].Ten
							+ "," + VanCo.player[0].qXe[1].Phe + "," + VanCo.player[0].qXe[1].Phia + "," + VanCo.player[0].qXe[1].TrangThai;
			string infoXe_10 = VanCo.player[1].qXe[0].Hang + "," + VanCo.player[1].qXe[0].Cot + "," + VanCo.player[1].qXe[0].Ten
							+ "," + VanCo.player[1].qXe[0].Phe + "," + VanCo.player[1].qXe[0].Phia + "," + VanCo.player[1].qXe[0].TrangThai;
			string infoXe_11 = VanCo.player[1].qXe[1].Hang + "," + VanCo.player[1].qXe[1].Cot + "," + VanCo.player[1].qXe[1].Ten
							+ "," + VanCo.player[1].qXe[1].Phe + "," + VanCo.player[1].qXe[1].Phia + "," + VanCo.player[1].qXe[1].TrangThai;
			//quan ma
			string infoMa_00 = VanCo.player[0].qMa[0].Hang + "," + VanCo.player[0].qMa[0].Cot + "," + VanCo.player[0].qMa[0].Ten
							+ "," + VanCo.player[0].qMa[0].Phe + "," + VanCo.player[0].qMa[0].Phia + "," + VanCo.player[0].qMa[0].TrangThai;
			string infoMa_01 = VanCo.player[0].qMa[1].Hang + "," + VanCo.player[0].qMa[1].Cot + "," + VanCo.player[0].qMa[1].Ten
							+ "," + VanCo.player[0].qMa[1].Phe + "," + VanCo.player[0].qMa[1].Phia + "," + VanCo.player[0].qMa[1].TrangThai;
			string infoMa_10 = VanCo.player[1].qMa[0].Hang + "," + VanCo.player[1].qMa[0].Cot + "," + VanCo.player[1].qMa[0].Ten
							+ "," + VanCo.player[1].qMa[0].Phe + "," + VanCo.player[1].qMa[0].Phia + "," + VanCo.player[1].qMa[0].TrangThai;
			string infoMa_11 = VanCo.player[1].qMa[1].Hang + "," + VanCo.player[1].qMa[1].Cot + "," + VanCo.player[1].qMa[1].Ten
							+ "," + VanCo.player[1].qMa[1].Phe + "," + VanCo.player[1].qMa[1].Phia + "," + VanCo.player[1].qMa[1].TrangThai;
			//quan voi
			string infoVoi_00 = VanCo.player[0].qVoi[0].Hang + "," + VanCo.player[0].qVoi[0].Cot + "," + VanCo.player[0].qVoi[0].Ten
							+ "," + VanCo.player[0].qVoi[0].Phe + "," + VanCo.player[0].qVoi[0].Phia + "," + VanCo.player[0].qVoi[0].TrangThai;
			string infoVoi_01 = VanCo.player[0].qVoi[1].Hang + "," + VanCo.player[0].qVoi[1].Cot + "," + VanCo.player[0].qVoi[1].Ten
							+ "," + VanCo.player[0].qVoi[1].Phe + "," + VanCo.player[0].qVoi[1].Phia + "," + VanCo.player[0].qVoi[1].TrangThai;
			string infoVoi_10 = VanCo.player[1].qVoi[0].Hang + "," + VanCo.player[1].qVoi[0].Cot + "," + VanCo.player[1].qVoi[0].Ten
							+ "," + VanCo.player[1].qVoi[0].Phe + "," + VanCo.player[1].qVoi[0].Phia + "," + VanCo.player[1].qVoi[0].TrangThai;
			string infoVoi_11 = VanCo.player[1].qVoi[1].Hang + "," + VanCo.player[1].qVoi[1].Cot + "," + VanCo.player[1].qVoi[1].Ten
							+ "," + VanCo.player[1].qVoi[1].Phe + "," + VanCo.player[1].qVoi[1].Phia + "," + VanCo.player[1].qVoi[1].TrangThai;
			// quan sy
			string infoSy_00 = VanCo.player[0].qSi[0].Hang + "," + VanCo.player[0].qSi[0].Cot + "," + VanCo.player[0].qSi[0].Ten
							+ "," + VanCo.player[0].qSi[0].Phe + "," + VanCo.player[0].qSi[0].Phia + "," + VanCo.player[0].qSi[0].TrangThai;
			string infoSy_01 = VanCo.player[0].qSi[1].Hang + "," + VanCo.player[0].qSi[1].Cot + "," + VanCo.player[0].qSi[1].Ten
							+ "," + VanCo.player[0].qSi[1].Phe + "," + VanCo.player[0].qSi[1].Phia + "," + VanCo.player[0].qSi[1].TrangThai;
			string infoSy_10 = VanCo.player[1].qSi[0].Hang + "," + VanCo.player[1].qSi[0].Cot + "," + VanCo.player[1].qSi[0].Ten
							+ "," + VanCo.player[1].qSi[0].Phe + "," + VanCo.player[1].qSi[0].Phia + "," + VanCo.player[1].qSi[0].TrangThai;
			string infoSy_11 = VanCo.player[1].qSi[1].Hang + "," + VanCo.player[1].qSi[1].Cot + "," + VanCo.player[1].qSi[1].Ten
							+ "," + VanCo.player[1].qSi[1].Phe + "," + VanCo.player[1].qSi[1].Phia + "," + VanCo.player[1].qSi[1].TrangThai;
			// quan Phao
			string infoPhao_00 = VanCo.player[0].qPhao[0].Hang + "," + VanCo.player[0].qPhao[0].Cot + "," + VanCo.player[0].qPhao[0].Ten
							+ "," + VanCo.player[0].qPhao[0].Phe + "," + VanCo.player[0].qPhao[0].Phia + "," + VanCo.player[0].qPhao[0].TrangThai;
			string infoPhao_01 = VanCo.player[0].qPhao[1].Hang + "," + VanCo.player[0].qPhao[1].Cot + "," + VanCo.player[0].qPhao[1].Ten
							+ "," + VanCo.player[0].qPhao[1].Phe + "," + VanCo.player[0].qPhao[1].Phia + "," + VanCo.player[0].qPhao[1].TrangThai;
			string infoPhao_10 = VanCo.player[1].qPhao[0].Hang + "," + VanCo.player[1].qPhao[0].Cot + "," + VanCo.player[1].qPhao[0].Ten
							+ "," + VanCo.player[1].qPhao[0].Phe + "," + VanCo.player[1].qPhao[0].Phia + "," + VanCo.player[1].qPhao[0].TrangThai;
			string infoPhao_11 = VanCo.player[1].qPhao[1].Hang + "," + VanCo.player[1].qPhao[1].Cot + "," + VanCo.player[1].qPhao[1].Ten
							+ "," + VanCo.player[1].qPhao[1].Phe + "," + VanCo.player[1].qPhao[1].Phia + "," + VanCo.player[1].qPhao[1].TrangThai;
			//quan tuong
			string infoTuongDen = VanCo.player[0].qTuong.Hang + "," + VanCo.player[0].qTuong.Cot + "," + VanCo.player[0].qTuong.Ten
							+ "," + VanCo.player[0].qTuong.Phe + "," + VanCo.player[0].qTuong.Phia + "," + VanCo.player[0].qTuong.TrangThai;
			string infoTuongDo = VanCo.player[1].qTuong.Hang + "," + VanCo.player[1].qTuong.Cot + "," + VanCo.player[1].qTuong.Ten
							+ "," + VanCo.player[1].qTuong.Phe + "," + VanCo.player[1].qTuong.Phia + "," + VanCo.player[1].qTuong.TrangThai;
			//quan tot
			string infoTot_00 = VanCo.player[0].qTot[0].Hang + "," + VanCo.player[0].qTot[0].Cot + "," + VanCo.player[0].qTot[0].Ten
						   + "," + VanCo.player[0].qTot[0].Phe + "," + VanCo.player[0].qTot[0].Phia + "," + VanCo.player[0].qTot[0].TrangThai;
			string infoTot_01 = VanCo.player[0].qTot[1].Hang + "," + VanCo.player[0].qTot[1].Cot + "," + VanCo.player[0].qTot[1].Ten
							+ "," + VanCo.player[0].qTot[1].Phe + "," + VanCo.player[0].qTot[1].Phia + "," + VanCo.player[0].qTot[1].TrangThai;
			string infoTot_02 = VanCo.player[0].qTot[2].Hang + "," + VanCo.player[0].qTot[2].Cot + "," + VanCo.player[0].qTot[2].Ten
							+ "," + VanCo.player[0].qTot[2].Phe + "," + VanCo.player[0].qTot[2].Phia + "," + VanCo.player[0].qTot[2].TrangThai;
			string infoTot_03 = VanCo.player[0].qTot[3].Hang + "," + VanCo.player[0].qTot[3].Cot + "," + VanCo.player[0].qTot[3].Ten
							+ "," + VanCo.player[0].qTot[3].Phe + "," + VanCo.player[0].qTot[3].Phia + "," + VanCo.player[0].qTot[3].TrangThai;
			string infoTot_04 = VanCo.player[0].qTot[4].Hang + "," + VanCo.player[0].qTot[4].Cot + "," + VanCo.player[0].qTot[4].Ten
							+ "," + VanCo.player[0].qTot[4].Phe + "," + VanCo.player[0].qTot[1].Phia + "," + VanCo.player[0].qTot[4].TrangThai;
			string infoTot_10 = VanCo.player[1].qTot[0].Hang + "," + VanCo.player[1].qTot[0].Cot + "," + VanCo.player[1].qTot[0].Ten
						   + "," + VanCo.player[1].qTot[0].Phe + "," + VanCo.player[1].qTot[0].Phia + "," + VanCo.player[1].qTot[0].TrangThai;
			string infoTot_11 = VanCo.player[1].qTot[1].Hang + "," + VanCo.player[1].qTot[1].Cot + "," + VanCo.player[1].qTot[1].Ten
							+ "," + VanCo.player[1].qTot[1].Phe + "," + VanCo.player[1].qTot[1].Phia + "," + VanCo.player[1].qTot[1].TrangThai;
			string infoTot_12 = VanCo.player[1].qTot[2].Hang + "," + VanCo.player[1].qTot[2].Cot + "," + VanCo.player[1].qTot[2].Ten
							+ "," + VanCo.player[1].qTot[2].Phe + "," + VanCo.player[1].qTot[2].Phia + "," + VanCo.player[1].qTot[2].TrangThai;
			string infoTot_13 = VanCo.player[1].qTot[3].Hang + "," + VanCo.player[1].qTot[3].Cot + "," + VanCo.player[1].qTot[3].Ten
							+ "," + VanCo.player[1].qTot[3].Phe + "," + VanCo.player[1].qTot[3].Phia + "," + VanCo.player[1].qTot[3].TrangThai;
			string infoTot_14 = VanCo.player[1].qTot[4].Hang + "," + VanCo.player[1].qTot[4].Cot + "," + VanCo.player[1].qTot[4].Ten
							+ "," + VanCo.player[1].qTot[4].Phe + "," + VanCo.player[1].qTot[1].Phia + "," + VanCo.player[1].qTot[4].TrangThai;
			player.socket.Send(VanCo.Serialize("DANHCO|," + infoXe_00 + "," + infoXe_01 + "," + infoXe_10 + "," + infoXe_11 + ","
														+ infoMa_00 + "," + infoMa_01 + "," + infoMa_10 + "," + infoMa_11 + ","
														+ infoVoi_00 + "," + infoVoi_01 + "," + infoVoi_10 + "," + infoVoi_11 + ","
														+ infoSy_00 + "," + infoSy_01 + "," + infoSy_10 + "," + infoSy_11 + ","
														+ infoTuongDen + "," + infoTuongDo + ","
														+ infoPhao_00 + "," + infoPhao_01 + "," + infoPhao_10 + "," + infoPhao_11 + ","
														+ infoTot_00 + "," + infoTot_01 + "," + infoTot_02 + "," + infoTot_03 + "," + infoTot_04 + ","
														+ infoTot_10 + "," + infoTot_11 + "," + infoTot_12 + "," + infoTot_13 + "," + infoTot_14 + ","));

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
			//	ComboBox cmb = (ComboBox)sender;
			//	string selectedItem = (string)(cmb.SelectedItem);
			//	if (selectedItem == "Default")
			//	{
			//		SelectedColor_board = CoTuong.Properties.Resources.board_default;
			//		SelectedColor_TuongDen = CoTuong.Properties.Resources.TuongDenDefault;
			//		SelectedColor_TuongDo = CoTuong.Properties.Resources.TuongDoDefault;
			//		SelectedColor_SiDen = CoTuong.Properties.Resources.SiDenDefault;
			//		SelectedColor_SiDo = CoTuong.Properties.Resources.SiDoDefault;
			//		SelectedColor_VoiDen = CoTuong.Properties.Resources.VoiDenDefault;
			//		SelectedColor_VoiDo = CoTuong.Properties.Resources.VoiDoDefault;
			//		SelectedColor_XeDen = CoTuong.Properties.Resources.XeDenDefault;
			//		SelectedColor_XeDo = CoTuong.Properties.Resources.XeDoDefault;
			//		SelectedColor_PhaoDen = CoTuong.Properties.Resources.PhaoDenDefault;
			//		SelectedColor_PhaoDo = CoTuong.Properties.Resources.PhaoDoDefault;
			//		SelectedColor_MaDen = CoTuong.Properties.Resources.MaDenDefault;
			//		SelectedColor_MaDo = CoTuong.Properties.Resources.MaDoDefault;
			//		SelectedColor_TotDen = CoTuong.Properties.Resources.TotDenDefault;
			//		SelectedColor_TotDo = CoTuong.Properties.Resources.TotDoDefault;
			//		SelectedColor_SelectTuongDen = CoTuong.Properties.Resources.SelecTuongDenDefault;
			//		SelectedColor_SelectTuongDo = CoTuong.Properties.Resources.SelecTuongDoDefault;
			//		SelectedColor_SelectSiDen = CoTuong.Properties.Resources.SelectSiDenDefault;
			//		SelectedColor_SelectSiDo = CoTuong.Properties.Resources.SelectSiDoDefault;
			//		SelectedColor_SelectVoiDen = CoTuong.Properties.Resources.SelectVoiDenDefault;
			//		SelectedColor_SelectVoiDo = CoTuong.Properties.Resources.SelectVoiDoDefault;
			//		SelectedColor_SelectXeDen = CoTuong.Properties.Resources.SelectXeDenDefault;
			//		SelectedColor_SelectXeDo = CoTuong.Properties.Resources.SelectXeDoDefault;
			//		SelectedColor_SelectPhaoDen = CoTuong.Properties.Resources.SelectPhaoDenDefault;
			//		SelectedColor_SelectPhaoDo = CoTuong.Properties.Resources.SelectPhaoDoDefault;
			//		SelectedColor_SelectMaDen = CoTuong.Properties.Resources.SelectMaDenDefault;
			//		SelectedColor_SelectMaDo = CoTuong.Properties.Resources.SelectMaDoDefault;
			//		SelectedColor_SelectTotDen = CoTuong.Properties.Resources.SelecTotDenDefault;
			//		SelectedColor_SelectTotDo = CoTuong.Properties.Resources.SelecTotDoDefault;

			//		lichSuDen.BackColor = lichSuDo.BackColor = System.Drawing.Color.NavajoWhite;
			//		lichSuDen.ForeColor = lichSuDo.ForeColor = System.Drawing.SystemColors.WindowText;
			//	}
			//	else if (selectedItem == "Black")
			//	{
			//		SelectedColor_board = CoTuong.Properties.Resources.board_black;
			//		SelectedColor_TuongDen = CoTuong.Properties.Resources.TuongDenBlack;
			//		SelectedColor_TuongDo = CoTuong.Properties.Resources.TuongDoBlack;
			//		SelectedColor_SiDen = CoTuong.Properties.Resources.SiDenBlack;
			//		SelectedColor_SiDo = CoTuong.Properties.Resources.SiDoBlack;
			//		SelectedColor_VoiDen = CoTuong.Properties.Resources.VoiDenBlack;
			//		SelectedColor_VoiDo = CoTuong.Properties.Resources.VoiDoBlack;
			//		SelectedColor_XeDen = CoTuong.Properties.Resources.XeDenBlack;
			//		SelectedColor_XeDo = CoTuong.Properties.Resources.XeDoBlack;
			//		SelectedColor_PhaoDen = CoTuong.Properties.Resources.PhaoDenBlack;
			//		SelectedColor_PhaoDo = CoTuong.Properties.Resources.PhaoDoBlack;
			//		SelectedColor_MaDen = CoTuong.Properties.Resources.MaDenBlack;
			//		SelectedColor_MaDo = CoTuong.Properties.Resources.MaDoBlack;
			//		SelectedColor_TotDen = CoTuong.Properties.Resources.TotDenBlack;
			//		SelectedColor_TotDo = CoTuong.Properties.Resources.TotDoBlack;
			//		SelectedColor_SelectTuongDen = CoTuong.Properties.Resources.SelectTuongDenBlack;
			//		SelectedColor_SelectTuongDo = CoTuong.Properties.Resources.SelectTuongDoBlack;
			//		SelectedColor_SelectSiDen = CoTuong.Properties.Resources.SelectSiDenBlack;
			//		SelectedColor_SelectSiDo = CoTuong.Properties.Resources.SelectSiDoBlack;
			//		SelectedColor_SelectVoiDen = CoTuong.Properties.Resources.SelectVoiDenBlack;
			//		SelectedColor_SelectVoiDo = CoTuong.Properties.Resources.SelectVoiDoBlack;
			//		SelectedColor_SelectXeDen = CoTuong.Properties.Resources.SelectXeDenBlack;
			//		SelectedColor_SelectXeDo = CoTuong.Properties.Resources.SelectXeDoBlack;
			//		SelectedColor_SelectPhaoDen = CoTuong.Properties.Resources.SelectPhaoDenBlack;
			//		SelectedColor_SelectPhaoDo = CoTuong.Properties.Resources.SelectPhaoDoBlack;
			//		SelectedColor_SelectMaDen = CoTuong.Properties.Resources.SelectMaDenBlack;
			//		SelectedColor_SelectMaDo = CoTuong.Properties.Resources.SelectMaDoBlack;
			//		SelectedColor_SelectTotDen = CoTuong.Properties.Resources.SelectTotDenBlack;
			//		SelectedColor_SelectTotDo = CoTuong.Properties.Resources.SelectTotDoBlack;

			//		lichSuDen.BackColor = lichSuDo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			//		lichSuDen.ForeColor = lichSuDo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			//	}
			//	else if (selectedItem == "Blue")
			//	{
			//		SelectedColor_board = CoTuong.Properties.Resources.board_blue;
			//		SelectedColor_TuongDen = CoTuong.Properties.Resources.TuongDenBlue;
			//		SelectedColor_TuongDo = CoTuong.Properties.Resources.TuongDoBlue;
			//		SelectedColor_SiDen = CoTuong.Properties.Resources.SiDenBlue;
			//		SelectedColor_SiDo = CoTuong.Properties.Resources.SiDoBlue;
			//		SelectedColor_VoiDen = CoTuong.Properties.Resources.VoiDenBlue;
			//		SelectedColor_VoiDo = CoTuong.Properties.Resources.VoiDoBlue;
			//		SelectedColor_XeDen = CoTuong.Properties.Resources.XeDenBlue;
			//		SelectedColor_XeDo = CoTuong.Properties.Resources.XeDoBlue;
			//		SelectedColor_PhaoDen = CoTuong.Properties.Resources.PhaoDenBlue;
			//		SelectedColor_PhaoDo = CoTuong.Properties.Resources.PhaoDoBlue;
			//		SelectedColor_MaDen = CoTuong.Properties.Resources.MaDenBlue;
			//		SelectedColor_MaDo = CoTuong.Properties.Resources.MaDoBlue;
			//		SelectedColor_TotDen = CoTuong.Properties.Resources.TotDenBlue;
			//		SelectedColor_TotDo = CoTuong.Properties.Resources.TotDoBlue;
			//		SelectedColor_SelectTuongDen = CoTuong.Properties.Resources.SelectTuongDenBlue;
			//		SelectedColor_SelectTuongDo = CoTuong.Properties.Resources.SelectTuongDoBlue;
			//		SelectedColor_SelectSiDen = CoTuong.Properties.Resources.SelectSiDenBlue;
			//		SelectedColor_SelectSiDo = CoTuong.Properties.Resources.SelectSiDoBlue;
			//		SelectedColor_SelectVoiDen = CoTuong.Properties.Resources.SelectVoiDenBlue;
			//		SelectedColor_SelectVoiDo = CoTuong.Properties.Resources.SelectVoiDoBlue;
			//		SelectedColor_SelectXeDen = CoTuong.Properties.Resources.SelectXeDenBlue;
			//		SelectedColor_SelectXeDo = CoTuong.Properties.Resources.SelectXeDoBlue;
			//		SelectedColor_SelectPhaoDen = CoTuong.Properties.Resources.SelectPhaoDenBlue;
			//		SelectedColor_SelectPhaoDo = CoTuong.Properties.Resources.SelectPhaoDoBlue;
			//		SelectedColor_SelectMaDen = CoTuong.Properties.Resources.SelectMaDenBlue;
			//		SelectedColor_SelectMaDo = CoTuong.Properties.Resources.SelectMaDoBlue;
			//		SelectedColor_SelectTotDen = CoTuong.Properties.Resources.SelectTotDenBlue;
			//		SelectedColor_SelectTotDo = CoTuong.Properties.Resources.SelectTotDoBlue;

			//		lichSuDen.BackColor = lichSuDo.BackColor = System.Drawing.SystemColors.ActiveCaption;
			//		lichSuDen.ForeColor = lichSuDo.ForeColor = System.Drawing.SystemColors.WindowText;
			//	}
			//	else if (selectedItem == "Grey")
			//	{
			//		SelectedColor_board = CoTuong.Properties.Resources.board_grey;
			//		SelectedColor_TuongDen = CoTuong.Properties.Resources.TuongDenGrey;
			//		SelectedColor_TuongDo = CoTuong.Properties.Resources.TuongDoGrey;
			//		SelectedColor_SiDen = CoTuong.Properties.Resources.SiDenGrey;
			//		SelectedColor_SiDo = CoTuong.Properties.Resources.SiDoGrey;
			//		SelectedColor_VoiDen = CoTuong.Properties.Resources.VoiDenGrey;
			//		SelectedColor_VoiDo = CoTuong.Properties.Resources.VoiDoGrey;
			//		SelectedColor_XeDen = CoTuong.Properties.Resources.XeDenGrey;
			//		SelectedColor_XeDo = CoTuong.Properties.Resources.XeDoGrey;
			//		SelectedColor_PhaoDen = CoTuong.Properties.Resources.PhaoDenGrey;
			//		SelectedColor_PhaoDo = CoTuong.Properties.Resources.PhaoDoGrey;
			//		SelectedColor_MaDen = CoTuong.Properties.Resources.MaDenGrey;
			//		SelectedColor_MaDo = CoTuong.Properties.Resources.MaDoGrey;
			//		SelectedColor_TotDen = CoTuong.Properties.Resources.TotDenGrey;
			//		SelectedColor_TotDo = CoTuong.Properties.Resources.TotDoGrey;
			//		SelectedColor_SelectTuongDen = CoTuong.Properties.Resources.SelectTuongDenGrey;
			//		SelectedColor_SelectTuongDo = CoTuong.Properties.Resources.SelectTuongDoGrey;
			//		SelectedColor_SelectSiDen = CoTuong.Properties.Resources.SelectSiDenGrey;
			//		SelectedColor_SelectSiDo = CoTuong.Properties.Resources.SelectSiDoGrey;
			//		SelectedColor_SelectVoiDen = CoTuong.Properties.Resources.SelectVoiDenGrey;
			//		SelectedColor_SelectVoiDo = CoTuong.Properties.Resources.SelectVoiDoGrey;
			//		SelectedColor_SelectXeDen = CoTuong.Properties.Resources.SelectXeDenGrey;
			//		SelectedColor_SelectXeDo = CoTuong.Properties.Resources.SelectXeDoGrey;
			//		SelectedColor_SelectPhaoDen = CoTuong.Properties.Resources.SelectPhaoDenGrey;
			//		SelectedColor_SelectPhaoDo = CoTuong.Properties.Resources.SelectPhaoDoGrey;
			//		SelectedColor_SelectMaDen = CoTuong.Properties.Resources.SelectMaDenGrey;
			//		SelectedColor_SelectMaDo = CoTuong.Properties.Resources.SelectMaDoGrey;
			//		SelectedColor_SelectTotDen = CoTuong.Properties.Resources.SelectTotDenGrey;
			//		SelectedColor_SelectTotDo = CoTuong.Properties.Resources.SelectTotDoGrey;

			//		lichSuDen.BackColor = lichSuDo.BackColor = System.Drawing.SystemColors.ControlLight;
			//		lichSuDen.ForeColor = lichSuDo.ForeColor = System.Drawing.SystemColors.WindowText;
			//	}
			//	else if (selectedItem == "Paper")
			//	{
			//		SelectedColor_board = CoTuong.Properties.Resources.board_paper;
			//		SelectedColor_TuongDen = CoTuong.Properties.Resources.TuongDenPaper;
			//		SelectedColor_TuongDo = CoTuong.Properties.Resources.TuongDoPaper;
			//		SelectedColor_SiDen = CoTuong.Properties.Resources.SiDenPaper;
			//		SelectedColor_SiDo = CoTuong.Properties.Resources.SiDoPaper;
			//		SelectedColor_VoiDen = CoTuong.Properties.Resources.VoiDenPaper;
			//		SelectedColor_VoiDo = CoTuong.Properties.Resources.VoiDoPaper;
			//		SelectedColor_XeDen = CoTuong.Properties.Resources.XeDenPaper;
			//		SelectedColor_XeDo = CoTuong.Properties.Resources.XeDoPaper;
			//		SelectedColor_PhaoDen = CoTuong.Properties.Resources.PhaoDenPaper;
			//		SelectedColor_PhaoDo = CoTuong.Properties.Resources.PhaoDoPaper;
			//		SelectedColor_MaDen = CoTuong.Properties.Resources.MaDenPaper;
			//		SelectedColor_MaDo = CoTuong.Properties.Resources.MaDoPaper;
			//		SelectedColor_TotDen = CoTuong.Properties.Resources.TotDenPaper;
			//		SelectedColor_TotDo = CoTuong.Properties.Resources.TotDoPaper;
			//		SelectedColor_SelectTuongDen = CoTuong.Properties.Resources.SelectTuongDenPaper;
			//		SelectedColor_SelectTuongDo = CoTuong.Properties.Resources.SelectTuongDoPaper;
			//		SelectedColor_SelectSiDen = CoTuong.Properties.Resources.SelectSiDenPaper;
			//		SelectedColor_SelectSiDo = CoTuong.Properties.Resources.SelectSiDoPaper;
			//		SelectedColor_SelectVoiDen = CoTuong.Properties.Resources.SelectVoiDenPaper;
			//		SelectedColor_SelectVoiDo = CoTuong.Properties.Resources.SelectVoiDoPaper;
			//		SelectedColor_SelectXeDen = CoTuong.Properties.Resources.SelectXeDenPaper;
			//		SelectedColor_SelectXeDo = CoTuong.Properties.Resources.SelectXeDoPaper;
			//		SelectedColor_SelectPhaoDen = CoTuong.Properties.Resources.SelectPhaoDenPaper;
			//		SelectedColor_SelectPhaoDo = CoTuong.Properties.Resources.SelectPhaoDoPaper;
			//		SelectedColor_SelectMaDen = CoTuong.Properties.Resources.SelectMaDenPaper;
			//		SelectedColor_SelectMaDo = CoTuong.Properties.Resources.SelectMaDoPaper;
			//		SelectedColor_SelectTotDen = CoTuong.Properties.Resources.SelectTotDenPaper;
			//		SelectedColor_SelectTotDo = CoTuong.Properties.Resources.SelectTotDoPaper;

			//		lichSuDen.BackColor = lichSuDo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			//		lichSuDen.ForeColor = lichSuDo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			//	}

			//	this.BackgroundImage = SelectedColor_board;
			//	RenderBackGroundBoard();

			//	for (int i = 0; i < 2; i++)
			//	{
			//		VanCo.player[0].qXe[i].draw();
			//		VanCo.player[0].qMa[i].draw();
			//		VanCo.player[0].qVoi[i].draw();
			//		VanCo.player[0].qSi[i].draw();
			//		VanCo.player[0].qPhao[i].draw();
			//	}
			//	for (int i = 0; i < 5; i++)
			//		VanCo.player[0].qTot[i].draw();
			//	VanCo.player[0].qTuong.draw();
			//	//========================
			//	for (int i = 0; i < 2; i++)
			//	{
			//		VanCo.player[1].qXe[i].draw();
			//		VanCo.player[1].qMa[i].draw();
			//		VanCo.player[1].qVoi[i].draw();
			//		VanCo.player[1].qSi[i].draw();
			//		VanCo.player[1].qPhao[i].draw();
			//	}
			//	for (int i = 0; i < 5; i++)
			//		VanCo.player[1].qTot[i].draw();
			//	VanCo.player[1].qTuong.draw();
		}

		private void RenderBackGroundBoard()
		{
			//	VanCo.BackBuffer = new Bitmap(this.Width, this.Height);
			//	Bitmap bg = new Bitmap(SelectedColor_board);
			//	Graphics g = Graphics.FromImage(VanCo.BackBuffer);
			//	g.Clear(this.BackColor);
			//	g.DrawImage(bg, 0, 0);
			//	g.Dispose();
			//}
		}
	}
}
