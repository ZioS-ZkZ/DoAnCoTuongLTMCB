using System;
using System.Collections.Generic;
using System.Text;

namespace CoTuong
{
    class NguoiChoi
    {
        public int Phe;
        public QuanCo.xe[] qXe = new QuanCo.xe[2];
        public QuanCo.ma[] qMa = new QuanCo.ma[2];
        public QuanCo.voi[] qVoi = new QuanCo.voi[2];
        public QuanCo.si[] qSi = new QuanCo.si[2];
        public QuanCo.tuong qTuong = new QuanCo.tuong();
        public QuanCo.phao[] qPhao = new QuanCo.phao[2];
        public QuanCo.tot[] qTot = new QuanCo.tot[5];

        public NguoiChoi(int x)// khoi tao quan co cho ng choi
        {
            if (x == 0)
            {
                Phe = 0;
                for(int i =0; i<2; i++)
                {
                    qXe[i] = new QuanCo.xe();
                    qMa[i] = new QuanCo.ma();
                    qVoi[i] = new QuanCo.voi();
                    qSi[i] = new QuanCo.si();
                    qPhao[i] = new QuanCo.phao();
                }
                for(int i =0; i< 5; i++)
                    qTot[i] = new QuanCo.tot();
                
                qXe[0].khoiTao(0, 0, "xe", 0, "trai", 1, false);
                qXe[1].khoiTao(0, 8, "xe", 0, "phai", 1, false);
                qMa[0].khoiTao(0, 1, "ma", 0, "trai", 1, false);
                qMa[1].khoiTao(0, 7, "ma", 0, "phai", 1, false);
                qVoi[0].khoiTao(0, 2, "voi", 0, "trai", 1, false);
                qVoi[1].khoiTao(0, 6, "voi", 0, "phai", 1, false);
                qSi[0].khoiTao(0, 3, "si", 0, "trai", 1, false);
                qSi[1].khoiTao(0, 5, "si", 0, "phai", 1, false);
                qPhao[0].khoiTao(2, 1, "phao", 0, "trai", 1, false);
                qPhao[1].khoiTao(2, 7, "phao", 0, "phai", 1, false);
                qTuong.khoiTao(0, 4, "tuong", 0, "trai", 1, false);
                qTot[0].khoiTao(3, 0, "tot", 0, "1", 1, false);
                qTot[1].khoiTao(3, 2, "tot", 0, "2", 1, false);
                qTot[2].khoiTao(3, 4, "tot", 0, "3", 1, false);
                qTot[3].khoiTao(3, 6, "tot", 0, "4", 1, false);
                qTot[4].khoiTao(3, 8, "tot", 0, "5", 1, false);
               
            }
            else
            {
                Phe = 1;
                for (int i = 0; i < 2; i++)
                {
                    qXe[i] = new QuanCo.xe();
                    qMa[i] = new QuanCo.ma();
                    qVoi[i] = new QuanCo.voi();
                    qSi[i] = new QuanCo.si();
                    qPhao[i] = new QuanCo.phao();
                }
                for (int i = 0; i < 5; i++)
                    qTot[i] = new QuanCo.tot();

                qXe[0].khoiTao(9, 0, "xe", 1, "trai", 1, false);
                qXe[1].khoiTao(9, 8, "xe", 1, "phai", 1, false);
                qMa[0].khoiTao(9, 1, "ma", 1, "trai", 1, false);
                qMa[1].khoiTao(9, 7, "ma", 1, "phai", 1, false);
                qVoi[0].khoiTao(9, 2, "voi", 1, "trai", 1, false);
                qVoi[1].khoiTao(9, 6, "voi", 1, "phai", 1, false);
                qSi[0].khoiTao(9, 3, "si", 1, "trai", 1, false);
                qSi[1].khoiTao(9, 5, "si", 1, "phai", 1, false);
                qPhao[0].khoiTao(7, 1, "phao", 1, "trai", 1, false);
                qPhao[1].khoiTao(7, 7, "phao", 1, "phai", 1, false);
                qTuong.khoiTao(9, 4, "tuong", 1, "trai", 1, false);
                qTot[0].khoiTao(6, 8, "tot", 1, "1", 1, false);
                qTot[1].khoiTao(6, 6, "tot", 1, "2", 1, false);
                qTot[2].khoiTao(6, 4, "tot", 1, "3", 1, false);
                qTot[3].khoiTao(6, 2, "tot", 1, "4", 1, false);
                qTot[4].khoiTao(6, 0, "tot", 1, "5", 1, false);

            }
        }
    }
}
