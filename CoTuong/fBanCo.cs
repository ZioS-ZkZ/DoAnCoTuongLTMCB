using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoTuong
{
    public partial class fBanCo : Form
    {
        private bool isClickNewGame = false; // check xem da nhan vao nut NEWGAME hay chua
        public fBanCo()
        {
            InitializeComponent();

            VanCo.BackBuffer = new Bitmap(this.Width, this.Height);
            Bitmap bg = new Bitmap(CoTuong.Properties.Resources.background);
            Graphics g = Graphics.FromImage(VanCo.BackBuffer);
            g.Clear(this.BackColor);
            g.DrawImage(bg, 0, 0);
            g.Dispose();

        }
        #region ========== Ve lai bacgroud tu buffer de cho game muot hon
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //do nothing             
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(VanCo.BackBuffer, 0, 0, this.Width, this.Height);
        }
        #endregion

        private void NewGame_Click(object sender, EventArgs e)
        {
            
            VanCo.NewGame();
            if (VanCo.LuotDi == 0) VanCo.DoiLuotDi();
            for (int i = 0; i< 10; i++)
                for(int j = 0; j<9; j++)
                {
                    this.Controls.Add(BanCo.ViTri[i, j].CanMove);
                    BanCo.ViTri[i, j].CanMove.MouseClick += new MouseEventHandler(CanMove_MouseClick);
                }
            addQuanCo();
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

                                    //Ô cờ trống tại ví trí ban đầu                
                                    VanCo.setOCoTrong(VanCo.temp.Hang, VanCo.temp.Cot);

									//In lịch sử nước đi
									VanCo.InLichSu(VanCo.temp, i, j);

                                    //Đặt quân cờ đã chọn vào vị trí mới [i,j]
                                    VanCo.DatQuanCo(sender, VanCo.temp, i, j);
                                    
                                    //Thay đổi lượt đi                        
                                    VanCo.DoiLuotDi();
                                    BanCo.ResetCanMove();
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
                                        VanCo.isWin = true;
                                    }
                                    //Bỏ chọn quân cờ
                                    VanCo.isMarked = false;

                                    //Ăn quân cờ của đối phương
                                    VanCo.AnQuanCo(QuanCoBiAn);

                                    //Trả lại ô cờ trống
                                    VanCo.setOCoTrong(VanCo.temp.Hang, VanCo.temp.Cot);

									//In lịch sử nước đi
									VanCo.InLichSu(VanCo.temp, i, j);

									//Thiết lập quân cờ đã chọn vào bàn cờ
									VanCo.DatQuanCo(sender, VanCo.temp, i, j);

                                    //Thay đổi lượt đi                            
                                    VanCo.DoiLuotDi();
                                    
                                    if (VanCo.isWin)
                                    {
                                        VanCo.NewGame();
                                        fEnd end = new fEnd();
                                        end.ShowDialog();
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
            for(int i =0; i< 2; i++)
            {
                this.Controls.Add(VanCo.player[0].qXe[i].picQuanCo);
                this.Controls.Add(VanCo.player[0].qMa[i].picQuanCo);
                this.Controls.Add(VanCo.player[0].qVoi[i].picQuanCo);
                this.Controls.Add(VanCo.player[0].qSi[i].picQuanCo);
                this.Controls.Add(VanCo.player[0].qPhao[i].picQuanCo);
            }
            for (int i = 0; i < 5; i++)
                this.Controls.Add(VanCo.player[0].qTot[i].picQuanCo);
            this.Controls.Add(VanCo.player[0].qTuong.picQuanCo);

            //====================================================
            for (int i = 0; i < 2; i++)
            {
                this.Controls.Add(VanCo.player[1].qXe[i].picQuanCo);
                this.Controls.Add(VanCo.player[1].qMa[i].picQuanCo);
                this.Controls.Add(VanCo.player[1].qVoi[i].picQuanCo);
                this.Controls.Add(VanCo.player[1].qSi[i].picQuanCo);
                this.Controls.Add(VanCo.player[1].qPhao[i].picQuanCo);
            }
            for (int i = 0; i < 5; i++)
                this.Controls.Add(VanCo.player[1].qTot[i].picQuanCo);
            this.Controls.Add(VanCo.player[1].qTuong.picQuanCo);
        }

        private void undo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("BAN MUON QUAY TRO LAI MENU ???", "THONG BAO", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }

		
	}
}
