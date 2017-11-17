using QuanLyBanHang.DAO.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyBanHang.DAO
{
    public class QuanLyThongTinDAO : IQuanLyThongTinDAO
    {
        /// <summary>
        /// trả về giá trị đầu tiên khi truy vấn
        /// </summary>
        /// <param name="query"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public object GetFirstValue(string query, object[] para = null)
        {
            return DataProvider2.Instance.ExecuteScalar(query, para);
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Tìm kiếm và trả về kết quả dạng bảng
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataTable SearchBy(string query, object values)
        {
            return DataProvider2.Instance.ExecuteQuery(query,new object[] { values });
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Lấy và trả về toàn bộ dữ liệu dự theo truy vấn
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataTable ShowAll(string query)
        {
            return DataProvider2.Instance.ExecuteQuery(query);
        }

        /// <summary>
        /// Hiển thị tất cả các dữ liệu với 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public DataTable ShowData(string query, object[] para = null)
        {
            return DataProvider2.Instance.ExecuteQuery(query,para);
        }

        /// <summary>
        /// trả về chuổi <see cref="string"/> có thể lấy làm dữ liệu cho các gợi ý
        /// </summary>
        /// <returns></returns>
        public string[] SourceComplete(string query, object[] values = null)
        {
            var data = DataProvider2.Instance.ExecuteQuery(query, values);
            var source = data.AsEnumerable().ToList().Select(p => p.ItemArray).Select(p => p.FirstOrDefault()).OfType<String>().ToArray();
            return source;
            //throw new NotImplementedException();
        }
    }
}
