using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace LT_CSDL.DAO
{
    class KetNoiCSDL
    {
        private static SqlConnection conn = null;
        public static void MoKetNoi()
        {
            try { 
            if(conn == null)
            {
                string sql = "Data Source=DESKTOP-P8MOIJI;Initial Catalog=QLTV;Integrated Security=True";
                conn = new SqlConnection(sql);
            }
            if (conn.State == ConnectionState.Closed) conn.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể kết nối CSDL");
            }
        }
        public static void DongKetNoi()
        {
            if(conn.State == ConnectionState.Open) conn.Close();
        }
        public static DataTable ExcuteQuery(string s)
        {
            MoKetNoi();
            SqlCommand cd = new SqlCommand(s, conn);
            SqlDataReader dr = cd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DongKetNoi();
            return dt;
        }
        public static void ExcuteNonQuery(string s)
        {
            MoKetNoi();
            SqlCommand cd = new SqlCommand(s, conn);
            cd.ExecuteNonQuery();
            DongKetNoi();
        }
    }
}
