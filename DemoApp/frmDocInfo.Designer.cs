namespace DemoApp
{
    partial class frmDocInfo
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
            this.ctxMnuDocInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeDocInfo = new System.Windows.Forms.TreeView();
            this.ctxMnuTreeDocInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveAsXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDocInfo = new System.Windows.Forms.TextBox();
            this.ctxMnuDocInfo.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ctxMnuTreeDocInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctxMnuDocInfo
            // 
            this.ctxMnuDocInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem});
            this.ctxMnuDocInfo.Name = "ctxMnuDOM";
            this.ctxMnuDocInfo.Size = new System.Drawing.Size(122, 76);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(118, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeDocInfo);
            this.splitContainer1.Panel1MinSize = 50;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtDocInfo);
            this.splitContainer1.Panel2MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(583, 455);
            this.splitContainer1.SplitterDistance = 194;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeDocInfo
            // 
            this.treeDocInfo.ContextMenuStrip = this.ctxMnuTreeDocInfo;
            this.treeDocInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDocInfo.Location = new System.Drawing.Point(0, 0);
            this.treeDocInfo.Name = "treeDocInfo";
            this.treeDocInfo.Size = new System.Drawing.Size(194, 455);
            this.treeDocInfo.TabIndex = 0;
            this.treeDocInfo.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeDocInfo_NodeMouseClick);
            // 
            // ctxMnuTreeDocInfo
            // 
            this.ctxMnuTreeDocInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsXMLToolStripMenuItem});
            this.ctxMnuTreeDocInfo.Name = "ctxMnuTreeDocInfo";
            this.ctxMnuTreeDocInfo.Size = new System.Drawing.Size(142, 26);
            // 
            // saveAsXMLToolStripMenuItem
            // 
            this.saveAsXMLToolStripMenuItem.Name = "saveAsXMLToolStripMenuItem";
            this.saveAsXMLToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.saveAsXMLToolStripMenuItem.Text = "Save as XML";
            this.saveAsXMLToolStripMenuItem.Click += new System.EventHandler(this.saveAsXMLToolStripMenuItem_Click);
            // 
            // txtDocInfo
            // 
            this.txtDocInfo.ContextMenuStrip = this.ctxMnuDocInfo;
            this.txtDocInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDocInfo.Location = new System.Drawing.Point(0, 0);
            this.txtDocInfo.Multiline = true;
            this.txtDocInfo.Name = "txtDocInfo";
            this.txtDocInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDocInfo.Size = new System.Drawing.Size(387, 455);
            this.txtDocInfo.TabIndex = 0;
            // 
            // frmDocInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 455);
            this.Controls.Add(this.splitContainer1);
            this.MinimizeBox = false;
            this.Name = "frmDocInfo";
            this.Text = "Document Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDocInfo_FormClosing);
            this.Load += new System.EventHandler(this.frmDocInfo_Load);
            this.ctxMnuDocInfo.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ctxMnuTreeDocInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ctxMnuDocInfo;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeDocInfo;
        private System.Windows.Forms.TextBox txtDocInfo;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip ctxMnuTreeDocInfo;
        private System.Windows.Forms.ToolStripMenuItem saveAsXMLToolStripMenuItem;
    }
}