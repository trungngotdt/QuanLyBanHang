using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.DAO.InterfacesDAO;

namespace QuanLyBanHang.DAO
{
    public class ThemKhachHangDAO : IThemKhachHangDAO
    {
        /// <summary>
        /// Thêm một bản ghi vào cơ sở dữ liệu và trả về số dòng bị tác động
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int Insert(string query, object[] values = null)
        {
            return DataProvider2.Instance.ExecuteNonQuery(query, values);
            //throw new NotImplementedException();
        }
    }
}
