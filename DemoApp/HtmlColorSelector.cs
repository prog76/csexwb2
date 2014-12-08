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

    #region ToolStripHtmlColorSelector Control
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
    #endregion

    #region HtmlColorSelector
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

        private void SetupHighlightPen(Color c)
        {
            int nThreshold = 105;
            int bgDelta = Convert.ToInt32((c.R * 0.299) + (c.G * 0.587) +
                                          (c.B * 0.114));

            Color foreColor = (255 - bgDelta < nThreshold) ? Color.Black : Color.White;
            m_highlightpen = new Pen(foreColor, 2);
            //if ((c.G > 128) &&
            //    (c.B > 128))
            //{
            //    m_highlightpen = new Pen(Color.Black, 2);
            //}
            //else
            //    m_highlightpen = new Pen(Color.White, 2);
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
                    if (SelectionChanged != null)
                    {
                        m_eventArgs.SelectedColor = m_DefaultColor;
                        SelectionChanged(this, m_eventArgs);
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


}
