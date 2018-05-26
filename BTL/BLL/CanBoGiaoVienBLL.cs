using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
   public class CanBoGiaoVienBLL
    {
        canBo cb = new canBo();
        public List<CanBoGiaoVien> dscb()
        {
            return cb.dsCanBO();
        }
    }
}
