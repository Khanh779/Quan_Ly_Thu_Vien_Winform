using Quan_Ly_Thu_Vien_Winform.DuLieu;
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
    public partial class FormQuanLyDocGia : Form
    {
        public FormQuanLyDocGia()
        {
            InitializeComponent();
        }


        void LayDanhSach_DocGia()
        {
            //dataGridView1.DataSource = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia.Values.ToList();

            dataGridView1.Rows.Clear();
            foreach (var docGia in XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia.Values)
            {
                if (txt_ReaderFilter.Text == String.Empty || docGia.HoTen.ToLower().Contains(txt_ReaderFilter.Text.ToLower()) || docGia.MaDocGia.ToLower().Contains(txt_ReaderFilter.Text.ToLower()))
                {
                    dataGridView1.Rows.Add(docGia.MaDocGia, docGia.HoTen, docGia.DiaChi, docGia.SoDienThoai, docGia.Email);
                }

                LB_ReaderCount.Text = "Tổng số độc giả: " + dataGridView1.Rows.Count;
            }
        }

        private void ReaderManager_Form_Load(object sender, EventArgs e)
        {
            LayDanhSach_DocGia();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin nhập vào đã đủ chưa
            if (txt_ReaderCode.Text == String.Empty || txt_ReaderName.Text == String.Empty || txt_Address.Text == String.Empty || txt_NumberPhone.Text == String.Empty || txt_Email.Text == String.Empty)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XuLy_DuLieu.KiemTraDocGia(txt_ReaderCode.Text))
            {
                MessageBox.Show("Mã độc giả đã tồn tại", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ThongTin_DocGia thongTin_DocGia = new ThongTin_DocGia(txt_ReaderCode.Text, txt_ReaderName.Text, txt_Address.Text, txt_NumberPhone.Text, txt_Email.Text);
            XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia.Add(thongTin_DocGia.MaDocGia, thongTin_DocGia);
            MessageBox.Show("Thêm độc giả thành công", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            LayDanhSach_DocGia();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            var getRowSelected = dataGridView1.Rows[e.RowIndex];
            txt_ReaderCode.Text = getRowSelected.Cells[0].Value.ToString();
            txt_ReaderName.Text = getRowSelected.Cells[1].Value.ToString();
            txt_Address.Text = getRowSelected.Cells[2].Value.ToString();
            txt_NumberPhone.Text = getRowSelected.Cells[3].Value.ToString();
            txt_Email.Text = getRowSelected.Cells[4].Value.ToString();


        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var getRowSelected = dataGridView1.SelectedRows[0];
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá độc giả " + getRowSelected.Cells[0].Value.ToString() + " này không?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ThongTin_DocGia thongTin_DocGia = new ThongTin_DocGia(txt_ReaderCode.Text, txt_ReaderName.Text, txt_Address.Text, txt_NumberPhone.Text, txt_Email.Text);

                    XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia[thongTin_DocGia.MaDocGia] = thongTin_DocGia;
                    MessageBox.Show("Sửa thông tin độc giả thành công", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LayDanhSach_DocGia();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn độc giả cần sửa", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var getRowSelected = dataGridView1.SelectedRows[0];
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá độc giả " + getRowSelected.Cells[0].Value.ToString() + " này không?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    XuLy_DuLieu.TruyCap_DuLieu.DanhSach_DocGia.Remove(getRowSelected.Cells[0].Value.ToString());
                    MessageBox.Show("Xoá độc giả thành công", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                LayDanhSach_DocGia();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn độc giả cần xoá", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txt_ReaderFilter_TextChanged(object sender, EventArgs e)
        {
            LayDanhSach_DocGia();
        }
    }
}
