using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using LT_CSDL.DTO;
namespace LT_CSDL.DAO
{
    class KhachHangDAO
    {
        public static DataTable ThongTinKhachHang()
        {
            string s = "select * from KHACHHANG";
            DataTable dt = new DataTable();
            dt = KetNoiCSDL.ExcuteQuery(s);
            return dt;
        }
        public static int MaLonNhat()
        {
            string s = "select top 1 MaKH from KHACHHANG order by MaKH desc";
            DataTable dt = KetNoiCSDL.ExcuteQuery(s);
            int ma = int.Parse(dt.Rows[0][0].ToString()) + 1;
            return ma;
        }
        public static void Luu(KhachHangDTO kh)
        {
            string s = $"insert into KHACHHANG (TenKH, DiaChi, SDT) values ('{kh.ten}', '{kh.diachi}', '{kh.sdt}')"; ;
            KetNoiCSDL.ExcuteNonQuery(s);
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
