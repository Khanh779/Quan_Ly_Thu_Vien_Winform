using Quan_Ly_Thu_Vien_Winform.DuLieu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Thu_Vien_Winform
{
    public class XuLy_DuLieu
    {

        public static TruyCap_DuLieu TruyCap_DuLieu = new TruyCap_DuLieu();


        public static bool KiemTraDocGia(string maDocGia)
        {
            return TruyCap_DuLieu.DanhSach_DocGia.ContainsKey(maDocGia);
        }

        public static bool KiemTraSach(string maSach)
        {
            return TruyCap_DuLieu.DanhSach_Sach.ContainsKey(maSach);
        }

        public static bool KiemTraPhieuMuon(string maPhieuMuon)
        {
            return TruyCap_DuLieu.DanhSach_PhieuMuon.ContainsKey(maPhieuMuon);
        }

        public static bool KiemTraPhieuTra(string maPhieuTra)
        {
            return TruyCap_DuLieu.DanhSach_PhieuTra.ContainsKey(maPhieuTra);
        }


        public static void DocFile(string filePath = "DuLieu_LuuTru.dk")
        {
            if (File.Exists(filePath))
            {
                try
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        TruyCap_DuLieu = (TruyCap_DuLieu)bf.Deserialize(fs);  // Đọc dữ liệu từ file
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("File not exist");
                XuLy_DuLieu.TaoVidu();
            }
        }

        public static void GhiFile(string filePath = "DuLieu_LuuTru.dk")
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, TruyCap_DuLieu);  // Ghi dữ liệu vào file
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        public static void TaoVidu()
        {
            // Thêm 100 độc giả
            for (int i = 0; i < 100; i++)
            {
                ThongTin_DocGia docGia = new ThongTin_DocGia();
                docGia.MaDocGia = "DG" + i;
                docGia.HoTen = "Độc giả " + i;
                docGia.DiaChi = "Địa chỉ " + i;
                docGia.SoDienThoai = "0123456789";
                docGia.Email = "docgia" + i + "@gmail.com";

                TruyCap_DuLieu.DanhSach_DocGia.Add(docGia.MaDocGia, docGia);

            }

            // Thêm 100 sách
            for (int i = 0; i < 100; i++)
            {
                ThongTin_Sach sach = new ThongTin_Sach();
                sach.MaSach = "S" + i;
                sach.TenSach = "Sách " + i;
                sach.TenTacGia = "Tác giả " + i;
                sach.NhaXuatBan = "Nhà xuất bản " + i;
                sach.NamXuatBan = 2000 + i;
                TruyCap_DuLieu.DanhSach_Sach.Add(sach.MaSach, sach);
            }

            // Thêm 40 phiếu mượn
            for (int i = 0; i < 40; i++)
            {
                ThongTin_PhieuMuon phieuMuon = new ThongTin_PhieuMuon();
                phieuMuon.MaDocGia = "DG" + i;
                phieuMuon.MaPhieuMuon = TaoMaMuon(phieuMuon.MaDocGia);
                phieuMuon.NgayMuon = DateTime.Now;
                phieuMuon.NgayHenTra = DateTime.Now.AddDays(7);
                TruyCap_DuLieu.DanhSach_PhieuMuon.Add(phieuMuon.MaPhieuMuon, phieuMuon);

                ChiTiet_PhieuMuon chiTiet = new ChiTiet_PhieuMuon();
                chiTiet.MaPhieuMuon = phieuMuon.MaPhieuMuon;
                if (i % 2 == 0)
                    chiTiet.DanhSach_SachMuon.Add("S" + i, TruyCap_DuLieu.DanhSach_Sach["S" + i]);
                TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon.Add(chiTiet.MaPhieuMuon, chiTiet);

                if (i % 3 == 0)
                {
                    ThongTin_PhieuTra phieuTra = new ThongTin_PhieuTra();
                    phieuTra.MaPhieuMuon = phieuMuon.MaPhieuMuon;
                    phieuTra.MaPhieuTra = phieuTra.MaPhieuMuon.Replace("PM", "PT");
                    phieuTra.NgayTra = DateTime.Now;
                    TruyCap_DuLieu.DanhSach_PhieuTra.Add(phieuTra.MaPhieuTra, phieuTra);

                    ChiTiet_PhieuTra chiTietPT = new ChiTiet_PhieuTra();
                    chiTietPT.MaPhieuTra = phieuTra.MaPhieuTra;
                }
            }

        }

        public static string TaoMaMuon(string maDocGia)
        {
            return maDocGia + "PM" + demSoPhieuMuon(maDocGia + "PM");
        }

        public static string TaoMaTra(string maDocGia)
        {
            return maDocGia + "PT" + demSoPhieuTra(maDocGia + "PT");
        }

        static int demSoPhieuMuon(string maPhieuMuon)
        {
            int dem = 0;
            foreach (var item in TruyCap_DuLieu.DanhSach_PhieuMuon)
            {
                if (item.Value.MaPhieuMuon.Contains(maPhieuMuon))
                {
                    dem++;
                }
            }
            return dem;
        }

        static int demSoPhieuTra(string maPhieuTra)
        {
            int dem = 0;
            foreach (var item in TruyCap_DuLieu.DanhSach_PhieuTra)
            {
                if (item.Value.MaPhieuTra.Contains(maPhieuTra))
                {
                    dem++;
                }
            }
            return dem;
        }
    }
}