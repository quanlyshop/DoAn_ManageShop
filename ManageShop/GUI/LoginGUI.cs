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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUsename.Text = "";
            txtPass.Text = "";
        }
        bool Login(string usename, string pass)
        {
            return AccountDAO.Instance.Login(usename, pass);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usename = txtUsename.Text;
            string pass = txtPass.Text;
            MessageBox.Show("Xin chào " + usename + " " + "!","Camper-Store",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            if (Login(usename, pass))
            {
                HomeGUI f = new HomeGUI();
                this.Hide();
                f.ShowDialog();
                this.Show();
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
