namespace DemoApp
{
    partial class frmPopup
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
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.cEXWB1 = new csExWB.cEXWB();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 275);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(452, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(16, 17);
            this.lblStatus.Text = "...";
            // 
            // cEXWB1
            // 
            this.cEXWB1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cEXWB1.Location = new System.Drawing.Point(3, 5);
            this.cEXWB1.LocationUrl = "about:blank";
            this.cEXWB1.Name = "cEXWB1";
            this.cEXWB1.OffLine = false;
            this.cEXWB1.RegisterAsBrowser = false;
            this.cEXWB1.RegisterAsDropTarget = false;
            this.cEXWB1.RegisterForInternalDragDrop = true;
            this.cEXWB1.SendSourceOnDocumentCompleteWBEx = false;
            this.cEXWB1.Silent = false;
            this.cEXWB1.Size = new System.Drawing.Size(447, 263);
            this.cEXWB1.TabIndex = 1;
            this.cEXWB1.Text = "cEXWB1";
            this.cEXWB1.TextSize = IfacesEnumsStructsClasses.TextSizeWB.Medium;
            this.cEXWB1.WBDOCDOWNLOADCTLFLAG = 112;
            this.cEXWB1.WBDOCHOSTUIDBLCLK = IfacesEnumsStructsClasses.DOCHOSTUIDBLCLK.DEFAULT;
            this.cEXWB1.WBDOCHOSTUIFLAG = 262276;
            this.cEXWB1.WindowSetWidth += new csExWB.WindowSetWidthEventHandler(this.cEXWB1_WindowSetWidth);
            this.cEXWB1.WBEvaluteNewWindow += new csExWB.EvaluateNewWindowEventHandler(this.cEXWB1_WBEvaluteNewWindow);
            this.cEXWB1.BeforeNavigate2 += new csExWB.BeforeNavigate2EventHandler(this.cEXWB1_BeforeNavigate2);
            this.cEXWB1.NavigateError += new csExWB.NavigateErrorEventHandler(this.cEXWB1_NavigateError);
            this.cEXWB1.WindowSetTop += new csExWB.WindowSetTopEventHandler(this.cEXWB1_WindowSetTop);
            this.cEXWB1.ScriptError += new csExWB.ScriptErrorEventHandler(this.cEXWB1_ScriptError);
            this.cEXWB1.StatusTextChange += new csExWB.StatusTextChangeEventHandler(this.cEXWB1_StatusTextChange);
            this.cEXWB1.TitleChange += new csExWB.TitleChangeEventHandler(this.cEXWB1_TitleChange);
            this.cEXWB1.WindowSetLeft += new csExWB.WindowSetLeftEventHandler(this.cEXWB1_WindowSetLeft);
            this.cEXWB1.WBSecurityProblem += new csExWB.SecurityProblemEventHandler(this.cEXWB1_WBSecurityProblem);
            this.cEXWB1.WindowSetHeight += new csExWB.WindowSetHeightEventHandler(this.cEXWB1_WindowSetHeight);
            this.cEXWB1.NewWindow2 += new csExWB.NewWindow2EventHandler(this.cEXWB1_NewWindow2);
            this.cEXWB1.NewWindow3 += new csExWB.NewWindow3EventHandler(this.cEXWB1_NewWindow3);
            this.cEXWB1.WindowClosing += new csExWB.WindowClosingEventHandler(this.cEXWB1_WindowClosing);
            this.cEXWB1.WBDocHostShowUIShowMessage += new csExWB.DocHostShowUIShowMessageEventHandler(this.cEXWB1_WBDocHostShowUIShowMessage);
            // 
            // frmPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 297);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cEXWB1);
            this.Name = "frmPopup";
            this.Text = "frmPopup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPopup_FormClosing);
            this.Load += new System.EventHandler(this.frmPopup_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private csExWB.cEXWB cEXWB1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}