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
    public partial class frmHoaDon : Form
    {
        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            txtma.Enabled = false; // mã hoá đơn
            txtMaKhachHang.Enabled = false;
            txtMaNhanVien.Enabled = false;
            Load_ComboKhachHang();
            Load_ComboNhanVien();
            Load_ListboxSanPham();
            Load_TreeView(tvdanhsach);
        }
        private void Load_ComboKhachHang()
        {
            DataTable dt = KhachHangDAO.ThongTinKhachHang();
            cboKhachHang.DataSource = dt;
            cboKhachHang.DisplayMember = "TenKH";
            cboKhachHang.ValueMember = "MaKH";
        }
        private void Load_ComboNhanVien()
        {
            DataTable dt = NhanVienDAO.ThongTinNhanVien();
            cboNhanVien.DataSource = dt;
            cboNhanVien.DisplayMember = "TenNV";
            cboNhanVien.ValueMember = "MaNV";
        }
        private void Load_ListboxSanPham()
        {
            DataTable dt = SanPhamDAO.ThongTinSanPham();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lvsp.Items.Add(dt.Rows[i]["MaSP"].ToString());
                lvsp.Items[i].SubItems.Add(dt.Rows[i]["TenSP"].ToString());
            }
        }
        private void Load_TreeView(TreeView tree)
        {
            tree.Nodes.Clear();
            TreeNode nodeCha = new TreeNode();
            DataTable dtHoaDon = HoaDonDAO.Load_TreeView();
            for (int i = 0; i < dtHoaDon.Rows.Count; i++)
            {
                string maHoaDon = dtHoaDon.Rows[i]["MaHD"].ToString();
                string tenKhachHang = dtHoaDon.Rows[i]["TenKH"].ToString();
                nodeCha = tree.Nodes.Add("[HD] - " + maHoaDon + " - " + tenKhachHang);
                nodeCha.Tag = maHoaDon;
            }
        }
        private void Load_ThongTinHoaDon(string maHoaDon)
        {
            DataTable dt = HoaDonDAO.ThongTinHoaDon(maHoaDon);
            txtma.Text = dt.Rows[0]["MaHD"].ToString();
            cboKhachHang.Text = dt.Rows[0]["TenKH"].ToString();
            cboNhanVien.Text = dt.Rows[0]["TenNV"].ToString();
            dtpthoigian.Text = dt.Rows[0]["NgayLap"].ToString();
        }
        private void Load_ThongTinSanPham(string maHoaDon)
        {
            lvspdachon.Items.Clear();
            DataTable dt = HoaDonDAO.ThongTinChiTiet(maHoaDon);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lvspdachon.Items.Add(dt.Rows[i]["MaSP"].ToString());
                lvspdachon.Items[i].SubItems.Add(dt.Rows[i]["TenSP"].ToString());
                lvspdachon.Items[i].SubItems.Add(dt.Rows[i]["SoLuong"].ToString());
            }
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            XoaTrang();
            txtma.Text = HoaDonDAO.MaLonNhat().ToString();
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if(lvspdachon.Items.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm để lưu!", "Thông báo");
                return;
            }
            HoaDonDTO hoadon = new HoaDonDTO()
            {
                mahd = txtma.Text,
                makh = txtMaKhachHang.Text,
                manv = txtMaNhanVien.Text,
                ngaylap = string.Format("{0:MM/dd/yyyy}", dtpthoigian.Value)
            };
            string sqlChiTietHoaDon = "insert into CTHD values";
            for (int i = 0; i < lvspdachon.Items.Count; i++)
            {
                string maSanPham = lvspdachon.Items[i].SubItems[0].Text;
                string soluong = lvspdachon.Items[i].SubItems[2].Text;
                sqlChiTietHoaDon += $"({txtma.Text}, {maSanPham}, {soluong}),";
            }
            sqlChiTietHoaDon = sqlChiTietHoaDon.Remove(sqlChiTietHoaDon.Length - 1);
            HoaDonDAO.Luu(hoadon, sqlChiTietHoaDon);
            XoaTrang();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedIndex > 0)
            {
                txtMaKhachHang.Text = cboKhachHang.SelectedValue.ToString();
            }
            else txtMaKhachHang.Text = "1";
        }

        private void cboNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhachHang.SelectedIndex > 0)
            {
                txtMaNhanVien.Text = cboNhanVien.SelectedValue.ToString();
            }
            else txtMaNhanVien.Text = "1";
        }

        private void tvdanhsach_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvdanhsach.SelectedNode.Parent != null) return;
            string maHD = tvdanhsach.SelectedNode.Tag.ToString();
            Load_ThongTinHoaDon(maHD);
            Load_ThongTinSanPham(maHD);
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {

            if (lvsp.SelectedItems.Count > 0)
            {
                bool chuaco = true;
                for (int i = 0; i < lvspdachon.Items.Count; i++)
                {
                    string maSP = lvsp.SelectedItems[0].SubItems[0].Text;
                    if (maSP == lvspdachon.Items[i].SubItems[0].Text)
                    {
                        int soluong = int.Parse(lvspdachon.Items[i].SubItems[2].Text) + 1;
                        lvspdachon.Items[i].SubItems[2].Text = soluong.ToString();
                        chuaco = false;
                        break;
                    }
                }
                if (chuaco)
                {
                    ListViewItem item = new ListViewItem(lvsp.SelectedItems[0].SubItems[0].Text);
                    item.SubItems.Add(lvsp.SelectedItems[0].SubItems[1].Text);
                    item.SubItems.Add("1");
                    lvspdachon.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm cần thêm", "Thông báo");
            }
        }

        private void btnGiamSanPham_Click(object sender, EventArgs e)
        {
            if (lvspdachon.SelectedItems.Count > 0 
                && int.Parse(lvspdachon.SelectedItems[0].SubItems[2].Text) > 1)
            {
                int soluong = int.Parse(lvspdachon.SelectedItems[0].SubItems[2].Text) - 1;
                lvspdachon.SelectedItems[0].SubItems[2].Text = soluong.ToString();
            }
            else if (lvspdachon.SelectedItems.Count > 0 
                && int.Parse(lvspdachon.SelectedItems[0].SubItems[2].Text) == 1)
            {
                lvspdachon.Items.RemoveAt(lvspdachon.SelectedIndices[0]);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm cần xoá", "Thông báo");
            }
        }
        private void XoaTrang()
        {
            txtma.Text = "";
            cboKhachHang.SelectedIndex = 0;
            cboNhanVien.SelectedIndex = 0;
            lvspdachon.Items.Clear();
            Load_TreeView(tvdanhsach);
        }
    }
}
