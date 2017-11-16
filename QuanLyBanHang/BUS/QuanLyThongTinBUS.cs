using QuanLyBanHang.BUS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.DTO;
using QuanLyBanHang.DAO.InterfacesDAO;
using System.Data;

namespace QuanLyBanHang.BUS
{
    public class QuanLyThongTinBUS : IQuanLyThongTinBUS
    {
        private IQuanLyThongTinDAO quanLyThongTin;
        public QuanLyThongTinBUS(IQuanLyThongTinDAO quanLy)
        {
            this.quanLyThongTin = quanLy;
        }

        /// <summary>
        /// trả về mảng các chuỗi <see cref="string"/> làm giá trị cho datasource của <see cref="System.Windows.Forms.ComboBox"/>
        /// </summary>
        /// <returns></returns>
        public string[] DataSourceForCombobox()
        {
            var source = quanLyThongTin.SourceComplete("SELECT h.TenHang FROM dbo.Hang h WHERE h.SoLuong>0");
            return source;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Trả về danh sách các dòng trong bảng ChiTietHoaDon
        /// </summary>
        /// <returns></returns>
        public List<ChiTietHoaDonDTO> GetListChiTietHoaDon()
        {
            List<ChiTietHoaDonDTO> list = new List<ChiTietHoaDonDTO>();
            var data = quanLyThongTin.ShowAll("SELECT cthd.* FROM dbo.ChiTietHoaDon cthd");
            foreach (DataRow item in data.Rows)
            {
                ChiTietHoaDonDTO hang = new ChiTietHoaDonDTO(item);
                list.Add(hang);
            }
            return list;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Trả về MaKhach theo SDT
        /// </summary>
        /// <param name="tenKH"></param>
        /// <returns></returns>
        public object GetMaKH(string sdtKH)
        {
            return quanLyThongTin.GetFirstValue("EXECUTE USP_GetMaKHBySDT  @sdt", new object[] { int.Parse(sdtKH) });
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Trả về MaHang theo TenHang
        /// </summary>
        /// <param name="tenKH"></param>
        /// <returns></returns>
        public object GetMaHang(string tenHang)
        {
            return quanLyThongTin.GetFirstValue("EXECUTE USP_GetMaHang @name", new object[] { tenHang });
        }

        /// <summary>
        /// Trả về tên Khách hàng thông qua SDT
        /// </summary>
        /// <param name="sdtKH"></param>
        /// <returns></returns>
        public object GetTenKH(string sdtKH)
        {
            return quanLyThongTin.GetFirstValue("EXECUTE USP_GetTenKH @sdt", new object[] { int.Parse(sdtKH) });
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Trả về giá trị của mặt hàng thông qua <paramref name="tenhang"/>
        /// </summary>
        /// <param name="tenhang"></param>
        /// <returns></returns>
        public object LayDonGia(string tenhang)
        {
            var donGia = quanLyThongTin.GetFirstValue("EXECUTE USP_GetDonGia @name", new object[] { tenhang });
            return donGia;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Trả về kết quả sau khi tìm kiếm theo yêu cầu
        /// </summary>
        /// <param name="values"></param>
        /// <param name="correct"></param>
        /// <returns></returns>
        public List<HangDTO> SearchBy(object values,bool correct)
        {
            List<HangDTO> listHang = new List<HangDTO>();
            var str = correct == true ? values.ToString() : $"%{values.ToString()}%";
            var data= quanLyThongTin.SearchBy("USP_SearchHang @name", str);
            foreach (DataRow item in data.Rows)
            {
                HangDTO hang = new HangDTO(item);
                listHang.Add(hang);
            }
            return listHang;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Hiển thị tất cả dữ liệu về hàng
        /// </summary>
        /// <returns></returns>
        public List<HangDTO> ShowAllHang()
        {
            List<HangDTO> listHang = new List<HangDTO>();
            var data = quanLyThongTin.ShowAll("SELECT h.* FROM dbo.Hang h");
            foreach (DataRow item in data.Rows)
            {
                HangDTO hang = new HangDTO(item);
                listHang.Add(hang);
            }
            return listHang;
            //throw new NotImplementedException();
        }



        /// <summary>
        /// Sắp xếp tăng giảm theo yêu cầu
        /// </summary>
        /// <param name="values"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public List<HangDTO> SortBy(object[] values, bool asc)
        {
            List<HangDTO> listHang = new List<HangDTO>();
            string query = "SELECT * FROM dbo.Hang ORDER BY ";
            string type = asc == true ? " ASC" : " DESC";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(query);
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].Equals(""))
                {
                    continue;
                }
                if (i!=0 &&query.Length!=stringBuilder.Length)
                {
                    stringBuilder.Append(" , ");
                }
                stringBuilder.Append(values[i].ToString());
                stringBuilder.Append(type);
            }            
            var data= quanLyThongTin.ShowAll(stringBuilder.ToString());
            foreach (DataRow item in data.Rows)
            {
                HangDTO hang = new HangDTO(item);
                listHang.Add(hang);
            }
            return listHang;
        }

        /// <summary>
        /// Lấy thông tin khách hàng dựa vào số điện thoại
        /// </summary>
        /// <param name="sdt"></param>
        /// <returns></returns>
        public KhachHangDTO GetKhachHangBySDT(int sdt)
        {
            var data= quanLyThongTin.ShowData("USP_GetKHBySDT @SDT",new object[] {sdt });
            KhachHangDTO khachHang = new KhachHangDTO(data.Rows.OfType<DataRow>().Single());
            return khachHang;
            //throw new NotImplementedException();
        }
    }
}
