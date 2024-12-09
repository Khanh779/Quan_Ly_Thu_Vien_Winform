using System;

namespace Quan_Ly_Thu_Vien_Winform.DuLieu
{
    [Serializable]
    public class ThongTin_PhieuTra
    {
        public string MaPhieuMuon { get; set; }
        public string MaPhieuTra { get; set; }
        public DateTime NgayTra { get; set; } = DateTime.Now;


        public ThongTin_PhieuTra()
        {
        }

        public ThongTin_PhieuTra(string maPhieuMuon, string maPhieuTra, string tinhTrangSauKhiTra, DateTime ngayTra)
        {
            MaPhieuMuon = maPhieuMuon;
            MaPhieuTra = maPhieuTra;
            NgayTra = ngayTra;

        }

    }
}
