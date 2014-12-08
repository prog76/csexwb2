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
    /// <summary>
    /// A minimal demonstration of how to use IHTMLEditDesigner interface
    /// via HTMLEditDesigner class to setup an HTML editor.
    /// The number of events that are fired are limited.
    /// </summary>
    public partial class frmHTMLEditor2 : Form
    {
        csExWB.HTMLEditDesigner m_designer = new csExWB.HTMLEditDesigner();

        public frmHTMLEditor2()
        {
            InitializeComponent();
            this.toolStrip1.ItemClicked += new ToolStripItemClickedEventHandler(toolStrip1_ItemClicked);
            this.Load += new EventHandler(frmHTMLEditor2_Load);
            this.FormClosing += new FormClosingEventHandler(frmHTMLEditor2_FormClosing);

            cEXWB1.BeforeNavigate2 += new csExWB.BeforeNavigate2EventHandler(cEXWB1_BeforeNavigate2);
            cEXWB1.DocumentComplete += new csExWB.DocumentCompleteEventHandler(cEXWB1_DocumentComplete);

            m_designer.HTMLEditDesigner_PreHandleEvent += new csExWB.HTMLEditDesignerEventHandler(m_designer_HTMLEditDesigner_PreHandleEvent); 
        }

        void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == newToolStripButton.Name)
                this.cEXWB1.Clear();
        }

        void m_designer_HTMLEditDesigner_PreHandleEvent(object sender, csExWB.HTMLEditDesignerArgs e)
        {
            //Only events that are fired, minimal
            if (e.m_EventDispId == HTMLEventDispIds.ID_ONKEYDOWN)
            {
                if (e.m_pEvtObj != null) //65 A
                    AllForms.m_frmLog.AppendToLog("ID_ONKEYDOWN_KeyCode ==>" + e.m_pEvtObj.keyCode.ToString());
            }
            else if (e.m_EventDispId == HTMLEventDispIds.ID_ONKEYUP) //never hits???
            {
                if (e.m_pEvtObj != null)
                    AllForms.m_frmLog.AppendToLog("ID_ONKEYUP_KeyCode ==>" + e.m_pEvtObj.keyCode.ToString());
            }
            //else if (e.m_EventDispId == HTMLEventDispIds.ID_ONKEYPRESS)
            //{
            //    if (e.m_pEvtObj != null) //97 a
            //        AllForms.m_frmLog.AppendToLog("ID_ONKEYPRESS_KeyCode ==>" + e.m_pEvtObj.keyCode.ToString());
            //}
            else if (e.m_EventDispId == HTMLEventDispIds.ID_ONMOUSEDOWN)
            {
                if ((e.m_pEvtObj != null) && (e.m_pEvtObj.SrcElement != null))
                    AllForms.m_frmLog.AppendToLog("ID_ONMOUSEDOWN_TagName ==>" + e.m_pEvtObj.SrcElement.tagName);
            }
            else if (e.m_EventDispId == HTMLEventDispIds.ID_ONMOUSEUP)
            {
                if ((e.m_pEvtObj != null) && (e.m_pEvtObj.SrcElement != null))
                    AllForms.m_frmLog.AppendToLog("ID_ONMOUSEUP_TagName ==>" + e.m_pEvtObj.SrcElement.tagName);
            }
            else if (e.m_EventDispId == HTMLEventDispIds.ID_ONMOUSEOVER)
            {
                AllForms.m_frmLog.AppendToLog("ID_ONMOUSEOVER");
            }
            else if (e.m_EventDispId == HTMLEventDispIds.ID_ONMOUSEOUT)
            {
                AllForms.m_frmLog.AppendToLog("ID_ONMOUSEOUT");
            }
            else if (e.m_EventDispId == HTMLEventDispIds.ID_ONCONTEXTMENU)
            {
                AllForms.m_frmLog.AppendToLog("ID_ONCONTEXTMENU");
                e.Cancel = true;
            }
            else if (e.m_EventDispId == HTMLEventDispIds.ID_ONMOUSEMOVE)
            {
                return;
            }
            else if (e.m_EventDispId == HTMLEventDispIds.ID_IME_EVENT)
            {
                AllForms.m_frmLog.AppendToLog("ID_IME_EVENT");
            }
            else
                AllForms.m_frmLog.AppendToLog("m_EventDispId ==>" + e.m_EventDispId.ToString());

        }

        void cEXWB1_DocumentComplete(object sender, csExWB.DocumentCompleteEventArgs e)
        {
            try
            {
                IHTMLDocument2 pDoc2 = ((IWebBrowser2)e.browser).Document as IHTMLDocument2;
                if (pDoc2 != null)
                {
                    m_designer.ActivateDesigner(pDoc2);
                }
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog(this.Name + "_cEXWB1_DocumentComplete\r\n" + ee.ToString());
            }
        }

        void cEXWB1_BeforeNavigate2(object sender, csExWB.BeforeNavigate2EventArgs e)
        {
            try
            {
                m_designer.DeactivateDesigner();
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog(this.Name + "_cEXWB1_DocumentComplete\r\n" + ee.ToString());
            }
        }

        void frmHTMLEditor2_Load(object sender, EventArgs e)
        {
            //Initialize webbrowser events
            cEXWB1.NavToBlank();
            //Enter design mode
            this.cEXWB1.SetDesignMode("on");
        }

        void frmHTMLEditor2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}