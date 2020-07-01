﻿using System;
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
            AddAcountBinding();
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
        void AddAcountBinding()
        {
            txtid.DataBindings.Add(new Binding("Text", dgvRegister.DataSource, "id"));
            txtfullname.DataBindings.Add(new Binding("Text", dgvRegister.DataSource, "fullname"));
            txtusename.DataBindings.Add(new Binding("Text", dgvRegister.DataSource, "usename"));
            txtpass.DataBindings.Add(new Binding("Text", dgvRegister.DataSource, "pass"));
            cbchucvu.DataBindings.Add(new Binding("Text", dgvRegister.DataSource, "chucvu"));
        }
        private void RegisterGUI_Load(object sender, EventArgs e)
        {

        }
        void AddAccount(string fullname, string usename, string pass, string chucvu)
        {
            try
            {
                if (AccountDAO.Instance.InsertAccount(fullname, usename, pass, chucvu))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadAccount();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Mã nhân viên không tồn tại");
            }
        }
        void EditAccount(string fullname, string usename, string pass, string chucvu, string id)
        {
            try
            {
                if (AccountDAO.Instance.UpdateAccount(fullname, usename, pass, chucvu, id))
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadAccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void DeleteAccount(string id)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa thông tin ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (AccountDAO.Instance.DeleteAccount(id))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadAccount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string fullname = txtfullname.Text;
            string usename = txtusename.Text;
            string pass = txtpass.Text;
            string chucvu = cbchucvu.Text;
            AddAccount(fullname, usename, pass, chucvu);
        }
        
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtid.Text;
            DeleteAccount(id);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string fullname = txtfullname.Text;
            string usename = txtusename.Text;
            string pass = txtpass.Text;
            string chucvu = cbchucvu.Text;
            string id = txtid.Text;
            EditAccount(fullname, usename, pass, chucvu, id);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtid.Text = "";
            txtfullname.Text = "";
            txtusename.Text = "";
            txtpass.Text = "";
            cbchucvu.Text = "";
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
