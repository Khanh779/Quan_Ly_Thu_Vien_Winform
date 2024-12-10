using Quan_Ly_Thu_Vien_Winform.DuLieu;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

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

        public static bool KiemTra_KyTu_DacBiet(string chuoi)
        {
            return chuoi.Any(char.IsPunctuation);
        }

        //public static bool KiemTraPhieuMuon(string maPhieuMuon)
        //{
        //    return TruyCap_DuLieu.DanhSach_PhieuMuon.ContainsKey(maPhieuMuon);
        //}

        //public static bool KiemTraPhieuTra(string maPhieuTra)
        //{
        //    return TruyCap_DuLieu.DanhSach_PhieuTra.ContainsKey(maPhieuTra);
        //}

        public static bool KiemTraPhieuTra_TuMaPhieuMuon(string maPhieuMuon)
        {
            return TruyCap_DuLieu.DanhSach_PhieuTra.Values.ToList().Exists(x => x.MaPhieuMuon == maPhieuMuon);
        }

        public static bool DocFile(string filePath = "DuLieu_LuuTru.dk")
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
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
            else
            {
                Console.WriteLine("File not exist");
                return false;
            }
        }

        public static bool GhiFile(string filePath = "DuLieu_LuuTru.dk")
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, TruyCap_DuLieu);  // Ghi dữ liệu vào file
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }



        public static void TaoVidu()
        {
            // Thêm 100 độc giả
            for (int i = 0; i < 100; i++)
            {
                ThongTin_DocGia docGia = new ThongTin_DocGia
                {
                    MaDocGia = "DG" + i,
                    HoTen = "Độc giả " + i,
                    DiaChi = "Địa chỉ " + i,
                    SoDienThoai = "0123456789",
                    Email = "docgia" + i + "@gmail.com"
                };

                if (!TruyCap_DuLieu.DanhSach_DocGia.ContainsKey(docGia.MaDocGia))
                    TruyCap_DuLieu.DanhSach_DocGia.Add(docGia.MaDocGia, docGia);

            }

            // Thêm 100 sách
            for (int i = 0; i < 100; i++)
            {
                ThongTin_Sach sach = new ThongTin_Sach
                {
                    MaSach = "S" + i,
                    TenSach = "Sách " + i,
                    TenTacGia = "Tác giả " + i,
                    NhaXuatBan = "Nhà xuất bản " + i,
                    NamXuatBan = 2000 + i,
                    LoaiSach = "Loại sách " + i
                };

                if (!TruyCap_DuLieu.DanhSach_Sach.ContainsKey(sach.MaSach))
                    TruyCap_DuLieu.DanhSach_Sach.Add(sach.MaSach, sach);
            }

            // Thêm 40 phiếu mượn
            for (int i = 0; i < 40; i++)
            {
                ThongTin_PhieuMuon phieuMuon = new ThongTin_PhieuMuon
                {
                    MaDocGia = "DG" + i
                };
                phieuMuon.MaPhieuMuon = TaoMaMuon(phieuMuon.MaDocGia);
                phieuMuon.NgayMuon = DateTime.Now;
                phieuMuon.NgayHenTra = DateTime.Now.AddDays(7);
                TruyCap_DuLieu.DanhSach_PhieuMuon.Add(phieuMuon.MaPhieuMuon, phieuMuon);

                ChiTiet_PhieuMuon chiTiet = new ChiTiet_PhieuMuon
                {
                    TinhTrangTruocKhiMuon = "Tốt",
                    MaPhieuMuon = phieuMuon.MaPhieuMuon
                };

                chiTiet.DanhSach_SachMuon.Add("S" + i, TruyCap_DuLieu.DanhSach_Sach["S" + i]);
                if (i % 2 == 0)
                {
                    if (TruyCap_DuLieu.DanhSach_Sach.ContainsKey("S" + i + 1))
                        chiTiet.DanhSach_SachMuon.Add("S" + i + 1, TruyCap_DuLieu.DanhSach_Sach["S" + i + 1]);
                }

                if (!TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon.ContainsKey(chiTiet.MaPhieuMuon))
                    TruyCap_DuLieu.DanhSach_ChiTietPhieuMuon.Add(chiTiet.MaPhieuMuon, chiTiet);

                if (i % 2 == 0)
                {
                    ThongTin_PhieuTra phieuTra = new ThongTin_PhieuTra
                    {
                        MaPhieuMuon = phieuMuon.MaPhieuMuon
                    };
                    phieuTra.MaPhieuTra = phieuTra.MaPhieuMuon.Replace("PM", "PT");
                    phieuTra.NgayTra = DateTime.Now;

                    if (!TruyCap_DuLieu.DanhSach_PhieuTra.ContainsKey(phieuTra.MaPhieuTra))
                        TruyCap_DuLieu.DanhSach_PhieuTra.Add(phieuTra.MaPhieuTra, phieuTra);

                    ChiTiet_PhieuTra chiTietPT = new ChiTiet_PhieuTra
                    {
                        TinhTrangSauMuon = "Tốt",
                        MaPhieuTra = phieuTra.MaPhieuTra
                    };

                    if (!TruyCap_DuLieu.DanhSach_ChiTietPhieuTra.ContainsKey(chiTietPT.MaPhieuTra))
                        TruyCap_DuLieu.DanhSach_ChiTietPhieuTra.Add(chiTietPT.MaPhieuTra, chiTietPT);
                }
            }

        }


        // Dùng thời gian
        // yyyyMMddHHmmssfff - Năm, Tháng, Ngày, Giờ, Phút, Giây, Mili giây
        // yyyyMMddHHmmss - Năm, Tháng, Ngày, Giờ, Phút, Giây

        public static string TaoMaMuon(string maDocGia)
        {
            var a = DateTime.Now;
            return "PM-" + maDocGia + "-" + a.Year + a.Month + a.Day + a.Hour + a.Minute + a.Second + a.Millisecond;
        }

        public static string TaoMaTra(string maDocGia)
        {
            var a = DateTime.Now;
            return "PT-" + maDocGia + "-" + a.Year + a.Month + a.Day + a.Hour + a.Minute + a.Second + a.Millisecond;
        }


    }
}