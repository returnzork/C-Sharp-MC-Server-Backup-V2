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
                if (args[0].ToLower() == "b" || args[0].ToLower() == "/b")
                #region backup
                {

                    Error_Logging Log = new Error_Logging();
                    Xml_Reader read = new Xml_Reader();

                    if (!Directory.Exists(Environment.GetEnvironmentVariable("appdata") + "\\returnzork\\") || !File.Exists(Environment.GetEnvironmentVariable("appdata") + "\\returnzork\\Settings.config"))
                    {
                        Log.MakeLog(null, "  Settings do not exist, cannot continue.");
                        Console.WriteLine("The settings file does not exist. Cannot continue without the settings file.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }



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
                        Environment.Exit(0);
                    }

                    #region copy world
                    #region Non FTP
                    #region not exist
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



                        System.ComponentModel.BackgroundWorker bgworker = new System.ComponentModel.BackgroundWorker();
                        bgworker.DoWork +=new System.ComponentModel.DoWorkEventHandler(bgworker_DoWork);
                        bgworker.RunWorkerAsync();

                        Console.ReadKey();
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
                    #endregion
                    #region Exists
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
                    #endregion
                    #region FTP
                    #region Upload
                    else if (TO == "FTP")
                    {
                        Ftp_Upload upload = new Ftp_Upload();
                        upload.Upload(DateNTime);

                        System.ComponentModel.BackgroundWorker bgworker = new System.ComponentModel.BackgroundWorker();
                        bgworker.WorkerReportsProgress = false;
                        bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(bgworker_DoWork);
                        bgworker.RunWorkerAsync();

                        Console.WriteLine("Finished");
                        Console.ReadKey();
                        Environment.Exit(0);
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

                        System.ComponentModel.BackgroundWorker bgworker = new System.ComponentModel.BackgroundWorker();
                        bgworker.WorkerReportsProgress = false;
                        bgworker.DoWork += new System.ComponentModel.DoWorkEventHandler(bgworker_DoWork);
                        bgworker.RunWorkerAsync();

                        Console.WriteLine("Finished");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    #endregion
                    #endregion
                    #endregion
                }
                #endregion
                else if (args[0].ToLower() == "r" || args[0].ToLower() == "/r")
                #region reset settings
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
                #endregion
                else if (args[0].ToLower() == "settings" || args[0].ToLower() == "/s")
                #region Current settings
                {
                    Xml_Reader xml = new Xml_Reader();

                    Console.WriteLine("Current settings are:");
                    Console.WriteLine();
                    Console.WriteLine();



                    Console.WriteLine();
                    Console.WriteLine("Backup time is:  " + xml.GetBackupTime() + " minute(s)");
                    Console.WriteLine();
                    Console.WriteLine();

                    if (xml.GetBackupTo() == "ftp")
                    {
                        Console.WriteLine("Backup to ftp is:  on");
                    }
                    else
                    {
                        Console.WriteLine("Backup to ftp is:  off");
                    }
                    if (xml.GetWorld() == "ftp")
                    {
                        Console.WriteLine("Backup from ftp is:  on");
                    }
                    else
                    {
                        Console.WriteLine("Backup from ftp is:  off");
                    }



                    Console.WriteLine();
                    Console.WriteLine();
                    if (xml.GetWorld() != "ftp")
                    {
                        Console.WriteLine("Backup from directory is:   " + xml.GetWorld());
                    }
                    else
                    {
                        Console.WriteLine("Backup from directory is:   ftp:\\\\" + xml.GetFtpServer() + "\\" + xml.GetFtpFolder() + "\\" + xml.GetFtpFolder2());
                    }

                    if (xml.GetBackupTo() != "ftp")
                    {
                        Console.WriteLine("Backup to directory is:  " + xml.GetBackupTo());
                    }
                    else
                    {
                        Console.WriteLine("Backup to directory is:   ftp:\\\\" + xml.GetFtpServer() + "\\" + xml.GetFtpFolder() + "\\" +xml.GetFtpFolder2());
                    }

                    Console.WriteLine();
                    Console.WriteLine();

                    if(xml.GetUpdateSettings() == "no")
                    {
                        Console.WriteLine("Auto updating is:  " + "off");
                    }
                    else if (xml.GetUpdateSettings() == "yes")
                    {
                        Console.WriteLine("Auto updating is:  " + "on");
                    }
                    else
                    {
                        Console.WriteLine("Auto updating is:  " + "not defined");
                    }

                    Console.WriteLine();
                    Console.ReadLine();
                }
                #endregion
                else
                #region help
                {
                    if (args[0] != "/?")
                    {
                        Console.WriteLine("Invalid argument: " + args[0]);
                        Console.WriteLine("");
                        Console.WriteLine("");
                    }
                    Console.WriteLine("BackupV2.exe usage:");
                    Console.WriteLine("");
                    Console.WriteLine("/?: This help message");
                    Console.WriteLine("/B: Backup using the configuration files");
                    Console.WriteLine("/R: Delete all settings files. Start fresh.");
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                }
                #endregion
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
