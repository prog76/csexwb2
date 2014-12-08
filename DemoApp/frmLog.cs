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
    public partial class frmLog : Form
    {
        public frmLog()
        {
            InitializeComponent();
        }

        public void AppendToLog(string Text)
        {
            try
            {
                txtLog.SelectionStart = txtLog.Text.Length;
                txtLog.AppendText(Environment.NewLine + Text + Environment.NewLine);
                txtLog.SelectionStart = txtLog.Text.Length;
            }
            catch (Exception)
            {
                txtLog.Text = string.Empty;
            }
        }

        private void tsBtnClear_Click(object sender, EventArgs e)
        {
            txtLog.Text = string.Empty;
        }

        private void frmLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void tsBtnSaveLog_Click(object sender, EventArgs e)
        {
            if (AllForms.ShowStaticSaveDialogForText(this) == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(AllForms.m_dlgSave.FileName))
                {
                    sw.Write(txtLog.Text);
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}