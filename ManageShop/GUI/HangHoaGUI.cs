using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class HangHoaGUI : Form
    {
        public HangHoaGUI()
        {
            InitializeComponent();
            LoadSanPham();
            AddSanPhamBinding();
        }

        private string chucvu;
        public string ChucVu
        {
            get { return chucvu; }
            set { chucvu = value; }
        }
        void LoadSanPham()
        {
            string cv = chucvu;
            DisableTextBox();
            if (cv == "Nhân Viên")
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            string query = "select * from SanPham ";
            dgvSanPham.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        void AddSanPhamBinding()
        {
            txtMaSP.DataBindings.Clear();
            txtMaSP.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "MaSP"));

            txtTenSP.DataBindings.Clear();
            txtTenSP.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "TenSP"));

            mtbSoLuong.DataBindings.Clear();
            mtbSoLuong.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "SoLuong"));

            mtbDonGiaGoc.DataBindings.Clear();
            mtbDonGiaGoc.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "DonGiaGoc"));

            mtbDonGiaBan.DataBindings.Clear();
            mtbDonGiaBan.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "DonGiaBan"));

            cmbSize.DataBindings.Clear();
            cmbSize.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "Size"));

            txtNhaSX.DataBindings.Clear();
            txtNhaSX.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "NhaSX"));

            dtNgayNhap.DataBindings.Clear();
            dtNgayNhap.DataBindings.Add(new Binding("Text", dgvSanPham.DataSource, "NgaySX"));
        }
        public void XoaTrang()
        {
            txtTenSP.Text = "";
            txtMaSP.Text = "";
            mtbSoLuong.Text = "";
            mtbDonGiaGoc.Text = "";
            mtbDonGiaBan.Text = "";
            cmbSize.Text = "";
            txtNhaSX.Text = "";
            dtNgayNhap.Text = "";
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
        
        public void EnableTextBox()
        {
            txtTenSP.Enabled = true;
            mtbSoLuong.Enabled = true;
            mtbDonGiaGoc.Enabled = true;
            mtbDonGiaBan.Enabled = true;
            cmbSize.Enabled = true;
            txtNhaSX.Enabled = true;
            dtNgayNhap.Enabled = true;
        }
        
        public void DisableTextBox()
        {
            // disable textbox
            txtTenSP.Enabled = false;
            mtbSoLuong.Enabled = false;
            mtbDonGiaGoc.Enabled = false;
            mtbDonGiaBan.Enabled = false;
            cmbSize.Enabled = false;
            txtNhaSX.Enabled = false;
            dtNgayNhap.Enabled = false;
        }
        void AddSanPham(string tenSP, string soLuong, string donGiaGoc, string donGiaBan, string size, string nhaSX, string ngaySX)
        {
            try
            {
                if (SanPhamDAO.Instance.InsertSanPham(tenSP, soLuong, donGiaGoc, donGiaBan, size, nhaSX, ngaySX))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    LoadSanPham();
                }
                else
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void EditSanPham(string tenSP, string soLuong, string donGiaGoc, string donGiaBan, string size, string nhaSX, string ngaySX, string maSP)
        {
            try
            {
                if (SanPhamDAO.Instance.UpdateSanPham(tenSP, soLuong, donGiaGoc, donGiaBan, size, nhaSX, ngaySX, maSP))
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadSanPham();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void DeleteSanPham(string MaSP)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa thông tin ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (SanPhamDAO.Instance.DeleteSanPham(MaSP))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadSanPham();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            // lấy dữ liệu từ textBox
            string tenSP = txtTenSP.Text;
            string soLuong = mtbSoLuong.Text;
            string donGiaGoc = mtbDonGiaGoc.Text;
            string donGiaBan = mtbDonGiaBan.Text;
            string size = cmbSize.Text;
            string nhaSX = txtNhaSX.Text;
            string ngaySX = dtNgayNhap.Text;

            if (tenSP == "")
            {
                MessageBox.Show("Vui lòng điền 'tên sản phẩm'","Quản lý sản phẩm",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                return;
            }

            else if (donGiaGoc == "")
            {
                MessageBox.Show("Vui lòng điền ' đơn giá gốc sản phẩm'", "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            else if (donGiaBan == "")
            {
                MessageBox.Show("Vui lòng điền ' đơn giá bán sản phẩm'","Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            
            else if (size == "")
            {
                MessageBox.Show("Vui lòng điền 'size sản phẩm'", "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            
            else if (nhaSX == "")
            {
                MessageBox.Show("Vui lòng điền 'nhà sản xuất sản phẩm'", "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            else if (ngaySX == "")
            {
                MessageBox.Show("Vui lòng điền 'ngày sản xuất sản phẩm'", "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            else if (soLuong == "")
            {
                MessageBox.Show("Vui lòng điền 'số lượng sản phẩm'", "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            else
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
                else
                {
                    try
                    {
                        AddSanPham(tenSP, soLuong, donGiaGoc, donGiaBan, size, nhaSX, ngaySX);
                        //load lại dữ liệu trên form
                        LoadSanPham();

                        //xóa trắng các ô textbox
                        //XoaTrang();
                        DisableTextBox();
                        btnThem.Text = "Thêm";

                        DisableHuyButton();
                        EnableSuaButton();
                        EnableXoaButton();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("'Mã sản phẩm đã tồn tại!'");
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSua.Text.Equals("Sửa"))
                {
                    LoadSanPham();
                    EnableTextBox();

                    DisableThemButton();
                    DisableXoaButton();

                    btnSua.Text = "Lưu";

                    EnableHuyButton();
                }
                else
                {
                    string tenSP = txtTenSP.Text;
                    string soLuong = mtbSoLuong.Text;
                    string donGiaGoc = mtbDonGiaGoc.Text;
                    string donGiaBan = mtbDonGiaBan.Text;
                    string size = cmbSize.Text;
                    string nhaSX = txtNhaSX.Text;
                    string ngaySX = dtNgayNhap.Text;
                    string maSP = txtMaSP.Text;
                    if (tenSP == "")
                    {
                        MessageBox.Show("Vui lòng điền 'tên sản phẩm'", "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }

                    else if (donGiaGoc == "")
                    {
                        MessageBox.Show("Vui lòng điền ' đơn giá gốc sản phẩm'", "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    else if (donGiaBan == "")
                    {
                        MessageBox.Show("Vui lòng điền ' đơn giá bán sản phẩm'", "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }

                    else if (size == "")
                    {
                        MessageBox.Show("Vui lòng điền 'size sản phẩm'", "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }

                    else if (nhaSX == "")
                    {
                        MessageBox.Show("Vui lòng điền 'nhà sản xuất sản phẩm'", "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    else if (ngaySX == "")
                    {
                        MessageBox.Show("Vui lòng điền 'ngày sản xuất sản phẩm'", "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    else if (soLuong == "")
                    {
                        MessageBox.Show("Vui lòng điền 'số lượng sản phẩm'", "Quản lý sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                
                    EditSanPham(tenSP, soLuong, donGiaGoc, donGiaBan, size, nhaSX, ngaySX, maSP);
                    LoadSanPham();
                    DisableTextBox();
                    btnSua.Text = "Sửa";
                    DisableHuyButton();
                    EnableThemButton();
                    EnableXoaButton();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult yes = MessageBox.Show("Bạn có chắc xóa thông tin?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (yes == DialogResult.Yes)
                {
                    string MaSP = txtMaSP.Text;
                    DeleteSanPham(MaSP);
                    LoadSanPham();
                }
            }
            catch (Exception ex)
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

                LoadSanPham();
                AddSanPhamBinding();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnSearchSP_Click(object sender, EventArgs e)
        {
            try
            {
                EnableHuyButton();
                string ten = txtSearchSP.Text;
                dgvSanPham.DataSource = SearchSanPham.Instance.GetSanPham(ten);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HangHoaGUI_Load(object sender, EventArgs e)
        {
            string cv = chucvu;

            if (cv == "Nhân viên")
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                
            }
        }
    }
}
