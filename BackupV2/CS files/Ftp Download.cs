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
        public Error_Logging log = new Error_Logging();
        public Xml_Reader Read = new Xml_Reader();

        public void main(string DateNTime)
        {
            #region string initialization

            string server = Read.GetFtpServer();
            string user = Read.GetFtpUser();
            string pass = Read.GetFtpPass();
            string folder = Read.GetFtpFolder();
            string[] files = GetFileList();

            #endregion

            try
            {
                foreach (string file in files)
                {
                    Download(file, DateNTime);
                }
            }
            catch (Exception EX)
            {
                log.MakeLog(EX.ToString());
            }
        }

        #region get FTP file list

        public static string[] GetFileList()
        {
            Error_Logging log = new Error_Logging();
            Xml_Reader Read = new Xml_Reader();

            #region string initialization

            string Server = Read.GetFtpServer();
            string User = Read.GetFtpUser();
            string Pass = Read.GetFtpPass();
            string Folder = Read.GetFtpFolder();
            string Folder2 = Read.GetFtpFolder2();
            string[] downloadFiles;

            #endregion


            StringBuilder result = new StringBuilder();
            WebResponse responce = null;
            StreamReader reader = null;
            try
            {
                FtpWebRequest reqFTP;
                #region FTP details

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + Server + "/" + Folder + "/" + Folder2));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(User, Pass);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectory;
                reqFTP.Proxy = null;
                reqFTP.KeepAlive = false;
                reqFTP.UsePassive = false;
                responce = reqFTP.GetResponse();

                #endregion
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
                log.MakeLog(ex.ToString());
                #region cleanup

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

                #endregion
            }
        }

        #endregion

        #region Download from FTP

        private void Download(string file, string DateNTime)
        {
            #region string initialization

            string Server = Read.GetFtpServer();
            string User = Read.GetFtpUser();
            string Pass = Read.GetFtpPass();
            string Folder = Read.GetFtpFolder();
            string Folder2 = Read.GetFtpFolder2();
            string LocalDirTo = Read.GetBackupTo();

            #endregion


            if (!LocalDirTo.EndsWith("\\"))
            {
                LocalDirTo = LocalDirTo + "\\";
            }

            try
            {
                string uri = "ftp://" + Server + "/" + Folder + "/" + file;
                Uri serverUri = new Uri(uri);
                if (serverUri.Scheme != Uri.UriSchemeFtp)
                {
                    return;
                }
                FtpWebRequest reqFTP;

                #region FTP details

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + Server + "/" + Folder + "/" + file));
                reqFTP.Credentials = new NetworkCredential(User, Pass);
                reqFTP.KeepAlive = false;
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Proxy = null;
                reqFTP.UsePassive = false;
                FtpWebResponse responce = (FtpWebResponse)reqFTP.GetResponse();
                Stream responceStream = responce.GetResponseStream();

                #endregion

                if (!Directory.Exists(LocalDirTo + DateNTime + "\\" + Folder2))
                {
                    Directory.CreateDirectory(LocalDirTo + DateNTime + "\\" + Folder2);
                }
                FileStream writeStream = new FileStream(LocalDirTo + DateNTime + "\\" + file, FileMode.Create);



                
                //TODO Test with actual server


                int Length = 16; //tweaking this may give better performance, but when I was on 32 it gave tiny noise (playable but..) from a mp3 file, at 256 it was unplayable. Smaller value takes longer but yields nearly 1-1 ratio of size and quality.//


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
            #region Catching errors

            catch (WebException wEx)
            {
                log.MakeLog(wEx.ToString());
            }
            catch (AccessViolationException aEx)
            {
                log.MakeLog(aEx.ToString());
            }
            catch (Exception ex)
            {
                log.MakeLog(ex.ToString());
            }

            #endregion
        }

        #endregion
    }
}