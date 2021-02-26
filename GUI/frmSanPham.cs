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
    public partial class frmSanPham : Form
    {
        public frmSanPham()
        {
            InitializeComponent();
        }

        private void frmSanPham_Load(object sender, EventArgs e)
        {
            Load_ComboBoxLoai();
            Load_DataGridView();
            txtma.Enabled = false;
        }
        private void Load_ComboBoxLoai()
        {
            DataTable dt = SanPhamDAO.ThongTinLoai();
            cboloai.DataSource = dt;
            cboloai.DisplayMember = "TenLoai";
            cboloai.ValueMember = "MaLoai";
        }
        private void Load_DataGridView()
        {
            DataTable dt = SanPhamDAO.ThongTinSanPham();
            gvdanhsach.DataSource = dt;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            XoaTrang();
            int ma = SanPhamDAO.MaLonNhat();
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
                SanPhamDTO sp = new SanPhamDTO()
                {
                    ten = txtten.Text,
                    loai = cboloai.SelectedValue.ToString(),
                    giatien = txtgiatien.Value.ToString()
                };
                SanPhamDAO.Luu(sp);
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
                SanPhamDTO nv = new SanPhamDTO()
                {
                    ma = txtma.Text,
                    ten = txtten.Text,
                    loai = cboloai.ValueMember.ToString(),
                    giatien = txtgiatien.Text
                };
                SanPhamDAO.Sua(nv);
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
                MessageBox.Show("Bạn chưa chọn sản phẩm cần xoá!");
                return;
            }
            if (MessageBox.Show("Bạn có thực sự muốn xoá ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;
            try
            {
                SanPhamDTO sp = new SanPhamDTO() { ma = txtma.Text };
                SanPhamDAO.Xoa(sp);
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
            string loai = row.Cells[2].Value.ToString();
            string giatien = row.Cells[3].Value.ToString();

            txtma.Text = ma;
            txtten.Text = ten;
            cboloai.Text = loai;
            txtgiatien.Text = giatien;
        }
        private bool KiemTra()
        {
            if (txtma.Text == "" || txtten.Text == "" || txtgiatien.Text == "")
            {
                return true;
            }
            return false;
        }
        private void XoaTrang()
        {
            txtma.Text = txtten.Text = txtgiatien.Text = "";
        }
    }
}
