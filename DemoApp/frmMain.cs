using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web;
using IfacesEnumsStructsClasses;
using System.IO;

namespace DemoApp
{

    /// <summary>
    /// A multi tab/thumb simulated webbrowser control which
    /// demonstrates the usage of csEXWB control with some extras.
    /// 
    /// The demo pretty much covers all the basics and most of the advanced
    /// functionality that the control offers. It also includes a complete DOM
    /// viewer which works independent of the control, cache and cookie explorers, thumb navigation,
    /// document information viewer, loading and displaying favorites in dynamic
    /// menu, Popup, authentication and find handlers,
    /// a functional HTML editor, ....
    /// 
    /// A bit of details:
    /// In the frmMain, each browser has a corresponding toolstripbutton
    /// acting as a tab and a menu item for tab switching which displays
    /// number of open tabs as well.
    /// 
    /// The name of all the webbrowser corresponding controls are identical!
    /// All use the webbrowser instance Name.
    /// Any new browser can be deleted but the first one which was placed
    /// on the form in design time. Kept for making things a bit easier!
    /// 
    /// The rest is a matter of synchronizing addition, removal, and switching
    /// among webbrowser instances. Simple enough.
    /// 
    /// All the images used in this project 
    /// are coming from IeToolbar.bmp image strip. They are loade in 
    /// SetupImages() method into a static imagelist
    /// which then is shared by all project forms and controls.
    /// 
    /// 
    /// To Test InvokeScript
    /// Add this code to onclick event of a control called tsBtn
    /// <code>
    /// if (tsBtn.Tag == null) //First click, loads the script into browser
    /// {
    ///     tsBtn.Tag = 1;
    ///     string html = "<HTML><HEAD><SCRIPT language=\"Jscript\">function InvokeMethod (str){ myDiv.innerHTML = \"<font size=8>\" + str + \"</font>\";}</Script></Head><Body><H2>Call from App via InvokeScript</h2><div id=\"myDiv\" style=\"font-size: 100%; vertical-align: middle; width: 100%; direction: ltr; font-family: Fantasy, Sans-Serif, Serif; height: 200px; text-align: center\"></div></Body></HTML>";
    ///     m_CurWB.LoadHtmlIntoBrowser(html, "http://www.dummy.com");
    /// }
    /// else //Second click invoke script
    /// {
    ///     tsBtn.Tag = null;
    ///     m_CurWB.InvokeScript("InvokeMethod", new object[] { "Nice !" });
    /// }
    /// </code>
    /// </summary>
    public partial class frmMain : Form
    {
        #region Local Variables

        private const string m_AboutBlank = "about:blank";
        private const string m_Blank = "Blank";
        private csExWB.cEXWB m_CurWB = null; //Current WB
        private int m_iCurTab = 0; //Current Tab index
        private int m_iCurMenu = 0; //Current WB count menu
        private int m_iCountWB = 1; //WB Count
        private const int m_MaxTextLen = 15; //Maimum len of text displayed in tabs,...
        private ToolStripButton m_tsBtnFirstTab = null; //for reference
        //For reference when rClicked on a toolstripbutton
        private ToolStripButton m_tsBtnctxMnu = null; 
        //Is used in browser context menu event to hold a ref
        //to the HTML element under the mouse
        private object m_oHTMLCtxMenu = null;
        //To capture file download name in FileDownload event
        //private string m_Status = string.Empty;

        //private PictureBox m_thumbPic = new PictureBox();
        //private ToolStripDropDown m_thumbPopup = new ToolStripDropDown();

        //Images for statusbar, ....
        private Image m_imgLock = null;
        private Image m_imgUnLock = null;
        private Image m_BlankImage = null;

        //Forms
        private frmPopup m_frmPopup = new frmPopup();
        private frmFind m_frmFind = new frmFind();
        private frmCacheCookie m_frmCacheCookie = new frmCacheCookie();
        private frmDOM m_frmDOM = new frmDOM();
        private frmDocInfo m_frmDocInfo = new frmDocInfo();
        private frmAuthenticate m_frmAuth = new frmAuthenticate();
        private frmHTMLeditor m_frmHTMLEditor = new frmHTMLeditor();
        private frmFileDownload m_frmFileDownload = new frmFileDownload();
        private frmRequestResponseHeaders m_frmRequestResponseHeaders = new frmRequestResponseHeaders();

        private frmHTMLDialogHandler m_HtmlDlgHandler = new frmHTMLDialogHandler();
        private frmWindowExternal m_frmWindowExternal = new frmWindowExternal();
        private frmAutomation m_frmAutomation = null;
        private frmHTMLParser m_frmHTMLParser = new frmHTMLParser();

        #endregion

        #region Form Events

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                mainToolStripMenuItem.Visible = false;
                SetupImages();

                //Restricted
                //this.cEXWB1.WBDOCDOWNLOADCTLFLAG = (int)(DOCDOWNLOADCTLFLAG.NO_DLACTIVEXCTLS |
                //DOCDOWNLOADCTLFLAG.NO_FRAMEDOWNLOAD | DOCDOWNLOADCTLFLAG.NO_JAVA |
                //DOCDOWNLOADCTLFLAG.NO_RUNACTIVEXCTLS | DOCDOWNLOADCTLFLAG.NO_SCRIPTS |
                //DOCDOWNLOADCTLFLAG.NOFRAMES | DOCDOWNLOADCTLFLAG.PRAGMA_NO_CACHE |
                //DOCDOWNLOADCTLFLAG.NO_BEHAVIORS | DOCDOWNLOADCTLFLAG.NO_CLIENTPULL |
                //DOCDOWNLOADCTLFLAG.SILENT);

            //    //To activate autocomplete
            //    this.cEXWB1.WBDOCHOSTUIFLAG = (int)(DOCHOSTUIFLAG.NO3DBORDER |
            //DOCHOSTUIFLAG.FLAT_SCROLLBAR | DOCHOSTUIFLAG.THEME |
            //DOCHOSTUIFLAG.ENABLE_FORMS_AUTOCOMPLETE);

                this.cEXWB1.DownloadComplete += new csExWB.DownloadCompleteEventHandler(this.cEXWB1_DownloadComplete);
                this.cEXWB1.DocumentComplete += new csExWB.DocumentCompleteEventHandler(this.cEXWB1_DocumentComplete);
                this.cEXWB1.TitleChange += new csExWB.TitleChangeEventHandler(this.cEXWB1_TitleChange);
                this.cEXWB1.NewWindow2 += new csExWB.NewWindow2EventHandler(this.cEXWB1_NewWindow2);
                this.cEXWB1.ScriptError += new csExWB.ScriptErrorEventHandler(this.cEXWB1_ScriptError);
                this.cEXWB1.WBKeyDown += new csExWB.WBKeyDownEventHandler(this.cEXWB1_WBKeyDown);
                this.cEXWB1.WindowClosing += new csExWB.WindowClosingEventHandler(this.cEXWB1_WindowClosing);
                this.cEXWB1.DocumentCompleteEX += new csExWB.DocumentCompleteExEventHandler(this.cEXWB1_DocumentCompleteEX);
                this.cEXWB1.NewWindow3 += new csExWB.NewWindow3EventHandler(this.cEXWB1_NewWindow3);
                this.cEXWB1.WBSecurityProblem += new csExWB.SecurityProblemEventHandler(this.cEXWB1_WBSecurityProblem);
                this.cEXWB1.WBKeyUp += new csExWB.WBKeyUpEventHandler(this.cEXWB1_WBKeyUp);
                this.cEXWB1.WBContextMenu += new csExWB.ContextMenuEventHandler(this.cEXWB1_WBContextMenu);
                this.cEXWB1.FileDownload += new csExWB.FileDownloadEventHandler(this.cEXWB1_FileDownload);
                this.cEXWB1.StatusTextChange += new csExWB.StatusTextChangeEventHandler(this.cEXWB1_StatusTextChange);
                this.cEXWB1.WBDragDrop += new csExWB.WBDropEventHandler(this.cEXWB1_WBDragDrop);
                this.cEXWB1.WBDocHostShowUIShowMessage += new csExWB.DocHostShowUIShowMessageEventHandler(this.cEXWB1_WBDocHostShowUIShowMessage);
                this.cEXWB1.ProtocolHandlerOnResponse += new csExWB.ProtocolHandlerOnResponseEventHandler(this.cEXWB1_ProtocolHandlerOnResponse);
                this.cEXWB1.SetSecureLockIcon += new csExWB.SetSecureLockIconEventHandler(this.cEXWB1_SetSecureLockIcon);
                this.cEXWB1.DownloadBegin += new csExWB.DownloadBeginEventHandler(this.cEXWB1_DownloadBegin);
                this.cEXWB1.NavigateComplete2 += new csExWB.NavigateComplete2EventHandler(this.cEXWB1_NavigateComplete2);
                this.cEXWB1.WBEvaluteNewWindow += new csExWB.EvaluateNewWindowEventHandler(this.cEXWB1_WBEvaluteNewWindow);
                this.cEXWB1.WBAuthenticate += new csExWB.AuthenticateEventHandler(this.cEXWB1_WBAuthenticate);
                this.cEXWB1.RefreshEnd += new csExWB.RefreshEndEventHandler(this.cEXWB1_RefreshEnd);
                this.cEXWB1.NavigateError += new csExWB.NavigateErrorEventHandler(this.cEXWB1_NavigateError);
                this.cEXWB1.BeforeNavigate2 += new csExWB.BeforeNavigate2EventHandler(this.cEXWB1_BeforeNavigate2);
                this.cEXWB1.RefreshBegin += new csExWB.RefreshBeginEventHandler(this.cEXWB1_RefreshBegin);
                this.cEXWB1.HTMLEvent += new csExWB.HTMLEventHandler(this.cEXWB1_HTMLEvent);
                this.cEXWB1.CommandStateChange += new csExWB.CommandStateChangeEventHandler(this.cEXWB1_CommandStateChange);
                this.cEXWB1.ProgressChange += new csExWB.ProgressChangeEventHandler(this.cEXWB1_ProgressChange);
                this.cEXWB1.FileDownloadExStart += new csExWB.FileDownloadExEventHandler(this.cEXWB1_FileDownloadExStart);
                this.cEXWB1.FileDownloadExEnd += new csExWB.FileDownloadExEndEventHandler(this.cEXWB1_FileDownloadExEnd);
                this.cEXWB1.FileDownloadExProgress += new csExWB.FileDownloadExProgressEventHandler(this.cEXWB1_FileDownloadExProgress);
                this.cEXWB1.FileDownloadExError += new csExWB.FileDownloadExErrorEventHandler(this.cEXWB1_FileDownloadExError);
                this.cEXWB1.FileDownloadExAuthenticate += new csExWB.FileDownloadExAuthenticateEventHandler(this.cEXWB1_FileDownloadExAuthenticate);
                this.cEXWB1.ProtocolHandlerOnBeginTransaction += new csExWB.ProtocolHandlerOnBeginTransactionEventHandler(this.cEXWB1_ProtocolHandlerOnBeginTransaction);
                this.cEXWB1.ProtocolHandlerOnResponse += new csExWB.ProtocolHandlerOnResponseEventHandler(this.cEXWB1_ProtocolHandlerOnResponse);
                cEXWB1.RegisterAsBrowser = true;
                cEXWB1.FileDownloadDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + System.IO.Path.DirectorySeparatorChar.ToString();

                //Add first tab
                string sname = cEXWB1.Name;
                m_tsBtnFirstTab = new ToolStripButton();
                m_tsBtnFirstTab.ImageScaling = ToolStripItemImageScaling.None;
                m_tsBtnFirstTab.ImageAlign = ContentAlignment.MiddleCenter;
                m_tsBtnFirstTab.TextAlign = ContentAlignment.TopLeft;
                m_tsBtnFirstTab.TextImageRelation = TextImageRelation.TextAboveImage;
                m_tsBtnFirstTab.Name = sname;
                m_tsBtnFirstTab.Text = m_Blank;
                m_tsBtnFirstTab.Image = m_BlankImage;
                m_tsBtnFirstTab.ToolTipText = m_AboutBlank;
                m_tsBtnFirstTab.Checked = true;
                m_tsBtnFirstTab.MouseUp += new MouseEventHandler(this.tsWBTabs_ToolStripButtonCtxMenuHandler);

                tsWBTabs.Items.Add((ToolStripItem)m_tsBtnFirstTab);
                //Take note of current WB and first toolstripbutton index
                m_CurWB = cEXWB1;
                m_iCurTab = tsWBTabs.Items.Count - 1;
                //Add menu
                ToolStripMenuItem menu = new ToolStripMenuItem(m_Blank, m_imgUnLock);
                menu.Name = sname;
                menu.Checked = true;
                ctxMnuOpenWBs.Items.Add((ToolStripItem)menu);
                m_iCurMenu = ctxMnuOpenWBs.Items.Count - 1;

                m_frmFind.Icon = AllForms.BitmapToIcon(30);
                //form find callback
                m_frmFind.FindInPageEvent += new FindInPage(m_frmFind_FindInPageEvent);
                
