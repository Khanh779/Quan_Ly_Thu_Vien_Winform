using Quan_Ly_Thu_Vien_Winform.DuLieu;
using System;
using System.Windows.Forms;

namespace Quan_Ly_Thu_Vien_Winform.Forms
{
    public partial class FormThemDocGia : Form
    {
        public FormThemDocGia()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_ReaderCode.Text == String.Empty || txt_ReaderName.Text == String.Empty || txt_Address.Text == String.Empty || txt_NumberPhone.Text == String.Empty || txt_Email.Text == String.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XuLy_DuLieu.KiemTraDocGia(txt_ReaderCode.Text))
            {
                MessageBox.Show("Mã độc giả đã tồn tại", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ThongTin_DocGia thongTin_DocGia = new ThongTin_DocGia(txt_ReaderCode.Text, txt_ReaderName.Text, txt_Address.Text, txt_NumberPhone.Text, txt_Email.Text);
            XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia.Add(thongTin_DocGia.MaDocGia, thongTin_DocGia);
            MessageBox.Show("Thêm độc giả thành công", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (MessageBox.Show("Bạn có muốn tiếp tục?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txt_ReaderCode.Text = txt_ReaderName.Text = txt_Address.Text = txt_NumberPhone.Text = txt_Email.Text = "";
            }
            else
            {
                Close();
            }
        }
    }
}
