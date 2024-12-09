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
    public partial class FormAddReturnBill : Form
    {
        public FormAddReturnBill()
        {
            InitializeComponent();
        }

        public void SetPreviewBorrowCode(string maPM)
        {
            txt_BorrowCode.Text = maPM;

        }

        private void FormAddReturnBill_Load(object sender, EventArgs e)
        {
            txt_BorrowCode.AutoCompleteCustomSource.AddRange(XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon.Keys.ToArray());

        }

        private void txt_BorrowCode_TextChanged(object sender, EventArgs e)
        {
            string maPM = txt_BorrowCode.Text;
            if (txt_BorrowCode.Text != String.Empty && txt_BorrowCode.Text.Contains("-"))
            {
                txt_ReturnCode.Text = XuLy_DuLieu.TaoMaTra(maPM.Split('-')[1]);
                txt_ReaderCode.Text = maPM.Split('-')[1];

                dateTimePicker1.Value = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon.ContainsKey(maPM) ? XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon[maPM].NgayMuon : DateTime.Now;

                dataGridView1.Rows.Clear();

                foreach (var a in XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon[maPM].DanhSach_SachMuon.Values)
                {
                    dataGridView1.Rows.Add(a.MaSach, a.TenSach, a.TenTacGia, a.LoaiSach, a.NhaXuatBan, a.NamXuatBan);
                }
            }

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string getMaPM = txt_BorrowCode.Text;
            if (MessageBox.Show("Xác nhận xoá/ trả từ phiếu mượn " + getMaPM + " phải ko?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuMuon.Remove(getMaPM);
                //XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon.Remove(getMaPM);
                //MessageBox.Show("Đã xoá phiếu mượn", Application.ProductName + " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (XuLy_DuLieu.KiemTraPhieuTra_TuMaPhieuMuon(getMaPM))
                {
                    MessageBox.Show("Phiếu mượn đã được trả, không thể xoá/ trả", Application.ProductName + " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ThongTin_PhieuTra phieuTra = new ThongTin_PhieuTra(getMaPM, XuLy_DuLieu.TaoMaTra(getMaPM), "", DateTime.Now);
                ChiTiet_PhieuTra chiTiet_PhieuTra = new ChiTiet_PhieuTra(phieuTra.MaPhieuTra, txt_StatusAfterReturn.Text);

                XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuTra.Add(phieuTra.MaPhieuTra, phieuTra);
                XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuTra.Add(chiTiet_PhieuTra.MaPhieuTra, chiTiet_PhieuTra);

                MessageBox.Show("Thêm phiếu trả thành công", Application.ProductName + " Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
