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
    public partial class LoginForm : Form
    {
        static LoginForm instance=null;
        public static LoginForm Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new LoginForm();
                return instance;
            }
        }

        public LoginForm()
        {
            InitializeComponent();
            instance = this;

            FormClosed += LoginForm_FormClosed;

        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text!= String.Empty && txtPassword.Text != String.Empty)
            {
                if (txtUserName.Text == "Admin" && txtPassword.Text == "Admin")
                {
                    MessageBox.Show("Đăng nhập thành công");
                    MainForm.Instance.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
