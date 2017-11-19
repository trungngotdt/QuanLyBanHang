using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using QuanLyBanHang.BUS;
using QuanLyBanHang.BUS.Interfaces;
using QuanLyBanHang.DAO;
using System.Data;
using FizzWare.NBuilder;
using QuanLyBanHang.DTO;

namespace QuanLyBanHangTest.BUS
{
    [TestFixture]
    class QuanLyThongTinBUSTest
    {
        private Mock<IDataProvider> mockIDataProvider;
        private QuanLyThongTinBUS quanLyThongTinBUS;
        [SetUp]
        public void SetUp()
        {
            mockIDataProvider = new Mock<IDataProvider>();
            quanLyThongTinBUS = new QuanLyThongTinBUS(mockIDataProvider.Object);
        }


        private DataTable GenerateDataTable<T>(int rows)
        {
            var datatable = new DataTable(typeof(T).Name);
            typeof(T).GetProperties().ToList().ForEach(
                x => datatable.Columns.Add(x.Name.Remove(0, 3)));
            Builder<T>.CreateListOfSize(rows).Build()
                .ToList().ForEach(
                    x => datatable.LoadDataRow(x.GetType().GetProperties().Select(
                        y => y.GetValue(x, null)).ToArray(), true));
            return datatable;
        }


        [Test]
        public void ClassTest()
        {
            var result = typeof(QuanLyThongTinBUS).GetInterfaces().Contains(typeof(IQuanLyThongTinBUS));
            var result1 = typeof(QuanLyThongTinBUS).IsPublic;
            Assert.IsTrue(result);
            Assert.IsTrue(result1);
        }

        [Test]
        public void DataSourceForComboboxTest()
        {

            var data = GenerateDataTable<HoaDonDTO>(10);

            mockIDataProvider.Setup(x => x.ExecuteQuery(It.IsNotNull<string>(), null)).Returns(data);

            var result = quanLyThongTinBUS.DataSourceForCombobox();
            var resultExcept = data.AsEnumerable().ToList().Select(p => p.ItemArray).Select(p => p.FirstOrDefault()).OfType<String>().ToArray();
            Assert.IsTrue(result.Count() == resultExcept.Count());
            mockIDataProvider.VerifyAll();
        }

        [TestCase("query", null)]
        public void SourceCompleteTest(string query, object[] values)
        {
            var data = GenerateDataTable<HangDTO>(10);

            mockIDataProvider.Setup(x => x.ExecuteQuery(query, values)).Returns(data);
            var result = quanLyThongTinBUS.SourceComplete(query, values);
            var resultExcept = data.AsEnumerable().ToList().Select(p => p.ItemArray).Select(p => p.FirstOrDefault()).OfType<String>().ToArray();
            Assert.IsTrue(result.Count() == resultExcept.Count());
            mockIDataProvider.VerifyAll();
        }


        [Test]
        public void GetListChiTietHoaDon()
        {

            var data = GenerateDataTable<ChiTietHoaDonDTO>(10);

            mockIDataProvider.Setup(x => x.ExecuteQuery(It.IsNotNull<string>(), null)).Returns(data);
            var expectResult = new List<ChiTietHoaDonDTO>();
            foreach (DataRow item in data.Rows)
            {
                ChiTietHoaDonDTO hang = new ChiTietHoaDonDTO(item);
                expectResult.Add(hang);
            }
            bool acc = false;
            var result = quanLyThongTinBUS.GetListChiTietHoaDon();
            for (int i = 0; i < result.LongCount(); i++)
            {
                acc = result[i].FltDonGia.Equals(expectResult[i].FltDonGia) &&
                    result[i].IntMaHoaDon.Equals(expectResult[i].IntMaHoaDon) &&
                    result[i].IntSoLuong.Equals(expectResult[i].IntSoLuong) &&
                    result[i].StrMaHang.Equals(expectResult[i].StrMaHang);
            }
            //var cc= result.SequenceEqual(expectResult);
            //var first = result.Except(expectResult).ToList();
            //var second = expectResult.Except(result).ToList();
            Assert.IsTrue(acc);
            mockIDataProvider.VerifyAll();
        }

        [TestCase("name", "result")]
        [TestCase("name", "result")]
        public void GetMaHangTest(string name, object value)
        {
            mockIDataProvider.Setup(x => x.ExecuteScalar(It.IsNotNull<string>(), new object[] { name })).Returns(value);
            var result = quanLyThongTinBUS.GetMaHang(name);
            Assert.That(result.Equals(value));
            mockIDataProvider.VerifyAll();
        }


        [TestCase("123", "result")]
        [TestCase("1234", "result")]
        public void GetTenKHTest(string name, object value)
        {
            mockIDataProvider.Setup(x => x.ExecuteScalar(It.IsNotNull<string>(), new object[] { int.Parse(name) })).Returns(value);
            var result = quanLyThongTinBUS.GetTenKH(name);
            Assert.That(result.Equals(value));
            mockIDataProvider.VerifyAll();
        }


