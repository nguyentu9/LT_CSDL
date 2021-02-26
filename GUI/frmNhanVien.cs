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
using LT_CSDL.DTO;
namespace LT_CSDL.GUI
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            Load_DataGridView();
            txtma.Enabled = false;
        }
        public void Load_DataGridView() 
        {
            DataTable dt = NhanVienDAO.ThongTinNhanVien();
            gvdanhsach.DataSource = dt;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            XoaTrang();
            int ma = NhanVienDAO.MaLonNhat();
            txtma.Text = ma.ToString();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                MessageBox.Show("Thông tin không được rỗng");
                return;
            }
            try
            {
                NhanVienDTO nv = new NhanVienDTO()
                {
                    ten = txtten.Text,
                    diachi = txtdiachi.Text,
                    sdt = txtsdt.Text
                };
                NhanVienDAO.Luu(nv);
                Load_DataGridView();
                XoaTrang();
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                MessageBox.Show("Thông tin không được rỗng");
                return;
            }
            try
            {
                NhanVienDTO nv = new NhanVienDTO()
                {
                    ma = txtma.Text,
                    ten = txtten.Text,
                    diachi = txtdiachi.Text,
                    sdt = txtsdt.Text
                };
                NhanVienDAO.Sua(nv);
                Load_DataGridView();
                XoaTrang();
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txtma.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn khách hàng cần xoá!");
                return;
            }
            if (MessageBox.Show("Bạn có thực sự muốn xoá ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
            try
            {
                NhanVienDTO nv = new NhanVienDTO() { ma = txtma.Text };
                NhanVienDAO.Xoa(nv);
                Load_DataGridView();
                XoaTrang();
            }
            catch (Exception)
            {
                MessageBox.Show("Xoá thất bại");
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvdanhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            DataGridViewRow row = gvdanhsach.Rows[e.RowIndex];
            string ma = row.Cells[0].Value.ToString();
            string ten = row.Cells[1].Value.ToString();
            string diachi = row.Cells[2].Value.ToString();
            string sdt = row.Cells[3].Value.ToString();

            txtma.Text = ma;
            txtten.Text = ten;
            txtdiachi.Text = diachi;
            txtsdt.Text = sdt;
        }
        private bool KiemTra()
        {
            if (txtma.Text == "" || txtten.Text == "" || txtdiachi.Text == "" || txtsdt.Text == "")
            {
                return true;
            }
            return false;
        }
        private void XoaTrang()
        {
            txtma.Text = txtten.Text = txtdiachi.Text = txtsdt.Text = "";
        }
    }
}
