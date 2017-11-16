using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Moq;
using NUnit.Framework;
using QuanLyBanHang.DAO.InterfacesDAO;
using QuanLyBanHang.BUS;
using QuanLyBanHang.BUS.Interfaces;

namespace QuanLyBanHangTest.BUS
{
    [TestFixture]
    class HoaDonThanhToanBUSTest
    {

        private Mock<IHoaDonThanhToanDAO> mockIHoaDonThanhToanDAO;
        private HoaDonThanhToanBUS hoaDonThanhToanBUS;

        [SetUp]
        public void SetUp()
        {
            mockIHoaDonThanhToanDAO = new Mock<IHoaDonThanhToanDAO>();
            hoaDonThanhToanBUS = new HoaDonThanhToanBUS(mockIHoaDonThanhToanDAO.Object);
        }

        [Test]
        public void ClassTest()
        {
            var result = typeof(HoaDonThanhToanBUS).GetInterfaces().Contains(typeof(IHoaDonThanhToanBUS));
            var result1 = typeof(HoaDonThanhToanBUS).IsPublic;
            Assert.IsTrue(result);
            Assert.IsTrue(result1);
        }

        [TestCase("value1", "value2")]
        public void AutoCompleteTest(string value1, string value2)
        {
            var array = new string[] { value1, value2 };
            var valueResult = new System.Windows.Forms.AutoCompleteStringCollection();
            valueResult.AddRange(array);
            mockIHoaDonThanhToanDAO.Setup(x => x.SourceForAutoComplete(It.IsNotNull<string>(), null)).Returns(valueResult);
            hoaDonThanhToanBUS.AutoComplete(new System.Windows.Forms.TextBox());
            mockIHoaDonThanhToanDAO.VerifyAll();
        }

        [Test]
        public void AutoCompleTestException()
        {
            try
            {
                mockIHoaDonThanhToanDAO.Setup(x => x.SourceForAutoComplete(It.IsNotNull<string>(), null)).Throws(new Exception());
                hoaDonThanhToanBUS.AutoComplete(new System.Windows.Forms.TextBox());
            }
            catch (Exception ex)
            {
                Assert.That(ex.GetType() == typeof(Exception));
                mockIHoaDonThanhToanDAO.VerifyAll();
            }
        }

        [TestCase("name", "value")]
        [TestCase("name1", "value1")]
        public void LayDonGiaTest(string name, string value)
        {
            mockIHoaDonThanhToanDAO.Setup(x => x.GetFirstValue(It.IsNotNull<string>(), new object[] { name })).Returns(value);
            var result = hoaDonThanhToanBUS.LayDonGia(name);
            mockIHoaDonThanhToanDAO.VerifyAll();
            Assert.IsTrue(result.Equals(value));

        }

        [Test]
        public void LayDonGiaTestException()
        {
            try
            {
                mockIHoaDonThanhToanDAO.Setup(x => x.GetFirstValue(It.IsNotNull<string>(), new object[] { null })).Throws(new Exception());
                hoaDonThanhToanBUS.LayDonGia(null);
            }
            catch (Exception ex)
            {
                mockIHoaDonThanhToanDAO.VerifyAll();
                Assert.IsTrue(ex.GetType() == typeof(Exception));
            }
        }

        [TestCase("value", "value1")]
        public void DataSourceForComboboxTest(string value, string value1)
        {
            mockIHoaDonThanhToanDAO.Setup(x => x.SourceComplete(It.IsNotNull<string>(), null)).Returns(new string[] { value, value1 });
            var result = hoaDonThanhToanBUS.DataSourceForCombobox();
            mockIHoaDonThanhToanDAO.VerifyAll();
            Assert.IsTrue(result.Count<string>() == 2);
        }

        [Test]
        public void DataSourceForComboboxTestException()
        {
            try
            {
                mockIHoaDonThanhToanDAO.Setup(x => x.SourceComplete(It.IsNotNull<string>(), null)).Throws(new Exception());
                hoaDonThanhToanBUS.DataSourceForCombobox();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(Exception));
            }
        }

        [Test]
        public void InsertKhachHangTest()
        {
            mockIHoaDonThanhToanDAO.Setup(x => x.Insert(It.IsNotNull<string>(), new object[] { "value", "value1", "value2", "value3", "value4" })).Returns(1);
            mockIHoaDonThanhToanDAO.Setup(x => x.Insert(It.IsNotNull<string>(), new object[] { "value0", "value1", "value2", "value3", "value4" })).Returns(0);

            var result = hoaDonThanhToanBUS.InsertKhachHang(new object[] { "value", "value1", "value2", "value3", "value4" });
            var result1 = hoaDonThanhToanBUS.InsertKhachHang(new object[] { "value0", "value1", "value2", "value3", "value4" });

            mockIHoaDonThanhToanDAO.VerifyAll();
            Assert.IsTrue(result);
            Assert.IsFalse(result1);
        }