        [TestCase("123", "result")]
        [TestCase("1234", "result")]
        public void GetMaKHTest(string name, object value)
        {
            mockIDataProvider.Setup(x => x.ExecuteScalar(It.IsNotNull<string>(), new object[] { int.Parse(name) })).Returns(value);
            var result = quanLyThongTinBUS.GetMaKH(name);
            Assert.That(result.Equals(value));
            mockIDataProvider.VerifyAll();
        }

        [TestCase("name", "result")]
        [TestCase("name", "result")]
        public void LayDonGiaTest(string name, object value)
        {
            mockIDataProvider.Setup(x => x.ExecuteScalar(It.IsNotNull<string>(), new object[] { name })).Returns(value);
            var result = quanLyThongTinBUS.LayDonGia(name);
            Assert.That(result.Equals(value));
            mockIDataProvider.VerifyAll();
        }

        [TestCase("name", true)]
        [TestCase("name1", false)]
        public void SearchByTest(object values, bool correct)
        {
            var data = GenerateDataTable<HangDTO>(10);
            var str = correct == true ? values.ToString() : $"%{values.ToString()}%";
            mockIDataProvider.Setup(x => x.ExecuteQuery(It.IsNotNull<string>(), new object[] { str })).Returns(data);
            var result = quanLyThongTinBUS.SearchBy(values, correct);
            mockIDataProvider.VerifyAll();
        }

        [Test]
        public void ShowAllHangTest()
        {
            var data = GenerateDataTable<HangDTO>(10);
            mockIDataProvider.Setup(x => x.ExecuteQuery(It.IsNotNull<string>(), null)).Returns(data);
            var result = quanLyThongTinBUS.ShowAllHang();
            bool isTrue = false;
            var expectResult = new List<HangDTO>();
            foreach (DataRow item in data.Rows)
            {
                HangDTO hang = new HangDTO(item);
                expectResult.Add(hang);
            }
            for (int i = 0; i < result.LongCount(); i++)
            {
                isTrue = result[i].StrTenHang.Equals(expectResult[i].StrTenHang) &&
                    result[i].FltDonGia.Equals(expectResult[i].FltDonGia) &&
                    result[i].StrGhiChu.Equals(expectResult[i].StrGhiChu) &&
                    result[i].IntSoLuong.Equals(expectResult[i].IntSoLuong) &&
                    result[i].StrMaHang.Equals(expectResult[i].StrMaHang);
            }
            Assert.IsTrue(isTrue);
            mockIDataProvider.VerifyAll();
        }

        [TestCase(new object[]{ "namea , " ,"", " "," , "}, false)]
        [TestCase(new object[] { "name" },true)]
        public void SortBy(object[] values, bool asc)
        {

            var data = GenerateDataTable<HangDTO>(10);
            mockIDataProvider.Setup(x => x.ExecuteQuery(It.IsNotNull<string>(), null)).Returns(data);
            var result = quanLyThongTinBUS.SortBy(values , asc);
            bool isTrue = false;
            var expectResult = new List<HangDTO>();
            foreach (DataRow item in data.Rows)
            {
                HangDTO hang = new HangDTO(item);
                expectResult.Add(hang);
            }
            for (int i = 0; i < result.LongCount(); i++)
            {
                isTrue = result[i].StrTenHang.Equals(expectResult[i].StrTenHang) &&
                    result[i].FltDonGia.Equals(expectResult[i].FltDonGia) &&
                    result[i].StrGhiChu.Equals(expectResult[i].StrGhiChu) &&
                    result[i].IntSoLuong.Equals(expectResult[i].IntSoLuong) &&
                    result[i].StrMaHang.Equals(expectResult[i].StrMaHang);
            }
            Assert.IsTrue(isTrue);
            mockIDataProvider.VerifyAll();
        }

        [TestCase(123)]
        [TestCase(456)]
        public void GetKhachHangBySDTTest(int sdt)
        {
            var data = GenerateDataTable<KhachHangDTO>(1);

            mockIDataProvider.Setup(x => x.ExecuteQuery(It.IsNotNull<string>(),new object[] { sdt })).Returns(data);
            var result = quanLyThongTinBUS.GetKhachHangBySDT(sdt);
            KhachHangDTO khachHang = new KhachHangDTO(data.Rows.OfType<DataRow>().Single());
            Assert.IsTrue(result.BlnGioiTinh.Equals(khachHang.BlnGioiTinh)&&
                result.IntSDT.Equals(khachHang.IntSDT)&&
                result.StrDiaChi.Equals(khachHang.StrDiaChi)&&
                result.StrLoaiKhachHang.Equals(khachHang.StrLoaiKhachHang)&&
                result.StrMaKH.Equals(khachHang.StrMaKH)&&
                result.StrTenKH.Equals(khachHang.StrTenKH));
            mockIDataProvider.VerifyAll();
        }
    }
}
