using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang.DTO
{
    public class HoaDonDTO
    {
        private int intMaHoaDon;
        private int intMaKH;
        private string strLoaiHoaDon;
        private int intMaNV;
        private DateTime dtmNgayLap;
        private string strNguoiLap;

        public int IntMaHoaDon { get => intMaHoaDon; set => intMaHoaDon = value; }
        public int IntMaKH { get => intMaKH; set => intMaKH = value; }
        public string StrLoaiHoaDon { get => strLoaiHoaDon; set => strLoaiHoaDon = value; }
        public int IntMaNV { get => intMaNV; set => intMaNV = value; }
        public DateTime DtmNgayLap { get => dtmNgayLap; set => dtmNgayLap = value; }
        public string StrNguoiLap { get => strNguoiLap; set => strNguoiLap = value; }

        public HoaDonDTO()
        {

        }
        public HoaDonDTO(int MaHoaDon,int MaKH,string LoaiHoaDon,int MaNV,DateTime NgayLap,string NguoiLap)
        {
            this.StrLoaiHoaDon = LoaiHoaDon;
            this.IntMaHoaDon = MaHoaDon;
            this.IntMaKH = MaKH;
            this.IntMaNV = MaNV;
            this.DtmNgayLap = NgayLap;
            this.StrNguoiLap = NguoiLap;
        }
    }
}
