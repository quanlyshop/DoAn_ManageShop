using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillDTO
    {
        private int maHD;
        private int maNV;
        private int maKh;
        private int tongTien;
        private DateTime ngayBan;

        public int MaHD { get => maHD; set => maHD = value; }
        public int MaNV { get => maNV; set => maNV = value; }
        public int MaKh { get => maKh; set => maKh = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
        public DateTime NgayBan { get => ngayBan; set => ngayBan = value; }
        public BillDTO(int maHD,int maNV,int maKH,int tongTien,DateTime ngayBan)
        {
            this.MaHD = maHD;
            this.MaNV = maNV;
            this.MaKh = maKh;
            this.TongTien = tongTien;
            this.NgayBan = ngayBan;
        }
        public BillDTO(DataRow row)
        {
            this.MaKh = (int)row["MaHD"];
            this.MaNV = (int)row["MaNV"];
            this.MaKh = (int)row["MaKH"];
            this.TongTien = (int)row["TongTien"];
            this.NgayBan = (DateTime)row["NgayBan"];
        }
    }
}
