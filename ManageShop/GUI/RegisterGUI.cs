using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace GUI
{
    public partial class RegisterGUI : Form
    {
        public RegisterGUI()
        {
            InitializeComponent();
            LoadAccount();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        void LoadAccount()
        {
            //string query = "select n.TenNhanVien,a.id,a.usename,a.pass,a.chucvu from Account a,NhanVien n where a.chucvu = n.chucvu";
            string query = "select * from Account ";
            //DataProvider provider = new DataProvider();
            dgvRegister.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        private void dgvRegister_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RegisterGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
