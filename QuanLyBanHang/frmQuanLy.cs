using QuanLyBanHang.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmQuanLy : Form
    {
        private QuanLyBUS QuanLy { get => Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<QuanLyBUS>(); }
        public frmQuanLy()
        {
            InitializeComponent();
        }

        void FlagForKH(bool flag)
        {
            txtDiaChiKhach.Enabled = !flag;
            txtLoaiKhach.Enabled = !flag;
            txtSDTKhach.Enabled = !flag;
            txtTenKhach.Enabled = !flag;
            txtGoiTinh.Enabled = !flag;
            btnThemKhach.Enabled = !flag;
            btnLamSachKhach.Enabled = !flag;
            btnCapNhatKhach.Enabled = !flag;
        }

        /// <summary>
        /// Sử dụng cờ cho tab Nhân Viên
        /// Khi flag bằng true thì vô hiệu hóa các nút bấm và textbox ngoại trừ <see cref="txtMaNV"/>
        /// </summary>
        /// <param name="flag">Khi flag bằng true thì vô hiệu hóa các nút bấm và textbox ngoại trừ <see cref="txtMaNV"/></param>
        void FlagForNV(bool flag)
        {
            txtChucVuNV.Enabled = !flag;
            txtDiaChiNV.Enabled = !flag;
            txtEmailNV.Enabled = !flag;
            txtTenNV.Enabled = !flag;
            txtSDTNV.Enabled = !flag;
            btnCapNhat.Enabled = !flag;
            btnThem.Enabled = !flag;
            btnLamSachNV.Enabled = !flag;

        }

        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            FlagForNV(true);
            GetDataNhanVien();
            txtChucVuNV.Enabled = false;
            txtID.Text = Program.IDStaff;
            txtName.Text = Program.NameStaff;
            txtRole.Text = Program.RoleStaff;
            txtRole.Enabled = false;
            txtRole.ReadOnly = true;
            txtID.Enabled = false;
            txtID.ReadOnly = true;
            txtName.Enabled = false;
            txtName.ReadOnly = true;
            dgrvNhanVien.ClearSelection();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            var text = btnSua.Text;
            if (text.Equals("Sửa"))
            {
                FlagForNV(false);
                btnThem.Enabled = true;
                btnSua.Text = "Xong";
            }
            else if (text.Equals("Xong"))
            {
                FlagForNV(true);
                btnSua.Text = "Sửa";
            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!CheckTextBoxNV())
            {
                MessageBox.Show("Vui Lòng điền đầy đủ thông tin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var isUpdate = QuanLy.UpdateNV(new object[] { txtMaNV.Text, txtTenNV.Text, txtChucVuNV.Text, txtDiaChiNV.Text, txtSDTNV.Text, txtEmailNV.Text });
                if (isUpdate)
                {
                    MessageBox.Show("Thành công", "", MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi trong quá trình sửa", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ClearAllTextBoxNV();
            GetDataNhanVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!CheckTextBoxNV())
            {
                MessageBox.Show("Vui Lòng điền đầy đủ thông tin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var isInsert = QuanLy.InsertNV(new object[] { txtTenNV.Text, txtChucVuNV.Text, txtDiaChiNV.Text, txtSDTNV.Text, txtEmailNV.Text });
                if (isInsert)
                {
                    MessageBox.Show("Thêm thành công", "", MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi trong quá trình thêm");
            }
            ClearAllTextBoxNV();
            GetDataNhanVien();
        }

        /// <summary>
        /// Cho tất cả các textbox của Nhân Viên về giá trị rỗng
        /// </summary>
        void ClearAllTextBoxNV()
        {
            txtChucVuNV.Text = "";
            txtDiaChiNV.Text = "";
            txtEmailNV.Text = "";
            txtMaNV.Text = "";
            txtSDTNV.Text = "";
            txtTenNV.Text = "";

        }

        private void btnLamSachNV_Click(object sender, EventArgs e)
        {
            ClearAllTextBoxNV();
        }

        private void dgrvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = e.RowIndex;
            if (index <= 0)
            {
                return;
            }
            txtMaNV.Text = dgrvNhanVien.Rows[index].Cells["MaNV"].Value.ToString();
            txtDiaChiNV.Text = dgrvNhanVien.Rows[index].Cells["DiaChi"].Value.ToString();
            txtChucVuNV.Text = dgrvNhanVien.Rows[index].Cells["ChucVu"].Value.ToString();
            txtEmailNV.Text = dgrvNhanVien.Rows[index].Cells["Email"].Value.ToString();
            txtSDTNV.Text = dgrvNhanVien.Rows[index].Cells["DienThoai"].Value.ToString();
            txtTenNV.Text = dgrvNhanVien.Rows[index].Cells["TenNV"].Value.ToString();
        }

        /// <summary>
        /// Kiểm tra textbox khác null hay rỗng
        /// Trả về true nếu textbox có dữ liệu
        /// </summary>
        /// <returns></returns>
        bool CheckTextBoxNV()
        {
            var isDiaChi = txtDiaChiNV.Text.Trim().Length > 0;
            var isTen = txtTenNV.Text.Trim().Length > 0;
            var isChucVu = txtChucVuNV.Text.Trim().Length > 0;
            var isDT = txtSDTNV.Text.Trim().Length > 0;
            var isEmail = txtEmailNV.Text.Trim().Length > 0;
            return isChucVu && isDiaChi && isDT && isEmail && isTen;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            GetDataNhanVien();
        }

        /// <summary>
        /// Kiểm tra các <see cref="TextBox"/> của Khách Hàng xem có để trống không .
        /// Ngoài trừ hai <see cref="TextBox"/> là <see cref="txtMaKhach"/> và <see cref="txtGoiTinh"/>
        /// </summary>
        /// <returns></returns>
        bool CheckTextBoxKH()
        {
            var isDiaChi = txtDiaChiKhach.Text.Trim().Length > 0;
            var isTen = txtTenKhach.Text.Trim().Length > 0;
            var isLoaiKH = txtLoaiKhach.Text.Trim().Length > 0;
            var isDT = txtSDTKhach.Text.Trim().Length > 0;
            return isLoaiKH && isDiaChi && isDT && isTen;
        }

        private void btnThemKhach_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (!CheckTextBoxKH())
            {
                MessageBox.Show("Điền đầy đủ thông tin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return;
            }
            try
            {
                var check = QuanLy.InsertKH(new object[] { txtTenKhach.Text, txtSDTKhach.Text, txtGoiTinh.Text, txtDiaChiKhach.Text, txtLoaiKhach.Text });
                if (check)
                {
                    MessageBox.Show("Thành công trong việc thêm khách hàng");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi không thể thêm khách hàng .Lỗi {ex.Message.ToString()}", "Lỗi Thêm Khách Hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClearAllTextBoxKH();
            GetDataKhachHang();
            this.Cursor = Cursors.Default;
            
        }

        private void btnSuaKhach_Click(object sender, EventArgs e)
        {
            var text = btnSuaKhach.Text;
            if (text.Equals("Sửa"))
            {
                FlagForKH(false);
                btnThemKhach.Enabled = true;
                btnSuaKhach.Text = "Xong";
            }
            else if (text.Equals("Xong"))
            {
                FlagForKH(true);
                btnSuaKhach.Text = "Sửa";
            }
        }

        private void btnCapNhatKhach_Click(object sender, EventArgs e)
        {
            if (!CheckTextBoxKH())
            {
                MessageBox.Show("Điền đầy đủ thông tin", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var check = QuanLy.UpdateKH(new object[] { txtMaKhach.Text, txtTenKhach.Text, txtSDTKhach.Text, txtGoiTinh.Text, txtDiaChiKhach.Text, txtLoaiKhach.Text });
                if (check)
                {
                    MessageBox.Show("Cập nhật thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể cập nhật thông tin khách hàng.Lỗi {ex.Message.ToString()}", "Lỗi Cập Nhật", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClearAllTextBoxKH();
            GetDataKhachHang();
        }

        /// <summary>
        /// Cho tất cả các giá trị của textbox Khách hàng về rỗng
        /// </summary>
        void ClearAllTextBoxKH()
        {
            txtTenKhach.Text = "";
            txtDiaChiKhach.Text = "";
            txtGoiTinh.Text = "";
            txtLoaiKhach.Text = "";
            txtSDTKhach.Text = "";
        }

        private void btnLamSachKhach_Click(object sender, EventArgs e)
        {
            ClearAllTextBoxKH();
        }

        /// <summary>
        /// Lấy tất cả dữ liệu của Nhân Viên
        /// </summary>
        void GetDataNhanVien()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                dgrvNhanVien.DataSource = QuanLy.GetDataNV();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Lỗi không thể lấy dữ liệu.Lỗi {e.Message.ToString()}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void txtSDTNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSDTKhach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGoiTinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            var charBinary = e.KeyChar == '0' || e.KeyChar == '1';
            if (!charBinary || txtGoiTinh.Text.Length >= 1)
            {
                if (!char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        void GetDataKhachHang()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                dgrvKhachHang.DataSource = QuanLy.GetDataKH();
            }
            catch (Exception e)
            {

                MessageBox.Show($"Không thể lấy dữ liệu .Tên lỗi {e.Message.ToString()}", "Không thể truy vấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void dgrvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = e.RowIndex;
            if (index <= 0)
            {
                return;
            }
            txtMaKhach.Text = dgrvKhachHang.Rows[index].Cells["MaKH"].Value.ToString();
            txtTenKhach.Text = dgrvKhachHang.Rows[index].Cells["TenKH"].Value.ToString();
            txtSDTKhach.Text = dgrvKhachHang.Rows[index].Cells["SDT"].Value.ToString();
            txtGoiTinh.Text = dgrvKhachHang.Rows[index].Cells["GioiTinh"].Value.ToString();
            txtDiaChiKhach.Text = dgrvKhachHang.Rows[index].Cells["DiaChi"].Value.ToString();
            txtLoaiKhach.Text = dgrvKhachHang.Rows[index].Cells["LoaiKhachHang"].Value.ToString();
        }

        private void tabCnQuanLy_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage.Name.ToString().Equals(tabPgKhach.Name))
            {
                FlagForKH(true);
                GetDataKhachHang();
                dgrvKhachHang.ClearSelection();
            }
            else if (e.TabPage.Name.Equals(tabPgNV.Name))
            {
                FlagForNV(true);
                GetDataNhanVien();
                dgrvNhanVien.ClearSelection();
            }

        }

        private void btnShowKH_Click(object sender, EventArgs e)
        {
            GetDataKhachHang();
        }
    }
}
