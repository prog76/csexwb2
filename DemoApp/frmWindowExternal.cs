using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DemoApp
{
    /// <summary>
    /// A simple demo of how to communicate with a page using
    /// ObjectForScripting property of csEXWB control
    /// in combination with window.external property of javascript
    /// </summary>
    public partial class frmWindowExternal : Form
    {
        private WinExternal m_external = new WinExternal();

        public frmWindowExternal()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmWindowExternal_Load);
            this.FormClosing += new FormClosingEventHandler(frmWindowExternal_FormClosing);
            this.StartPosition = FormStartPosition.CenterParent;
            this.cEXWB1.TitleChange += new csExWB.TitleChangeEventHandler(cEXWB1_TitleChange);
        }

        void cEXWB1_TitleChange(object sender, csExWB.TitleChangeEventArgs e)
        {
            this.Text = e.title;
        }

        void frmWindowExternal_Load(object sender, EventArgs e)
        {
            this.cEXWB1.NavToBlank();
        }

        void frmWindowExternal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void frmWindowExternal_Shown(object sender, EventArgs e)
        {
            string source = "<html><head><title>Demo - How to communicate with client using window.external</title>" +
                "<script language=\"javascript\" type=\"text/javascript\">" +
                "function Button1_onclick() {window.external.SaySomething ();}" +
                "function Button2_onclick() {window.external.AMessageFromHome = \"A message from HTML page.\";}" +
                "function Button3_onclick() {alert (window.external.AMessageFromHome);}" +
                "</script>" +
                "</head><body><p>" +
                "<input id=\"Button1\" type=\"button\" value=\"Invoke SaySomething method from WinExternal class.\" onclick=\"return Button1_onclick()\">" +
                "</P><p><br>" +
                "<input id=\"Button3\" type=\"button\" value=\"Display value of AMessageFromHome property of WinExternal class.\" onclick=\"return Button3_onclick()\">" +
                "</P><p><br>" +
                "<input id=\"Button2\" type=\"button\" value=\"Change AMessageFromHome property in WinExternal class!\" onclick=\"return Button2_onclick()\"><br>" +
                "</P></body></html>";
            this.cEXWB1.ObjectForScripting = m_external;
            this.cEXWB1.LoadHtmlIntoBrowser(source);
        }
    }
}