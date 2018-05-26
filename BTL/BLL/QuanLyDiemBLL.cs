using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class QuanLyDiemBLL
    {
        QuanLyDiemDAL ql = new QuanLyDiemDAL();
        public List<Lop> dsLop()
        {
            return ql.dsLop();
        }
        public List<MonHoc> dsMon()
        {
            return ql.dsMon();
        }
        public List<HoSoHocSinh> dsHs()
        {
            return ql.dsHS();
        }
        public List<PhanCongGiangDay> dsPhanCong()
        {
            return ql.dsPhanCong();
        }

        public List<Diem> dsDiem()
        {
            return ql.dsdiem();
        }
        public bool ThemDiem1(string maHS, string maMon, string diem)
        {
            //TH1
            double gt = 0;
            if (diem == "")
            {
                return true;
            }
            else 
            {
                try
                {
                    gt = double.Parse(diem);  
                }
                catch (Exception ex)
                {
                    return false;
                }

                if (gt < 0 || gt > 10)
                    return false;
                else
                {
                    return ql.ThemDiem1(maHS,maMon,gt);
                }
            }
            
            //return "";
        }

        public bool ThemDiem2(string maHS, string maMon, string diem)
        {
            //TH1
            double gt = 0;
            if (diem == "")
            {
                return true;
            }
            else
            {
                try
                {
                    gt = double.Parse(diem);
                }
                catch (Exception ex)
                {
                    return false;
                }

                if (gt < 0 || gt > 10)
                    return false;
                else
                {
                    return ql.ThemDiem2(maHS, maMon, gt);
                }
            }

            //return "";
        }

        //Sua diem

        public bool Suadiem1(string maHS, string maMon, string diem)
        {
            //TH1
            double gt = 0,gt1 = 0;
            if (diem == "v")
            {
                gt1=-1;
                return ql.Suadiem2(maHS, maMon, gt1);
            }
            else
            {
                try
                {
                    gt = double.Parse(diem);
                }
                catch (Exception ex)
                {
                    return false;
                }

                if (gt < 0 || gt > 10)
                    return false;
                else
                {
                    return ql.Suadiem1(maHS, maMon, gt);
                }
            }

            //return "";
        }
        //diem 22

        public bool Suadiem2(string maHS, string maMon, string diem)
        {
            //TH1
            double gt = 0, gt1 = 0;
            if (diem == "v")
            {
                gt1 = -1;
                return ql.Suadiem2(maHS, maMon, gt1);
            }
            else
            {
                try
                {
                    gt = double.Parse(diem);
                }
                catch (Exception ex)
                {
                    return false;
                }

                if (gt < 0 || gt > 10)
                    return false;
                else
                {
                    return ql.Suadiem2(maHS, maMon, gt);
                }
            }

            //return "";
        }
    }
}
