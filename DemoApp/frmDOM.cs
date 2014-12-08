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
    public partial class frmDOM : Form
    {
        #region FORM related
        public frmDOM()
        {
            InitializeComponent();
        }

        private void frmDOM_Load(object sender, EventArgs e)
        {
            this.Icon = AllForms.BitmapToIcon(34);
        }

        private void frmDOM_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                treeDOM.Nodes.Clear();
            }
        } 
        #endregion

        private void saveTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeDOM.Nodes.Count == 0)
                    return;

                if (AllForms.ShowStaticSaveDialogForXML(this) == DialogResult.OK)
                {
                    TreeViewSerializer savetree = new TreeViewSerializer();
                    savetree.SerializeTreeView(treeDOM, AllForms.m_dlgSave.FileName);
                }
            }
            catch (Exception ee)
            {
                AllForms.m_frmLog.AppendToLog("frmDOM::saveTreeToolStripMenuItem_Click\r\n" + ee.ToString());
            }
        }

        #region DOM Walker
        /*        
        document.documentElement points to the root element of the 
        DOM tree. Starting from there you could recursively visit 
        the whole tree using each element's childNodes. To identify
        nodes, use nodeName and nodeType properties. i.e.
        A comment node has a nodeName "#comment" and a nodeType of ???.
        
        //To get specific attributes for a node
        //This is very slow in .NET
        IHTMLAttributeCollection attrcol = (IHTMLAttributeCollection)nd.attributes;
        foreach (IHTMLDOMAttribute domattr in attrcol)
        {
            if (domattr.specified)
            {
                //do something
            }
        }
        */

        private const string TEXTNODE = "#text";
        private const string COMMENTNODE = "#comment";
        private const string FRAMENODE = "FRAME";
        private const string BASENODE = "BASE";
        private const string BODYNODE = "BODY";
        private const string VALUESEPERATOR = " \"";
        private const string VALUESEPERATOR1 = "\"";

        /// <summary>
        /// Standalone DOM walker - much like IEDeveloper toolbar
        /// Starting point to walk the DOM
        /// </summary>
        /// <param name="DocumentObject">Webbrowser.Document object</param>
        public void LoadDOM(object DocumentObject)
        {
            treeDOM.Nodes.Clear();

            IHTMLDocument3 doc3 = DocumentObject as IHTMLDocument3;
            IHTMLDOMNode domnode = (IHTMLDOMNode)doc3.documentElement;
            //Start walking
            if (domnode != null)
                parseNodes(domnode, null);
            if (treeDOM.Nodes.Count > 0)
                treeDOM.Nodes[0].Expand();
        }

        /// <summary>
        /// Recursive method to walk the DOM, acounts for frames
        /// </summary>
        /// <param name="nd">Parent DOM node to walk</param>
        /// <param name="node">Parent tree node to populate</param>
        /// <returns></returns>
        private TreeNode parseNodes(IHTMLDOMNode nd, TreeNode node)
        {
            string str = nd.nodeName;
            TreeNode nextnode = null;

            //Add a new node to tree
            if (node != null)
                nextnode = node.Nodes.Add(str);
            else
                nextnode = treeDOM.Nodes.Add(str);

            //For each child, get children collection
            //And continue walking up and down the DOM
            try
            {
                //Frame?
                if (str == FRAMENODE)
                {
                    //Get the nd.IWebBrowser2.IHTMLDocument3.documentelement and recurse
                    IWebBrowser2 wb = (IWebBrowser2)nd;
                    IHTMLDocument3 doc3 = (IHTMLDocument3)wb.Document;

                    IHTMLDOMNode tempnode = (IHTMLDOMNode)doc3.documentElement;
                    //get the comments for this node, if any
                    IHTMLDOMChildrenCollection framends = (IHTMLDOMChildrenCollection)doc3.childNodes;
                    foreach (IHTMLDOMNode tmpnd in framends)
                    {
                        str = tmpnd.nodeName;
                        if (COMMENTNODE == str)
                        {
                            if (tmpnd.nodeValue != null)
                                str += VALUESEPERATOR + tmpnd.nodeValue.ToString() + VALUESEPERATOR1;
                            if (nextnode != null) nextnode.Nodes.Add(str);
                        }
                    }
                    //parse document
                    parseNodes(tempnode, nextnode);
                    return nextnode;
                }

                //Get the DOM collection
                string strdom = string.Empty;
                IHTMLDOMChildrenCollection nds = (IHTMLDOMChildrenCollection)nd.childNodes;
                foreach (IHTMLDOMNode childnd in nds)
                {
                    strdom = childnd.nodeName;
                    //Attempt to extract text and comments
                    if ((COMMENTNODE == strdom) || (TEXTNODE == strdom))
                    {
                        if (childnd.nodeValue != null)
                            strdom += VALUESEPERATOR + childnd.nodeValue.ToString() + VALUESEPERATOR1;
                        //Add a new node to tree
                        if (nextnode != null) nextnode.Nodes.Add(strdom);
                    }
                    else
                    {
                        if ((BODYNODE == strdom) &&
                            (str == BASENODE))
                        {
                            //In MSDN, one of the inner FRAMEs BASE element
                            //contains the BODY element???
                            //Do nothing
                        }
                        else
                            parseNodes(childnd, nextnode);
                    }
                }

            }
            catch (System.InvalidCastException icee)
            {
                Console.Write("\r\n InvalidCastException =" +
                    icee.ToString() + "\r\nName =" +
                    str + " \r\n");
            }
            catch (Exception) //Anything else throw it
            {
                throw;
            }
            return nextnode;
        } 
        #endregion

    }
}