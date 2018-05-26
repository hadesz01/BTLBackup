using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
namespace WindowsFormsApp15
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           DialogResult r= MessageBox.Show("ban thuc su muốn thoát ??", "???", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (r == DialogResult.Yes)

            {
                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    //if (Application.OpenForms[i].Name != "Menu")
                    Application.OpenForms[i].Close();
                }
            }
            else
                return;
        }
        List<string> tk = new List<string>();
        List<string> mk = new List<string>();
        private bool chk()
        {
            CanBoGiaoVienBLL cb = new CanBoGiaoVienBLL();
            foreach (CanBoGiaoVien item in cb.dscb())
            {
                string TK = item.Taikhoan;
                string MK = item.MatKHau;
                tk.Add(TK);
                mk.Add(MK);
            }
           for(int i=0;i<tk.Count;i++)
            {
                if (tk[i] == txtuser.Text && mk[i] == txtpass.Text)
                
                    return true;
                    
                
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Close();
            if (chk())
            {
                FormMain frm = new FormMain();

                if (txtpass.Text == "admin" && txtuser.Text == "admin")
                {
                    frm.ad = true;
                }

                else
                {
                    frm.gv = true;
                   
                }
                frm.TenUsers = txtuser.Text;
                frm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("sai tai khoan or mat khau ", "");
        }
    }
}
