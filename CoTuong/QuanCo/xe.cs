using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CoTuong.QuanCo
{
    class xe : QuanCo
    {
        public override int KiemTra(int row, int col)
        {
            // mang chua cac vi tri di chuyen duoc
            List<ToaDo> isCanMove = new List<ToaDo>();
            // kiem tra trai  
            for (int i = 1; Cot - i >= 0; i++)
            {
                if (BanCo.ViTri[Hang, Cot - i].Trong == true)
                    isCanMove.Add(new ToaDo(Hang, Cot - i));
                else
                {
                    if (BanCo.ViTri[Hang, Cot].Phe == 0 && BanCo.ViTri[Hang, Cot - i].Phe == 1)
                        isCanMove.Add(new ToaDo(Hang, Cot - i));
                    else if (BanCo.ViTri[Hang, Cot].Phe == 1 && BanCo.ViTri[Hang, Cot - i].Phe == 0)
                        isCanMove.Add(new ToaDo(Hang, Cot - i));
                    break;
                }
            }
            //kiem tra phai
            for (int i = 1; Cot + i <= 8; i++)
            {
                if (BanCo.ViTri[Hang, Cot + i].Trong == true)
                    isCanMove.Add(new ToaDo(Hang, Cot + i));
                else
                {
                    if (BanCo.ViTri[Hang, Cot].Phe == 0 && BanCo.ViTri[Hang, Cot + i].Phe == 1)
                        isCanMove.Add(new ToaDo(Hang, Cot + i));
                    else if (BanCo.ViTri[Hang, Cot].Phe == 1 && BanCo.ViTri[Hang, Cot + i].Phe == 0)
                        isCanMove.Add(new ToaDo(Hang, Cot + i));
                    break;
                }
            }
            // kiem tra phia sau
            for (int i = 1; Hang - i >= 0; i++)
            {
                if (BanCo.ViTri[Hang - i, Cot].Trong == true)
                    isCanMove.Add(new ToaDo(Hang - i, Cot));
                else
                {
                    if (BanCo.ViTri[Hang, Cot].Phe == 0 && BanCo.ViTri[Hang - i, Cot].Phe == 1)
                        isCanMove.Add(new ToaDo(Hang - i, Cot));
                    else if (BanCo.ViTri[Hang, Cot].Phe == 1 && BanCo.ViTri[Hang - i, Cot].Phe == 0)
                        isCanMove.Add(new ToaDo(Hang - i, Cot));
                    break;
                }
            }
            // kiem tra phia truoc
            for (int i = 1; Hang + i <= 9; i++)
            {
                if (BanCo.ViTri[Hang + i, Cot].Trong == true)
                    isCanMove.Add(new ToaDo(Hang + i, Cot));
                else
                {
                    if (BanCo.ViTri[Hang, Cot].Phe == 0 && BanCo.ViTri[Hang + i, Cot].Phe == 1)
                        isCanMove.Add(new ToaDo(Hang + i, Cot));
                    else if (BanCo.ViTri[Hang, Cot].Phe == 1 && BanCo.ViTri[Hang + i, Cot].Phe == 0)
                        isCanMove.Add(new ToaDo(Hang + i, Cot));
                    break;
                }
            }
            for (int i = 0; i < isCanMove.Count; i++)
                if (isCanMove[i].x == row && isCanMove[i].y == col)
                    return 1;
            return 0;
        }
    }
}
