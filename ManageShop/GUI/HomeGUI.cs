using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace GUI
{
    public partial class HomeGUI : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public HomeGUI()
        {
            InitializeComponent();
        }
        private string chucvu;
        private string fullname;

        public string Fullname { get => fullname; set => fullname = value; }
        public string Chucvu { get => chucvu; set => chucvu = value; }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(NhanVienGUI));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                //IsMdiContainer = true;
                NhanVienGUI f = new NhanVienGUI();
                f.MdiParent = this;
                f.Show();
            }
            
        }
        public void DisEndMenu(bool e)
        {
            btnNhanVien.Enabled = !e;
            btnKhachHang.Enabled = e;
            btnAccount.Enabled = !e;
            btnKhachHang.Enabled = e;
            btnLogout.Enabled = e;
            btnSanPham.Enabled = e;
        }
        public void get_permission(int per)
        {
            if (per == 1)
            {
                DisEndMenu(true);
                btnLogout.Enabled = true;
            }
            else
                DisEndMenu(false);
                btnLogout.Enabled = true;
        }
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhachHangGUI f = new KhachHangGUI();
            //IsMdiContainer = true;
            f.MdiParent = this;
            f.Show();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //IsMdiContainer = true;
            RegisterGUI f = new RegisterGUI();
            f.MdiParent = this;
            f.Show();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //IsMdiContainer = true;
            HangHoaGUI f = new HangHoaGUI();
            f.MdiParent = this;
            f.Show();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //StoreGUI f = new StoreGUI();
            //f.MdiParent = this;
            //f.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //IsMdiContainer = true;
            LoginGUI f = new LoginGUI();
            f.Show();
        }

        private void HomeGUI_Load(object sender, EventArgs e)
        {

        }
        private Form KiemTraTonTai(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype) //neu form duoc truyen vao da dc mo
                {
                    return f;
                }
            }
            return null;
        }

        private void HomeGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show("Bạn có muốn thoát ?", "Camper-Store", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr==DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnHoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //IsMdiContainer = true;
            HoaDonGUI f = new HoaDonGUI();
            f.MdiParent = this;
            f.Show();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LapHoaDonGUI f = new LapHoaDonGUI();
            f.MdiParent = this;
            f.Show();
        }
    }
}
