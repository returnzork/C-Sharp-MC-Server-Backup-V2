using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Ionic.Zip;

namespace BackupV2
{
    internal static class NativeMethods
    {
        [DllImport("kernel32.dll")]
        internal static extern Boolean AllocConsole();
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Backup());
            }
            else
            {
                NativeMethods.AllocConsole();
                if (args[0] == "B")
                {
                    Error_Logging Log = new Error_Logging();
                    Xml_Reader read = new Xml_Reader();

                    string FROM = read.GetWorld();
                    string TO = read.GetBackupTo();
                    string Compression = read.UseCompression();
                    string DateNTime = DateTime.Now.ToString("MM.dd.yyyy  hh-mm-ss");


                    if(!FROM.EndsWith("\\") && FROM != "FTP")
                    {
                        FROM = FROM + "\\";
                    }
                    if (!TO.EndsWith("\\") && TO != "FTP")
                    {
                        TO = TO + "\\";
                    }


                    if (!Directory.Exists(FROM) && FROM != "FTP")
                    {
                        Console.WriteLine("CANNOT RUN WHEN THE WORLD FOLDER DOES NOT EXIST, AND WHEN NOT RUNNING ON FTP.\r\nTest");
                        Console.ReadKey();
                        Application.Exit();
                    }

                    #region copy world
                    #region Non FTP
                    if (!Directory.Exists(TO) && TO != "FTP")
                    {
                        Directory.CreateDirectory(TO);

                        if (!Directory.Exists(TO + DateNTime))
                        {
                            Directory.CreateDirectory(TO + DateNTime);
                        }

                        foreach (string dirPath in Directory.GetDirectories(FROM, "*", SearchOption.AllDirectories))
                            Directory.CreateDirectory(dirPath.Replace(FROM, TO + DateNTime + "\\"));


                        foreach (string newPath in Directory.GetFiles(FROM, "*.*", SearchOption.AllDirectories))
                            File.Copy(newPath, newPath.Replace(FROM, TO + DateNTime + "\\"));

                        Console.WriteLine("Finished copying world.");


                        DateTime time = DateTime.Now;
                        DateTime timeout = time.AddSeconds(10);

                        while (time < timeout)
                        {
                            Console.ReadKey();
                            Application.Exit();
                        }
                        Application.Exit();


                        #region compression
                        if (Compression == "yes")
                        {
                            ZipFile zip = new ZipFile();

                            try
                            {
                                zip.AddDirectory(TO + DateNTime);
                                zip.Save(TO + DateNTime + ".zip");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("An error has occurred:r\n\"" + ex);
                                Console.ReadKey();
                                Log.MakeLog(ex, null);
                            }
                        }
                        #endregion
                    }
                    else if (Directory.Exists(TO) && TO != "FTP")
                    {
                        if (!Directory.Exists(TO + DateNTime))
                        {
                            Directory.CreateDirectory(TO + DateNTime);
                        }

                        foreach (string dirPath in Directory.GetDirectories(FROM, "*", SearchOption.AllDirectories))
                            Directory.CreateDirectory(dirPath.Replace(FROM, TO + DateNTime + "\\"));


                        foreach (string newPath in Directory.GetFiles(FROM, "*.*", SearchOption.AllDirectories))
                            File.Copy(newPath, newPath.Replace(FROM, TO + DateNTime + "\\"));


                        #region compression
                        if (Compression == "yes")
                        {
                            ZipFile zip = new ZipFile();

                            try
                            {
                                zip.AddDirectory(TO + DateNTime);
                                zip.Save(TO + DateNTime + ".zip");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("An error has occurred:r\n\"" + ex);
                                Console.ReadKey();
                                Log.MakeLog(ex, null);
                            }
                        }
                        #endregion


                        System.ComponentModel.BackgroundWorker bgworker = new System.ComponentModel.BackgroundWorker();
                        bgworker.WorkerReportsProgress = false;
                        bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(bgworker_DoWork);
                        bgworker.RunWorkerAsync();

                        


                        Console.WriteLine("Finished copying world.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    #endregion
                    #region FTP
                    #region Upload
                    else if (TO == "FTP")
                    {
                        Ftp_Upload upload = new Ftp_Upload();
                        upload.Upload(DateNTime);
                    }
                    #endregion
                    #region Download
                    else if (FROM == "FTP")
                    {
                        Ftp_Download download = new Ftp_Download();
                        download.main(DateNTime);
                        #region compression
                        if (Compression == "yes")
                        {
                            ZipFile zip = new ZipFile();

                            try
                            {
                                zip.AddDirectory(TO + DateNTime);
                                zip.Save(TO + DateNTime + ".zip");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("An error has occurred:r\n\"" + ex);
                                Console.ReadKey();
                                Log.MakeLog(ex, null);
                            }
                        }
                        #endregion
                    }
                    #endregion
                    #endregion
                    #endregion
                }
                else if (args[0] == "R")
                {
                    if (Directory.Exists(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\"))
                    {
                        string[] FILES = Directory.GetFiles(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\");
                        foreach (string file in FILES)
                        {
                            File.Delete(file);
                        }
                    }
                    Console.WriteLine("Completed!");
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("BackupV2.exe usage:");
                    Console.WriteLine("/?: This help message");
                    Console.WriteLine("B: Backup using the configuration files");
                    Console.WriteLine("R: Delete all settings files. Start fresh.");
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
            }
        }

        static void bgworker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DateTime Now = DateTime.Now;
            DateTime End = DateTime.Now.AddSeconds(10);

            while (Now <= End)
            {
                System.Threading.Thread.Sleep(10);
                Now = DateTime.Now;
            }
            Environment.Exit(0);
        }
    }
}
