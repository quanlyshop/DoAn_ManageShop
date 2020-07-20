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
    public partial class LoginGUI : Form
    {
        public LoginGUI()
        {
            InitializeComponent();
        }
      
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn thoát chương trình","Thông báo",MessageBoxButtons.OKCancel)==System.Windows.Forms.DialogResult.OK)
            {
                Application.Exit();
            }
        }

        bool Login(string usename, string pass, string fullname,string chucvu)
        {
            return AccountDAO.Instance.Login(usename, pass, fullname, chucvu);
        }
        bool PhanQuyen(string chucvu)
        {
            return AccountDAO.Instance.PhanQuyen(chucvu);
        }

        //public delegate void CheckpPermission(int per);
        //CheckpPermission chk;
        //HomeGUI frm;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usename = txtUsename.Text;
            string pass = txtPass.Text;
            string fullname = lbFullname.Text;
            string chucvu = "";
            if (Login(usename, pass, fullname, chucvu))
            {
                MessageBox.Show("Xin chào '" + usename + "'", "Camper-Store", MessageBoxButtons.OK);
                AccountDTO loginAccount = AccountDAO.Instance.GetAccountByUserName(usename);
                HomeGUI f = new HomeGUI();
                this.Hide();
                f.ShowDialog();
                this.Show();
                txtUsename.Text = "";
                txtPass.Text = "";
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mặt khẩu", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsename.Text = "";
                txtPass.Text = "";
            }
        }
    }
}
