using System;
using System.Collections.Generic;
using System.Text;

namespace CoTuong.QuanCo
{
    [Serializable]
    public class tuong:QuanCo
    {
        public override int KiemTra(int row, int col)
        {
            bool turn = false;
            int i = row;
            int j = col;
            if ((i >= 0 && i <= 2 && j >= 3 && j <= 5) || (i >= 7 && i <= 9 && j >= 3 && j <= 5))
                if ((i == Hang + 1 && j == Cot) || (i == Hang - 1 && j == Cot) || (i == Hang && j == Cot + 1) || (i == Hang && j == Cot - 1))
                {
                    if (BanCo.ViTri[i, j].Trong == true) turn = true;
                    if (BanCo.ViTri[i, j].Trong == false)
                        if (BanCo.ViTri[i, j].Phe != this.Phe) turn = true;
                }
            if (turn) return 1;
            else return 0;
        }
    }
}
