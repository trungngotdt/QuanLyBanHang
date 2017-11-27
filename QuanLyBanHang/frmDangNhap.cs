﻿using Microsoft.Practices.ServiceLocation;
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

        public DangNhapBUS dangNhapBUS { get => ServiceLocator.Current.GetInstance<DangNhapBUS>(); }

        /// <summary>
        ///Hiển thị thông báo khi có bất kì <see cref="Exception"/> nào bị phát hiện 
        /// </summary>
        /// <param name="ex"></param>
        void WarningMessageBox(Exception ex)
        {
            MessageBox.Show($"Lỗi trong quá trình thực thi.Mã lỗi :\n {ex.Message.ToString()} \\\n Vui lòng liên hệ người quản trị " +
                $"hoặc nhân viên để được nhận thêm sự " +
                $" hỗ trợ", "Lỗi Trong Quá Trình Thực Thi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OpenAnOtherFrom(string chucVu)
        {
            Program.RoleStaff = chucVu;
            Program.OpenFrmHoaDonThanhToan = chucVu.Equals("NV");
            Program.OpenFrmQuanLy = chucVu.Equals("GD");
            Program.OpenFrmQuanLyThongTin = chucVu.Equals("TK");
        }

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                var isTextBoxEmpty = txtName.Text.Trim().Length > 0 && txtPass.Text.Trim().Length > 0;
                if (!isTextBoxEmpty)
                {
                    MessageBox.Show("Vui lòng điền vào chỗ trống", "THIẾU SÓT DỮ LIỆU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (txtName.Text.Trim().Length == 0)
                    {
                        txtName.Focus();
                    }
                    else
                    {
                        txtPass.Focus();
                    }
                }
                else
                {
                    bool kiemTra = dangNhapBUS.IsDangNhap(txtName.Text, txtPass.Text);
                    if (kiemTra)
                    {
                        MessageBox.Show("Đăng Nhập thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Program.IDStaff = dangNhapBUS.MaNV(txtName.Text);
                        Program.NameStaff = dangNhapBUS.TenNV(int.Parse(Program.IDStaff));
                        var chucVu = dangNhapBUS.ChucVu(txtName.Text);
                        OpenAnOtherFrom(chucVu);
                        /*Program.RoleStaff = chucVu;
                        Program.OpenFrmHoaDonThanhToan = chucVu.Equals("NV");
                        Program.OpenFrmQuanLy = chucVu.Equals("GD");
                        Program.OpenFrmQuanLyThongTin = chucVu.Equals("TK");*/
                        /*if (chucVu.Equals("NV"))
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
                        }*/
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
            catch (Exception ex)
            {
                WarningMessageBox(ex);
            }
            this.Cursor = Cursors.Default;
        }
    }
}
