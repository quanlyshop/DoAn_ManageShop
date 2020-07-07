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
using DTO;

namespace GUI
{
    public partial class StoreGUI : Form
    {
        public StoreGUI()
        {
            InitializeComponent();
            LoadTable();
        }
        #region Method
        void LoadTable()
        {
            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach(Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.MaHang + Environment.NewLine + item.TenHang + Environment.NewLine + item.DonGiaBan;
                btn.BackColor = Color.Aqua;
                btn.Click += btn_Click;
                btn.Tag = item;
                flpTableStore.Controls.Add(btn);
            }
        }
        void ShowBill(int maHD)
        {

        }
        #endregion
        void btn_Click(object sender,EventArgs e)
        {
            //int tableID = (sender as Table).maHD;
            //ShowBill(tableID);
            //throw new NotImplementedException();
        }
    }
}
