using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Drawing;

namespace BackupV2
{
    public partial class Options : Form
    {
        XmlDocument xd = new XmlDocument();
        XmlNode node1, node2, node3, node4, node5;


        public Options()
        {
            InitializeComponent();
            this.Size = new Size(350, 280);
        }

        private void Options_Load(object sender, EventArgs e)
        {
            ftpusage.Enabled = false;
            ftpDeXpand.Visible = false;
            ftpDeXpand.Enabled = false;



            //start load world folder

            Xml_Reader XML = new Xml_Reader();
            string World = XML.GetWorld();
            BackupFrom.Text = World;

            //end load world folder


            //start load Backup To folder

            string WorldTo = XML.GetBackupTo();
            BackupTo.Text = WorldTo;

            //end load Backup Tofolder


            //start ftp loading

            string ftpUser = XML.GetFtpUser();
            string ftpPass = XML.GetFtpPass();
            string ftpServer = XML.GetFtpServer();
            ftpUserText.Text = ftpUser;
            ftpPassText.Text = ftpPass;
            ftpServerText.Text = ftpServer;

        }

        private void SettingsFolder_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            ProcessStartInfo StartInfo = new ProcessStartInfo();
            StartInfo.FileName = "explorer.exe";
            StartInfo.Arguments = Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork";
            p.StartInfo = StartInfo;
            p.Start();
        }

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


            xd.Save(Environment.GetEnvironmentVariable("APPDATA") + "\\returnzork\\Settings.config");
        }

        private void ftpusage_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FtpExpand_Click(object sender, EventArgs e)
        {
            this.Size = new Size(700, 280);
            FtpExpand.Visible = false;
            FtpExpand.Enabled = false;

            ftpDeXpand.Visible = true;
            ftpDeXpand.Enabled = true;
        }

        private void ftpDeXpand_Click(object sender, EventArgs e)
        {
            this.Size = new Size(350, 280);
            ftpDeXpand.Enabled = false;
            ftpDeXpand.Visible = false;

            FtpExpand.Enabled = true;
            FtpExpand.Visible = true;
        }
    }
}
