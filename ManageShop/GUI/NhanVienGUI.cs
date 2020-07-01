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
    public partial class NhanVienGUI : Form
    {
        //NhanVienBUS nvBUS = new NhanVienBUS();
        NhanVienDTO nvDTO = new NhanVienDTO();
        //NhanVienDAO nvDAO = new NhanVienDAO();
        //tạo một cái cờ
        int flag = 0;
        public NhanVienGUI()
        {
            InitializeComponent();
            LoadNhanVien();
            AddNhanVienBinding();
           
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
            string TenNhanVien = txtTenNV.Text;
            string GioiTinh = cmbGioiTinh.Text;
            string DiaChi = txtDiaChi.Text;
            string SDT = mtbSDT.Text;
            string NamSinh = dtNamSinh.Text;
            string chucvu =cbChucVu.Text;
            string luongcoban = mtbLuongCoBan.Text;
            AddNhanVien(TenNhanVien, GioiTinh, DiaChi, SDT, NamSinh, chucvu,luongcoban);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string TenNhanVien = txtTenNV.Text;
            string GioiTinh = cmbGioiTinh.Text;
            string DiaChi = txtDiaChi.Text;
            string SDT = mtbSDT.Text;
            string NamSinh = dtNamSinh.Text;
            string chucvu = cbChucVu.Text;
            string luongcoban = mtbLuongCoBan.Text;
            string MaNV = txtMaNV.Text;
            EditNhanVien(TenNhanVien, GioiTinh, DiaChi, SDT, NamSinh, chucvu, luongcoban, MaNV);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult yes = MessageBox.Show("Bạn có chắc xóa thông tin?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yes == DialogResult.Yes)
            {
                string MaNV = txtMaNV.Text;
                DeleteNhanVien(MaNV);
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //ganData(nvDTO);
            //if (flag == 0)
            //{
            //    if (nvDAO.UpdateData(nvDTO))
            //        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    else
            //        MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            ////else
            ////{
            ////    if (nvBUS.addData(nvDTO))
            ////        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////    else
            ////        MessageBox.Show("Sửa thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ////}
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            NhanVienGUI_Load(sender, e);
        }
        void AddNhanVien(string TenNhanVien, string GioiTinh, string DiaChi, string SDT, string NamSinh, string chucvu,string luongcoban)
        {
            try
            {
                if (NhanVienDAO.Instance.InsertNhanVien(TenNhanVien, GioiTinh, DiaChi, SDT, NamSinh, chucvu, luongcoban))
                {
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Mã nhân viên không tồn tại");
            }
        }
        void EditNhanVien(string TenNhanVien, string GioiTinh, string DiaChi, string SDT, string NamSinh, string chucvu,string luongcoban, string MaNV)
        {
            try
            {
                if (NhanVienDAO.Instance.UpdateNhanVien(TenNhanVien, GioiTinh, DiaChi, SDT, NamSinh, chucvu, luongcoban, MaNV))
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
                    }
                    else
                        MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoadNhanVien();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
