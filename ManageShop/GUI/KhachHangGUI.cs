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
using BUS;

namespace GUI
{
    public partial class KhachHangGUI : Form
    {
        public KhachHangGUI()
        {
            InitializeComponent();
            LoadKhachHang();
            AddKhachHangBinding();
        }
        void LoadKhachHang()
        {
            string query = "Select *from KhachHang";
            dgvKhachHang.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        void AddKhachHangBinding()
        {
            txtMaKH.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "MaKH"));
            txtTenKH.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "TenKH"));
            mtbSDT.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "SDT"));
            cmbGioiTinh.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "GioiTinh"));
            txtDiaChi.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "DiaChi"));
            mtbSoDiem.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "SoDiem"));
            dtNamSinh.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "NamSinh"));
            txtEmail.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "Email"));
        }
        void AddKhachHang(string tenkh, string sdt, string gioitinh, string diachi, string sodiem, string namsinh, string email)
        {
            try
            {
                if (KhachHangDAO.Instance.InsertKhachHang(tenkh,sdt,gioitinh,diachi,sodiem,namsinh,email))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void EditKhachHang(string tenkh, string sdt, string gioitinh, string diachi, string sodiem, string namsinh, string email,string makh)
        {
            try
            {
                if (KhachHangDAO.Instance.UpdateKhachHang(tenkh,sdt,gioitinh,diachi,sodiem,namsinh,email,makh))
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void DeleteKhachHang(string makh)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa thông tin ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (KhachHangDAO.Instance.DeleteKhachHang(makh))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    else
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadKhachHang();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenkh = txtTenKH.Text;
            string sdt = mtbSDT.Text;
            string gioitinh = cmbGioiTinh.Text;
            string diachi = txtDiaChi.Text;
            string sodiem = mtbSoDiem.Text;
            string namsinh = dtNamSinh.Text;
            string email = txtEmail.Text;
            AddKhachHang(tenkh, sdt, gioitinh,diachi, sodiem, namsinh, email);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string tenkh = txtTenKH.Text;
            string sdt = mtbSDT.Text;
            string gioitinh = cmbGioiTinh.Text;
            string diachi = txtDiaChi.Text;
            string sodiem = mtbSoDiem.Text;
            string namsinh = dtNamSinh.Text;
            string email = txtEmail.Text;
            string makh = txtMaKH.Text;
            EditKhachHang(tenkh, sdt, gioitinh, diachi, sodiem, namsinh, email,makh);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult yes = MessageBox.Show("Bạn có chắc xóa thông tin?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (yes == DialogResult.Yes)
                {
                    string makh = txtMaKH.Text;
                    DeleteKhachHang(makh);
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                LoadKhachHang();
                AddKhachHangBinding();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = txtSearch.Text;
                dgvKhachHang.DataSource = SearchKhachHangBUS.Instance.GetKhachHang(ten);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
