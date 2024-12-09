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
    public partial class FormThemSach : Form
    {
        public FormThemSach()
        {
            InitializeComponent();


        }

        int saveMode = 0;

        public FormThemSach(ChiTiet_PhieuMuon chiTiet_PhieuMuon)
        {
            InitializeComponent();
            saveMode = 1;
            txt_BookCode.AutoCompleteCustomSource.AddRange(XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach.Keys.ToArray());
            txt_BookCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_BookCode.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txt_BookCode.Enabled = false;
            chiTietPM = chiTiet_PhieuMuon;


        }

        ChiTiet_PhieuMuon chiTietPM = null;

        private void ViewBookForm_Load(object sender, EventArgs e)
        {

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

            // Kiểm tra thông tin nhập vào có đủ hay chưa
            if (txt_BookCode.Text == String.Empty || txt_BookName.Text == String.Empty || txt_AuthName.Text == String.Empty || txt_BookType.Text == String.Empty || txt_Publisher.Text == String.Empty || txt_PublishYear.Text == String.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txt_PublishYear.Text, out int publishYear))
            {
                MessageBox.Show("Năm xuất bản phải là số", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            ThongTin_Sach sach = new ThongTin_Sach(txt_BookCode.Text, txt_BookName.Text, txt_AuthName.Text, txt_BookType.Text, txt_Publisher.Text, int.Parse(txt_PublishYear.Text), (Bitmap)PB_Book.Image);
            if (saveMode == 0)
            {
                if (XuLy_DuLieu.KiemTraSach(txt_BookCode.Text))
                {
                    MessageBox.Show("Mã sách đã tồn tại", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach.Add(txt_BookCode.Text, sach);
                MessageBox.Show("Thêm sách thành công", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                if (chiTietPM.DanhSach_SachMuon.ContainsKey(txt_BookCode.Text))
                {
                    MessageBox.Show("Sách đã tồn tại trong danh sách mượn", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                chiTietPM.DanhSach_SachMuon.Add(txt_BookCode.Text, sach);
                MessageBox.Show("Thêm sách thành công", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            FormQuanLySach.Instance.layDanhSach_Sach();

            //DialogResult = DialogResult.OK;
            if (MessageBox.Show("Bạn có muốn tiếp tục?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

            }
            else
            {
                this.Close();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            PB_Book.Image = LayHinhSach();
        }
    }
}
