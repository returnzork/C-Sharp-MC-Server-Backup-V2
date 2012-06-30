using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using Ionic.Zip;
using System.IO;
using System.Reflection;
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

        #region decimals

        decimal dec = 0.00M;
        decimal MAX = 0.00M;

        #endregion
        #region strings

        string DirTo;
        string DirFrom;
        string DateNTime;
        string VALUE;
        string OS;
        string Folder2;

        #endregion


        public Backup()
        {

            InitializeComponent();

            StopButton.Enabled = false;

            if (!Directory.Exists(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork"))
            {
                Directory.CreateDirectory(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork");
            }

            #region extract settings

            if (!File.Exists(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Settings.config"))
            {
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BackupV2.Text_Files.Settings.config");
                FileStream fileStream = new FileStream(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Settings.config", FileMode.CreateNew);
                for (int i = 0; i < stream.Length; i++)
                    fileStream.WriteByte((byte)stream.ReadByte());
                fileStream.Close();
            }

            #endregion

            #region extract version file

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

            #endregion

            #region check if using mono

            Type Mono = Type.GetType("Mono.Runtime");

            if (Mono != null)  //if not null it is mono//
            {
                OS = "MONO";
            }
            else
            {
                OS = "NET";
            }

            #endregion

            #region app icon

            if (OS == "NET")
            {
                this.Icon = new Icon(Assembly.GetEntryAssembly().GetManifestResourceStream("BackupV2.Icons.Cloud.ico"));
            }

            #endregion

            #region Close to Tray

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

            #endregion

            #region Save world process

            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\save.vbs";
            p.StartInfo = startInfo;
            
            #endregion
        }

        #region Form load

        private void Form1_Load(object sender, EventArgs e)
        {
            HelpLabel.Visible = false;
            #region extract save world vbs file

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

            #endregion
        }

        #endregion

        #region Form Shown

        private void Form1_Shown(object sender, EventArgs e)
        {
            Check4UpdateThread.RunWorkerAsync();
        }

        #endregion

        #region Updates

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
                    if (UpdateLabel.InvokeRequired)
                    {
                        this.Invoke((MethodInvoker)delegate() { UpdateLabel.Visible = true;});
                    }
                    else
                    {
                        UpdateLabel.Visible = true;
                    }
                }
                else
                {
                    Tray.Icon = new Icon(Assembly.GetEntryAssembly().GetManifestResourceStream("BackupV2.Icons.Cloud.ico"));
                    UpdateLabel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Log.MakeLog(ex,null);
            }
        }

        #endregion

        #region Saveworld

        private void SaveWorld_CLICK(Object sender, EventArgs e)
        {
            string FROM = XmlReader.GetWorld();
                if (FROM != "FTP")
                {
                    try
                    {
                        p.Start();
                    }
                    catch (Exception ex)
                    {
                        Log.MakeLog(ex,null);
                    }
                }
                else
                    MessageBox.Show("Cannot save world when backing up from FTP.");
            }

        #endregion

        #region Open from tray

        void Tray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Tray.Visible = false;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        #endregion

        #region minimize to tray

        void Form_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                Tray.Visible = true;
            }
        }

        #endregion

        #region Start button click

        private void StartButton_Click(object sender, EventArgs e)
        {
            
            WaitTimer.Start();
            CountdownThread.RunWorkerAsync();
            StartButton.Enabled = false;
            StopButton.Enabled = true;
        }

        #endregion

        #region stop button click

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

        #endregion

        #region Form closing

        private void FormCLOSED(object sender, FormClosingEventArgs FC)
        {
            switch (FC.CloseReason)
            {
                #region Windows shutdown
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
                #endregion

                #region user closing
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
                #endregion
            }
        }

        #endregion

        #region timer

        private void timer1_Tick(object sender, EventArgs e)
        {
            string dec1 = XmlReader.GetBackupTime();
            decimal MAX;
            MAX = Convert.ToDecimal(dec1);
            dec = dec + 0.0167M;
            
            if (dec >= MAX + 0.001M)
            {
                WaitTimer.Stop();
            }
        }

        #endregion

        #region toolstrip
        
        #region check for updates toolstrip click

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForUpdate(null, null);
        }

        #endregion

        #region save world toolstrip click

        private void saveWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string FROM = XmlReader.GetWorld();
            if (FROM != "FTP")
            {
                try
                {
                    p.Start();
                }
                catch (Exception ex)
                {
                    Log.MakeLog(ex,null);
                }
            }
            else
            {
                MessageBox.Show("Cannot backup world when backing up from FTP.");
            }
        }

        #endregion

        #region toolstrip quit button click
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region options toolstrip button click

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Options().ShowDialog();
        }

        #endregion

        #region Quit toolstrip button click

        private void QUIT_Click(Object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #endregion

        #region threads

        #region Countdown thread

        private void CountdownThread_DoWork(object sender, DoWorkEventArgs e)
        {
            while (CountdownThread.CancellationPending == false)
            {
                string FROM = XmlReader.GetWorld();
                string TO = XmlReader.GetBackupTo();
                string Compression = XmlReader.UseCompression();
                string MAX1 = XmlReader.GetBackupTime();
                decimal MAX = Convert.ToDecimal(MAX1);

                if (FROM == "" || TO == "" || MAX == 0)
                {
                    while (CountdownThread.CancellationPending == false)
                    {
                        WaitTimer.Stop();
                        Log.MakeLog(null, "  required things are blank" + FROM + TO + Compression + "" + MAX.ToString());
                        this.Invoke((MethodInvoker)delegate() { StartButton.Enabled = true; });
                        this.Invoke((MethodInvoker)delegate() { StopButton.Enabled = false; });
                        CountdownThread.CancelAsync();
                        this.Invoke((MethodInvoker)delegate() { HelpLabel.Visible = true; });
                        e.Cancel = true;
                        return;
                    }
                }

                if (dec != 0.00M && !CountdownThread.CancellationPending)  //reset value when thread runs//
                {
                    dec = 0.00M;
                }

                #region assign variables

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

                #endregion

                while (dec < MAX && !CountdownThread.CancellationPending)  //Checks the time left is less than the total time
                {
                    //do nothing//
                }

                DateNTime = DateTime.Now.ToString("MM.dd.yyyy  hh-mm-ss");

                if (Directory.Exists(DirTo))
                {
                    if (!Directory.Exists(DirTo + DateNTime))  //create the directory for the current time if it does not exist
                    {
                        Directory.CreateDirectory(DirTo + DateNTime);
                    }

                    if (DirFrom == "FTP")  //if the from directory is FTP, start FTP downloading
                    {
                        Ftp_Download FTP = new Ftp_Download();
                        FTP.main(DateNTime);
                        if (Compression == "yes")
                        {
                            CompressionBackground.RunWorkerAsync();
                        }
                    }
                    else if (DirFrom != "FTP")  //if the from directory is not FTP, copy the directory.
                    {
                        foreach(string CreateDir in Directory.GetDirectories(DirFrom, "*", SearchOption.AllDirectories))
                        {
                            Directory.CreateDirectory(CreateDir.Replace(DirFrom, DirTo + DateNTime + "\\"));  //create each sub directory
                        }
                        foreach (string file in Directory.GetFiles(DirFrom, "*", SearchOption.AllDirectories))
                        {
                            File.Copy(file, file.Replace(DirFrom, DirTo + DateNTime + "\\"));  //copy each file in sub directories, and in main directory
                        }

                        if (Compression == "yes")
                        {
                            CompressionBackground.RunWorkerAsync();
                        }
                    }
                    else
                    {
                        //error
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
                        foreach (string CreateDir in Directory.GetDirectories(DirFrom, "*", SearchOption.AllDirectories))
                        {
                            Directory.CreateDirectory(CreateDir.Replace(DirFrom, DirTo + DateNTime + "\\"));  //create each sub directory
                        }
                        foreach (string file in Directory.GetFiles(DirFrom, "*", SearchOption.AllDirectories))
                        {
                            File.Copy(file, file.Replace(DirFrom, DirTo + DateNTime + "\\"));  //copy each file in sub directories, and in main directory
                        }

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

        #endregion

        #region Compression thread

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
                Log.MakeLog(ex,null);
            }
        }

        #endregion

        #region check for update thread

        private void Check4UpdateThread_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);

            string Updating = XmlReader.GetUpdateSettings();

            if (Updating == "yes")
            {
                CheckForUpdate(null, null);
            }
        }

        #endregion

        #endregion
    }
}