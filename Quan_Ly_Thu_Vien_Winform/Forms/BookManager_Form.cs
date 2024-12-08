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
    public partial class BookManager_Form : Form
    {
        public BookManager_Form()
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
                Controls.BookButton bookButton = new Controls.BookButton();
                bookButton.BookContent = item.Value.TenSach + "\n(" + item.Value.MaSach + ")";
                bookButton.BookBitmap = item.Value.HinhAnh;
                bookButton.Size = new Size(180, 180);

                bookButton.Click += (s, ev) =>
                {
                    ViewBookForm bookDetail_Form = new ViewBookForm(item.Value);
                    bookDetail_Form.MdiParent = MainForm.Instance;
                    bookDetail_Form.Show();
                };

                flowLayoutPanel1.Controls.Add(bookButton);
            }
            label1.Text = "Tổng số sách: " + XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddBookForm addBookForm = new AddBookForm();
            addBookForm.MdiParent = MainForm.Instance;
            addBookForm.Show();
        }
    }
}
