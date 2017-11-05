using Microsoft.Practices.ServiceLocation;
using QuanLyBanHang.BUS;
using QuanLyBanHang.DAO;
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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
            Loading();
        }

        void Loading()
        {
            this.ActiveControl = txtName;
            this.AcceptButton = btnDangNhap;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public DangNhapBUS DangNhapBUS { get => ServiceLocator.Current.GetInstance<DangNhapBUS>(); }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            bool kiemTra = DangNhapBUS.IsDangNhap(txtName.Text, txtPass.Text);

            if (kiemTra)
            {
                MessageBox.Show("Đăng Nhập thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.IDStaff = DangNhapBUS.MaNV(txtName.Text);
                Program.NameStaff = DangNhapBUS.TenNV(int.Parse(Program.IDStaff));
                var chucVu = DangNhapBUS.ChucVu(txtName.Text);
                Program.RoleStaff = chucVu;
                if (chucVu.Equals("NV"))
                {
                    Program.OpenFrmHoaDonThanhToan = true;
                }
                else if (chucVu.Equals("TK"))
                {
                    Program.OpenFrmQuanLyThongTin = true;
                }
                else if (chucVu.Equals("GD"))
                {
                    Program.OpenFrmQuanLy = true;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng Nhập thất bại", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Text = "";
                txtPass.Text = "";
                this.ActiveControl = txtName;
            }
        }
    }
}
