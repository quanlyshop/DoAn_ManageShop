using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonDTO
    {
        string maHD, maNV, maKH, ngayBan, tenSP;
        float tongTien, donGia, soLuong;
        public HoaDonDTO() { }
        public string MaHD { get => maHD; set => maHD = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public string NgayBan { get => ngayBan; set => ngayBan = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
        public float DonGia { get => donGia; set => donGia = value; }
        public float SoLuong { get => soLuong; set => soLuong = value; }

        public HoaDonDTO(string maHD,string maNV,string maKH,string ngayBan, float tongTien,string tenSP, float soLuong, float donGia)
        {
            this.MaHD = maHD;
            this.MaNV = maNV;
            this.MaKH = maKH;
            this.NgayBan = ngayBan;
            this.TongTien = tongTien;
            this.TenSP = tenSP;
            this.SoLuong = soLuong;
            this.DonGia = donGia;
        }
    }
}
