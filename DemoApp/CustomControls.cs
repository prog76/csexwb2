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
    /// Five simple custom controls
    /// Two ComboBox and ToolStripComboBox based controls
    /// ToolStripCustomComboBox can be used directly from a ToolStrip in design time
    /// each combobox can display text, fonts, web colors, and image+text
    /// A RichTextBox based control with simple syntx highlighting
    /// A SplitContainer based control with visual cues for collapsing panels, ...
    /// A ToolstripDropdown control for selecting HTML colors
    /// </summary>
    #region Custom Controls

    #region CustomComboBox class
    public class CustomComboBox : ComboBox
    {
        public enum CustomComboBoxType
        {
            Type_Text = 0, //Default, acts as a normal combo
            Type_Font = 1,
            Type_HTML_Color = 2,
            Type_Image = 3
        }

        public CustomComboBox()
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.DrawMode = DrawMode.OwnerDrawFixed;
        }

        private CustomComboBoxType m_DisplayType = CustomComboBoxType.Type_Text;
        public CustomComboBoxType DisplayType
        {
            get { return m_DisplayType; }
        }

        private ImageList m_ImageList = null;
        public ImageList Images
        {
            get { return m_ImageList; }
            set { m_ImageList = value; }
        }

        private void LoadHtmlColors()
        {
            Array knownColors = Enum.GetValues(typeof(System.Drawing.KnownColor));
            //First add an empty color
            this.Items.Add(Color.Empty);
            //Then the rest
            foreach (KnownColor k in knownColors)
            {
                Color c = Color.FromKnownColor(k);

                if (!c.IsSystemColor && (c.A > 0))
                {
                    this.Items.Add(c);
                }
            }
            //Select default
            this.SelectedIndex = 0;
        }

        private void LoadFonts()
        {
            // Gets the list of installed fonts.
            FontFamily[] ff = FontFamily.Families;

            // Loop and create a sample of each font.
            for (int x = 0; x < ff.Length; x++)
            {
                System.Drawing.Font font = null;

                // Create the font - based on the styles available.
                if (ff[x].IsStyleAvailable(FontStyle.Regular))
                    font = new System.Drawing.Font(
                        ff[x].Name,
                        this.Font.Size
                        );
                else if (ff[x].IsStyleAvailable(FontStyle.Bold))
                    font = new System.Drawing.Font(
                        ff[x].Name,
                        this.Font.Size,
                        FontStyle.Bold
                        );
                else if (ff[x].IsStyleAvailable(FontStyle.Italic))
                    font = new System.Drawing.Font(
                        ff[x].Name,
                        this.Font.Size,
                        FontStyle.Italic
                        );
                else if (ff[x].IsStyleAvailable(FontStyle.Strikeout))
                    font = new System.Drawing.Font(
                        ff[x].Name,
                        this.Font.Size,
                        FontStyle.Strikeout
                        );
                else if (ff[x].IsStyleAvailable(FontStyle.Underline))
                    font = new System.Drawing.Font(
                        ff[x].Name,
                        this.Font.Size,
                        FontStyle.Underline
                        );

                // Add the item
                if (font != null)
                    this.Items.Add(font);
            }
        }

        public void InitComboBox(CustomComboBoxType combotype)
        {
            m_DisplayType = combotype;
            if (m_DisplayType == CustomComboBoxType.Type_Font)
                LoadFonts();
            else if (m_DisplayType == CustomComboBoxType.Type_HTML_Color)
                LoadHtmlColors();
        }

        private int m_Count = 0;
        private bool m_Gotit = false;
        private Color m_selColor = Color.Empty;
        public Color SelectedColorItem
        {
            get
            {
                if (this.SelectedIndex > -1)
                    return (Color)this.SelectedItem;
                else
                    return Color.Empty;
            }

            set
            {
                m_Count = 0;
                m_Gotit = false;
                foreach (object item in this.Items)
                {
                    m_selColor = (Color)item;
                    if ((m_selColor.A == value.A) &&
                        (m_selColor.B == value.B) &&
                        (m_selColor.R == value.R) &&
                        (m_selColor.G == value.G))
                    {
                        m_Gotit = true;
                        break;
                    }
                    m_Count++;
                }
                if (m_Gotit)
                {
                    m_InternalCall = true;
                    this.SelectedIndex = m_Count;
                }
            }
        }

        public Font SelectedFontItem
        {
            get
            {
                if (this.SelectedIndex > -1)
                    return (Font)this.SelectedItem;
                else
                    return null;
            }

            set
            {
                m_Gotit = false;
                m_Count = 0;
                foreach (object item in this.Items)
                {
                    if (((Font)item).Name == value.Name)
                    {
                        m_Gotit = true;
                        break;
                    }
                    m_Count++;
                }
                if (m_Gotit)
                {
                    m_InternalCall = true;
                    this.SelectedIndex = m_Count;
                }
            }
        }

        public string SelectedFontNameItem
        {
            get
            {
                if (this.SelectedIndex > -1)
                    return ((Font)this.SelectedItem).Name;
                else
                    return string.Empty;
            }

            set
            {
                m_Gotit = false;
                m_Count = 0;
                foreach (object item in this.Items)
                {
                    if (((Font)item).Name == value)
                    {
                        m_Gotit = true;
                        break;
                    }
                    m_Count++;
                }
                if (m_Gotit)
                {
                    m_InternalCall = true;
                    this.SelectedIndex = m_Count;
                }
            }
        }

        private int m_ColorBoxWidth = 30;
        private int m_ColorBoxHeight = 15;
        private int m_ImageWidth = 16;
        private int m_ImageHeight = 15;
        private bool m_InternalCall = false;

        public bool InternalCall
        {
            get { return m_InternalCall; }
            set { m_InternalCall = value; }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            m_InternalCall = false;
        }

        protected override void OnClick(EventArgs e)
        {
            m_InternalCall = false;
            base.OnClick(e);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if ((e.Index < 0) || (e.Index > this.Items.Count))
            {
                base.OnDrawItem(e);
                return;
            }

            e.DrawBackground();
            Brush b = null;
            Brush brect = null;

            if (m_DisplayType == CustomComboBoxType.Type_Font)
            {

                try
                {
                    // Create a new background brush.
                    b = new SolidBrush(e.ForeColor);

                    string stext = (e.Index == 0) ? "Default" : ((Font)this.Items[e.Index]).Name;
                    // Draw the item.
                    e.Graphics.DrawString(stext, ((Font)this.Items[e.Index]), b, e.Bounds);
                }
                finally
                {
                    if (b != null)
                        b.Dispose();
                    b = null;
                }
            }
            else if (m_DisplayType == CustomComboBoxType.Type_HTML_Color)
            {
                try
                {
                    int boxH = (e.Bounds.Height - m_ColorBoxHeight) / 2;

                    brect = new SolidBrush((Color)this.Items[e.Index]);
                    e.Graphics.FillRectangle(brect, e.Bounds.Left, e.Bounds.Top + boxH, m_ColorBoxWidth, m_ColorBoxHeight);

                    // Create a new background brush.
                    b = new SolidBrush(e.ForeColor);

                    // Draw the item.
                    Rectangle rect = new Rectangle(e.Bounds.Left + m_ColorBoxWidth + 1, e.Bounds.Top + boxH
                        , e.Bounds.Width - m_ColorBoxWidth - 1, e.Bounds.Height - (boxH * 2));
                    string stext = (e.Index == 0) ? "Default" : ((Color)this.Items[e.Index]).Name;
                    e.Graphics.DrawString(stext, e.Font, b, rect);
                }
                finally
                {
                    if (brect != null)
                        brect.Dispose();
                    brect = null;
                    if (b != null)
                        b.Dispose();
                    b = null;
                }
            }
            else if (m_DisplayType == CustomComboBoxType.Type_Image)
            {
                try
                {
                    int boxH = (e.Bounds.Height - m_ImageHeight) / 2;
                    ComboBoxIconItem item = (ComboBoxIconItem)this.Items[e.Index];
                    if ((m_ImageList != null) && (item != null) && (item.ImageIndex > -1))
                    {
                        m_ImageList.Draw(e.Graphics, e.Bounds.Left + 1,
                            e.Bounds.Top + boxH, item.ImageIndex);
                    }
                    else
                    {
                        brect = new SolidBrush(Color.Blue);
                        e.Graphics.FillRectangle(brect,
                            e.Bounds.Left,
                            e.Bounds.Top + boxH,
                            m_ImageWidth, m_ImageHeight);
                    }

                    // Create a new background brush.
                    b = new SolidBrush(e.ForeColor);

                    // Draw the item.
                    Rectangle rect = new Rectangle(e.Bounds.Left + m_ImageWidth + 1, e.Bounds.Top + boxH
                        , e.Bounds.Width - m_ImageWidth - 1, e.Bounds.Height - (boxH * 2));
                    e.Graphics.DrawString(this.Items[e.Index].ToString(),
                        e.Font, b, rect);

                }
                finally
                {
                    if (brect != null)
                        brect.Dispose();
                    brect = null;
                    if (b != null)
                        b.Dispose();
                    b = null;
                }
            }
            else if (m_DisplayType == CustomComboBoxType.Type_Text)
            {
                try
                {
                    // Create a new background brush.
                    b = new SolidBrush(e.ForeColor);

                    // Draw the item.
                    e.Graphics.DrawString(this.Items[e.Index].ToString(),
                        e.Font, b, e.Bounds);

                }
                finally
                {
                    if (b != null)
                        b.Dispose();
                    b = null;
                }
            }

            base.OnDrawItem(e);
        }

    } 
    #endregion

    #region ToolStripCustomComboBox class
    public class ToolStripCustomComboBox : ToolStripComboBox
    {
        public enum ToolStripComboBoxType
        {
            Type_Text = 0,
            Type_Font = 1,
            Type_HTML_Color = 2,
            Type_Image = 3
        }

        public ToolStripCustomComboBox()
        {
            this.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.ComboBox.DrawItem += new DrawItemEventHandler(ComboBox_DrawItem);
        }

        void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if ((e.Index < 0) || (e.Index > this.Items.Count))
                return;

            e.DrawBackground();
            Brush b = null;
            Brush brect = null;

            if (m_DisplayType == ToolStripComboBoxType.Type_Font)
            {

                try
                {
                    // Create a new background brush.
                    b = new SolidBrush(e.ForeColor);

                    string stext = (e.Index == 0) ? "Default" : ((Font)this.Items[e.Index]).Name;
                    // Draw the item.
                    e.Graphics.DrawString(stext, ((Font)this.Items[e.Index]), b, e.Bounds);
                }
                finally
                {
                    if (b != null)
                        b.Dispose();
                    b = null;
                }
            }
            else if (m_DisplayType == ToolStripComboBoxType.Type_HTML_Color)
            {
                try
                {
                    int boxH = (e.Bounds.Height - m_ColorBoxHeight) / 2;

                    brect = new SolidBrush((Color)this.Items[e.Index]);
                    e.Graphics.FillRectangle(brect, e.Bounds.Left, e.Bounds.Top + boxH, m_ColorBoxWidth, m_ColorBoxHeight);

                    // Create a new background brush.
                    b = new SolidBrush(e.ForeColor);

                    // Draw the item.
                    Rectangle rect = new Rectangle(e.Bounds.Left + m_ColorBoxWidth + 1, e.Bounds.Top + boxH
                        , e.Bounds.Width - m_ColorBoxWidth - 1, e.Bounds.Height - (boxH * 2));
                    string stext = (e.Index == 0) ? "Default" : ((Color)this.Items[e.Index]).Name;
                    e.Graphics.DrawString(stext, e.Font, b, rect);
                }
                finally
                {
                    if (brect != null)
                        brect.Dispose();
                    brect = null;
                    if (b != null)
                        b.Dispose();
                    b = null;
                }
            }
            else if (m_DisplayType == ToolStripComboBoxType.Type_Image)
            {
                try
                {
                    int boxH = (e.Bounds.Height - m_ImageHeight) / 2;
                    ComboBoxIconItem item = (ComboBoxIconItem)this.Items[e.Index];
                    if ((m_ImageList != null) && (item != null) && (item.ImageIndex > -1))
                    {
                        m_ImageList.Draw(e.Graphics, e.Bounds.Left + 1,
                            e.Bounds.Top + boxH, item.ImageIndex);
                    }
                    else
                    {
                        brect = new SolidBrush(Color.Blue);
                        e.Graphics.FillRectangle(brect,
                            e.Bounds.Left,
                            e.Bounds.Top + boxH,
                            m_ImageWidth, m_ImageHeight);
                    }

                    // Create a new background brush.
                    b = new SolidBrush(e.ForeColor);

                    // Draw the item.
                    Rectangle rect = new Rectangle(e.Bounds.Left + m_ImageWidth + 1, e.Bounds.Top + boxH
                        , e.Bounds.Width - m_ImageWidth - 1, e.Bounds.Height - (boxH * 2));
                    e.Graphics.DrawString(this.Items[e.Index].ToString(),
                        e.Font, b, rect);

                }
                finally
                {
                    if (brect != null)
                        brect.Dispose();
                    brect = null;
                    if (b != null)
                        b.Dispose();
                    b = null;
                }
            }
            else if (m_DisplayType == ToolStripComboBoxType.Type_Text)
            {
                try
                {
                    // Create a new background brush.
                    b = new SolidBrush(e.ForeColor);

                    // Draw the item.
                    e.Graphics.DrawString(this.Items[e.Index].ToString(),
                        e.Font, b, e.Bounds);

                }
                finally
                {
                    if (b != null)
                        b.Dispose();
                    b = null;
                }
            }

        }

        private ImageList m_ImageList = null;
        public ImageList Images
        {
            get { return m_ImageList; }
            set { m_ImageList = value; }
        }

        private ToolStripComboBoxType m_DisplayType = ToolStripComboBoxType.Type_Text;
        public ToolStripComboBoxType DisplayType
        {
            get { return m_DisplayType; }
        }

        private void LoadHtmlColors()
        {
            Array knownColors = Enum.GetValues(typeof(System.Drawing.KnownColor));
            //First add an empty color
            this.Items.Add(Color.Empty);
            //Then the rest
            foreach (KnownColor k in knownColors)
            {
                Color c = Color.FromKnownColor(k);

                if (!c.IsSystemColor && (c.A > 0))
                {
                    this.Items.Add(c);
                }
            }
            //Select default
            this.SelectedIndex = 0;
        }

        private void LoadFonts()
        {
            // Gets the list of installed fonts.
            FontFamily[] ff = FontFamily.Families;

            // Loop and create a sample of each font.
            for (int x = 0; x < ff.Length; x++)
            {
                System.Drawing.Font font = null;

                // Create the font - based on the styles available.
                if (ff[x].IsStyleAvailable(FontStyle.Regular))
                    font = new System.Drawing.Font(
                        ff[x].Name,
                        this.Font.Size
                        );
                else if (ff[x].IsStyleAvailable(FontStyle.Bold))
                    font = new System.Drawing.Font(
                        ff[x].Name,
                        this.Font.Size,
                        FontStyle.Bold
                        );
                else if (ff[x].IsStyleAvailable(FontStyle.Italic))
                    font = new System.Drawing.Font(
                        ff[x].Name,
                        this.Font.Size,
                        FontStyle.Italic
                        );
                else if (ff[x].IsStyleAvailable(FontStyle.Strikeout))
                    font = new System.Drawing.Font(
                        ff[x].Name,
                        this.Font.Size,
                        FontStyle.Strikeout
                        );
                else if (ff[x].IsStyleAvailable(FontStyle.Underline))
                    font = new System.Drawing.Font(
                        ff[x].Name,
                        this.Font.Size,
                        FontStyle.Underline
                        );

                // Add the item
                if (font != null)
                    this.Items.Add(font);
            }
        }

        public void InitComboBox(ToolStripComboBoxType combotype)
        {
            m_DisplayType = combotype;
            if (m_DisplayType == ToolStripComboBoxType.Type_Font)
                LoadFonts();
            else if (m_DisplayType == ToolStripComboBoxType.Type_HTML_Color)
                LoadHtmlColors();
        }

        private int m_ColorBoxWidth = 30;
        private int m_ColorBoxHeight = 15;
        private int m_ImageWidth = 16;
        private int m_ImageHeight = 15;
        private bool m_InternalCall = false;

        public bool InternalCall
        {
            get { return m_InternalCall; }
            set { m_InternalCall = value; }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            m_InternalCall = false;
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            m_InternalCall = false;
        }

        private int m_Count = 0;
        private bool m_Gotit = false;
        private Color m_selColor = Color.Empty;

        public Color SelectedColorItem
        {
            get
            {
                if (this.SelectedIndex > -1)
                    return (Color)this.SelectedItem;
                else
                    return Color.Empty;
            }

            set
            {
                m_Count = 0;
                m_Gotit = false;
                foreach (object item in this.Items)
                {
                    m_selColor = (Color)item;
                    if ((m_selColor.A == value.A) &&
                        (m_selColor.B == value.B) &&
                        (m_selColor.R == value.R) &&
                        (m_selColor.G == value.G))
                    {
                        m_Gotit = true;
                        break;
                    }
                    m_Count++;
                }
                if (m_Gotit)
                {
                    m_InternalCall = true;
                    this.SelectedIndex = m_Count;
                }
            }
        }

        public string SelectedFontNameItem
        {
            get
            {
                if (this.SelectedIndex > -1)
                    return ((Font)this.SelectedItem).Name;
                else
                    return string.Empty;
            }

            set
            {
                m_Gotit = false;
                m_Count = 0;
                foreach (object item in this.Items)
                {
                    if (((Font)item).Name == value)
                    {
                        m_Gotit = true;
                        break;
                    }
                    m_Count++;
                }
                if (m_Gotit)
                {
                    m_InternalCall = true;
                    this.SelectedIndex = m_Count;
                }
            }
        }

        public Font SelectedFontItem
        {
            get
            {
                if (this.SelectedIndex > -1)
                    return (Font)this.SelectedItem;
                else
                    return null;
            }

            set
            {
                m_Gotit = false;
                m_Count = 0;
                foreach (object item in this.Items)
                {
                    if (((Font)item).Name == value.Name)
                    {
                        m_Gotit = true;
                        break;
                    }
                    m_Count++;
                }
                if (m_Gotit)
                {
                    m_InternalCall = true;
                    this.SelectedIndex = m_Count;
                }
            }
        }

    } 
    #endregion

    #region ComboBoxIconItem class
    /// <summary>
    /// Used for adding items to custom combos when style is image+text
    /// </summary>
    public class ComboBoxIconItem
    {
        private string m_text = string.Empty;
        private int m_ImageIndex = -1;
        public string Text
        {
            get { return m_text; }
            set { m_text = value; }
        }

        public int ImageIndex
        {
            get { return m_ImageIndex; }
            set { m_ImageIndex = value; }
        }

        public override string ToString()
        {
            return m_text;
        }

        public void New()
        {
            m_text = string.Empty;
        }
        public void New(string text)
        {
            m_text = text;
        }
        public void New(string text, int imgindex)
        {
            m_text = text;
            m_ImageIndex = imgindex;
        }

    } 
    #endregion

    #region HtmlRichTextBox, RichTextBox based with basic syntx highlighting
    /// <summary>
    /// Simple RichTextBox control derived class with basic syntax highlighting
    /// Add control as you would with a RichTextBox, call two methods
    /// htmlRichTextBox1.SetupHighLighting(StringCollection);
    /// htmlRichTextBox1.SuppressHightlighting = false;
    /// In tabControl1_SelectedIndexChanged event, we call also
    /// htmlRichTextBox1.Modified = false; to avoid reloading of the webbrowser
    /// hence loosing the changes
    /// </summary>
    public class HtmlRichTextBox : RichTextBox
    {
        public void SetupHighLighting(System.Collections.Specialized.StringCollection col)
        {
            string keywords = string.Empty;
            int i = 0;
            foreach (string str in col)
            {
                if (i == col.Count - 1)
                    keywords += "\\b" + str + "\\b";
                else
                    keywords += "\\b" + str + "\\b|";
                i++;
            }
            //Compile
            keywordsRegexp = new System.Text.RegularExpressions.Regex(keywords,
                System.Text.RegularExpressions.RegexOptions.Compiled |
                System.Text.RegularExpressions.RegexOptions.Multiline);
        }

        private System.Text.RegularExpressions.Regex keywordsRegexp = null;
        private Color m_color = Color.FromArgb(163, 21, 21);
        private bool paintControl = true;
        private bool suppressHightlighting = true;

        public bool SuppressHightlighting
        {
            get
            {
                return suppressHightlighting;
            }
            set
            {
                suppressHightlighting = value;
            }
        }

        public Color HighlightColor
        {
            get
            {
                return m_color;
            }
            set
            {
                m_color = value;
            }
        }

        private bool PaintControl
        {
            get { return paintControl; }
            set
            {
                paintControl = value;
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;

                if (!suppressHightlighting)
                {
                    ProcessAllLines();
                }
            }
        }

        private void ProcessRegex(string line, int lineStart, System.Text.RegularExpressions.Regex regexp, Color color)
        {
            if (regexp == null)
                return;

            System.Text.RegularExpressions.Match regMatch;

            for (regMatch = regexp.Match(line); regMatch.Success; regMatch = regMatch.NextMatch())
            {
                // Process the words
                int nStart = lineStart + regMatch.Index;
                int nLenght = regMatch.Length;
                SelectionStart = nStart;
                SelectionLength = nLenght;
                SelectionColor = color;
            }
        }

        private void ProcessLine(string line, int lineStart)
        {
            // Save the position and make the whole line black
            int nPosition = SelectionStart;
            SelectionStart = lineStart;
            SelectionLength = line.Length;
            SelectionColor = Color.Black;

            // Process the keywords
            ProcessRegex(line, lineStart, keywordsRegexp, m_color);

            SelectionStart = nPosition;
            SelectionLength = 0;
            SelectionColor = Color.Black;

        }

        public void ProcessAllLines()
        {
            PaintControl = false;
            suppressHightlighting = true;

            // Save the position and make the whole line black
            int nPosition = SelectionStart;
            SelectionStart = 0;
            SelectionLength = Text.Length;
            SelectionColor = Color.Black;

            // Process the keywords
            ProcessRegex(Text, 0, keywordsRegexp, m_color);

            SelectionStart = nPosition;
            SelectionLength = 0;
            SelectionColor = Color.Black;


            suppressHightlighting = false;
            PaintControl = true;
        }

        protected override void WndProc(ref Message m)
        {
            //Avoid unnecessary paint messages
            if (m.Msg == 0x000F)
            {
                if (PaintControl)
                {
                    base.WndProc(ref m);
                }
                else
                {
                    m.Result = IntPtr.Zero;
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (suppressHightlighting)
            {
                base.OnTextChanged(e);
                return;
            }

            PaintControl = false;
            string line = GetCurrentLine();
            int lineStart = GetFirstCharIndexOfCurrentLine();
            // Process this line.
            ProcessLine(line, lineStart);
            PaintControl = true;
        }

        private string GetCurrentLine()
        {
            int charIndex = SelectionStart;
            int currentLineNumber = GetLineFromCharIndex(charIndex);

            if (currentLineNumber < Lines.Length)
            {
                return Lines[currentLineNumber];
            }
            else
            {
                return string.Empty;
            }
        }

        private string GetLastWord()
        {
            int pos = this.SelectionStart - 1;

            while (pos > 1)
            {
                string substr = this.Text.Substring(pos - 1, 1);

                if (Char.IsWhiteSpace(substr, 0))
                {
                    return Text.Substring(pos, this.SelectionStart - pos);
                }

                pos--;
            }

            return Text.Substring(0, this.SelectionStart);
        }

        private string GetLastLine()
        {
            int charIndex = SelectionStart;
            int currentLineNumber = GetLineFromCharIndex(charIndex);

            // the carriage return hasn't happened yet... 
            //      so the 'previous' line is the current one.
            string previousLineText;
            if (Lines.Length <= currentLineNumber)
                previousLineText = Lines[Lines.Length - 1];
            else
                previousLineText = Lines[currentLineNumber];

            return previousLineText;
        }

    } 
    #endregion

    #region Custom Splitter based on SplitContainer
    public class CustomSplitter : SplitContainer
    {
        public CustomSplitter()
        {
            //To stop flickering
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.CacheText, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.Opaque, true);

            this.SplitterWidth = 7;
            m_Panel1MinSize = this.Panel1MinSize;
            m_Panel2MinSize = this.Panel2MinSize;

            //This timer is needed as setting SplitterDistance
            //property in OnClick event will reset the SplitterDistance
            //to it's original state??
            m_Timer.Interval = 100;
            m_Timer.Tick += new EventHandler(m_Timer_Tick);
            this.SplitterMoved += new SplitterEventHandler(CustomSplitter_SplitterMoved);
            //Tooltip
            m_ToolTipCtl.SetToolTip(this, m_TooltipText);
            //ContextMenu
            m_CtxMenu.Name = "SplitterContextMenu";
            m_MnuFixSplitter.Name = "MnuFixSplitter";
            m_MnuToolTip.Name = "MnuToolTip";
            m_CtxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                m_MnuFixSplitter, m_MnuToolTip });
            m_CtxMenu.Opening += new CancelEventHandler(m_CtxMenu_Opening);
            m_CtxMenu.ItemClicked += new ToolStripItemClickedEventHandler(m_CtxMenu_ItemClicked);
        }

        #region Variables
        private Timer m_Timer = new Timer();
        private ToolTip m_ToolTipCtl = new ToolTip();
        private string m_TooltipText = "Double click to change orientation.\r\nClick on Arrows to collapse or expand splitter panes.\r\nRight click for more options.";

        private ContextMenuStrip m_CtxMenu = new ContextMenuStrip();
        private ToolStripMenuItem m_MnuFixSplitter = new ToolStripMenuItem("Splitter fixed");
        private ToolStripMenuItem m_MnuToolTip = new ToolStripMenuItem("Tooltip");

        private Rectangle m_RectDrawing = Rectangle.Empty; //where dots are drawn
        private Rectangle m_RectLeftArrow = Rectangle.Empty; //where rightarrow is drawn
        private Rectangle m_RectRightArrow = Rectangle.Empty; //where leftarrow is drawn

        private int m_ArrowHeight = 20; //Pixels
        private int m_HalfArrowHeight = 10;
        private const int HEIGHT_RATIO = 4;
        //where to draw pattern in relation tothis.splitterRectangle.Left
        private const int DRAWING_PADDING_LEFT = 1;
        private const int DRAWING_PADDING_RIGHT = 2;
        private bool m_IsHot = false;
        private Color m_ArrowBackColor = Color.Blue; //used in Paint event as a temp var
        private Color m_ArrowHotBackColor = Color.Red;
        private Color m_ArrowNormalBackColor = Color.Blue;
        private Color m_DotsColor = SystemColors.ControlDarkDark;
        private Size m_PixelsBetweenDots = new Size(2, 2);

        private int m_LastSplitterPos = 0;
        private int m_TimerValueToSet = 0;
        private int m_Panel1MinSize = 0;
        private int m_Panel2MinSize = 0;
        private int m_DotsDrawingH = 0;
        private bool m_IsInternalCall = false;
        private bool m_ShowTooltips = true;
        private int m_iTempVariable = 0;
        private Point[] m_ptTemp = new Point[3];
        private Point[] m_ptTempA = new Point[3];

        private Color m_LineColor = SystemColors.ControlDark;
        private Pen m_LinePen = new Pen(SystemColors.ControlDark);
        private Brush m_RectangleBrush = new SolidBrush(SystemColors.ControlDark);
        private Brush m_BackgroundBrush = new SolidBrush(SystemColors.Control);
        public Color LineColor
        {
            get { return m_LineColor; }
            set
            {
                m_LineColor = value;
                m_LinePen.Dispose();
                m_RectangleBrush.Dispose();
                m_LinePen = new Pen(m_LineColor);
                m_RectangleBrush = new SolidBrush(m_LineColor);
                this.Invalidate();
            }
        }

        public enum SplitterVisualStyle
        {
            Horizontal_Lines = 0,
            Vertical_Lines = 1,
            Empty_Boxs = 2,
            Double_Jagged_Dots = 3,
            Mesh_Dots = 4,
            Filled_Boxs = 5,
            Gradient = 6
        }
        private SplitterVisualStyle m_SplitterVisualStyle = SplitterVisualStyle.Gradient;
        public SplitterVisualStyle SplitterHandleStyle
        {
            get { return m_SplitterVisualStyle; }
            set
            {
                m_SplitterVisualStyle = value;
                this.Invalidate();
            }
        }

        private Color m_GradientBeginColor = Color.Orange;
        private Color m_GradientEndColor = Color.Yellow;
        public Color GradientBegingColor
        {
            get { return m_GradientBeginColor; }
            set { m_GradientBeginColor = value; }
        }
        public Color GradientEndColor
        {
            get { return m_GradientEndColor; }
            set { m_GradientEndColor = value; }
        }

        public enum SplitterPanelState
        {
            Retracted = 0,
            Expanded = 1
        }
        private SplitterPanelState m_Panel1State = SplitterPanelState.Expanded;
        private SplitterPanelState m_Panel2State = SplitterPanelState.Expanded;
        #endregion

        #region Events

        void m_Timer_Tick(object sender, EventArgs e)
        {
            m_Timer.Stop();
            m_IsInternalCall = true;
            this.SplitterDistance = m_TimerValueToSet;
            //Fire an event
        }

        void CustomSplitter_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (m_IsInternalCall)
            {
                m_IsInternalCall = false;
                if (m_LastSplitterPos == 0)
                    m_LastSplitterPos = m_Panel1MinSize; //arbitary
                return;
            }
            if (this.Orientation == Orientation.Vertical)
            {
                if (this.SplitterDistance == 0)
                {
                    this.m_Panel1State = SplitterPanelState.Retracted;
                    this.Invalidate();
                }
                else if (this.SplitterDistance == (this.Width - this.SplitterWidth))
                {
                    this.m_Panel2State = SplitterPanelState.Retracted;
                    this.Invalidate();
                }
                else
                {
                    this.m_Panel1State = SplitterPanelState.Expanded;
                    this.m_Panel2State = SplitterPanelState.Expanded;
                }
            }
            else
            {
                if (this.SplitterDistance == 0)
                {
                    this.m_Panel1State = SplitterPanelState.Retracted;
                    this.Invalidate();
                }
                else if (this.SplitterDistance == (this.Height - this.SplitterWidth))
                {
                    this.m_Panel2State = SplitterPanelState.Retracted;
                    this.Invalidate();
                }
                else
                {
                    this.m_Panel1State = SplitterPanelState.Expanded;
                    this.m_Panel2State = SplitterPanelState.Expanded;
                }
            }
        }

        void m_CtxMenu_Opening(object sender, CancelEventArgs e)
        {
            m_MnuFixSplitter.Checked = (this.IsSplitterFixed) ? true : false;
            m_MnuToolTip.Checked = m_ShowTooltips;
        }

        void m_CtxMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == m_MnuFixSplitter.Name)
            {
                m_MnuFixSplitter.Checked = (m_MnuFixSplitter.Checked) ? false : true;
                this.IsSplitterFixed = (m_MnuFixSplitter.Checked) ? true : false;
            }
            else if (e.ClickedItem.Name == m_MnuToolTip.Name)
            {
                m_MnuToolTip.Checked = (m_MnuToolTip.Checked) ? false : true;
                if (m_MnuToolTip.Checked)
                {
                    m_ShowTooltips = true;
                    m_ToolTipCtl.SetToolTip(this, m_TooltipText);
                }
                else
                {
                    m_ShowTooltips = false;
                    m_ToolTipCtl.SetToolTip(this, string.Empty);
                }
            }
        }

        #endregion

        #region Properties

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                m_BackgroundBrush.Dispose();
                m_BackgroundBrush = new SolidBrush(value);
                base.BackColor = value;
            }
        }

        public string TooltipText
        {
            get { return m_TooltipText; }
            set
            {
                m_TooltipText = value;
                m_ToolTipCtl.SetToolTip(this, m_TooltipText);
            }
        }

        public int ArrowHeight
        {
            get { return m_ArrowHeight; }
            set
            {
                if (value > 0)
                {
                    m_ArrowHeight = value;
                    m_HalfArrowHeight = m_ArrowHeight / 2;
                    this.Invalidate();
                }
            }
        }

        public Color ArrowColor
        {
            get { return m_ArrowNormalBackColor; }
            set
            {
                m_ArrowNormalBackColor = value;
                this.Invalidate();
            }
        }

        public Color ArrowColorHot
        {
            get { return m_ArrowHotBackColor; }
            set
            {
                m_ArrowHotBackColor = value;
                this.Invalidate();
            }
        }

        public Color DotsColor
        {
            get { return m_DotsColor; }
            set
            {
                m_DotsColor = value;
                this.Invalidate();
            }
        }

        public Size PixelsBetweenDots
        {
            get { return m_PixelsBetweenDots; }
            set
            {
                m_PixelsBetweenDots = value;
                this.Invalidate();
            }
        }

        public Rectangle DotsRectangle
        {
            get { return m_RectDrawing; }
        }

        public Rectangle LeftArrowRectangle
        {
            get { return m_RectLeftArrow; }
        }

        public Rectangle RightArrowRectangle
        {
            get { return m_RectRightArrow; }
        }
        #endregion

        #region Overrides
        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            if (this.Orientation == Orientation.Horizontal)
                this.Orientation = Orientation.Vertical;
            else
                this.Orientation = Orientation.Horizontal;
        }

        protected override void OnClick(EventArgs e)
        {
            if (m_IsHot)
            {

                Point ptC = new Point(Cursor.Position.X, Cursor.Position.Y);
                Point pt = this.PointToClient(ptC);

                if (this.m_RectLeftArrow.Contains(pt))
                {
                    if (this.m_Panel2State == SplitterPanelState.Retracted)
                    {
                        this.m_Panel2State = SplitterPanelState.Expanded;
                        m_TimerValueToSet = m_LastSplitterPos;
                        m_Timer.Start();
                        this.Panel1MinSize = m_Panel1MinSize;
                    }
                    else if (this.m_Panel1State == SplitterPanelState.Expanded)
                    {
                        this.m_Panel1State = SplitterPanelState.Retracted;
                        m_LastSplitterPos = this.SplitterDistance;
                        this.Panel1MinSize = 0;
                        m_TimerValueToSet = 0;
                        m_Timer.Start();
                    }
                    else
                    {
                        this.m_Panel1State = SplitterPanelState.Expanded;
                        m_TimerValueToSet = m_LastSplitterPos;
                        m_Timer.Start();
                        this.Panel1MinSize = m_Panel1MinSize;
                    }
                    this.Invalidate();
                }
                else if (this.m_RectRightArrow.Contains(pt))
                {
                    if (this.m_Panel1State == SplitterPanelState.Retracted)
                    {
                        this.m_Panel1State = SplitterPanelState.Expanded;
                        m_TimerValueToSet = m_LastSplitterPos;
                        m_Timer.Start();
                        this.Panel2MinSize = m_Panel2MinSize;
                    }
                    else if (this.m_Panel2State == SplitterPanelState.Expanded)
                    {
                        this.m_Panel2State = SplitterPanelState.Retracted;
                        m_LastSplitterPos = this.SplitterDistance;
                        this.Panel2MinSize = 0;
                        m_TimerValueToSet = this.Width - this.SplitterWidth;
                        m_Timer.Start();
                    }
                    else
                    {
                        this.m_Panel2State = SplitterPanelState.Expanded;
                        m_TimerValueToSet = m_LastSplitterPos;
                        m_Timer.Start();
                        this.Panel2MinSize = m_Panel2MinSize;
                    }
                    this.Invalidate();
                }
                else
                    base.OnClick(e);
            }
            else
                base.OnClick(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            //Nothing to do
            if (this.IsSplitterFixed)
            {
                m_IsHot = false;
                this.Cursor = Cursors.Default;
                return;
            }

            //Dragging, let the base do the work
            if (e.Button == MouseButtons.Left)
            {
                m_IsHot = false;
                this.Cursor = (this.Orientation == Orientation.Vertical) ? Cursors.VSplit : Cursors.HSplit;
                base.OnMouseMove(e);
                return;
            }

            if (this.SplitterRectangle.Contains(e.Location))
            {
                if ((this.m_RectLeftArrow.Contains(e.Location)) ||
                    (this.m_RectRightArrow.Contains(e.Location)))
                {
                    m_IsHot = true;
                    this.Cursor = Cursors.Hand;
                }
                else
                {
                    this.Cursor = (this.Orientation == Orientation.Vertical) ? Cursors.VSplit : Cursors.HSplit;
                    m_IsHot = false;
                }
                this.Invalidate();
            }
            else
            {
                this.Cursor = Cursors.Default;
                m_IsHot = false;
                this.Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            m_IsHot = false;
            base.OnMouseLeave(e);
            this.Cursor = Cursors.Default;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right) && (this.ContextMenu == null))
            {
                Point pt = this.PointToScreen(e.Location);
                this.m_CtxMenu.Show(pt);
            }
            else
                base.OnMouseUp(e);
        }

        private void SetupArrowPoints(int X, int Y, int X1, int Y1, int X2, int Y2)
        {
            m_ptTemp[0].X = X;
            m_ptTemp[0].Y = Y;
            m_ptTemp[1].X = X1;
            m_ptTemp[1].Y = Y1;
            m_ptTemp[2].X = X2;
            m_ptTemp[2].Y = Y2;
        }

        private void SetupArrowPointsA(int X, int Y, int X1, int Y1, int X2, int Y2)
        {
            m_ptTempA[0].X = X;
            m_ptTempA[0].Y = Y;
            m_ptTempA[1].X = X1;
            m_ptTempA[1].Y = Y1;
            m_ptTempA[2].X = X2;
            m_ptTempA[2].Y = Y2;
        }

        private System.Drawing.Drawing2D.LinearGradientBrush m_gradientBrush = null;

        protected override void OnPaint(PaintEventArgs e)
        {

            //Fill background
            e.Graphics.FillRectangle(m_BackgroundBrush, this.ClientRectangle);

            //Background Image
            if (this.BackgroundImage != null)
                e.Graphics.DrawImage(this.BackgroundImage, this.ClientRectangle);

            //Border
            if (this.BorderStyle != BorderStyle.None)
            {
                //System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, e.Graphics, backbr, ButtonBorderStyle.Solid);
                if (this.BorderStyle == BorderStyle.FixedSingle)
                    System.Windows.Forms.ControlPaint.DrawBorder3D(
                        e.Graphics, this.ClientRectangle, Border3DStyle.Flat);
                else if (this.BorderStyle == BorderStyle.Fixed3D)
                    System.Windows.Forms.ControlPaint.DrawBorder3D(
                        e.Graphics, this.ClientRectangle, Border3DStyle.Adjust);
            }

            //Don't draw anything
            if ((this.Panel1Collapsed) || (this.Panel2Collapsed))
                return;

            //Backcolor for arrows
            m_ArrowBackColor = (m_IsHot) ? m_ArrowHotBackColor : m_ArrowNormalBackColor;
            SolidBrush blueBrush = new SolidBrush(m_ArrowBackColor);

            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //Vertical
            if (this.Orientation == Orientation.Vertical)
            {
                m_DotsDrawingH = this.Height / HEIGHT_RATIO;
                //Get the Drawing dots, left and right arrow rectangles
                //Divide Height by 4
                //Draw pattern in two parts, centered
                //Draw arrows on the beginning and end of the pattern
                m_RectDrawing = new Rectangle(
                    e.ClipRectangle.X + DRAWING_PADDING_LEFT,
                    m_DotsDrawingH,
                    e.ClipRectangle.Width - DRAWING_PADDING_RIGHT,
                    m_DotsDrawingH * 2);
                m_RectLeftArrow = new Rectangle(m_RectDrawing.X,
                    m_DotsDrawingH - m_ArrowHeight, m_RectDrawing.Width, m_ArrowHeight);
                m_RectRightArrow = new Rectangle(m_RectDrawing.X,
                    m_DotsDrawingH * 3, m_RectDrawing.Width, m_ArrowHeight);

                if (m_SplitterVisualStyle == SplitterVisualStyle.Gradient)
                {
                    m_gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                        this.ClientRectangle,
                        m_GradientBeginColor,
                        m_GradientEndColor,
                        System.Drawing.Drawing2D.LinearGradientMode.Vertical);
                    e.Graphics.FillRectangle(m_gradientBrush, this.ClientRectangle);
                }
                else if (m_SplitterVisualStyle == SplitterVisualStyle.Mesh_Dots)
                {
                    System.Windows.Forms.ControlPaint.DrawGrid(e.Graphics,
                        m_RectDrawing, m_PixelsBetweenDots, m_DotsColor);
                }
                else if (m_SplitterVisualStyle == SplitterVisualStyle.Horizontal_Lines)
                {
                    m_iTempVariable = this.m_RectDrawing.Top;
                    while (true)
                    {
                        e.Graphics.DrawLine(m_LinePen, m_RectDrawing.Left, m_iTempVariable,
                            m_RectDrawing.Right, m_iTempVariable);
                        m_iTempVariable += 3;
                        if (m_iTempVariable > this.m_RectDrawing.Bottom)
                            break;
                    }
                }
                else if (m_SplitterVisualStyle == SplitterVisualStyle.Vertical_Lines)
                {
                    m_iTempVariable = 0;
                    while (true)
                    {
                        e.Graphics.DrawLine(m_LinePen,
                            m_RectDrawing.Left + m_iTempVariable, m_RectDrawing.Top,
                            m_RectDrawing.Left + m_iTempVariable, m_RectDrawing.Bottom);
                        m_iTempVariable += 3;
                        if (m_iTempVariable > m_RectDrawing.Right)
                            break;
                    }
                }
                else if (m_SplitterVisualStyle == SplitterVisualStyle.Empty_Boxs)
                {
                    m_iTempVariable = this.m_RectDrawing.Top;
                    while (true)
                    {
                        e.Graphics.DrawRectangle(m_LinePen,
                            this.m_RectDrawing.Left, m_iTempVariable,
                            this.m_RectDrawing.Width - 1, this.m_RectDrawing.Width);
                        m_iTempVariable += this.m_RectDrawing.Width + DRAWING_PADDING_RIGHT;
                        if (m_iTempVariable > this.m_RectDrawing.Bottom - DRAWING_PADDING_RIGHT)
                            break;
                    }
                }
                else if (m_SplitterVisualStyle == SplitterVisualStyle.Filled_Boxs)
                {
                    //m_RectDrawing.Offset
                    m_iTempVariable = this.m_RectDrawing.Top;
                    while (true)
                    {
                        e.Graphics.FillRectangle(m_RectangleBrush,
                            this.m_RectDrawing.Left, m_iTempVariable,
                            this.m_RectDrawing.Width, this.m_RectDrawing.Width);
                        if (m_IsHot)
                        {
                            Brush lightbr = new SolidBrush(ProfessionalColors.SeparatorLight);
                            int iTemp = this.m_RectDrawing.Width / 2;
                            e.Graphics.FillRectangle(lightbr,
                                this.m_RectDrawing.Left, m_iTempVariable,
                                iTemp, iTemp);
                        }
                        m_iTempVariable += this.m_RectDrawing.Width + DRAWING_PADDING_RIGHT;
                        if (m_iTempVariable > this.m_RectDrawing.Bottom - DRAWING_PADDING_RIGHT)
                            break;
                    }
                }
                else if (m_SplitterVisualStyle == SplitterVisualStyle.Double_Jagged_Dots)
                {
                    m_iTempVariable = this.m_RectDrawing.Top;
                    int boxdim = m_RectDrawing.Width / 2;
                    while (true)
                    {
                        e.Graphics.FillRectangle(m_RectangleBrush,
                            this.m_RectDrawing.Left, m_iTempVariable, boxdim, boxdim);
                        if (m_iTempVariable + boxdim > this.m_RectDrawing.Bottom)
                            break;

                        e.Graphics.FillRectangle(m_RectangleBrush,
                            this.m_RectDrawing.Left + boxdim, m_iTempVariable + boxdim, boxdim, boxdim);
                        m_iTempVariable += boxdim * 3;
                        if (m_iTempVariable > this.m_RectDrawing.Bottom - boxdim)
                            break;
                    }
                }

                //No arrows
                if (this.IsSplitterFixed)
                {
                    //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                    return;
                }

                //Arrows
                if (this.m_Panel1State == SplitterPanelState.Retracted)
                {
                    SetupArrowPoints(m_RectLeftArrow.X, m_RectLeftArrow.Y,
                        m_RectLeftArrow.Right, m_RectLeftArrow.Y + m_HalfArrowHeight,
                        m_RectLeftArrow.X, m_RectLeftArrow.Y + m_ArrowHeight);
                    //pointing right
                    e.Graphics.FillPolygon(blueBrush, m_ptTemp);

                    SetupArrowPointsA(m_RectRightArrow.X, m_RectRightArrow.Y,
                        m_RectRightArrow.Right, m_RectRightArrow.Y + m_HalfArrowHeight,
                        m_RectRightArrow.X, m_RectRightArrow.Y + m_ArrowHeight);
                    //pointing Right
                    e.Graphics.FillPolygon(blueBrush, m_ptTempA);
                }
                else if (this.m_Panel2State == SplitterPanelState.Retracted)
                {
                    SetupArrowPoints(m_RectLeftArrow.Right, m_RectLeftArrow.Y,
                        m_RectLeftArrow.X, m_RectLeftArrow.Y + m_HalfArrowHeight,
                        m_RectLeftArrow.Right, m_RectLeftArrow.Y + m_ArrowHeight);
                    //pointing Left
                    e.Graphics.FillPolygon(blueBrush, m_ptTemp);

                    SetupArrowPointsA(m_RectRightArrow.Right, m_RectRightArrow.Y,
                        m_RectRightArrow.X, m_RectRightArrow.Y + m_HalfArrowHeight,
                        m_RectRightArrow.Right, m_RectRightArrow.Y + m_ArrowHeight);
                    //pointing left
                    e.Graphics.FillPolygon(blueBrush, m_ptTempA);
                }
                else
                {
                    SetupArrowPoints(m_RectLeftArrow.Right, m_RectLeftArrow.Y,
                        m_RectLeftArrow.X, m_RectLeftArrow.Y + m_HalfArrowHeight,
                        m_RectLeftArrow.Right, m_RectLeftArrow.Y + m_ArrowHeight);
                    //pointing Left
                    e.Graphics.FillPolygon(blueBrush, m_ptTemp);

                    SetupArrowPointsA(m_RectRightArrow.X, m_RectRightArrow.Y,
                        m_RectRightArrow.Right, m_RectRightArrow.Y + m_HalfArrowHeight,
                        m_RectRightArrow.X, m_RectRightArrow.Y + m_ArrowHeight);
                    //pointing Right
                    e.Graphics.FillPolygon(blueBrush, m_ptTempA);
                }
            }
            else //Horizontal
            {
                m_DotsDrawingH = this.Width / HEIGHT_RATIO;
                m_RectDrawing = new Rectangle(
                    e.ClipRectangle.X + m_DotsDrawingH,
                    e.ClipRectangle.Y + DRAWING_PADDING_LEFT,
                    m_DotsDrawingH * 2,
                    e.ClipRectangle.Height - DRAWING_PADDING_RIGHT);

                m_RectLeftArrow = new Rectangle(m_RectDrawing.X - m_ArrowHeight,
                    m_RectDrawing.Y, m_ArrowHeight, m_RectDrawing.Height);
                m_RectRightArrow = new Rectangle(m_RectDrawing.Right,
                    m_RectDrawing.Y, m_ArrowHeight, m_RectDrawing.Height);

                if (m_SplitterVisualStyle == SplitterVisualStyle.Gradient)
                {
                    m_gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                        this.ClientRectangle,
                        m_GradientBeginColor,
                        m_GradientEndColor,
                        System.Drawing.Drawing2D.LinearGradientMode.Vertical);
                    e.Graphics.FillRectangle(m_gradientBrush, this.ClientRectangle);
                }
                if (m_SplitterVisualStyle == SplitterVisualStyle.Mesh_Dots)
                {
                    System.Windows.Forms.ControlPaint.DrawGrid(e.Graphics,
                        m_RectDrawing, m_PixelsBetweenDots, m_DotsColor);
                }
                else if (m_SplitterVisualStyle == SplitterVisualStyle.Horizontal_Lines)
                {
                    m_iTempVariable = this.m_RectDrawing.Top;
                    while (true)
                    {
                        e.Graphics.DrawLine(m_LinePen, m_RectDrawing.Left,
                            m_iTempVariable,
                            m_RectDrawing.Right, m_iTempVariable);
                        m_iTempVariable += 3;
                        if (m_iTempVariable > this.m_RectDrawing.Bottom)
                            break;
                    }
                }
                else if (m_SplitterVisualStyle == SplitterVisualStyle.Vertical_Lines)
                {
                    m_iTempVariable = 0;
                    while (true)
                    {
                        e.Graphics.DrawLine(m_LinePen,
                            m_RectDrawing.Left + m_iTempVariable, m_RectDrawing.Top,
                            m_RectDrawing.Left + m_iTempVariable, m_RectDrawing.Bottom);
                        m_iTempVariable += 3;
                        if (m_RectDrawing.Left + m_iTempVariable > m_RectDrawing.Right)
                            break;
                    }
                }
                else if (m_SplitterVisualStyle == SplitterVisualStyle.Empty_Boxs)
                {
                    m_iTempVariable = this.m_RectDrawing.Left;
                    while (true)
                    {
                        e.Graphics.DrawRectangle(m_LinePen,
                            m_iTempVariable, this.m_RectDrawing.Top,
                            this.m_RectDrawing.Height, this.m_RectDrawing.Height - 1);
                        m_iTempVariable += this.m_RectDrawing.Height + DRAWING_PADDING_RIGHT;
                        if (m_iTempVariable > this.m_RectDrawing.Right - DRAWING_PADDING_RIGHT)
                            break;
                    }
                }
                else if (m_SplitterVisualStyle == SplitterVisualStyle.Filled_Boxs)
                {
                    m_iTempVariable = this.m_RectDrawing.Left;
                    while (true)
                    {
                        e.Graphics.FillRectangle(m_RectangleBrush,
                            m_iTempVariable, this.m_RectDrawing.Top,
                            this.m_RectDrawing.Height, this.m_RectDrawing.Height - 1);

                        if (m_IsHot)
                        {
                            Brush lightbr = new SolidBrush(ProfessionalColors.SeparatorLight);
                            int iTemp = this.m_RectDrawing.Height / 2;
                            e.Graphics.FillRectangle(lightbr,
                                m_iTempVariable, this.m_RectDrawing.Top,
                                iTemp, iTemp);
                        }

                        m_iTempVariable += this.m_RectDrawing.Height + DRAWING_PADDING_RIGHT;
                        if (m_iTempVariable > this.m_RectDrawing.Right - DRAWING_PADDING_RIGHT)
                            break;
                    }
                }
                else if (m_SplitterVisualStyle == SplitterVisualStyle.Double_Jagged_Dots)
                {
                    m_iTempVariable = this.m_RectDrawing.Left;
                    int boxdim = m_RectDrawing.Height / 2;
                    while (true)
                    {
                        e.Graphics.FillRectangle(m_RectangleBrush,
                            m_iTempVariable, this.m_RectDrawing.Top, boxdim, boxdim);
                        if (m_iTempVariable + boxdim > this.m_RectDrawing.Right)
                            break;
                        e.Graphics.FillRectangle(m_RectangleBrush,
                            m_iTempVariable + boxdim,
                            this.m_RectDrawing.Top + boxdim, boxdim, boxdim);
                        m_iTempVariable += boxdim * 3;
                        if (m_iTempVariable > this.m_RectDrawing.Right - boxdim)
                            break;
                    }
                }

                //No arrows
                if (this.IsSplitterFixed)
                {
                    //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                    return;
                }

                if (this.m_Panel1State == SplitterPanelState.Retracted)
                {
                    SetupArrowPoints(m_RectLeftArrow.X, m_RectLeftArrow.Y,
                        m_RectLeftArrow.X + m_HalfArrowHeight, m_RectLeftArrow.Bottom,
                        m_RectLeftArrow.Right, m_RectLeftArrow.Y);
                    //pointing down
                    e.Graphics.FillPolygon(blueBrush, m_ptTemp);

                    SetupArrowPointsA(m_RectRightArrow.X, m_RectRightArrow.Y,
                        m_RectRightArrow.Right, m_RectRightArrow.Y,
                        m_RectRightArrow.X + m_HalfArrowHeight, m_RectRightArrow.Bottom);
                    //pointing down
                    e.Graphics.FillPolygon(blueBrush, m_ptTempA);
                }
                else if (this.m_Panel1State == SplitterPanelState.Retracted)
                {
                    SetupArrowPoints(m_RectLeftArrow.X, m_RectLeftArrow.Bottom,
                        m_RectLeftArrow.X + m_HalfArrowHeight, m_RectLeftArrow.Y,
                        m_RectLeftArrow.Right, m_RectLeftArrow.Bottom);
                    //pointing up
                    e.Graphics.FillPolygon(blueBrush, m_ptTemp);

                    SetupArrowPointsA(m_RectRightArrow.X, m_RectRightArrow.Bottom,
                        m_RectRightArrow.X + m_HalfArrowHeight, m_RectRightArrow.Y,
                        m_RectRightArrow.Right, m_RectRightArrow.Bottom);
                    //pointing up
                    e.Graphics.FillPolygon(blueBrush, m_ptTempA);
                }
                else
                {
                    SetupArrowPoints(m_RectLeftArrow.X, m_RectLeftArrow.Bottom,
                        m_RectLeftArrow.X + m_HalfArrowHeight, m_RectLeftArrow.Y,
                        m_RectLeftArrow.Right, m_RectLeftArrow.Bottom);
                    //pointing up
                    e.Graphics.FillPolygon(blueBrush, m_ptTemp);

                    SetupArrowPointsA(m_RectRightArrow.X, m_RectRightArrow.Y,
                        m_RectRightArrow.Right, m_RectRightArrow.Y,
                        m_RectRightArrow.X + m_HalfArrowHeight, m_RectRightArrow.Bottom);
                    //pointing down
                    e.Graphics.FillPolygon(blueBrush, m_ptTempA);
                }
            }
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
        }

        #endregion
    }
    #endregion

    #region HtmlColorSelectorComboBox control
    /// <summary>
    /// A control simiulating a combobox with 
    /// ToolStripHtmlColorSelector as the dropdown part
    /// </summary>
    public class HtmlColorSelectorComboBox : Control
    {
        public HtmlColorSelectorComboBox()
        {
            //To stop flickering and stuff
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.CacheText, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.StandardClick, true);
            this.SetStyle(ControlStyles.Opaque, true);
            this.Size = new Size(140, MAXIMUM_HEIGHT);
            //When dropdown is closed we reset focus back to this control
            m_DropDown.Closed += new ToolStripDropDownClosedEventHandler(m_DropDown_Closed);
        }

        void m_DropDown_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            //Set the focus back to us
            this.Focus();
            Invalidate();
        }

        #region Variables
        private System.ComponentModel.IContainer components = null;
        private ToolStripHtmlColorSelector m_DropDown = new ToolStripHtmlColorSelector();
        private Brush m_BackgroundBrush = new SolidBrush(SystemColors.Control);
        private bool m_IsHot = false;
        private bool m_HasFocus = false;
        private bool m_IsDropDownPressed = false;
        private int m_Padding = 3;
        private int m_colorwidth = 30;
        private int m_DropdownDimensions = 15;
        private const int MAXIMUM_HEIGHT = 21;
        private Rectangle m_textrect = Rectangle.Empty;
        private Rectangle m_dropdownrect = Rectangle.Empty;
        private Rectangle m_colorrect = Rectangle.Empty;
        private string m_DefaultText = "Default";
        private System.Drawing.Drawing2D.LinearGradientBrush gradBrush = null;
        private int opacity = 0x99;
        private string m_strText = string.Empty;
        private Color m_tempforecolor = Control.DefaultForeColor;
        private Color m_GradientEndColor = Color.White; //ProfessionalColors.ButtonSelectedGradientEnd;
        private Color m_GradientStartColor = Color.White; //ProfessionalColors.MenuStripGradientEnd;
        private Color m_hovercolor = Color.Blue;
        #endregion

        #region Properties
        public Color SelectedColor
        {
            get { return m_DropDown.Selector.SelectedColor; }
            set { m_DropDown.Selector.SelectedColor = value; }
        }

        public Color DefaultColor
        {
            get { return m_DropDown.Selector.DefaultColor; }
            set { m_DropDown.Selector.DefaultColor = value; }
        }

        public string DefaultColorText
        {
            get { return m_DefaultText; }
            set { m_DefaultText = value; }
        }

        public ToolStripHtmlColorSelector DropDownToolStripContainer
        {
            get { return m_DropDown; }
        }

        public HtmlColorSelector ColorSelector
        {
            get { return m_DropDown.Selector; }
        }

        public new Size Size
        {
            get { return new Size(base.Size.Width, MAXIMUM_HEIGHT); }
            set
            {
                if (value.Height == MAXIMUM_HEIGHT)
                    base.Size = value;
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                Invalidate();
            }
        }

        public Color TextHoverColor
        {
            get { return m_hovercolor; }
            set
            {
                m_hovercolor = value;
                Invalidate();
            }
        }

        public Color GradientStartColor
        {
            get { return m_GradientStartColor; }
            set
            {
                m_GradientStartColor = value;
                Invalidate();
            }
        }

        public Color GradientEndColor
        {
            get { return m_GradientEndColor; }
            set
            {
                m_GradientEndColor = value;
                Invalidate();
            }
        }

        #endregion

        #region Overrides

        protected override void OnBackColorChanged(EventArgs e)
        {
            m_BackgroundBrush = new SolidBrush(this.BackColor);
            base.OnBackColorChanged(e);
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            m_HasFocus = true;
            base.OnGotFocus(e);
            Invalidate();
        }

        protected override void OnLostFocus(EventArgs e)
        {
            m_HasFocus = false;
            base.OnLostFocus(e);
            Invalidate();
        }

        private const int WM_KEYDOWN = 0x0100;
        private int m_msgkey = 0;
        public override bool PreProcessMessage(ref Message msg)
        {
            if (msg.Msg == WM_KEYDOWN)
            {
                m_msgkey = (int)msg.WParam;
                if (((Keys)m_msgkey) == Keys.Down)
                {
                    Point location = this.PointToScreen(new Point(this.ClientRectangle.Left, this.ClientRectangle.Top + this.ClientRectangle.Height));
                    //display color picker
                    m_DropDown.Show(location, ToolStripDropDownDirection.Default);
                    return true;
                }
                else
                    return base.PreProcessMessage(ref msg);
            }
            else
                return base.PreProcessMessage(ref msg);
        }

        protected override void OnResize(EventArgs e)
        {
            if (this.Height > MAXIMUM_HEIGHT)
                this.Size = new Size(this.Size.Width, MAXIMUM_HEIGHT);
            else
                base.OnResize(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (this.Enabled == false)
                return;
            m_IsHot = true;
            base.OnMouseMove(e);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (this.Enabled == false)
                return;
            m_IsHot = false;
            m_IsDropDownPressed = false;
            base.OnMouseLeave(e);
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this.Enabled == false)
                return;

            m_IsDropDownPressed = true;
            base.OnMouseDown(e);
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (this.Enabled == false)
                return;
            m_IsDropDownPressed = false;
            base.OnMouseUp(e);
            Invalidate();
            if ((m_dropdownrect.Contains(e.Location)) ||
                (m_textrect.Contains(e.Location)))
            {
                Point location = this.PointToScreen(new Point(this.ClientRectangle.Left, this.ClientRectangle.Top + this.ClientRectangle.Height));
                //display color picker
                m_DropDown.Show(location, ToolStripDropDownDirection.Default);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(m_BackgroundBrush, this.ClientRectangle);

            m_textrect = new Rectangle(this.ClientRectangle.X + m_Padding,
                this.ClientRectangle.Y + m_Padding,
                this.ClientRectangle.Width - ((m_Padding * 2) + m_DropdownDimensions),
                this.ClientRectangle.Height - (m_Padding * 2));

            opacity = 0x99; //153
            if ((m_IsDropDownPressed) || (!this.Enabled))
                opacity = (int)(.4f * opacity + .5f);

            gradBrush = new System.Drawing.Drawing2D.LinearGradientBrush(m_textrect,
            Color.FromArgb(opacity, m_GradientStartColor),
            Color.FromArgb(opacity / 3, m_GradientEndColor),
            System.Drawing.Drawing2D.LinearGradientMode.Vertical);

            e.Graphics.FillRectangle(gradBrush, m_textrect);

            m_dropdownrect = new Rectangle(m_textrect.X + m_textrect.Width,
                m_textrect.Y, m_DropdownDimensions, m_DropdownDimensions); //m_textrect.Height);

            if (m_IsHot)
            {
                System.Windows.Forms.ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.RaisedOuter);
                if (m_IsDropDownPressed)
                    System.Windows.Forms.ControlPaint.DrawComboButton(e.Graphics, m_dropdownrect, ButtonState.Pushed);
                else
                    System.Windows.Forms.ControlPaint.DrawComboButton(e.Graphics, m_dropdownrect, ButtonState.Normal);
            }
            else
            {
                if (this.Enabled)
                {
                    if (m_HasFocus)
                        System.Windows.Forms.ControlPaint.DrawFocusRectangle(e.Graphics, this.ClientRectangle);
                    else
                        System.Windows.Forms.ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.SunkenOuter);
                    if (m_IsDropDownPressed)
                        System.Windows.Forms.ControlPaint.DrawComboButton(e.Graphics, m_dropdownrect, ButtonState.Pushed);
                    else
                        System.Windows.Forms.ControlPaint.DrawComboButton(e.Graphics, m_dropdownrect, ButtonState.Flat);
                }
                else
                {
                    System.Windows.Forms.ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.SunkenOuter);
                    System.Windows.Forms.ControlPaint.DrawComboButton(e.Graphics, m_dropdownrect, ButtonState.Flat | ButtonState.Inactive);
                }
            }

            m_colorrect = new Rectangle(m_textrect.X, m_textrect.Y,
                m_colorwidth, m_textrect.Height);

            if (m_DropDown.Selector.SelectedColor != Color.Empty)
            {
                using (Brush br = new SolidBrush(m_DropDown.Selector.SelectedColor))
                {
                    e.Graphics.FillRectangle(br, m_colorrect);
                }
                m_strText = m_DropDown.Selector.SelectedColor.Name;
            }
            else
                m_strText = m_DefaultText;

            if (this.Enabled)
            {
                if ((m_IsHot) || (m_IsDropDownPressed))
                    m_tempforecolor = m_hovercolor;
                else
                    m_tempforecolor = this.ForeColor;
            }
            else
                m_tempforecolor = SystemColors.GrayText; //Color.LightSlateGray;

            //Draw text
            m_textrect.X = m_textrect.X + m_colorwidth + 1;
            m_textrect.Width -= m_colorwidth + 1;
            TextRenderer.DrawText(e.Graphics,
                m_strText,
                this.Font,
                m_textrect,
                m_tempforecolor,
                TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
        }
        #endregion

    }
    #endregion

    #region HtmlColorSelector
    //Add a ToolStripHtmlColorSelector control
    //Add a toolstrip, a dropdownbutton
    //Set the drop-down on the ToolStripDropDownButton to
    //ToolStripHtmlColorSelector
    //Subscribe to HtmlColorSelector events for color changing,...
    public class ToolStripHtmlColorSelector : ToolStripDropDown
    {
        private HtmlColorSelector m_Control = new HtmlColorSelector();
        public ToolStripHtmlColorSelector()
        {
            Items.Add(new ToolStripControlHost(m_Control));
            this.m_Control.SelectionChanged += new HtmlColorSelectorEventHandler(m_Control_SelectionChanged);
            this.m_Control.SelectionCancelled += new EventHandler(m_Control_SelectionCancelled);
            this.m_Control.ResetToDefaultColor += new EventHandler(m_Control_ResetToDefaultColor);
        }

        void m_Control_ResetToDefaultColor(object sender, EventArgs e)
        {
            this.Close(ToolStripDropDownCloseReason.CloseCalled);
        }

        void m_Control_SelectionCancelled(object sender, EventArgs e)
        {
            this.Close(ToolStripDropDownCloseReason.CloseCalled);
        }

        void m_Control_SelectionChanged(object sender, HtmlColorSelectorEventArgs e)
        {
            this.Close(ToolStripDropDownCloseReason.CloseCalled);
        }

        public HtmlColorSelector Selector
        {
            get { return m_Control; }
        }

        protected override void OnOpened(EventArgs e)
        {
            base.OnOpened(e);
            //set focus to control for keyboard processing
            //left, right, up, down, cancel, na denter keys are handled
            this.m_Control.Focus();
        }

    }

    public class HtmlColorSelectorEventArgs : EventArgs
    {
        public Color SelectedColor;
        public HtmlColorSelectorEventArgs()
        {
            this.SelectedColor = Color.Empty;
        }
    }
    public delegate void HtmlColorSelectorEventHandler(object sender, HtmlColorSelectorEventArgs e);

    public class HtmlColorSelector : Control
    {
        public event HtmlColorSelectorEventHandler SelectionChanged;
        //Cancel key is accounted for
        public event EventHandler SelectionCancelled;
        //When the Reset to default part is clicked
        //Default color can be set via property, along with the text
        public event EventHandler ResetToDefaultColor;
        private HtmlColorSelectorEventArgs m_eventArgs = new HtmlColorSelectorEventArgs();

        public HtmlColorSelector()
        {
            //To stop flickering
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.CacheText, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            LoadColorBoxs();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        public override Size MinimumSize
        {
            get
            {
                //return base.MinimumSize;
                return new Size((MAX_COLS * m_ColorBoxDimensions) + (m_Spacing * (MAX_COLS + 1)), 0);
            }
            set
            {
                base.MinimumSize = value;
            }
        }

        private class ColorBox
        {
            public Color BoxColor;
            public Rectangle BoxRectangle;
            public int Index; // zero based
            public ColorBox()
            {
                this.BoxColor = Color.Empty;
                this.BoxRectangle = Rectangle.Empty;
                this.Index = -1;
            }
            public ColorBox(Color _BoxColor, Rectangle _BoxRectangle, int _Index)
            {
                this.BoxColor = _BoxColor;
                this.BoxRectangle = _BoxRectangle;
                this.Index = _Index;
            }
        }
        private System.ComponentModel.IContainer components = null;
        private List<ColorBox> m_ColorBoxs = new List<ColorBox>();
        private ColorBox m_SelectedBox = null;
        private ColorBox m_HoveredBox = null;
        private int m_ColorBoxDimensions = 15; //pixel
        private int m_Spacing = 2; //pixel
        private const int MAX_COLS = 20;
        private Brush m_BackgroundBrush = new SolidBrush(SystemColors.Control);
        private Rectangle m_paintrect = Rectangle.Empty;
        private Brush m_boxbrush = new SolidBrush(Color.Empty);
        private Pen m_highlightpen = new Pen(Color.Black, 2);
        private string m_paintstring = string.Empty;
        private Rectangle m_rectboxs = Rectangle.Empty;
        private Rectangle m_recttext = Rectangle.Empty;
        private const string DEFAULT_TEXT_COLOR = "Reset to default color";
        private Rectangle m_rectdefaultcolor = Rectangle.Empty;
        private bool m_overdefaultcolor = false;
        private Color m_DefaultColor = Color.Empty;

        public Color SelectedColor
        {
            get
            {
                if (m_SelectedBox != null)
                    return m_SelectedBox.BoxColor;
                else
                    return Color.Empty;
            }
            set
            {
                m_SelectedBox = null;
                if (value == Color.Empty)
                    return;
                foreach (ColorBox box in m_ColorBoxs)
                {
                    if ((box.BoxColor.R == value.R) &&
                        (box.BoxColor.G == value.G) &&
                        (box.BoxColor.B == value.B))
                    {
                        m_SelectedBox = box;
                        break;
                    }
                }
            }
        }

        public Color DefaultColor
        {
            get { return m_DefaultColor; }
            set
            {
                m_DefaultColor = value;
                Invalidate();
            }
        }

        private void LoadColorBoxs()
        {
            int x = m_Spacing;
            int y = m_Spacing;
            int movewpos = m_ColorBoxDimensions + m_Spacing;

            Array knownColors = Enum.GetValues(typeof(System.Drawing.KnownColor));
            int curcol = 1;
            int index = 0;
            bool gotit = false;
            List<Color> mycolors = new List<Color>();

            foreach (KnownColor k in knownColors)
            {
                Color c = Color.FromKnownColor(k);

                if (!c.IsSystemColor && (c.A > 0))
                {
                    gotit = false;
                    for (index = 0; index < mycolors.Count; index++)
                    {
                        //Sort by brightness
                        if (c.GetBrightness() > mycolors[index].GetBrightness())
                        {
                            gotit = true;
                            break;
                        }
                    }
                    if (gotit)
                        mycolors.Insert(index, c);
                    else
                        mycolors.Add(c);
                }
            }

            foreach (Color item in mycolors)
            {
                Rectangle rect = new Rectangle(
                    x, y,
                    m_ColorBoxDimensions,
                    m_ColorBoxDimensions);
                ColorBox box = new ColorBox(item, rect, m_ColorBoxs.Count);
                m_ColorBoxs.Add(box);
                curcol++;
                //New row
                if (curcol > MAX_COLS)
                {
                    curcol = 1;
                    x = m_Spacing;
                    y += movewpos;
                }
                else
                {
                    x += movewpos;
                }
            }

            //Adjust height, account for status and reset default text
            this.Height = y + (movewpos * 2);
        }

        //sort of works
        private void SetupHighlightPen(Color c)
        {
            if ((c.G > 128) &&
                (c.B > 128)) // &&
            //(c.R > 128) )
            {
                m_highlightpen = new Pen(Color.Black, 2);
            }
            else
                m_highlightpen = new Pen(Color.White, 2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Fill background
            e.Graphics.FillRectangle(m_BackgroundBrush, e.ClipRectangle);

            m_paintstring = string.Empty;
            //Draw boxs
            foreach (ColorBox box in m_ColorBoxs)
            {
                m_paintrect = new Rectangle(
                    e.ClipRectangle.X + box.BoxRectangle.X,
                    e.ClipRectangle.Y + box.BoxRectangle.Y,
                    m_ColorBoxDimensions, m_ColorBoxDimensions);
                m_boxbrush = new SolidBrush(box.BoxColor);
                e.Graphics.FillRectangle(m_boxbrush, m_paintrect);
                //Selected or hovered box
                if ((m_SelectedBox != null) && (m_SelectedBox.Index == box.Index))
                {
                    SetupHighlightPen(box.BoxColor);
                    e.Graphics.DrawRectangle(m_highlightpen, m_paintrect);
                    //System.Windows.Forms.ControlPaint.DrawBorder3D(e.Graphics, m_paintrect, Border3DStyle.Raised);
                }
                else if ((m_HoveredBox != null) && (m_HoveredBox.Index == box.Index))
                {
                    SetupHighlightPen(box.BoxColor);
                    e.Graphics.DrawRectangle(m_highlightpen, m_paintrect);
                    m_paintstring = box.BoxColor.Name + " (" + box.BoxColor.R.ToString() + ", " + box.BoxColor.G.ToString() + ", " + box.BoxColor.B.ToString() + ")";
                }
            }

            //Get the rectangle for boxs
            m_rectboxs = e.ClipRectangle;
            m_rectboxs.X += m_Spacing;
            m_rectboxs.Y += m_Spacing;
            m_rectboxs.Height -= (m_ColorBoxDimensions + m_Spacing);

            //No text, see if a box has been selected
            if ((string.IsNullOrEmpty(m_paintstring)) && (m_SelectedBox != null))
                m_paintstring = m_SelectedBox.BoxColor.Name + " (" + m_SelectedBox.BoxColor.R.ToString() + ", " + m_SelectedBox.BoxColor.G.ToString() + ", " + m_SelectedBox.BoxColor.B.ToString() + ")";

            m_recttext = new Rectangle(e.ClipRectangle.X + m_Spacing,
                e.ClipRectangle.Y + (this.Height - ((m_ColorBoxDimensions + m_Spacing) * 2)),
                e.ClipRectangle.Width - (m_Spacing * 2), m_ColorBoxDimensions);
            e.Graphics.FillRectangle(Brushes.White, m_recttext);

            e.Graphics.DrawString(m_paintstring, this.Font, Brushes.Black,
                new PointF(
                (float)m_recttext.X,
                (float)m_recttext.Y));

            //Draw default text
            m_rectdefaultcolor = new Rectangle(
                m_recttext.X, m_recttext.Y + m_recttext.Height + m_Spacing, m_recttext.Width, m_ColorBoxDimensions);

            if (m_overdefaultcolor)
                e.Graphics.FillRectangle(Brushes.LightSkyBlue, m_rectdefaultcolor);

            e.Graphics.DrawString(DEFAULT_TEXT_COLOR, this.Font, Brushes.Black,
                new PointF(
                (float)m_rectdefaultcolor.X,
                (float)m_rectdefaultcolor.Y));
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                if (m_rectboxs.Contains(e.Location))
                {
                    m_SelectedBox = null;
                    foreach (ColorBox box in m_ColorBoxs)
                    {
                        if (box.BoxRectangle.Contains(e.Location))
                        {
                            m_SelectedBox = box;
                            break;
                        }
                    }
                    //this.Invalidate();
                    if ((m_SelectedBox != null) && (SelectionChanged != null))
                    {
                        m_eventArgs.SelectedColor = m_SelectedBox.BoxColor;
                        SelectionChanged(this, m_eventArgs);
                    }
                }
                else if (m_rectdefaultcolor.Contains(e.Location))
                {
                    m_SelectedBox = null;
                    //this.Invalidate();
                    if (ResetToDefaultColor != null)
                    {
                        ResetToDefaultColor(this, EventArgs.Empty);
                    }
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            m_HoveredBox = null;
            m_overdefaultcolor = false;
            if (m_rectboxs.Contains(e.Location))
            {
                foreach (ColorBox box in m_ColorBoxs)
                {
                    if (box.BoxRectangle.Contains(e.Location))
                    {
                        m_HoveredBox = box;
                        break;
                    }
                }
            }
            else if (m_rectdefaultcolor.Contains(e.Location))
            {
                m_overdefaultcolor = true;
            }
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            m_HoveredBox = null;
            m_overdefaultcolor = false;
            base.OnMouseLeave(e);
            this.Invalidate();
        }

        private const int WM_KEYDOWN = 0x0100;
        private void ProcessKeyDownEvent()
        {
            if (m_HoveredBox == null)
            {
                m_HoveredBox = m_ColorBoxs[0];
            }
            else
            {
                if ((m_HoveredBox.Index + MAX_COLS) < m_ColorBoxs.Count)
                {
                    m_HoveredBox = m_ColorBoxs[m_HoveredBox.Index + MAX_COLS];
                }
            }
            Invalidate();
        }

        private void ProcessKeyUpEvent()
        {
            if (m_HoveredBox == null)
            {
                m_HoveredBox = m_ColorBoxs[0];
            }
            else
            {
                if ((m_HoveredBox.Index - MAX_COLS) > -1)
                {
                    m_HoveredBox = m_ColorBoxs[m_HoveredBox.Index - MAX_COLS];
                }
            }
            Invalidate();
        }

        private void ProcessKeyLeftEvent()
        {
            if (m_HoveredBox == null)
            {
                m_HoveredBox = m_ColorBoxs[0];
            }
            else
            {
                //Anything before
                if ((m_HoveredBox.Index - 1) > -1)
                {
                    m_HoveredBox = m_ColorBoxs[m_HoveredBox.Index - 1];
                }
                else //Start from End
                {
                    m_HoveredBox = m_ColorBoxs[m_ColorBoxs.Count - 1];
                }
            }
            Invalidate();
        }

        private void ProcessKeyRightEvent()
        {
            if (m_HoveredBox == null)
            {
                m_HoveredBox = m_ColorBoxs[0];
            }
            else
            {
                //ColorBox index is zero based
                //Anything after
                if ((m_HoveredBox.Index + 1) < m_ColorBoxs.Count)
                {
                    m_HoveredBox = m_ColorBoxs[m_HoveredBox.Index + 1];
                }
                else //Start from beginning
                {
                    m_HoveredBox = m_ColorBoxs[0];
                }
            }
            Invalidate();
        }

        private int m_msgkey = 0;
        public override bool PreProcessMessage(ref Message msg)
        {
            if (msg.Msg == WM_KEYDOWN)
            {
                m_msgkey = (int)msg.WParam;
                if (((Keys)m_msgkey) == Keys.Up)
                {
                    ProcessKeyUpEvent();
                    return true;
                }
                else if (((Keys)m_msgkey) == Keys.Down)
                {
                    ProcessKeyDownEvent();
                    return true;
                }
                else if (((Keys)m_msgkey) == Keys.Left)
                {
                    ProcessKeyLeftEvent();
                    return true;
                }
                else if (((Keys)m_msgkey) == Keys.Right)
                {
                    ProcessKeyRightEvent();
                    return true;
                }
                else if (((Keys)m_msgkey) == Keys.Cancel)
                {
                    m_SelectedBox = null;
                    if (SelectionCancelled != null)
                        SelectionCancelled(this, EventArgs.Empty);
                    return true;
                }
                else if (((Keys)m_msgkey) == Keys.Enter)
                {
                    if ((m_HoveredBox != null) && (SelectionChanged != null))
                    {
                        m_SelectedBox = m_HoveredBox;
                        m_eventArgs.SelectedColor = m_SelectedBox.BoxColor;
                        SelectionChanged(this, m_eventArgs);
                    }
                    return true;
                }
                else
                    return base.PreProcessMessage(ref msg);
            }
            else
                return base.PreProcessMessage(ref msg);
        }

    }
    #endregion

    #endregion
}