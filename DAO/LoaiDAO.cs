using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LT_CSDL.DTO;
namespace LT_CSDL.DAO
{
    class LoaiDAO
    {
        public static DataTable ThongTinLoai()
        {
            string s = "select * from LOAI";
            DataTable dt = new DataTable();
            dt = KetNoiCSDL.ExcuteQuery(s);
            return dt;
        }
        public static int MaLonNhat()
        {
            string s = "select top 1 MaLoai from LOAI order by MaLoai desc";
            DataTable dt = KetNoiCSDL.ExcuteQuery(s);
            int ma = int.Parse(dt.Rows[0][0].ToString()) + 1;
            return ma;
        }
        public static void Luu(LoaiDTO l)
        {
            string s = $"insert into LOAI values ('{l.ten}')"; ;
            KetNoiCSDL.ExcuteNonQuery(s);
        }
        public static void Sua(LoaiDTO l)
        {
            string s = $"update LOAI set TenLoai=N'{l.ten}' where MaLoai={l.ma}";
            KetNoiCSDL.ExcuteNonQuery(s);
        }
        public static void Xoa(LoaiDTO l)
        {
            string s = $"delete from LOAI where MaLoai={l.ma}";
            KetNoiCSDL.ExcuteNonQuery(s);
        }
    }
}
