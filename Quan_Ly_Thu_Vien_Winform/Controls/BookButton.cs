using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace Quan_Ly_Thu_Vien_Winform.Controls
{
    public partial class BookButton : UserControl
    {
        public BookButton()
        {
            InitializeComponent();
            Paint += BookButton_Paint;
            BookBitmap = bookBitmap;

        }

        private Bitmap bookBitmap = null;
        public Bitmap BookBitmap
        {
            get => bookBitmap;
            set
            {
                bookBitmap = value;
                PBB.Image = bookBitmap != null ? bookBitmap : Properties.Resources.icons8_open_book_100__1_;
                Invalidate();
            }
        }

        string bookContent = "";
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [SettingsBindable(true)]
        public string BookContent
        {
            get => bookContent;
            set
            {
                bookContent = value;
                label1.Text = bookContent;
                Invalidate();
            }
        }

        private void BookButton_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.DrawRectangle(new Pen(Color.Silver, 1), 0, 0, Width - 1, Height - 1);
        }

        private void PBB_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
    }
}
