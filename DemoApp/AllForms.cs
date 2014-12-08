using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IfacesEnumsStructsClasses;
using System.IO;

namespace DemoApp
{
    #region AllForms class
    /// <summary>
    /// Simple class to encapsulate global forms, controls, consts, and methods
    /// </summary>
    public sealed class AllForms
    {
        public const string COOKIE = "Cookie:";
        public const string VISITED = "Visited:";
        public const string DLG_HTMLS_FILTER = "Html files (*.html)|*.html|Htm files (*.htm)|*.htm|Text files (*.txt)|*.txt|All files (*.*)|*.*";
        public const string DLG_XMLS_FILTER = "XML files (*.xml)|*.xml";
        public const string DLG_TEXTFILES_FILTER = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
        public const string DLG_IMAGES_FILTER = "Bmp files (*.bmp)|*.bmp" +
                        "|Gif files (*.gif)|*.gif" +
                        "|Jpeg files (*.Jpeg)|*.Jpeg" +
                        "|Png files (*.png)|*.png" +
                        "|Wmf files (*.wmf)|*.wmf" +
                        "|Tiff files (*.tiff)|*.tiff" +
                        "|Emf files (*.emf)|*.emf";

        public static frmLog m_frmLog = new frmLog();
        public static frmDynamicConfirm m_frmDynamicConfirm = new frmDynamicConfirm();
        public static frmInput m_frmInput = new frmInput();
        public static ImageList m_imgListMain = new ImageList();
        public static SaveFileDialog m_dlgSave = new SaveFileDialog();
        public static OpenFileDialog m_dlgOpen = new OpenFileDialog();

        public static Icon BitmapToIcon(Image orgImage)
        {
            Icon icoRet = null;
            if (orgImage == null)
                return icoRet;
            Bitmap bmp = new Bitmap(orgImage);
            icoRet = Icon.FromHandle(bmp.GetHicon());
            bmp.Dispose();
            return icoRet;
        }

        //Using m_imgListMain static member
        public static Icon BitmapToIcon(int orgImage)
        {
            Icon icoRet = null;
            if (AllForms.m_imgListMain.Images.Count > 0)
            {
                Bitmap bmp = new Bitmap(AllForms.m_imgListMain.Images[orgImage]);
                icoRet = Icon.FromHandle(bmp.GetHicon());
                bmp.Dispose();
            }
            return icoRet;
        }

        //replace = visited: or cookie:
        public static string SetupCookieCachePattern(string pattern, string replace)
        {
            const string COOKIECACHEPATTERN = ".*";
            const string DOT = ".";
            const string BACKSLASHDOT = "\\.";

            string url = pattern;
            if (url.Length > 0)
            {
                Uri curUri = new Uri(url);
                url = curUri.Host;
                //Replace "." with "\\."
                url = url.Replace(DOT, BACKSLASHDOT);
                url = replace + COOKIECACHEPATTERN + url;

                //www.google.com
                //visited:.*www\\.google\\.com

                //login.live.com
                //cookie:.*login\\.live\\.com

            }
            return url;
        }

        /// <summary>
        /// A little shortcut when asking for yes or no type of confirmation
        /// </summary>
        /// <param name="Msg"></param>
        /// <param name="Win"></param>
        /// <returns></returns>
        public static bool AskForConfirmation(string Msg, IWin32Window Win)
        {
            const string CONFIRMATIONREQUESTED = "Confirmation Requested";
            DialogResult result = MessageBox.Show(Win, Msg, CONFIRMATIONREQUESTED, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return (result == DialogResult.Yes) ? true : false;
        }

        /// <summary>
        /// To display a save dialog from any form within this project
        /// </summary>
        /// <param name="defaultext">If empty, "txt" is used.</param>
        /// <param name="filename">Name or Name.ext</param>
        /// <param name="filter">If empty, Textual filter is used.</param>
        /// <param name="title">if empty, "Save File" is used.</param>
        /// <param name="initialdir">If empty, current directory is used.</param>
        /// <returns></returns>
        public static DialogResult ShowStaticSaveDialog(IWin32Window Win,
            string defaultext, string filename,
            string filter, string title, string initialdir)
        {
            if (string.IsNullOrEmpty(defaultext))
                AllForms.m_dlgSave.DefaultExt = "txt";
            else
                AllForms.m_dlgSave.DefaultExt = defaultext;

            if (string.IsNullOrEmpty(filename))
                AllForms.m_dlgSave.FileName = "FileName";
            else
                AllForms.m_dlgSave.FileName = filename;

            if (string.IsNullOrEmpty(filter))
                AllForms.m_dlgSave.Filter = DLG_TEXTFILES_FILTER;
            else
                AllForms.m_dlgSave.Filter = filter;

            if (string.IsNullOrEmpty(title))
                AllForms.m_dlgSave.Title = "Save File";
            else
                AllForms.m_dlgSave.Title = title;

            if (string.IsNullOrEmpty(initialdir))
                AllForms.m_dlgSave.InitialDirectory = Environment.CurrentDirectory;
            else
                AllForms.m_dlgSave.InitialDirectory = initialdir;

            return AllForms.m_dlgSave.ShowDialog(Win);
        }

        public static DialogResult ShowStaticSaveDialogForHTML(IWin32Window Win)
        {
            return ShowStaticSaveDialog(Win, string.Empty, string.Empty, DLG_HTMLS_FILTER, string.Empty, string.Empty);
        }

        public static DialogResult ShowStaticSaveDialogForText(IWin32Window Win)
        {
            return ShowStaticSaveDialog(Win, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
        }

        public static DialogResult ShowStaticSaveDialogForImage(IWin32Window Win)
        {
            return ShowStaticSaveDialog(Win, "bmp", "ImageFileName", DLG_IMAGES_FILTER, "Save Image", string.Empty);
        }

        public static DialogResult ShowStaticSaveDialogForXML(IWin32Window Win)
        {
            return ShowStaticSaveDialog(Win, "xml", "XMLFileName", DLG_XMLS_FILTER, "Save XML", string.Empty);
        }

        public static DialogResult ShowStaticOpenDialog(IWin32Window Win,
            string filter, string title, string initialdir, bool showreadonly)
        {
            AllForms.m_dlgOpen.Filter = filter;

            if (string.IsNullOrEmpty(title))
                AllForms.m_dlgOpen.Title = "Open File";
            else
                AllForms.m_dlgOpen.Title = title;

            if (string.IsNullOrEmpty(initialdir))
                AllForms.m_dlgOpen.InitialDirectory = Environment.CurrentDirectory;
            else
                AllForms.m_dlgOpen.InitialDirectory = initialdir;

            AllForms.m_dlgOpen.ShowReadOnly = showreadonly;

            return AllForms.m_dlgOpen.ShowDialog(Win);
        }

        public static void LoadWebColors(ComboBox combo)
        {
            Array knownColors = Enum.GetValues(typeof(System.Drawing.KnownColor));
            //First add an empty color
            combo.Items.Add(Color.Empty);
            //Then the rest
            foreach (KnownColor k in knownColors)
            {
                Color c = Color.FromKnownColor(k);

                if (!c.IsSystemColor && (c.A > 0))
                {
                    combo.Items.Add(c);
                }
            }
            //Select default
            combo.SelectedIndex = 0;
        }

    }
    #endregion
}
