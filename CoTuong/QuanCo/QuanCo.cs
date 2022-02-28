using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;


namespace CoTuong.QuanCo
{
    class QuanCo
    {
        public int Hang;
        public int Cot;
		public int toaDoMoDo_x;//toa do hien thi quan co bi an
		public int toaDoMoDo_y;//toa do hien thi quan co bi an
		public int toaDoMoDen_x;//toa do hien thi quan co bi an
		public int toaDoMoDen_y;//toa do hien thi quan co bi an
		public static List<QuanCo> dsCoChet_Do = new List<QuanCo>();
		public static List<QuanCo> dsCoChet_Den = new List<QuanCo>();
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
                                    if (Ten == "xe") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.selecXeDen;
                                    if (Ten == "ma") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.selecMaDen;
                                    if (Ten == "voi") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.selecVoiDen;
                                    if (Ten == "si") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.selecSiDen;
                                    if (Ten == "tuong") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.selecTuongDen;
                                    if (Ten == "phao") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.selecPhaoDen;
                                    if (Ten == "tot") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.selecTotDen;
                                }
                                else if (Phe == 1)
                                {
                                    if (Ten == "xe") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.selecXeDo;
                                    if (Ten == "ma") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.selecMaDo;
                                    if (Ten == "voi") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.selecVoiDo;
                                    if (Ten == "si") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.selecSiDo;
                                    if (Ten == "tuong") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.selecTuongDo;
                                    if (Ten == "phao") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.selecPhaoDo;
                                    if (Ten == "tot") VanCo.temp.picQuanCo.Image = CoTuong.Properties.Resources.selecTotDo;
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
                    if(this.TrangThai == 1)
                    {
                        if(this.Phe == VanCo.temp.Phe)
                        {
                            VanCo.isMarked = false;
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
                            BanCo.ResetCanMove();
                        }
                        if(this.Phe != VanCo.temp.Phe)
                        {
                            if (VanCo.temp.KiemTra(this.Hang, this.Cot) == 1)
                            {
                                VanCo.setOCoTrong(VanCo.temp.Hang, VanCo.temp.Cot);
                                VanCo.AnQuanCo(this);
                                if (this.Ten == "tuong")
                                    VanCo.isWin = true;
                                VanCo.DatQuanCo(sender, VanCo.temp, this.Hang, this.Cot);
                                VanCo.DoiLuotDi();
                            }
                            if (VanCo.isWin)
                            {
                                VanCo.NewGame();
                                fEnd end = new fEnd();
                                end.ShowDialog();
                            }
                            BanCo.ResetCanMove();
                        }
                        
                        VanCo.isMarked = false;
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
                        BanCo.ResetCanMove();

                    }

                    break;
                
            }
        }
        //Hàm vẽ quân cờ
        public void draw()
        {
            if (Phe == 0)
            {
                if (Ten == "tuong") picQuanCo.Image = CoTuong.Properties.Resources.tuongDen;
                if (Ten == "si") picQuanCo.Image = CoTuong.Properties.Resources.siDen;
                if (Ten == "voi") picQuanCo.Image = CoTuong.Properties.Resources.voiDen;
                if (Ten == "xe") picQuanCo.Image = CoTuong.Properties.Resources.xeDen;
                if (Ten == "phao") picQuanCo.Image = CoTuong.Properties.Resources.phaoDen;
                if (Ten == "ma") picQuanCo.Image = CoTuong.Properties.Resources.maDen;
                if (Ten == "tot") picQuanCo.Image = CoTuong.Properties.Resources.totDen;
            }
            if (Phe == 1)
            {
                if (Ten == "tuong") picQuanCo.Image = CoTuong.Properties.Resources.tuongDo;
                if (Ten == "si") picQuanCo.Image = CoTuong.Properties.Resources.siDo;
                if (Ten == "voi") picQuanCo.Image = CoTuong.Properties.Resources.voiDo;
                if (Ten == "xe") picQuanCo.Image = CoTuong.Properties.Resources.xeDo;
                if (Ten == "phao") picQuanCo.Image = CoTuong.Properties.Resources.phaoDo;
                if (Ten == "ma") picQuanCo.Image = CoTuong.Properties.Resources.maDo;
                if (Ten == "tot") picQuanCo.Image = CoTuong.Properties.Resources.totDo;
            }

            //Vẽ quân cờ
            picQuanCo.Width = 39;
            picQuanCo.Height = 39;
            picQuanCo.Cursor = Cursors.Hand;
            picQuanCo.Top = Hang * 50 + 31;
            picQuanCo.Left = Cot * 49 + 10;
            picQuanCo.BackColor = Color.Transparent;


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
