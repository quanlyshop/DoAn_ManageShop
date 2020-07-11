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
using System.Data.SqlClient;

namespace GUI
{
    public partial class LapHoaDonGUI : Form
    {
        public LapHoaDonGUI()
        {
            InitializeComponent();
            LoadSanPham();
        }
        void LoadSanPham()
        {
            string query = "select * from SanPham ";
            dgvSanPham.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string ten = txtSearch.Text;
                dgvSanPham.DataSource = SearchSanPham.Instance.GetSanPham(ten);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadSanPham();
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
        void TinhTong()
        {
            //float Tong = 0;
            //float dongia = float.Parse(txtDonGia.Text);
            //float soluong = float.Parse(txtSoLuong.Text);
            //Tong = dongia * soluong;
            //txtTong.Text = Tong.ToString();
        }
        private void LapHoaDonGUI_Load(object sender, EventArgs e)
        {
            LayDuLieuSanPham();
            TinhTong();
            DisableTextBox();
        }
        void AddHoaDon(string maNV, string maKH, string ngayBan, float tongTien, string tenSP, float soLuong, float donGia)
        {
            try
            {
                if (HoaDonDAO.Instance.InsertHoaDon(maNV, maKH, ngayBan, tongTien, tenSP, soLuong, donGia))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    
                }
                else
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void EnableTextBox()
        {
            txtMaKH.Enabled = true;
            txtSoLuong.Enabled = true;
            txtMaNV.Enabled = true;
            dtNgayLapHD.Enabled = true;
            txtDonGia.Enabled = true;
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
        public void XoaTrang()
        {
            txtDonGia.Text = "";
            dtNgayLapHD.Text = "";
            txtSoLuong.Text = "";
            txtMaNV.Text = "";
            txtMaKH.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnThem.Text.Equals("Thêm"))
                {
                    LayDuLieuSanPham();
                    LoadSanPham();
                    EnableTextBox();
                    XoaTrang();
                    btnThem.Text = "Lưu";
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
                        DisableTextBox();
                        btnThem.Text = "Thêm";
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

    }
}
