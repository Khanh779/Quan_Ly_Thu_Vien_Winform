using System;
using System.Collections.Generic;
using System.Linq;

namespace Quan_Ly_Thu_Vien_Winform.DuLieu
{
    [Serializable]
    public class ChiTiet_PhieuTra
    {
        public string MaPhieuTra { get; set; }
        public Dictionary<string, ThongTin_Sach> DanhSach_SachTra
        {
            get
            {
                var a = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_PhieuTra.FirstOrDefault(x => x.Value.MaPhieuTra == MaPhieuTra).Value.MaPhieuMuon;
                var b = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon.FirstOrDefault(x => x.Value.MaPhieuMuon == a).Value.DanhSach_SachMuon;
                return a != null ? b : new Dictionary<string, ThongTin_Sach>();
            }
        }

        public int SoLuongTra
        {
            get
            {
                return DanhSach_SachTra.Values.ToList().Count();
            }
        }
        public string TinhTrangSauMuon { get; set; }


        public ChiTiet_PhieuTra()
        {
        }

        public ChiTiet_PhieuTra(string maPhieuTra, string tinhTrangSauMuon)
        {
            MaPhieuTra = maPhieuTra;
            TinhTrangSauMuon = tinhTrangSauMuon;
        }
    }
}
