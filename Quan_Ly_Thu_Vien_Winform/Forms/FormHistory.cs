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
    public partial class FormHistory : Form
    {
        public FormHistory()
        {
            InitializeComponent();
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        void LoadList()
        {
            dataGridView1.Rows.Clear();
            foreach (var docGia in XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia.Values)
            {
                foreach (var phieuMuon in XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon.Values)
                {

                    foreach (var phieuTra in XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuTra.Values)
                    {
                        if (phieuMuon.MaDocGia == docGia.MaDocGia && phieuTra.MaPhieuMuon == phieuMuon.MaPhieuMuon)
                        {
                            if (txtBillCode.Text == String.Empty || txtReaderFilter.Text == String.Empty ||
                                docGia.MaDocGia.ToLower().Contains(txtReaderFilter.Text.ToLower()) ||
                                docGia.HoTen.ToLower().Contains(txtReaderFilter.Text.ToLower()) ||
                                phieuMuon.MaPhieuMuon.ToLower().Contains(txtBillCode.Text.ToLower()) ||
                                phieuTra.MaPhieuTra.ToLower().Contains(txtBillCode.Text.ToLower()) ||

                                dateTimePickerFrom.Value <= phieuMuon.NgayMuon && phieuMuon.NgayMuon <= dateTimePickerTo.Value ||
                                dateTimePickerFrom.Value <= phieuTra.NgayTra && phieuTra.NgayTra <= dateTimePickerTo.Value
                            )
                            {
                                var chiTietPhieuMuon = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon[phieuMuon.MaPhieuMuon];
                                var chiTietPhieuTra = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuTra[phieuTra.MaPhieuTra];

                                dataGridView1.Rows.Add(docGia.MaDocGia, docGia.HoTen, docGia.SoDienThoai + "\n" + docGia.Email + "\n" + docGia.DiaChi,
                                     phieuMuon.NgayMuon, phieuTra.NgayTra, phieuMuon.MaPhieuMuon, phieuTra.MaPhieuTra,
                                     chiTietPhieuMuon.TinhTrangTruocKhiMuon, chiTietPhieuTra.TinhTrangSauMuon, chiTietPhieuMuon.SoLuong);
                            }
                        }
                    }
                }
            }
        }

        private void txtBillCode_TextChanged(object sender, EventArgs e)
        {
            //if (txtReaderFilter.Text != String.Empty)
            //    txtReaderFilter.Text = String.Empty;
            //LoadList();
        }

        private void txtReaderFilter_TextChanged(object sender, EventArgs e)
        {
            //if (txtBillCode.Text != String.Empty)
            //    txtBillCode.Text = String.Empty;
            //LoadList();
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value > dateTimePickerTo.Value)
            {
                dateTimePickerFrom.Value = dateTimePickerTo.Value.AddDays(-1);
            }
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerTo.Value < dateTimePickerFrom.Value)
            {
                dateTimePickerTo.Value = dateTimePickerFrom.Value.AddDays(1);
            }
        }

        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            LoadList();
        }
    }
}
