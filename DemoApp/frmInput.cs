using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DemoApp
{
    //if (AllForms.m_frmInput.ShowDialogInternal("Some Text\r\nMore text.", this) == DialogResult.OK)
    public partial class frmInput : Form
    {
        public frmInput()
        {
            InitializeComponent();
        }

        public string GetInputBoxText()
        {
            return txtInput.Text;
        }

        private bool m_Result = false;

        public DialogResult ShowDialogInternal(string Text, IWin32Window owner)
        {
            m_Result = false;
            txtInput.Text = Text;
            this.ShowDialog(owner);
            return (m_Result) ? DialogResult.OK : DialogResult.Cancel;
        }

        private void txtInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                m_Result = true;
                this.Hide();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            m_Result = true;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_Result = false;
            this.Hide();
        }

        private void frmInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                m_Result = false;
                this.Hide();
            }
        }
    }
}