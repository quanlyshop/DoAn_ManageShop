﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAO;
using DTO;

namespace GUI
{
    public partial class NhanVienGUI : Form
    {
        //NhanVienBUS nvBUS = new NhanVienBUS();
        NhanVienDTO nvDTO = new NhanVienDTO();
        //NhanVienDAO nvDAO = new NhanVienDAO();
        //tạo một cái cờ
        //int flag = 0;
        public NhanVienGUI()
        {
            InitializeComponent();
            LoadNhanVien();
            AddNhanVienBinding();
            DisableTextBox();
            DisableHuyButton();
        }
        void AddNhanVienBinding()
        {
            txtMaNV.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "MaNV"));
            txtTenNV.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "TenNhanVien"));
            cmbGioiTinh.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "GioiTinh"));
            txtDiaChi.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "DiaChi"));
            mtbSDT.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "SDT"));
            dtNamSinh.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "NamSinh"));
            cbChucVu.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "chucvu"));
            mtbLuongCoBan.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "luongcoban"));
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void NhanVienGUI_Load(object sender, EventArgs e)
        {
            
        }
        void LoadNhanVien()
        {
            DisableTextBox();
            DisableHuyButton();
            string query = "select * from NhanVien ";
            dgvNhanVien.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        void loadcontrol(bool e)
        {
            //txtTenNV.Enabled = e;
            //cmbGioiTinh.Enabled = e;
            //txtDiaChi.Enabled = e;
            //mtbSDT.Enabled = e;
            //dtNamSinh.Enabled = e;
            //cbChucVu.Enabled = e;
        }
        public void DisableTextBox()
        {
            // disable textbox
            txtTenNV.Enabled = false;
            txtDiaChi.Enabled = false;
            mtbSDT.Enabled = false;
            mtbLuongCoBan.Enabled = false;
            cmbGioiTinh.Enabled = false;
            cbChucVu.Enabled = false;
            dtNamSinh.Enabled = false;
        }
        public void EnableTextBox()
        {
            // disable textbox
            txtTenNV.Enabled = true;
            txtDiaChi.Enabled = true;
            mtbSDT.Enabled = true;
            mtbLuongCoBan.Enabled = true;
            cmbGioiTinh.Enabled = true;
            cbChucVu.Enabled = true;
            dtNamSinh.Enabled = true;
        }
        public void EnableHuyButton()
        {
            btnHuy.Enabled = true;
            btnHuy.BackColor = Color.DeepSkyBlue;
        }
        public void DisableHuyButton()
        {
            btnHuy.Enabled = false;
            btnHuy.BackColor = Color.White;
        }
        public void DisableThemButton()
        {
            btnThem.Enabled = false;
            btnThem.BackColor = Color.White;
        }
        public void EnableThemButton()
        {
            btnThem.Enabled = true;
            btnThem.BackColor = Color.Turquoise;
        }
        public void EnableSuaButton()
        {
            btnSua.Enabled = true;
            btnSua.BackColor = Color.RoyalBlue;
        }
        public void DisableSuaButton()
        {
            btnSua.Enabled = false;
            btnSua.BackColor = Color.White;
        }
        public void DisableXoaButton()
        {
            btnXoa.Enabled = false;
            btnXoa.BackColor = Color.White;
        }
        public void EnableXoaButton()
        {
            btnXoa.Enabled = true;
            btnXoa.BackColor = Color.Tomato;
        }
        public void DisableComboBox()
        {
            // disable ComboBox
            cbChucVu.Enabled = false;
            cmbGioiTinh.Enabled = false;
        }
        public void EnableComboBox()
        {
            cbChucVu.Enabled = true;
            cmbGioiTinh.Enabled = true;
        }
        public void XoaTrang()
        {
            txtTenNV.Text = " ";
            txtDiaChi.Text = " ";
            mtbSDT.Text = "";
            mtbLuongCoBan.Text = "";
            cmbGioiTinh.Text = "";
            cbChucVu.Text = "";
            dtNamSinh.Text = "";
        }
        ////tạo 1 hàm gán dữ liệu vào NhanVienDTO khi nhập dữ liệu vào textbox thì sẽ được gán vào các biến ở NhanVienDTO
        //void ganData(NhanVienDTO nvDTO)
        //{
        //    nvDTO.Tennv = txtTenNV.Text.Trim();
        //    nvDTO.Gioitinh = cmbGioiTinh.Text.Trim();
        //    nvDTO.Diachi = txtDiaChi.Text.Trim();
        //    nvDTO.Sdt = mtbSDT.Text.Trim();
        //    nvDTO.Namsinh = dtNamSinh.Text.Trim();
        //    nvDTO.Chucvu = cbChucVu.Text.Trim();
        //}
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text.Equals("Thêm"))
            {
                EnableTextBox();
                XoaTrang();
                btnThem.Text = "Lưu";

                EnableHuyButton();
                DisableSuaButton();
                DisableXoaButton();

            }

            else if (btnThem.Text.Equals("Lưu"))
            {
                try
                {
                    string TenNhanVien = txtTenNV.Text;
                    string GioiTinh = cmbGioiTinh.Text;
                    string DiaChi = txtDiaChi.Text;
                    string SDT = mtbSDT.Text;
                    string NamSinh = dtNamSinh.Text;
                    string chucvu = cbChucVu.Text;
                    string LuongCoBan = mtbLuongCoBan.Text;

                    if (TenNhanVien == "")
                    {
                        MessageBox.Show("Vui lòng điền 'tên nhân viên'","Quản lý nhân viên",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                        return;
                    }

                    if (NamSinh == "")
                    {
                        MessageBox.Show("Vui lòng điền 'năm sinh nhân viên'", "Quản lý nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }

                    if (DiaChi == "")
                    {
                        MessageBox.Show("Vui lòng điền 'địa chi của nhân viên'", "Quản lý nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }

                    if (SDT == "")
                    {
                        MessageBox.Show("Vui lòng điền 'sđt của nhân viên'", "Quản lý nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }


                    if (GioiTinh == "")
                    {
                        MessageBox.Show("Vui lòng chọn giới tính của nhân viên'", "Quản lý nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    if (chucvu == "")
                    {
                        MessageBox.Show("Vui lòng chọn chức vụ của nhân viên'", "Quản lý nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    if (LuongCoBan == "")
                    {
                        MessageBox.Show("Vui lòng điền lương cơ bản của nhân viên'", "Quản lý nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    AddNhanVien(TenNhanVien, GioiTinh, DiaChi, SDT, NamSinh, chucvu, LuongCoBan);
                    LoadNhanVien();

                    //xóa trắng các ô textbox
                    //XoaTrang();

                    DisableTextBox();
                    DisableComboBox();
                    btnThem.Text = "Thêm";

                    DisableHuyButton();
                    EnableSuaButton();
                    EnableXoaButton();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text.Equals("Sửa"))
            {

                EnableComboBox();
                EnableTextBox();

                DisableThemButton();
                DisableXoaButton();

                btnSua.Text = "Lưu";

                EnableHuyButton();
            }
            else
            {
                string TenNhanVien = txtTenNV.Text;
                string GioiTinh = cmbGioiTinh.Text;
                string DiaChi = txtDiaChi.Text;
                string SDT = mtbSDT.Text;
                string NamSinh = dtNamSinh.Text;
                string chucvu = cbChucVu.Text;
                string LuongCoBan = mtbLuongCoBan.Text;
                string MaNV = txtMaNV.Text;
                if (TenNhanVien == "")
                {
                    MessageBox.Show("Vui lòng điền 'tên nhân viên'");
                    return;
                }

                if (NamSinh == "")
                {
                    MessageBox.Show("Vui lòng điền 'năm sinh nhân viên'");
                    return;
                }

                if (DiaChi == "")
                {
                    MessageBox.Show("Vui lòng điền 'địa chi của nhân viên'");
                    return;
                }

                if (SDT == "")
                {
                    MessageBox.Show("Vui lòng điền 'sđt của nhân viên'");
                    return;
                }


                if (GioiTinh == "")
                {
                    MessageBox.Show("Vui lòng chọn giới tính của nhân viên'");
                    return;
                }
                if (chucvu == "")
                {
                    MessageBox.Show("Vui lòng chọn chức vụ của nhân viên'");
                    return;
                }
                if (LuongCoBan == "")
                {
                    MessageBox.Show("Vui lòng điền lương cơ bản của nhân viên'");
                    return;
                }

                EditNhanVien(TenNhanVien, GioiTinh, DiaChi, SDT, NamSinh, chucvu, LuongCoBan, MaNV);
                LoadNhanVien();
                DisableTextBox();
                DisableComboBox();
                btnSua.Text = "Sửa";
                DisableHuyButton();
                EnableThemButton();
                EnableXoaButton();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult yes = MessageBox.Show("Bạn có chắc xóa thông tin?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yes == DialogResult.Yes)
            {
                string MaNV = txtMaNV.Text;
                DeleteNhanVien(MaNV);
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadNhanVien();
            }
            else
                MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        private void btnHuy_Click(object sender, EventArgs e)
        {
            try
            {
                LoadNhanVien();
                AddNhanVienBinding();
                if (btnThem.Text.Equals("Lưu"))
                {
                    btnThem.Text = "Thêm";
                    EnableSuaButton();
                    EnableXoaButton();
                }

                if (btnSua.Text.Equals("Lưu"))
                {
                    btnSua.Text = "Sửa";
                    EnableXoaButton();
                    EnableThemButton();
                }
                DisableHuyButton();
                DisableTextBox();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            //NhanVienGUI_Load(sender, e);
        }
        void AddNhanVien(string TenNhanVien, string GioiTinh, string DiaChi, string SDT, string NamSinh, string chucvu,string LuongCoBan)
        {
            try
            {
                if (NhanVienDAO.Instance.InsertNhanVien(TenNhanVien, GioiTinh, DiaChi, SDT, NamSinh, chucvu, LuongCoBan))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    LoadNhanVien();
                }
                else
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void EditNhanVien(string TenNhanVien, string GioiTinh, string DiaChi, string SDT, string NamSinh, string chucvu,string LuongCoBan, string MaNV)
        {
            try
            {
                if (NhanVienDAO.Instance.UpdateNhanVien(TenNhanVien, GioiTinh, DiaChi, SDT, NamSinh, chucvu, LuongCoBan, MaNV))
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void DeleteNhanVien(string MaNV)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa thông tin ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (NhanVienDAO.Instance.DeleteNhanVien(MaNV))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadNhanVien();
                    }
                    else
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
