using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LT_CSDL.DAO;
using LT_CSDL.GUI;
namespace LT_CSDL
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            try
            {
                string taikhoan = txttaikhoan.Text;
                string matkhau = txtmatkhau.Text;
                if (taikhoan == "" || matkhau == "")
                {
                    MessageBox.Show("Tài khoản và mật khẩu không dược trống");
                    return;
                }
                DataTable dt = DangNhapDAO.DangNhap(txttaikhoan.Text);

                if(dt.Rows[0]["TenDangNhap"].ToString() == taikhoan && 
                    dt.Rows[0]["MatKhau"].ToString() == matkhau)
                {
                    frmMenu f = new frmMenu();
                    f.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai");
            }
        }
    }
}
