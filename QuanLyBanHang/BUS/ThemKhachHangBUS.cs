using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.BUS.Interfaces;
using QuanLyBanHang.DAO.InterfacesDAO;

namespace QuanLyBanHang.BUS
{
    public class ThemKhachHangBUS : IThemKhachHangBUS
    {
        private IThemKhachHangDAO themKhachHang;
        public ThemKhachHangBUS(IThemKhachHangDAO themKhachHangDAO)
        {
            this.themKhachHang = themKhachHangDAO;
        }

        /// <summary>
        ///Thêm một khách hàng vào cơ sở dữ liệu .Trả về <see cref="true"/> nếu thành công và ngược lại 
        ///Theo thứ tự tên , sdt , giới tính , địa chỉ , loại khách hàng
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool InsertKhachHang(object[] values)
        {
            return themKhachHang.Insert("EXECUTE USP_InsertKhachHang @ten , @sdt , @gioitinh , @diachi , @loaikh", values)>0;
            //throw new NotImplementedException();
        }
    }
}
