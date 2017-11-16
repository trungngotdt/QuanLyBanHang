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
    class QuanLyThongTinBUSTest
    {

        private Mock<IQuanLyThongTinDAO> mockIQuanLyThongTinDAO;
        private QuanLyThongTinBUS quanLyThongTinBUS;
        [SetUp]
        public void SetUp()
        {
            mockIQuanLyThongTinDAO = new Mock<IQuanLyThongTinDAO>();
            quanLyThongTinBUS = new QuanLyThongTinBUS(mockIQuanLyThongTinDAO.Object);
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
        public void GetListChiTietHoaDon()
        {
            var aa = new System.Data.DataTable();
            mockIQuanLyThongTinDAO.Setup(x => x.ShowAll(It.IsNotNull<string>())).Returns(new System.Data.DataTable());
            var result= quanLyThongTinBUS.GetListChiTietHoaDon();

            mockIQuanLyThongTinDAO.VerifyAll();
        }
    }
}
