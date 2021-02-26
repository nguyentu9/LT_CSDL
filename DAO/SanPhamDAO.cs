using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LT_CSDL.DTO;
namespace LT_CSDL.DAO
{
    class SanPhamDAO
    {
        public static DataTable ThongTinLoai()
        {
            string s = "select * from LOAI";
            DataTable dt = KetNoiCSDL.ExcuteQuery(s);
            return dt;
        }
        public static DataTable ThongTinSanPham()
        {
            string s = "select MaSP, TenSP, l.TenLoai, GiaTien from SANPHAM s inner join LOAI l on s.MaLoai = l.MaLoai";
            DataTable dt = KetNoiCSDL.ExcuteQuery(s);
            return dt;
        }
        public static int MaLonNhat()
        {
            string s = "select top 1 MaSP from SANPHAM order by MaSP desc";
            DataTable dt = KetNoiCSDL.ExcuteQuery(s);
            int ma = int.Parse(dt.Rows[0][0].ToString()) + 1;
            return ma;
        }
        public static void Luu(SanPhamDTO l)
        {
            string s = $"insert into SANPHAM values (N'{l.ten}', {l.loai}, {l.giatien})";
            KetNoiCSDL.ExcuteNonQuery(s);
        }
        public static void Sua(SanPhamDTO l)
        {
            string s = $"update SANPHAM set TenSP=N'{l.ten}', MaLoai={l.loai}, GiaTien={l.giatien} where MaSP={l.ma}";
            KetNoiCSDL.ExcuteNonQuery(s);
        }
        public static void Xoa(SanPhamDTO l)
        {
            string s = $"delete from SANPHAM where MaSP={l.ma}";
            KetNoiCSDL.ExcuteNonQuery(s);
        }
    }
}
