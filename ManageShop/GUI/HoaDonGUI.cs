using System;
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
    public partial class HoaDonGUI : Form
    {
        public HoaDonGUI()
        {
            InitializeComponent();
            LoadHoaDon();
            AddHoaDonBinding();
        }
        void LoadHoaDon()
        {
            DisableTextBox();
            DisableComboBox();
            DisableHuyButton();
            string query = "Select *from HoaDon";
            dgvHoaDon.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        void AddHoaDonBinding()
        {
            try
            {
                txtMaHD.DataBindings.Clear();
                txtMaHD.DataBindings.Add(new Binding("Text", dgvHoaDon.DataSource, "MaHD"));

                txtMaNV.DataBindings.Clear();
                txtMaNV.DataBindings.Add(new Binding("Text", dgvHoaDon.DataSource, "MaNV"));

                txtMaKH.DataBindings.Clear();
                txtMaKH.DataBindings.Add(new Binding("Text", dgvHoaDon.DataSource, "MaKH"));

                dtNgayLapHD.DataBindings.Clear();
                dtNgayLapHD.DataBindings.Add(new Binding("Text", dgvHoaDon.DataSource, "NgayBan"));

                txtTongTien.DataBindings.Clear();
                txtTongTien.DataBindings.Add(new Binding("Text", dgvHoaDon.DataSource, "TongTien"));

                cmbTenSP.DataBindings.Clear();
                cmbTenSP.DataBindings.Add(new Binding("Text", dgvHoaDon.DataSource, "TenSanPham"));

                txtSoLuong.DataBindings.Clear();
                txtSoLuong.DataBindings.Add(new Binding("Text", dgvHoaDon.DataSource, "SoLuong"));

                txtDonGia.DataBindings.Clear();
                txtDonGia.DataBindings.Add(new Binding("Text", dgvHoaDon.DataSource, "DonGia"));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DisableTextBox()
        {
            // disable textbox
            txtMaKH.Enabled = false;
            txtSoLuong.Enabled = false;
            txtMaNV.Enabled = false;
            dtNgayLapHD.Enabled = false;
            txtDonGia.Enabled = false;
        }
        public void DisableComboBox()
        {
            // disable ComboBox
            cmbTenSP.Enabled = false;
        }
        public void EnableComboBox()
        {
            cmbTenSP.Enabled = true;
        }
        public void EnableTextBox()
        {
            txtMaKH.Enabled = true;
            txtSoLuong.Enabled = true;
            txtMaNV.Enabled = true;
            dtNgayLapHD.Enabled = true;
            txtDonGia.Enabled = true;
        }
        public void EnableTextBox2()
        {
            txtMaKH.Enabled = true;
            txtSoLuong.Enabled = true;
            dtNgayLapHD.Enabled = true;
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
        public void XoaTrang()
        {
            txtDonGia.Text = "";
            dtNgayLapHD.Text = "";
            txtSoLuong.Text = "";
            txtMaNV.Text = "";
            txtMaKH.Text = "";
        }
        void AddHoaDon(string maNV, string maKH, string ngayBan, float tongTien, string tenSP, float soLuong, float donGia)
        {
            try
            {
                if (HoaDonDAO.Instance.InsertHoaDon(maNV, maKH, ngayBan, tongTien, tenSP, soLuong, donGia))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    LoadHoaDon();
                }
                else
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void EditHoaDon(string maNV, string maKH, string ngayBan, float tongTien, string tenSP, float soLuong, float donGia, string maHD)
        {
            try
            {
                if (HoaDonDAO.Instance.UpdateHoaDon(maNV, maKH, ngayBan, tongTien, tenSP, soLuong, donGia, maHD))
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void DeleteHoaDon(string MaHD)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa thông tin ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    if (HoaDonDAO.Instance.DeleteHoaDon(MaHD))
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                        LoadHoaDon();
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
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnThem.Text.Equals("Thêm"))
                {
                    LayDuLieuSanPham();
                    LoadHoaDon();
                    AddHoaDonBinding();
                    EnableComboBox();
                    EnableTextBox();
                    XoaTrang();
                    btnThem.Text = "Lưu";

                    EnableHuyButton();
                    DisableSuaButton();
                    DisableXoaButton();
                    cmbTenSP.Text = "";
                }
                else if (btnThem.Text.Equals("Lưu"))
                {
                    try
                    {
                        string maNV = txtMaNV.Text;
                        string maKH = txtMaKH.Text;
                        string ngayBan = dtNgayLapHD.Text;
                        string tenSP = cmbTenSP.Text;
                        float soLuong = float.Parse(txtSoLuong.Text);
                        float donGia = float.Parse(txtDonGia.Text);
                        float tongTien = donGia * soLuong;

                        if (maNV == "")
                        {
                            MessageBox.Show("Vui lòng điền 'Mã nhân viên'", "Quản lý hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }

                        if (maKH == "")
                        {
                            MessageBox.Show("Vui lòng điền 'Mã khách hàng'", "Quản lý hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }

                        if (ngayBan == "")
                        {
                            MessageBox.Show("Vui lòng điền 'ngày bán'", "Quản lý hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }

                        if (tenSP == "")
                        {
                            MessageBox.Show("Vui lòng điền 'sản phẩm'", "Quản lý hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }

                        if (soLuong.Equals(""))
                        {
                            MessageBox.Show("Vui lòng điền 'số lượng'", "Quản lý hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }

                        AddHoaDon(maNV, maKH, ngayBan, tongTien, tenSP, soLuong, donGia);
                        //load lại dữ liệu trên form
                        LoadHoaDon();

                        //xóa trắng các ô textbox
                        //XoaTrang();

                        DisableTextBox();
                        DisableComboBox();
                        btnThem.Text = "Thêm";

                        DisableHuyButton();
                        EnableSuaButton();
                        EnableXoaButton();

                        //đóng kết nối
                        //conn.Close();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("'Số hóa đơn' đã tồn tại!");
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSua.Text.Equals("Sửa"))
                {
                    LoadHoaDon();
                    EnableComboBox();
                    EnableTextBox();
                    DisableThemButton();
                    DisableXoaButton();
                    btnSua.Text = "Lưu";
                    EnableHuyButton();
                }
                else
                {
                    string maHD = txtMaHD.Text;
                    string maNV = txtMaNV.Text;
                    string maKH = txtMaKH.Text;
                    string ngayBan = dtNgayLapHD.Text;
                    string tenSP = cmbTenSP.Text;
                    float soLuong = float.Parse(txtSoLuong.Text);
                    float donGia = float.Parse(txtDonGia.Text);
                    float tongTien = donGia * soLuong;

                    if (maNV == "")
                    {
                        MessageBox.Show("Vui lòng điền 'Mã nhân viên'", "Quản lý hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }

                    if (maKH == "")
                    {
                        MessageBox.Show("Vui lòng điền 'Mã khách hàng'", "Quản lý hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }

                    if (ngayBan == "")
                    {
                        MessageBox.Show("Vui lòng điền 'ngày bán'", "Quản lý hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }

                    if (tenSP == "")
                    {
                        MessageBox.Show("Vui lòng điền 'sản phẩm'", "Quản lý hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }

                    if (soLuong.Equals(""))
                    {
                        MessageBox.Show("Vui lòng điền 'số lượng'", "Quản lý hóa đơn", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    EditHoaDon(maNV, maKH, ngayBan, tongTien, tenSP, soLuong, donGia, maHD);
                    LoadHoaDon();
                    DisableTextBox();
                    DisableComboBox();

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
                    string MaHD = txtMaHD.Text;
                    DeleteHoaDon(MaHD);
                    LoadHoaDon();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
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

            LoadHoaDon();
            AddHoaDonBinding();
        }

        private void LayDuLieuSanPham()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-AB4A8OE;Initial Catalog=QL_ShopQuanAo;Integrated Security=True");
            string query = "SELECT *FROM SanPham";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            
            DataTable tb = new DataTable();
            adap.Fill(tb);

            cmbTenSP.DataSource = tb;
            cmbTenSP.DisplayMember = "TenSP";

            txtDonGia.DataSource = tb;
            txtDonGia.DisplayMember = "DonGiaBan";
        }

        private void HoaDonGUI_Load(object sender, EventArgs e)
        {
            LayDuLieuSanPham();
        }
    }
}
