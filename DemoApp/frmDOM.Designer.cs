namespace DemoApp
{
    partial class frmDOM
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
            this.treeDOM = new System.Windows.Forms.TreeView();
            this.ctxMnuTreeDOM = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuTreeDOM.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeDOM
            // 
            this.treeDOM.ContextMenuStrip = this.ctxMnuTreeDOM;
            this.treeDOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeDOM.Location = new System.Drawing.Point(0, 0);
            this.treeDOM.Name = "treeDOM";
            this.treeDOM.Size = new System.Drawing.Size(503, 448);
            this.treeDOM.TabIndex = 0;
            // 
            // ctxMnuTreeDOM
            // 
            this.ctxMnuTreeDOM.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveTreeToolStripMenuItem});
            this.ctxMnuTreeDOM.Name = "ctxMnuTreeDOM";
            this.ctxMnuTreeDOM.Size = new System.Drawing.Size(128, 26);
            // 
            // saveTreeToolStripMenuItem
            // 
            this.saveTreeToolStripMenuItem.Name = "saveTreeToolStripMenuItem";
            this.saveTreeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveTreeToolStripMenuItem.Text = "Save DOM as XML";
            this.saveTreeToolStripMenuItem.Click += new System.EventHandler(this.saveTreeToolStripMenuItem_Click);
            // 
            // frmDOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 448);
            this.Controls.Add(this.treeDOM);
            this.Name = "frmDOM";
            this.Text = "DOM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDOM_FormClosing);
            this.Load += new System.EventHandler(this.frmDOM_Load);
            this.ctxMnuTreeDOM.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeDOM;
        private System.Windows.Forms.ContextMenuStrip ctxMnuTreeDOM;
        private System.Windows.Forms.ToolStripMenuItem saveTreeToolStripMenuItem;
    }
}