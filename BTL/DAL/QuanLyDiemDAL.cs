using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using System.Configuration;
namespace DAL
{
   public class QuanLyDiemDAL:KetNoi
    {
        public List<Lop> dsLop()
        {
            List<Lop> ds = new List<Lop>();
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Lop";
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Lop a = new Lop();
                a.MaLop = reader.GetString(0);
                a.TenLop = reader.GetString(1);
                a.NienKhoa = reader.GetString(2);
                a.SiSo = reader.GetInt32(3);
                a.GiaoVienChuNHiem = reader.GetString(4);
                ds.Add(a);
            }
            Close();
            conn.Close();
            return ds;
        }
        public List<MonHoc> dsMon()
        {
            List<MonHoc> ds = new List<MonHoc>();
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from MonHoc";
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                MonHoc a = new MonHoc();
                a.MaMon = reader.GetString(0);
                a.TenMon = reader.GetString(1);
                //a.NienKhoa = reader.GetString(2);
                a.SoTiet = reader.GetInt32(2);
               // a.GiaoVienChuNHiem = reader.GetString(4);
                ds.Add(a);
            }
            Close();
            conn.Close();
            return ds;
        }
        //ds hoc sinh
        public List<HoSoHocSinh> dsHS()
        {
            List<HoSoHocSinh> ds = new List<HoSoHocSinh>();
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from HoSoHocSinh";
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                HoSoHocSinh a = new HoSoHocSinh();
                a.MaHocSinh = reader.GetString(0);
                a.HoTen = reader.GetString(1);
                a.NgaySinh = reader.GetDateTime(2);
                a.GioiTinh = reader.GetString(3);
                a.DiaChi = reader.GetString(4);
                a.DiemVAotruong = reader.GetDouble(5);
                a.HoTenBoMe = reader.GetString(6);
                a.sdt = reader.GetString(7);
                //a.NienKhoa = reader.GetString(2);
                a.MaLop = reader.GetString(8);
                // a.GiaoVienChuNHiem = reader.GetString(4);
                ds.Add(a);
            }
            Close();
            conn.Close();
            return ds;
        }

        //danh sach phan cong

        public List<PhanCongGiangDay> dsPhanCong()
        {
            List<PhanCongGiangDay> ds = new List<PhanCongGiangDay>();
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from PhanCongGiangDay";
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                PhanCongGiangDay a = new PhanCongGiangDay();
                a.MaLop = reader.GetString(0);
                a.MaMon = reader.GetString(1);
                a.MaCanBoGV = reader.GetString(2);
                a.NgayPhanCong = reader.GetDateTime(3);
               
                ds.Add(a);
            }
            Close();
            conn.Close();
            return ds;
        }
        public List<Diem> dsdiem()
        {
            List<Diem> ds = new List<Diem>();
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Diem";
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Diem a = new Diem();
                a.MaHocSinh = reader.GetString(0);
                a.MaMonHoc = reader.GetString(1);
               // if (reader.GetDouble(2) == null)
                    try
                    {
                        a.DiemKy1 = reader.GetDouble(2);
                       // a.DiemKy2 = reader.GetDouble(3);
                    }
                    catch (Exception ex)
                    {
                    a.DiemKy1 = -1;
                    }
                try
                {
                    a.DiemKy2 = reader.GetDouble(3);
                    // a.DiemKy2 = reader.GetDouble(3);
                }
                catch (Exception ex)
                {
                    a.DiemKy2 = -1;
                }
                ds.Add(a);
            }
            Close();
            conn.Close();
            return ds;
        }
        public bool ThemDiem1(string maHS,string maMon,double diem)
        {
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Diem set DiemTB_Ky1=@diem where MaHocSinh=@mahs and MaMonHoc=@mamon ";
            cmd.Connection = conn;
            cmd.Parameters.Add("@diem", SqlDbType.Float).Value = diem;
            cmd.Parameters.Add("@mahs", SqlDbType.NVarChar).Value = maHS;
            cmd.Parameters.Add("@mamon", SqlDbType.NVarChar).Value = maMon;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Close();
                return false;
            }
            Close();
            return true;
        }
        //diem 2

        public bool ThemDiem2(string maHS, string maMon, double diem)
        {
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Diem set DiemTB_Ky2=@diem where MaHocSinh=@mahs and MaMonHoc=@mamon ";
            cmd.Connection = conn;
            cmd.Parameters.Add("@diem", SqlDbType.Float).Value = diem;
            cmd.Parameters.Add("@mahs", SqlDbType.NVarChar).Value = maHS;
            cmd.Parameters.Add("@mamon", SqlDbType.NVarChar).Value = maMon;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Close();
                return false;
            }
            Close();
            return true;
        }
        //sua diem 1

        public bool Suadiem1(string maHS, string maMon, double diem)
        {
            Open();
            //object t = null;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            if (diem == -1)
            {
                cmd.CommandText = "update Diem set DiemTB_Ky1=NULL where MaHocSinh=@mahs and MaMonHoc=@mamon ";
                cmd.Connection = conn;
               // cmd.Parameters.Add("@t", SqlDbType.Float).Value = t;
              //  cmd.Parameters.Add("@diem", SqlDbType.Float).Value = diem;
                cmd.Parameters.Add("@mahs", SqlDbType.NVarChar).Value = maHS;
                cmd.Parameters.Add("@mamon", SqlDbType.NVarChar).Value = maMon;
            }
            else
            {
                cmd.CommandText = "update Diem set DiemTB_Ky1=@diem where MaHocSinh=@mahs and MaMonHoc=@mamon ";
                cmd.Connection = conn;
               // cmd.Parameters.Add("@t", SqlDbType.Float).Value = t;
                cmd.Parameters.Add("@diem", SqlDbType.Float).Value = diem;
                cmd.Parameters.Add("@mahs", SqlDbType.NVarChar).Value = maHS;
                cmd.Parameters.Add("@mamon", SqlDbType.NVarChar).Value = maMon;

            }
            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Close();
                return false;
            }
            Close();
            return true;
        }

        //sua diem 2

        public bool Suadiem2(string maHS, string maMon, double diem)
        {
            Open();
            //object t = null;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            if (diem == -1)
            {
                cmd.CommandText = "update Diem set DiemTB_Ky1=NULL where MaHocSinh=@mahs and MaMonHoc=@mamon ";
                cmd.Connection = conn;
                //cmd.Parameters.Add("@t",null).Value = t;
                //  cmd.Parameters.Add("@diem", SqlDbType.Float).Value = diem;
                cmd.Parameters.Add("@mahs", SqlDbType.NVarChar).Value = maHS;
                cmd.Parameters.Add("@mamon", SqlDbType.NVarChar).Value = maMon;
            }
            else
            {
                cmd.CommandText = "update Diem set DiemTB_Ky2=@diem where MaHocSinh=@mahs and MaMonHoc=@mamon ";
                cmd.Connection = conn;
                // cmd.Parameters.Add("@t", SqlDbType.Float).Value = t;
                cmd.Parameters.Add("@diem", SqlDbType.Float).Value = diem;
                cmd.Parameters.Add("@mahs", SqlDbType.NVarChar).Value = maHS;
                cmd.Parameters.Add("@mamon", SqlDbType.NVarChar).Value = maMon;

            }

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Close();
                return false;
            }
            Close();
            return true;
        }
    }
}
