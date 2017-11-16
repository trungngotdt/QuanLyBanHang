using Moq;
using NUnit.Framework;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLyBanHang.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyBanHang.DAO.InterfacesDAO;

namespace QuanLyBanHang.BUS.Tests
{
    [TestFixture]
    public class DangNhapBUSTests
    {
        private Mock<IDangNhapDAO> mockIDangNhapDAO;
        private DangNhapBUS dangNhapBUS;

        [SetUp]
        public void SetUp()
        {
            mockIDangNhapDAO = new Mock<IDangNhapDAO>();
            dangNhapBUS = new DangNhapBUS(mockIDangNhapDAO.Object);
        }

        [TestCase("name2", "value2")]
        [TestCase("name3", "value3")]
        public void ChucVuTestAllow(string name, string value)
        {
            mockIDangNhapDAO.Setup(x => x.ChucVu(It.IsNotNull<string>(), new object[] { name })).Returns(value);
            var result = dangNhapBUS.ChucVu(name);
            Assert.AreEqual(value, result);
            mockIDangNhapDAO.VerifyAll();
            //Assert.Fail();
        }

        [TestCase(null)]
        [TestCase("name")]
        public void ChucVuTestException(string name)
        {
            try
            {
                mockIDangNhapDAO.Setup(x => x.ChucVu(It.IsNotNull<string>(), new object[] { name })).Throws(new Exception());
                dangNhapBUS.ChucVu(name);
            }
            catch (Exception ex)
            {
                //Assert.True(ex.Message == "kkk");
                Assert.True(ex.GetType() == typeof(Exception));
            }

            //mockIDangNhapDAO.Setup(x => x.ChucVu(It.IsNotNull<string>(), new object[] { "name" })).Returns(new Exception());
            //var result = ;
            //Assert.That(() => dangNhapBUS.ChucVu("name"), Throws.Exception);
            //Assert.That(()=>dangNhapBUS.ChucVu(null), Throws.Exception);
            // Assert.Throws<Exception>(() => dangNhapBUS.ChucVu(null));
            //mockIDangNhapDAO.VerifyAll();
        }

        [TestCase("name", "pass")]
        [TestCase("name1", "pass1")]
        public void IsDangNhapTest(string name, string pass)
        {
            mockIDangNhapDAO.Setup(x => x.GetPassHashCode(It.IsNotNull<string>(), name)).Returns(pass.GetHashCode);
            var result = dangNhapBUS.IsDangNhap(name, pass);
            var resultFalse = dangNhapBUS.IsDangNhap(name, "passs");
            Assert.True(result);
            Assert.False(resultFalse);
            mockIDangNhapDAO.VerifyAll();
        }

        [TestCase(null, "pass")]
        [TestCase("name", "pass1")]
        public void IsDangNhapTestException(string name, string pass)
        {
            try
            {
                mockIDangNhapDAO.Setup(x => x.GetPassHashCode(It.IsNotNull<string>(), name)).Throws(new Exception());
                dangNhapBUS.IsDangNhap(name, pass);
            }
            catch (Exception ex)
            {
                Assert.That(ex.GetType() == typeof(Exception));
                //throw;
            }
        }

        [TestCase("name", "ma")]
        [TestCase("name1", "ma1")]
        public void MaNVTest(string name, string maNV)
        {
            mockIDangNhapDAO.Setup(x => x.GetFirstData(It.IsNotNull<string>(), new object[] { name })).Returns(maNV);
            var result = dangNhapBUS.MaNV(name);
            Assert.True(result.Equals(maNV));
            mockIDangNhapDAO.VerifyAll();
        }

        [TestCase(null)]
        [TestCase("name")]
        public void MaNVTestException(string name)
        {
            try
            {
                mockIDangNhapDAO.Setup(x => x.GetFirstData(It.IsAny<string>(), new object[] { name })).Throws(new Exception());
                dangNhapBUS.MaNV(name);
            }
            catch (Exception ex)
            {
                Assert.True(ex.GetType() == typeof(Exception));
            }
        }

        [TestCase(1, "name")]
        [TestCase(2, "name1")]
        public void TenNVTest(int id, string name)
        {
            mockIDangNhapDAO.Setup(x => x.GetFirstData(It.IsNotNull<string>(), new object[] { id })).Returns(name);
            var result = dangNhapBUS.TenNV(id);
            Assert.True(result.Equals(name));
            mockIDangNhapDAO.VerifyAll();
        }

        [TestCase(null)]
        [TestCase(1)]
        public void TenNVTestException(int id)
        {
            try
            {
                mockIDangNhapDAO.Setup(x => x.GetFirstData(It.IsNotNull<string>(), new object[] { id })).Throws(new Exception());
                dangNhapBUS.TenNV(id);
            }
            catch (Exception ex)
            {
                Assert.True(ex.GetType() == typeof(Exception));
            }

        }
    }
}