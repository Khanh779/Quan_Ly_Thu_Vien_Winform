using Quan_Ly_Thu_Vien_Winform.DuLieu;
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
                "Tất cả",
                "Chỉ mượn",
                "Chỉ trả"
            };
        }

        void LoadList()
        {
            dataGridView1.Rows.Clear();
            foreach (var phieuMuon in XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon.Values)
            {
                List<object> rrow = new List<object>();
                var docGia = XuLy_DuLieu.KiemTraDocGia(phieuMuon.MaDocGia) ? XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia[phieuMuon.MaDocGia] : null;
                var v = docGia != null ? docGia.HoTen : "<ko xác định";
                rrow.Add(docGia != null ? docGia.MaDocGia : "<Không xác định>");
                rrow.Add(v);
                rrow.Add(docGia != null ? docGia.SoDienThoai + "\n" + docGia.Email + "\n" + docGia.DiaChi : "");

                if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 1)
                {
                    if (XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon.ContainsKey(phieuMuon.MaPhieuMuon))
                    {
                        var chiTietPhieuMuon = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon[phieuMuon.MaPhieuMuon];
                        rrow.Add(phieuMuon.MaPhieuMuon);
                        rrow.Add(phieuMuon.NgayMuon);
                        rrow.Add(phieuMuon.NgayHenTra);
                        rrow.Add(chiTietPhieuMuon.TinhTrangTruocKhiMuon);
                    }
                }

                if (comboBox1.SelectedIndex == 0 || comboBox1.SelectedIndex == 2)
                {
                    if (comboBox1.SelectedIndex == 2)
                    {
                        rrow.Add("");
                        rrow.Add("");
                        rrow.Add("");
                        rrow.Add("");
                    }

                    foreach (var item in XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuTra.Values)
                    {
                        if (XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuTra.ContainsKey(item.MaPhieuTra))
                        {
                            var chiTietPhieuTra = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuTra[item.MaPhieuTra];
                            rrow.Add(item.MaPhieuTra);
                            rrow.Add(item.NgayTra);
                            rrow.Add(chiTietPhieuTra.TinhTrangSauMuon);
                            rrow.Add(chiTietPhieuTra.SoLuongTra);
                        }
                    }
                }

                //if (txtBillCode.Text == String.Empty ||
                //       phieuMuon.MaDocGia.ToLower().Contains(txtBillCode.Text.ToLower()) ||
                //       v.ToLower().Contains(txtBillCode.Text.ToLower()) ||
                //       phieuMuon.MaPhieuMuon.ToLower().Contains(txtBillCode.Text.ToLower()) ||
                //       phieuTra.MaPhieuTra.ToLower().Contains(txtBillCode.Text.ToLower()) ||

                //       dateTimePickerFrom.Value <= phieuMuon.NgayMuon && phieuMuon.NgayMuon <= dateTimePickerTo.Value ||
                //       dateTimePickerFrom.Value <= phieuTra.NgayTra && phieuTra.NgayTra <= dateTimePickerTo.Value
                //   )

                if (txtBillCode.Text == String.Empty ||
                    rrow[3].ToString().ToLower().Contains(txtBillCode.Text.ToLower()) ||
                    rrow[7].ToString().ToLower().Contains(txtBillCode.Text.ToLower()) ||
                    rrow[4].ToString().ToLower().Contains(txtBillCode.Text.ToLower()) || // ngay muon
                    rrow[5].ToString().ToLower().Contains(txtBillCode.Text.ToLower()) || // ngay hen tra
                    rrow[8].ToString().ToLower().Contains(txtBillCode.Text.ToLower())  // ngay tra
                )
                {
                    dataGridView1.Rows.Add(rrow.ToArray());
                }

            }
            LB_BorrowBillCount.Text = "Tổng số: " + dataGridView1.Rows.Count;
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
           // LoadList();
        }
    }
}
