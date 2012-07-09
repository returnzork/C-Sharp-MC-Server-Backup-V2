using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace BackupV2
{
    class Ftp_Upload
    {
        Xml_Reader Read = new Xml_Reader();
        WebClient Client = new WebClient();
        Error_Logging log = new Error_Logging();

        public void Upload(string DateNTime)
        {
            string LocalFolder = Read.GetWorld();
            string Folder = Read.GetFtpFolder();
            string Folder2 = Read.GetFtpFolder2();
            string User = Read.GetFtpUser();
            string Pass = Read.GetFtpPass();
            string Server = Read.GetFtpServer();
            WebResponse responce;

            //throw new NotImplementedException();


            string[] FILES = Directory.GetFiles(LocalFolder);
            string[] fold = Directory.GetDirectories(LocalFolder);
            WebRequest Request = WebRequest.Create("ftp://" + Server + "/" + Folder + "/" + Folder2);
            Request.Method = WebRequestMethods.Ftp.MakeDirectory;
            Request.Credentials = new NetworkCredential(User, Pass);

            
            try
            {
                responce = Request.GetResponse();
            }
            catch(Exception)
            {
                //creates error when the directory already exists, no need to log
                Console.WriteLine("FTP Directory root already exists, continuing...");
            }
            
            Request = WebRequest.Create("ftp://" + Server + "/" + Folder + "/" + Folder2 + "/" + DateNTime);
            Request.Method = WebRequestMethods.Ftp.MakeDirectory;
            Request.Credentials = new NetworkCredential(User, Pass);
            try
            {
                responce = Request.GetResponse();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error has occured:r\n\"" + ex);
                Console.ReadKey();
                log.MakeLog(ex, null);
            }


            var path = LocalFolder;
            var dirName = new DirectoryInfo(path).Name;

            #region Create Directories and copy files
            foreach (string dir in fold)
            {
                dirName = new DirectoryInfo(dir).Name;
                string[] Files = Directory.GetFiles(dir);


                Request = WebRequest.Create("ftp://" + Server + "/" + Folder + "/" + Folder2 + "/" + DateNTime + "/" + dirName);
                Request.Method = WebRequestMethods.Ftp.MakeDirectory;
                Request.Credentials = new NetworkCredential(User, Pass);
                try
                {
                    responce = Request.GetResponse();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error has occurred:r\n\"" + ex);
                    Console.ReadKey();
                    log.MakeLog(ex, null);
                }

                foreach(string file1 in Files)
                {
                    if (file1 == null)
                        break;
                    WebClient client = new WebClient();
                    client.Credentials = new NetworkCredential(User, Pass);
                    try
                    {
                        client.UploadFile("ftp://" + Server + "/" + Folder + "/" + Folder2 + "/" + DateNTime + "/" + 
                            dirName + "/" + new FileInfo(file1).Name, "STOR", file1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error has occured:r\n\"" + ex);
                        Console.ReadKey();
                        log.MakeLog(ex, null);
                    }
                }
            }
            #endregion

            #region Copy files from root folder
            foreach (string files in FILES)
            {
                WebClient client = new WebClient();
                client.Credentials = new NetworkCredential(User, Pass);
                try
                {
                    client.UploadFile("ftp://" + Server + "/" + Folder + "/" + Folder2 + "/" + DateNTime + "/" + 
                        new FileInfo(files).Name, "STOR", files);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error has occured:r\n\"" + ex);
                    Console.ReadKey();
                    log.MakeLog(ex, null);
                }
            }
            #endregion
            Console.WriteLine("Finished FTP upload of world.");
            Console.ReadKey();
        }
    }
}
