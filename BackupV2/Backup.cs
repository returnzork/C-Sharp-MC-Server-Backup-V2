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
//using Ionic.Zip;
using System.IO;
using System.Reflection;
using System.Security;
using System.Configuration;

namespace BackupV2
{
    public partial class Backup : Form
    {
        ToolTip Compress = new ToolTip();  //creates the ToolTip for the compression checkbox

        System.Diagnostics.Process p = new System.Diagnostics.Process(); //creates the save world process

        string DirTo;
        string DirFrom;
        string DateNTime;
        int Number = 0;
        string VALUE;
        int VALUE2;
        string OS;

        NotifyIcon Tray = new NotifyIcon();  //creates the Tray icon


        public Backup()
        {
            InitializeComponent();



            Type Mono = Type.GetType("Mono.Runtime");
#if DEBUG
            
            if (Mono != null)
            {
                MessageBox.Show("MONO");
            }
            else
            {
                MessageBox.Show("NOT MONO");
            }
#endif


            //Start operating system check
            
            
            if (Mono != null)  //if not null it is mono//
            {
                OS = "MONO";
            }
            else
            {
                OS = "NET";
            }            


            //End operating system check



            //Start Close2Tray


            if (OS == "NET")
            {
                Tray.Icon = new Icon(System.Reflection.Assembly.GetEntryAssembly().GetManifestResourceStream("BackupV2.Cloud.ico"));  //get the icon from the resources
                Tray.Visible = false;
                Tray.Text = "Minecraft Server Backup";
                this.Resize += new EventHandler(Form_Resize);
                Tray.MouseDoubleClick += new MouseEventHandler(Tray_MouseDoubleClick);
            }


            //End Close2Tray




            //Start ToolTips


            Compress.ShowAlways = true;
            if (OS == "NET")
            {
                Compress.SetToolTip(Compression, "Check this to use Zip Compression");
            }
            else
            {
                Compression.Enabled = false;
                Compress.SetToolTip(Compression, "Compression is not supported on mono");
            }


            //End ToolTips



            //Start Save world process

            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = Environment.GetEnvironmentVariable("TEMP") + "\\new.vbs";
            //startInfo.Arguments = "COMMAND";
            p.StartInfo = startInfo;

            //End Save world


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
            {
                Directory.CreateDirectory(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork");
            }

            //extract settings file

            if (!File.Exists(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Settings.config"))
            {

                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BackupV2.Settings.config");
                FileStream fileStream = new FileStream(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Settings.config", FileMode.CreateNew);
                for (int i = 0; i < stream.Length; i++)
                    fileStream.WriteByte((byte)stream.ReadByte());
                fileStream.Close();
            }

            //end extract settings file




        }

        private void StartButton_Click(object sender, EventArgs e)
        {

            CountdownThread.RunWorkerAsync();


        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            //progressBar1.Value = 0;
            CountdownThread.CancelAsync();
        }

        private void CompressionBackground_DoWork(object sender, DoWorkEventArgs e)
        {

            DateNTime = DateTime.Now.Month.ToString();
            DateNTime = DateNTime + "-" + DateTime.Now.Day.ToString();
            DateNTime = DateNTime + "-" + DateTime.Now.Hour.ToString();
            DateNTime = DateNTime + "-" + DateTime.Now.Minute.ToString();


            MessageBox.Show(DirTo);


            if (!Directory.Exists(DirTo))
            {
                if (!DirTo.EndsWith("\\"))
                {
                    DirTo = DirTo + "\\";
                }
                Directory.CreateDirectory(DirTo);
            }



            //System.IO.Directory.CreateDirectory(CopyTo + Date);



            CompressionBackground.CancelAsync();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Compression.Enabled = true;
            Compress.SetToolTip(Compression, "Zip Compression is not recommended when using the Mono runtime. Expect errors");
        }


        private void CountdownThread_DoWork(object sender, DoWorkEventArgs e)
        {
            Xml_Reader XmlReader = new Xml_Reader();
            string FROM = XmlReader.GetWorld();
            string TO = XmlReader.GetBackupTo();





            if (Number != 0)  //reset value when thread runs//
            {
                Number = 0;
            }



            //variable assignment, supports modifying locations without restart//

            VALUE = CountdownTime.Text;
            VALUE2 = Convert.ToInt32(VALUE);
           
            

            DirFrom = FROM;
            DirTo = TO;

            //end variable assignment//



            while (Number < VALUE2 && !CountdownThread.CancellationPending)  //Checks the time left is less than the total time, AND that the countdownthread does not have a cancellation pending.//
            {
                Thread.Sleep(10000);
                Number++;



                if (CountdownThread.CancellationPending)
                {
                    break;
                }
#if RELEASE
                Thread.Sleep(10000);
                if (CountdownThread.CancellationPending)
                {
                    break;
                }
                Thread.Sleep(10000);
                if (CountdownThread.CancellationPending)
                {
                    break;
                }
                Thread.Sleep(10000);
                if (CountdownThread.CancellationPending)
                {
                    break;
                }
                Thread.Sleep(10000);
                if (CountdownThread.CancellationPending)
                {
                    break;
                }
                Thread.Sleep(10000);
#endif
            }

            if (!CountdownThread.CancellationPending)
            {

                if (Directory.Exists(DirTo))
                {
                    //FileSystem.CopyDirectory(DirFrom, DirTo);
                }
                else if (!Directory.Exists(DirTo))
                {
                    Directory.CreateDirectory(DirTo);
                    //FileSystem.CopyDirectory(DirFrom, DirTo);  //temp copy method//
                    

                    //start future copy method//

                    try
                    {
                        FileSystem.CopyDirectory(DirFrom, DirTo);
                    }
                    catch (Exception EX)
                    {
                        MessageBox.Show(EX + "");
                    }


                    //end debug//





                    //end future copy method//
                }
            }
        }


        private void FormCLOSED(object sender, FormClosingEventArgs FC)
        {
            //extract the save world file before exiting

            if (OS == "NET")
            {

                FileInfo FI = new FileInfo(Environment.GetEnvironmentVariable("TEMP") + "new.vbs");

                if (!File.Exists(Environment.GetEnvironmentVariable("TEMP") + "\\new.vbs"))
                {
                    Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BackupV2.saveall.vbs");
                    FileStream fileStream = new FileStream(Environment.GetEnvironmentVariable("TEMP") + "\\new.vbs", FileMode.CreateNew);
                    for (int i = 0; i < stream.Length; i++)
                        fileStream.WriteByte((byte)stream.ReadByte());
                    fileStream.Close();
                }
                else if (FI.CreationTime < DateTime.Now.AddDays(-5))
                {
                    File.Delete(Environment.GetEnvironmentVariable("TEMP") + "\\new.vbs");
                    FI.Delete();
                    Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BackupV2.saveall.vbs");
                    FileStream fileStream = new FileStream(Environment.GetEnvironmentVariable("TEMP") + "\\new.vbs", FileMode.CreateNew);
                    for (int i = 0; i < stream.Length; i++)
                        fileStream.WriteByte((byte)stream.ReadByte());
                    fileStream.Close();
                }
            }

            //end extract save world file

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
                        CLOSE = MessageBox.Show("Save world before closing?", "Save world?", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                        if (CLOSE == DialogResult.Yes)
                        {
                            p.Start();
                            FC.Cancel = false;
                            Application.Exit();
                        }
                        else if (CLOSE == DialogResult.No)
                        {
                            FC.Cancel = false;
                            Application.Exit();
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
    }
}