﻿using Quan_Ly_Thu_Vien_Winform.DuLieu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Thu_Vien_Winform.Forms
{
    public partial class FormAddBorrowBill : Form
    {
        public FormAddBorrowBill()
        {
            InitializeComponent();
        }

        public void SetPreviewBorrowCode(string maPM)
        {
            txt_ReaderID.Text = maPM;

        }

        private void FormAddReturnBill_Load(object sender, EventArgs e)
        {
            txt_ReaderID.AutoCompleteCustomSource.AddRange(XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia.Keys.ToArray());
            txt_BookCode.AutoCompleteCustomSource.AddRange(XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach.Keys.ToArray());
            dateTimePicker2.Value = DateTime.Now.AddDays(7);

        }

        private void txt_BorrowCode_TextChanged(object sender, EventArgs e)
        {
            string maPM = txt_ReaderID.Text;
            if (txt_ReaderID.Text != String.Empty)
            {
                txt_BorrowCode.Text = XuLy_DuLieu.TaoMaMuon(maPM);
                if(XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia.ContainsKey(txt_ReaderID.Text))
                {
                    txt_ReaderName.Text = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia[maPM].HoTen;

                }    

            }

        }

        ChiTiet_PhieuMuon chiTiet = new ChiTiet_PhieuMuon();

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_ReaderID.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mã độc giả", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txt_BookCode.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mã sách", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach.ContainsKey(txt_BookCode.Text))
            {
                MessageBox.Show("Mã sách không tồn tại", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string getMaPM = txt_ReaderID.Text;
            ThongTin_PhieuMuon phieuMuon = new ThongTin_PhieuMuon();
            phieuMuon.MaPhieuMuon = txt_BorrowCode.Text;
            phieuMuon.MaDocGia = txt_ReaderID.Text;
            phieuMuon.NgayMuon = dateTimePicker1.Value;
            phieuMuon.NgayHenTra = dateTimePicker2.Value;

            //chiTiet = new ChiTiet_PhieuMuon();
            chiTiet.MaPhieuMuon = phieuMuon.MaPhieuMuon;
            chiTiet.TinhTrangTruocKhiMuon = txt_StatusBeforeBorrow.Text;

            XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon.Add(phieuMuon.MaPhieuMuon, phieuMuon);

            MessageBox.Show("Thêm phiếu mượn thành công", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (MessageBox.Show("Bạn có muốn tiếp tục?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txt_BookCode.Text = "";
                txt_StatusBeforeBorrow.Text = "";
                txt_BookCode.Focus();
            }
            else
            {
                this.Close();
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chiTiet.DanhSach_SachMuon.Clear();
            dataGridView1.Rows.Clear();
        }

        private void txt_BookCode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}