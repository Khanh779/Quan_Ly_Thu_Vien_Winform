﻿using Quan_Ly_Thu_Vien_Winform.DuLieu;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Quan_Ly_Thu_Vien_Winform.Forms
{
    public partial class QuanLyPhieuMuon : Form
    {
        public QuanLyPhieuMuon()
        {
            InitializeComponent();
        }

        private void QuanLyPhieuMuon_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker2.Value.AddDays(7);

            txt_ReaderCode.AutoCompleteCustomSource.AddRange(XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia.Keys.ToArray());
            txt_ReaderCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_ReaderCode.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txt_BookCode.AutoCompleteCustomSource.AddRange(XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach.Keys.ToArray());
            txt_BookCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_BookCode.AutoCompleteSource = AutoCompleteSource.CustomSource;

            LayDanhSachPhieuMuon();

        }

        private void txt_ReaderCode_TextChanged(object sender, EventArgs e)
        {
            txt_BorrowCode.Text = XuLy_DuLieu.TaoMaMuon(txt_ReaderCode.Text);

            if (dataGridView1.SelectedRows.Count > 0)
                dataGridView1.SelectedRows[0].Selected = false;

            if (dataGridView1.SelectedColumns.Count > 0)
                dataGridView1.SelectedColumns[0].Selected = false;

            if (dataGridView1.SelectedCells.Count > 0)
                dataGridView1.SelectedCells[0].Selected = false;

            dataGridView2.Rows.Clear();
        }

        void LayDanhSachPhieuMuon()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            foreach (var a in XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon.Values)
            {
                if (txt_BorrowFilter.Text == String.Empty || a.MaPhieuMuon.ToLower().Contains(txt_BorrowFilter.Text.ToLower()) || a.MaDocGia.ToLower().Contains(txt_BorrowFilter.Text.ToLower()))
                {
                    string getReaderFullName =
                        XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia.ContainsKey(a.MaDocGia) ? XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia[a.MaDocGia].HoTen : "<ko xác định>";

                    var chiTe = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon.ContainsKey(a.MaPhieuMuon) ? XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon[a.MaPhieuMuon] : null;

                    dataGridView1.Rows.Add(a.MaPhieuMuon, a.MaDocGia, getReaderFullName, a.NgayMuon, a.NgayHenTra, chiTe != null ? chiTe.TinhTrangTruocKhiMuon : "", chiTe != null ? chiTe.SoLuong : 0);
                }
            }
            LB_BorrowBillCount.Text = "Tổng số phiếu mượn: " + dataGridView1.Rows.Count;
        }

        void LayDanhSachSach_Tu_MaPM(string maPM)
        {
            dataGridView2.Rows.Clear();
            if (XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon.ContainsKey(maPM))
            {
                foreach (var a in XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon[maPM].DanhSach_SachMuon.Values)
                {
                    dataGridView2.Rows.Add(a.MaSach, a.TenSach, a.TenTacGia, a.LoaiSach, a.NhaXuatBan, a.NamXuatBan);
                }
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LayDanhSachSach_Tu_MaPM(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            //var kttt = XuLy_DuLieu.KiemTraPhieuTra_TuMaPhieuMuon(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //if (kttt == true)
            //{
            //    btn_Del.Enabled = !kttt;
            //}
        }

        private void txt_BorrowFilter_TextChanged(object sender, EventArgs e)
        {
            LayDanhSachPhieuMuon();
        }

        private void btn_AddBook_Click(object sender, EventArgs e)
        {
            if (txt_ReaderCode.Text == String.Empty)
            {
                MessageBox.Show("Chưa nhập mã độc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txt_BookCode.Text == String.Empty)
            {
                MessageBox.Show("Chưa nhập mã sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia.ContainsKey(txt_ReaderCode.Text))
            {
                MessageBox.Show("Mã độc giả không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach.ContainsKey(txt_BookCode.Text))
            {
                MessageBox.Show("Mã sách không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            chiTiet.DanhSach_SachMuon.Add(txt_BookCode.Text, XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach[txt_BookCode.Text]);
            dataGridView2.Rows.Add(txt_BookCode.Text, XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach[txt_BookCode.Text].TenSach, XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach[txt_BookCode.Text].TenTacGia, XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach[txt_BookCode.Text].LoaiSach, XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach[txt_BookCode.Text].NhaXuatBan, XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach[txt_BookCode.Text].NamXuatBan);

            txt_BookCode.Text = "";

        }

        ChiTiet_PhieuMuon chiTiet = new ChiTiet_PhieuMuon();

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_ReaderCode.Text == String.Empty)
            {
                MessageBox.Show("Chưa nhập mã độc giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (chiTiet.DanhSach_SachMuon.Count <= 0)
            {
                MessageBox.Show("Vui lòng thêm 1 sách để tiếp tục", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ThongTin_PhieuMuon phieuMuon = new ThongTin_PhieuMuon(txt_ReaderCode.Text, txt_BorrowCode.Text, dateTimePicker1.Value, dateTimePicker2.Value);
            chiTiet.MaPhieuMuon = phieuMuon.MaPhieuMuon;
            chiTiet.TinhTrangTruocKhiMuon = txt_StatusBeforeBorrow.Text;

            if (XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon.ContainsKey(phieuMuon.MaPhieuMuon))
            {
                MessageBox.Show("Mã phiếu mượn đã tồn tại do đó không thể thêm", Application.ProductName + " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon.Add(phieuMuon.MaPhieuMuon, phieuMuon);
            XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon.Add(chiTiet.MaPhieuMuon, chiTiet);

            MessageBox.Show("Thêm phiếu mượn thành công", Application.ProductName + " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LayDanhSachPhieuMuon();

            if (MessageBox.Show("Ban có muốn tiếp tục?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                this.Close();
            }

            txt_ReaderCode.Text = txt_BookCode.Text = txt_BorrowCode.Text = txt_StatusBeforeBorrow.Text = "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chiTiet.DanhSach_SachMuon.Clear();
            dataGridView2.Rows.Clear();

            MessageBox.Show("Đã xóa tất cả sách trong phiếu mượn", Application.ProductName + " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            var getMaPM = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();


            FormAddReturnBill formAddReturnBill = new FormAddReturnBill();
            formAddReturnBill.SetPreviewBorrowCode(getMaPM);
            formAddReturnBill.MdiParent = MainForm.Instance;
            formAddReturnBill.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LayDanhSachPhieuMuon();
        }
    }
}
