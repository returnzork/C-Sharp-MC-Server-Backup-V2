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
            this.CountdownTime = new System.Windows.Forms.TextBox();
            this.CompressionBackground = new System.ComponentModel.BackgroundWorker();
            this.StartButton = new System.Windows.Forms.Button();
            this.CountdownThread = new System.ComponentModel.BackgroundWorker();
            this.Label3 = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWorldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WaitTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CountdownTime
            // 
            this.CountdownTime.Location = new System.Drawing.Point(155, 85);
            this.CountdownTime.Name = "CountdownTime";
            this.CountdownTime.Size = new System.Drawing.Size(109, 20);
            this.CountdownTime.TabIndex = 2;
            // 
            // CompressionBackground
            // 
            this.CompressionBackground.WorkerReportsProgress = true;
            this.CompressionBackground.WorkerSupportsCancellation = true;
            this.CompressionBackground.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CompressionBackground_DoWork);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(25, 141);
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
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(152, 58);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(77, 13);
            this.Label3.TabIndex = 10;
            this.Label3.Text = "Time between:";
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(305, 141);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(103, 38);
            this.Cancel.TabIndex = 11;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(444, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveWorldToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveWorldToolStripMenuItem
            // 
            this.saveWorldToolStripMenuItem.Name = "saveWorldToolStripMenuItem";
            this.saveWorldToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.saveWorldToolStripMenuItem.Text = "Save World";
            this.saveWorldToolStripMenuItem.Click += new System.EventHandler(this.saveWorldToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // WaitTimer
            // 
            this.WaitTimer.Interval = 1000;
            this.WaitTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 201);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.CountdownTime);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Backup";
            this.Text = "Minecraft Server Backup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCLOSED);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CountdownTime;
        private System.ComponentModel.BackgroundWorker CompressionBackground;
        private System.Windows.Forms.Button StartButton;
        private System.ComponentModel.BackgroundWorker CountdownThread;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWorldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.Timer WaitTimer;
    }
}

