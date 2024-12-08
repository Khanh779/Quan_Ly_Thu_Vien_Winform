
using System;
using System.Collections.Generic;

namespace Quan_Ly_Thu_Vien_Winform.DuLieu
{
    [Serializable]
    public class ChiTiet_PhieuMuon
    {
        public string MaPhieuMuon { get; set; } = "";
        public Dictionary<string, ThongTin_Sach> DanhSach_SachMuon { get; set; } = new Dictionary<string, ThongTin_Sach>();
        public int SoLuong
        {
            get
            {
                return DanhSach_SachMuon.Count;
            }
        }

        public string TinhTrangTruocKhiMuon { get; set; } = "";

        public ChiTiet_PhieuMuon()
        {
        }
        public ChiTiet_PhieuMuon(string maPhieuMuon, Dictionary<string, ThongTin_Sach> danhSach_SachMuon, string tinhTrangTruocKhiMuon)
        {
            MaPhieuMuon = maPhieuMuon;
            DanhSach_SachMuon = danhSach_SachMuon;
            TinhTrangTruocKhiMuon = tinhTrangTruocKhiMuon;

        }

    }
}
