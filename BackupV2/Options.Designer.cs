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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ftpusage = new System.Windows.Forms.CheckBox();
            this.FtpExpand = new System.Windows.Forms.Button();
            this.ftpDeXpand = new System.Windows.Forms.Button();
            this.WarningTextBox = new System.Windows.Forms.RichTextBox();
            this.ftpUserText = new System.Windows.Forms.TextBox();
            this.ftpPassText = new System.Windows.Forms.TextBox();
            this.ftpServerText = new System.Windows.Forms.TextBox();
            this.ftpUser = new System.Windows.Forms.Label();
            this.ftpPass = new System.Windows.Forms.Label();
            this.ftpServer = new System.Windows.Forms.Label();
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
            this.BackupFrom.Location = new System.Drawing.Point(12, 142);
            this.BackupFrom.Name = "BackupFrom";
            this.BackupFrom.Size = new System.Drawing.Size(132, 20);
            this.BackupFrom.TabIndex = 2;
            // 
            // BackupTo
            // 
            this.BackupTo.Location = new System.Drawing.Point(194, 142);
            this.BackupTo.Name = "BackupTo";
            this.BackupTo.Size = new System.Drawing.Size(132, 20);
            this.BackupTo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "World folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Backup to";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(69, 188);
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
            this.ftpusage.CheckedChanged += new System.EventHandler(this.ftpusage_CheckedChanged);
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
            this.WarningTextBox.Location = new System.Drawing.Point(478, 123);
            this.WarningTextBox.Name = "WarningTextBox";
            this.WarningTextBox.Size = new System.Drawing.Size(157, 102);
            this.WarningTextBox.TabIndex = 10;
            this.WarningTextBox.Text = "!!WARNING!!\nFTP user and pass is stored as plain text!!";
            // 
            // ftpUserText
            // 
            this.ftpUserText.Location = new System.Drawing.Point(429, 42);
            this.ftpUserText.Name = "ftpUserText";
            this.ftpUserText.Size = new System.Drawing.Size(100, 20);
            this.ftpUserText.TabIndex = 11;
            this.ftpUserText.Text = "test";
            // 
            // ftpPassText
            // 
            this.ftpPassText.Location = new System.Drawing.Point(557, 42);
            this.ftpPassText.Name = "ftpPassText";
            this.ftpPassText.Size = new System.Drawing.Size(100, 20);
            this.ftpPassText.TabIndex = 12;
            // 
            // ftpServerText
            // 
            this.ftpServerText.Location = new System.Drawing.Point(429, 97);
            this.ftpServerText.Name = "ftpServerText";
            this.ftpServerText.Size = new System.Drawing.Size(100, 20);
            this.ftpServerText.TabIndex = 13;
            // 
            // ftpUser
            // 
            this.ftpUser.AutoSize = true;
            this.ftpUser.Location = new System.Drawing.Point(429, 17);
            this.ftpUser.Name = "ftpUser";
            this.ftpUser.Size = new System.Drawing.Size(29, 13);
            this.ftpUser.TabIndex = 14;
            this.ftpUser.Text = "User";
            // 
            // ftpPass
            // 
            this.ftpPass.AutoSize = true;
            this.ftpPass.Location = new System.Drawing.Point(554, 17);
            this.ftpPass.Name = "ftpPass";
            this.ftpPass.Size = new System.Drawing.Size(30, 13);
            this.ftpPass.TabIndex = 15;
            this.ftpPass.Text = "Pass";
            // 
            // ftpServer
            // 
            this.ftpServer.AutoSize = true;
            this.ftpServer.Location = new System.Drawing.Point(429, 77);
            this.ftpServer.Name = "ftpServer";
            this.ftpServer.Size = new System.Drawing.Size(38, 13);
            this.ftpServer.TabIndex = 16;
            this.ftpServer.Text = "Server";
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 242);
            this.Controls.Add(this.ftpServer);
            this.Controls.Add(this.ftpPass);
            this.Controls.Add(this.ftpUser);
            this.Controls.Add(this.ftpServerText);
            this.Controls.Add(this.ftpPassText);
            this.Controls.Add(this.ftpUserText);
            this.Controls.Add(this.WarningTextBox);
            this.Controls.Add(this.ftpDeXpand);
            this.Controls.Add(this.FtpExpand);
            this.Controls.Add(this.ftpusage);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.CheckBox ftpusage;
        private System.Windows.Forms.Button FtpExpand;
        private System.Windows.Forms.Button ftpDeXpand;
        private System.Windows.Forms.RichTextBox WarningTextBox;
        private System.Windows.Forms.TextBox ftpUserText;
        private System.Windows.Forms.TextBox ftpPassText;
        private System.Windows.Forms.TextBox ftpServerText;
        private System.Windows.Forms.Label ftpUser;
        private System.Windows.Forms.Label ftpPass;
        private System.Windows.Forms.Label ftpServer;
    }
}