using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LT_CSDL.GUI;
namespace LT_CSDL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            //Application.Run(new frmKhachHang());
            //Application.Run(new frmNhanVien());
            //Application.Run(new frmLoai());
            Application.Run(new frmSanPham());
        }
    }
}
