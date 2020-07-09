using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class SearchSanPham
    {
        private static SearchSanPham instance;

        public static SearchSanPham Instance
        {
            get { if (instance == null) instance = new SearchSanPham(); return SearchSanPham.instance; }
            private set { SearchSanPham.instance = value; }
        }
        public DataTable GetSanPham(string ten)
        {
            try
            {
                return SanPhamDAO.Instance.GetSanPham(ten);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
