using QuanLyBanHang.DAO.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.DAO
{
    public class HoaDonThanhToanDAO : IHoaDonThanhToanDAO
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
        }

        /// <summary>
        /// Chèn một dòng dữ liệu vào dự vào các tình huống cụ thể
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int Insert(string query, object[] values = null)
        {
            int count = 0;
            count = DataProvider2.Instance.ExecuteNonQuery(query, values);
            return count;
        }

        /// <summary>
        /// Chèn một dòng chi tiết hóa đơn vào bàng ChiTietHoaDon
        /// Trả về số dòng bị tác động trong trường hợp này là dòng được chèn vào ( là 1 dòng)
        /// </summary>
        /// <param name="query"></param>
        /// <param name="valuse"></param>
        /// <returns></returns>
        public int InsertChiTietHoaDon(string query, object[] values = null)
        {
            int count = 0;
            count = DataProvider2.Instance.ExecuteNonQuery(query, values);
            return count;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Chèn một dòng hóa đơn vào bàng HoaDon
        /// Trả về số dòng bị tác động trong trường hợp này là dòng được chèn vào ( là 1 dòng)
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int InsertHoaDon(string query, object[] values = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Thêm một khách hàng vào danh sách khách hàng bằng lệnh query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool InsertKhachHang(string query, object[] values = null)
        {
            return DataProvider2.Instance.ExecuteNonQuery(query, values) > 0;
            //throw new NotImplementedException();
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
        }



        /// <summary>
        /// Trả về chuỗi <see cref="AutoCompleteStringCollection"/> phục vụ cho chức năng AutoComplete của TextBox
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public AutoCompleteStringCollection SourceForAutoComplete(string query, object[] values = null)
        {
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            autoCompleteStringCollection.AddRange(SourceComplete(query, values));
            return autoCompleteStringCollection;
            //throw new NotImplementedException();
        }

        /// <summary>
        ///Cập nhật và trả về số dòng được cập nhật 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public int Update(string query, object[] values = null)
        {
            return DataProvider2.Instance.ExecuteNonQuery(query, values);
            //throw new NotImplementedException();
        }
    }
}
