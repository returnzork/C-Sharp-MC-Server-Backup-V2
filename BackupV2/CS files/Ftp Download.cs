using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace BackupV2
{
    public class Ftp_Download
    {
        public void main()
        {
            Xml_Reader Read = new Xml_Reader();
            string server = Read.GetFtpServer();
            string user = Read.GetFtpUser();
            string pass = Read.GetFtpPass();
            string folder = Read.GetFtpFolder();

            string[] files = GetFileList();

            try
            {
                foreach (string file in files)
                {
                    Download(file);
                }
                /*FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(user, pass);
                FtpWebResponse responce = (FtpWebResponse)request.GetResponse();

                Stream responceStream = responce.GetResponseStream();
                StreamReader reader = new StreamReader(responceStream);
                Console.WriteLine(reader.ReadToEnd());

                Console.WriteLine("Down {0}", responce.StatusDescription);

                reader.Close();
                responce.Close();*/
            }
            catch (Exception EX)
            {
                Console.WriteLine(EX);
            }
        }

        public static string[] GetFileList()
        {
            Xml_Reader Read = new Xml_Reader();
            string Server = Read.GetFtpServer();
            string User = Read.GetFtpUser();
            string Pass = Read.GetFtpPass();
            string Folder = Read.GetFtpFolder();
            string Folder2 = Read.GetFtpFolder2();

            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            WebResponse responce = null;
            StreamReader reader = null;
            try
            {
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + Server + "/" + Folder + "/" + Folder2));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(User, Pass);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.Proxy = null;
                reqFTP.KeepAlive = false;
                reqFTP.UsePassive = false;
                responce = reqFTP.GetResponse();
                reader = new StreamReader(responce.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf("\n"), 1);
                return result.ToString().Split('\n');
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                if (reader != null)
                {
                    reader.Close();
                }
                if (responce != null)
                {
                    responce.Close();
                }
                downloadFiles = null;
                return downloadFiles;
            }
        }

        private void Download(string file)
        {
            Xml_Reader Read = new Xml_Reader();
            string Server = Read.GetFtpServer();
            string User = Read.GetFtpUser();
            string Pass = Read.GetFtpPass();
            string Folder = Read.GetFtpFolder();
            string Folder2 = Read.GetFtpFolder2();
            string LocalDirTo = Read.GetBackupTo();
            try
            {
                string uri = "ftp://" + Server + "/" + Folder + "/" + file;
                Uri serverUri = new Uri(uri);
                if (serverUri.Scheme != Uri.UriSchemeFtp)
                {
                    return;
                }
                FtpWebRequest reqFTP;
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + Server + "/" + Folder + "/" + file));
                reqFTP.Credentials = new NetworkCredential(User, Pass);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Proxy = null;
                reqFTP.UsePassive = false;
                FtpWebResponse responce = (FtpWebResponse)reqFTP.GetResponse();
                Stream responceStream = responce.GetResponseStream();
                if (!Directory.Exists(LocalDirTo + "\\" + Folder2))
                {
                    Directory.CreateDirectory(LocalDirTo + "\\" + Folder2);
                }
                FileStream writeStream = new FileStream(LocalDirTo + "\\" + file, FileMode.Create);

                int Length = 64; //tweaking this may give better performance, but when I was on 256 it gave noise from a mp3 file. Smaller value takes longer but yields nearly 1-1 raitio of size and quality.//

                Byte[] buffer = new Byte[Length];
                int bytesRead = responceStream.Read(buffer, 0, Length);
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, Length);
                    bytesRead = responceStream.Read(buffer, 0, Length);
                }
                writeStream.Close();
                responce.Close();
            }
            catch (WebException wEx)
            {
                Console.WriteLine(wEx);
            }
            catch (AccessViolationException aEx)
            {
                Console.WriteLine(aEx);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}