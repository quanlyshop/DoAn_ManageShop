using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class SearchHoaDonBUS
    {
        private static SearchHoaDonBUS instance;

        public static SearchHoaDonBUS Instance
        {
            get { if (instance == null) instance = new SearchHoaDonBUS(); return SearchHoaDonBUS.instance; }
            private set { SearchHoaDonBUS.instance = value; }
        }
        public DataTable GetHoaDon(string ten)
        {
            try
            {
                return HoaDonDAO.Instance.GetHoaDon(ten);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ReporHoaDon(int id)
        {
            try
            {
                return HoaDonDAO.Instance.ReportHoaDon(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
