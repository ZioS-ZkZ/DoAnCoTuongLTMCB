using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CoTuong.QuanCo
{
    public class QuanCo
    {
        public int Hang;
        public int Cot;
		public string Ten;
        public int Phe;
        public string Phia;// phia ben trai hoac phai VD: xe-trai, xe-phai
        public int TrangThai;// =1(con song), =0(da bi an)
        public bool isLock = false;// trang thai khoa hoac khong
        public PictureBox picQuanCo = new PictureBox();// hinh anh quan co
        public QuanCo()
        {
            Hang = 10;
            Cot = 10;// hang va cot nam ngoai ban co 
            Ten = "";
            Phe = 2;// tai o do khong co quan co
            Phia = "";
            TrangThai = 0;
            isLock = true;
        }
        public void khoiTao(int hang, int cot, string ten, int phe, string phia, int trangthai, bool islock)
        {
            Hang = hang;
            Cot = cot;
            Ten = ten;
            Phe = phe;
            Phia = phia;
            TrangThai = trangthai;
            isLock = islock;
            BanCo.ViTri[hang, cot].Hang = hang;
            BanCo.ViTri[hang, cot].Cot = cot;
            BanCo.ViTri[hang, cot].Phe = phe;
            BanCo.ViTri[hang, cot].Phia = phia;
            BanCo.ViTri[hang, cot].Ten = ten;
            BanCo.ViTri[hang, cot].Trong = false;
            picQuanCo.MouseClick += new MouseEventHandler(picQuanCo_MouseClick);
        }
        private void picQuanCo_MouseClick(Object sender,MouseEventArgs e)
        {
            switch (VanCo.isMarked)
            {
                case false:
                    if (this.TrangThai == 1)
                    {
                        if (this.isLock == false)
                        {
                            VanCo.isMarked = true;
                            VanCo.temp = new QuanCo();
                            VanCo.temp = this;
                            if (Phe == 0)
                            {
								if (Ten == "xe") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SelectXeDen;
								if (Ten == "ma") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SelectMaDen;
								if (Ten == "voi") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SelectVoiDen;
								if (Ten == "si") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SelectSiDen;
								if (Ten == "tuong") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SelectTuongDen;
								if (Ten == "phao") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SelectPhaoDen;
								if (Ten == "tot") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SelectTotDen;
							}
                            else if (Phe == 1)
                            {
								//if (!VanCo.timerDo.Enabled) VanCo.timerDo.Enabled = true;
								fBanCo.player.socket.Send(VanCo.Serialize("DOen|"));

								if (!VanCo.timerDo.Enabled) VanCo.timerDo.Enabled = true;
								if (Ten == "xe") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SelectXeDo;
								if (Ten == "ma") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SelectMaDo;
								if (Ten == "voi") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SelectVoiDo;
								if (Ten == "si") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SelectSiDo;
								if (Ten == "tuong") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SelectTuongDo;
								if (Ten == "phao") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SelectPhaoDo;
								if (Ten == "tot") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SelectTotDo;
							}
                            for (int i = 0; i < 10; i++)
                                for (int j = 0; j < 9; j++)
                                    if (this.KiemTra(i, j) == 1)
                                    {
                                        BanCo.ViTri[i, j].CanMove.Visible = true;

                                    }
                        }
                    }
                    break;
                case true:
                    if (this.TrangThai == 1)
                    {
                        if (this.Phe == VanCo.temp.Phe)
                        {
                            VanCo.isMarked = false;
                            if (VanCo.temp.Phe == 0)
                            {
								if (VanCo.temp.Ten == "xe") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_XeDen;
								if (VanCo.temp.Ten == "ma") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_MaDen;
								if (VanCo.temp.Ten == "voi") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_VoiDen;
								if (VanCo.temp.Ten == "si") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SiDen;
								if (VanCo.temp.Ten == "tuong") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_TuongDen;
								if (VanCo.temp.Ten == "phao") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_PhaoDen;
								if (VanCo.temp.Ten == "tot") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_TotDen;
							}
                            else if (VanCo.temp.Phe == 1)
                            {
								if (VanCo.temp.Ten == "xe") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_XeDo;
								if (VanCo.temp.Ten == "ma") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_MaDo;
								if (VanCo.temp.Ten == "voi") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_VoiDo;
								if (VanCo.temp.Ten == "si") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SiDo;
								if (VanCo.temp.Ten == "tuong") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_TuongDo;
								if (VanCo.temp.Ten == "phao") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_PhaoDo;
								if (VanCo.temp.Ten == "tot") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_TotDo;
							}
                            BanCo.ResetCanMove();

                        }
                        if (this.Phe != VanCo.temp.Phe)
                        {
                            if (VanCo.temp.KiemTra(this.Hang, this.Cot) == 1)
                            {
                                string inforQuanCoBiAn = this.Ten + "," + this.Phe + "," + this.Phia;
                                fBanCo.player.socket.Send(VanCo.Serialize("DANHCO|," + VanCo.temp.Hang + "," + VanCo.temp.Cot + "," + VanCo.temp.Ten + "," + VanCo.temp.Phe + "," + VanCo.temp.Phia + "," + this.Hang + "," + this.Cot + "," + VanCo.LuotDi + "," + inforQuanCoBiAn));

                                if (this.Ten == "tuong")
                                {
                                    if (this.Phe == 0)
                                        VanCo.isWin = "do";
                                    else if (this.Phe == 1)
                                        VanCo.isWin = "den";
                                }
                            }
                            if (VanCo.isWin == "do")
                            {
                                fBanCo.player.socket.Send(VanCo.Serialize("DOWIN|,"));
                            }
                            if (VanCo.isWin == "den")
                            {
                                fBanCo.player.socket.Send(VanCo.Serialize("DENWIN|,"));
                            }
                            if (VanCo.isWin == "hoa")
                            {
                                fBanCo.player.socket.Send(VanCo.Serialize("HOA|,"));
                            }
                            BanCo.ResetCanMove();

                        }

                        VanCo.isMarked = false;
                        if (VanCo.temp.Phe == 0)
                        {
							if (VanCo.temp.Ten == "xe") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_XeDen;
							if (VanCo.temp.Ten == "ma") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_MaDen;
							if (VanCo.temp.Ten == "voi") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_VoiDen;
							if (VanCo.temp.Ten == "si") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SiDen;
							if (VanCo.temp.Ten == "tuong") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_TuongDen;
							if (VanCo.temp.Ten == "phao") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_PhaoDen;
							if (VanCo.temp.Ten == "tot") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_TotDen;
						}
                        else if (VanCo.temp.Phe == 1)
                        {
							if (VanCo.temp.Ten == "xe") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_XeDo;
							if (VanCo.temp.Ten == "ma") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_MaDo;
							if (VanCo.temp.Ten == "voi") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_VoiDo;
							if (VanCo.temp.Ten == "si") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_SiDo;
							if (VanCo.temp.Ten == "tuong") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_TuongDo;
							if (VanCo.temp.Ten == "phao") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_PhaoDo;
							if (VanCo.temp.Ten == "tot") VanCo.temp.picQuanCo.Image = fBanCo.SelectedColor_TotDo;
						}
                        BanCo.ResetCanMove();


                    }
                    //fBanCo.sendStatus();
                    break;


            }
            
        }

        //Hàm vẽ quân cờ
        public void draw()
        {
			if (Phe == 0)
			{
				if (Ten == "tuong") picQuanCo.Image = fBanCo.SelectedColor_TuongDen;
				if (Ten == "si") picQuanCo.Image = fBanCo.SelectedColor_SiDen;
				if (Ten == "voi") picQuanCo.Image = fBanCo.SelectedColor_VoiDen;
				if (Ten == "xe") picQuanCo.Image = fBanCo.SelectedColor_XeDen;
				if (Ten == "phao") picQuanCo.Image = fBanCo.SelectedColor_PhaoDen;
				if (Ten == "ma") picQuanCo.Image = fBanCo.SelectedColor_MaDen;
				if (Ten == "tot") picQuanCo.Image = fBanCo.SelectedColor_TotDen;
			}
			if (Phe == 1)
			{
				if (Ten == "tuong") picQuanCo.Image = fBanCo.SelectedColor_TuongDo;
				if (Ten == "si") picQuanCo.Image = fBanCo.SelectedColor_SiDo;
				if (Ten == "voi") picQuanCo.Image = fBanCo.SelectedColor_VoiDo;
				if (Ten == "xe") picQuanCo.Image = fBanCo.SelectedColor_XeDo;
				if (Ten == "phao") picQuanCo.Image = fBanCo.SelectedColor_PhaoDo;
				if (Ten == "ma") picQuanCo.Image = fBanCo.SelectedColor_MaDo;
				if (Ten == "tot") picQuanCo.Image = fBanCo.SelectedColor_TotDo;
			}

			//Vẽ quân cờ
			picQuanCo.Width = 83;
			picQuanCo.Height = 83;
			picQuanCo.Cursor = Cursors.Hand;
            picQuanCo.BackColor = Color.Transparent;
			picQuanCo.SizeMode = PictureBoxSizeMode.StretchImage;
			picQuanCo.Top = Hang * 107 + 28;
			picQuanCo.Left = Cot * 105 + 500;

            //Thiết lập quân cờ trên Bàn Cờ

            BanCo.ViTri[Hang, Cot].Hang = Hang;
            BanCo.ViTri[Hang, Cot].Cot = Cot;
            BanCo.ViTri[Hang, Cot].Trong = false;
            BanCo.ViTri[Hang, Cot].Ten = Ten;
            BanCo.ViTri[Hang, Cot].Phia = Phia;
            BanCo.ViTri[Hang, Cot].Phe = Phe;
        }
        public virtual int KiemTra(int row, int col)
        {
            return 0;
        }
    }
}
