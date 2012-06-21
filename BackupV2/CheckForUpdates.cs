using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace BackupV2
{
    public class CheckForUpdates
    {
        public void CheckForUpdate()
        {
            throw new Exception("Not implemented yet");
            WebClient webClient = new WebClient();



            webClient.DownloadFile("UrlToTXTDownload", Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\versiontemp.txt");
            Compare();
        }

        public void Compare()
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;
            string file1 = Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Version.txt";
            string file2 = Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\versiontemp.txt";

            fs1 = new FileStream(file1, FileMode.Open);
            fs2 = new FileStream(file2, FileMode.Open);

            if (fs1.Length != fs2.Length)
            {
                fs1.Close();
                fs2.Close();
            }

            do
            {
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            fs1.Close();
            fs2.Close();
            if ((file1byte - file2byte) == 0)
            {
                //MessageBox.Show("SAME");
            }
            else
            {
                //MessageBox.Show("DIFF");
                //get new exe
                string test = Application.ExecutablePath;
                MessageBox.Show("Update downloaded. Please copy the file from " + test);
                File.Move(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Backup.exe", test);
            }
        }
    }
}
