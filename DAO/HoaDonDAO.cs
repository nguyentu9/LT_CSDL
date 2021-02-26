using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
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

            string s = $"insert into HOADON values({hoadon.makh}, {hoadon.manv},'{hoadon.ngaylap}')";
          
            KetNoiCSDL.ExcuteNonQuery(s);
            KetNoiCSDL.ExcuteNonQuery(sqlChiTietHoaDon);
        }
        public static void Sua(KhachHangDTO kh)
        {
            string s = $"update KHACHHANG set TenKH=N'{kh.ten}', DiaChi=N'{kh.diachi}', SDT='{kh.sdt}' where MaKH={kh.ma}";
            KetNoiCSDL.ExcuteNonQuery(s);
        }
        public static void Xoa(KhachHangDTO kh)
        {
            string s = $"delete from KHACHHANG where MaKH={kh.ma}";
            KetNoiCSDL.ExcuteNonQuery(s);
        }
    }
}
