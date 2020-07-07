using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public class NhanVienDTO
    {
        string manv, tennv, gioitinh, diachi, sdt, namsinh, chucvu ;
        string luongcoban;
        int id;
        public string Manv { get => manv; set => manv = value; }
        public string Tennv { get => tennv; set => tennv = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Namsinh { get => namsinh; set => namsinh = value; }
        public string Chucvu { get => chucvu; set => chucvu = value; }
        public int Id { get => id; set => id = value; }
        public string Luongcoban { get => luongcoban; set => luongcoban = value; }

        public NhanVienDTO() { }
        public NhanVienDTO(string manv,string tennv,string gioitinh,string diachi,string sdt,string namsinh,string chucvu,string luongcoban, int id)
        {
            this.manv = manv;
            this.tennv = tennv;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.sdt = sdt;
            this.namsinh = namsinh;
            this.chucvu = chucvu;
            this.id = id;
            this.Luongcoban = luongcoban;
        }
    }
}
