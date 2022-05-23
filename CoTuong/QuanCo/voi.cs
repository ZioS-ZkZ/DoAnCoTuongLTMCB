using System;
using System.Collections.Generic;
using System.Text;

namespace CoTuong.QuanCo
{
    [Serializable]
    public class voi : QuanCo
    {
        public override int KiemTra(int row, int col)
        {
            int i = row;
            int j = col;
            bool isCanMove = false;
            if (Phe == 0)
            {
                if (i >= 0 && i <= 4 && j >= 0 && j <= 8)
                    if ((i == Hang - 2 && j == Cot - 2 && BanCo.ViTri[Hang - 1, Cot - 1].Trong == true) 
                        || (i == Hang - 2 && j == Cot + 2 && BanCo.ViTri[Hang - 1, Cot + 1].Trong == true) 
                        || (i == Hang + 2 && j == Cot - 2 && BanCo.ViTri[Hang + 1, Cot - 1].Trong == true) 
                        || (i == Hang + 2 && j == Cot + 2 && BanCo.ViTri[Hang + 1, Cot + 1].Trong == true))
                    {
                        if (BanCo.ViTri[i, j].Trong == true) 
                            isCanMove = true;
                        if (BanCo.ViTri[i, j].Trong == false)
                            if (BanCo.ViTri[i, j].Phe != this.Phe) 
                                isCanMove = true;
                    }
            }
            if (Phe == 1)
            {
                if (i >= 5 && i <= 9 && j >= 0 && j <= 8)
                    if ((i == Hang - 2 && j == Cot - 2 && BanCo.ViTri[Hang - 1, Cot - 1].Trong == true) 
                        || (i == Hang - 2 && j == Cot + 2 && BanCo.ViTri[Hang - 1, Cot + 1].Trong == true) 
                        || (i == Hang + 2 && j == Cot - 2 && BanCo.ViTri[Hang + 1, Cot - 1].Trong == true) 
                        || (i == Hang + 2 && j == Cot + 2 && BanCo.ViTri[Hang + 1, Cot + 1].Trong == true))
                    {
                        if (BanCo.ViTri[i, j].Trong == true) 
                            isCanMove = true;
                        if (BanCo.ViTri[i, j].Trong == false)
                            if (BanCo.ViTri[i, j].Phe != this.Phe) 
                                isCanMove = true;
                    }
            }
            if (isCanMove) return 1;
            else return 0;
        }

    }
}
