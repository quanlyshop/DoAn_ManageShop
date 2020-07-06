using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class SearchKhachHangBUS
    {
        private static SearchKhachHangBUS instance;

        public static SearchKhachHangBUS Instance
        {
            get { if (instance == null) instance = new SearchKhachHangBUS(); return SearchKhachHangBUS.instance; }
            private set { SearchKhachHangBUS.instance = value; }
        }
        public DataTable GetKhachHang(string ten)
        {
            try
            {
                return KhachHangDAO.Instance.GetKhachHang(ten);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
