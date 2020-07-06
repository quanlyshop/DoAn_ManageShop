using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        string makh, tenkh, sdt, gioitinh, diachi, sodiem, namsinh, email;
        public KhachHangDTO() { }
        public KhachHangDTO(string makh, string tenkh, string sdt, string gioitinh, string diachi, string sodiem, string namsinh, string email)
        {
            this.Makh = makh;
            this.Tenkh = tenkh;
            this.Sdt = sdt;
            this.Gioitinh = gioitinh;
            this.Diachi = diachi;
            this.Sodiem = sodiem;
            this.Namsinh = namsinh;
            this.Email = email;
        }
        public string Makh { get => makh; set => makh = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public string Sodiem { get => sodiem; set => sodiem = value; }
        public string Namsinh { get => namsinh; set => namsinh = value; }
        public string Email { get => email; set => email = value; }
    }
}
