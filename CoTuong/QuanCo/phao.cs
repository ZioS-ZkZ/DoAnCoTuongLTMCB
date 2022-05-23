using System;
using System.Collections.Generic;
using System.Text;

namespace CoTuong.QuanCo
{
    [Serializable]
    public class phao:QuanCo
    {
        public override int KiemTra(int row, int col)
        {
            bool isCanMove = true;
            int findEnemy = 0;// tim duoc quan co lot
            int i = row;
            int j = col;
            if (i < 0 || i > 9 || j < 0 || j > 8) isCanMove = false;// nam ngoai ban co
            if (i != Hang && j != Cot) isCanMove = false; // khong nam tren duong di chuyen
            if (i >= 0 && i <= 9 && j >= 0 && j <= 8 && (i == Hang || j == Cot))
            {
                // neu tren duong di chuyen khong co quan co
                if (BanCo.ViTri[i, j].Trong == true)
                {
                    // di chuyen qua lai
                    if (i == Hang && j >= 0 && j <= 8)
                    {
                        // qua phai
                        if (j > Cot)
                            for (int k = Cot + 1; k <= j; k++)
                            {
                                if (BanCo.ViTri[i, k].Trong == false)
                                {
                                    isCanMove = false;
                                    break;
                                }
                            }
                        // qua trai
                        if (j < Cot)
                            for (int k = j; k <= Cot - 1; k++)
                            {
                                if (BanCo.ViTri[i, k].Trong == false)
                                {
                                    isCanMove = false;
                                    break;
                                }
                            }
                    }
                    // di chuyen len xuong
                    if (j == Cot && i >= 0 && i <= 9)
                    {
                        // di len
                        if (i > Hang)
                            for (int k = Hang + 1; k <= i; k++)
                            {
                                if (BanCo.ViTri[k, j].Trong == false)
                                {
                                    isCanMove = false;
                                    break;
                                }
                            }
                        //di xuong
                        if (i < Hang)
                            for (int k = i; k <= Hang - 1; k++)
                            {
                                if (BanCo.ViTri[k, j].Trong == false)
                                {
                                    isCanMove = false;
                                    break;
                                }
                            }
                    }
                }
                // tren duong di chuyen co quan co
                if (BanCo.ViTri[i, j].Trong == false)
                {
                    // neu khac phe thi xet xem co an duoc quan co khong 
                    if (BanCo.ViTri[i, j].Phe != this.Phe)
                    {
                        if (i == Hang && j >= 0 && j <= 8)
                        {
                            if (j > Cot)
                                for (int k = Cot + 1; k < j; k++)
                                    if (BanCo.ViTri[i, k].Trong == false) findEnemy++;
                            if (j < Cot)
                                for (int k = j + 1; k <= Cot - 1; k++)
                                    if (BanCo.ViTri[i, k].Trong == false) findEnemy++;
                        }
                        if (j == Cot && i >= 0 && i <= 9)
                        {
                            if (i > Hang)
                                for (int k = Hang + 1; k < i; k++)
                                    if (BanCo.ViTri[k, j].Trong == false) findEnemy++;
                            if (i < Hang)
                                for (int k = i + 1; k <= Hang - 1; k++)
                                    if (BanCo.ViTri[k, j].Trong == false) findEnemy++;
                        }
                        if (findEnemy != 1) isCanMove = false;// quan phao chi duoc lot 1 con moi co the an duoc quan co
                    }
                    if (BanCo.ViTri[i, j].Phe == this.Phe) isCanMove = false;
                }
            }

            if (isCanMove) return 1;
            else return 0;
        }
    }
}
