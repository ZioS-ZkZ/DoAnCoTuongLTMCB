using System;
using System.Collections.Generic;
using System.Text;

namespace CoTuong.QuanCo
{
    class ma : QuanCo
    {

        public override int KiemTra(int row, int col)
        {
            bool isCanMove = false;
            int i = row;
            int j = col;
            // kiem tra phia sau
            if (i == Hang - 2 && (j == Cot - 1 || j == Cot + 1))
                if (Hang - 2 >= 0 && Hang - 2 <= 9 && ((Cot - 1 >= 0 && Cot - 1 <= 8) || (Cot + 1 >= 0 && Cot + 1 <= 8)))
                    if (BanCo.ViTri[Hang - 1, Cot].Trong == true)
                    {
                        if (BanCo.ViTri[i, j].Trong == true) isCanMove = true;
                        if (BanCo.ViTri[i, j].Trong == false)
                            if (BanCo.ViTri[i, j].Phe != this.Phe) isCanMove = true;
                    }
            // kiem tra phia truoc
            if (i == Hang + 2 && (j == Cot - 1 || j == Cot + 1))
                if (Hang + 2 >= 0 && Hang + 2 <= 9 && ((Cot - 1 >= 0 && Cot - 1 <= 8) || (Cot + 1 >= 0 && Cot + 1 <= 8)))
                    if (BanCo.ViTri[Hang + 1, Cot].Trong == true)
                    {
                        if (BanCo.ViTri[i, j].Trong == true) isCanMove = true;
                        if (BanCo.ViTri[i, j].Trong == false)
                            if (BanCo.ViTri[i, j].Phe != this.Phe) isCanMove = true;
                    }
            //kiem trai phia trai
            if (j == Cot - 2 && (i == Hang - 1 || i == Hang + 1))
                if (Cot - 2 >= 0 && Cot - 2 <= 8 && ((Hang - 1 >= 0 && Hang - 1 <= 9) || (Hang + 1 >= 0 && Hang + 1 <= 9)))
                    if (BanCo.ViTri[Hang, Cot - 1].Trong == true)
                    {
                        if (BanCo.ViTri[i, j].Trong == true) isCanMove = true;
                        if (BanCo.ViTri[i, j].Trong == false)
                            if (BanCo.ViTri[i, j].Phe != this.Phe) isCanMove = true;
                    }
            // kiem tra phia phai
            if (j == Cot + 2 && (i == Hang - 1 || i == Hang + 1))
                if (Cot + 2 >= 0 && Cot + 2 <= 8 && ((Hang - 1 >= 0 && Hang - 1 <= 9) || (Hang + 1 >= 0 && Hang + 1 <= 9)))
                    if (BanCo.ViTri[Hang, Cot + 1].Trong == true)
                    {
                        if (BanCo.ViTri[i, j].Trong == true) isCanMove = true;
                        if (BanCo.ViTri[i, j].Trong == false)
                            if (BanCo.ViTri[i, j].Phe != this.Phe) isCanMove = true;
                    }
            if (isCanMove) return 1;
            else return 0;
        }
    }
}
