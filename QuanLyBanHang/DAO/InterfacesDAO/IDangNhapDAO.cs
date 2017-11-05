using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO.InterfacesDAO
{
    public interface IDangNhapDAO
    {
        /// <summary>
        /// Lấy dữ liệu ở cột đầu dòng đầu 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        object GetFirstData(string query, object[] para = null);


        /// <summary>
        /// Trả về giá trị chức vụ theo tên
        /// </summary>
        /// <param name="query"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        object ChucVu(string query,object[] name);

        /// <summary>
        /// Trả về password đã băm
        /// </summary>
        /// <param name="query"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        int GetPassHashCode(string query, string name);
    }
}
