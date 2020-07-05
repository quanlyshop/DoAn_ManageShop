using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Table
    {
        //ham dung
       public Table(int maHang,string tenHang,int donGiaBan)
        {
            this.MaHang = maHang;
            this.TenHang = tenHang;
            this.DonGiaBan = donGiaBan;
        }
        public Table(DataRow row)
        {
            this.MaHang = (int)row["MaHang"];
            this.TenHang = row["TenHang"].ToString();
            this.DonGiaBan = (int)row["DonGiaBan"];
        }
        private int maHang;
        private string tenHang;
        private int donGiaBan;

        public int MaHang { get => maHang; set => maHang = value; }
        public string TenHang { get => tenHang; set => tenHang = value; }
        public int DonGiaBan { get => donGiaBan; set => donGiaBan = value; }
    }
}
