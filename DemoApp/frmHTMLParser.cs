using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using csExWB;

namespace DemoApp
{
    ///Simple demonstration of HTMLParser class - UI_Less parsing
    ///Using MSHTML document object to parse HTML without GUI
    public partial class frmHTMLParser : Form
    {
        private HTMLParser cparser = new HTMLParser();
        public frmHTMLParser()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(frmHTMLParser_FormClosing);
            this.cparser.HtmlParsingDoneEvent += new HtmlParsingDoneEventHandler(cparser_HtmlParsingDoneEvent);
            this.toolStripButtonParse.Click += new EventHandler(toolStripButtonParse_Click);
        }

        void toolStripButtonParse_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.toolStripComboBoxUrl.Text))
            {
                toolStripButtonParse.Enabled = false;
                this.richTextBox1.Clear();
                this.Cursor = Cursors.WaitCursor;
                //Also can set username, password, and cookie
                cparser.StartParsing(this.toolStripComboBoxUrl.Text, string.Empty);
            }
        }

        void cparser_HtmlParsingDoneEvent(object sender, HtmlParsingDoneEventArg e)
        {
            this.richTextBox1.Text = "HtmlParsingDoneEvent\r\nURL: " + e.MSHTMDocument.url
                + "\r\n" + e.MSHTMDocument.body.outerHTML;
            //Clean up so we can use this object again
            cparser.StopParsing();
            toolStripButtonParse.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        void frmHTMLParser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.richTextBox1.Clear();
                this.Hide();
            }
        }
    }
}