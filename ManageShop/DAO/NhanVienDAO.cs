using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class NhanVienDAO
    {
        private static NhanVienDAO instance1;
        public static NhanVienDAO Instance
        {
            get { if (instance1 == null) instance1 = new NhanVienDAO(); return instance1; }
            private set { instance1 = value; }
        }
        private NhanVienDAO() { }

        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();
        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "Select * form NhanVien";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.Fill(dt);
                con.CloseConn();
            }
            catch(Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();//dong phien lam viec
                con.CloseConn();
            }
            return dt;
            //return DataProvider.Instance.ExecuteQuery("Select * form NhanVien");
        }
        public bool AddData(NhanVienDTO nvDTO)
        {
            cmd.CommandText = "Insert into NhanVien values ('" + nvDTO.Tennv + "','" + nvDTO.Gioitinh + "','" + nvDTO.Diachi + "','" + nvDTO.Sdt + "','" + nvDTO.Namsinh + "','" + nvDTO.Chucvu + "')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                con.CloseConn();
            }
            catch(Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
            //cmd.CommandText= "insert into NhanVien values(N'{0}',N'{1}',N'{2}','{3}',{4},N'{5}')", nvDTO.Tennv,nvDTO.Gioitinh,nvDTO.Diachi,nvDTO.Sdt,nvDTO.Namsinh,nvDTO.Chucvu);
            //string query = string.Format("insert into NhanVien values(N'{0}',N'{1}',N'{2}','{3}',{4},N'{5}')", nvDTO.Tennv,nvDTO.Gioitinh,nvDTO.Diachi,nvDTO.Sdt,nvDTO.Namsinh,nvDTO.Chucvu);
            //int result = DataProvider.Instance.ExecuteNonQuery(query);
            //return result > 0;
        }
        public bool UpdateData(NhanVienDTO nvDTO)
        {
            cmd.CommandText = "Update NhanVien set TenNhanVien = '" + nvDTO.Tennv + "', GioiTinh = '" + nvDTO.Gioitinh + "', DiaChi='" + nvDTO.Diachi + "', SDT='" + nvDTO.Sdt + "', NamSinh='" + nvDTO.Namsinh + "', chucvu= '" + nvDTO.Chucvu + "' where MaNV ='" + nvDTO.Id + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                con.CloseConn();
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
            //string query = string.Format("update NhanVien set TenNhanVien=N'{0}',GioiTinh=N'{1}',DiaChi=N'{2}',SDT='{3}',NamSinh='{4}',chucvu=N'{5}' where id={6}", nvDTO.Tennv,nvDTO.Gioitinh, nvDTO.Diachi, nvDTO.Sdt, nvDTO.Namsinh, nvDTO.Chucvu,nvDTO.Id);
            //int result = DataProvider.Instance.ExecuteNonQuery(query);
            //return result > 0;
        }
        public bool DeleteData(string id)
        {
            cmd.CommandText = "Delete NhanVien where MaNV ='" + id + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                con.CloseConn();
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
            //string query = string.Format("delete NhanVien where id={0}", id);
            //int result = DataProvider.Instance.ExecuteNonQuery(query);
            //return result > 0;
        }

        public DataTable GetListNhanVien()
        {
            return DataProvider.Instance.ExecuteQuery("Select * form NhanVien");
        }
        public bool InsertNhanVien(string TenNhanVien, string GioiTinh, string DiaChi, string SDT,string NamSinh,string chucvu,string luongcoban)
        {
            string query = string.Format("insert into NhanVien values(N'{0}',N'{1}',N'{2}',{3},'{4}',N'{5}',{6})", TenNhanVien, GioiTinh, DiaChi, SDT, NamSinh, chucvu, luongcoban);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateNhanVien(string TenNhanVien, string GioiTinh, string DiaChi, string SDT, string NamSinh, string chucvu, string luongcoban, string MaNV)
        {
            string query = string.Format("update NhanVien set TenNhanVien=N'{0}',GioiTinh=N'{1}',DiaChi=N'{2}',SDT='{3}',NamSinh='{4}',chucvu=N'{5}',LuongCoBan='{6}' where MaNV='{7}'", TenNhanVien, GioiTinh, DiaChi, SDT, NamSinh, chucvu, luongcoban, MaNV);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteNhanVien(string MaNV)
        {
            string query = string.Format("delete NhanVien where MaNV='{0}'", MaNV);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
