using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance1;
        public static HoaDonDAO Instance
        {
            get { if (instance1 == null) instance1 = new HoaDonDAO(); return instance1; }
            private set { instance1 = value; }
        }
        private HoaDonDAO() { }
        public DataTable GetListHoaDon()
        {
            return DataProvider.Instance.ExecuteQuery("Select * form HoaDon");
        }
        public bool InsertHoaDon(string maNV, string maKH, string ngayBan, float tongTien, string tenSP, float soLuong, float donGia)
        {
            string query = string.Format("insert into HoaDon values('{0}','{1}','{2}','{3}',N'{4}','{5}','{6}')", maNV, maKH, ngayBan, tongTien, tenSP, soLuong, donGia);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateHoaDon(string maNV, string maKH, string ngayBan, float tongTien, string tenSP, float soLuong, float donGia, string maHD)
        {
            string query = string.Format("update HoaDon set MaNV='{0}',MaKH='{1}',NgayBan='{2}',TongTien='{3}',TenSanPham='{4}',SoLuong='{5}',DonGia='{6}' where MaHD='{7}'", maNV, maKH, ngayBan, tongTien, tenSP, soLuong, donGia, maHD);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteHoaDon(string MaHD)
        {
            string query = string.Format("delete HoaDon where MaHD='{0}'", MaHD);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
