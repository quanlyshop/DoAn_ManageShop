using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccountDTO
    {
        private string usename;
        private string pass;
        private int id;
        private string chucvu;
        private string fullname;
        public AccountDTO(int id, string fullname, string usename, string chucvu, string pass=null)
        {
            this.Id = id;
            this.Fullname = fullname;
            this.Usename = usename;
            this.Chucvu = chucvu;
            this.Pass = pass;
        }
        public AccountDTO(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Fullname = row["fullname"].ToString();
            this.Usename = row["usename"].ToString();
            this.Chucvu = row["chucvu"].ToString();
            this.Pass = row["pass"].ToString();
        }

        public string Usename { get => usename; set => usename = value; }
        public string Pass { get => pass; set => pass = value; }
        public int Id { get => id; set => id = value; }
        public string Chucvu { get => chucvu; set => chucvu = value; }
        public string Fullname { get => fullname; set => fullname = value; }
    }
}
