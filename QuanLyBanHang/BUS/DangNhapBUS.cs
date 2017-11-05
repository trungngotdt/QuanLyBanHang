using QuanLyBanHang.BUS.Interfaces;
using QuanLyBanHang.DAO;
using QuanLyBanHang.DAO.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS
{
    public class DangNhapBUS:IDangNhapBUS
    {
        private IDangNhapDAO dangNhapDAO;
        public DangNhapBUS(IDangNhapDAO dangNhap)
        {
            this.dangNhapDAO = dangNhap;
        }

        /// <summary>
        /// Trả về chức vụ ứng với tên
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string ChucVu(string name)
        {
            return dangNhapDAO.ChucVu("EXEC USP_CheckChucVu @Name", new object[] {name }).ToString();
        }

        /// <summary>
        /// Kiểm tra xem đăng nhập có đúng không
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Pass"></param>
        /// <returns></returns>
        public bool IsDangNhap(string name,string Pass)
        {
            return dangNhapDAO.GetPassHashCode("EXECUTE USP_GetPassword @name", name) == Pass.GetHashCode();
            //throw new NotImplementedException();
        }

        public string MaNV(string name)
        {
            return dangNhapDAO.GetFirstData("EXEC USP_GetMaNVByNameSignIn @name", new object[] { name }).ToString();
        }

        public string TenNV(int id)
        {
            return dangNhapDAO.GetFirstData("EXEC USP_GetTenNV @id", new object[] { id }).ToString();
            //throw new NotImplementedException();
        }
    }
}
