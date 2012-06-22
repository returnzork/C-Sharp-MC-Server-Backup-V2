namespace BackupV2
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
            this.SettingsFolder = new System.Windows.Forms.Button();
            this.BackupFrom = new System.Windows.Forms.TextBox();
            this.BackupTo = new System.Windows.Forms.TextBox();
            this.WorldFromLabel = new System.Windows.Forms.Label();
            this.WorldToLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ftpusage = new System.Windows.Forms.CheckBox();
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ftpFolderText = new System.Windows.Forms.TextBox();
            this.FtpFolderLabel = new System.Windows.Forms.Label();
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
            this.BackupFrom.Location = new System.Drawing.Point(12, 229);
            this.BackupFrom.Name = "BackupFrom";
            this.BackupFrom.Size = new System.Drawing.Size(132, 20);
            this.BackupFrom.TabIndex = 2;
            // 
            // BackupTo
            // 
            this.BackupTo.Location = new System.Drawing.Point(175, 229);
            this.BackupTo.Name = "BackupTo";
            this.BackupTo.Size = new System.Drawing.Size(132, 20);
            this.BackupTo.TabIndex = 3;
            // 
            // WorldFromLabel
            // 
            this.WorldFromLabel.AutoSize = true;
            this.WorldFromLabel.Location = new System.Drawing.Point(13, 210);
            this.WorldFromLabel.Name = "WorldFromLabel";
            this.WorldFromLabel.Size = new System.Drawing.Size(64, 13);
            this.WorldFromLabel.TabIndex = 4;
            this.WorldFromLabel.Text = "World folder";
            // 
            // WorldToLabel
            // 
            this.WorldToLabel.AutoSize = true;
            this.WorldToLabel.Location = new System.Drawing.Point(172, 210);
            this.WorldToLabel.Name = "WorldToLabel";
            this.WorldToLabel.Size = new System.Drawing.Size(56, 13);
            this.WorldToLabel.TabIndex = 5;
            this.WorldToLabel.Text = "Backup to";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(70, 268);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(177, 35);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ftpusage
            // 
            this.ftpusage.AutoSize = true;
            this.ftpusage.Location = new System.Drawing.Point(231, 12);
            this.ftpusage.Name = "ftpusage";
            this.ftpusage.Size = new System.Drawing.Size(66, 17);
            this.ftpusage.TabIndex = 7;
            this.ftpusage.Text = "Use ftp?";
            this.ftpusage.UseVisualStyleBackColor = true;
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
            this.WarningTextBox.Location = new System.Drawing.Point(352, 233);
            this.WarningTextBox.Name = "WarningTextBox";
            this.WarningTextBox.Size = new System.Drawing.Size(157, 70);
            this.WarningTextBox.TabIndex = 10;
            this.WarningTextBox.Text = "!!WARNING!!\nFTP user and pass is stored as plain text!!";
            // 
            // ftpUserText
            // 
            this.ftpUserText.Location = new System.Drawing.Point(372, 42);
            this.ftpUserText.Name = "ftpUserText";
            this.ftpUserText.Size = new System.Drawing.Size(100, 20);
            this.ftpUserText.TabIndex = 11;
            this.ftpUserText.Text = "test";
            // 
            // ftpPassText
            // 
            this.ftpPassText.Location = new System.Drawing.Point(484, 42);
            this.ftpPassText.Name = "ftpPassText";
            this.ftpPassText.Size = new System.Drawing.Size(100, 20);
            this.ftpPassText.TabIndex = 12;
            // 
            // ftpServerText
            // 
            this.ftpServerText.Location = new System.Drawing.Point(372, 97);
            this.ftpServerText.Name = "ftpServerText";
            this.ftpServerText.Size = new System.Drawing.Size(100, 20);
            this.ftpServerText.TabIndex = 13;
            // 
            // ftpUserLabel
            // 
            this.ftpUserLabel.AutoSize = true;
            this.ftpUserLabel.Location = new System.Drawing.Point(369, 18);
            this.ftpUserLabel.Name = "ftpUserLabel";
            this.ftpUserLabel.Size = new System.Drawing.Size(29, 13);
            this.ftpUserLabel.TabIndex = 14;
            this.ftpUserLabel.Text = "User";
            // 
            // ftpPassLabel
            // 
            this.ftpPassLabel.AutoSize = true;
            this.ftpPassLabel.Location = new System.Drawing.Point(481, 18);
            this.ftpPassLabel.Name = "ftpPassLabel";
            this.ftpPassLabel.Size = new System.Drawing.Size(30, 13);
            this.ftpPassLabel.TabIndex = 15;
            this.ftpPassLabel.Text = "Pass";
            // 
            // ftpServerLabel
            // 
            this.ftpServerLabel.AutoSize = true;
            this.ftpServerLabel.Location = new System.Drawing.Point(369, 77);
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
            this.FtpUsageHelpTextbox.Location = new System.Drawing.Point(515, 233);
            this.FtpUsageHelpTextbox.Name = "FtpUsageHelpTextbox";
            this.FtpUsageHelpTextbox.Size = new System.Drawing.Size(157, 70);
            this.FtpUsageHelpTextbox.TabIndex = 18;
            this.FtpUsageHelpTextbox.Text = "How to use:\nIn \'World Folder\' type in:\nFTP\nin ALL CAPS.";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(372, 123);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(157, 50);
            this.richTextBox1.TabIndex = 19;
            this.richTextBox1.Text = "For \'Server\'\nType in the IP/Hostname ONLY";
            // 
            // ftpFolderText
            // 
            this.ftpFolderText.Location = new System.Drawing.Point(484, 97);
            this.ftpFolderText.Name = "ftpFolderText";
            this.ftpFolderText.Size = new System.Drawing.Size(100, 20);
            this.ftpFolderText.TabIndex = 20;
            // 
            // FtpFolderLabel
            // 
            this.FtpFolderLabel.AutoSize = true;
            this.FtpFolderLabel.Location = new System.Drawing.Point(481, 78);
            this.FtpFolderLabel.Name = "FtpFolderLabel";
            this.FtpFolderLabel.Size = new System.Drawing.Size(36, 13);
            this.FtpFolderLabel.TabIndex = 21;
            this.FtpFolderLabel.Text = "Folder";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 312);
            this.Controls.Add(this.FtpFolderLabel);
            this.Controls.Add(this.ftpFolderText);
            this.Controls.Add(this.richTextBox1);
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
            this.Controls.Add(this.ftpusage);
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
        private System.Windows.Forms.CheckBox ftpusage;
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
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox ftpFolderText;
        private System.Windows.Forms.Label FtpFolderLabel;
    }
}