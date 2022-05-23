using System;
using System.Collections.Generic;
using System.Text;

namespace CoTuong.QuanCo
{
    [Serializable]
    public class tot:QuanCo
    {
        public override int KiemTra(int row, int col)
        {
            bool turn = false;
            int i = row;
            int j = col;
            if (Phe == 0)
            {
                // chua qua song
                if (i >= 0 && i <= 4)
                    if (i == Hang + 1 && j == Cot)
                    {
                        if (BanCo.ViTri[i, j].Trong == true) turn = true;
                        if (BanCo.ViTri[i, j].Trong == false)
                            if (BanCo.ViTri[i, j].Phe != this.Phe) turn = true;
                    }
                // da qua song 
                if (i > 4 && i <= 9)
                    if ((i == Hang + 1 && j == Cot) || (i == Hang && j == Cot - 1) || (i == Hang && j == Cot + 1))
                        if (i >= 0 && i <= 9 && j >= 0 && j <= 8)
                        {
                            if (BanCo.ViTri[i, j].Trong == true) turn = true;
                            if (BanCo.ViTri[i, j].Trong == false)
                                if (BanCo.ViTri[i, j].Phe != this.Phe) turn = true;
                        }
            }
            if (Phe == 1)
            {
                // chua qua song
                if ((i <= 9) && (i >= 5))
                    if ((i == Hang - 1) && (j == Cot))
                    {
                        if (BanCo.ViTri[i, j].Trong == true) turn = true;
                        if (BanCo.ViTri[i, j].Trong == false)
                            if (BanCo.ViTri[i, j].Phe != this.Phe) turn = true;
                    }
                // da qua song
                if ((i < 5) && (i >= 0))
                    if ((i == Hang - 1 && j == Cot) || (i == Hang && j == Cot - 1) || (i == Hang && j == Cot + 1))
                        if (i >= 0 && i <= 9 && j >= 0 && j <= 8)
                        {
                            if (BanCo.ViTri[i, j].Trong == true) turn = true;
                            if (BanCo.ViTri[i, j].Trong == false)
                                if (BanCo.ViTri[i, j].Phe != this.Phe) turn = true;
                        }
            }
            if (turn) return 1;
            else return 0;
        }
    }
}
