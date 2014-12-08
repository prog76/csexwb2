using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class frmFileDownload : Form
    {
        private ProgressBar m_pb = null;
        private List<ProgressBar> m_pbList = new List<ProgressBar>();
        public frmFileDownload()
        {
            InitializeComponent();
            this.AddDownloadItem("csexwb1", "filename.zip", "http://www.google.com", 1, "http://www.google.com", "C:\\", 4000);
            lvDownloads.ColumnWidthChanging += new ColumnWidthChangingEventHandler(lvDownloads_ColumnWidthChanging);
            lvDownloads.Resize += new EventHandler(lvDownloads_Resize);
        }

        void lvDownloads_Resize(object sender, EventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        void lvDownloads_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        public bool NotifyEndDownload
        {
            get
            {
                return tsNotifyEndDownload.Checked;
            }
        }

        private struct DLIDS
        {
            public string BrowserName;
            public string FileName;
            public string URL;
            public int DlUid;
            public int FileSize;
            public bool DlDone;

            public DLIDS(string browsername_,string filename_,string url_, int dluid_, int filesize_)
            {
                BrowserName = browsername_;
                FileName = filename_;
                URL = url_;
                DlUid = dluid_;
                FileSize = filesize_;
                DlDone = false;
            }
        }
        private int m_TotalDownloads = 0;
        private void UpdateThisText(bool add)
        {
            if (add)
                m_TotalDownloads++;
            else
                m_TotalDownloads--;
            this.Text = "<< " + m_TotalDownloads.ToString() + " >> File Download(s) in progress....";
        }

        public void AddDownloadItem(string browsername, string filename, string url, int uDlId, string FromUrl, string ToPath, int filesize)
        {
            ListViewItem item = new ListViewItem();
            item.SubItems[0].Text = FromUrl;    //0 URL
            item.SubItems.Add(ToPath);          //1 Local file
            item.SubItems.Add("Downloading");   //2 Status
            item.SubItems.Add("0");             //3 Bytes Received
            if (filesize > 0)
                item.SubItems.Add("%0");            //4 Percentage
            else
                item.SubItems.Add("Unknown");
            DLIDS id = new DLIDS(browsername, filename, url, uDlId, filesize);
            item.Tag = id;
            lvDownloads.Items.Add(item);

            UpdateThisText(true);
        }

        public void UpdateDownloadItem(string browsername, int uDlId, string url, int progress, int progressmax)
        {
            DLIDS id = new DLIDS();
            foreach (ListViewItem item in lvDownloads.Items)
            {
                id = (DLIDS)item.Tag;
                if ((id.DlUid == uDlId) &&
                    (id.URL == url) &&
                    (id.BrowserName == browsername))
                {
                    if (progress > 0)
                    {
                        if( (id.FileSize > 0) && (id.FileSize > progress) )
                        {
                            item.SubItems[4].Text = ((progress * 100) / id.FileSize).ToString() + "%";
                            item.SubItems[3].Text = progress.ToString();
                        }
                        else
                        {
                            //last progress will contain actual file size
                            item.SubItems[3].Text = progress.ToString();
                        }
                    }
                    return;
                }
            }
        }

        public void DeleteDownloadItem(string browsername, int uDlId, string url, string Msg)
        {
            DLIDS id = new DLIDS();
            ListViewItem delitem = null;
            foreach (ListViewItem item in lvDownloads.Items)
            {
                id = (DLIDS)item.Tag;
                if ((id.DlUid == uDlId) &&
                    (id.URL == url) &&
                    (id.BrowserName == browsername))
                {
                    id.DlDone = true;
                    delitem = item;
                    if(id.FileSize > 0)
                        item.SubItems[3].Text = id.FileSize.ToString();
                    item.SubItems[4].Text = "%100";
                    break;
                }
            }

            //Here rather than deleting a dl, we can mark it as downloaded
            //and keep a log of the dls
            if (delitem != null)
            {
                delitem.SubItems[2].Text = Msg;
                if (Msg == "completed")
                    delitem.BackColor = Color.LightGreen;
                else
                    delitem.BackColor = Color.LightPink;
                
                //lvDownloads.Items.Remove(delitem);
                UpdateThisText(false);
                if (NotifyEndDownload)
                    MessageBox.Show(this, "Finished downloading\r\n" + delitem.SubItems[0].Text + "\r\nTO:\r\n" + delitem.SubItems[1].Text);
            }
        }

        private void frmFileDownload_Load(object sender, EventArgs e)
        {
            this.Icon = AllForms.BitmapToIcon(45);
            m_pb = new ProgressBar();
            m_pb.Name = "DownloadPB";
            //m_pb.Visible = false;
            m_pb.Parent = lvDownloads;
            m_pb.Style = ProgressBarStyle.Continuous;
            m_pb.Value = 50;
            m_pb.Bounds = lvDownloads.Items[0].SubItems[4].Bounds;
        }

        private void frmFileDownload_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == tsStopDownload.Name)
            {
                if (lvDownloads.SelectedItems.Count > 0)
                {
                    ListViewItem item = lvDownloads.SelectedItems[0];
                    if( (item != null) && (this.Owner != null) )
                    {
                        DLIDS id = (DLIDS)item.Tag;
                        ((frmMain)this.Owner).StopFileDownload(id.BrowserName, id.DlUid);
                    }
                }
            }
            else if (e.ClickedItem.Name == tsCloseDownload.Name)
            {
                this.Hide();
            }
            else if (e.ClickedItem.Name == tsBtnRemoveCompleted.Name)
            {
                try
                {
                    DLIDS id = new DLIDS();
                    for (int i = lvDownloads.Items.Count - 1; i > -1; i--)
                    {
                        id = (DLIDS)lvDownloads.Items[i].Tag;
                        if (id.DlDone)
                            lvDownloads.Items.RemoveAt(i);
                    }
                }
                catch (Exception ee)
                {
                    AllForms.m_frmLog.AppendToLog(this.Name +  "_toolStrip1_ItemClicked_tsBtnRemoveCompleted\r\n" + ee.ToString());
                }
            }
        }
    }
}