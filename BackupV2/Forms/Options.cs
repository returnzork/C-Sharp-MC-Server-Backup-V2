using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.IO;

namespace BackupV2
{
    public partial class Options : Form
    {
        XmlDocument xd = new XmlDocument();
        XmlNode node1, node2, node3, node4, node5, node6, node7, node8, node9, node10;
        ToolTip TT = new ToolTip();


        public Options()
        {
            
            InitializeComponent();
            this.Size = new Size(350, 350);

            TT.SetToolTip(UseCompression, "Check this to use Zip Compression.");
            TT.SetToolTip(WorldFromLabel, "Enter where your world is currently located");
            TT.SetToolTip(WorldToLabel, "Enter where you want your world backup to be located at");
        }

        #region Form load

        private void Options_Load(object sender, EventArgs e)
        {
            ftpDeXpand.Visible = false;
            FtpExpand.Visible = true;

            #region textbox loading

            Xml_Reader XML = new Xml_Reader();
            string World = XML.GetWorld();
            BackupFrom.Text = World;
            string BackupTime = XML.GetBackupTime();
            BackuptimeText.Text = BackupTime;

            #endregion


            #region load Backup to folder
            string WorldTo = XML.GetBackupTo();
            BackupTo.Text = WorldTo;
            #endregion


            #region ftp loading

            string ftpUser = XML.GetFtpUser();
            string ftpPass = XML.GetFtpPass();
            string ftpServer = XML.GetFtpServer();
            string ftpFolder = XML.GetFtpFolder();
            string ftpFolder2 = XML.GetFtpFolder2();
            ftpUserText.Text = ftpUser;
            ftpPassText.Text = ftpPass;
            ftpServerText.Text = ftpServer;
            ftpFolderText.Text = ftpFolder;
            ftpFolder2Text.Text = ftpFolder2;

            #endregion


            #region load checkbox config

            string Compression = XML.UseCompression();
            if (Compression == "yes")
            {
                UseCompression.Checked = true;
            }

            string Update = XML.GetUpdateSettings();
            if (Update == "yes")
            {
                UpdatingCheckBox.Checked = true;
            }

            #endregion
        }

        #endregion

        #region settings folder button click

        private void SettingsFolder_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            ProcessStartInfo StartInfo = new ProcessStartInfo();
            StartInfo.FileName = "explorer.exe";
            StartInfo.Arguments = Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork";
            p.StartInfo = StartInfo;
            p.Start();
        }

        #endregion

        #region save button click

        private void SaveButton_Click(object sender, EventArgs e)
        {
            xd.Load(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Settings.config");


            node1 = xd.SelectSingleNode("descendant::*[name(.) = 'worldFrom']");
            node1.InnerText = BackupFrom.Text;

            node2 = xd.SelectSingleNode("descendant::*[name(.) = 'worldTo']");
            node2.InnerText = BackupTo.Text;

            node3 = xd.SelectSingleNode("descendant::*[name(.) = 'ftpUser']");
            node3.InnerText = ftpUserText.Text;

            node4 = xd.SelectSingleNode("descendant::*[name(.) = 'ftpPass']");
            node4.InnerText = ftpPassText.Text;

            node5 = xd.SelectSingleNode("descendant::*[name(.) = 'ftpServer']");
            node5.InnerText = ftpServerText.Text;

            #region compression node
            node6 = xd.SelectSingleNode("descendant::*[name(.) = 'compression']");
            if (UseCompression.Checked == true)
            {
                node6.InnerText = "yes";
            }
            else
            {
                node6.InnerText = "no";
            }
            #endregion

            node7 = xd.SelectSingleNode("descendant::*[name(.) = 'ftpFolder']");
            node7.InnerText = ftpFolderText.Text;

            node8 = xd.SelectSingleNode("descendant::*[name(.) = 'ftpFolder2']");
            node8.InnerText = ftpFolder2Text.Text;

            node9 = xd.SelectSingleNode("descendant::*[name(.) = 'timeBetween']");
            node9.InnerText = BackuptimeText.Text;

            #region update node
            node10 = xd.SelectSingleNode("descendant::*[name(.) = 'Update']");
            if (UpdatingCheckBox.Checked == true)
            {
                node10.InnerText = "yes";
            }
            else
            {
                node10.InnerText = "no";
            }
            #endregion

            xd.Save(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Settings.config");
        }

        #endregion

        #region FtpExpand click

        private void FtpExpand_Click(object sender, EventArgs e)
        {
            this.Size = new Size(750, 350);
            FtpExpand.Visible = false;
            FtpExpand.Enabled = false;

            ftpDeXpand.Visible = true;
            ftpDeXpand.Enabled = true;
        }

        #endregion

        #region Ftp DeXpand click

        private void ftpDeXpand_Click(object sender, EventArgs e)
        {
            this.Size = new Size(350, 350);
            ftpDeXpand.Enabled = false;
            ftpDeXpand.Visible = false;

            FtpExpand.Enabled = true;
            FtpExpand.Visible = true;
        }

        #endregion 

        #region Allow only numbers in backup time

        private void BackupTimeBetweenKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue >= 96 && e.KeyValue <= 105 || e.KeyValue >= 48 && e.KeyValue <= 57 || e.KeyValue == 8)
            { }
            else
            {
                e.SuppressKeyPress = true;
                TT.Show("Please enter a number between 0 and 9.", BackuptimeText);
            }
        }

        #endregion
    }
}
