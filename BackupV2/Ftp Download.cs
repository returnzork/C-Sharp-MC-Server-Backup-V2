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
        public static void main(object sender, EventArgs e)
        {
            Xml_Reader Read = new Xml_Reader();
            string server = Read.GetFtpServer();
            string user = Read.GetFtpUser();
            string pass = Read.GetFtpPass();


            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(server);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(user, pass);
            FtpWebResponse responce = (FtpWebResponse)request.GetResponse();

            Stream responceStream = responce.GetResponseStream();
            StreamReader reader = new StreamReader(responceStream);
            Console.WriteLine(reader.ReadToEnd());

            Console.WriteLine("Down {0}", responce.StatusDescription);

            reader.Close();
            responce.Close();
        }
    }
}
