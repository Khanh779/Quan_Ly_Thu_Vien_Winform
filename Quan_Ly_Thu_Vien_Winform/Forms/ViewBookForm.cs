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
    public partial class ViewBookForm : Form
    {
        public ViewBookForm()
        {
            InitializeComponent();
        }

        int saveMode = 0;

        public ViewBookForm(ThongTin_Sach thongTin_Sach)
        {
            InitializeComponent();
            saveMode = 1;
            txt_BookCode.Text = thongTin_Sach.MaSach;
            txt_BookName.Text = thongTin_Sach.TenSach;
            txt_AuthName.Text = thongTin_Sach.TenSach;
            txt_Publisher.Text = thongTin_Sach.NhaXuatBan;
            txt_PublishYear.Text = thongTin_Sach.NamXuatBan.ToString();
            txt_BookType.Text = thongTin_Sach.LoaiSach;
            PB_Book.Image = thongTin_Sach.HinhAnh == null ? Properties.Resources.icons8_open_book_100__1_ : thongTin_Sach.HinhAnh;

            txt_BookCode.Enabled = false;

            this.thongTin_Sach = thongTin_Sach;
        }

        ThongTin_Sach thongTin_Sach = null;

        private void ViewBookForm_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                MessageBox.Show("Chế độ chỉnh sửa được bật");
            }
            btnBrowse.Enabled = txt_BookName.Enabled = txt_BookCode.Enabled = txt_AuthName.Enabled = txt_Publisher.Enabled =
              txt_PublishYear.Enabled = txt_BookType.Enabled
              = button2.Enabled = button1.Enabled
              = checkBox1.Checked;
        }

        Bitmap LayHinhSach()
        {
            Bitmap bitmapBook = new Bitmap(50, 50);
            bitmapBook.MakeTransparent();
            using (Graphics g = Graphics.FromImage(bitmapBook))
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    g.DrawImage(new Bitmap(ofd.FileName), 0, 0, 50, 50);
                }
            }
            return bitmapBook;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveMode == 1)
            {
                ThongTin_Sach sach = new ThongTin_Sach(txt_BookCode.Text, txt_BookName.Text, txt_AuthName.Text, txt_BookType.Text, txt_Publisher.Text, int.Parse(txt_PublishYear.Text), (Bitmap)PB_Book.Image);
                thongTin_Sach = sach;
                MessageBox.Show("Cập nhật thành công");
            }
            Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            PB_Book.Image = LayHinhSach();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach.Remove(thongTin_Sach.MaSach);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
