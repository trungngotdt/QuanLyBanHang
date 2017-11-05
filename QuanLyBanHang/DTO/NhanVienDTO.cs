using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class NhanVienDTO
    {
        private string strMaNV;
        private string strtenNV;
        private string chucVu;
        private string diaChi;
        private int dienThoai;
        private string email;
        private string tenDangNhap;
        private string matKhau;

        public string StrMaNV { get => strMaNV; set => strMaNV = value; }
        public string StrTenNV { get => strtenNV; set => strtenNV = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int DienThoai { get => dienThoai; set => dienThoai = value; }
        public string Email { get => email; set => email = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public NhanVienDTO(string manv,string tennv,string chucVu,string diaChi,int dienThoai,string Email,string tenDangNhap,string matKhau)
        {
            this.StrMaNV = manv;
            this.StrTenNV = tennv;
            this.ChucVu = chucVu;
            this.DiaChi = diaChi;
            this.DienThoai = dienThoai;
            this.Email = Email;
            this.TenDangNhap = tenDangNhap;
            this.MatKhau = matKhau;
        }
        public NhanVienDTO(DataRow row)
        {
            this.StrMaNV = row["MaNV"].ToString();
            this.StrTenNV = row["TenNV"].ToString();
            this.ChucVu= row["ChucVu"].ToString();
            this.DiaChi= row["DiaChi"].ToString();
            this.DienThoai=(int) row["DienThoai"];
            this.Email= row["Email"].ToString();
            this.TenDangNhap= row["TenDangNhap"].ToString();
            this.MatKhau= row["MatKhau"].ToString();
        }
    }
}
