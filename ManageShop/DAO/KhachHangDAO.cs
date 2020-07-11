using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KhachHangDAO
    {
        private static KhachHangDAO instance;
        public static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return instance; }
            private set { instance = value; }
        }
        private KhachHangDAO() { }
        public DataTable GetListKhachHang()
        {
            return DataProvider.Instance.ExecuteQuery("select * form KhachHang");
        }
        public bool InsertKhachHang(string tenkh, string sdt, string gioitinh, string diachi, string sodiem, string namsinh, string email)
        {
            string query = string.Format("insert into KhachHang values(N'{0}','{1}',N'{2}',N'{3}','{4}','{5}',N'{6}')", tenkh, sdt, gioitinh, diachi, sodiem, namsinh, email);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateKhachHang(string tenkh, string sdt, string gioitinh, string diachi, string sodiem, string namsinh, string email, string makh)
        {
            string query = string.Format("update KhachHang set TenKH=N'{0}',SDT='{1}',GioiTinh=N'{2}',DiaChi=N'{3}',SoDiem='{4}',NamSinh='{5}',Email='{6}' where MaKH='{7}'", tenkh, sdt, gioitinh, diachi, sodiem, namsinh, email, makh);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteKhachHang(string makh)
        {
            string query = string.Format("delete KhachHang where MaKH='{0}'", makh);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DataTable GetKhachHang(string ten)
        {
            try
            {
                string query = string.Format("SearchKhachHang " + ten);
                return DataProvider.Instance.ExecuteQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
