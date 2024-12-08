using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Thu_Vien_Winform
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //string updateUrl = "https://github.com/Khanh779/Quan_Ly_Thu_Vien_Winform/raw/refs/heads/master/Quan_Ly_Thu_Vien_Winform/bin/Debug/Quan_Ly_Thu_Vien_Winform.exe";
            //string fileName = updateUrl.Substring(updateUrl.LastIndexOf('/') + 1);
            //string localPath = Application.StartupPath + "\\" + fileName;

            //if (File.Exists(localPath))
            //{
            //    try
            //    {
            //        File.Delete(localPath);
            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //}

            //using (WebClient client = new WebClient())
            //{
            //    try
            //    {
            //        client.DownloadFile(updateUrl, localPath);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Lỗi khi tải file: " + ex.Message);
            //        return;
            //    }
            //}



            //MessageBox.Show("Đã cập nhật file " + fileName);


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());

        }


    }
}
