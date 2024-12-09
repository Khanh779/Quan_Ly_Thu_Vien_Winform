using System;
using System.Drawing;
using System.Windows.Forms;

namespace Quan_Ly_Thu_Vien_Winform.Forms
{
    public partial class FormQuanLySach : Form
    {
        static FormQuanLySach instance = null;
        public static FormQuanLySach Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new FormQuanLySach();
                //instance.BringToFront();
                return instance;
            }
        }


        public FormQuanLySach()
        {
            InitializeComponent();
            instance = this;
        }

        private void BookManager_Form_Load(object sender, EventArgs e)
        {
            layDanhSach_Sach();

        }

        public void layDanhSach_Sach()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var item in XuLy_DuLieu.TruyCap_DuLieu.DanhSach_Sach)
            {
                if (txt_BookCode.Text == String.Empty || item.Key.ToLower().Contains(txt_BookCode.Text.ToLower()) || item.Value.TenSach.ToLower().Contains(txt_BookCode.Text.ToLower()))
                {
                    Controls.BookButton bookButton = new Controls.BookButton
                    {
                        BookContent = item.Value.TenSach + "\n(" + item.Value.MaSach + ")",
                        BookBitmap = item.Value.HinhAnh,
                        Size = new Size(180, 180)
                    };

                    bookButton.Click += (s, ev) =>
                    {
                        FormXemSach bookDetail_Form = new FormXemSach(item.Value)
                        {
                            MdiParent = MainForm.Instance
                        };
                        bookDetail_Form.Show();
                    };

                    flowLayoutPanel1.Controls.Add(bookButton);
                }
            }
            label1.Text = "Tổng số sách: " + flowLayoutPanel1.Controls.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormThemSach addBookForm = new FormThemSach
            {
                MdiParent = MainForm.Instance
            };
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