                //Start watching favorites folder
                fswFavorites.Path = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);

                //Load favorites
                LoadFavoriteMenuItems();

                //Fill up the screen
                this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ee)
            {
                MessageBox.Show("frmMain_Load Failed\r\n" + ee.ToString());
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if( (e.CloseReason == CloseReason.ApplicationExitCall)
                || (e.CloseReason == CloseReason.UserClosing) )
            {
                if (!AllForms.AskForConfirmation("Proceed to exit application?", this))
                {
                    e.Cancel = true;
                    //Refocus
                    try
                    {
                        if (m_CurWB != null)
                            m_CurWB.SetFocus();
                    }
                    catch (Exception ee)
                    {
                        AllForms.m_frmLog.AppendToLog("frmMain_FormClosing\r\n" + ee.ToString());
                    }
                }
            }
        }

        #endregion

        #region Local methods

        /// <summary>
        /// Called from HTML Editor in response to loading
        /// current browser contents into the HTML Editor
        /// </summary>
        public csExWB.cEXWB CurrentBrowserControl
        {
            get
            {
                return m_CurWB;
            }
        }

        private bool CheckWBPointer()
        {
            return (m_CurWB == null) ? false : true;
        }

        private csExWB.cEXWB FindBrowser(string name)
        {
            try
            {
                foreach (Control ctl in this.toolStripContainer1.ContentPanel.Controls)
                {
                    if (ctl.Name == name)
                    {
                        if (ctl is csExWB.cEXWB)
                            return (csExWB.cEXWB)ctl;
                    }
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        private ToolStripButton FindTab(string name)
        {
            try
            {
                foreach (ToolStripItem item in tsWBTabs.Items)
                {
                    if (item.Name == name)
                    {
                        if (item is ToolStripButton)
                            return (ToolStripButton)item;
                    }
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        private ToolStripMenuItem FindWBMenu(string name)
        {
            foreach (ToolStripItem item in ctxMnuOpenWBs.Items)
            {
                if (item.Name == name)
                {
                    if (item is ToolStripMenuItem)
                        return (ToolStripMenuItem)item;
                }
            }
            return null;
        }

        private bool AddNewBrowser(string TabText, string TabTooltip, string Url, bool BringToFront)
        {
            //Copy flags
            int iDochostUIFlag = (int)(DOCHOSTUIFLAG.NO3DBORDER |
                        DOCHOSTUIFLAG.FLAT_SCROLLBAR | DOCHOSTUIFLAG.THEME);
            int iDocDlCltFlag = (int)(DOCDOWNLOADCTLFLAG.DLIMAGES |
                        DOCDOWNLOADCTLFLAG.BGSOUNDS | DOCDOWNLOADCTLFLAG.VIDEOS);

            if (m_CurWB != null)
            {
                iDochostUIFlag = m_CurWB.WBDOCHOSTUIFLAG;
                iDocDlCltFlag = m_CurWB.WBDOCDOWNLOADCTLFLAG;
            }

            csExWB.cEXWB pWB = null;
            
            int i = m_iCountWB + 1;
            string sname = "cEXWB" + i.ToString();

            try
            {
                ToolStripButton btn = new ToolStripButton();
                btn.ImageAlign = ContentAlignment.MiddleCenter;
                btn.ImageScaling = ToolStripItemImageScaling.None;
                btn.TextAlign = ContentAlignment.TopLeft;
                btn.TextImageRelation = TextImageRelation.TextAboveImage;
                btn.Name = sname;
                if (TabText.Length > 0)
                    btn.Text = TabText;
                else
                    btn.Text = m_Blank;
                btn.Image = m_BlankImage;
                if (TabTooltip.Length > 0)
                    btn.ToolTipText = TabTooltip;
                btn.AutoToolTip = true;
                btn.MouseUp += new MouseEventHandler(this.tsWBTabs_ToolStripButtonCtxMenuHandler);
                tsWBTabs.Items.Add(btn);

                //Create and setup browser
                pWB = new csExWB.cEXWB();

                //pWB.Dock = cEXWB1.Dock;
                pWB.Anchor = cEXWB1.Anchor;
                pWB.Name = sname;
                pWB.Location = cEXWB1.Location;
                pWB.Size = cEXWB1.Size;

                pWB.RegisterAsBrowser = true;
                pWB.WBDOCDOWNLOADCTLFLAG = iDocDlCltFlag;
                pWB.WBDOCHOSTUIFLAG = iDochostUIFlag;
                pWB.FileDownloadDirectory = cEXWB1.FileDownloadDirectory;

                //Add events, using the same eventhandlers for all browsers
                pWB.TitleChange += new csExWB.TitleChangeEventHandler(this.cEXWB1_TitleChange);
                pWB.StatusTextChange += new csExWB.StatusTextChangeEventHandler(this.cEXWB1_StatusTextChange);
                pWB.CommandStateChange += new csExWB.CommandStateChangeEventHandler(this.cEXWB1_CommandStateChange);
                pWB.WBKeyDown += new csExWB.WBKeyDownEventHandler(this.cEXWB1_WBKeyDown);
                pWB.WBEvaluteNewWindow += new csExWB.EvaluateNewWindowEventHandler(this.cEXWB1_WBEvaluteNewWindow);
                pWB.BeforeNavigate2 += new csExWB.BeforeNavigate2EventHandler(this.cEXWB1_BeforeNavigate2);
                pWB.ProgressChange += new csExWB.ProgressChangeEventHandler(this.cEXWB1_ProgressChange);
                pWB.NavigateComplete2 += new csExWB.NavigateComplete2EventHandler(this.cEXWB1_NavigateComplete2);
                pWB.HTMLEvent += new csExWB.HTMLEventHandler(this.cEXWB1_HTMLEvent);
                pWB.DownloadBegin += new csExWB.DownloadBeginEventHandler(this.cEXWB1_DownloadBegin);
                pWB.ScriptError += new csExWB.ScriptErrorEventHandler(this.cEXWB1_ScriptError);
                pWB.DownloadComplete += new csExWB.DownloadCompleteEventHandler(this.cEXWB1_DownloadComplete);
                pWB.StatusTextChange += new csExWB.StatusTextChangeEventHandler(this.cEXWB1_StatusTextChange);
                pWB.DocumentCompleteEX += new csExWB.DocumentCompleteExEventHandler(this.cEXWB1_DocumentCompleteEX);
                pWB.WBDragDrop += new csExWB.WBDropEventHandler(cEXWB1_WBDragDrop);
                pWB.SetSecureLockIcon += new csExWB.SetSecureLockIconEventHandler(this.cEXWB1_SetSecureLockIcon);
                pWB.NavigateError += new csExWB.NavigateErrorEventHandler(this.cEXWB1_NavigateError);
                pWB.WBSecurityProblem += new csExWB.SecurityProblemEventHandler(this.cEXWB1_WBSecurityProblem);
                pWB.NewWindow2 += new csExWB.NewWindow2EventHandler(this.cEXWB1_NewWindow2);
                pWB.DocumentComplete += new csExWB.DocumentCompleteEventHandler(this.cEXWB1_DocumentComplete);
                pWB.NewWindow3 += new csExWB.NewWindow3EventHandler(this.cEXWB1_NewWindow3);
                pWB.WBKeyUp += new csExWB.WBKeyUpEventHandler(this.cEXWB1_WBKeyUp);
                pWB.WindowClosing += new csExWB.WindowClosingEventHandler(this.cEXWB1_WindowClosing);
                pWB.WBContextMenu += new csExWB.ContextMenuEventHandler(this.cEXWB1_WBContextMenu);
                pWB.WBDocHostShowUIShowMessage += new csExWB.DocHostShowUIShowMessageEventHandler(this.cEXWB1_WBDocHostShowUIShowMessage);
                pWB.FileDownload += new csExWB.FileDownloadEventHandler(this.cEXWB1_FileDownload);
                pWB.WBAuthenticate += new csExWB.AuthenticateEventHandler(this.cEXWB1_WBAuthenticate);
                
                pWB.FileDownloadExStart += new csExWB.FileDownloadExEventHandler(cEXWB1_FileDownloadExStart);
                pWB.FileDownloadExEnd += new csExWB.FileDownloadExEndEventHandler(cEXWB1_FileDownloadExEnd);
                pWB.FileDownloadExProgress += new csExWB.FileDownloadExProgressEventHandler(cEXWB1_FileDownloadExProgress);
                pWB.FileDownloadExError += new csExWB.FileDownloadExErrorEventHandler(cEXWB1_FileDownloadExError);
                pWB.FileDownloadExAuthenticate += new csExWB.FileDownloadExAuthenticateEventHandler(cEXWB1_FileDownloadExAuthenticate);

                pWB.ProtocolHandlerOnBeginTransaction += new csExWB.ProtocolHandlerOnBeginTransactionEventHandler(cEXWB1_ProtocolHandlerOnBeginTransaction);
                pWB.ProtocolHandlerOnResponse += new csExWB.ProtocolHandlerOnResponseEventHandler(cEXWB1_ProtocolHandlerOnResponse);
                pWB.RegisterAsBrowser = true;

                //Add to controls collection
                //this.Controls.Add(pWB);
                this.toolStripContainer1.ContentPanel.Controls.Add(pWB);

                ToolStripMenuItem menu = new ToolStripMenuItem(btn.Text, m_imgUnLock);
                menu.Name = sname;
                ctxMnuOpenWBs.Items.Add((ToolStripItem)menu);

                if (BringToFront)
                {
                    //Uncheck last tab
                    ((ToolStripButton)tsWBTabs.Items[m_iCurTab]).Checked = false;
                    btn.Checked = true;

                    ((ToolStripMenuItem)ctxMnuOpenWBs.Items[m_iCurMenu]).Checked = false;
                    m_iCurMenu = ctxMnuOpenWBs.Items.Count - 1;
                    menu.Checked = true;

                    //Adjust current browser pointer
                    m_CurWB = pWB;
                    //Adjust current tab index
                    m_iCurTab = tsWBTabs.Items.Count - 1;
                    //Reset and hide progressbar
                    tsProgress.Value = 0;
                    tsProgress.Maximum = 0;
                    tsProgress.Visible = false;
                    //Bring to front
                    pWB.BringToFront();
                }
                //Increase count
                m_iCountWB++;
                tsBtnOpenWBs.Text = m_iCountWB.ToString() + " open tab(s)";

                if (Url.Length > 0)
                    pWB.Navigate(Url);
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("AddNewBrowser\r\n" + ee.ToString());
                return false;
            }

            return true;
        }

        /// <summary>
        /// Removes an inactive browser without switching to another
        /// </summary>
        /// <param name="name"></param>
        /// <param name="RemoveMenu">true, removes corresponding menu item</param>
        /// <returns></returns>
        private bool RemoveBrowser2(string name, bool RemoveMenu)
        {
            try
            {
                //Do not remove the first browser          
                if ((m_iCountWB == 1) || (name == m_tsBtnFirstTab.Name))
                    return false;

                csExWB.cEXWB pWB = FindBrowser(name);
                //Controls.Remove(pWB);
                this.toolStripContainer1.ContentPanel.Controls.Remove(pWB);
                
                pWB.Dispose();
                pWB = null;

                ToolStripButton btn = FindTab(name);
                tsWBTabs.Items.Remove((ToolStripItem)btn);
                btn.Dispose();
                btn = null;

                if (RemoveMenu)
                {
                    ToolStripMenuItem menu = FindWBMenu(name);
                    ctxMnuOpenWBs.Items.Remove((ToolStripItem)menu);
                    menu.Dispose();
                    menu = null;
                }

                m_iCountWB--;
                tsBtnOpenWBs.Text = m_iCountWB.ToString() + " open tab(s)";
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("RemoveBrowser2\r\n" + ee.ToString());
            }
            return true;
        }

        /// <summary>
        /// Removes the current browser and switches to the one before it
        /// if one is available, else the first one is selected
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool RemoveBrowser(string name)
        {
            bool bRet = false;

            //Do not remove the first browser          
            if ((m_iCountWB == 1) || (name == m_tsBtnFirstTab.Name))
                return bRet;

            tsProgress.Value = 0;
            tsProgress.Maximum = 0;
            tsProgress.Visible = false;

            ToolStripButton btn = FindTab(name);
            ToolStripButton nexttab = null;
            try
            {
                //find the first available btn before this one and switch
                foreach (ToolStripItem item in tsWBTabs.Items)
                {
                    if (item.Name == btn.Name)
                    {
                        break;
                    }
                    if (item is ToolStripButton)
                        nexttab = (ToolStripButton)item;
                }
            }
            catch (Exception ERemoveBrowser)
            {
                AllForms.m_frmLog.AppendToLog("RemoveBrowser\r\n" + ERemoveBrowser.ToString());
            }

            try
            {
                tsWBTabs.Items.Remove((ToolStripItem)btn);
                btn.Dispose();
                btn = null;
            }
            catch (Exception ERemoveBrowser1)
            {
                AllForms.m_frmLog.AppendToLog("RemoveBrowser1\r\n" + ERemoveBrowser1.ToString());
            }

            try
            {
                csExWB.cEXWB pWB = FindBrowser(name);
                //Controls.Remove(pWB);
                this.toolStripContainer1.ContentPanel.Controls.Remove(pWB);
                pWB.Dispose();
                pWB = null;
            }
            catch (Exception ERemoveBrowser2)
            {
                AllForms.m_frmLog.AppendToLog("RemoveBrowser2\r\n" + ERemoveBrowser2.ToString());
            }

            ToolStripMenuItem menu = FindWBMenu(name);
            ToolStripMenuItem nextmenu = null;

            try
            {
                foreach (ToolStripItem titem in ctxMnuOpenWBs.Items)
                {
                    if (titem.Name == menu.Name)
                    {
                        break;
                    }
                    if (titem is ToolStripMenuItem)
                        nextmenu = (ToolStripMenuItem)titem;
                }
                ctxMnuOpenWBs.Items.Remove((ToolStripItem)menu);
                menu.Dispose();
                menu = null;
            }
            catch (Exception ERemoveBrowser3)
            {
                AllForms.m_frmLog.AppendToLog("RemoveBrowser3\r\n" + ERemoveBrowser3.ToString());
            }

            try
            {
                if (nexttab == null)
                {
                    m_CurWB = cEXWB1;
                    m_iCurTab = tsWBTabs.Items.IndexOf((ToolStripItem)m_tsBtnFirstTab);
                    m_iCurMenu = 0;
                    nexttab = m_tsBtnFirstTab;
                }
                else
                {
                    m_CurWB = FindBrowser(nexttab.Name);
                    m_iCurTab = tsWBTabs.Items.IndexOf((ToolStripItem)nexttab);
                    m_iCurMenu = ctxMnuOpenWBs.Items.IndexOf((ToolStripItem)nextmenu);
                }

                this.Text = m_CurWB.GetTitle(true);
                if (this.Text.Length == 0)
                    this.Text = m_Blank;
                this.comboURL.Text = nexttab.ToolTipText;
                nexttab.Checked = true;
                nextmenu.Checked = true;
                m_CurWB.BringToFront();

                m_CurWB.SetFocus();

            }
            catch (Exception ERemoveBrowser4)
            {
                AllForms.m_frmLog.AppendToLog("RemoveBrowser4\r\n" + ERemoveBrowser4.ToString());
            }

            m_iCountWB--;
            tsBtnOpenWBs.Text = m_iCountWB.ToString() + " open tab(s)";

            return bRet;
        }

        private void SwitchTabs(string name, ToolStripButton btn)
        {
            try
            {
                csExWB.cEXWB pWB = FindBrowser(name);
                if (pWB == null)
                    return;

                //Uncheck last one
                if (m_iCountWB > 1)
                    ((ToolStripButton)tsWBTabs.Items[m_iCurTab]).Checked = false;
                m_iCurTab = tsWBTabs.Items.IndexOf(btn);

                m_CurWB = pWB;
                tsBtnBack.Enabled = m_CurWB.CanGoBack;
                tsBtnForward.Enabled = m_CurWB.CanGoForward;
                m_CurWB.BringToFront();
                m_CurWB.SetFocus();
                this.Text = m_CurWB.GetTitle(true);
                if (this.Text.Length == 0)
                    this.Text = m_Blank;
                if (btn != null)
                {
                    btn.Checked = true;
                    btn.Text = this.Text;
                    if (btn.Text.Length > m_MaxTextLen)
                        btn.Text = btn.Text.Substring(0, m_MaxTextLen) + "...";
                    btn.ToolTipText = HttpUtility.UrlDecode(m_CurWB.LocationUrl);
                    this.comboURL.Text = btn.ToolTipText;
                }

                //Uncheck all menu items first
                foreach (ToolStripItem item in ctxMnuOpenWBs.Items)
                {
                    if (item is ToolStripMenuItem)
                        ((ToolStripMenuItem)item).Checked = false;
                }
                //Find target menu item
                ToolStripMenuItem menu = FindWBMenu(name);
                m_iCurMenu = ctxMnuOpenWBs.Items.IndexOf((ToolStripItem)menu);
                if (menu != null)
                {
                    if (btn != null)
                        menu.Text = btn.Text;
                    menu.Checked = true;
                }
                //Reset and hide progressbar
                //If page is in the process of loading then the progressbar
                //will be adjusted
                tsProgress.Value = 0;
                tsProgress.Maximum = 0;
                tsProgress.Visible = false;

                //update SecureLockIcon state
                UpdateSecureLockIcon(m_CurWB.SecureLockIcon);
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("SwitchingTabs\r\n" + ee.ToString());
            }

        }

        private void UpdateSecureLockIcon(SecureLockIconConstants slic)
        {
            if (slic == SecureLockIconConstants.secureLockIconUnsecure)
            {
                tsSecurity.Image = m_imgUnLock;
                this.tsSecurity.Text = "Not Secure";
            }
            else if (slic == SecureLockIconConstants.secureLockIcon128Bit)
            {
                tsSecurity.Image = m_imgLock;
                this.tsSecurity.Text = "128 Bit";
            }
            else if (slic == SecureLockIconConstants.secureLockIcon40Bit)
            {
                tsSecurity.Image = m_imgLock;
                this.tsSecurity.Text = "40 Bit";
            }
            else if (slic == SecureLockIconConstants.secureLockIcon56Bit)
            {
                tsSecurity.Image = m_imgLock;
                this.tsSecurity.Text = "56 Bit";
            }
            else if (slic == SecureLockIconConstants.secureLockIconFortezza)
            {
                tsSecurity.Image = m_imgLock;
                this.tsSecurity.Text = "Fortezza";
            }
            else if (slic == SecureLockIconConstants.secureLockIconMixed)
            {
                tsSecurity.Image = m_imgUnLock;
                this.tsSecurity.Text = "Mixed";
            }
            else if (slic == SecureLockIconConstants.secureLockIconUnknownBits)
            {
                tsSecurity.Image = m_imgUnLock;
                this.tsSecurity.Text = "UnknownBits";
            }
        }

        /// <summary>
        /// Loads all images from a image strip into a
        /// static imagelist which in turn can 
        /// be used bey any form or control 
        /// capable of using images
        /// </summary>
        private void SetupImages()
        {
            try
            {
                //string[] str = this.GetType().Assembly.GetManifestResourceNames();
                //foreach (string s in str)
                //{
                //    System.Diagnostics.Debug.Print(s);
                //}
                //DemoApp.Properties.Resources.resources
                //DemoApp.frmPopup.resources
                //DemoApp.frmMain.resources
                //DemoApp.Resources.IeToolbar.bmp
                //....

                System.IO.Stream file2 =
                    this.GetType().Assembly.GetManifestResourceStream("DemoApp.Resources.blank.gif");
                m_BlankImage = Image.FromStream(file2);

                System.IO.Stream file =
                    this.GetType().Assembly.GetManifestResourceStream("DemoApp.Resources.IeToolbar.bmp");
                Image img = Image.FromStream(file);

                AllForms.m_imgListMain.TransparentColor = Color.FromArgb(192, 192, 192);
                AllForms.m_imgListMain.Images.AddStrip(img);

                tsBtnBack.Image = AllForms.m_imgListMain.Images[0];
                tsBtnForward.Image = AllForms.m_imgListMain.Images[1];
                tsBtnStop.Image = AllForms.m_imgListMain.Images[2];
                tsBtnRefresh.Image = AllForms.m_imgListMain.Images[4];
                tsSplitBtnSearch.Image = AllForms.m_imgListMain.Images[30];
                tsBtnGo.Image = AllForms.m_imgListMain.Images[10];
                tsChkBtnGo.Image = AllForms.m_imgListMain.Images[18];

                tsBtnOpenWBs.Image = AllForms.m_imgListMain.Images[12];
                tsBtnAddWB.Image = AllForms.m_imgListMain.Images[16];
                tsChkBtnAddWB.Image = AllForms.m_imgListMain.Images[18];
                tsBtnRemoveWB.Image = AllForms.m_imgListMain.Images[39];
                tsBtnRemoveAllWBs.Image = AllForms.m_imgListMain.Images[40];

                m_imgLock = AllForms.m_imgListMain.Images[13];
                m_imgUnLock = AllForms.m_imgListMain.Images[32]; //normall ie

                tsLinksLblText.Image = AllForms.m_imgListMain.Images[20];

                tsFileMnuNew.Image = AllForms.m_imgListMain.Images[19];
                tsFileMnuOpen.Image = AllForms.m_imgListMain.Images[43];
                tsFileMnuSave.Image = AllForms.m_imgListMain.Images[21];
                tsFileMnuSaveDocument.Image = AllForms.m_imgListMain.Images[44];
                tsFileMnuSaveDocumentImage.Image = AllForms.m_imgListMain.Images[45];
                tsEditMnuCut.Image = AllForms.m_imgListMain.Images[23];
                tsEditMnuCopy.Image = AllForms.m_imgListMain.Images[24];
                tsEditMnuPaste.Image = AllForms.m_imgListMain.Images[25];
                tsEditMnuSelectAll.Image = AllForms.m_imgListMain.Images[28];
                tsEditMnuFindInPage.Image = AllForms.m_imgListMain.Images[30];
                tsFileMnuPrintPreview.Image = AllForms.m_imgListMain.Images[7];
                tsFileMnuPrint.Image = AllForms.m_imgListMain.Images[8];
                tsFileMnuExit.Image = AllForms.m_imgListMain.Images[37];

                tsHelpMnuHelpAbout.Image = AllForms.m_imgListMain.Images[33];
                tsHelpMnuHelpContents.Image = AllForms.m_imgListMain.Images[9];

                tsDate.Image = AllForms.m_imgListMain.Images[36];
                tsDate.Text = DateTime.Today.ToString("D");

                tsOpticalZoom.Image = AllForms.m_imgListMain.Images[30];

                this.Icon = AllForms.BitmapToIcon(41);
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("\r\nError=" + ee.ToString());
            }
        }

        private void NavToUrl(string sUrl)
        {
            if (!CheckWBPointer())
                return;
            try
            {
                m_CurWB.Navigate(sUrl);
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("NavToUrl\r\n" + ee.ToString());
            }
        }

        #endregion

        #region Event handlers

        private void ToolStripViewMenuClickHandler(object sender, EventArgs e)
        {
            try
            {
                if ((sender == tsViewMnuLogs) && (!AllForms.m_frmLog.Visible))
                    AllForms.m_frmLog.Show(this);
                else if (sender == this.mainToolStripMenuItem)
                {
                    //tsMenus.Visible = mainToolStripMenuItem.Checked;
                }
                else if (sender == tabsToolStripMenuItem)
                {
                    tsWBTabs.Visible = tabsToolStripMenuItem.Checked;
                }
                else if (sender == linksToolStripMenuItem)
                {
                    tsLinks.Visible = linksToolStripMenuItem.Checked;
                }
                else if (sender == addressToolStripMenuItem)
                {
                    tsGoSearch.Visible = addressToolStripMenuItem.Checked;
                }
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("ToolStripViewMenuClickHandler\r\n" + ee.ToString());
            }
        }

        private void BrowserCtxMenuClickHandler(object sender, EventArgs e)
        {
            if (m_oHTMLCtxMenu == null)
                return;
            try
            {
                //A
                if (sender == ctxMnuACopyUrl)
                {
                    IHTMLAnchorElement phref = (IHTMLAnchorElement)m_oHTMLCtxMenu;
                    Clipboard.Clear();
                    Clipboard.SetText(HttpUtility.UrlDecode(phref.href));
                }
                else if (sender == ctxMnuACopyUrlText)
                {
                    IHTMLElement pelem = (IHTMLElement)m_oHTMLCtxMenu;
                    Clipboard.Clear();
                    Clipboard.SetText(pelem.outerText);
                }
                else if (sender == ctxMnuAOpenInBack)
                {
                    IHTMLAnchorElement phref = (IHTMLAnchorElement)m_oHTMLCtxMenu;
                    AddNewBrowser(m_Blank, "", phref.href, false);
                }
                else if (sender == ctxMnuAOpenInFront)
                {
                    IHTMLAnchorElement phref = (IHTMLAnchorElement)m_oHTMLCtxMenu;
                    AddNewBrowser(m_Blank, "", phref.href, true);
                }
                //Img
                else if (sender == ctxMnuImgCopyImageSource)
                {
                    IHTMLImgElement pimg = (IHTMLImgElement)m_oHTMLCtxMenu;
                    Clipboard.Clear();
                    Clipboard.SetText(pimg.src);
                }
                else if (sender == ctxMnuImgCopyImageAlt)
                {
                    IHTMLImgElement pimg = (IHTMLImgElement)m_oHTMLCtxMenu;
                    Clipboard.Clear();
                    Clipboard.SetText(pimg.alt);
                }
                else if (sender == ctxMnuImgCopyUrlText)
                {
                    IHTMLElement pelem = (IHTMLElement)m_oHTMLCtxMenu;
                    IHTMLAnchorElement phref = (IHTMLAnchorElement)pelem.parentElement;
                    Clipboard.Clear();
                    Clipboard.SetText(HttpUtility.UrlDecode(phref.href));
                    /*
                    Uri url = new Uri(phref.href);                    
                    string str = "AbsolutePath\r\n" + url.AbsolutePath;
                    str += "\r\nFragment\r\n" + url.Fragment;
                    str += "\r\nHost\r\n" + url.Host;
                    str += "\r\nPathAndQuery\r\n" + url.PathAndQuery;
                    str += "\r\nPort\r\n" + url.Port;
                    str += "\r\nQuery\r\n" + url.Query;
                    str += "\r\nScheme\r\n" + url.Scheme;
                    str += "\r\nUserInfo\r\n" + url.UserInfo;
                    str += "\r\nOriginal\r\n" + url.OriginalString;
                    fLog.AppendToLog("\r\n" + str);
                    
                    //Uncomment the top part

                    AbsolutePath
                    /imgres
                    Fragment

                    Host
                    images.google.ca
                    PathAndQuery
                    /imgres?imgurl=http://www.rixane.com/shots/flight-over-sea-800-1.jpg&imgrefurl=http://www.rixane.com/flight-over-sea/flight-over-sea.html&h=600&w=800&sz=69&hl=en&start=1&tbnid=arcdwYQaOgXKaM:&tbnh=107&tbnw=143&prev=/images%3Fq%3Dsea%26svnum%3D10%26hl%3Den%26lr%3D%26safe%3Doff%26sa%3DG
                    Port
                    80
                    Query
                    ?imgurl=http://www.rixane.com/shots/flight-over-sea-800-1.jpg&imgrefurl=http://www.rixane.com/flight-over-sea/flight-over-sea.html&h=600&w=800&sz=69&hl=en&start=1&tbnid=arcdwYQaOgXKaM:&tbnh=107&tbnw=143&prev=/images%3Fq%3Dsea%26svnum%3D10%26hl%3Den%26lr%3D%26safe%3Doff%26sa%3DG
                    Scheme
                    http
                    UserInfo

                    Original
                    http://images.google.ca/imgres?imgurl=http://www.rixane.com/shots/flight-over-sea-800-1.jpg&imgrefurl=http://www.rixane.com/flight-over-sea/flight-over-sea.html&h=600&w=800&sz=69&hl=en&start=1&tbnid=arcdwYQaOgXKaM:&tbnh=107&tbnw=143&prev=/images%3Fq%3Dsea%26svnum%3D10%26hl%3Den%26lr%3D%26safe%3Doff%26sa%3DG
                     */
                }
                else if (sender == ctxMnuImgOpenInBack)
                {
                    IHTMLElement pelem = (IHTMLElement)m_oHTMLCtxMenu;
                    IHTMLAnchorElement phref = (IHTMLAnchorElement)pelem.parentElement;
                    AddNewBrowser(m_Blank, "", phref.href, false);
                }
                else if (sender == ctxMnuImgOpenInFront)
                {
                    IHTMLElement pelem = (IHTMLElement)m_oHTMLCtxMenu;
                    IHTMLAnchorElement phref = (IHTMLAnchorElement)pelem.parentElement;
                    AddNewBrowser(m_Blank, "", phref.href, true);
                }
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("BrowserCtxMenuClickHandler\r\n" + ee.ToString());
            }

            m_oHTMLCtxMenu = null;
        }

        private void tsWBTabs_ToolStripButtonCtxMenuHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    tsMnuCloasAllWBs.Enabled = (m_iCountWB > 1) ? true : false;
                    ctxMnuCloseWB.Show(Cursor.Position.X, Cursor.Position.Y);
                }
                catch (Exception ee)
                {
                    AllForms.m_frmLog.AppendToLog("TabContextMenuHandler\r\n" + ee.ToString());
                }
            }
        }

        private void comboSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;

                if (comboSearch.Text.Length == 0)
                    return;

                string str = string.Empty;


                if (ctxMnuSearchGoogle.Checked)
                {
                    str = comboSearch.Text.Replace(" ", "+");
                    str = "http://www.google.com/search?q=" + str + "&btnG=Google+Search&meta=";
                    //Open in foreground or background
                    if (ctxMnuSearchOpenInCurrentBrowser.Checked)
                        NavToUrl(str);
                    else
                        AddNewBrowser(m_Blank, m_AboutBlank, str, true);
                }

                //if (ctxMnuSearchGoogleImages.Checked)
                //{
                    //string requestUri = string.Format("http://images.google.com/images?q={0}&start={1}&filter={2}&safe={3}",
                    //query, 0.ToString(), (filterSimilarResults)?1.ToString():0.ToString(), safeSearchStr )
                    //Active Moderate Off = safeSearchStr
                //}
            }
        }

        private void GoSearchToolStripButtonClickHandler(object sender, EventArgs e)
        {
            if (!CheckWBPointer())
                return;

            try
            {
                if (sender == this.tsSplitBtnSearch)
                {
                    if (comboSearch.Text.Length == 0)
                        return;

                    string str = string.Empty;
                    if (ctxMnuSearchGoogle.Checked)
                    {
                        str = comboSearch.Text.Replace(" ", "+");
                        str = "http://www.google.com/search?q=" + str + "&btnG=Google+Search&meta=";
                        //Open in foreground or background
                        if (ctxMnuSearchOpenInCurrentBrowser.Checked)
                            NavToUrl(str);
                        else
                            AddNewBrowser(m_Blank, m_AboutBlank, str, true);
                    }
                }
                else if (sender == this.tsBtnGo)
                {
                    if (tsChkBtnGo.Checked) //Open in a new background browser
                    {
                        AddNewBrowser(m_Blank, m_AboutBlank, comboURL.Text, false);
                    }
                    else
                        NavToUrl(comboURL.Text);
                }
                else if (sender == this.tsBtnBack)
                {
                    if (m_CurWB.CanGoBack)
                        m_CurWB.GoBack();
                }
                else if (sender == this.tsBtnForward)
                {
                    if (m_CurWB.CanGoForward)
                        m_CurWB.GoForward();
                }
                else if (sender == this.tsBtnRefresh)
                    m_CurWB.Refresh();
                else if (sender == this.tsBtnStop)
                    m_CurWB.Stop();
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("GoSearchToolStripButtonClickHandler\r\n" + ee.ToString());
            }
        }

        private void ToolStripHelpMenuClickHandler(object sender, EventArgs e)
        {
            try
            {
                if (sender == tsHelpMnuHelpAbout)
                {
                    frmAbout about = new frmAbout();
                    about.ShowDialog(this);
                    about.Dispose();
                }
                else if (sender == tsHelpMnuHelpContents)
                {
                    //m_CurWB.execScript(true,
                    //    "javascript:__doPostBack('NY,412800013,09/15/2007,10010,18,C,165,0','false')",
                    //    "JavaScript");
                    //if (!m_frmHTMLParser.Visible)
                    //{
                    //    m_frmHTMLParser.Show(this);
                    //}
                }
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("ToolStripHelpMenuClickHandler\r\n" + ee.ToString());
            }
        }

        private void ToolStripToolsMenuClickHandler(object sender, EventArgs e)
        {
            if (!CheckWBPointer())
                return;
            if (sender == tsToolsMnuTravelLogEntries)
            {
                //m_CurWB.RemoveTravelLogEntry(0);
                //m_CurWB.AddTravelLogEntry("http://www.yahoo.com", "Yahoo");
                AllForms.m_frmLog.AppendToLog("Travel Log Entries (History for current browser) - Count = " + m_CurWB.GetTravelLogCount().ToString() + "\r\n");
                List<TravelLogStruct> items = m_CurWB.GetTraveLogEntries();
                foreach (TravelLogStruct item in items)
                {
                    //Current page will have it's url and title as zero length string
                    if ((!string.IsNullOrEmpty(item.Title)) &&
                        (!string.IsNullOrEmpty(item.URL)))
                        AllForms.m_frmLog.AppendToLog("Title==>" + item.Title + " <>Url==>" + item.URL);
                    else
                        AllForms.m_frmLog.AppendToLog("Current Title==>" + m_CurWB.GetTitle(true) + " <>Current Url==>" + m_CurWB.LocationUrl);
                }
                if (!AllForms.m_frmLog.Visible)
                    AllForms.m_frmLog.Show(this);
                return;
            }
            else if (sender == tsToolsMnuDocumentDOM)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    //load and display DOM, passing Document object
                    m_frmDOM.LoadDOM(m_CurWB.WebbrowserObject.Document);
                    if (!m_frmDOM.Visible)
                        m_frmDOM.Show(this);
                    else
                        m_frmDOM.BringToFront();
                    this.Cursor = Cursors.Default;
                }
                catch (Exception eee)
                {
                    this.Cursor = Cursors.Default;
                    AllForms.m_frmLog.AppendToLog("tsToolsMnuDocumentDOM\r\n" + eee.ToString());
                }
                return;
            }
            else if (sender == tsToolsMnuDocumentInfo)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    m_frmDocInfo.LoadDocumentInfo(this.m_CurWB);
                    if (!m_frmDocInfo.Visible)
                        m_frmDocInfo.Show(this);
                    else
                        m_frmDocInfo.BringToFront();
                    this.Cursor = Cursors.Default;
                }
                catch (Exception eeee)
                {
                    this.Cursor = Cursors.Default;
                    AllForms.m_frmLog.AppendToLog("tsToolsMnuDocumentInfo\r\n" + eeee.ToString());
                }
                return;
            }
            else if (sender == tsToolsMnuSimpleHTMLEditor)
            {
                if (!m_frmHTMLEditor.Visible)
                    m_frmHTMLEditor.Show(this);
                return;
            }
            else if (sender == tsToolsMnurequestResponseHeaders)
            {
                if (tsToolsMnurequestResponseHeaders.Checked)
                {
                    //Activate all browsers
                    foreach (Control ctl in this.toolStripContainer1.ContentPanel.Controls)
                    {
                        if (ctl is csExWB.cEXWB)
                        {
                            csExWB.cEXWB wb = ctl as csExWB.cEXWB;
                            wb.StartHTTPAPP();
                            wb.StartHTTPSAPP();
                        }
                    }
                    if (!m_frmRequestResponseHeaders.Visible)
                        m_frmRequestResponseHeaders.Show(this);
                }
                else
                {
                    //Only one call is enough to deactivate all
                    cEXWB1.StopHTTPAPP();
                    cEXWB1.StopHTTPSAPP();
                    if (m_frmRequestResponseHeaders.Visible)
                        m_frmRequestResponseHeaders.Hide();
                }
                return;
            }
            else if (sender == tsToolsMnufileDownloads)
            {
                if (!m_frmFileDownload.Visible)
                    m_frmFileDownload.Show(this);
                return;
            }
            else if (sender == tsToolsMnuHTMLDialogs)
            {
                if (tsToolsMnuHTMLDialogs.Checked) //Allow
                {
                    tsToolsMnuHTMLDialogs.Text = "Allow HTML Dialogs";
                    cEXWB1.SetAllowHTMLDialogs(true);
                }
                else
                {
                    tsToolsMnuHTMLDialogs.Text = "Disllow HTML Dialogs";
                    cEXWB1.SetAllowHTMLDialogs(false);
                }
                return;
            }
            else if (sender == tsToolsMnudisplayHTMLPopup)
            {
                IHTMLDocument2 doc2 = m_CurWB.WebbrowserObject.Document as IHTMLDocument2;
                IHTMLWindow4 win4 = null;

                if (doc2 == null)
                    return;

                win4 = doc2.parentWindow as IHTMLWindow4;
                if (win4 == null)
                    return;
                IHTMLPopup popup = win4.createPopup(null) as IHTMLPopup;
                if (popup != null)
                {
                    IHTMLDocument2 popdoc = popup.document as IHTMLDocument2;
                    if ((popdoc != null) && (popdoc.body != null))
                    {
                        popdoc.body.style.backgroundColor = "lightyellow";
                        popdoc.body.style.border = "solid black 1px";
                        popdoc.body.innerHTML = "<p align=\"center\">Displaying some <B>HTML</B> as a tooltip! X = 10, Y = 10</p>";
                    }
                    popup.show(10, 10, 400, 25, doc2.body);
                }
                return;
            }
            else if (sender == tsToolsMnuWindowExternal)
            {
                if (!m_frmWindowExternal.Visible)
                    m_frmWindowExternal.Show(this);
                return;
            }
            else if (sender == tsToolsMnuAutomation)
            {
                m_frmAutomation = new frmAutomation();
                m_frmAutomation.Show(this);
                return;
            }

            #region Cache Cookie History
            
            bool bshowform = true;
            int iCount = 0; //Number of cookies or cache entries deleted
            try
            {
                if (sender == tsToolsMnuClearHistory)
                {
                    if (!AllForms.AskForConfirmation("Proceed to remove all History entries?", this))
                        return;
                    m_CurWB.ClearHistory();
                }
                else if (sender == tsToolsMnuCookieViewAll)
                {
                    this.Cursor = Cursors.WaitCursor;
                    iCount = m_frmCacheCookie.LoadListViewItems(AllForms.COOKIE);
                    this.Cursor = Cursors.Default;
                }
                else if (sender == tsToolsMnuCookieViewCurrentSite)
                {
                    string url = m_CurWB.LocationUrl;
                    if (url.Length > 0)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        iCount = m_frmCacheCookie.LoadListViewItems(
                            AllForms.SetupCookieCachePattern(m_CurWB.LocationUrl, AllForms.COOKIE));
                        this.Cursor = Cursors.Default;
                    }
                }
                else if (sender == tsToolsMnuCacheViewAll)
                {
                    this.Cursor = Cursors.WaitCursor;
                    iCount = m_frmCacheCookie.LoadListViewItems(AllForms.VISITED);
                    this.Cursor = Cursors.Default;
                }
                else if (sender == tsToolsMnuCacheViewCurrentSite)
                {
                    string url = m_CurWB.LocationUrl;
                    if (url.Length > 0)
                    {
                        //Visited:.*\.example\.com
                        this.Cursor = Cursors.WaitCursor;
                        iCount = m_frmCacheCookie.LoadListViewItems(
                            AllForms.SetupCookieCachePattern(m_CurWB.LocationUrl, AllForms.VISITED));
                        this.Cursor = Cursors.Default;
                    }
                }
                else if (sender == tsToolsMnuCookieEmptyAll)
                {
                    if (!AllForms.AskForConfirmation("Proceed to remove all cookies?", this))
                        return;
                    this.Cursor = Cursors.WaitCursor;
                    iCount = m_frmCacheCookie.ClearAllCookies(string.Empty);
                    bshowform = false;
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(this, "Deleted " + iCount.ToString() + " Cooikes.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (sender == tsToolsMnuCookieEmptyCurrentSite)
                {
                    if (!AllForms.AskForConfirmation("Proceed to remove cookies from "
                        + m_CurWB.LocationUrl + " ?", this))
                        return;
                    this.Cursor = Cursors.WaitCursor;
                    iCount = m_frmCacheCookie.ClearAllCookies(m_CurWB.LocationUrl);
                    bshowform = false;
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(this, "Deleted " + iCount.ToString() +
                        " Cooikes from\r\n" + m_CurWB.LocationUrl,
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (sender == tsToolsMnuCacheEmptyAll)
                {
                    if (!AllForms.AskForConfirmation("Proceed to remove all cache entries?", this))
                        return;
                    this.Cursor = Cursors.WaitCursor;
                    iCount = m_frmCacheCookie.ClearAllCache(string.Empty);
                    bshowform = false;
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(this, "Deleted " + iCount.ToString() + " Cache Entries.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (sender == tsToolsMnuCacheEmptyCurrentSite)
                {
                    if (!AllForms.AskForConfirmation("Proceed to remove cache entries from "
                        + m_CurWB.LocationUrl + " ?", this))
                        return;
                    this.Cursor = Cursors.WaitCursor;
                    iCount = m_frmCacheCookie.ClearAllCache(m_CurWB.LocationUrl);
                    bshowform = false;
                    this.Cursor = Cursors.Default;
                    MessageBox.Show(this, "Deleted " + iCount.ToString() +
                        " Cache Entries from\r\n" + m_CurWB.LocationUrl,
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (bshowform)
                {
                    if (iCount > 0)
                    {
                        if (!m_frmCacheCookie.Visible)
                            m_frmCacheCookie.Show(this);
                    }
                    else
                        MessageBox.Show(this, "No Items Found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ee)
            {
                this.Cursor = Cursors.Default;
                AllForms.m_frmLog.AppendToLog("ToolStripToolsMenuClickHandler\r\n" + ee.ToString());
            }

            #endregion

        }

        /// <summary>
        /// File menu items click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripFileMenuClickHandler(object sender, EventArgs e)
        {
            try
            {
                if (sender == this.tsFileMnuBackgroundBlankPage)
                {
                    AddNewBrowser(m_Blank, m_AboutBlank, string.Empty, false);
                }
                else if (sender == tsFileMnuBackgroundFromAddress)
                {
                    AddNewBrowser(m_Blank, m_AboutBlank, comboURL.Text, false);
                }
                else if (sender == tsFileMnuForegroundBlankPage)
                {
                    AddNewBrowser(m_Blank, m_AboutBlank, string.Empty, true);
                }
                else if (sender == tsFileMnuForegroundFromAddress)
                {
                    AddNewBrowser(m_Blank, m_AboutBlank, comboURL.Text, true);
                }
                else if (sender == tsFileMnuPrint)
                {
                    m_CurWB.Print();
                }
                else if (sender == tsFileMnuPrintPreview)
                {
                    m_CurWB.PrintPreview();
                }
                else if (sender == tsFileMnuSaveDocument)
                {
                    m_CurWB.SaveAs();
                }
                else if (sender == tsFileMnuSaveDocumentImage)
                {
                    ////gif format produces some of the smallest sizes
                    if (AllForms.ShowStaticSaveDialogForImage(this) == DialogResult.OK)
                    {
                        System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Bmp;
                        string ext = ".bmp";
                        switch (AllForms.m_dlgSave.FilterIndex)
                        {
                            case 1:
                                break;
                            case 2:
                                format = System.Drawing.Imaging.ImageFormat.Gif;
                                ext = ".gif";
                                break;
                            case 3:
                                format = System.Drawing.Imaging.ImageFormat.Jpeg;
                                ext = ".jpeg";
                                break;
                            case 4:
                                format = System.Drawing.Imaging.ImageFormat.Png;
                                ext = ".png";
                                break;
                            case 5:
                                format = System.Drawing.Imaging.ImageFormat.Wmf;
                                ext = ".wmf";
                                break;
                            case 6:
                                format = System.Drawing.Imaging.ImageFormat.Tiff;
                                ext = ".tiff";
                                break;
                            case 7:
                                format = System.Drawing.Imaging.ImageFormat.Emf;
                                ext = ".emf";
                                break;
                            default:
                                break;
                        }
                        if (string.IsNullOrEmpty(Path.GetExtension(AllForms.m_dlgSave.FileName)))
                            AllForms.m_dlgSave.FileName += ext;

                        m_CurWB.SaveBrowserImage(AllForms.m_dlgSave.FileName,
                            System.Drawing.Imaging.PixelFormat.Format24bppRgb, format);
                    }
                }
                else if (sender == tsFileMnuOpen)
                {
                    if (AllForms.ShowStaticOpenDialog(this, AllForms.DLG_HTMLS_FILTER, 
                        string.Empty, "C:",true) == DialogResult.OK)
                        m_CurWB.Navigate(AllForms.m_dlgOpen.FileName);
                }
                else if (sender == tsFileMnuExit)
                {
                    Application.Exit();
                }
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("File Menu\r\n" + ee.ToString());
            }
        }

        /// <summary>
        /// Edit menu items click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripEditMenuClickHandler(object sender, EventArgs e)
        {
            try
            {
                if (!CheckWBPointer())
                    return;
                if (sender == tsEditMnuSelectAll)
                    m_CurWB.SelectAll();
                else if (sender == tsEditMnuCopy)
                    m_CurWB.Copy();
                else if (sender == tsEditMnuCut)
                    m_CurWB.Cut();
                else if (sender == tsEditMnuPaste)
                    m_CurWB.Paste();
                else if (sender == tsEditMnuFindInPage)
                {
                    m_frmFind.Show(this);
                }
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("ToolStripEditMenuClickHandler\r\n" + ee.ToString());
            }
        }

        /// <summary>
        /// URL combo click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboURL_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Return)
                {
                    e.Handled = true;
                    NavToUrl(comboURL.Text);
                }
            }
            catch (Exception eex)
            {
                MessageBox.Show(eex.ToString(), "comboUrl_KeyUp");
            }
        }

        /// <summary>
        /// Handles click event of the drop down menu items of the
        /// toolstrip button responsible to display number of open browsers
        /// and to offer a quick menu to select a browser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsBtnOpenWBs_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                SwitchTabs(e.ClickedItem.Name, FindTab(e.ClickedItem.Name));
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("tsBtnOpenWBs_DropDownItemClicked\r\n" + ee.ToString());
            }
        }

        /// <summary>
        /// Handles toolstripbutton (tabs) click events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsWBTabs_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem.Name == tsBtnOpenWBs.Name)
                    return;

                ToolStripButton btn = (ToolStripButton)e.ClickedItem;
                if (e.ClickedItem.Name == tsBtnAddWB.Name)
                {
                    if (tsChkBtnAddWB.Checked)
                    {
                        AddNewBrowser(m_Blank, m_AboutBlank, m_AboutBlank, false);
                    }
                    else
                        AddNewBrowser(m_Blank, m_AboutBlank, m_AboutBlank, true);
                }
                else if (e.ClickedItem.Name == tsBtnRemoveWB.Name)
                {
                    RemoveBrowser(((ToolStripButton)tsWBTabs.Items[m_iCurTab]).Name);
                }
                else if (e.ClickedItem.Name == tsBtnRemoveAllWBs.Name)
                {
                    tsMnuCloasAllWBs_Click(this, EventArgs.Empty);
                }
                else
                    SwitchTabs(e.ClickedItem.Name, btn);
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("tsWBTabs_ItemClicked\r\n" + ee.ToString());
            }
        }

        /// <summary>
        /// Handles close menu click event to remove a browser
        /// May not be the current browser in front
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMnuCloseWB_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_tsBtnctxMnu == null)
                    return;
                //Is this the current one
                if (m_tsBtnctxMnu.Name == m_CurWB.Name)
                {
                    RemoveBrowser(m_tsBtnctxMnu.Name);
                }
                else
                {
                    RemoveBrowser2(m_tsBtnctxMnu.Name, true);
                }
                m_tsBtnctxMnu = null;
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("tsMnuCloseWB_Click\r\n" + ee.ToString());
            }
        }

        /// <summary>
        /// Close all browsers except the first one from design time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMnuCloasAllWBs_Click(object sender, EventArgs e)
        {
            if (m_iCountWB == 1)
                return;
            try
            {
                foreach (ToolStripMenuItem item in ctxMnuOpenWBs.Items)
                {
                    RemoveBrowser2(item.Name, false);
                }
                ctxMnuOpenWBs.Items.Clear();

                m_CurWB = cEXWB1;
                m_CurWB.BringToFront();
                m_CurWB.SetFocus();

                m_tsBtnFirstTab.Checked = true;
                m_iCurTab = tsWBTabs.Items.IndexOf((ToolStripItem)m_tsBtnFirstTab);

                string text = m_CurWB.GetTitle(true);
                if (text.Length == 0)
                    text = m_Blank;
                ToolStripMenuItem menu = new ToolStripMenuItem(text, m_imgUnLock);
                menu.Name = m_tsBtnFirstTab.Name;
                menu.Checked = true;
                ctxMnuOpenWBs.Items.Add((ToolStripItem)menu);
                m_iCurMenu = ctxMnuOpenWBs.Items.Count - 1;

                tsBtnOpenWBs.Text = m_iCountWB.ToString() + " open tab(s)";
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("tsMnuCloasAllWBs_Click\r\n" + ee.ToString());
            }
        }

        /// <summary>
        /// Update enable state of Edit menu items before displaying them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMnuEdit_DropDownOpening(object sender, EventArgs e)
        {
            try
            {
                tsEditMnuSelectAll.Enabled = m_CurWB.IsCommandEnabled("SelectAll");
                tsEditMnuCopy.Enabled = m_CurWB.IsCommandEnabled("Copy");
                tsEditMnuCut.Enabled = m_CurWB.IsCommandEnabled("Cut");
                tsEditMnuPaste.Enabled = m_CurWB.IsCommandEnabled("Paste");
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("tsMnuEdit_DropDownOpening\r\n" + ee.ToString());
            }
        }

        /// <summary>
        /// Call back to intercept find requests from frmFind
        /// </summary>
        /// <param name="FindPhrase"></param>
        /// <param name="MatchWholeWord"></param>
        /// <param name="MatchCase"></param>
        /// <param name="Downward"></param>
        /// <param name="HighlightAll"></param>
        /// <param name="sColor"></param>
        void m_frmFind_FindInPageEvent(string FindPhrase, bool MatchWholeWord, bool MatchCase, bool Downward, bool HighlightAll, string sColor)
        {
            try
            {
                if (HighlightAll)
                {
                    int found = m_CurWB.FindAndHightAllInPage(FindPhrase, MatchWholeWord, MatchCase, sColor, "black");
                    MessageBox.Show(this, "Found " + found.ToString() + " matches.", "Finf in Page", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (m_CurWB.FindInPage(FindPhrase, Downward, MatchWholeWord, MatchCase, true) == false)
                        MessageBox.Show(this, "No more matches found for " + FindPhrase, "Find in Page", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("frmMain_m_frmFind_FindInPageEvent\r\n" + ee.ToString());
            }
        }

        private ToolStripMenuItem m_lastopticalzoomvalue = null;
        /// <summary>
        /// Optical Zoom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsOpticalZoom_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (m_lastopticalzoomvalue == null)
                tsOpticalZoom100.Checked = false;
            else
                m_lastopticalzoomvalue.Checked = false;
            m_lastopticalzoomvalue = e.ClickedItem as ToolStripMenuItem;
            if (m_lastopticalzoomvalue != null)
                m_CurWB.SetOpticalZoomValue(int.Parse(m_lastopticalzoomvalue.Text));
        }

        #endregion

        #region Favorites Handling

        //Use a FileSystemWatcher to determine whether to reload favorites upon
        //dropping down or not.
        //To be more effeicent, I would have, in case of
        //Create, insert a new menu item in the appropriate index
        //delete, remove the menu item
        //renamed, modify the text
        //changed, modify text and/or url
        private bool m_FavNeedReload = false;

        private void fswFavorites_Created(object sender, FileSystemEventArgs e)
        {
            m_FavNeedReload = true;
            //e.ChangeType.ToString();
            //e.FullPath;
            //e.Name;
        }

        private void fswFavorites_Deleted(object sender, FileSystemEventArgs e)
        {
            m_FavNeedReload = true;
            //try
            //{
            //    //If a link then we remove it
            //    ToolStripItem itema = null;
            //    foreach (ToolStripItem item in tsLinks.Items)
            //    {
            //        if (item.Name == e.Name)
            //        {
            //            itema = item;
            //            break;
            //        }
            //    }
            //    if (itema != null)
            //        tsLinks.Items.Remove(itema);
            //}
            //catch (Exception ee)
            //{
            //    AllForms.m_frmLog.AppendToLog("fswFavorites_Deleted\r\n" + ee.ToString());
            //}
        }

        private void fswFavorites_Renamed(object sender, RenamedEventArgs e)
        {
            m_FavNeedReload = true;
        }

        private void fswFavorites_Changed(object sender, FileSystemEventArgs e)
        {
            m_FavNeedReload = true;
        }

        private void LoadFavoriteMenuItems()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DirectoryInfo objDir = new DirectoryInfo(fswFavorites.Path);
                //Recurse, starting from main dir
                LoadFavoriteMenuItems(objDir, tsFavoritesMnu);
                this.Cursor = Cursors.Default;
            }
            catch (Exception ee)
            {
                this.Cursor = Cursors.Default;
                AllForms.m_frmLog.AppendToLog("LoadFavoriteMenuItems\r\n" + ee.ToString());
            }
        }

        /// <summary>
        /// Recursive function
        /// </summary>
        /// <param name="objDir"></param>
        private void LoadFavoriteMenuItems(DirectoryInfo objDir, ToolStripMenuItem menuitem)
        {
            try
            {
                string strName = string.Empty;
                string strUrl = string.Empty;
                
                DirectoryInfo[] dirs = objDir.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    
                    ToolStripMenuItem diritem = new ToolStripMenuItem(dir.Name, tsFileMnuOpen.Image);
                    menuitem.DropDownItems.Add((ToolStripItem)diritem);
                    LoadFavoriteMenuItems(dir, diritem);
                }

                bool addlinks = (objDir.Name.Equals("links", 
                    StringComparison.CurrentCultureIgnoreCase)) ? true : false;
                FileInfo[] urls = objDir.GetFiles("*.url");
                foreach (FileInfo url in urls)
                {
                    strName = Path.GetFileNameWithoutExtension(url.Name);
                    strUrl = m_CurWB.ResolveInternetShortCut(url.FullName);
                    //load up quick links
                    if (addlinks)
                    {
                        ToolStripButton btn = new ToolStripButton(strName, m_imgUnLock);
                        btn.Tag = strUrl;
                        btn.Click += new EventHandler(ToolStripLinksButtonClickHandler);
                        tsLinks.Items.Add((ToolStripItem)btn);
                    }
                    ToolStripMenuItem item = new ToolStripMenuItem(strName, m_imgUnLock);
                    item.Tag = strUrl;
                    item.Click += new EventHandler(ToolStripFavoritesMenuClickHandler);
                    menuitem.DropDownItems.Add((ToolStripItem)item);
                }
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("LoadFavoriteMenuItems\r\n" + ee.ToString());
            }
        }

        void ToolStripLinksButtonClickHandler(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem item = (ToolStripItem)sender;
                if (item.Tag != null)
                    this.NavToUrl(item.Tag.ToString());
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("ToolStripLinksButtonClickHandler\r\n" + ee.ToString());
            }
        }

        private void tsFavoritesMnu_DropDownOpening(object sender, EventArgs e)
        {
            if (!m_FavNeedReload)
                return;
            m_FavNeedReload = false;
            try
            {
                //Reload favorites
                if (tsFavoritesMnu.DropDownItems.Count > 3)
                {
                    //Remove from back to front except the original items
                    for (int i = tsFavoritesMnu.DropDownItems.Count - 1; i > 2; i--)
                    {
                        if ((tsFavoritesMnu.DropDownItems[i] != tsFavoritesMnuAddToFavorites) &&
                            (tsFavoritesMnu.DropDownItems[i] != tsFavoritesMnuOrganizeFavorites) &&
                            (tsFavoritesMnu.DropDownItems[i] != tsFavoritesMnuSeparator))
                        {
                            tsFavoritesMnu.DropDownItems.Remove(tsFavoritesMnu.DropDownItems[i]);
                        }
                    }
                    for (int i = tsLinks.Items.Count - 1; i > 0; i--)
                    {
                        tsLinks.Items.Remove(tsLinks.Items[i]);
                    }
                }
                //Load favorites
                LoadFavoriteMenuItems();
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("tsFavoritesMnu_DropDownOpening\r\n" + ee.ToString());
            }
        }

        private void ToolStripFavoritesMenuClickHandler(object sender, EventArgs e)
        {
            try
            {
                if (sender == tsFavoritesMnuAddToFavorites)
                {
                    m_CurWB.AddToFavorites();
                }
                else if (sender == tsFavoritesMnuOrganizeFavorites)
                {
                    m_CurWB.OrganizeFavorites();
                }
                ToolStripItem item = (ToolStripItem)sender;
                if (item.Tag != null)
                    this.NavToUrl(item.Tag.ToString());
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("ToolStripFavoritesMenuClickHandler\r\n" + ee.ToString());
            }
        }

        #endregion

        #region TextSize
        
        /// <summary>
        /// Sets browser text size based on given parameter 0-4
        /// Adjust the chack state of textsize menu items
        /// </summary>
        /// <param name="iLevel">Text size level 0-4</param>
        private void SetZoomLevel(int iLevel)
        {
            tsViewMnuTextSizeLargest.Checked = false;
            tsViewMnuTextSizeLarger.Checked = false;
            tsViewMnuTextSizeMedium.Checked = false;
            tsViewMnuTextSizeSmaller.Checked = false;
            tsViewMnuTextSizeSmallest.Checked = false;

            switch (iLevel)
            {
                case 0:
                    tsViewMnuTextSizeLargest.Checked = true;
                    if (m_CurWB != null)
                        m_CurWB.TextSize = TextSizeWB.Largest;
                    break;
                case 1:
                    tsViewMnuTextSizeLarger.Checked = true;
                    if (m_CurWB != null)
                        m_CurWB.TextSize = TextSizeWB.Larger;
                    break;
                case 2:
                    tsViewMnuTextSizeMedium.Checked = true;
                    if (m_CurWB != null)
                        m_CurWB.TextSize = TextSizeWB.Medium;
                    break;
                case 3:
                    tsViewMnuTextSizeSmaller.Checked = true;
                    if (m_CurWB != null)
                        m_CurWB.TextSize = TextSizeWB.Smaller;
                    break;
                case 4:
                    tsViewMnuTextSizeSmallest.Checked = true;
                    if (m_CurWB != null)
                        m_CurWB.TextSize = TextSizeWB.Smallest;
                    break;
            }
        }

        /// <summary>
        /// Hanldes textsize menu item clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMnuTextSizeClickHandler(object sender, EventArgs e)
        {
            if (sender == tsViewMnuTextSizeLargest)
                SetZoomLevel(0);
            else if (sender == tsViewMnuTextSizeLarger)
                SetZoomLevel(1);
            else if (sender == tsViewMnuTextSizeMedium)
                SetZoomLevel(2);
            else if (sender == tsViewMnuTextSizeSmaller)
                SetZoomLevel(3);
            else if (sender == tsViewMnuTextSizeSmallest)
                SetZoomLevel(4);
        }

        /// <summary>
        /// Updates the check state of the text size menu items before displaying them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMnuTextSize_DropDownOpening(object sender, EventArgs e)
        {
            tsViewMnuTextSizeLargest.Checked = false;
            tsViewMnuTextSizeLarger.Checked = false;
            tsViewMnuTextSizeMedium.Checked = false;
            tsViewMnuTextSizeSmaller.Checked = false;
            tsViewMnuTextSizeSmallest.Checked = false;
            if (cEXWB1.TextSize == TextSizeWB.Largest)
                tsViewMnuTextSizeLargest.Checked = true;
            else if (cEXWB1.TextSize == TextSizeWB.Larger)
                tsViewMnuTextSizeLarger.Checked = true;
            else if (cEXWB1.TextSize == TextSizeWB.Medium)
                tsViewMnuTextSizeMedium.Checked = true;
            else if (cEXWB1.TextSize == TextSizeWB.Smaller)
                tsViewMnuTextSizeSmaller.Checked = true;
            else if (cEXWB1.TextSize == TextSizeWB.Smallest)
                tsViewMnuTextSizeSmallest.Checked = true;
        } 

        #endregion

        #region WebBrowser Events

        private void cEXWB1_TitleChange(object sender, csExWB.TitleChangeEventArgs e)
        {
            if (sender != m_CurWB)
                return;
            this.Text = e.title;
        }

        private void cEXWB1_StatusTextChange(object sender, csExWB.StatusTextChangeEventArgs e)
        {
            if (sender != m_CurWB)
                return;
            //if (e.text.Length > 0) m_Status = e.text;
            tsStatus.Text = e.text;
        }

        private void cEXWB1_BeforeNavigate2(object sender, csExWB.BeforeNavigate2EventArgs e)
        {
            //if(e.istoplevel)
            //    AllForms.m_frmLog.AppendToLog("cEXWB1_BeforeNavigate2_TOPLEVEL");
            //else
            //    AllForms.m_frmLog.AppendToLog("cEXWB1_BeforeNavigate2");
            //try
            //{
            //    if ((m_CurWB != null) && (m_CurWB == sender) && (e.istoplevel))
            //    {
            //    }
            //}
            //catch (Exception ee)
            //{
            //    if (m_CurWB != null)
            //        AllForms.m_frmLog.AppendToLog(m_CurWB.Name + "_BeforeNavigate2\r\n" + ee.ToString());
            //    else
            //        AllForms.m_frmLog.AppendToLog("cEXWB1_BeforeNavigate2\r\n" + ee.ToString());
            //}
            //finally
            //{

            //}
        }

        private void cEXWB1_CommandStateChange(object sender, csExWB.CommandStateChangeEventArgs e)
        {
            if (sender != m_CurWB)
                return;
            try
            {
                if (e.command == CommandStateChangeConstants.CSC_NAVIGATEBACK)
                    tsBtnBack.Enabled = e.enable;
                else if (e.command == CommandStateChangeConstants.CSC_NAVIGATEFORWARD)
                    tsBtnForward.Enabled = e.enable;
            }
            catch (Exception ee)
            {
                if(m_CurWB != null)
                    AllForms.m_frmLog.AppendToLog(m_CurWB.Name + "_CommandStateChange\r\n" + ee.ToString());
                else
                    AllForms.m_frmLog.AppendToLog("cEXWB1_CommandStateChange\r\n" + ee.ToString());
            }
        }

        private void cEXWB1_DocumentComplete(object sender, csExWB.DocumentCompleteEventArgs e)
        {
            try
            {
                //if (e.istoplevel)
                //    AllForms.m_frmLog.AppendToLog("cEXWB1_DocumentComplete_TOPLEVEL");
                //else
                //    AllForms.m_frmLog.AppendToLog("cEXWB1_DocumentComplete");

                csExWB.cEXWB pWB = (csExWB.cEXWB)sender;
                if (e.istoplevel)
                {
                    ToolStripButton btn = FindTab(pWB.Name);
                    ToolStripMenuItem menu = FindWBMenu(pWB.Name);

                    btn.Text = pWB.GetTitle(true);
                    if (btn.Text.Length == 0)
                    {
                        btn.Text = m_Blank;
                    }
                    else if (btn.Text.Length > m_MaxTextLen)
                        btn.Text = btn.Text.Substring(0, m_MaxTextLen) + "...";
                    menu.Text = btn.Text;
                    btn.ToolTipText = HttpUtility.UrlDecode(e.url);

                    try
                    {
                        if ((this.WindowState != FormWindowState.Minimized) &&
                            (e.url != m_AboutBlank))
                        {
                            btn.Image = pWB.DrawThumb(80, 80,
                                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                        }
                    }
                    catch (Exception ee1)
                    {
                        AllForms.m_frmLog.AppendToLog(pWB.Name + "_DocumentComplete_UpdateThumb\r\n" + ee1.ToString());
                    }
                    finally
                    {
                    }

                    if (sender == m_CurWB)
                    {
                        this.comboURL.Text = btn.ToolTipText;
                        pWB.SetFocus();
                    }
                }
                else if (pWB.MainDocumentFullyLoaded) // a frame naviagtion within a frameset
                {
                    try
                    {
                        ToolStripButton btn = FindTab(pWB.Name);
                        if( (this.WindowState != FormWindowState.Minimized) &&
                            (btn != null) )
                        {
                            btn.Image = pWB.DrawThumb(80, 80,
                                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                        }
                    }
                    catch (Exception ee2)
                    {
                        AllForms.m_frmLog.AppendToLog(pWB.Name + "_DocumentComplete_UpdateThumb\r\n" + ee2.ToString());
                    }
                    finally
                    {
                    }
                }
            }
            catch (Exception ee)
            {
                if (m_CurWB != null)
                    AllForms.m_frmLog.AppendToLog(m_CurWB.Name + "_DocumentComplete\r\n" + ee.ToString());
                else
                    AllForms.m_frmLog.AppendToLog("cEXWBxx_DocumentComplete\r\n" + ee.ToString());
            }
            finally
            {
            }
        }

        private void cEXWB1_DocumentCompleteEX(object sender, csExWB.DocumentCompleteExEventArgs e)
        {
            //Activate this event, if you need to process the source HTML before
            //any scripts have been executed.
        }

        //Handling HTMLDocument and HTMLWindow events
        private void cEXWB1_HTMLEvent(object sender, csExWB.HTMLEventArgs e)
        {
            try
            {
                //Window events are not cancellable
                if (e.m_EventType == HTMLEventType.HTMLWindowEvent)
                {
                    if (e.m_EventDispId == HTMLEventDispIds.ID_ONLOAD)
                    {
                        csExWB.cEXWB pWB = (csExWB.cEXWB)sender;
                        if (pWB != null)
                            AllForms.m_frmLog.AppendToLog(pWB.Name + "_ONLOAD fired.");
                        else
                            AllForms.m_frmLog.AppendToLog("UNKNOWN_ONLOAD fired.");
                    }
                }
                else if (e.m_EventType == HTMLEventType.HTMLDocumentEvent)
                {
                    if (e.m_EventDispId == HTMLEventDispIds.ID_ONCLICK)
                    {
                        //Cancellable
                        if ( (e.m_pEvtObj != null) &&
                            (e.m_pEvtObj.SrcElement != null) && 
                            (!string.IsNullOrEmpty(e.m_pEvtObj.SrcElement.tagName)) )
                        {
                            if (e.m_pEvtObj.SrcElement.tagName == "A")
                            {
                                IHTMLAnchorElement anchor = (IHTMLAnchorElement)e.m_pEvtObj.SrcElement;
                                if (anchor != null)
                                    AllForms.m_frmLog.AppendToLog("A Link Clicked:\r\n" + anchor.href);
                                else
                                    AllForms.m_frmLog.AppendToLog("Unable to retrevie clicked link html anchor");
                            }
                            else
                                AllForms.m_frmLog.AppendToLog("An HTML element was clicked - tagname:\r\n" + e.m_pEvtObj.SrcElement.tagName);
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                if (m_CurWB != null)
                    AllForms.m_frmLog.AppendToLog(m_CurWB.Name + "_HTMLEvent\r\n" + ee.ToString());
                else
                    AllForms.m_frmLog.AppendToLog("cEXWB1_HTMLEvent\r\n" + ee.ToString());
            }

        }

        private void cEXWB1_NavigateComplete2(object sender, csExWB.NavigateComplete2EventArgs e)
        {

        }

        //default, cancel = false;
        private void cEXWB1_NavigateError(object sender, csExWB.NavigateErrorEventArgs e)
        {
            //If using internal filedownlod mechanism, we get nav errors for file download with status code 200(OK)????
            if ((e.statuscode == WinInetErrors.HTTP_STATUS_OK) ||
                (e.statuscode == WinInetErrors.HTTP_STATUS_CONTINUE) ||
                (e.statuscode == WinInetErrors.HTTP_STATUS_REDIRECT) ||
                (e.statuscode == WinInetErrors.HTTP_STATUS_REQUEST_TIMEOUT) ||
                (e.statuscode == WinInetErrors.HTTP_STATUS_ACCEPTED))
            {
                return; //default handling
            }

            if (m_CurWB != null)
            {
                AllForms.m_frmLog.AppendToLog(m_CurWB.Name +
                    "_NavigateError\r\nURL\r\n" + HttpUtility.UrlDecode(e.url) +
                    "\r\nStatus Code\r\n" + e.statuscode.ToString());
            }
            else
            {
                AllForms.m_frmLog.AppendToLog("cEXWBxx_NavigateError\r\nURL\r\n" + HttpUtility.UrlDecode(e.url) +
                    "\r\nStatus Code\r\n" + e.statuscode.ToString());

            }
            //Any nav errors, cancel it
            e.Cancel = true;
        }

        private void AssignPopup(ref object obj)
        {
            if (m_CurWB != null)
            {
                if (!m_CurWB.RegisterAsBrowser)
                    m_CurWB.RegisterAsBrowser = true;
                obj = m_CurWB.WebbrowserObject;
            }
        }
        private void cEXWB1_NewWindow2(object sender, csExWB.NewWindow2EventArgs e)
        { 
            try
            {
                string result = AllForms.m_frmDynamicConfirm.DisplayConfirm(this,
                    "A new window2 has been requested by " + m_CurWB.Name,
                    "Popup Window", 
                    "Cancel popup", "Open in popup", "Open in new tab", string.Empty);

                if (result == "Cancel popup")
                    e.Cancel = true;
                else if (result == "Open in popup")
                {
                    if (!m_frmPopup.Visible)
                        m_frmPopup.Show(this);
                    m_frmPopup.AssignBrowserObject(ref e.browser);
                }
                else if (result == "Open in new tab")
                {
                    AddNewBrowser(m_Blank, m_AboutBlank, m_AboutBlank, true);
                    AssignPopup(ref e.browser);
                }
                //else open in current webbrowser
            }
            catch (Exception nEx)
            {
                if (m_CurWB != null)
                    AllForms.m_frmLog.AppendToLog(m_CurWB.Name + "_NewWindow2\r\n" + nEx.ToString());
                else
                    AllForms.m_frmLog.AppendToLog("cEXWBxx_NewWindow2\r\n" + nEx.ToString());
            }
            finally
            {
            }
        }

        private void cEXWB1_NewWindow3(object sender, csExWB.NewWindow3EventArgs e)
        {
            try
            {
                string str = string.Empty;
                if (e.flags == NWMF.HTMLDIALOG)
                    str = "HTML Dialog";
                else if (e.flags == NWMF.SHOWHELP)
                    str = "Show Help";
                else
                    str = e.flags.ToString();

                string result = AllForms.m_frmDynamicConfirm.DisplayConfirm(this,
                    "A new window3 has been requested by:\r\n" + e.url + "\r\nType:" + str,
                    "Popup Window",
                    "Cancel popup", "Open in popup", "Open in new tab", string.Empty);

                if (result == "Cancel popup")
                    e.Cancel = true;
                else if (result == "Open in popup")
                {
                    if (!m_frmPopup.Visible)
                        m_frmPopup.Show(this);
                    m_frmPopup.AssignBrowserObject(ref e.browser);
                }
                else if (result == "Open in new tab")
                {
                    AddNewBrowser(m_Blank, m_AboutBlank, "", true);
                    AssignPopup(ref e.browser);
                }
            }
            catch (Exception nEx)
            {
                if (m_CurWB != null)
                    AllForms.m_frmLog.AppendToLog(m_CurWB.Name + "_NewWindow3\r\n" + nEx.ToString());
                else
                    AllForms.m_frmLog.AppendToLog("cEXWBxx_NewWindow3\r\n" + nEx.ToString());
            }
            finally
            {
            }
        }

        private void cEXWB1_ProgressChange(object sender, csExWB.ProgressChangeEventArgs e)
        {
            if (sender != m_CurWB)
                return;
            try
            {
                if ((e.progress == -1) || (e.progressmax == e.progress))
                {
                    tsProgress.Value = 0; // 100;
                    tsProgress.Maximum = 0;
                    return;
                }
                if ((e.progressmax > 0) && (e.progress > 0) && (e.progress < e.progressmax))
                {
                    tsProgress.Maximum = e.progressmax;
                    tsProgress.Value = e.progress; //* 100) / tsProgress.Maximum;
                }
            }
            catch (Exception)
            {
            }
        }

        private void cEXWB1_ScriptError(object sender, csExWB.ScriptErrorEventArgs e)
        {
            string wbname = (m_CurWB != null) ? m_CurWB.Name : "cEXWBxx";
            AllForms.m_frmLog.AppendToLog(wbname + "_ScriptError - Continuing to run scripts");
            AllForms.m_frmLog.AppendToLog("Error Message" + e.errorMessage + "\r\nLine Number" + e.lineNumber.ToString());
        }

        private void cEXWB1_SetSecureLockIcon(object sender, csExWB.SetSecureLockIconEventArgs e)
        {
            if (sender != m_CurWB)
                return;
            try
            {
                UpdateSecureLockIcon(e.securelockicon);
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog(m_CurWB.Name + "_SetSecureLockIcon" + ee.ToString());
            }
        }

        private void cEXWB1_WBContextMenu(object sender, csExWB.ContextMenuEventArgs e)
        {
            try
            {
                if (e.contextmenutype == WB_CONTEXTMENU_TYPES.CONTEXT_MENU_ANCHOR)
                {
                    e.displaydefault = false;
                    m_oHTMLCtxMenu = e.dispctxmenuobj;
                    ctxMnuWB_A.Show(e.pt);
                }
                else if (e.contextmenutype == WB_CONTEXTMENU_TYPES.CONTEXT_MENU_IMAGE)
                {
                    //If image has a HREF then enable CopyURLText image menu
                    e.displaydefault = false;
                    m_oHTMLCtxMenu = e.dispctxmenuobj;

                    ctxMnuImgCopyUrlText.Enabled = false;
                    IHTMLElement pelem = (IHTMLElement)m_oHTMLCtxMenu;
                    if (pelem != null)
                    {
                        IHTMLElement pParent = pelem.parentElement;
                        ctxMnuImgCopyUrlText.Enabled = (pParent.tagName.ToUpper() == "A") ? true : false;
                    }
                    ctxMnuImgOpenInBack.Enabled = ctxMnuImgCopyUrlText.Enabled;
                    ctxMnuImgOpenInFront.Enabled = ctxMnuImgCopyUrlText.Enabled;

                    ctxMnuWB_Img.Show(e.pt);
                }
                else if (e.contextmenutype == WB_CONTEXTMENU_TYPES.CONTEXT_MENU_CONTROL)
                {
                    AllForms.m_frmLog.AppendToLog("CONTEXT_MENU_CONTROL");
                }
                else if (e.contextmenutype == WB_CONTEXTMENU_TYPES.CONTEXT_MENU_DEFAULT)
                {
                    AllForms.m_frmLog.AppendToLog("CONTEXT_MENU_DEFAULT");
                }
                else if (e.contextmenutype == WB_CONTEXTMENU_TYPES.CONTEXT_MENU_TEXTSELECT)
                {
                    AllForms.m_frmLog.AppendToLog("CONTEXT_MENU_TEXTSELECT");
                }
                else if (e.contextmenutype == WB_CONTEXTMENU_TYPES.CONTEXT_MENU_IMGART)
                {
                    AllForms.m_frmLog.AppendToLog("CONTEXT_MENU_IMGART");
                }
                else if (e.contextmenutype == WB_CONTEXTMENU_TYPES.CONTEXT_MENU_IMGDYNSRC)
                {
                    AllForms.m_frmLog.AppendToLog("CONTEXT_MENU_IMGDYNSRC");
                }
                else if (e.contextmenutype == WB_CONTEXTMENU_TYPES.CONTEXT_MENU_TABLE)
                {
                    AllForms.m_frmLog.AppendToLog("CONTEXT_MENU_TABLE");
                }
                else if (e.contextmenutype == WB_CONTEXTMENU_TYPES.CONTEXT_MENU_UNKNOWN)
                {
                    AllForms.m_frmLog.AppendToLog("CONTEXT_MENU_UNKNOWN");
                }
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("cEXWB1_WBContextMenu\r\n" + ee.ToString());
            }
        }

        private void cEXWB1_WBDocHostShowUIShowMessage(object sender, csExWB.DocHostShowUIShowMessageEventArgs e)
        {
            string wbname = (m_CurWB != null) ? m_CurWB.Name : "cEXWBxx";
            AllForms.m_frmLog.AppendToLog(wbname + "_WBDocHostShowUIShowMessage - handled - Text\r\n" + e.text);
 
            //To stop messageboxs
            e.handled = true;
            //e.result = (int)DialogResult.OK;

            // simple alert dialog
            if (e.type == 48)
            {
                e.result = (int)MessageBox.Show(e.text, "DemoApp");
            }
            // confirm dialog
            else if (e.type == 33)
            {
                e.result = (int)MessageBox.Show(e.text, "DemoApp", MessageBoxButtons.OKCancel);
            }

       }

        private void cEXWB1_WBEvaluteNewWindow(object sender, csExWB.EvaluateNewWindowEventArgs e)
        {
            try
            {
                string str = string.Empty;
                if (e.flags == NWMF.HTMLDIALOG)
                    str = "HTML Dialog";
                else if (e.flags == NWMF.SHOWHELP)
                    str = "Show Help";
                else
                    str = e.flags.ToString();
                if (MessageBox.Show("A new EvaluteNewWindow has been requested by:\r\n" + e.url + "\r\nType:" + str + "\r\nCancel it?", "Popup Window", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                {
                    e.Cancel = true;
                }
            }
            catch (Exception nEx)
            {
                AllForms.m_frmLog.AppendToLog(m_CurWB.Name + "_WBEvaluteNewWindow\r\n" + nEx.ToString());
            }
        }

        private void cEXWB1_WBSecurityProblem(object sender, csExWB.SecurityProblemEventArgs e)
        {
            if( (e.problem == WinInetErrors.HTTP_REDIRECT_NEEDS_CONFIRMATION) ||
                (e.problem == WinInetErrors.ERROR_INTERNET_HTTP_TO_HTTPS_ON_REDIR) ||
                (e.problem == WinInetErrors.ERROR_INTERNET_HTTPS_HTTP_SUBMIT_REDIR) ||
                (e.problem == WinInetErrors.ERROR_INTERNET_HTTPS_TO_HTTP_ON_REDIR) ||
                (e.problem == WinInetErrors.ERROR_INTERNET_MIXED_SECURITY) )
            {
                e.handled = true;
                e.retvalue = Hresults.S_FALSE;
            }
                
            string wbname = (m_CurWB != null) ? m_CurWB.Name : "cEXWBxx";
            AllForms.m_frmLog.AppendToLog(wbname + "_WBSecurityProblem - Wininet Problem=" + e.problem.ToString());
        }

        private void cEXWB1_WindowClosing(object sender, csExWB.WindowClosingEventArgs e)
        {
            //Ask, or read from users options what to do. For now
            e.Cancel = true;
            AllForms.m_frmLog.AppendToLog("frmMain_cEXWB1_WindowClosing");
        }

        private void cEXWB1_WBKeyUp(object sender, csExWB.WBKeyUpEventArgs e)
        {

        }

        private void cEXWB1_WBKeyDown(object sender, csExWB.WBKeyDownEventArgs e)
        {
            //Consume keys here, if needed
            try
            {
                if (e.virtualkey == Keys.ControlKey)
                {
                    switch (e.keycode)
                    {
                        case Keys.F:
                            m_frmFind.Show(this);
                            e.handled = true;
                            break;
                        case Keys.N:
                            AddNewBrowser(m_Blank, m_AboutBlank, string.Empty, true);
                            e.handled = true;
                            break;
                        case Keys.O:
                            AddNewBrowser(m_Blank, m_AboutBlank, string.Empty, true);
                            e.handled = true;
                            break;
                    }
                }
            }
            catch (Exception eex)
            {
                if (m_CurWB != null)
                    AllForms.m_frmLog.AppendToLog(m_CurWB.Name + "_WBKeyDown\r\n" + eex.ToString());
                else
                    AllForms.m_frmLog.AppendToLog("cEXWBxx_WBKeyDown\r\n" + eex.ToString());            
            }
        }

        private void cEXWB1_DownloadBegin(object sender)
        {
            if (sender != m_CurWB)
                return;
            tsProgress.Visible = true;
        }

        private void cEXWB1_DownloadComplete(object sender)
        {
            if (sender != m_CurWB)
                return;
            tsProgress.Value = 0;
            tsProgress.Maximum = 0;
            tsProgress.Visible = false;
        }

        private void cEXWB1_RefreshBegin(object sender)
        {
            //AllForms.m_frmLog.AppendToLog("cEXWB1_RefreshBegin");
        }

        private void cEXWB1_RefreshEnd(object sender)
        {
            //AllForms.m_frmLog.AppendToLog("cEXWB1_RefreshEnd");
        }

        private void cEXWB1_FileDownload(object sender, csExWB.FileDownloadEventArgs e)
        {
            //Here is the easiest way to find out the download file name
            //m_Status is set in StatusTextChange event handler
            //After the user has clicked a downloadable link, we get a 
            //BeforeNavigate2 and then at least two calls to StatusTextChange
            //One containing a text such as below
            //Start downloading from site: http://www.codeproject.com/cs/media/cameraviewer/cv_demo.zip
            //and one that sends an empty string to clear the status text.
            //After the status calls, we should get this event fired.
            //AllForms.m_frmLog.AppendToLog("cEXWBxx_FileDownload\r\n" + m_Status);

            //Here you can cancel the download and take over.
            //e.Cancel = true;
        }
        
        private void cEXWB1_WBAuthenticate(object sender, csExWB.AuthenticateEventArgs e)
        {
            if (m_frmAuth.ShowDialogInternal(this) == DialogResult.OK)
            {
                //Default value of handled is false
                e.handled = true;
                //To pass a doamin as in a NTLM authentication scheme,
                //use this format: Username = Domain\username
                e.username = m_frmAuth.m_Username;
                e.password = m_frmAuth.m_Password;
                //Default value of retValue is 0 or S_OK
            }
        }
     
        private void cEXWB1_WBDragDrop(object sender, csExWB.WBDropEventArgs e)
        {
            if (e.dataobject == null)
                return;
            if (e.dataobject.ContainsText())
                AllForms.m_frmLog.AppendToLog("cEXWB1_WBDragDrop\r\n" + e.dataobject.GetText());
            else if (e.dataobject.ContainsFileDropList())
            {
                System.Collections.Specialized.StringCollection files = e.dataobject.GetFileDropList();
                if (files.Count > 1)
                    MessageBox.Show("Can not do multi file drop!");
                else
                {
                    if(m_CurWB != null)
                        m_CurWB.Navigate(files[0]);
                }
            }
            else
            {
                //Example of how to catch a dragdrop of a ListViewItem from frmCacheCookie form
                object obj = e.dataobject.GetData("WindowsForms10PersistentObject");
                if (obj != null)
                {
                    if (obj is ListViewItem)
                    {
                        ListViewItem ctl = (ListViewItem)obj;
                        AllForms.m_frmLog.AppendToLog("cEXWB1_WBDragDrop\r\n" + ctl.Text);
                    }
                }
            }
            //To get the available formats
            //string[] formats = obja.GetFormats();
            //foreach (string str in formats)
            //{
            //    Debug.Print("\r\n" + str);
            //}
        }

        #endregion

        #region APP Events

        public void StopAPPs()
        {
            tsToolsMnurequestResponseHeaders.Checked = false;
            cEXWB1.StopHTTPAPP();
            cEXWB1.StopHTTPSAPP();
        }

        void cEXWB1_ProtocolHandlerOnResponse(object sender, csExWB.ProtocolHandlerOnResponseEventArgs e)
        {
            if (!m_frmRequestResponseHeaders.Visible)
                return;
            csExWB.cEXWB pWB = (csExWB.cEXWB)sender;
            try
            {
                m_frmRequestResponseHeaders.AppendToLog("ProtocolHandlerOnResponse_"
                    + pWB.Name + "\r\nURL >> " + e.m_URL +
                    "\r\nResponseHeader >>\r\n" + e.m_ResponseHeaders);
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("ProtocolHandlerOnResponse_"
                    + pWB.Name + "\r\n" + ee.ToString());
            }
        }

        void cEXWB1_ProtocolHandlerOnBeginTransaction(object sender, csExWB.ProtocolHandlerOnBeginTransactionEventArgs e)
        {
            if (!m_frmRequestResponseHeaders.Visible)
                return;
            csExWB.cEXWB pWB = (csExWB.cEXWB)sender;
            try
            {
                m_frmRequestResponseHeaders.AppendToLog("ProtocolHandlerOnBeginTransaction_"
                    + pWB.Name + "\r\nURL >> " + e.m_URL +
                    "\r\nRequestHeaders >>\r\n" + e.m_RequestHeaders);
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("ProtocolHandlerOnBeginTransaction_"
                    + pWB.Name + "\r\n" + ee.ToString());
            }
        }
        #endregion

        #region File Download Events

        //private const string RESPONSE_CONTENT_LENGTH = "content-length:";
        //private const string SPACE_CHAR = " ";
        //private const string NEW_LINE = "\r\n";
        //private int m_Index = 0;
        //private int m_Begin = 0;
        //private int m_End = 0;
        //private string m_FileSize = string.Empty;
        private int m_lFileSize = 0;

        /// <summary>
        /// Called from frmFileDownload to stop a file download
        /// </summary>
        /// <param name="browsername"></param>
        /// <param name="dlUid"></param>
        public void StopFileDownload(string browsername, int dlUid)
        {
            csExWB.cEXWB pWB = FindBrowser(browsername);
            if (pWB != null)
                pWB.StopFileDownload(dlUid);
        }

        void cEXWB1_FileDownloadExAuthenticate(object sender, csExWB.FileDownloadExAuthenticateEventArgs e)
        {
            csExWB.cEXWB pWB = (csExWB.cEXWB)sender;
            try
            {
                if (m_frmAuth.ShowDialogInternal(this) == DialogResult.OK)
                {
                    e.Cancel = false; //default value true
                    //To pass a doamin as in a NTLM authentication scheme,
                    //use this format: Username = Domain\username
                    e.username = m_frmAuth.m_Username;
                    e.password = m_frmAuth.m_Password;
                }
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog(pWB.Name + "_FileDownloadExAuthenticate" + ee.ToString());
            }
        }

        void cEXWB1_FileDownloadExError(object sender, csExWB.FileDownloadExErrorEventArgs e)
        {
            csExWB.cEXWB pWB = (csExWB.cEXWB)sender;
            try
            {
                m_frmFileDownload.DeleteDownloadItem(pWB.Name, e.m_dlUID, e.m_URL,  "Error");
                AllForms.m_frmLog.AppendToLog("An error occured during downloading of " + e.m_URL + "\r\n" + e.m_ErrorMsg);

            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog(pWB.Name + "_FileDownloadExError" + ee.ToString());
            }
        }

        void cEXWB1_FileDownloadExProgress(object sender, csExWB.FileDownloadExProgressEventArgs e)
        {
            csExWB.cEXWB pWB = (csExWB.cEXWB)sender;
            try
            {
                m_frmFileDownload.UpdateDownloadItem(pWB.Name, e.m_dlUID, e.m_URL, e.m_Progress, e.m_ProgressMax);
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog(pWB.Name + "_FileDownloadExProgress" + ee.ToString());
            }
        }

        void cEXWB1_FileDownloadExEnd(object sender, csExWB.FileDownloadExEndEventArgs e)
        {
            csExWB.cEXWB pWB = (csExWB.cEXWB)sender;
            try
            {
                m_frmFileDownload.DeleteDownloadItem(pWB.Name, e.m_dlUID, e.m_URL,  "Completed");
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog(pWB.Name + "_FileDownloadExEnd" + ee.ToString());
            }
        }

        //A typical file attachment header from hotmail
        //HTTP/1.1 200 OK
        //Date: Mon, 20 Aug 2007 12:02:06 GMT
        //Server: Microsoft-IIS/6.0
        //P3P: CP="BUS CUR CONo FIN IVDo ONL OUR PHY SAMo TELo"
        //xxn:18
        //X-Powered-By: ASP.NET
        //Content-Length: 24955
        //Content-Disposition: attachment; filename="TabStrip.zip"
        //MSNSERVER: H: BAY139-W18 V: 11.10.0.115 D: 2007-07-09T20:51:32
        //Set-Cookie: KVC=11.10.0000.0115; domain=.mail.live.com; path=/
        //Cache-Control: private
        //Content-Type: application/x-zip-compressed

        void cEXWB1_FileDownloadExStart(object sender, csExWB.FileDownloadExEventArgs e)
        {
            csExWB.cEXWB pWB = (csExWB.cEXWB)sender;
            try
            {
                if (!string.IsNullOrEmpty(e.m_FileSize))
                    //AllForms.m_frmLog.AppendToLog(e.m_Filename + "\r\n" + e.m_FileSize + "\r\n" + e.m_ExtraHeaders);
                    m_lFileSize = int.Parse(e.m_FileSize);
                else
                    m_lFileSize = 0;
                //Send progress events. default false
                e.m_SendProgressEvents = true;
                //The initial value of FileDownloadDirectory defaults to MyDocuments dir
                e.m_PathToSave = pWB.FileDownloadDirectory + e.m_Filename;
                m_frmFileDownload.AddDownloadItem(pWB.Name, e.m_Filename, e.m_URL,  e.m_dlUID, e.m_URL, e.m_PathToSave, m_lFileSize);
                if (!m_frmFileDownload.Visible)
                    m_frmFileDownload.Show(this);
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog(pWB.Name + "_FileDownloadExStart" + ee.ToString());
            }
        }
        #endregion

    }



}