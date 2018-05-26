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
  public  class canBo:KetNoi
    {
        public List<CanBoGiaoVien> dsCanBO()
        {
            List<CanBoGiaoVien> ds = new List<CanBoGiaoVien>();
            Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from CanBoGiaoVien";
            cmd.Connection = conn;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                CanBoGiaoVien a = new CanBoGiaoVien();
                a.MaCanBo = reader.GetString(0);
                a.HoTen = reader.GetString(1);
                a.DiaChi = reader.GetString(2);
                a.Sdt = reader.GetString(3);
                a.Taikhoan = reader.GetString(4);
                a.MatKHau = reader.GetString(5);
                a.LoaiTaiKhoan = reader.GetString(6);
                ds.Add(a);
            }
            Close();
            conn.Close();
            return ds;
        }
    }
}
