using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO();return instance; }
            private set { instance = value; }
        }
        private AccountDAO() { }
        public bool Login(string usename,string pass)
        {
            string query = "select *from Account a where a.usename = N'" + usename + "' and a.pass = N'" + pass + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }
    }
}