        [Test]
        public void InsertKhachHangTestException()
        {
            try
            {
                mockIHoaDonThanhToanDAO.Setup(x => x.Insert(It.IsNotNull<string>(), null)).Throws(new Exception());
                hoaDonThanhToanBUS.InsertKhachHang(null);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(Exception));
                mockIHoaDonThanhToanDAO.VerifyAll();
            }
        }

        [TestCase(new object[] { "value", "value1", "value2", "value3" }, 1, true)]
        [TestCase(new object[] { "value0", "value1", "value2", "value3" }, 0, false)]
        public void InsertChiTietHoaDonTest(object[] array, int value, bool valueReslut)
        {
            mockIHoaDonThanhToanDAO.Setup(x => x.Insert(It.IsNotNull<string>(), array)).Returns(value);
            var reslut = hoaDonThanhToanBUS.InsertChiTietHoaDon(array);
            Assert.IsTrue(reslut == valueReslut);
            mockIHoaDonThanhToanDAO.VerifyAll();
        }

        [Test]
        public void InsertChiTietHoaDonTestException()
        {
            try
            {
                mockIHoaDonThanhToanDAO.Setup(x => x.Insert(It.IsNotNull<string>(), null)).Throws(new Exception());
                hoaDonThanhToanBUS.InsertChiTietHoaDon(null);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(Exception));
                mockIHoaDonThanhToanDAO.VerifyAll();
            }
        }

        [TestCase("name", "value")]
        [TestCase("name1", "value1")]
        public void GetMaHangTest(string name, string value)
        {
            mockIHoaDonThanhToanDAO.Setup(x => x.GetFirstValue(It.IsNotNull<string>(), new object[] { name })).Returns(value);
            var result = hoaDonThanhToanBUS.GetMaHang(name);
            Assert.AreEqual(result, value);
            mockIHoaDonThanhToanDAO.VerifyAll();
        }

        [TestCase("name")]
        [TestCase(null)]
        public void GetMaHangTestException(string name)
        {
            try
            {
                mockIHoaDonThanhToanDAO.Setup(x => x.GetFirstValue(It.IsNotNull<string>(), new object[] { name })).Throws(new Exception());
                hoaDonThanhToanBUS.GetMaHang(name);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(Exception));
                mockIHoaDonThanhToanDAO.VerifyAll();
            }
        }


        [TestCase(new object[] { "value", "value1", "value2", "value3" }, 1, true)]
        [TestCase(new object[] { "value0", "value1", "value2", "value3" }, 0, false)]
        public void InsertHoaDonTest(object[] array, int value, bool valueReslut)
        {
            mockIHoaDonThanhToanDAO.Setup(x => x.Insert(It.IsNotNull<string>(), array)).Returns(value);
            var result = hoaDonThanhToanBUS.InsertHoaDon(array);

            Assert.IsTrue(result == valueReslut);
            mockIHoaDonThanhToanDAO.VerifyAll();
        }

        [TestCase(new object[] { "value", "value1", "value2", "value3" }, typeof(Exception))]
        [TestCase(new object[] { null }, typeof(Exception))]
        public void InsertHoaDonTestException(object[] array, Type type)
        {
            try
            {
                mockIHoaDonThanhToanDAO.Setup(x => x.Insert(It.IsNotNull<string>(), array)).Throws(new Exception());
                hoaDonThanhToanBUS.InsertHoaDon(array);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == type);
                mockIHoaDonThanhToanDAO.VerifyAll();
            }
        }

        [TestCase("321", "value")]
        [TestCase("123", "value1")]
        public void GetMaKHTest(string number, string value)
        {
            mockIHoaDonThanhToanDAO.Setup(x => x.GetFirstValue(It.IsNotNull<string>(), new object[] { int.Parse(number) })).Returns(value);
            var reslut = hoaDonThanhToanBUS.GetMaKH(number);

            Assert.AreEqual(reslut, value);
            mockIHoaDonThanhToanDAO.VerifyAll();
        }

        [TestCase("123", typeof(Exception))]
        [TestCase(null, typeof(System.Reflection.TargetInvocationException))]
        public void GetMaKHTestException(string number, Type value)
        {
            try
            {
                mockIHoaDonThanhToanDAO.Setup(x => x.GetFirstValue(It.IsNotNull<string>(), new object[] { int.Parse(number) })).Throws(new Exception());
                hoaDonThanhToanBUS.GetMaKH(number);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == value);
                mockIHoaDonThanhToanDAO.VerifyAll();
            }
        }


        [TestCase("321", "value")]
        [TestCase("123", "value1")]
        public void GetTenKHTest(string number, string value)
        {

            mockIHoaDonThanhToanDAO.Setup(x => x.GetFirstValue(It.IsNotNull<string>(), new object[] { int.Parse(number) })).Returns(value);
            var reslut = hoaDonThanhToanBUS.GetTenKH(number);

            Assert.AreEqual(reslut, value);
            mockIHoaDonThanhToanDAO.VerifyAll();
        }

        [TestCase("123", typeof(Exception))]
        [TestCase(null, typeof(TargetInvocationException))]
        public void GetTenKHTestException(string number, Type value)
        {
            try
            {
                mockIHoaDonThanhToanDAO.Setup(x => x.GetFirstValue(It.IsNotNull<string>(), new object[] { int.Parse(number) })).Throws(new Exception());
                var exception = Assert.Catch<Exception>(() => hoaDonThanhToanBUS.GetTenKH(number));
                Assert.IsTrue(exception.GetType() == value);
                mockIHoaDonThanhToanDAO.VerifyAll();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == value);
            }
                
        }

        [TestCase(new object[]{ 1, "value1", 2, "value2", "value3"},"value")]
        [TestCase(new object[] { 2, "value2", 2, "value3", "value4" }, "value5")]
        public void GetMaHoaDonTest(object[] array,object value)
        {
            mockIHoaDonThanhToanDAO.Setup(x => x.GetFirstValue(It.IsNotNull<string>(), array)).Returns(value);
            var result = hoaDonThanhToanBUS.GetMaHoaDon((int) array[0], array[1].ToString(),(int) array[2], array[3].ToString(), array[4].ToString());

            Assert.IsTrue(value.Equals(result));
            mockIHoaDonThanhToanDAO.VerifyAll();
        }

        [Test]
        public void GetMaHoaDonTestException()
        {
            var array = new object[] { 1, "value1", 2, "value2", "value3" };
            var arrayNull = new object[] { 1,null,1,null,null };
            mockIHoaDonThanhToanDAO.Setup(x => x.GetFirstValue(It.IsNotNull<string>(), array)).Throws(new Exception());
            mockIHoaDonThanhToanDAO.Setup(x => x.GetFirstValue(It.IsNotNull<string>(), arrayNull)).Throws(new Exception());

            var exception = Assert.Catch<Exception>(
                () => hoaDonThanhToanBUS.GetMaHoaDon((int)array[0], array[1].ToString(), (int)array[2], array[3].ToString(), array[4].ToString()));

            var exceptionNull = Assert.Catch<Exception>(
                () => hoaDonThanhToanBUS.GetMaHoaDon(1,null,1,null,null));

            Assert.IsTrue(typeof(Exception) == exceptionNull.GetType());

            Assert.IsTrue(typeof( Exception) == exception.GetType());
            mockIHoaDonThanhToanDAO.VerifyAll();
        }

        [TestCase(new object[] { "id1", "number1" },true,1)]
        [TestCase(new object[] {"id","number" },true,1)]
        public void UpdateHangHoaTest(object[] arg,bool value,int number)
        {
            mockIHoaDonThanhToanDAO.Setup(x => x.Update(It.IsNotNull<string>(), arg)).Returns(number);
            var result = hoaDonThanhToanBUS.UpdateHangHoa(arg);
            Assert.IsTrue(result == value);
            mockIHoaDonThanhToanDAO.VerifyAll();
        }


        [TestCase(new object[] { "id1", "number1" }, typeof(Exception))]
        [TestCase(new object[] { "id"}, typeof(Exception))]
        [TestCase(new object[] { null }, typeof(Exception))]
        public void UpdateHangHoaTestException(object[] arg, Type value)
        {
            mockIHoaDonThanhToanDAO.Setup(x => x.Update(It.IsNotNull<string>(), arg)).Throws(new Exception());
            var exception = Assert.Catch<Exception>(
                () => hoaDonThanhToanBUS.UpdateHangHoa(arg));
            Assert.IsTrue(value == exception.GetType());
            //mockIHoaDonThanhToanDAO.Setup(x => x.Update(It.IsNotNull<string>(), arg)).Returns(number);
        }

        [TestCase(new object[] {"id" },"value")]
        [TestCase(new object[] { "id1" }, "value1")]
        public void GetSoLuongTest(object[] array,object value)
        {
            mockIHoaDonThanhToanDAO.Setup(x => x.GetFirstValue(It.IsNotNull<string>(), array)).Returns(value);
            var reslut = hoaDonThanhToanBUS.GetSoLuong(array);
            Assert.IsTrue(reslut.Equals(value));
        }


        [TestCase(new object[] { "id" }, typeof(Exception))]
        [TestCase(new object[] { "id1" }, typeof(Exception))]
        public void GetSoLuongTestException(object[] array, Type value)
        {
            mockIHoaDonThanhToanDAO.Setup(x => x.GetFirstValue(It.IsNotNull<string>(), array)).Throws(new Exception());
            var exception = Assert.Catch<Exception>(
                () => hoaDonThanhToanBUS.GetSoLuong(array));

            Assert.IsTrue(value== exception.GetType());
        }
    }
}
