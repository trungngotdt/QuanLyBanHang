using QuanLyBanHang.BUS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyBanHang.DAO.InterfacesDAO;
using QuanLyBanHang.DAO;

namespace QuanLyBanHang.BUS
{
    public class QuanLyBUS : IQuanLyBUS
    {
        private IDataProvider dataProvider;
        public QuanLyBUS(IDataProvider data)
        {
            this.dataProvider = data;
        }

        /// <summary>
        /// Lấy tất cả dữ liệu về khách hàng
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataKH()
        {
            try
            {

                return dataProvider.ExecuteQuery("SELECT kh.* FROM dbo.KhachHang kh");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Lấy tất cả dữ liệu về Nhân Viên
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataNV()
        {
            try
            {

                return dataProvider.ExecuteQuery("SELECT nv.MaNV ,nv.TenNV,nv.ChucVu,nv.DiaChi,nv.DienThoai,nv.Email,nv.TenDangNhap FROM dbo.NhanVien nv");
                //throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Trả về true nếu thêm thành công
        /// Thứ tự paramater @name , @phone , @sex , @address , @level  trong đó mã khách hàng là tự động tăng
        /// </summary>
        /// <param name="para">Thứ tự paramater @name , @phone , @sex , @address , @level </param>
        /// <returns></returns>
        public bool InsertKH(object[] para)
        {
            try
            {

                return dataProvider.ExecuteNonQuery("EXECUTE USP_InsertKhachHang @name , @phone , @sex , @address , @level ", para) > 0;
                //throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Trả về true nếu thêm thành công
        /// Thứ tự paramater @Ten , @Chuc ,@DiaChi ,@SDT ,@Email 
        /// Trong đó Tên Đăng Nhập và Mật khẩu mật định là @Ten và @SDT
        /// </summary>
        /// <param name="para">Thứ tự paramater @Ten , @Chuc ,@DiaChi ,@SDT ,@Email </param>
        /// <returns></returns>
        public bool InsertNV(object[] para)
        {
            try
            {

                return dataProvider.ExecuteNonQuery("EXECUTE USP_InsertNV @Ten , @Chuc , @DiaChi , @SDT , @Email", para) > 0;
                //throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Trả về true nếu cập nhật thành công
        /// Thứ tự paramater @ID , @name , @phone , @sex , @address , @level  
        /// </summary>
        /// <param name="para"> Thứ tự paramater @ID , @name , @phone , @sex , @address , @level </param>
        /// <returns></returns>
        public bool UpdateKH(object[] para)
        {
            try
            {

                return dataProvider.ExecuteNonQuery("EXECUTE USP_UpdateKH @ID , @name , @phone , @sex , @address , @level ", para) > 0;
                //throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Trả về true nếu cập nhật thành công
        /// Paramater theo thứ tự @MaNV , @Ten , @Chuc , @DiaChi , @SDT , @Email  ; trong đó @MaNV là thứ ta để xác định NV
        /// </summary>
        /// <param name="para">thứ tự @MaNV , @Ten , @Chuc , @DiaChi , @SDT , @Email  </param>
        /// <returns></returns>
        public bool UpdateNV(object[] para)
        {
            try
            {

                return dataProvider.ExecuteNonQuery("EXECUTE USP_UpdateNVWithoutPassAndNameSignIn @MaNV , @Ten , @Chuc , @DiaChi , @SDT , @Email ", para) > 0;
                //throw new NotImplementedException();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
