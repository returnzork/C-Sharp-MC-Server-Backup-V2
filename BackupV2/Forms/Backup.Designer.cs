namespace BackupV2
{
    partial class Backup
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
            this.components = new System.ComponentModel.Container();
            this.CompressionBackground = new System.ComponentModel.BackgroundWorker();
            this.StartButton = new System.Windows.Forms.Button();
            this.CountdownThread = new System.ComponentModel.BackgroundWorker();
            this.StopButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WaitTimer = new System.Windows.Forms.Timer(this.components);
            this.updatePictureBox = new System.Windows.Forms.PictureBox();
            this.UpdateLabel = new System.Windows.Forms.Label();
            this.Check4UpdateThread = new System.ComponentModel.BackgroundWorker();
            this.HelpLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updatePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CompressionBackground
            // 
            this.CompressionBackground.WorkerReportsProgress = true;
            this.CompressionBackground.WorkerSupportsCancellation = true;
            this.CompressionBackground.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CompressionBackground_DoWork);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(82, 53);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(103, 38);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // CountdownThread
            // 
            this.CountdownThread.WorkerSupportsCancellation = true;
            this.CountdownThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CountdownThread_DoWork);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(203, 53);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(103, 38);
            this.StopButton.TabIndex = 11;
            this.StopButton.Text = "Cancel";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(318, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveWorldToolStripMenuItem,
            this.checkForUpdateToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveWorldToolStripMenuItem
            // 
            this.saveWorldToolStripMenuItem.Name = "saveWorldToolStripMenuItem";
            this.saveWorldToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.saveWorldToolStripMenuItem.Text = "Save World";
            this.saveWorldToolStripMenuItem.Click += new System.EventHandler(this.saveWorldToolStripMenuItem_Click);
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check for update";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // WaitTimer
            // 
            this.WaitTimer.Interval = 1000;
            this.WaitTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // updatePictureBox
            // 
            this.updatePictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.updatePictureBox.Location = new System.Drawing.Point(12, 27);
            this.updatePictureBox.Name = "updatePictureBox";
            this.updatePictureBox.Size = new System.Drawing.Size(64, 64);
            this.updatePictureBox.TabIndex = 13;
            this.updatePictureBox.TabStop = false;
            // 
            // UpdateLabel
            // 
            this.UpdateLabel.AutoSize = true;
            this.UpdateLabel.Location = new System.Drawing.Point(82, 27);
            this.UpdateLabel.Name = "UpdateLabel";
            this.UpdateLabel.Size = new System.Drawing.Size(87, 13);
            this.UpdateLabel.TabIndex = 14;
            this.UpdateLabel.Text = "Update available";
            // 
            // Check4UpdateThread
            // 
            this.Check4UpdateThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Check4UpdateThread_DoWork);
            // 
            // HelpLabel
            // 
            this.HelpLabel.AutoSize = true;
            this.HelpLabel.Location = new System.Drawing.Point(29, 94);
            this.HelpLabel.Name = "HelpLabel";
            this.HelpLabel.Size = new System.Drawing.Size(277, 13);
            this.HelpLabel.TabIndex = 15;
            this.HelpLabel.Text = "(go into File>options and set the parameters to continue..)";
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 111);
            this.Controls.Add(this.HelpLabel);
            this.Controls.Add(this.UpdateLabel);
            this.Controls.Add(this.updatePictureBox);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.StartButton);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Backup";
            this.Text = "Minecraft Server Backup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCLOSED);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updatePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker CompressionBackground;
        private System.Windows.Forms.Button StartButton;
        private System.ComponentModel.BackgroundWorker CountdownThread;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWorldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Timer WaitTimer;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.PictureBox updatePictureBox;
        private System.Windows.Forms.Label UpdateLabel;
        private System.ComponentModel.BackgroundWorker Check4UpdateThread;
        private System.Windows.Forms.Label HelpLabel;
    }
}

