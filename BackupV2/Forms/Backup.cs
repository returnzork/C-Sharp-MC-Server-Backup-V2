using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using System.Threading;
using Ionic.Zip;
using System.IO;
using System.Reflection;
using System.Security;
using System.Configuration;
using System.Diagnostics;

namespace BackupV2
{
    public partial class Backup : Form
    {
        NotifyIcon Tray = new NotifyIcon();
        Process p = new Process();
        Error_Logging Log = new Error_Logging();
        Xml_Reader XmlReader = new Xml_Reader();
        ContextMenu menu = new ContextMenu();


        decimal dec = 0.00M;
        decimal MAX = 0.00M;
        

        string DirTo;
        string DirFrom;
        string DateNTime;
        string VALUE;
        string OS;
        string Folder2;


        public Backup()
        {

            InitializeComponent();


            StopButton.Enabled = false;

            if (!Directory.Exists(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork"))
            {
                Directory.CreateDirectory(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork");
            }

            //start extract settings file

            if (!File.Exists(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Settings.config"))
            {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BackupV2.Text_Files.Settings.config");
                FileStream fileStream = new FileStream(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Settings.config", FileMode.CreateNew);
                for (int i = 0; i < stream.Length; i++)
                    fileStream.WriteByte((byte)stream.ReadByte());
                fileStream.Close();
            }

            //end extract settings file


            //start extract version file

            Folder2 = XmlReader.GetFtpFolder2();

            UpdateLabel.Visible = false;

            if (!File.Exists(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Version.txt"))
            {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BackupV2.Text_Files.Version.txt");
                FileStream fileStream = new FileStream(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Version.txt", FileMode.CreateNew);
                for (int i = 0; i < stream.Length; i++)
                    fileStream.WriteByte((byte)stream.ReadByte());
                fileStream.Close();
            }

            //end extract version file


            //Start operating system check

            Type Mono = Type.GetType("Mono.Runtime");

            if (Mono != null)  //if not null it is mono//
            {
                OS = "MONO";
            }
            else
            {
                OS = "NET";
            }            


            //End operating system check


            //Start Application Icon

            if (OS == "NET")
            {
                this.Icon = new Icon(Assembly.GetEntryAssembly().GetManifestResourceStream("BackupV2.Icons.Cloud.ico"));
            }

            //End Application Icon

            //Start check for updates
#if DEBUG
                CheckForUpdate(null, null);
#else
            //TODO
#endif

            //End check for updates



            //Start Close2Tray


            if (OS == "NET")
            {
                Tray.Visible = false;
                Tray.Text = "Minecraft Server Backup";
                this.Resize += new EventHandler(Form_Resize);
                Tray.MouseDoubleClick += new MouseEventHandler(Tray_MouseDoubleClick);

                menu.MenuItems.Add("Save World", new EventHandler(SaveWorld_CLICK));
                menu.MenuItems.Add("Check for updates", new EventHandler(CheckForUpdate));
                menu.MenuItems.Add("Quit", new System.EventHandler(QUIT_Click));
                Tray.ContextMenu = menu;
            }


            //End Close2Tray


            //Start Save world process

            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\save.vbs";
            p.StartInfo = startInfo;

            //End Save world


        }

        private void CheckForUpdate(Object sender, EventArgs e)
        {
            CheckForUpdates UPDATE = new CheckForUpdates();
            try
            {
                string Available = UPDATE.Compare();
                if (Available == "yes")
                {
                    Tray.Icon = new Icon(Assembly.GetEntryAssembly().GetManifestResourceStream("BackupV2.Icons.CloudUpdate.ico"));
                    Bitmap bmp = new Icon(Assembly.GetEntryAssembly().GetManifestResourceStream("BackupV2.Icons.CloudUpdate.ico")).ToBitmap();
                    Bitmap bmp2 = new Bitmap(bmp, 64, 64);
                    updatePictureBox.Image = bmp2;
                    UpdateLabel.Visible = true;
                }
                else
                {
                    Tray.Icon = new Icon(Assembly.GetEntryAssembly().GetManifestResourceStream("BackupV2.Icons.Cloud.ico"));
                    UpdateLabel.Visible = false;
                }
            }
            catch (NotImplementedException)
            {
                Tray.Icon = new Icon(Assembly.GetEntryAssembly().GetManifestResourceStream("BackupV2.Icons.Cloud.ico"));
                UpdateLabel.Visible = false;
            }
            catch (Exception ex)
            {
                Log.MakeLog(ex.ToString());
            }
        }

        private void SaveWorld_CLICK(Object sender, EventArgs e)
        {
            if (!File.Exists(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\save.vbs"))
            {
                try
                {
                    p.Start();
                }
                catch (Exception ex)
                {
                    Log.MakeLog(ex.ToString());
                }
            }
        }

        private void QUIT_Click(Object sender, EventArgs e)
        {
            this.Close();
        }

        void Tray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Tray.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        
        void Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                Tray.Visible = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //start extract save.vbs

            if (OS == "NET")
            {
                FileInfo FI = new FileInfo(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\save.vbs");

                if (!File.Exists(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\save.vbs"))
                {
                    Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BackupV2.Text_Files.saveall.vbs");
                    FileStream fileStream = new FileStream(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\save.vbs", FileMode.CreateNew);
                    for (int i = 0; i < stream.Length; i++)
                        fileStream.WriteByte((byte)stream.ReadByte());
                    fileStream.Close();
                }
                else if (FI.CreationTime < DateTime.Now.AddDays(-5))
                {
                    File.Delete(Environment.GetEnvironmentVariable("appdata") + "\\returnzork\\save.vbs");
                    FI.Delete();
                    Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BackupV2.Text_Files.saveall.vbs");
                    FileStream fileStream = new FileStream(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\save.vbs", FileMode.CreateNew);
                    for (int i = 0; i < stream.Length; i++)
                        fileStream.WriteByte((byte)stream.ReadByte());
                    fileStream.Close();
                }
            }

            //end extract save.vbs
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            WaitTimer.Start();
            CountdownThread.RunWorkerAsync();
            StartButton.Enabled = false;
            StopButton.Enabled = true;
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            CountdownThread.CancelAsync();
            WaitTimer.Stop();
            StopButton.Enabled = false;
            if (CountdownThread.IsBusy)
            {
                StartButton.Enabled = true;
            }
        }

        private void CompressionBackground_DoWork(object sender, DoWorkEventArgs e)
        {
            ZipFile zip = new ZipFile();

            try
            {
                zip.AddDirectory(DirTo + DateNTime);
                zip.Save(DirTo + DateNTime + ".zip");
            }
            catch (Exception ex)
            {
                Log.MakeLog(ex.ToString());
            }
        }

        private void CountdownThread_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!CountdownThread.CancellationPending)
            {
                string FROM = XmlReader.GetWorld();
                string TO = XmlReader.GetBackupTo();
                string Compression = XmlReader.UseCompression();


                if (dec != 0.00M)  //reset value when thread runs//
                {
                    dec = 0.00M;
                }


                //variable assignment, supports modifying locations without restart//

                VALUE = XmlReader.GetBackupTime();
                MAX = Convert.ToDecimal(VALUE);


                DirFrom = FROM;
                DirTo = TO;

                if (!DirFrom.EndsWith("\\") && DirFrom != "FTP")
                {
                    DirFrom = DirFrom + "\\";
                }
                if (!DirTo.EndsWith("\\"))
                {
                    DirTo = DirTo + "\\";
                }

                //end variable assignment//


                while (dec < MAX && !CountdownThread.CancellationPending)  //Checks the time left is less than the total time
                {
                    //do nothing//
                }

                    DateNTime = DateTime.Now.ToString("MM.dd.yyyy  hh-mm-ss");

                    if (Directory.Exists(DirTo))
                    {
                        if (!Directory.Exists(DirTo + DateNTime))
                        {
                            Directory.CreateDirectory(DirTo + DateNTime);
                        }

                        if (DirFrom == "FTP")
                        {
                            Ftp_Download FTP = new Ftp_Download();
                            FTP.main(DateNTime);
                            if (Compression == "yes")
                            {
                                CompressionBackground.RunWorkerAsync();
                            }
                        }
                        else
                        {
                            FileSystem.CopyDirectory(DirFrom, DirTo + DateNTime + "\\");
                            if (Compression == "yes")
                            {
                                CompressionBackground.RunWorkerAsync();
                            }
                        }
                    }
                    else if (!Directory.Exists(DirTo))
                    {
                        Directory.CreateDirectory(DirTo);
                        if (DirFrom == "FTP")
                        {
                            Ftp_Download FTP = new Ftp_Download();
                            FTP.main(DateNTime);
                            if (Compression == "yes")
                            {
                                CompressionBackground.RunWorkerAsync();
                            }
                        }
                        else
                        {
                            FileSystem.CopyDirectory(DirFrom, DirTo + DateNTime + "\\");
                            if (Compression == "yes")
                            {
                                CompressionBackground.RunWorkerAsync();
                            }
                        }
                    }
                    else
                    {
                        //Error//
                        MessageBox.Show("ERROR");
                    }
            }
        }

        private void FormCLOSED(object sender, FormClosingEventArgs FC)
        {
            switch (FC.CloseReason)
            {
                case CloseReason.WindowsShutDown:
                    try
                    {
                        p.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    Application.Exit();
                    break;


                case CloseReason.UserClosing:
                    DialogResult CLOSE;
                    if (OS == "NET")
                    {
                        string FROM = XmlReader.GetWorld();
                        if (FROM != "FTP")
                        {
                            CLOSE = MessageBox.Show("Save world before closing?", "Save world?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (CLOSE == DialogResult.Yes)
                            {
                                p.Start();
                                FC.Cancel = false;
                                Tray.Dispose();
                                p.WaitForExit();

                                Application.Exit();
                            }
                            else if (CLOSE == DialogResult.No)
                            {
                                FC.Cancel = false;
                                Application.Exit();
                                if (Tray.Visible == true)
                                {
                                    Tray.Dispose();
                                }
                            }
                            else if (CLOSE == DialogResult.Cancel)
                            {
                                FC.Cancel = true;
                            }
                            else
                            {
                                //error//
                            }
                        }
                        else
                        {
                            CLOSE = MessageBox.Show("Realy quit?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (CLOSE == DialogResult.Yes)
                            {
                                FC.Cancel = false;
                                Tray.Dispose();
                                Application.Exit();
                            }
                            else if(CLOSE == DialogResult.No)
                            {
                                FC.Cancel = true;
                            }
                            else
                            {
                                //error
                            }
                        }
                    }
                    else
                    {
                        CLOSE = MessageBox.Show("Realy quit?", "Realy quit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (CLOSE == DialogResult.OK)
                        {
                            FC.Cancel = false;
                            Application.Exit();
                        }
                        else
                        {
                            FC.Cancel = true;
                        }
                    }
                    break;
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Options().ShowDialog();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            p.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dec = dec + 0.0167M;
            
#if DEBUG
            dec = MAX;
#endif

            if (dec >= MAX + 0.001M)
            {
                WaitTimer.Stop();
            }
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForUpdate(null, null);
        }
    }
}