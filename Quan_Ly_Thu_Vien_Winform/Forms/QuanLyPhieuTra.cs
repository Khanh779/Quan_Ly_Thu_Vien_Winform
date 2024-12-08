using Quan_Ly_Thu_Vien_Winform.DuLieu;
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
    public partial class QuanLyPhieuTra : Form
    {
        public QuanLyPhieuTra()
        {
            InitializeComponent();
        }

        private void QuanLyPhieuMuon_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker2.Value.AddDays(7);

            txt_ReaderCode.AutoCompleteCustomSource.AddRange(XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia.Keys.ToArray());
            txt_ReaderCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_ReaderCode.AutoCompleteSource = AutoCompleteSource.CustomSource;



            LayDanhSachPhieuTra();

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

        void LayDanhSachPhieuTra()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            foreach (var b in XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuTra.Values)
            {
                //if(XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuTra.ContainsKey(b.MaPhieuMuon))
                {
                    var a = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon[b.MaPhieuMuon];
                    if (txt_BorrowFilter.Text == String.Empty || a.MaPhieuMuon.ToLower().Contains(txt_BorrowFilter.Text.ToLower()) || a.MaDocGia.ToLower().Contains(txt_BorrowFilter.Text.ToLower()))
                    {
                        string getReaderFullName =
                            XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia.ContainsKey(a.MaDocGia) ? XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia[a.MaDocGia].HoTen : "<ko xác định>";

                        var chi = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuTra[b.MaPhieuTra];
                        dataGridView1.Rows.Add(b.MaPhieuTra, a.MaPhieuMuon, a.MaDocGia, getReaderFullName, a.NgayMuon, a.NgayHenTra, b.NgayTra, chi.TinhTrangSauMuon, chi.SoLuongTra);
                    }
                }
            }
            LB_BorrowBillCount.Text = "Tổng số phiếu mượn: " + dataGridView1.Rows.Count;
        }

        void LayDanhSachSach_Tu_MaPT(string maPT)
        {
            dataGridView2.Rows.Clear();
            if (XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuTra.ContainsKey(maPT))
            {
                foreach (var a in XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuTra[maPT].DanhSach_SachTra.Values)
                {

                    dataGridView2.Rows.Add(a.MaSach, a.TenSach, a.TenTacGia, a.LoaiSach, a.NhaXuatBan, a.NamXuatBan);
                }
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            LayDanhSachSach_Tu_MaPT(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void txt_BorrowFilter_TextChanged(object sender, EventArgs e)
        {
            LayDanhSachPhieuTra();
        }



        ChiTiet_PhieuMuon chiTiet = new ChiTiet_PhieuMuon();

        private void btn_Add_Click(object sender, EventArgs e)
        {

            LayDanhSachPhieuTra();
        }



        private void btn_Del_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LayDanhSachPhieuTra();
        }
    }
}
