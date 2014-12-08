using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IfacesEnumsStructsClasses;

namespace DemoApp
{
    public partial class frmPopup : Form
    {
        //Able to handle a popup launched from this browser
        private frmPopup newfrm = null;
        public bool isSecondaryPopup = false;

        public frmPopup()
        {
            InitializeComponent();
        }

        public void AssignBrowserObject(ref object obj)
        {
            obj = this.cEXWB1.WebbrowserObject;
        }

        public void PopupNavigate(string Url)
        {
            this.cEXWB1.Navigate(Url);
        }

        private void frmPopup_Load(object sender, EventArgs e)
        {
            this.cEXWB1.RegisterAsBrowser = true;
            this.cEXWB1.WBDragDrop += new csExWB.WBDropEventHandler(cEXWB1_WBDragDrop);
            this.cEXWB1.NavToBlank();
        }

        void cEXWB1_WBDragDrop(object sender, csExWB.WBDropEventArgs e)
        {
            if (e.dataobject.ContainsText())
                AllForms.m_frmLog.AppendToLog("frmPopup_cEXWB1_WBDragDrop\r\n" + e.dataobject.GetText());
            else if (e.dataobject.ContainsFileDropList())
            {
                System.Collections.Specialized.StringCollection files = e.dataobject.GetFileDropList();
                if (files.Count > 1)
                    MessageBox.Show("Can not do multi file drop!");
                else
                {
                    this.cEXWB1.Navigate(files[0]);
                }
            }
        }

        private void frmPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (this.cEXWB1 != null)
                    this.cEXWB1.NavToBlank();
                if (!isSecondaryPopup)
                {
                    e.Cancel = true;
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// Sets the DL flags of the browser to be as restrictive as possible
        /// </summary>
        public void SetupAsSandBox()
        {
            this.cEXWB1.WBDOCDOWNLOADCTLFLAG = (int)(
                DOCDOWNLOADCTLFLAG.NO_SCRIPTS | 
                DOCDOWNLOADCTLFLAG.NO_JAVA | 
                DOCDOWNLOADCTLFLAG.NOFRAMES | 
                DOCDOWNLOADCTLFLAG.NO_DLACTIVEXCTLS | 
                DOCDOWNLOADCTLFLAG.NO_RUNACTIVEXCTLS | 
                DOCDOWNLOADCTLFLAG.PRAGMA_NO_CACHE | 
                DOCDOWNLOADCTLFLAG.SILENT | 
                DOCDOWNLOADCTLFLAG.NO_BEHAVIORS | 
                DOCDOWNLOADCTLFLAG.NO_CLIENTPULL);
        }

        private void cEXWB1_StatusTextChange(object sender, csExWB.StatusTextChangeEventArgs e)
        {
            lblStatus.Text = e.text;
        }

        private void cEXWB1_TitleChange(object sender, csExWB.TitleChangeEventArgs e)
        {
            this.Text = e.title;
        }

        private void cEXWB1_WBDocHostShowUIShowMessage(object sender, csExWB.DocHostShowUIShowMessageEventArgs e)
        {
            AllForms.m_frmLog.AppendToLog("frmPopup_cEXWB1_WBDocHostShowUIShowMessage\r\n" + e.text);
        }

        private void cEXWB1_WindowClosing(object sender, csExWB.WindowClosingEventArgs e)
        {
            this.cEXWB1.NavToBlank();
            //e.Cancel = true;
            this.Hide();
        }

        private void cEXWB1_WindowSetHeight(object sender, csExWB.WindowSetHeightEventArgs e)
        {
            if( (!this.Visible) || (this.WindowState == FormWindowState.Maximized) ||
                (this.WindowState == FormWindowState.Minimized) || (e.height < 0) )
                return;
            this.Height = e.height;
        }

        private void cEXWB1_WindowSetWidth(object sender, csExWB.WindowSetWidthEventArgs e)
        {
            if ((!this.Visible) || (this.WindowState == FormWindowState.Maximized) ||
                (this.WindowState == FormWindowState.Minimized) || (e.width < 0))
                return;
            this.Width = e.width;
        }

        private void cEXWB1_ScriptError(object sender, csExWB.ScriptErrorEventArgs e)
        {
            AllForms.m_frmLog.AppendToLog("frmPopup_cEXWB1_ScriptError");
            e.continueScripts = true;
        }

        private void cEXWB1_NavigateError(object sender, csExWB.NavigateErrorEventArgs e)
        {
            AllForms.m_frmLog.AppendToLog("frmPopup_cEXWB1_NavigateError");
            e.Cancel = true;
        }

        private void SetupNewForm()
        {
            if (newfrm != null)
                return;
            newfrm = new frmPopup();
            newfrm.isSecondaryPopup = true;
            newfrm.Show();
            newfrm.BringToFront();
        }

        private void cEXWB1_NewWindow2(object sender, csExWB.NewWindow2EventArgs e)
        {
            try
            {
                this.SetupNewForm();
                newfrm.AssignBrowserObject(ref e.browser);
                //AllForms.m_frmLog.AppendToLog("frmPopup_cEXWB1_NewWindow2");
                //e.Cancel = true;
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("frmPopup_cEXWB1_NewWindow2\r\n" + ee.ToString());
            }
        }

        private void cEXWB1_NewWindow3(object sender, csExWB.NewWindow3EventArgs e)
        {
            try
            {
                this.SetupNewForm();
                newfrm.AssignBrowserObject(ref e.browser);
                //e.Cancel = true;
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("frmPopup_cEXWB1_NewWindow3\r\n" + ee.ToString());
            }
        }

        private void cEXWB1_WBEvaluteNewWindow(object sender, csExWB.EvaluateNewWindowEventArgs e)
        {
            this.SetupNewForm();
            //e.Cancel = true;
        }
        
        private void cEXWB1_BeforeNavigate2(object sender, csExWB.BeforeNavigate2EventArgs e)
        {
            AllForms.m_frmLog.AppendToLog("frmPopup_BeforeNavigate2\r\n" + e.url);
        }

        private void cEXWB1_WindowSetLeft(object sender, csExWB.WindowSetLeftEventArgs e)
        {
            if ((!this.Visible) || (this.WindowState == FormWindowState.Maximized) ||
                (this.WindowState == FormWindowState.Minimized) || (e.left < 0))
                return;
            this.Left = e.left;
        }

        private void cEXWB1_WindowSetTop(object sender, csExWB.WindowSetTopEventArgs e)
        {
            if ((!this.Visible) || (this.WindowState == FormWindowState.Maximized) ||
                (this.WindowState == FormWindowState.Minimized) || (e.top < 0))
                return;
            this.Top = e.top;
        }

        private void cEXWB1_WBSecurityProblem(object sender, csExWB.SecurityProblemEventArgs e)
        {
            AllForms.m_frmLog.AppendToLog("frmPopup_cEXWB1_WBSecurityProblem\r\n" + e.problem.ToString());
        }


    }
}