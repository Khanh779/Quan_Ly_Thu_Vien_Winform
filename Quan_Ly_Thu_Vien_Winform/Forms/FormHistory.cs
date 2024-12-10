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
            comboBox1.DataSource = new List<string>
            {
                "Tất cả",
                "Chỉ mượn"
            };
            dateTimePickerFrom.Value = DateTime.Now.AddDays(-12);
            dateTimePickerTo.Value = DateTime.Now.AddDays(12);
            LoadList();
        }

        void LoadList()
        {
            dataGridView1.Rows.Clear();
            List<object[]> rrows = new List<object[]>();
            foreach (var phieuMuon in XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon.Values)
            {
                List<object> rrow = new List<object>();
                var docGia = XuLy_DuLieu.KiemTraDocGia(phieuMuon.MaDocGia) ? XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia[phieuMuon.MaDocGia] : null;
                var v = docGia != null ? docGia.HoTen : "<Không xác định";
                rrow.Add(docGia != null ? docGia.MaDocGia : "<Không xác định>");
                rrow.Add(v);
                rrow.Add(docGia != null ? docGia.SoDienThoai + "\n" + docGia.Email + "\n" + docGia.DiaChi : "");

                if (XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon.ContainsKey(phieuMuon.MaPhieuMuon))
                {
                    var chiTietPhieuMuon = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon[phieuMuon.MaPhieuMuon];
                    rrow.Add(phieuMuon.MaPhieuMuon);
                    rrow.Add(phieuMuon.NgayMuon);
                    rrow.Add(phieuMuon.NgayHenTra);
                    rrow.Add(chiTietPhieuMuon.TinhTrangTruocKhiMuon);
                }

                bool tonTaiPhieuTra = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuTra.Values.ToList().Exists(x => x.MaPhieuMuon == phieuMuon.MaPhieuMuon);
                if (tonTaiPhieuTra)
                {
                    var phieuTra = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuTra.Values.ToList().Find(x => x.MaPhieuMuon == phieuMuon.MaPhieuMuon);
                    rrow.Add(phieuTra.MaPhieuTra);
                    rrow.Add(phieuTra.NgayTra);

                    var chiTietPhieuTra = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuTra[phieuTra.MaPhieuTra];
                    rrow.Add(chiTietPhieuTra.TinhTrangSauMuon);
                    rrow.Add(chiTietPhieuTra.SoLuongTra);
                }
                else
                {
                    rrow.Add("");
                    rrow.Add("");
                    rrow.Add("");
                    rrow.Add("");
                }
                rrows.Add(rrow.ToArray());
            }


            foreach (var rrow in rrows)
            {
                if (txtBillCode.Text == String.Empty ||
                    rrow[3].ToString().ToLower().Contains(txtBillCode.Text.ToLower()) ||
                    rrow[7].ToString().ToLower().Contains(txtBillCode.Text.ToLower())

                )
                {

                    if (comboBox1.SelectedIndex == 1)
                    {
                        if (rrow[7].ToString() == "")
                            continue;
                    }

                    if (dateTimePickerFrom.Value > Convert.ToDateTime(rrow[4]) || Convert.ToDateTime(rrow[4]) > dateTimePickerTo.Value)
                    {
                        continue;
                    }
                    if (dateTimePickerFrom.Value > Convert.ToDateTime(rrow[5]) || Convert.ToDateTime(rrow[5]) > dateTimePickerTo.Value)
                    {
                        continue;
                    }

                    if (rrow[8].ToString() != "" && (dateTimePickerTo.Value > Convert.ToDateTime(rrow[8]) || Convert.ToDateTime(rrow[8]) > dateTimePickerTo.Value))
                    {
                        continue;
                    }

                    dataGridView1.Rows.Add(rrow);
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
