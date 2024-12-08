using System;

namespace Quan_Ly_Thu_Vien_Winform.DuLieu
{
    [Serializable]
    public class ThongTin_DocGia
    {
        public string MaDocGia { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }



        public ThongTin_DocGia()
        {
            MaDocGia = HoTen = DiaChi = SoDienThoai = Email = "";
        }

        public ThongTin_DocGia(string maNguoiMuon, string hoTen, string diaChi, string soDienThoai, string email)
        {
            MaDocGia = maNguoiMuon;
            HoTen = hoTen;
            DiaChi = diaChi;
            SoDienThoai = soDienThoai;
            Email = email;
        }
    }

    public enum TrangThaiMuonTra
    {
        DangMuon,
        DaTra
    }
}
