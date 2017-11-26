using QuanLyBanHang.BUS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.DTO;
using System.Data;
using QuanLyBanHang.DAO;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyBanHang.BUS
{
    public class QuanLyThongTinBUS : IQuanLyThongTinBUS
    {
        private IDataProvider dataProvider;

        public QuanLyThongTinBUS(IDataProvider data)
        {
            this.dataProvider = data;
        }


        /// <summary>
        /// trả về chuổi <see cref="string"/> có thể lấy làm dữ liệu cho các gợi ý
        /// </summary>
        /// <returns></returns>
        public string[] SourceComplete(string query, object[] values = null)
        {
            var data = dataProvider.ExecuteQuery(query, values);
            var source = data.AsEnumerable().ToList().Select(p => p.ItemArray).Select(p => p.FirstOrDefault()).OfType<String>().ToArray();
            return source;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// trả về mảng các chuỗi <see cref="string"/> làm giá trị cho datasource của <see cref="System.Windows.Forms.ComboBox"/>
        /// </summary>
        /// <returns></returns>
        public string[] DataSourceForCombobox()
        {
            var source = SourceComplete("SELECT h.TenHang FROM dbo.Hang h WHERE h.SoLuong>0");
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
            var data = dataProvider.ExecuteQuery("SELECT cthd.* FROM dbo.ChiTietHoaDon cthd");
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
            return dataProvider.ExecuteScalar("EXECUTE USP_GetMaKHBySDT  @sdt", new object[] { int.Parse(sdtKH) });
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Trả về MaHang theo TenHang
        /// </summary>
        /// <param name="tenKH"></param>
        /// <returns></returns>
        public object GetMaHang(string tenHang)
        {
            return dataProvider.ExecuteScalar("EXECUTE USP_GetMaHang @name", new object[] { tenHang });
        }

        /// <summary>
        /// Trả về tên Khách hàng thông qua SDT
        /// </summary>
        /// <param name="sdtKH"></param>
        /// <returns></returns>
        public object GetTenKH(string sdtKH)
        {
            return dataProvider.ExecuteScalar("EXECUTE USP_GetTenKH @sdt", new object[] { int.Parse(sdtKH) });
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Trả về giá trị của mặt hàng thông qua <paramref name="tenhang"/>
        /// </summary>
        /// <param name="tenhang"></param>
        /// <returns></returns>
        public object LayDonGia(string tenhang)
        {
            var donGia = dataProvider.ExecuteScalar("EXECUTE USP_GetDonGia @name", new object[] { tenhang });
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
            var data= dataProvider.ExecuteQuery("USP_SearchHang @name",new object[] { str });
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
            var data = dataProvider.ExecuteQuery("SELECT h.* FROM dbo.Hang h");
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
            var data= dataProvider.ExecuteQuery(stringBuilder.ToString());
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
            var data= dataProvider.ExecuteQuery("USP_GetKHBySDT @SDT",new object[] {sdt });
            KhachHangDTO khachHang = new KhachHangDTO(data.Rows.OfType<DataRow>().Single());
            return khachHang;
            //throw new NotImplementedException();
        }


        public Workbooks GetWorkBooks(_Application application)
        {
            Workbooks workbooks = application.Workbooks;
            return workbooks;
        }

        public Worksheet GetWorkSheet(Workbooks workbooks, string address)
        {
            var resultworkbooks = workbooks.Open(address).Worksheets[1];
            return resultworkbooks;
        }

        public Range GetRange(Worksheet worksheet)
        {
            var range = worksheet.UsedRange;
            return range;
        }

        public Range GetRangeValueWithIndex(Range range, int i, int j)
        {
            Range result = range[i, j];
            return result;
        }

        public string GetValueOfRange(Range range)
        {
            object value = range.Value2 == null ? "null" : range.Value2; ;
            return value.ToString();
        }

        public Task<List<Tuple<string, string, string, string, string>>> ReadAsync(_Application application, string address)
        {
            return Task.Factory.StartNew(() => ReadWithInteropExcel(application, address));
            //throw new NotImplementedException();
        }

        public List<Tuple<string, string, string, string, string>> ReadWithInteropExcel(_Application application,string address)
        {
            object row;
            object row2;
            object row3;
            object row4;
            object row5;

            List < Tuple < string, string, string, string, string>> list = new List<Tuple<string, string, string, string, string>>();
            var workBooks = GetWorkBooks(application);
            var workSheet = GetWorkSheet(workBooks, address);
            var range = GetRange(workSheet);
            int countRow = range.Rows.Count;
            int countColumn = range.Columns.Count;
            for (int i = 2; i <= countRow; i++)
            {
                for (int j = 1; j <= countColumn; j++)
                {
                    var value1 = GetRangeValueWithIndex(range, i, j);
                    row = GetValueOfRange(value1); //worksheet.Cells[i, j].Value2==null?"a":"b";
                    j++;
                    var value2 = GetRangeValueWithIndex(range, i, j);
                    row2 = GetValueOfRange(value2);// worksheet.Cells[i, j].Value2;

                    j++;
                    var value3 = GetRangeValueWithIndex(range, i, j);
                    row3 = GetValueOfRange(value3) ;
                    j++;
                    var value4 = GetRangeValueWithIndex(range, i, j);
                    row4 = GetValueOfRange(value4);
                    j++;
                    var value5 = GetRangeValueWithIndex(range, i, j);
                    row5 = GetValueOfRange(value2);

                    list.Add(new Tuple<string, string, string, string, string>(row.ToString(), row2.ToString(), row3.ToString(), row4.ToString(), row5.ToString()));

                }
            }
            workBooks.Close();
            return list;
            //throw new NotImplementedException();
        }
    }
}
