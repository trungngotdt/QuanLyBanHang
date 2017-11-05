using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO.InterfacesDAO
{
    public interface IQuanLyThongTinDAO
    {
        System.Data.DataTable ShowData(string query,object[] para=null);

        /// <summary>
        /// trả về chuổi <see cref="string"/> có thể lấy làm dữ liệu cho các gợi ý
        /// </summary>
        /// <returns></returns>
        string[] SourceComplete(string query, object[] values = null);

        /// <summary>
        /// trả về giá trị đầu tiên khi truy vấn
        /// </summary>
        /// <param name="query"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        object GetFirstValue(string query, object[] para = null);

        /// <summary>
        /// Tìm kiếm và trả về kết quả dạng bảng
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        System.Data.DataTable SearchBy(string query, object values);

        /// <summary>
        /// Lấy và trả về toàn bộ dữ liệu dự theo truy vấn
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        System.Data.DataTable ShowAll(string query);
    }
}
