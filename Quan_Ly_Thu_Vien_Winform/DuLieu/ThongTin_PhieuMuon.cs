using System;

namespace Quan_Ly_Thu_Vien_Winform.DuLieu
{
    [Serializable]
    public class ThongTin_PhieuMuon
    {
        public string MaPhieuMuon { get; set; } = "";
        public string MaDocGia { get; set; } = "";

        public DateTime NgayMuon { get; set; } = DateTime.Now;
        public DateTime NgayHenTra { get; set; } = DateTime.Now;


        public ThongTin_PhieuMuon()
        {
            MaDocGia = MaPhieuMuon = "";
            NgayMuon = NgayHenTra = DateTime.Now;
        }

        public ThongTin_PhieuMuon(string maDocGia, string maPhieuMuon, DateTime ngayMuon, DateTime ngayTra)
        {
            MaDocGia = maDocGia;
            MaPhieuMuon = maPhieuMuon;
            NgayMuon = ngayMuon;
            NgayHenTra = ngayTra;
        }



    }


}
