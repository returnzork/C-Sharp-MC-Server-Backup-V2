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
        WebClient webClient = new WebClient();
        WebClient webClient2 = new WebClient();
        public void CheckForUpdate()
        {
            throw new Exception("Not implemented yet");

            webClient.DownloadFile("FROM", Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\versiontemp.txt");
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

            if (fs1.Length == fs2.Length)
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
                GetExe();
                string AppPath = Application.ExecutablePath;
                string Update = AppPath + ".update\\";

                if(!Directory.Exists(Update))
                {
                    Directory.CreateDirectory(Update);
                }
                File.Move(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\BackupV2.exe", Update + "BackupV2.exe");
                File.Delete(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\version.txt");
                File.Move(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\versiontemp.txt", Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\version.txt");
                MessageBox.Show("Update downloaded. Please copy the file from: " + Update);
            }
        }

        public void GetExe()
        {
            webClient2.DownloadFile("FROM", Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\BackupV2.exe");
        }
    }
}
