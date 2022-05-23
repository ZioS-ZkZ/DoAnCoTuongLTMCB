using System;
using System.Collections.Generic;
using System.Text;

namespace CoTuong.QuanCo
{
    [Serializable]
    public class si : QuanCo
    {
        public override int KiemTra(int row, int col)
        {
            int i = row;
            int j = col;
            bool isCanMove = false;
            if ((i >= 0 && i <= 2 && j >= 3 && j <= 5) || (i >= 7 && i <= 9 && j >= 3 && j <= 5))// xet dieu kien nam trong o vuong
                if ((i == Hang + 1 && j == Cot + 1) || (i == Hang + 1 && j == Cot - 1) || (i == Hang - 1 && j == Cot - 1) || (i == Hang - 1 && j == Cot + 1))
                {
                    if (BanCo.ViTri[i, j].Trong == true) isCanMove = true;
                    if (BanCo.ViTri[i, j].Trong == false)
                        if (BanCo.ViTri[i, j].Phe != this.Phe) isCanMove = true;
                }

            //Trả về kết quả
            if (isCanMove) return 1;
            else return 0;
        }
    }
}
