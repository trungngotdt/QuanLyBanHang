using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using QuanLyBanHang.DAO.InterfacesDAO;
using QuanLyBanHang.BUS;
using QuanLyBanHang.BUS.Interfaces;



namespace QuanLyBanHangTest.BUS
{
    [TestFixture]
    public class QuanLyBUSTest
    {
        private Mock<IQuanLyDAO> mockIQuanLyDAO;
        private QuanLyBUS quanLyBUS;
        [SetUp]
        public void SetUp()
        {
            mockIQuanLyDAO = new Mock<IQuanLyDAO>();
            quanLyBUS = new QuanLyBUS(mockIQuanLyDAO.Object);
        }

        [Test]
        public void ClassTest()
        {
            var result = typeof(QuanLyBUS).GetInterfaces().Contains(typeof(IQuanLyBUS));
            var result1 = typeof(QuanLyBUS).IsPublic;
            Assert.IsTrue(result);
            Assert.IsTrue(result1);
        }

        [Test]
        public void GetDataKHTest()
        {
            mockIQuanLyDAO.Setup(x => x.GetData(It.IsNotNull<string>(),  null )).Returns(new System.Data.DataTable());
            quanLyBUS.GetDataKH();
            mockIQuanLyDAO.VerifyAll();
        }

        [Test]
        public void GetDataKHTestException()
        {
            mockIQuanLyDAO.Setup(x => x.GetData(It.IsNotNull<string>(), null)).Throws(new Exception());
            var exception=Assert.Catch<Exception>(()=> quanLyBUS.GetDataKH());
            Assert.IsTrue(exception.GetType() == typeof(Exception));
            mockIQuanLyDAO.VerifyAll();
        }

        [Test]
        public void GetDataNVTest()
        {
            mockIQuanLyDAO.Setup(x => x.GetData(It.IsNotNull<string>(), null)).Returns(new System.Data.DataTable());
            quanLyBUS.GetDataNV();
            mockIQuanLyDAO.VerifyAll();
        }

        [Test]
        public void GetDataNVTestException()
        { 
            mockIQuanLyDAO.Setup(x => x.GetData(It.IsNotNull<string>(), null)).Throws(new Exception());
            var exception = Assert.Catch<Exception>(() => quanLyBUS.GetDataNV());
            Assert.IsTrue(exception.GetType() == typeof(Exception));
            mockIQuanLyDAO.VerifyAll();
        }

        [TestCase(new object[] {"value1","value2","value2","value3","value4" },1,true)]
        [TestCase(new object[] { "value1", "value2", "value2", "value3", "value5" }, 0,false)]
        public void InsertKHTest(object[] para,int number,bool value)
        {
            mockIQuanLyDAO.Setup(x => x.Insert(It.IsNotNull<string>(), para)).Returns(number);
            var result = quanLyBUS.InsertKH(para);
            Assert.AreEqual(result, value);
        }

        [TestCase(new object[] {"null" })]
        public void InsertKHTestException(object[] para)
        {
            mockIQuanLyDAO.Setup(x => x.Insert(It.IsNotNull<string>(), para)).Throws<Exception>();
            var exception = Assert.Catch<Exception>(() => quanLyBUS.InsertKH(para));
            Assert.IsTrue(exception.GetType() == typeof(Exception));
            mockIQuanLyDAO.VerifyAll();
        }


        [TestCase(new object[] { "value1", "value2", "value2", "value3", "value4" }, 1, true)]
        [TestCase(new object[] { "value1", "value2", "value2", "value3", "value5" }, 0, false)]
        public void InsertNVTest(object[] para, int number, bool value)
        {
            mockIQuanLyDAO.Setup(x => x.Insert(It.IsNotNull<string>(), para)).Returns(number);
            var result = quanLyBUS.InsertNV(para);
            Assert.AreEqual(result, value);
        }

        [TestCase(new object[] { "null" })]
        public void InsertNVTestException(object[] para)
        {
            mockIQuanLyDAO.Setup(x => x.Insert(It.IsNotNull<string>(), para)).Throws<Exception>();
            var exception = Assert.Catch<Exception>(() => quanLyBUS.InsertNV(para));
            Assert.IsTrue(exception.GetType() == typeof(Exception));
            mockIQuanLyDAO.VerifyAll();
        }


        [TestCase(new object[] { "value1", "value2", "value2", "value3", "value4","value5" }, 1, true)]
        [TestCase(new object[] { "value1", "value2", "value2", "value3", "value5","value7" }, 0, false)]
        public void UpdateKHTest(object[] para, int number, bool value)
        {

            mockIQuanLyDAO.Setup(x => x.Update(It.IsNotNull<string>(), para)).Returns(number);
            var result = quanLyBUS.UpdateKH(para);
            Assert.AreEqual(result, value);
        }


        [TestCase(new object[] { "null" })]
        public void UpdateKHTestException(object[] para)
        {
            mockIQuanLyDAO.Setup(x => x.Update(It.IsNotNull<string>(), para)).Throws<Exception>();
            var exception = Assert.Catch<Exception>(() => quanLyBUS.UpdateKH(para));
            Assert.IsTrue(exception.GetType() == typeof(Exception));
            mockIQuanLyDAO.VerifyAll();
        }

        [TestCase(new object[] { "value1", "value2", "value2", "value3", "value4", "value5" }, 1, true)]
        [TestCase(new object[] { "value1", "value2", "value2", "value3", "value5", "value7" }, 0, false)]
        public void UpdateNVTest(object[] para, int number, bool value)
        {

            mockIQuanLyDAO.Setup(x => x.Update(It.IsNotNull<string>(), para)).Returns(number);
            var result = quanLyBUS.UpdateNV(para);
            Assert.AreEqual(result, value);
        }


        [TestCase(new object[] { "null" })]
        public void UpdateNVTestException(object[] para)
        {
            mockIQuanLyDAO.Setup(x => x.Update(It.IsNotNull<string>(), para)).Throws<Exception>();
            var exception = Assert.Catch<Exception>(() => quanLyBUS.UpdateNV(para));
            Assert.IsTrue(exception.GetType() == typeof(Exception));
            mockIQuanLyDAO.VerifyAll();
        }
    }
}
