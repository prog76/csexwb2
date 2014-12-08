using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DemoApp
{
    public partial class frmRequestResponseHeaders : Form
    {
        public frmRequestResponseHeaders()
        {
            InitializeComponent();
            this.Text = "HTTP + HTTPS Request Response Headers!";
            this.FormClosing += new FormClosingEventHandler(frmRequestResponseHeaders_FormClosing);
            this.toolStripButtonClear.Click += new EventHandler(toolStripButtonClear_Click);
            this.toolStripButtonClose.Click += new EventHandler(toolStripButtonClose_Click);
            this.toolStripButtonSave.Click += new EventHandler(toolStripButtonSave_Click);
        }

        public void AppendToLog(string Text)
        {
            //richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.AppendText(Environment.NewLine + Text + Environment.NewLine);
            //richTextBox1.SelectionStart = richTextBox1.Text.Length;
        }

        void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (AllForms.ShowStaticSaveDialogForText(this) == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(AllForms.m_dlgSave.FileName))
                {
                    sw.Write(richTextBox1.Text);
                }
            }
        }

        void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            if ((this.Owner != null) && (this.Owner is frmMain))
            {
                ((frmMain)this.Owner).StopAPPs();
            }
            this.Hide();
        }

        void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        void frmRequestResponseHeaders_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                toolStripButtonClose_Click(this, EventArgs.Empty);
            }
        }
    }
}