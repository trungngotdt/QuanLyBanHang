﻿using Microsoft.Practices.ServiceLocation;
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
    public partial class frmThemKhachHang : Form
    {
        public frmThemKhachHang()
        {
            InitializeComponent();
        }

        private ThemKhachHangBUS themKhachHang { get => ServiceLocator.Current.GetInstance<ThemKhachHangBUS>(); }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (ChechTextBox())
            {
                MessageBox.Show("Không được để trống ô nào");
                return;
            }
            var gioiTinh = cboNam.Checked == true ? 1 : 0;
            var isThemKH = themKhachHang.InsertKhachHang(new object[] { txtTenKhachHang.Text, int.Parse(txtSDT.Text), gioiTinh, txtDiaChi.Text, txtLoaiKH.Text });
            if (isThemKH)
            {
                MessageBox.Show("Thành công","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void TxtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        /// <summary>
        /// Kiểm tra xem textbox có để trống không
        /// </summary>
        private bool ChechTextBox()
        {
            var chechkSDT = String.IsNullOrEmpty(txtSDT.Text) || String.IsNullOrWhiteSpace(txtSDT.Text);
            var checkTen = String.IsNullOrEmpty(txtTenKhachHang.Text) || String.IsNullOrWhiteSpace(txtTenKhachHang.Text);
            var chechDiaChi = String.IsNullOrEmpty(txtDiaChi.Text) || String.IsNullOrWhiteSpace(txtDiaChi.Text);
            var chechLoaiKH = String.IsNullOrEmpty(txtLoaiKH.Text) || String.IsNullOrWhiteSpace(txtLoaiKH.Text);
            var checkTextBox = chechDiaChi || chechkSDT || chechLoaiKH || checkTen;
            return checkTextBox;
        }
    }
}
