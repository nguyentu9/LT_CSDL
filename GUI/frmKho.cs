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
    public partial class frmKho : Form
    {
        public frmKho()
        {
            InitializeComponent();
        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            Load_DataGridView();
            Load_ComboBox();
        }
        public void Load_ComboBox()
        {
            DataTable dt = KhoDAO.ThongTinSanPham();
            cbosanpham.DataSource = dt;
            cbosanpham.DisplayMember = "TenSP";
            cbosanpham.ValueMember = "MaSP";
        }
        public void Load_DataGridView()
        {
            DataTable dt = KhoDAO.ThongTinKho();
            gvdanhsach.DataSource = dt;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            XoaTrang();
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
                KhoDTO loai = new KhoDTO() {
                    ma = cbosanpham.SelectedValue.ToString(),
                    soluong = txtSoLuong.Value.ToString()
                };
                KhoDAO.Luu(loai);
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
                KhoDTO loai = new KhoDTO()
                {
                    ma = cbosanpham.SelectedValue.ToString(),
                    soluong = txtSoLuong.Value.ToString()
                };
                KhoDAO.Sua(loai);
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
            if (cbosanpham.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn loại cần xoá!");
                return;
            }
            if (MessageBox.Show("Bạn có thực sự muốn xoá ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
            try
            {
                KhoDTO loai = new KhoDTO() { 
                    ma = cbosanpham.SelectedValue.ToString(),
                };
                KhoDAO.Xoa(loai);
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
            string ten = row.Cells[1].Value.ToString();
            string soluong = row.Cells[2].Value.ToString();


            cbosanpham.Text = ten;
            txtSoLuong.Text = soluong;
        }
        private bool KiemTra()
        {
            if (cbosanpham.Text == "" || txtSoLuong.Value <= 0)
            {
                return true;
            }
            return false;
        }
        private void XoaTrang()
        {
            txtSoLuong.Value = 0;
        }
    }
}
