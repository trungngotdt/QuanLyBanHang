using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DAO.InterfacesDAO
{
    public interface IHoaDonThanhToanDAO
    {
        /// <summary>
        ///Cập nhật và trả về số dòng được cập nhật 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        int Update(string query, object[] values = null);

        /// <summary>
        /// Chèn một dòng dữ liệu vào dự vào các tình huống cụ thể
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        int Insert(string query, object[] values = null);

        /// <summary>
        /// Chèn một dòng chi tiết hóa đơn vào bàng ChiTietHoaDon
        /// Trả về số dòng bị tác động trong trường hợp này là dòng được chèn vào ( là 1 dòng)
        /// </summary>
        /// <param name="query"></param>
        /// <param name="valuse"></param>
        /// <returns></returns>
        int InsertChiTietHoaDon(string query, object[] values = null);

        /// <summary>
        /// Chèn một dòng hóa đơn vào bàng HoaDon
        /// Trả về số dòng bị tác động trong trường hợp này là dòng được chèn vào ( là 1 dòng)
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        int InsertHoaDon(string query, object[] values = null);

        /// <summary>
        /// trả về giá trị đầu tiên khi truy vấn
        /// </summary>
        /// <param name="query"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        object GetFirstValue(string query, object[] para = null);

        /// <summary>
        /// trả về chuổi <see cref="string"/> có thể lấy làm dữ liệu cho các gợi ý
        /// </summary>
        /// <returns></returns>
        string[] SourceComplete(string query, object[] values = null);

        /// <summary>
        /// Trả về chuỗi <see cref="AutoCompleteStringCollection"/> phục vụ cho chức năng AutoComplete của TextBox
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        System.Windows.Forms.AutoCompleteStringCollection SourceForAutoComplete( string query, object[] values = null);

        /// <summary>
        /// Thêm một khách hàng vào danh sách khách hàng bằng lệnh query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        bool InsertKhachHang(string query,object[] values=null);
    }
}
