using System;
using System.Windows.Forms;
using System.Drawing;

namespace CoTuong
{
    class BanCo
    {
        public struct OCo //struct dinh nghia 1 OCo
        {
            public int Hang;
            public int Cot;
            public string Phia;
            public bool Trong;  //Trong=True: O co dang trong | Trong=False: O co dang chua 1 quan co
            public string Ten; //Ten quan co dang dung trong Oco
            public int Phe; //Phe=0 || Phe=1
            public PictureBox CanMove;
        }

        public static OCo[,] ViTri = new OCo[10, 9]; //Mang cac OCo [10x9]

        static BanCo() //Constructor khoi tao mang ViTri trong
        {
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    ViTri[i, j].Hang = i;
                    ViTri[i, j].Cot = j;
                    ViTri[i, j].Trong = true;
                    ViTri[i, j].Ten = "";
                    ViTri[i, j].Phia = "";
                    ViTri[i, j].Phe = 2;
                    ViTri[i, j].CanMove = new PictureBox();
					ViTri[i, j].CanMove.SizeMode = PictureBoxSizeMode.StretchImage;
					ViTri[i, j].CanMove.BackColor = Color.Transparent;
					ViTri[i, j].CanMove.Image = Properties.Resources.viTriDiDuoc;
                    ViTri[i, j].CanMove.Width = 40;
                    ViTri[i, j].CanMove.Height = 40;
                    ViTri[i, j].CanMove.Top = i * 110 + 35;
                    ViTri[i, j].CanMove.Left = j * 106 + 513;
                    ViTri[i, j].CanMove.Cursor = Cursors.Hand;
                    ViTri[i, j].CanMove.Visible = false;

                }
            }
        }

        public static void ResetCanMove()
        {
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    BanCo.ViTri[i, j].CanMove.Visible = false;
                }
            }
        }
        public static void ResetBanCo()
        {
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    ViTri[i, j].Hang = i;
                    ViTri[i, j].Cot = j;
                    ViTri[i, j].Trong = true;
                    ViTri[i, j].Ten = "";
                    ViTri[i, j].Phia = "";
                    ViTri[i, j].Phe = 2;
                    ViTri[i, j].CanMove.Visible = false;
                }
            }
        }
    }
}
