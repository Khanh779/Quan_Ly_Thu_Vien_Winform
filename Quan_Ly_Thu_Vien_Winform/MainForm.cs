using Quan_Ly_Thu_Vien_Winform.Forms;
using System;
using System.IO;
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
            var bookManager_Form = FormQuanLySach.Instance;
            bookManager_Form.MdiParent = this;
            bookManager_Form.Show();
            bookManager_Form.BringToFront();
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThemSach addBookForm = new FormThemSach
            {
                MdiParent = this
            };
            addBookForm.Show();
        }

        private void đọcFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (XuLy_DuLieu.DocFile() == true)
            {
                MessageBox.Show("Đọc file thành công", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đọc file thất bại", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void ghiFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (XuLy_DuLieu.GhiFile() == true)
            {
                MessageBox.Show("Ghi file thành công", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ghi file thất bại", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void readersManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQuanLyDocGia readerManager_Form = new FormQuanLyDocGia
            {
                MdiParent = this
            };
            readerManager_Form.Show();
        }

        private void addReaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThemDocGia addReader_Form = new FormThemDocGia
            {
                MdiParent = this
            };
            addReader_Form.Show();

        }

        private void quảnLýPhiếuMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyPhieuMuon quanLyPhieuMuon = new QuanLyPhieuMuon
            {
                MdiParent = this
            };
            quanLyPhieuMuon.Show();
        }

        private void quảnLýPhiếuTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyPhieuTra quanLyPhieuTra = new QuanLyPhieuTra
            {
                MdiParent = this
            };
            quanLyPhieuTra.Show();
        }

        private void createExampleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn tạo dữ liệu mẫu không?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (File.Exists("DuLieu_LuuTru.dk"))
                {
                    if (MessageBox.Show("File dữ liệu đã tồn tại, việc ghi đè sẽ xóa hết dữ liệu cũ\nBạn có muốn tiếp tục?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        return;
                    }
                    XuLy_DuLieu.TruyCap_DuLieu = new TruyCap_DuLieu();
                    XuLy_DuLieu.TaoVidu();
                }
             
                MessageBox.Show("Tạo dữ liệu mẫu thành công", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void thêmPhiếuTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddReturnBill formAddReturnBill = new FormAddReturnBill
            {
                MdiParent = MainForm.Instance
            };
            formAddReturnBill.Show();

        }

        private void thêmPhiếuMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddBorrowBill formAddBorrowBill = new FormAddBorrowBill
            {
                MdiParent = MainForm.Instance
            };
            formAddBorrowBill.Show();
        }

        private void lịchSửToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHistory formHistory = new FormHistory
            {
                MdiParent = MainForm.Instance
            };
            formHistory.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn ghi file không?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                XuLy_DuLieu.GhiFile();
            }
        }
    }
}
