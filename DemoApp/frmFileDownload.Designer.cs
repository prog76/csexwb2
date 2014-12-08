namespace DemoApp
{
    partial class frmFileDownload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileDownload));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsStopDownload = new System.Windows.Forms.ToolStripButton();
            this.tsNotifyEndDownload = new System.Windows.Forms.ToolStripButton();
            this.tsCloseDownload = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRemoveCompleted = new System.Windows.Forms.ToolStripButton();
            this.lvDownloads = new System.Windows.Forms.ListView();
            this.colURLDownload = new System.Windows.Forms.ColumnHeader();
            this.colSavingTo = new System.Windows.Forms.ColumnHeader();
            this.colDownloadStatus = new System.Windows.Forms.ColumnHeader();
            this.colBytesReceived = new System.Windows.Forms.ColumnHeader();
            this.colPercentage = new System.Windows.Forms.ColumnHeader();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStopDownload,
            this.tsNotifyEndDownload,
            this.tsCloseDownload,
            this.tsBtnRemoveCompleted});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(679, 25);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "toolStrip1";
            this.tsMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // tsStopDownload
            // 
            this.tsStopDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsStopDownload.Image = ((System.Drawing.Image)(resources.GetObject("tsStopDownload.Image")));
            this.tsStopDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsStopDownload.Name = "tsStopDownload";
            this.tsStopDownload.Size = new System.Drawing.Size(98, 22);
            this.tsStopDownload.Text = "Stop Download";
            // 
            // tsNotifyEndDownload
            // 
            this.tsNotifyEndDownload.CheckOnClick = true;
            this.tsNotifyEndDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsNotifyEndDownload.Image = ((System.Drawing.Image)(resources.GetObject("tsNotifyEndDownload.Image")));
            this.tsNotifyEndDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNotifyEndDownload.Name = "tsNotifyEndDownload";
            this.tsNotifyEndDownload.Size = new System.Drawing.Size(172, 22);
            this.tsNotifyEndDownload.Text = "Notify When Download Ends";
            // 
            // tsCloseDownload
            // 
            this.tsCloseDownload.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsCloseDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsCloseDownload.Image = ((System.Drawing.Image)(resources.GetObject("tsCloseDownload.Image")));
            this.tsCloseDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCloseDownload.Name = "tsCloseDownload";
            this.tsCloseDownload.Size = new System.Drawing.Size(43, 22);
            this.tsCloseDownload.Text = "Close";
            // 
            // tsBtnRemoveCompleted
            // 
            this.tsBtnRemoveCompleted.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsBtnRemoveCompleted.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRemoveCompleted.Image")));
            this.tsBtnRemoveCompleted.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRemoveCompleted.Name = "tsBtnRemoveCompleted";
            this.tsBtnRemoveCompleted.Size = new System.Drawing.Size(123, 22);
            this.tsBtnRemoveCompleted.Text = "Remove Completed";
            // 
            // lvDownloads
            // 
            this.lvDownloads.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvDownloads.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colURLDownload,
            this.colSavingTo,
            this.colDownloadStatus,
            this.colBytesReceived,
            this.colPercentage});
            this.lvDownloads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDownloads.GridLines = true;
            this.lvDownloads.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvDownloads.Location = new System.Drawing.Point(0, 25);
            this.lvDownloads.MultiSelect = false;
            this.lvDownloads.Name = "lvDownloads";
            this.lvDownloads.ShowItemToolTips = true;
            this.lvDownloads.Size = new System.Drawing.Size(679, 363);
            this.lvDownloads.TabIndex = 1;
            this.lvDownloads.UseCompatibleStateImageBehavior = false;
            this.lvDownloads.View = System.Windows.Forms.View.Details;
            // 
            // colURLDownload
            // 
            this.colURLDownload.Text = "Downloading URL";
            this.colURLDownload.Width = 150;
            // 
            // colSavingTo
            // 
            this.colSavingTo.Text = "Saving To";
            this.colSavingTo.Width = 150;
            // 
            // colDownloadStatus
            // 
            this.colDownloadStatus.Text = "Download Status";
            this.colDownloadStatus.Width = 100;
            // 
            // colBytesReceived
            // 
            this.colBytesReceived.Text = "Bytes Received";
            this.colBytesReceived.Width = 130;
            // 
            // colPercentage
            // 
            this.colPercentage.Text = "Percentage";
            this.colPercentage.Width = 100;
            // 
            // frmFileDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 388);
            this.Controls.Add(this.lvDownloads);
            this.Controls.Add(this.tsMain);
            this.Name = "frmFileDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "< 0 > File Downloads";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFileDownload_FormClosing);
            this.Load += new System.EventHandler(this.frmFileDownload_Load);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsStopDownload;
        private System.Windows.Forms.ToolStripButton tsNotifyEndDownload;
        private System.Windows.Forms.ToolStripButton tsCloseDownload;
        private System.Windows.Forms.ListView lvDownloads;
        private System.Windows.Forms.ColumnHeader colURLDownload;
        private System.Windows.Forms.ColumnHeader colSavingTo;
        private System.Windows.Forms.ColumnHeader colDownloadStatus;
        private System.Windows.Forms.ColumnHeader colBytesReceived;
        private System.Windows.Forms.ToolStripButton tsBtnRemoveCompleted;
        private System.Windows.Forms.ColumnHeader colPercentage;
    }
}