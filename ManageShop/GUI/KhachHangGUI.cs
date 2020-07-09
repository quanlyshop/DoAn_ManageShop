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
            DisableTextBox();
            DisableHuyButton();
            string query = "Select *from KhachHang";
            dgvKhachHang.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        void AddKhachHangBinding()
        {
            try
            {
                txtMaKH.DataBindings.Clear();
                txtMaKH.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "MaKH"));

                txtTenKH.DataBindings.Clear();
                txtTenKH.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "TenKH"));

                mtbSDT.DataBindings.Clear();
                mtbSDT.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "SDT"));

                cmbGioiTinh.DataBindings.Clear();
                cmbGioiTinh.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "GioiTinh"));

                txtDiaChi.DataBindings.Clear();
                txtDiaChi.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "DiaChi"));

                mtbSoDiem.DataBindings.Clear();
                mtbSoDiem.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "SoDiem"));

                dtNamSinh.DataBindings.Clear();
                dtNamSinh.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "NamSinh"));

                txtEmail.DataBindings.Clear();
                txtEmail.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "Email"));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
        public void DisableTextBox()
        {
            // disable textbox
            txtTenKH.Enabled = false;
            mtbSDT.Enabled = false;
            cmbGioiTinh.Enabled = false;
            txtDiaChi.Enabled = false;
            mtbSoDiem.Enabled = false;
            dtNamSinh.Enabled = false;
            txtEmail.Enabled = false;
        }
        public void EnableTextBox()
        {
            // disable textbox
            txtTenKH.Enabled = true;
            txtDiaChi.Enabled = true;
            mtbSDT.Enabled = true;
            mtbSoDiem.Enabled = true;
            cmbGioiTinh.Enabled = true;
            txtEmail.Enabled = true;
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
           
            cmbGioiTinh.Enabled = false;
        }
        public void EnableComboBox()
        {
            
            cmbGioiTinh.Enabled = true;
        }
        public void XoaTrang()
        {
            txtTenKH.Text = " ";
            txtDiaChi.Text = " ";
            mtbSDT.Text = "";
            mtbSoDiem.Text = "";
            cmbGioiTinh.Text = "";
            txtEmail.Text = "";
            dtNamSinh.Text = "";
        }

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
                    string tenkh = txtTenKH.Text;
                    string sdt = mtbSDT.Text;
                    string gioitinh = cmbGioiTinh.Text;
                    string diachi = txtDiaChi.Text;
                    string sodiem = mtbSoDiem.Text;
                    string namsinh = dtNamSinh.Text;
                    string email = txtEmail.Text;
                    if (tenkh == "")
                    {
                        MessageBox.Show("Vui lòng điền 'tên khách hàng'", "Quản lý khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (namsinh == "")
                    {
                        MessageBox.Show("Vui lòng điền 'năm sinh khách hàng'", "Quản lý khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (diachi == "")
                    {
                        MessageBox.Show("Vui lòng điền 'địa chi của khách hàng'", "Quản lý khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (sdt == "")
                    {
                        MessageBox.Show("Vui lòng điền 'sđt của khách hàng'", "Quản lý khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    if (gioitinh == "")
                    {
                        MessageBox.Show("Vui lòng chọn giới tính của khách hàng", "Quản lý khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (email == "")
                    {
                        MessageBox.Show("Vui lòng điền email khách hàng", "Quản lý khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (sodiem == "")
                    {
                        MessageBox.Show("Vui lòng điền số điểm của khách hàng","Quản lý khách hàng",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }

                    AddKhachHang(tenkh, sdt, gioitinh, diachi, sodiem, namsinh, email);
                    DisableTextBox();
                    DisableComboBox();
                    btnThem.Text = "Thêm";

                    DisableHuyButton();
                    EnableSuaButton();
                    EnableXoaButton();

                    AddKhachHangBinding();
                    LoadKhachHang();
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
                string tenkh = txtTenKH.Text;
                string sdt = mtbSDT.Text;
                string gioitinh = cmbGioiTinh.Text;
                string diachi = txtDiaChi.Text;
                string sodiem = mtbSoDiem.Text;
                string namsinh = dtNamSinh.Text;
                string email = txtEmail.Text;
                string makh = txtMaKH.Text;
                if (tenkh == "")
                {
                    MessageBox.Show("Vui lòng điền 'tên khách hàng'", "Quản lý khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (namsinh == "")
                {
                    MessageBox.Show("Vui lòng điền 'năm sinh khách hàng'", "Quản lý khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (diachi == "")
                {
                    MessageBox.Show("Vui lòng điền 'địa chi của khách hàng'", "Quản lý khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (sdt == "")
                {
                    MessageBox.Show("Vui lòng điền 'sđt của khách hàng'", "Quản lý khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (gioitinh == "")
                {
                    MessageBox.Show("Vui lòng chọn giới tính của khách hàng", "Quản lý khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (email == "")
                {
                    MessageBox.Show("Vui lòng điền email khách hàng", "Quản lý khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (sodiem == "")
                {
                    MessageBox.Show("Vui lòng điền số điểm của khách hàng", "Quản lý khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                EditKhachHang(tenkh, sdt, gioitinh, diachi, sodiem, namsinh, email, makh);
                DisableTextBox();
                DisableComboBox();
                btnSua.Text = "Sửa";
                DisableHuyButton();
                EnableThemButton();
                EnableXoaButton();
                LoadKhachHang();
                AddKhachHangBinding();
            }
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

                LoadKhachHang();
                AddKhachHangBinding();
            }
            catch (Exception ex)
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

        private void KhachHangGUI_Load(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            try
            {
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

                LoadKhachHang();
                AddKhachHangBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadKhachHang();
            AddKhachHangBinding();
        }
    }
}
