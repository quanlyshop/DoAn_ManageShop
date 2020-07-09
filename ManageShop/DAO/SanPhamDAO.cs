using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SanPhamDAO
    {
        private static SanPhamDAO instance1;
        public static SanPhamDAO Instance
        {
            get { if (instance1 == null) instance1 = new SanPhamDAO(); return instance1; }
            private set { instance1 = value; }
        }
        private SanPhamDAO() { }
        public DataTable GetListSanPham()
        {
            return DataProvider.Instance.ExecuteQuery("Select * form NhanVien");
        }
        public bool InsertSanPham(string tenSP, string soLuong, string donGiaGoc, string donGiaBan, string size, string nhaSX, string ngaySX)
        {
            string query = string.Format("insert into SanPham values(N'{0}','{1}','{2}','{3}','{4}',N'{5}','{6}')", tenSP, soLuong, donGiaGoc, donGiaBan, size, nhaSX, ngaySX);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateSanPham(string tenSP, string soLuong, string donGiaGoc, string donGiaBan, string size, string nhaSX, string ngaySX, string maSP)
        {
            string query = string.Format("update SanPham set TenSP=N'{0}',SoLuong='{1}',DonGiaGoc='{2}',DonGiaBan='{3}',Size=N'{4}',NhaSX=N'{5}',NgaySX='{6}' where MaSP='{7}'", tenSP, soLuong, donGiaGoc, donGiaBan, size, nhaSX, ngaySX, maSP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteSanPham(string MaSP)
        {
            string query = string.Format("delete SanPham where MaSP='{0}'", MaSP);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DataTable GetSanPham(string ten)
        {
            try
            {
                string query = string.Format("Search_SanPham " + ten);
                return DataProvider.Instance.ExecuteQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
