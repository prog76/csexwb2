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
    #region CustomComboBox class
    /// <summary>
    /// A custom combobox
    /// Can load and display, plain text, system fonts, Html colors, text+image
    /// </summary>
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
    /// <summary>
    /// Toolstrip version of CustomComboBox control
    /// </summary>
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
}
