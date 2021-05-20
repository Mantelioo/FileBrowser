namespace FileBrowser
{
    partial class Form1
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LblDriveStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblPath = new System.Windows.Forms.ToolStripStatusLabel();
            this.LstDrives = new System.Windows.Forms.ListBox();
            this.LstFolderAndFiles = new System.Windows.Forms.ListBox();
            this.BtnGetDrives = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblDriveStatus,
            this.LblPath});
            this.statusStrip1.Location = new System.Drawing.Point(0, 381);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(441, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LblDriveStatus
            // 
            this.LblDriveStatus.Name = "LblDriveStatus";
            this.LblDriveStatus.Size = new System.Drawing.Size(86, 20);
            this.LblDriveStatus.Text = "Drive status";
            // 
            // LblPath
            // 
            this.LblPath.Name = "LblPath";
            this.LblPath.Size = new System.Drawing.Size(30, 20);
            this.LblPath.Text = "NA";
            // 
            // LstDrives
            // 
            this.LstDrives.FormattingEnabled = true;
            this.LstDrives.ItemHeight = 16;
            this.LstDrives.Location = new System.Drawing.Point(16, 82);
            this.LstDrives.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LstDrives.Name = "LstDrives";
            this.LstDrives.Size = new System.Drawing.Size(159, 276);
            this.LstDrives.TabIndex = 1;
            this.LstDrives.SelectedIndexChanged += new System.EventHandler(this.LstDrives_SelectedIndexChanged);
            this.LstDrives.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LstDrives_MouseDoubleClick);
            // 
            // LstFolderAndFiles
            // 
            this.LstFolderAndFiles.FormattingEnabled = true;
            this.LstFolderAndFiles.ItemHeight = 16;
            this.LstFolderAndFiles.Location = new System.Drawing.Point(265, 82);
            this.LstFolderAndFiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LstFolderAndFiles.Name = "LstFolderAndFiles";
            this.LstFolderAndFiles.Size = new System.Drawing.Size(159, 276);
            this.LstFolderAndFiles.TabIndex = 2;
            this.LstFolderAndFiles.SelectedIndexChanged += new System.EventHandler(this.LstFolderAndFiles_SelectedIndexChanged);
            this.LstFolderAndFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LstFolderAndFiles_KeyDown);
            this.LstFolderAndFiles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LstFolderAndFiles_KeyPress);
            this.LstFolderAndFiles.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LstFolderAndFiles_KeyUp);
            this.LstFolderAndFiles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LstFolderAndFiles_MouseDoubleClick);
            // 
            // BtnGetDrives
            // 
            this.BtnGetDrives.Location = new System.Drawing.Point(16, 15);
            this.BtnGetDrives.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnGetDrives.Name = "BtnGetDrives";
            this.BtnGetDrives.Size = new System.Drawing.Size(149, 42);
            this.BtnGetDrives.TabIndex = 3;
            this.BtnGetDrives.Text = "Get drives";
            this.BtnGetDrives.UseVisualStyleBackColor = true;
            this.BtnGetDrives.Click += new System.EventHandler(this.BtnGetDrives_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 407);
            this.Controls.Add(this.BtnGetDrives);
            this.Controls.Add(this.LstFolderAndFiles);
            this.Controls.Add(this.LstDrives);
            this.Controls.Add(this.statusStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LblDriveStatus;
        private System.Windows.Forms.ToolStripStatusLabel LblPath;
        private System.Windows.Forms.ListBox LstDrives;
        private System.Windows.Forms.ListBox LstFolderAndFiles;
        private System.Windows.Forms.Button BtnGetDrives;
    }
}

