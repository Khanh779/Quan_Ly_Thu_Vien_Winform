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
    public partial class FormQuanLySach : Form
    {
        public FormQuanLySach()
        {
            InitializeComponent();
        }

        private void BookManager_Form_Load(object sender, EventArgs e)
        {
            layDanhSach_Sach();

        }

        void layDanhSach_Sach()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var item in XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach)
            {
                if (txt_BookCode.Text == String.Empty || item.Key.ToLower().Contains(txt_BookCode.Text.ToLower()) || item.Value.TenSach.ToLower().Contains(txt_BookCode.Text.ToLower()))
                {
                    Controls.BookButton bookButton = new Controls.BookButton();
                    bookButton.BookContent = item.Value.TenSach + "\n(" + item.Value.MaSach + ")";
                    bookButton.BookBitmap = item.Value.HinhAnh;
                    bookButton.Size = new Size(180, 180);

                    bookButton.Click += (s, ev) =>
                    {
                        FormXemSach bookDetail_Form = new FormXemSach(item.Value);
                        bookDetail_Form.MdiParent = MainForm.Instance;
                        bookDetail_Form.Show();
                    };

                    flowLayoutPanel1.Controls.Add(bookButton);
                }
            }
            label1.Text = "Tổng số sách: " + flowLayoutPanel1.Controls.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormThemSach addBookForm = new FormThemSach();
            addBookForm.MdiParent = MainForm.Instance;
            addBookForm.Show();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            layDanhSach_Sach();
        }

        private void txt_BookCode_TextChanged(object sender, EventArgs e)
        {
            layDanhSach_Sach();
        }
    }
}
