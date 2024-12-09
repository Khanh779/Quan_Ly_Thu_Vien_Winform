using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            comboBox1.DataSource = new List<string>
            {
                "Bình thường",
                "Tăng dần theo mã ĐG",
                "Giảm dần theo mã ĐG",
                "Tăng dần theo thời gian mượn",
                "Giảm dần theo thời gian mượn"
            };
        }

        void LoadList()
        {
            dataGridView1.Rows.Clear();
            List<object[]> objects = new List<object[]>();
            foreach (var docGia in XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia.Values)
            {
                foreach (var phieuMuon in XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon.Values)
                {

                    foreach (var phieuTra in XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuTra.Values)
                    {
                        if (phieuMuon.MaDocGia == docGia.MaDocGia && phieuTra.MaPhieuMuon == phieuMuon.MaPhieuMuon)
                        {
                            if (txtBillCode.Text == String.Empty ||
                                docGia.MaDocGia.ToLower().Contains(txtBillCode.Text.ToLower()) ||
                                docGia.HoTen.ToLower().Contains(txtBillCode.Text.ToLower()) ||
                                phieuMuon.MaPhieuMuon.ToLower().Contains(txtBillCode.Text.ToLower()) ||
                                phieuTra.MaPhieuTra.ToLower().Contains(txtBillCode.Text.ToLower()) ||

                                dateTimePickerFrom.Value <= phieuMuon.NgayMuon && phieuMuon.NgayMuon <= dateTimePickerTo.Value ||
                                dateTimePickerFrom.Value <= phieuTra.NgayTra && phieuTra.NgayTra <= dateTimePickerTo.Value
                            )
                            {
                                var chiTietPhieuMuon = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon[phieuMuon.MaPhieuMuon];
                                var chiTietPhieuTra = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuTra[phieuTra.MaPhieuTra];

                                //dataGridView1.Rows.Add(docGia.MaDocGia, docGia.HoTen, docGia.SoDienThoai + "\n" + docGia.Email + "\n" + docGia.DiaChi,
                                //     phieuMuon.NgayMuon, phieuTra.NgayTra, phieuMuon.MaPhieuMuon, phieuTra.MaPhieuTra,
                                //     chiTietPhieuMuon.TinhTrangTruocKhiMuon, chiTietPhieuTra.TinhTrangSauMuon, chiTietPhieuMuon.SoLuong);

                                objects.Add(new object[] { docGia.MaDocGia, docGia.HoTen, docGia.SoDienThoai + "\n" + docGia.Email + "\n" + docGia.DiaChi,
                                     phieuMuon.NgayMuon, phieuTra.NgayTra, phieuMuon.MaPhieuMuon, phieuTra.MaPhieuTra,
                                     chiTietPhieuMuon.TinhTrangTruocKhiMuon, chiTietPhieuTra.TinhTrangSauMuon, chiTietPhieuMuon.SoLuong });
                            }
                        }
                    }
                }

            }

            if (comboBox1.SelectedIndex == 1)
            {
                objects = objects.OrderBy(x => x[0]).ToList();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                objects = objects.OrderByDescending(x => x[0]).ToList();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                objects = objects.OrderBy(x => x[3]).ToList();
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                objects = objects.OrderByDescending(x => x[3]).ToList();
            }

            foreach (var obj in objects)
            {
                dataGridView1.Rows.Add(obj);
            }

            LB_BorrowBillCount.Text = "Tổng số phiếu mượn: " + dataGridView1.Rows.Count;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadList();
        }
    }
}
