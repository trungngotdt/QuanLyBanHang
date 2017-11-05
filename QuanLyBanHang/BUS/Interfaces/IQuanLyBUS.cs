using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS.Interfaces
{
    public interface IQuanLyBUS
    {
        /// <summary>
        /// Lấy tất cả dữ liệu về khách hàng
        /// </summary>
        /// <returns></returns>
        System.Data.DataTable GetDataKH();

        /// <summary>
        /// Trả về true nếu cập nhật thành công
        /// Thứ tự paramater @ID , @name , @phone , @sex , @address , @level  
        /// </summary>
        /// <param name="para"> Thứ tự paramater @ID, @name , @phone , @sex , @address , @level </param>
        /// <returns></returns>
        bool UpdateKH(object[] para);

        /// <summary>
        /// Trả về true nếu thêm thành công
        /// Thứ tự paramater @name , @phone , @sex , @address , @level  trong đó mã khách hàng là tự động tăng
        /// </summary>
        /// <param name="para">Thứ tự paramater @name , @phone , @sex , @address , @level </param>
        /// <returns></returns>
        bool InsertKH(object[] para);

        /// <summary>
        /// Trả về true nếu thêm thành công.
        /// Thứ tự paramater @Ten , @Chuc ,@DiaChi ,@SDT ,@Email .
        /// Trong đó Tên Đăng Nhập và Mật khẩu mật định là @Ten và @SDT
        /// </summary>
        /// <param name="para">Thứ tự paramater @Ten , @Chuc ,@DiaChi ,@SDT ,@Email </param>
        /// <returns></returns>
        bool InsertNV(object[] para);

        /// <summary>
        /// Trả về true nếu cập nhật thành công
        /// Paramater theo thứ tự @MaNV , @Ten , @Chuc , @DiaChi , @SDT , @Email  ; trong đó @MaNV là thứ ta để xác định NV
        /// </summary>
        /// <param name="para">thứ tự @MaNV , @Ten , @Chuc , @DiaChi , @SDT , @Email  </param>
        /// <returns></returns>
        bool UpdateNV(object[] para);

        /// <summary>
        /// Lấy tất cả dữ liệu về Nhân Viên
        /// </summary>
        /// <returns></returns>
        System.Data.DataTable GetDataNV();
    }
}
