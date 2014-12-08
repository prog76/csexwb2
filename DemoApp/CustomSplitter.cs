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
    #region Custom Splitter based on SplitContainer
    /// <summary>
    /// A custom splitter based on SpliContainer
    /// Collapsable, gradient, tooltip, contextmenu, different visual styles
    /// </summary>
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
}
