namespace Quan_Ly_Thu_Vien_Winform .Forms
{
    partial class FormThemSach
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThemSach));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Publisher = new System.Windows.Forms.TextBox();
            this.txt_BookType = new System.Windows.Forms.TextBox();
            this.txt_PublishYear = new System.Windows.Forms.TextBox();
            this.txt_AuthName = new System.Windows.Forms.TextBox();
            this.txt_BookName = new System.Windows.Forms.TextBox();
            this.txt_BookCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LB_AuthName = new System.Windows.Forms.Label();
            this.LB_BookCode = new System.Windows.Forms.Label();
            this.LB_BookName = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.PB_Book = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Book)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.PB_Book);
            this.panel1.Location = new System.Drawing.Point(10, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 344);
            this.panel1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(350, 299);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button2.Size = new System.Drawing.Size(84, 30);
            this.button2.TabIndex = 9;
            this.button2.Text = "Xoá";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(133)))), ((int)(((byte)(237)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(440, 299);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(84, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Publisher);
            this.groupBox1.Controls.Add(this.txt_BookType);
            this.groupBox1.Controls.Add(this.txt_PublishYear);
            this.groupBox1.Controls.Add(this.txt_AuthName);
            this.groupBox1.Controls.Add(this.txt_BookName);
            this.groupBox1.Controls.Add(this.txt_BookCode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LB_AuthName);
            this.groupBox1.Controls.Add(this.LB_BookCode);
            this.groupBox1.Controls.Add(this.LB_BookName);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(134, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 279);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // txt_Publisher
            // 
            this.txt_Publisher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.txt_Publisher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Publisher.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Publisher.Location = new System.Drawing.Point(154, 206);
            this.txt_Publisher.Name = "txt_Publisher";
            this.txt_Publisher.Size = new System.Drawing.Size(210, 25);
            this.txt_Publisher.TabIndex = 58;
            // 
            // txt_BookType
            // 
            this.txt_BookType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.txt_BookType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_BookType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_BookType.Location = new System.Drawing.Point(154, 173);
            this.txt_BookType.Name = "txt_BookType";
            this.txt_BookType.Size = new System.Drawing.Size(210, 25);
            this.txt_BookType.TabIndex = 57;
            // 
            // txt_PublishYear
            // 
            this.txt_PublishYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.txt_PublishYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_PublishYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_PublishYear.Location = new System.Drawing.Point(154, 139);
            this.txt_PublishYear.Name = "txt_PublishYear";
            this.txt_PublishYear.Size = new System.Drawing.Size(210, 25);
            this.txt_PublishYear.TabIndex = 56;
            // 
            // txt_AuthName
            // 
            this.txt_AuthName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.txt_AuthName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_AuthName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_AuthName.Location = new System.Drawing.Point(154, 105);
            this.txt_AuthName.Name = "txt_AuthName";
            this.txt_AuthName.Size = new System.Drawing.Size(210, 25);
            this.txt_AuthName.TabIndex = 55;
            // 
            // txt_BookName
            // 
            this.txt_BookName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.txt_BookName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_BookName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_BookName.Location = new System.Drawing.Point(154, 72);
            this.txt_BookName.Name = "txt_BookName";
            this.txt_BookName.Size = new System.Drawing.Size(210, 25);
            this.txt_BookName.TabIndex = 54;
            // 
            // txt_BookCode
            // 
            this.txt_BookCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.txt_BookCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_BookCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_BookCode.Location = new System.Drawing.Point(154, 36);
            this.txt_BookCode.Name = "txt_BookCode";
            this.txt_BookCode.Size = new System.Drawing.Size(210, 25);
            this.txt_BookCode.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(20, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 24);
            this.label5.TabIndex = 52;
            this.label5.Text = "Thể loại:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(20, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 24);
            this.label4.TabIndex = 51;
            this.label4.Text = "Nhà xuất bản:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(20, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 24);
            this.label1.TabIndex = 50;
            this.label1.Text = "Năm xuất bản:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LB_AuthName
            // 
            this.LB_AuthName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LB_AuthName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LB_AuthName.Location = new System.Drawing.Point(20, 103);
            this.LB_AuthName.Name = "LB_AuthName";
            this.LB_AuthName.Size = new System.Drawing.Size(111, 24);
            this.LB_AuthName.TabIndex = 49;
            this.LB_AuthName.Text = "Tên tác giả:";
            this.LB_AuthName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LB_BookCode
            // 
            this.LB_BookCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LB_BookCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LB_BookCode.Location = new System.Drawing.Point(20, 37);
            this.LB_BookCode.Name = "LB_BookCode";
            this.LB_BookCode.Size = new System.Drawing.Size(111, 24);
            this.LB_BookCode.TabIndex = 48;
            this.LB_BookCode.Text = "Mã sách:";
            this.LB_BookCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LB_BookName
            // 
            this.LB_BookName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.LB_BookName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LB_BookName.Location = new System.Drawing.Point(20, 70);
            this.LB_BookName.Name = "LB_BookName";
            this.LB_BookName.Size = new System.Drawing.Size(111, 24);
            this.LB_BookName.TabIndex = 47;
            this.LB_BookName.Text = "Tên sách:";
            this.LB_BookName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.Gray;
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(28, 190);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnBrowse.Size = new System.Drawing.Size(73, 26);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Duyệt";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // PB_Book
            // 
            this.PB_Book.Image = global::Quan_Ly_Thu_Vien_Winform.Properties.Resources.icons8_open_book_100__1_;
            this.PB_Book.Location = new System.Drawing.Point(14, 89);
            this.PB_Book.Name = "PB_Book";
            this.PB_Book.Size = new System.Drawing.Size(100, 86);
            this.PB_Book.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PB_Book.TabIndex = 0;
            this.PB_Book.TabStop = false;
            // 
            // FormThemSach
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(559, 359);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormThemSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm sách";
            this.Load += new System.EventHandler(this.ViewBookForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Book)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox PB_Book;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LB_AuthName;
        private System.Windows.Forms.Label LB_BookCode;
        private System.Windows.Forms.Label LB_BookName;
        private System.Windows.Forms.TextBox txt_BookCode;
        private System.Windows.Forms.TextBox txt_BookName;
        private System.Windows.Forms.TextBox txt_Publisher;
        private System.Windows.Forms.TextBox txt_BookType;
        private System.Windows.Forms.TextBox txt_PublishYear;
        private System.Windows.Forms.TextBox txt_AuthName;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}