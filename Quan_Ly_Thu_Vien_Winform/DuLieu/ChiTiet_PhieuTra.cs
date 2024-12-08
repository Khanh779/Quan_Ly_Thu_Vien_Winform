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
                var a = XuLy_DuLieu.TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon.Values.ToList().Find(x => x.MaPhieuMuon.Replace("PM", "PT") == MaPhieuTra).DanhSach_SachMuon;
                return a != null ? a : new Dictionary<string, ThongTin_Sach>();
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
