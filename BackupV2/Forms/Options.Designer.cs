﻿namespace BackupV2
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.SettingsFolder = new System.Windows.Forms.Button();
            this.BackupFrom = new System.Windows.Forms.TextBox();
            this.BackupTo = new System.Windows.Forms.TextBox();
            this.WorldFromLabel = new System.Windows.Forms.Label();
            this.WorldToLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.FtpExpand = new System.Windows.Forms.Button();
            this.ftpDeXpand = new System.Windows.Forms.Button();
            this.WarningTextBox = new System.Windows.Forms.RichTextBox();
            this.ftpUserText = new System.Windows.Forms.TextBox();
            this.ftpPassText = new System.Windows.Forms.TextBox();
            this.ftpServerText = new System.Windows.Forms.TextBox();
            this.ftpUserLabel = new System.Windows.Forms.Label();
            this.ftpPassLabel = new System.Windows.Forms.Label();
            this.ftpServerLabel = new System.Windows.Forms.Label();
            this.UseCompression = new System.Windows.Forms.CheckBox();
            this.FtpUsageHelpTextbox = new System.Windows.Forms.RichTextBox();
            this.ServerTextBox = new System.Windows.Forms.RichTextBox();
            this.ftpFolderText = new System.Windows.Forms.TextBox();
            this.FtpFolderLabel = new System.Windows.Forms.Label();
            this.ftpFolder2Text = new System.Windows.Forms.TextBox();
            this.Folder2Label = new System.Windows.Forms.Label();
            this.slash = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FolderTextbox = new System.Windows.Forms.RichTextBox();
            this.FtpLabel = new System.Windows.Forms.Label();
            this.TimeBetweenLabel = new System.Windows.Forms.Label();
            this.BackuptimeText = new System.Windows.Forms.TextBox();
            this.UpdatingCheckBox = new System.Windows.Forms.CheckBox();
            this.Label4FTP = new System.Windows.Forms.Label();
            this.CompressionNoUsed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SettingsFolder
            // 
            this.SettingsFolder.Location = new System.Drawing.Point(12, 12);
            this.SettingsFolder.Name = "SettingsFolder";
            this.SettingsFolder.Size = new System.Drawing.Size(74, 50);
            this.SettingsFolder.TabIndex = 0;
            this.SettingsFolder.Text = "Open settings folder";
            this.SettingsFolder.UseVisualStyleBackColor = true;
            this.SettingsFolder.Click += new System.EventHandler(this.SettingsFolder_Click);
            // 
            // BackupFrom
            // 
            this.BackupFrom.Location = new System.Drawing.Point(9, 237);
            this.BackupFrom.Name = "BackupFrom";
            this.BackupFrom.Size = new System.Drawing.Size(140, 20);
            this.BackupFrom.TabIndex = 2;
            // 
            // BackupTo
            // 
            this.BackupTo.Location = new System.Drawing.Point(172, 237);
            this.BackupTo.Name = "BackupTo";
            this.BackupTo.Size = new System.Drawing.Size(132, 20);
            this.BackupTo.TabIndex = 3;
            // 
            // WorldFromLabel
            // 
            this.WorldFromLabel.AutoSize = true;
            this.WorldFromLabel.Location = new System.Drawing.Point(10, 218);
            this.WorldFromLabel.Name = "WorldFromLabel";
            this.WorldFromLabel.Size = new System.Drawing.Size(64, 13);
            this.WorldFromLabel.TabIndex = 4;
            this.WorldFromLabel.Text = "World folder";
            // 
            // WorldToLabel
            // 
            this.WorldToLabel.AutoSize = true;
            this.WorldToLabel.Location = new System.Drawing.Point(169, 218);
            this.WorldToLabel.Name = "WorldToLabel";
            this.WorldToLabel.Size = new System.Drawing.Size(56, 13);
            this.WorldToLabel.TabIndex = 5;
            this.WorldToLabel.Text = "Backup to";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(172, 273);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(132, 41);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // FtpExpand
            // 
            this.FtpExpand.Location = new System.Drawing.Point(303, 8);
            this.FtpExpand.Name = "FtpExpand";
            this.FtpExpand.Size = new System.Drawing.Size(23, 23);
            this.FtpExpand.TabIndex = 8;
            this.FtpExpand.Text = ">";
            this.FtpExpand.UseVisualStyleBackColor = true;
            this.FtpExpand.Click += new System.EventHandler(this.FtpExpand_Click);
            // 
            // ftpDeXpand
            // 
            this.ftpDeXpand.Location = new System.Drawing.Point(303, 8);
            this.ftpDeXpand.Name = "ftpDeXpand";
            this.ftpDeXpand.Size = new System.Drawing.Size(23, 23);
            this.ftpDeXpand.TabIndex = 9;
            this.ftpDeXpand.Text = "<";
            this.ftpDeXpand.UseVisualStyleBackColor = true;
            this.ftpDeXpand.Click += new System.EventHandler(this.ftpDeXpand_Click);
            // 
            // WarningTextBox
            // 
            this.WarningTextBox.Location = new System.Drawing.Point(590, 5);
            this.WarningTextBox.Name = "WarningTextBox";
            this.WarningTextBox.Size = new System.Drawing.Size(114, 57);
            this.WarningTextBox.TabIndex = 10;
            this.WarningTextBox.Text = "!!WARNING!!\nFTP user and pass is stored as plain text!!";
            // 
            // ftpUserText
            // 
            this.ftpUserText.Location = new System.Drawing.Point(372, 31);
            this.ftpUserText.Name = "ftpUserText";
            this.ftpUserText.Size = new System.Drawing.Size(100, 20);
            this.ftpUserText.TabIndex = 11;
            // 
            // ftpPassText
            // 
            this.ftpPassText.Location = new System.Drawing.Point(484, 31);
            this.ftpPassText.Name = "ftpPassText";
            this.ftpPassText.Size = new System.Drawing.Size(100, 20);
            this.ftpPassText.TabIndex = 12;
            // 
            // ftpServerText
            // 
            this.ftpServerText.Location = new System.Drawing.Point(372, 86);
            this.ftpServerText.Name = "ftpServerText";
            this.ftpServerText.Size = new System.Drawing.Size(103, 20);
            this.ftpServerText.TabIndex = 13;
            // 
            // ftpUserLabel
            // 
            this.ftpUserLabel.AutoSize = true;
            this.ftpUserLabel.Location = new System.Drawing.Point(369, 7);
            this.ftpUserLabel.Name = "ftpUserLabel";
            this.ftpUserLabel.Size = new System.Drawing.Size(29, 13);
            this.ftpUserLabel.TabIndex = 14;
            this.ftpUserLabel.Text = "User";
            // 
            // ftpPassLabel
            // 
            this.ftpPassLabel.AutoSize = true;
            this.ftpPassLabel.Location = new System.Drawing.Point(481, 7);
            this.ftpPassLabel.Name = "ftpPassLabel";
            this.ftpPassLabel.Size = new System.Drawing.Size(30, 13);
            this.ftpPassLabel.TabIndex = 15;
            this.ftpPassLabel.Text = "Pass";
            // 
            // ftpServerLabel
            // 
            this.ftpServerLabel.AutoSize = true;
            this.ftpServerLabel.Location = new System.Drawing.Point(369, 66);
            this.ftpServerLabel.Name = "ftpServerLabel";
            this.ftpServerLabel.Size = new System.Drawing.Size(38, 13);
            this.ftpServerLabel.TabIndex = 16;
            this.ftpServerLabel.Text = "Server";
            // 
            // UseCompression
            // 
            this.UseCompression.AutoSize = true;
            this.UseCompression.Location = new System.Drawing.Point(12, 77);
            this.UseCompression.Name = "UseCompression";
            this.UseCompression.Size = new System.Drawing.Size(114, 17);
            this.UseCompression.TabIndex = 17;
            this.UseCompression.Text = "Use Compression?";
            this.UseCompression.UseVisualStyleBackColor = true;
            // 
            // FtpUsageHelpTextbox
            // 
            this.FtpUsageHelpTextbox.Location = new System.Drawing.Point(372, 198);
            this.FtpUsageHelpTextbox.Name = "FtpUsageHelpTextbox";
            this.FtpUsageHelpTextbox.Size = new System.Drawing.Size(145, 116);
            this.FtpUsageHelpTextbox.TabIndex = 18;
            this.FtpUsageHelpTextbox.Text = "How to use:\nIn \'World Folder\' type in:\nFTP\nin ALL CAPS.\n--OR--\nType FTP into \'Bac" +
                "kup To\'\nif uploading to an FTP server.";
            // 
            // ServerTextBox
            // 
            this.ServerTextBox.Location = new System.Drawing.Point(372, 112);
            this.ServerTextBox.Name = "ServerTextBox";
            this.ServerTextBox.Size = new System.Drawing.Size(145, 80);
            this.ServerTextBox.TabIndex = 19;
            this.ServerTextBox.Text = "For \'Server\'\nType in the IP/Hostname ONLY";
            // 
            // ftpFolderText
            // 
            this.ftpFolderText.Location = new System.Drawing.Point(499, 86);
            this.ftpFolderText.Name = "ftpFolderText";
            this.ftpFolderText.Size = new System.Drawing.Size(104, 20);
            this.ftpFolderText.TabIndex = 20;
            // 
            // FtpFolderLabel
            // 
            this.FtpFolderLabel.AutoSize = true;
            this.FtpFolderLabel.Location = new System.Drawing.Point(496, 66);
            this.FtpFolderLabel.Name = "FtpFolderLabel";
            this.FtpFolderLabel.Size = new System.Drawing.Size(36, 13);
            this.FtpFolderLabel.TabIndex = 21;
            this.FtpFolderLabel.Text = "Folder";
            // 
            // ftpFolder2Text
            // 
            this.ftpFolder2Text.Location = new System.Drawing.Point(627, 86);
            this.ftpFolder2Text.Name = "ftpFolder2Text";
            this.ftpFolder2Text.Size = new System.Drawing.Size(151, 20);
            this.ftpFolder2Text.TabIndex = 22;
            // 
            // Folder2Label
            // 
            this.Folder2Label.AutoSize = true;
            this.Folder2Label.Location = new System.Drawing.Point(624, 67);
            this.Folder2Label.Name = "Folder2Label";
            this.Folder2Label.Size = new System.Drawing.Size(45, 13);
            this.Folder2Label.TabIndex = 23;
            this.Folder2Label.Text = "Folder 2";
            // 
            // slash
            // 
            this.slash.AutoSize = true;
            this.slash.Location = new System.Drawing.Point(481, 89);
            this.slash.Name = "slash";
            this.slash.Size = new System.Drawing.Size(12, 13);
            this.slash.TabIndex = 24;
            this.slash.Text = "/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(609, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "/";
            // 
            // FolderTextbox
            // 
            this.FolderTextbox.Location = new System.Drawing.Point(527, 112);
            this.FolderTextbox.Name = "FolderTextbox";
            this.FolderTextbox.Size = new System.Drawing.Size(251, 202);
            this.FolderTextbox.TabIndex = 26;
            this.FolderTextbox.Text = resources.GetString("FolderTextbox.Text");
            // 
            // FtpLabel
            // 
            this.FtpLabel.AutoSize = true;
            this.FtpLabel.Location = new System.Drawing.Point(339, 89);
            this.FtpLabel.Name = "FtpLabel";
            this.FtpLabel.Size = new System.Drawing.Size(32, 13);
            this.FtpLabel.TabIndex = 27;
            this.FtpLabel.Text = "ftp://";
            // 
            // TimeBetweenLabel
            // 
            this.TimeBetweenLabel.AutoSize = true;
            this.TimeBetweenLabel.Location = new System.Drawing.Point(9, 273);
            this.TimeBetweenLabel.Name = "TimeBetweenLabel";
            this.TimeBetweenLabel.Size = new System.Drawing.Size(121, 13);
            this.TimeBetweenLabel.TabIndex = 29;
            this.TimeBetweenLabel.Text = "Time between backups:";
            // 
            // BackuptimeText
            // 
            this.BackuptimeText.Location = new System.Drawing.Point(9, 291);
            this.BackuptimeText.Name = "BackuptimeText";
            this.BackuptimeText.Size = new System.Drawing.Size(140, 20);
            this.BackuptimeText.TabIndex = 28;
            this.BackuptimeText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BackupTimeBetweenKeyDown);
            // 
            // UpdatingCheckBox
            // 
            this.UpdatingCheckBox.AutoSize = true;
            this.UpdatingCheckBox.Location = new System.Drawing.Point(9, 127);
            this.UpdatingCheckBox.Name = "UpdatingCheckBox";
            this.UpdatingCheckBox.Size = new System.Drawing.Size(157, 17);
            this.UpdatingCheckBox.TabIndex = 30;
            this.UpdatingCheckBox.Text = "Check for updates on start?";
            this.UpdatingCheckBox.UseVisualStyleBackColor = true;
            // 
            // Label4FTP
            // 
            this.Label4FTP.AutoSize = true;
            this.Label4FTP.Location = new System.Drawing.Point(265, 13);
            this.Label4FTP.Name = "Label4FTP";
            this.Label4FTP.Size = new System.Drawing.Size(27, 13);
            this.Label4FTP.TabIndex = 31;
            this.Label4FTP.Text = "FTP";
            // 
            // CompressionNoUsed
            // 
            this.CompressionNoUsed.AutoSize = true;
            this.CompressionNoUsed.Location = new System.Drawing.Point(32, 103);
            this.CompressionNoUsed.Name = "CompressionNoUsed";
            this.CompressionNoUsed.Size = new System.Drawing.Size(231, 13);
            this.CompressionNoUsed.TabIndex = 32;
            this.CompressionNoUsed.Text = "Compression is NOT used if backing up to FTP.";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 323);
            this.Controls.Add(this.CompressionNoUsed);
            this.Controls.Add(this.Label4FTP);
            this.Controls.Add(this.UpdatingCheckBox);
            this.Controls.Add(this.TimeBetweenLabel);
            this.Controls.Add(this.BackuptimeText);
            this.Controls.Add(this.FtpLabel);
            this.Controls.Add(this.FolderTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.slash);
            this.Controls.Add(this.Folder2Label);
            this.Controls.Add(this.ftpFolder2Text);
            this.Controls.Add(this.FtpFolderLabel);
            this.Controls.Add(this.ftpFolderText);
            this.Controls.Add(this.ServerTextBox);
            this.Controls.Add(this.FtpUsageHelpTextbox);
            this.Controls.Add(this.UseCompression);
            this.Controls.Add(this.ftpServerLabel);
            this.Controls.Add(this.ftpPassLabel);
            this.Controls.Add(this.ftpUserLabel);
            this.Controls.Add(this.ftpServerText);
            this.Controls.Add(this.ftpPassText);
            this.Controls.Add(this.ftpUserText);
            this.Controls.Add(this.WarningTextBox);
            this.Controls.Add(this.ftpDeXpand);
            this.Controls.Add(this.FtpExpand);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.WorldToLabel);
            this.Controls.Add(this.WorldFromLabel);
            this.Controls.Add(this.BackupTo);
            this.Controls.Add(this.BackupFrom);
            this.Controls.Add(this.SettingsFolder);
            this.Name = "Options";
            this.Text = "Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SettingsFolder;
        private System.Windows.Forms.TextBox BackupFrom;
        private System.Windows.Forms.TextBox BackupTo;
        private System.Windows.Forms.Label WorldFromLabel;
        private System.Windows.Forms.Label WorldToLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button FtpExpand;
        private System.Windows.Forms.Button ftpDeXpand;
        private System.Windows.Forms.RichTextBox WarningTextBox;
        private System.Windows.Forms.TextBox ftpUserText;
        private System.Windows.Forms.TextBox ftpPassText;
        private System.Windows.Forms.TextBox ftpServerText;
        private System.Windows.Forms.Label ftpUserLabel;
        private System.Windows.Forms.Label ftpPassLabel;
        private System.Windows.Forms.Label ftpServerLabel;
        private System.Windows.Forms.CheckBox UseCompression;
        private System.Windows.Forms.RichTextBox FtpUsageHelpTextbox;
        private System.Windows.Forms.RichTextBox ServerTextBox;
        private System.Windows.Forms.TextBox ftpFolderText;
        private System.Windows.Forms.Label FtpFolderLabel;
        private System.Windows.Forms.TextBox ftpFolder2Text;
        private System.Windows.Forms.Label Folder2Label;
        private System.Windows.Forms.Label slash;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox FolderTextbox;
        private System.Windows.Forms.Label FtpLabel;
        private System.Windows.Forms.Label TimeBetweenLabel;
        private System.Windows.Forms.TextBox BackuptimeText;
        private System.Windows.Forms.CheckBox UpdatingCheckBox;
        private System.Windows.Forms.Label Label4FTP;
        private System.Windows.Forms.Label CompressionNoUsed;
    }
}