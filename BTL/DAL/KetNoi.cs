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
    public class KetNoi
    {
        string connString = ConfigurationManager.ConnectionStrings["datacn"].ToString();
        protected SqlConnection conn = null;
        public void Open()
        {
            if (conn == null)
                conn = new SqlConnection(connString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public void Close()
        {
            if (conn.State == ConnectionState.Open && conn != null)
                conn.Close();
        }
    }
}
