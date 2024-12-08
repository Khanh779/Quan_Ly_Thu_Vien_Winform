using Quan_Ly_Thu_Vien_Winform.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Thu_Vien_Winform
{
    public partial class MainForm : Form
    {
        static MainForm instance = null;
        public static MainForm Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new MainForm();
                return instance;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            instance = this;
            FormClosed += MainForm_FormClosed;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoginForm.Instance.Show();
            LoginForm.Instance.BringToFront();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQuanLySach bookManager_Form = new FormQuanLySach();
            bookManager_Form.MdiParent = this;
            bookManager_Form.Show();
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThemSach addBookForm = new FormThemSach();
            addBookForm.MdiParent = this;
            addBookForm.Show();
        }

        private void đọcFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XuLy_DuLieu.DocFile();
            MessageBox.Show("Đọc file thành công");

        }

        private void ghiFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XuLy_DuLieu.GhiFile();
            MessageBox.Show("Ghi file thành công");
        }

        private void readersManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQuanLyDocGia readerManager_Form = new FormQuanLyDocGia();
            readerManager_Form.MdiParent = this;
            readerManager_Form.Show();
        }

        private void addReaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThemDocGia addReader_Form = new FormThemDocGia();
            addReader_Form.MdiParent = this;
            addReader_Form.Show();

        }

        private void quảnLýPhiếuMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyPhieuMuon quanLyPhieuMuon = new QuanLyPhieuMuon();
            quanLyPhieuMuon.MdiParent = this;
            quanLyPhieuMuon.Show();
        }
    }
}
