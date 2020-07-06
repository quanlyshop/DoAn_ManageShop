using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance { get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; } }
        private BillDAO() { }
        public int GetUncheckBillIDByTableID(int maHD)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select *from HoaDon where MaHD= " + maHD + "");
            if(data.Rows.Count>0)
            {
                //BillDAO bill = new BillDAO(data.Rows[0]);
                //return bill.maHD;
            }
            return -1;
        }
    }
}
