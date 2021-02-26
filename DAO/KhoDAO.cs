using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LT_CSDL.DTO;
using LT_CSDL.DAO;
namespace LT_CSDL.DAO
{
    class KhoDAO
    {
        public static DataTable ThongTinSanPham()
        {
            string s = "select MaSP, TenSP from SANPHAM";
            DataTable dt = KetNoiCSDL.ExcuteQuery(s);
            return dt;

        }
        public static DataTable ThongTinKho()
        {
            string s = "select k.MaSP, s.TenSP, SoLuongTonKho from KHO k inner join SANPHAM s on k.MaSP = s.MaSP";
            DataTable dt = KetNoiCSDL.ExcuteQuery(s);
            return dt;
        }
        public static void Luu(KhoDTO l)
        {
            string s = $"insert into KHO values ('{l.ma}', {l.soluong})"; ;
            KetNoiCSDL.ExcuteNonQuery(s);
        }
        public static void Sua(KhoDTO l)
        {
            string s = $"update KHO set SoLuongTonKho='{l.soluong}' where MaSP={l.ma}";
            KetNoiCSDL.ExcuteNonQuery(s);
        }
        public static void Xoa(KhoDTO l)
        {
            string s = $"delete from KHO where MaSP={l.ma}";
            KetNoiCSDL.ExcuteNonQuery(s);
        }
    }
}
