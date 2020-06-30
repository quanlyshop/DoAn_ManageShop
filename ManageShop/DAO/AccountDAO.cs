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
        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("Select id, fullname, usename, chucvu, MaNV form Account");
        }
        public bool InsertAccount(string fullname,string usename,string pass,string chucvu,string MaNV)
        {
            string query = string.Format("insert into Account values(N'{0}','{1}','{2}',N'{3}',{4})", fullname, usename, pass, chucvu, MaNV);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateAccount(string fullname, string usename, string pass, string chucvu, string MaNV,string id)
        {
            string query = string.Format("update Account set fullname=N'{0}',usename=N'{1}',pass=N'{2}',chucvu=N'{3}',MaNV='{4}' where id={4}", fullname, usename, pass, chucvu, MaNV, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteAccount(string id)
        {
            string query = string.Format("delete Account where id={0}", id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
