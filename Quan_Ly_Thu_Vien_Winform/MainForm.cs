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
            BookManager_Form bookManager_Form = new BookManager_Form();
            bookManager_Form.MdiParent = this;
            bookManager_Form.Show();
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBookForm addBookForm = new AddBookForm();
            addBookForm.MdiParent = this;
            addBookForm.Show();
        }
    }
}
