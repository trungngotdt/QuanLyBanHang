using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO.InterfacesDAO
{
    public interface IQuanLyDAO
    {
        /// <summary>
        /// Lấy dữ liệu ở cột đầu dòng đầu 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        object GetFirstData(string query, object[] para = null);

        /// <summary>
        /// Trả về số dòng thêm vào thành công
        /// </summary>
        /// <param name="query"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        int Insert(string query, object[] para = null);

        /// <summary>
        /// Trả về số dòng cập nhật thành công
        /// </summary>
        /// <param name="query"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        int Update(string query, object[] para = null);

        /// <summary>
        /// Lấy tất cả dữ liệu theo câu truy vấn
        /// </summary>
        /// <param name="query"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        System.Data.DataTable GetData(string query, object[] para = null);
    }
}
