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
    public class DangNhapBUS : IDangNhapBUS
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
            try
            {
                return dangNhapDAO.ChucVu("EXEC USP_CheckChucVu @Name", new object[] { name }).ToString();
            }
            catch (Exception ex)
            {

                throw new Exception();
            }

        }

        /// <summary>
        /// Kiểm tra xem đăng nhập có đúng không
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Pass"></param>
        /// <returns></returns>
        public bool IsDangNhap(string name, string Pass)
        {
            try
            {
                return dangNhapDAO.GetPassHashCode("EXECUTE USP_GetPassword @name", name) == Pass.GetHashCode();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            //throw new NotImplementedException();
        }

        /// <summary>
        /// Trả về Mã Nhân Viên dựa vào tên đăng nhập
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string MaNV(string name)
        {
            try
            {
                return dangNhapDAO.GetFirstData("EXEC USP_GetMaNVByNameSignIn @name", new object[] { name }).ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Trả về Tên Nhân Viên dựa vào Mả Nhân Viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string TenNV(int id)
        {
            try
            {
                return dangNhapDAO.GetFirstData("EXEC USP_GetTenNV @id", new object[] { id }).ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            //throw new NotImplementedException();
        }
    }
}
