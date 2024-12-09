using System;
using System.Drawing;
namespace Quan_Ly_Thu_Vien_Winform.DuLieu
{
    [Serializable]
    public class ThongTin_Sach
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string TenTacGia { get; set; }
        public string LoaiSach { get; set; }
        public string NhaXuatBan { get; set; }
        public int NamXuatBan { get; set; }
        public Bitmap HinhAnh { get; set; } = null;

        public ThongTin_Sach()
        {
            MaSach = TenSach = TenTacGia = LoaiSach = NhaXuatBan = "";
            NamXuatBan = 0;
        }

        public ThongTin_Sach(string maSach, string tenSach, string tenTacGia, string loaiSach, string nhaXB,
            int namXB, Bitmap hinhAnh = null)
        {
            MaSach = maSach;
            TenSach = tenSach;
            TenTacGia = tenTacGia;
            LoaiSach = loaiSach;
            NhaXuatBan = nhaXB;
            NamXuatBan = namXB;
            HinhAnh = hinhAnh;
        }
    }


}
