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
       
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(NhanVienGUI));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {  
                NhanVienGUI f = new NhanVienGUI();
                //f.MdiParent = this;
                f.Show();
            }
            
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhachHangGUI f = new KhachHangGUI();
            //f.MdiParent = this;
            f.ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            RegisterGUI f = new RegisterGUI();
            //f.MdiParent = this;
            f.Show();
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HangHoaGUI f = new HangHoaGUI();
            //f.MdiParent = this;
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
            this.Hide();
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
    }
}
