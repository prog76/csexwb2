using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IfacesEnumsStructsClasses;
using System.Runtime.InteropServices;
using System.IO;

namespace DemoApp
{
    public partial class frmDocInfo : Form
    {
        public frmDocInfo()
        {
            InitializeComponent();
        }

        private void frmDocInfo_Load(object sender, EventArgs e)
        {
            this.Icon = AllForms.BitmapToIcon(34);
        }

        private void frmDocInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                treeDocInfo.Nodes.Clear();
                txtDocInfo.Clear();
            }
        }
        
        /// <summary>
        /// Loads document information into the Tree
        /// Uses each node.Tag to store information
        /// </summary>
        /// <param name="pWB">An instance of csExWB.cEXWB</param>
        public void LoadDocumentInfo(csExWB.cEXWB pWB)
        {
            treeDocInfo.Nodes.Clear();
            txtDocInfo.Clear();
            IHTMLDocument2 doc2 = null;

            //First fill in the main document information
            TreeNode root = treeDocInfo.Nodes.Add("Main Document");

            TreeNode node = root.Nodes.Add("HTML");
            TreeNode subnode = node.Nodes.Add("Title");
            subnode.Tag = pWB.GetTitle(true);
            doc2 = (IHTMLDocument2)pWB.WebbrowserObject.Document;
            subnode = node.Nodes.Add("URL");
            subnode.Tag = doc2.url;
            subnode = node.Nodes.Add("Domain");
            subnode.Tag = doc2.domain;
            subnode = node.Nodes.Add("Protocol");
            subnode.Tag = doc2.protocol;
            subnode = node.Nodes.Add("Cookie");
            subnode.Tag = doc2.cookie;
            subnode = node.Nodes.Add("Referrer");
            subnode.Tag = doc2.referrer;
            subnode = node.Nodes.Add("Last Modified");
            subnode.Tag = doc2.lastModified;
            subnode = node.Nodes.Add("Source");
            subnode.Tag = pWB.GetSource(pWB.WebbrowserObject); //pWB.GetSource(true);
            subnode = node.Nodes.Add("Text");
            subnode.Tag = pWB.GetText(true);

            //or pWB.GetImages(true);
            IHTMLElementCollection elems = (IHTMLElementCollection)doc2.images;
            subnode = node.Nodes.Add("Images");
            IHTMLImgElement img = null;
            string str = string.Empty;
            foreach (IHTMLElement elem in elems)
            {
                if (elem != null)
                {
                    img = (IHTMLImgElement)elem;
                    str += Environment.NewLine + img.src;
                }
            }
            subnode.Tag = str;
            
            //
            //Other collections
            //

            //elems = (IHTMLElementCollection)doc2.anchors;
            //subnode = node.Nodes.Add("Links");

            //elems = (IHTMLElementCollection)doc2.scripts;
            //subnode = node.Nodes.Add("Java Scripts");

            //IHTMLMetaElement meta = null;
            //IHTMLElementCollection col = (IHTMLElementCollection)pWB.GetElementsByTagName(true, "meta");
            //foreach (IHTMLElement elem in col)
            //{
            //    meta = (IHTMLMetaElement)elem;
            //    if (meta != null)
            //    {
            //        AllForms.m_frmLog.AppendToLog("\r\nhttpEquiv=" + meta.httpEquiv + "\r\nname=" + meta.name +
            //            "\r\nurl=" + meta.url + "\r\ncharset=" + meta.charset + "\r\ncontent=" + meta.content);
            //    }
            //    meta = null;
            //}

            //IFRAME
            //elem.getAttribute("src", 0) + "\r\n" +
            IHTMLElementCollection col = pWB.GetElementsByTagName(true, "IFRAME") as IHTMLElementCollection;
            if (col != null)
            {
                foreach (IHTMLElement elem in col)
                {
                    if (elem != null)
                    {
                        subnode = root.Nodes.Add("IFrame");
                        subnode.Tag = elem.outerHTML;
                    }
                }
            }

            //If frameset, we add the frames
            if (pWB.IsFrameset())
            {
                TreeNode framenode = root.Nodes.Add("FRAMES");
                List<IWebBrowser2> frames = pWB.GetFrames();
                foreach (IWebBrowser2 wb in frames)
                {
                    node = framenode.Nodes.Add("HTML");
                    subnode = node.Nodes.Add("Title");
                    subnode.Tag = pWB.GetTitle(wb);
                    doc2 = (IHTMLDocument2)wb.Document;
                    subnode = node.Nodes.Add("URL");
                    subnode.Tag = doc2.url;
                    subnode = node.Nodes.Add("Domain");
                    subnode.Tag = doc2.domain;
                    subnode = node.Nodes.Add("Protocol");
                    subnode.Tag = doc2.protocol;
                    subnode = node.Nodes.Add("Cookie");
                    subnode.Tag = doc2.cookie;
                    subnode = node.Nodes.Add("Referrer");
                    subnode.Tag = doc2.referrer;
                    subnode = node.Nodes.Add("Last Modified");
                    subnode.Tag = doc2.lastModified;
                    subnode = node.Nodes.Add("Source");
                    subnode.Tag = pWB.GetSource(wb);
                    subnode = node.Nodes.Add("Text");
                    subnode.Tag = pWB.GetText(wb);
                }
            }

            //Expand the root
            root.Expand();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtDocInfo.Copy();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Save as text
                if (AllForms.ShowStaticSaveDialogForText(this) == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(AllForms.m_dlgSave.FileName))
                    {
                        sw.Write(txtDocInfo.Text);
                    }
                }
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("frmDocInfo::saveToolStripMenuItem_Click\r\n" + ee.ToString());
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtDocInfo.SelectAll();
        }

        private void saveAsXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeDocInfo.Nodes.Count == 0)
                    return;

                if (AllForms.ShowStaticSaveDialogForXML(this) == DialogResult.OK)
                {
                    TreeViewSerializer savetree = new TreeViewSerializer();
                    savetree.SerializeTreeView(treeDocInfo, AllForms.m_dlgSave.FileName);
                }
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("frmDocInfo::saveAsXMLToolStripMenuItem_Click\r\n" + ee.ToString());
            }
        }

        private void treeDocInfo_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                txtDocInfo.Clear();
                if ((e.Node != null) && (e.Node.Tag != null))
                {
                    txtDocInfo.Text = e.Node.Tag.ToString();
                }
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("treeDocInfo_NodeMouseClick\r\n" + ee.ToString());
            }
        }

    }
}