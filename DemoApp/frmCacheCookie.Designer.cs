namespace DemoApp
{
    partial class frmCacheCookie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCacheCookie));
            this.tsCacheCookie = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonDelSelected = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelChecked = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelAll = new System.Windows.Forms.ToolStripButton();
            this.lsvCacheCookie = new System.Windows.Forms.ListView();
            this.colLocalPath = new System.Windows.Forms.ColumnHeader();
            this.colLastModified = new System.Windows.Forms.ColumnHeader();
            this.colLastAccessed = new System.Windows.Forms.ColumnHeader();
            this.colExpires = new System.Windows.Forms.ColumnHeader();
            this.colsize = new System.Windows.Forms.ColumnHeader();
            this.colUrl = new System.Windows.Forms.ColumnHeader();
            this.tsCacheCookie.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsCacheCookie
            // 
            this.tsCacheCookie.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonDelSelected,
            this.toolStripButtonDelChecked,
            this.toolStripButtonDelAll});
            this.tsCacheCookie.Location = new System.Drawing.Point(0, 0);
            this.tsCacheCookie.Name = "tsCacheCookie";
            this.tsCacheCookie.Size = new System.Drawing.Size(498, 25);
            this.tsCacheCookie.TabIndex = 0;
            this.tsCacheCookie.Text = "toolStrip1";
            // 
            // toolStripButtonDelSelected
            // 
            this.toolStripButtonDelSelected.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelSelected.Image")));
            this.toolStripButtonDelSelected.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelSelected.Name = "toolStripButtonDelSelected";
            this.toolStripButtonDelSelected.Size = new System.Drawing.Size(126, 22);
            this.toolStripButtonDelSelected.Text = "Delete Selected Items";
            this.toolStripButtonDelSelected.Click += new System.EventHandler(this.toolStripButtonDelSelected_Click);
            // 
            // toolStripButtonDelChecked
            // 
            this.toolStripButtonDelChecked.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelChecked.Image")));
            this.toolStripButtonDelChecked.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelChecked.Name = "toolStripButtonDelChecked";
            this.toolStripButtonDelChecked.Size = new System.Drawing.Size(132, 22);
            this.toolStripButtonDelChecked.Text = "Delete Checked Items";
            this.toolStripButtonDelChecked.Click += new System.EventHandler(this.toolStripButtonDelChecked_Click);
            // 
            // toolStripButtonDelAll
            // 
            this.toolStripButtonDelAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelAll.Image")));
            this.toolStripButtonDelAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelAll.Name = "toolStripButtonDelAll";
            this.toolStripButtonDelAll.Size = new System.Drawing.Size(100, 22);
            this.toolStripButtonDelAll.Text = "Delete All Items";
            this.toolStripButtonDelAll.Click += new System.EventHandler(this.toolStripButtonDelAll_Click);
            // 
            // lsvCacheCookie
            // 
            this.lsvCacheCookie.CheckBoxes = true;
            this.lsvCacheCookie.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUrl,
            this.colLocalPath,
            this.colLastModified,
            this.colLastAccessed,
            this.colExpires,
            this.colsize});
            this.lsvCacheCookie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvCacheCookie.FullRowSelect = true;
            this.lsvCacheCookie.GridLines = true;
            this.lsvCacheCookie.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvCacheCookie.Location = new System.Drawing.Point(0, 25);
            this.lsvCacheCookie.Name = "lsvCacheCookie";
            this.lsvCacheCookie.ShowItemToolTips = true;
            this.lsvCacheCookie.Size = new System.Drawing.Size(498, 395);
            this.lsvCacheCookie.TabIndex = 1;
            this.lsvCacheCookie.UseCompatibleStateImageBehavior = false;
            this.lsvCacheCookie.View = System.Windows.Forms.View.Details;
            // 
            // colLocalPath
            // 
            this.colLocalPath.Text = "Local Path";
            this.colLocalPath.Width = 103;
            // 
            // colLastModified
            // 
            this.colLastModified.Text = "Last Modified";
            this.colLastModified.Width = 82;
            // 
            // colLastAccessed
            // 
            this.colLastAccessed.Text = "Last Accessesd";
            this.colLastAccessed.Width = 72;
            // 
            // colExpires
            // 
            this.colExpires.Text = "Expires";
            // 
            // colsize
            // 
            this.colsize.Text = "Size";
            this.colsize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colUrl
            // 
            this.colUrl.Text = "Url";
            this.colUrl.Width = 96;
            // 
            // frmCacheCookie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 420);
            this.Controls.Add(this.lsvCacheCookie);
            this.Controls.Add(this.tsCacheCookie);
            this.Name = "frmCacheCookie";
            this.Text = "Cache + Cookies";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCacheCookie_FormClosing);
            this.Load += new System.EventHandler(this.frmCacheCookie_Load);
            this.tsCacheCookie.ResumeLayout(false);
            this.tsCacheCookie.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsCacheCookie;
        private System.Windows.Forms.ListView lsvCacheCookie;
        private System.Windows.Forms.ColumnHeader colLocalPath;
        private System.Windows.Forms.ColumnHeader colLastModified;
        private System.Windows.Forms.ColumnHeader colLastAccessed;
        private System.Windows.Forms.ColumnHeader colExpires;
        private System.Windows.Forms.ColumnHeader colsize;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelSelected;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelChecked;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelAll;
        private System.Windows.Forms.ColumnHeader colUrl;
    }
}