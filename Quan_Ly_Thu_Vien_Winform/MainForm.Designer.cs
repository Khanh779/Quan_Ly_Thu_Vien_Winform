﻿    namespace Quan_Ly_Thu_Vien_Winform
    {
        partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addReaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readersManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuMượnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmPhiếuMượnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýPhiếuMượnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuTrảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmPhiếuTrảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýPhiếuTrảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.khácToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookToolStripMenuItem,
            this.readersToolStripMenuItem,
            this.phiếuMượnToolStripMenuItem,
            this.phiếuTrảToolStripMenuItem,
            this.khácToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1142, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bookToolStripMenuItem
            // 
            this.bookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addBookToolStripMenuItem,
            this.viewBooksToolStripMenuItem});
            this.bookToolStripMenuItem.Name = "bookToolStripMenuItem";
            this.bookToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.bookToolStripMenuItem.Text = "Sách";
            // 
            // addBookToolStripMenuItem
            // 
            this.addBookToolStripMenuItem.Name = "addBookToolStripMenuItem";
            this.addBookToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addBookToolStripMenuItem.Text = "Thêm sách";
            this.addBookToolStripMenuItem.Click += new System.EventHandler(this.addBookToolStripMenuItem_Click);
            // 
            // viewBooksToolStripMenuItem
            // 
            this.viewBooksToolStripMenuItem.Name = "viewBooksToolStripMenuItem";
            this.viewBooksToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewBooksToolStripMenuItem.Text = "Quản lý sách";
            this.viewBooksToolStripMenuItem.Click += new System.EventHandler(this.viewBooksToolStripMenuItem_Click);
            // 
            // readersToolStripMenuItem
            // 
            this.readersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addReaderToolStripMenuItem,
            this.readersManagerToolStripMenuItem});
            this.readersToolStripMenuItem.Name = "readersToolStripMenuItem";
            this.readersToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.readersToolStripMenuItem.Text = "Độc giả";
            // 
            // addReaderToolStripMenuItem
            // 
            this.addReaderToolStripMenuItem.Name = "addReaderToolStripMenuItem";
            this.addReaderToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.addReaderToolStripMenuItem.Text = "Thêm độc giả";
            // 
            // readersManagerToolStripMenuItem
            // 
            this.readersManagerToolStripMenuItem.Name = "readersManagerToolStripMenuItem";
            this.readersManagerToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.readersManagerToolStripMenuItem.Text = "Quản lý độc giả";
            // 
            // phiếuMượnToolStripMenuItem
            // 
            this.phiếuMượnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmPhiếuMượnToolStripMenuItem,
            this.quảnLýPhiếuMượnToolStripMenuItem});
            this.phiếuMượnToolStripMenuItem.Name = "phiếuMượnToolStripMenuItem";
            this.phiếuMượnToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.phiếuMượnToolStripMenuItem.Text = "Phiếu mượn";
            // 
            // thêmPhiếuMượnToolStripMenuItem
            // 
            this.thêmPhiếuMượnToolStripMenuItem.Name = "thêmPhiếuMượnToolStripMenuItem";
            this.thêmPhiếuMượnToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.thêmPhiếuMượnToolStripMenuItem.Text = "Thêm phiếu mượn";
            // 
            // quảnLýPhiếuMượnToolStripMenuItem
            // 
            this.quảnLýPhiếuMượnToolStripMenuItem.Name = "quảnLýPhiếuMượnToolStripMenuItem";
            this.quảnLýPhiếuMượnToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.quảnLýPhiếuMượnToolStripMenuItem.Text = "Quản lý phiếu mượn";
            // 
            // phiếuTrảToolStripMenuItem
            // 
            this.phiếuTrảToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmPhiếuTrảToolStripMenuItem,
            this.quảnLýPhiếuTrảToolStripMenuItem});
            this.phiếuTrảToolStripMenuItem.Name = "phiếuTrảToolStripMenuItem";
            this.phiếuTrảToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.phiếuTrảToolStripMenuItem.Text = "Phiếu trả";
            // 
            // thêmPhiếuTrảToolStripMenuItem
            // 
            this.thêmPhiếuTrảToolStripMenuItem.Name = "thêmPhiếuTrảToolStripMenuItem";
            this.thêmPhiếuTrảToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.thêmPhiếuTrảToolStripMenuItem.Text = "Thêm phiếu trả";
            // 
            // quảnLýPhiếuTrảToolStripMenuItem
            // 
            this.quảnLýPhiếuTrảToolStripMenuItem.Name = "quảnLýPhiếuTrảToolStripMenuItem";
            this.quảnLýPhiếuTrảToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.quảnLýPhiếuTrảToolStripMenuItem.Text = "Quản lý phiếu trả";
            // 
            // khácToolStripMenuItem
            // 
            this.khácToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thốngKêToolStripMenuItem});
            this.khácToolStripMenuItem.Name = "khácToolStripMenuItem";
            this.khácToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.khácToolStripMenuItem.Text = "Khác";
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.thốngKêToolStripMenuItem.Text = "Thống kê";
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1142, 692);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.MenuStrip menuStrip1;
            private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem addBookToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem viewBooksToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem readersToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem addReaderToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem readersManagerToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem phiếuMượnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmPhiếuMượnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýPhiếuMượnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuTrảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmPhiếuTrảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýPhiếuTrảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem khácToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
    }
    }