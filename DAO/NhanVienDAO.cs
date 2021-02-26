using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using LT_CSDL.DTO;
namespace LT_CSDL.DAO
{
    class NhanVienDAO
    {
        public static DataTable ThongTinNhanVien()
        {
            string s = "select * from NHANVIEN";
            DataTable dt = new DataTable();
            dt = KetNoiCSDL.ExcuteQuery(s);
            return dt;
        }
        public static int MaLonNhat()
        {
            string s = "select top 1 MaNV from NHANVIEN order by MaNV desc";
            DataTable dt = KetNoiCSDL.ExcuteQuery(s);
            int ma = int.Parse(dt.Rows[0][0].ToString()) + 1;
            return ma;
        }
        public static void Luu(NhanVienDTO kh)
        {
            string s = $"insert into NHANVIEN (TenNV, DiaChi, SDT) values ('{kh.ten}', '{kh.diachi}', '{kh.sdt}')"; ;
            KetNoiCSDL.ExcuteNonQuery(s);
        }
        public static void Sua(NhanVienDTO kh)
        {
            string s = $"update NHANVIEN set TenNV=N'{kh.ten}', DiaChi=N'{kh.diachi}', SDT='{kh.sdt}' where MaNV={kh.ma}";
            KetNoiCSDL.ExcuteNonQuery(s);
        }
        public static void Xoa(NhanVienDTO kh)
        {
            string s = $"delete from NHANVIEN where MaNV={kh.ma}";
            KetNoiCSDL.ExcuteNonQuery(s);
        }
    }
}
