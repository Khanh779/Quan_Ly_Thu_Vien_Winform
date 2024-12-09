using Quan_Ly_Thu_Vien_Winform.DuLieu;
using System;
using System.Linq;
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
                if (XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia.ContainsKey(txt_ReaderID.Text))
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
            //if (txt_BookCode.Text == string.Empty)
            //{
            //    MessageBox.Show("Vui lòng nhập mã sách", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            if (chiTiet.DanhSach_SachMuon.Count <= 0)
            {
                MessageBox.Show("Vui lòng thêm 1 sách để tiếp tục", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //if (chiTiet.DanhSach_SachMuon.Count > 0 && !XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach.ContainsKey(txt_BookCode.Text))
            //{
            //    MessageBox.Show("Mã sách không tồn tại", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}


            string getMaPM = txt_ReaderID.Text;
            ThongTin_PhieuMuon phieuMuon = new ThongTin_PhieuMuon
            {
                MaPhieuMuon = txt_BorrowCode.Text,
                MaDocGia = txt_ReaderID.Text,
                NgayMuon = dateTimePicker1.Value,
                NgayHenTra = dateTimePicker2.Value
            };

            //chiTiet = new ChiTiet_PhieuMuon();
            chiTiet.MaPhieuMuon = phieuMuon.MaPhieuMuon;
            chiTiet.TinhTrangTruocKhiMuon = txt_StatusBeforeBorrow.Text;

            XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon.Add(phieuMuon.MaPhieuMuon, phieuMuon);
            XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon.Add(chiTiet.MaPhieuMuon, chiTiet);
            MessageBox.Show("Thêm phiếu mượn thành công", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (MessageBox.Show("Bạn có muốn tiếp tục?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txt_BookCode.Text = "";
                txt_StatusBeforeBorrow.Text = "";
                txt_BookCode.Focus();
            }
            else
            {
                Close();
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            chiTiet.DanhSach_SachMuon.Clear();
            dataGridView1.Rows.Clear();
            hienThi();
        }

        private void txt_BookCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txt_BookCode.Text != String.Empty && XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach.ContainsKey(txt_BookCode.Text))
            {
                ThongTin_Sach sach = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach[txt_BookCode.Text];

                if (chiTiet.DanhSach_SachMuon.ContainsKey(sach.MaSach))
                {
                    MessageBox.Show("Sách đã tồn tại", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                chiTiet.DanhSach_SachMuon.Add(sach.MaSach, sach);
                MessageBox.Show("Thêm sách " + sach.MaSach + " thành công", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Textbox trống hoặc mã sách không tồn tại", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            hienThi();
        }

        void hienThi()
        {
            dataGridView1.Rows.Clear();
            foreach (var item in chiTiet.DanhSach_SachMuon)
            {
                dataGridView1.Rows.Add(item.Value.MaSach, item.Value.TenSach, item.Value.TenTacGia, item.Value.NhaXuatBan, item.Value.NamXuatBan, item.Value.LoaiSach);
            }
        }
    }
}
