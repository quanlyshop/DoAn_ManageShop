using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SanPhamDTO
    {
        string tenSP, size, nhaSX, ngaySX;
        string maSP, soLuong, donGiaGoc, donGiaBan;
        
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string Size { get => size; set => size = value; }
        public string NhaSX { get => nhaSX; set => nhaSX = value; }
        public string NgaySX { get => ngaySX; set => ngaySX = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public string SoLuong { get => soLuong; set => soLuong = value; }
        public string DonGiaGoc { get => donGiaGoc; set => donGiaGoc = value; }
        public string DonGiaBan { get => donGiaBan; set => donGiaBan = value; }
        public SanPhamDTO() { }
        public SanPhamDTO(string maSP,string tenSP, string soLuong, string donGiaGoc, string donGiaBan,string size,string nhaSX,string ngaySX)
        {
            this.MaSP = maSP;
            this.TenSP = tenSP;
            this.SoLuong = soLuong;
            this.DonGiaBan = donGiaBan;
            this.DonGiaGoc = donGiaGoc;
            this.Size = size;
            this.NhaSX = nhaSX;
            this.NgaySX = ngaySX;
        }
    }
}
