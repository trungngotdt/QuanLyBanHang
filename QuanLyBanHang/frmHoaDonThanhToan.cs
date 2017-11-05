using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.DAO;
using System.Diagnostics;
using QuanLyBanHang.BUS;
using Microsoft.Practices.ServiceLocation;

namespace QuanLyBanHang
{
    public partial class frmHoaDonThanhToan : Form
    {
        public HoaDonThanhToanBUS HoaDonThanhToan { get => ServiceLocator.Current.GetInstance<HoaDonThanhToanBUS>(); }
        public string TenNhanVien { get; set; }
        public frmHoaDonThanhToan()
        {
            InitializeComponent();
            Loading();
        }

        public void Loading()
        {
            txtSDTKhachHang.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSDTKhachHang.AutoCompleteSource = AutoCompleteSource.CustomSource;
            HoaDonThanhToan.AutoComplete(txtSDTKhachHang);
            cboTenHang.DataSource = HoaDonThanhToan.DataSourceForCombobox();
            lvwChiTietHoaDon.Columns.Add(new ColumnHeader() { Text = "Tên Hàng" });
            lvwChiTietHoaDon.Columns.Add(new ColumnHeader() { Text = "Đơn Giá" });
            lvwChiTietHoaDon.Columns.Add(new ColumnHeader() { Text = "Số Lượng" });
            txtNameStaff.Text = Program.NameStaff;
            DisEnableControl();
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            var maKH = HoaDonThanhToan.GetMaKH(txtSDTKhachHang.Text);
            var date = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + " " + DateTime.Now.ToLongTimeString();
            HoaDonThanhToan.InsertHoaDon(new object[] { maKH, "Bán Hàng", 1, date, "A" });
            var kiemtra= lvwChiTietHoaDon.Items.Count == 0;
            if (kiemtra)
            {
                MessageBox.Show("Điền đơn hàng");
                return;
            }
            var maHD = HoaDonThanhToan.GetMaHoaDon(int.Parse(maKH.ToString()), "Bán Hàng", 1, date, "A");
            foreach (ListViewItem item in lvwChiTietHoaDon.Items)
            {
                var maHang = HoaDonThanhToan.GetMaHang(item.SubItems[0].Text);
                var soLuongHang =int.Parse( HoaDonThanhToan.GetSoLuong(new object[] { maHang }).ToString());
                var donGia = float.Parse(item.SubItems[1].Text);
                var soLuong = int.Parse(item.SubItems[2].Text);
                HoaDonThanhToan.InsertChiTietHoaDon(new object[] { maHD, maHang, donGia, soLuong });
                HoaDonThanhToan.UpdateHangHoa(new object[] { maHang,soLuongHang- soLuong });
                //var element = item.SubItems.OfType<ListViewItem.ListViewSubItem>().Select(p => p.Text);
            }
            MessageBox.Show("Hoàn Thành Đơn Hàng","Tình Trạng",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BtnThemHang_Click(object sender, EventArgs e)
        {
            var tenHang = cboTenHang.Text;
            bool checkTenHangInListView = lvwChiTietHoaDon.FindItemWithText(tenHang) != null ? true : false;//trả ra true khi tìm thấy có tên hàng trong listview và ngược lại
            if (checkTenHangInListView)
            {
                lvwChiTietHoaDon.FindItemWithText(tenHang).SubItems[2].Text = (int.Parse(lvwChiTietHoaDon.FindItemWithText(tenHang).SubItems[2].Text)
                    + int.Parse(nudSoLuong.Value.ToString())).ToString();
            }
            else
            {
                ListViewItem listViewItem = new ListViewItem() { Text = tenHang };
                var donGia = HoaDonThanhToan.LayDonGia(tenHang);
                listViewItem.SubItems.Add(donGia.ToString());
                listViewItem.SubItems.Add(nudSoLuong.Value.ToString());
                lvwChiTietHoaDon.Items.Add(listViewItem);
            }
        }

        /// <summary>
        /// Chỉ cho nhập số
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSDTKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void BtnKiemTraKH_Click(object sender, EventArgs e)
        {
            var sdtKH = txtSDTKhachHang.Text;
            var kiemTra = String.IsNullOrEmpty(sdtKH) || String.IsNullOrWhiteSpace(sdtKH);
            if (kiemTra)
            {
                MessageBox.Show("Điền số điện thoại");
                //txtSDTKhachHang.Focus();
                return;
            }
            var tenKH = HoaDonThanhToan.GetTenKH(txtSDTKhachHang.Text);
            txtTenKhachHang.Text = tenKH?.ToString();
            if (tenKH != null)
            {
                EnableControl();
            }
            else
            {
                DisEnableControl();
                var dialogResult= MessageBox.Show("Số điện thoại không tồn tại","Lỗi",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button1);
                if (dialogResult==DialogResult.Yes)
                {
                    frmThemKhachHang frmThemKhachHang = new frmThemKhachHang();
                    frmThemKhachHang.ShowDialog();
                }
            }
        }

        private void DisEnableControl()
        {
            lvwChiTietHoaDon.Items.Clear();
            nudSoLuong.Value = 1;
            cboTenHang.Enabled = false;
            nudSoLuong.Enabled = false;
            lvwChiTietHoaDon.Enabled = false;
            btnThemHang.Enabled = false;
            btnThanhToan.Enabled = false;

        }

        private void EnableControl()
        {
            cboTenHang.Enabled = true;
            nudSoLuong.Enabled = true;
            lvwChiTietHoaDon.Enabled = true;
            btnThemHang.Enabled = true;
            btnThanhToan.Enabled = true;
        }
    }
}
