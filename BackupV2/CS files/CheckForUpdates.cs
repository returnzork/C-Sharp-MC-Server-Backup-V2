using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Reflection;

namespace BackupV2
{
    public class CheckForUpdates
    {
        WebClient webClient = new WebClient();
        WebClient webClient2 = new WebClient();
        public void CheckForUpdate()
        {
            throw new NotImplementedException("Not implemented yet");
            Compare();
        }

        public string Compare()
        {
            throw new NotImplementedException("Not implemented yet");


            webClient.DownloadFile("C:\\ver.txt", Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\versiontemp.txt");

            string UpdateAvailable;
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

            try
            {
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
                    UpdateAvailable = "no match";
                    MessageBox.Show("No update found");
                    return UpdateAvailable;
                }
                else
                {
                    DialogResult UpdateFound = MessageBox.Show("Update found. Would you like to download?", "Update?", MessageBoxButtons.YesNo);
                    if (UpdateFound == DialogResult.Yes)
                    {
                        GetExe();
                        string AppPath = Application.ExecutablePath;
                        string Update = AppPath + ".update\\";

                        if (!Directory.Exists(Update))
                        {
                            Directory.CreateDirectory(Update);
                        }
                        if (File.Exists(Update + "BackupV2.exe"))
                        {
                            File.Delete(Update + "BackupV2.exe");
                        }
                        File.Move(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\BackupV2.exe", Update + "BackupV2.exe");
                        File.Delete(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\version.txt");
                        File.Move(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\versiontemp.txt", Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\version.txt");
                        MessageBox.Show("Update downloaded. Please copy the file from: " + Update);
                        UpdateAvailable = "no";
                        return UpdateAvailable;
                    }
                    else
                    {
                        UpdateAvailable = "yes";
                        return UpdateAvailable;
                    }
                }
            }
            catch (ObjectDisposedException)
            {

                GetVersion();

                file1 = Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Version.txt";


                FileStream fs = new FileStream(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\supertempVersion.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.Close();
                fs.Close();

                file2 = Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\supertempVersion.txt";
                

                
                fs1 = new FileStream(file1, FileMode.Open);
                fs2 = new FileStream(file2, FileMode.Open);

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
                    File.Delete(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\supertempVersion.txt");
                }
                else
                {
                    File.Delete(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Version.txt");
                    File.Move(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\supertempVersion.txt", Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Version.txt");
                    MessageBox.Show("Please reopen the application and choose yes to download the update, or choose no to prompt to update at a later date.");
                }



            }
            return null;
        }

        public void GetExe()
        {
            webClient2.DownloadFile("C:\\BackupV2.exe", Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\BackupV2.exe");
        }

        public void GetVersion()
        {
            if (!File.Exists(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\supertempVersion.txt"))
            {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BackupV2.Text_Files.Version.txt");
                FileStream fileStream = new FileStream(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\supertempVersion.txt", FileMode.CreateNew);
                for (int i = 0; i < stream.Length; i++)
                    fileStream.WriteByte((byte)stream.ReadByte());
                fileStream.Close();
            }
        }
    }
}
