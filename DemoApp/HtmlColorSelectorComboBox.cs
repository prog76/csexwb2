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
}
