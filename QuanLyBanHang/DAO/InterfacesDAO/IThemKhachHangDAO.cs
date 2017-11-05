using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO.InterfacesDAO
{
    public interface IThemKhachHangDAO
    {
        /// <summary>
        /// Thêm một bản ghi vào cơ sở dữ liệu và trả về số dòng bị tác động
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        int Insert(string query, object[] values = null);
    }
}
