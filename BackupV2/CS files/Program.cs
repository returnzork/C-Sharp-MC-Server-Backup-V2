using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

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
                //TODO console support
                NativeMethods.AllocConsole();
                if (args[0] == "B")
                {
                    //TODO Backup
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
    }
}
