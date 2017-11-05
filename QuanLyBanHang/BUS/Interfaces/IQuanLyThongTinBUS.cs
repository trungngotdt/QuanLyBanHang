using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.BUS.Interfaces
{
    public interface IQuanLyThongTinBUS
    {
        /// <summary>
        /// Lấy khách hàng theo số điện thoại
        /// </summary>
        /// <param name="sdt"></param>
        /// <returns></returns>
        DTO.KhachHangDTO GetKhachHangBySDT(int sdt);

        /// <summary>
        /// Trả về giá trị của mặt hàng thông qua <paramref name="tenhang"/>
        /// </summary>
        /// <param name="tenhang"></param>
        /// <returns></returns>
        object LayDonGia(string tenhang);

        /// <summary>
        /// Trả về MaHang theo TenHang
        /// </summary>
        /// <param name="tenKH"></param>
        /// <returns></returns>
        object GetMaHang(string tenHang);

        /// <summary>
        /// trả về mảng các chuỗi <see cref="string"/> làm giá trị cho datasource của <see cref="ComboBox"/>
        /// </summary>
        /// <returns></returns>
        string[] DataSourceForCombobox();
        /// <summary>
        ///Trả về Tên khách hành theo sdt 
        /// </summary>
        /// <param name="sdtKH"></param>
        /// <returns></returns>
        object GetTenKH(string sdtKH);

        /// <summary>
        /// Trả về MaKhach theo SDT
        /// </summary>
        /// <param name="tenKH"></param>
        /// <returns></returns>
        object GetMaKH(string sdtKH);

        /// <summary>
        /// Trả về danh sách ChiTietHoaDon
        /// </summary>
        /// <returns></returns>
        List<DTO.ChiTietHoaDonDTO> GetListChiTietHoaDon();
        
        /// <summary>
        /// Trả về kết quả sau khi tìm kiếm theo yêu cầu
        /// </summary>
        /// <param name="values"></param>
        /// <param name="correct"></param>
        /// <returns></returns>
        List<QuanLyBanHang.DTO.HangDTO> SearchBy(object values, bool correct);

        /// <summary>
        /// Sắp xếp tăng giảm theo yêu cầu
        /// </summary>
        /// <param name="values"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        List<DTO.HangDTO> SortBy(object[] values, bool asc);

        /// <summary>
        /// Hiển thị tất cả dữ liệu về hàng
        /// </summary>
        /// <returns></returns>
        List<DTO.HangDTO> ShowAllHang();
    }
}
