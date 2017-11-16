using QuanLyBanHang.BUS.Interfaces;
using QuanLyBanHang.DAO.InterfacesDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang.BUS
{
    public class HoaDonThanhToanBUS : IHoaDonThanhToanBUS
    {
        private IHoaDonThanhToanDAO hoaDonThanhToan;
        public HoaDonThanhToanBUS(IHoaDonThanhToanDAO hoaDonThanhToanDAO)
        {
            this.hoaDonThanhToan = hoaDonThanhToanDAO;
        }

        /// <summary>
        /// Gán giá trị cho phần <see cref="AutoCompleteSource"/>  của <see cref="TextBox"/> 
        /// </summary>
        /// <param name="textBox"></param>
        public void AutoComplete(TextBox textBox)
        {
            try
            {
                textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox.AutoCompleteCustomSource = hoaDonThanhToan.SourceForAutoComplete("SELECT kh.TenKH FROM dbo.KhachHang kh");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Trả về giá trị của mặt hàng thông qua <paramref name="tenhang"/>
        /// </summary>
        /// <param name="tenhang"></param>
        /// <returns></returns>
        public object LayDonGia(string tenhang)
        {
            try
            {
                var donGia = hoaDonThanhToan.GetFirstValue("EXECUTE USP_GetDonGia @name", new object[] { tenhang });
                return donGia;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// trả về mảng các chuỗi <see cref="string"/> làm giá trị cho datasource của <see cref="ComboBox"/>
        /// </summary>
        /// <returns></returns>
        public string[] DataSourceForCombobox()
        {
            try
            {
                var source = hoaDonThanhToan.SourceComplete("SELECT h.TenHang FROM dbo.Hang h WHERE h.SoLuong>0");
                return source;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //throw new NotImplementedException();
        }

        /// <summary>
        /// Thêm một khách hàng vào cơ sở dữ liệu
        /// Trả về true nếu thành công ,flase nếu thất bại 
        /// Dữ liệu truyền vào theo thứ tự TenKH,SDT,GioiTinh,DiaChi,LoaiKhachHang
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool InsertKhachHang(object[] values)
        {
            try
            {
                return hoaDonThanhToan.Insert("EXEC USP_InsertKhachHang @name , @phone , @sex , @address , @level", values) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Trả về true khi chèn dữ liệu thành công ,chen dữ liệu vào bảng ChiTietHoaDon
        /// Dữ liêu chen vào phải theo thứ tự MaHoaDon,MaHang,DonGia,SoLuong
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool InsertChiTietHoaDon(object[] values = null)
        {
            try
            {
                return hoaDonThanhToan.Insert("EXEC USP_InsertChiTietHoaDon @idbill , @idgoods , @price , @number ", values) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }//throw new NotImplementedException();
        }

        /// <summary>
        /// Trả về MaHang theo TenHang
        /// </summary>
        /// <param name="tenKH"></param>
        /// <returns></returns>
        public object GetMaHang(string tenHang)
        {
            try
            {
                return hoaDonThanhToan.GetFirstValue("EXECUTE USP_GetMaHang @name", new object[] { tenHang });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Chèn dữ liệu HoaDon vào database
        /// Với các giá trị theo thứ tự MaKH,LoaiHoaDon,MaNV, NgayLap,NguoiLap
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool InsertHoaDon(object[] values)
        {
            try
            {
                return hoaDonThanhToan.Insert("EXEC USP_InsertHoaDon   @idcustomer , @typebill , @idstaff , @date , @namestaff", values) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Trả về MaKH theo SDT
        /// </summary>
        /// <param name="tenKH"></param>
        /// <returns></returns>
        public object GetMaKH(string sdtKH)
        {
            try
            {
                return hoaDonThanhToan.GetFirstValue("EXECUTE USP_GetMaKHBySDT  @sdt", new object[] { int.Parse(sdtKH) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Trả về TenKhachHang dựa vào SDT
        /// </summary>
        /// <param name="sdt"></param>
        /// <returns></returns>
        public object GetTenKH(string sdt)
        {
            try
            {
                return hoaDonThanhToan.GetFirstValue("EXECUTE USP_GetTenKH @sdt", new object[] { int.Parse(sdt) });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Trả về giá trị MaHoaDon
        /// </summary>
        /// <param name="MaKH"></param>
        /// <param name="LoaiHD"></param>
        /// <param name="MaNV"></param>
        /// <param name="NgayLap"></param>
        /// <param name="TenNV"></param>
        /// <returns></returns>
        public object GetMaHoaDon(int MaKH, string LoaiHD, int MaNV, string NgayLap, string TenNV)
        {
            try
            {
                return hoaDonThanhToan.GetFirstValue("EXECUTE USP_GetMaHoaDon @idcustomer , @type , @idstaff , @date , @namestaff ", new object[] { MaKH, LoaiHD, MaNV, NgayLap, TenNV });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Cập nhật số lượng hàng trong kho theo mả hàng
        /// Theo thứ tự MaHang , Soluong mới 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public bool UpdateHangHoa(object[] values = null)
        {
            try
            {
                return hoaDonThanhToan.Update("EXECUTE USP_UpdateSoLuongHang @idgoods , @number ", values) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Lấy số lượng hàng dựa vào mã hàng
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public object GetSoLuong(object[] values = null)
        {
            try
            {
                return hoaDonThanhToan.GetFirstValue("EXECUTE USP_GetSoLuong @idgoods ", values);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //throw new NotImplementedException();
        }
    }
}
