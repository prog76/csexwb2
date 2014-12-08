using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class frmTableCellProp : Form
    {
        public frmTableCellProp()
        {
            InitializeComponent();
            HorizontalAlignmentcomboBox.SelectedIndex = 0;
            VerticalAlignmentcomboBox.SelectedIndex = 0;
        }

        public DialogResult m_Result = DialogResult.Cancel;
        public string m_HAlignment = string.Empty;
        public string m_VAlignment = string.Empty;
        public string m_BackColor = string.Empty; //change to color
        public string m_BorderColor = string.Empty;
        public string m_LightBorderColor = string.Empty;
        public string m_DarkBorderColor = string.Empty;
        public bool m_NoWrap = false; //default

        public void SetupValues(string Halign, string Valign, Color backcolor,
            Color bordercolor, Color borderlightcolor, Color borderdarkcolor,
            bool nowrap)
        {
            int index = 0;
            if (!string.IsNullOrEmpty(Halign))
            {
                index = HorizontalAlignmentcomboBox.FindString(Halign);
                if (index > 0)
                    HorizontalAlignmentcomboBox.SelectedIndex = index;
            }
            else
                HorizontalAlignmentcomboBox.SelectedIndex = 0;

            if (!string.IsNullOrEmpty(Valign))
            {
                index = VerticalAlignmentcomboBox.FindString(Valign);
                if (index > 0)
                    VerticalAlignmentcomboBox.SelectedIndex = index;
            }
            else
                VerticalAlignmentcomboBox.SelectedIndex = 0;

            backgoundcolorcomboBox.SelectedColor = backcolor;
            bordercolorcomboBox.SelectedColor = bordercolor;
            borderlightcolorcomboBox.SelectedColor = borderlightcolor;
            borderdarkcolorcomboBox.SelectedColor = borderdarkcolor;
            chkNoWrap.Checked = nowrap;
        }

        private void FillValues()
        {
            m_Result = DialogResult.OK;
            
            m_HAlignment = string.Empty;
            if (HorizontalAlignmentcomboBox.SelectedIndex > 0)
                m_HAlignment = HorizontalAlignmentcomboBox.Items[HorizontalAlignmentcomboBox.SelectedIndex].ToString();
            
            m_VAlignment = string.Empty;
            if (VerticalAlignmentcomboBox.SelectedIndex > 0)
                m_VAlignment = VerticalAlignmentcomboBox.Items[VerticalAlignmentcomboBox.SelectedIndex].ToString();

            m_BackColor = (backgoundcolorcomboBox.SelectedColor == Color.Empty) ? 
                string.Empty : backgoundcolorcomboBox.SelectedColor.Name;
            
            m_BorderColor = (bordercolorcomboBox.SelectedColor == Color.Empty) ? 
                string.Empty : bordercolorcomboBox.SelectedColor.Name;

            m_LightBorderColor = (borderlightcolorcomboBox.SelectedColor == Color.Empty) ?
                string.Empty : borderlightcolorcomboBox.SelectedColor.Name;

            m_DarkBorderColor = (borderdarkcolorcomboBox.SelectedColor == Color.Empty) ?
                string.Empty : borderdarkcolorcomboBox.SelectedColor.Name;

            m_NoWrap = chkNoWrap.Checked;
            
        }

        private void btnCloseNoChange_Click(object sender, EventArgs e)
        {
            this.Hide();
            m_Result = DialogResult.Cancel;
        }

        private void btnApplyClose_Click(object sender, EventArgs e)
        {
            FillValues();
            this.Hide();
        }

        private void frmTableCellProp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
                m_Result = DialogResult.Cancel;
            }
        }
    }
}