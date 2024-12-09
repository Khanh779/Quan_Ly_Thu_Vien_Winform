using Quan_Ly_Thu_Vien_Winform.DuLieu;
using System;
using System.Collections.Generic;

namespace Quan_Ly_Thu_Vien_Winform
{
    [Serializable]
    public class TruyCap_DuLieu
    {
        public Dictionary<string, ThongTin_DocGia> DanhSach_DocGia;
        public Dictionary<string, ThongTin_Sach> DanhSach_Sach;

        // Các phiếu
        public Dictionary<string, ThongTin_PhieuMuon> DanhSach_PhieuMuon;
        public Dictionary<string, ChiTiet_PhieuMuon> DanhSach_ChiTietPhieuMuon;

        public Dictionary<string, ThongTin_PhieuTra> DanhSach_PhieuTra;
        public Dictionary<string, ChiTiet_PhieuTra> DanhSach_ChiTietPhieuTra;

        public TruyCap_DuLieu()
        {
            DanhSach_DocGia = new Dictionary<string, ThongTin_DocGia>();
            DanhSach_Sach = new Dictionary<string, ThongTin_Sach>();

            DanhSach_PhieuMuon = new Dictionary<string, ThongTin_PhieuMuon>();
            DanhSach_ChiTietPhieuMuon = new Dictionary<string, ChiTiet_PhieuMuon>();

            DanhSach_PhieuTra = new Dictionary<string, ThongTin_PhieuTra>();
            DanhSach_ChiTietPhieuTra = new Dictionary<string, ChiTiet_PhieuTra>();
        }


        //public bool Toan_Bo_Du_Lieu__Trong
        //{
        //    get
        //    {
        //        return DanhSach_DocGia.Count == 0 && DanhSach_Sach.Count == 0 && DanhSach_PhieuMuon.Count == 0 && DanhSach_ChiTietPhieuMuon.Count == 0 && DanhSach_PhieuTra.Count == 0 && DanhSach_ChiTietPhieuTra.Count == 0;
        //    }
        //}

    }
}
