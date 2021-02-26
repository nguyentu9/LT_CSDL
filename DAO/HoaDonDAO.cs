using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using LT_CSDL.DTO;
namespace LT_CSDL.DAO
{
    class HoaDonDAO
    {
        public static DataTable Load_TreeView()
        {
            string s = "select MaHD, k.TenKH from HOADON h inner join KHACHHANG k on k.MaKH = h.MaKH";
            DataTable dt = KetNoiCSDL.ExcuteQuery(s);
            return dt;
        }
        public static DataTable ThongTinHoaDon(string maHD)
        {
            string s = $"select MaHD, k.TenKH, n.TenNV, NgayLap from HOADON d inner join KHACHHANG k on d.MaKH = k.MaKH inner join NHANVIEN n on n.MaNV = d.MaNV where MaHD={maHD}";
            DataTable dt = KetNoiCSDL.ExcuteQuery(s);
            return dt;
        }
        public static DataTable ThongTinChiTiet(string maHD)
        {
            string s = $"select s.MaSP, s.TenSP, SoLuong from CTHD c inner join SANPHAM s on c.MaSP = s.MaSP where MaHD={maHD}";
            DataTable dt = KetNoiCSDL.ExcuteQuery(s);
            return dt;
        }
        public static int MaLonNhat()
        {
            string s = "select top 1 MaHD from HOADON order by MaHD desc";
            DataTable dt = KetNoiCSDL.ExcuteQuery(s);
            int ma = int.Parse(dt.Rows[0][0].ToString()) + 1;
            return ma;
        }
        public static void Luu(HoaDonDTO hoadon, string sqlChiTietHoaDon)
        {
            try
            {
                string s = $"insert into HOADON values({hoadon.makh}, {hoadon.manv},'{hoadon.ngaylap}')";
                KetNoiCSDL.ExcuteNonQuery(s);
                KetNoiCSDL.ExcuteNonQuery(sqlChiTietHoaDon);
            }
            catch (Exception)
            {
                MessageBox.Show("Lưu thất bại");
            }
        }
        public static void Sua(HoaDonDTO hoadon, string sqlChiTietHoaDon)
        {
            string s = $"update HOADON set MaKH={hoadon.makh}, MaNV={hoadon.manv}, NgayLap='{hoadon.ngaylap}' where MaHD={hoadon.mahd}";
            KetNoiCSDL.ExcuteNonQuery(s);
            KetNoiCSDL.ExcuteNonQuery(sqlChiTietHoaDon);
        }
        public static void Xoa(HoaDonDTO hoadon)
        {
            string s = $"delete from HOADON where MaHD={hoadon.mahd}";
            KetNoiCSDL.ExcuteNonQuery(s);
        }
        public static void XoaCTHD(HoaDonDTO hoadon)
        {
            string sqlCTHD = $"delete from CTHD where MaHD={hoadon.mahd}";
            KetNoiCSDL.ExcuteNonQuery(sqlCTHD);
        }
    }
}
