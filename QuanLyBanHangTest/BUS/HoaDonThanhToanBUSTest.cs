using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using QuanLyBanHang.DAO.InterfacesDAO;
using QuanLyBanHang.BUS;

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

        [TestCase("value1","value2")]
        public void AutoCompleteTest(string value1,string value2)
        {
            var value = new string[] { value1, value2 };
            mockIHoaDonThanhToanDAO.Setup(x => x.SourceComplete(It.IsNotNull<string>(),null)).Returns(value);
            var array = mockIHoaDonThanhToanDAO.Object.SourceComplete("string", null);
            var valueResult = new System.Windows.Forms.AutoCompleteStringCollection();
            valueResult.AddRange(array);
            mockIHoaDonThanhToanDAO.Setup(x => x.SourceForAutoComplete(It.IsNotNull<string>(), null)).Returns(valueResult);
            hoaDonThanhToanBUS.AutoComplete(new System.Windows.Forms.TextBox());
            mockIHoaDonThanhToanDAO.VerifyAll();
        }


        public void AutoCompleTestException()
        {

        }
    }
}
