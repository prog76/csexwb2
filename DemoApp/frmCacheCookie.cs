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
    public partial class frmCacheCookie : Form
    {
        public frmCacheCookie()
        {
            InitializeComponent();
        }

        private string m_CurOp = string.Empty;
        private void AdjustThisText()
        {
            this.Text = "Found " + lsvCacheCookie.Items.Count.ToString() + m_CurOp;
        }

        public int ClearAllCookies(string FromSite)
        {
            int ideleted = 0;
            System.Collections.ArrayList results = WinApis.FindUrlCacheEntries(
                AllForms.SetupCookieCachePattern(FromSite, AllForms.COOKIE));
            foreach (INTERNET_CACHE_ENTRY_INFO entry in results)
            {
                //Must have a SourceUrlName and LocalFileName
                if (
                    (!string.IsNullOrEmpty(entry.lpszSourceUrlName)) &&
                    (entry.lpszSourceUrlName.Trim().Length > 0) &&
                    (!string.IsNullOrEmpty(entry.lpszLocalFileName)) &&
                    (entry.lpszLocalFileName.Trim().Length > 0)
                    )
                {
                    WinApis.DeleteUrlCacheEntry(entry.lpszSourceUrlName);
                    ideleted++;
                }
            }
            return ideleted;
        }

        public int ClearAllCache(string FromSite)
        {
            int ideleted = 0;

            System.Collections.ArrayList results = WinApis.FindUrlCacheEntries(
                AllForms.SetupCookieCachePattern(FromSite, AllForms.VISITED));
            foreach (INTERNET_CACHE_ENTRY_INFO entry in results)
            {
                //Avoid Null or empty entries
                if ((!string.IsNullOrEmpty(entry.lpszSourceUrlName)) &&
                    (entry.lpszSourceUrlName.Trim().Length > 0))
                {
                    WinApis.DeleteUrlCacheEntry(entry.lpszSourceUrlName);
                    ideleted++;
                }
            }

            return ideleted;
        }
        
        public int LoadListViewItems(string pattern)
        {
            if (pattern.StartsWith(AllForms.COOKIE))
                m_CurOp = " cookies";
            else
                m_CurOp = " cache entries";
            //Reset
            lsvCacheCookie.Items.Clear();
            Int64 size = 0;
            int index = 0;
            System.Collections.ArrayList results = WinApis.FindUrlCacheEntries(pattern);
            foreach (INTERNET_CACHE_ENTRY_INFO entry in results)
            {
                if ( (!string.IsNullOrEmpty(entry.lpszSourceUrlName)) &&
                    (entry.lpszSourceUrlName.Trim().Length > 0) )
                {
                    ListViewItem item = new ListViewItem();
                    lsvCacheCookie.Items.Add(item);

                    item.SubItems[0].Text = entry.lpszSourceUrlName;
                    if( (!string.IsNullOrEmpty(entry.lpszLocalFileName)) &&
                        (entry.lpszLocalFileName.Trim().Length > 0) )
                        item.SubItems.Add(entry.lpszLocalFileName);
                    else
                        item.SubItems.Add(string.Empty);
                    item.SubItems.Add(WinApis.ToStringFromFileTime(entry.LastModifiedTime));
                    item.SubItems.Add(WinApis.ToStringFromFileTime(entry.LastAccessTime));
                    item.SubItems.Add(WinApis.ToStringFromFileTime(entry.ExpireTime));
                    try
                    {
                        size = (((Int64)entry.dwSizeHigh) << 32) + entry.dwSizeLow;
                    }
                    catch (Exception)
                    {
                        size = 0;
                    }
                    finally
                    {
                        item.SubItems.Add(size.ToString());
                    }
                }
                index++;
            }
            AdjustThisText();
            return index;
        }

        private void frmCacheCookie_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                lsvCacheCookie.Items.Clear();
            }
        }

        private void frmCacheCookie_Load(object sender, EventArgs e)
        {
            //Add some icons
            this.Icon = AllForms.BitmapToIcon(5);
            toolStripButtonDelSelected.Image = AllForms.m_imgListMain.Images[29];
            toolStripButtonDelChecked.Image = AllForms.m_imgListMain.Images[39];
            toolStripButtonDelAll.Image = AllForms.m_imgListMain.Images[40];

            //To demonstrate of handling of a listviewitem dragdrop on a csEXWB control
            lsvCacheCookie.ItemDrag += new ItemDragEventHandler(lsvCacheCookie_ItemDrag);
        }

        void lsvCacheCookie_ItemDrag(object sender, ItemDragEventArgs e)
        {
            lsvCacheCookie.DoDragDrop(e.Item, DragDropEffects.All);
        }

        private void toolStripButtonDelSelected_Click(object sender, EventArgs e)
        {
            try
            {
                ListView.SelectedListViewItemCollection selitems = lsvCacheCookie.SelectedItems;
                if (selitems.Count == 0)
                    return;
                if (!AllForms.AskForConfirmation(
                    "Proceed to delete " + selitems.Count.ToString() + 
                    " selected items?", this))
                    return;
                foreach (ListViewItem item in selitems)
                {
                    WinApis.DeleteUrlCacheEntry(item.SubItems[0].Text);
                    lsvCacheCookie.Items.Remove(item);
                }
                AdjustThisText();
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("toolStripButtonDelSelected_Click:\r\n" + ee.ToString());
            }
        }

        private void toolStripButtonDelChecked_Click(object sender, EventArgs e)
        {
            try
            {
                ListView.CheckedListViewItemCollection checkeditems = lsvCacheCookie.CheckedItems;
                if (checkeditems.Count == 0)
                    return;
                if (!AllForms.AskForConfirmation(
                    "Proceed to delete " + checkeditems.Count.ToString() +
                    " checked items?", this))
                    return;
                foreach (ListViewItem item in checkeditems)
                {
                    WinApis.DeleteUrlCacheEntry(item.SubItems[0].Text);
                    lsvCacheCookie.Items.Remove(item);
                }
                AdjustThisText();
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("toolStripButtonDelChecked_Click:\r\n" + ee.ToString());
            }
        }

        private void toolStripButtonDelAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvCacheCookie.Items.Count == 0)
                    return;
                if (!AllForms.AskForConfirmation(
                    "Proceed to delete all " + lsvCacheCookie.Items.Count.ToString() +
                    " items?", this))
                    return;
                foreach (ListViewItem item in lsvCacheCookie.Items)
                {
                    WinApis.DeleteUrlCacheEntry(item.SubItems[0].Text);
                }
                lsvCacheCookie.Items.Clear();
                AdjustThisText();
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("toolStripButtonDelAll_Click:\r\n" + ee.ToString());
            }
        }
    }
}