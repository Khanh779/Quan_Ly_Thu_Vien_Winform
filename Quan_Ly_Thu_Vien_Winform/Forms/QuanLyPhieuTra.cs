using Quan_Ly_Thu_Vien_Winform.DuLieu;
using System;
using System.Linq;
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
            txt_BorrowCode.AutoCompleteCustomSource.AddRange(XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon.Keys.ToArray());
            txt_BorrowCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_BorrowCode.AutoCompleteSource = AutoCompleteSource.CustomSource;



            LayDanhSachPhieuTra();

        }

        private void txt_ReaderCode_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                dataGridView1.SelectedRows[0].Selected = false;

            if (dataGridView1.SelectedColumns.Count > 0)
                dataGridView1.SelectedColumns[0].Selected = false;

            if (dataGridView1.SelectedCells.Count > 0)
                dataGridView1.SelectedCells[0].Selected = false;


            if (txt_BorrowCode.Text.Contains("-"))
            {
                txt_ReturnCode.Text = XuLy_DuLieu.TaoMaTra(txt_BorrowCode.Text.Split('-')[1]);

                if (XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon.Keys.ToList().Exists(x => x == txt_BorrowCode.Text))
                {
                    var a = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon[txt_BorrowCode.Text];
                    dateTimePicker1.Value = a.NgayMuon;
                    dateTimePicker2.Value = a.NgayHenTra;
                }
            }

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
                    if (txt_BorrowFilter.Text == String.Empty || b.MaPhieuTra.ToLower().Contains(txt_BorrowFilter.Text.ToLower()) || b.MaPhieuMuon.ToLower().Contains(txt_BorrowFilter.Text.ToLower()) || a.MaDocGia.ToLower().Contains(txt_BorrowFilter.Text.ToLower()))
                    {
                        string getReaderFullName =
                            XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia.ContainsKey(a.MaDocGia) ? XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia[a.MaDocGia].HoTen : "<ko xác định>";


                        object[] obs = new object[] {
                            b.MaPhieuTra, a.MaPhieuMuon, a.MaDocGia, getReaderFullName, a.NgayMuon, a.NgayHenTra, b.NgayTra
                        };

                        var chi = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuTra[b.MaPhieuTra];
                        if (chi != null)
                        {
                            obs = new object[] {
                                b.MaPhieuTra, a.MaPhieuMuon, a.MaDocGia, getReaderFullName, a.NgayMuon, a.NgayHenTra, b.NgayTra, chi.TinhTrangSauMuon, chi.SoLuongTra
                            };
                        }

                        dataGridView1.Rows.Add(obs);
                    }
                }
            }
            LB_BorrowBillCount.Text = "Tổng số phiếu trả: " + dataGridView1.Rows.Count;
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



        ChiTiet_PhieuTra chiTiet = new ChiTiet_PhieuTra();

        private void btn_Add_Click(object sender, EventArgs e)
        {
            ThongTin_PhieuTra phieuTra = new ThongTin_PhieuTra
            {
                MaPhieuMuon = txt_BorrowCode.Text,
                MaPhieuTra = txt_ReturnCode.Text,
                NgayTra = dateTimePicker2.Value
            };

            chiTiet.MaPhieuTra = phieuTra.MaPhieuTra;
            chiTiet.TinhTrangSauMuon = txt_StatusAfterBorrow.Text;

            if (!XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon.ContainsKey(phieuTra.MaPhieuMuon))
            {
                MessageBox.Show("Mã phiếu mượn không tồn tại", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuTra.ContainsKey(phieuTra.MaPhieuTra))
            {
                MessageBox.Show("Mã phiếu trả đã tồn tại trong danh sách phiếu trả", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (XuLy_DuLieu.KiemTraPhieuTra_TuMaPhieuMuon(phieuTra.MaPhieuMuon))
            {
                MessageBox.Show("Phiếu mượn đã được trả, tiếp tục xử lý", Application.ProductName + " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuTra.ContainsKey(phieuTra.MaPhieuTra))
            {
                XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuTra.Add(phieuTra.MaPhieuTra, phieuTra);
                XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuTra.Add(chiTiet.MaPhieuTra, chiTiet);

                MessageBox.Show("Thêm phiếu trả thành công", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Mã phiếu trả đã tồn tại", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


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
