using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class frmAuthenticate : Form
    {
        private bool m_AuthSuccess = false;
        public string m_Username = string.Empty;
        public string m_Password = string.Empty;

        private void ResetAllFields()
        {
            m_AuthSuccess = false;
            m_Username = string.Empty;
            m_Password = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            chkViewPassword.Text = "Show Password";
            txtPassword.PasswordChar = '*';
        }

        public frmAuthenticate()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialogInternal(IWin32Window owner)
        {
            ResetAllFields();
            this.ShowDialog(owner);
            return (m_AuthSuccess) ? DialogResult.OK : DialogResult.Cancel;
        }

        private void chkViewPassword_Click(object sender, EventArgs e)
        {
            if (chkViewPassword.Checked)
            {
                chkViewPassword.Text = "Hide Password";
                txtPassword.PasswordChar = new char();
            }
            else
            {
                chkViewPassword.Text = "Show Password";
                txtPassword.PasswordChar = '*';
            }
        }

        private void frmAuthenticate_Load(object sender, EventArgs e)
        {
            this.Icon = AllForms.BitmapToIcon(14);
        }

        private void frmAuthenticate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            m_AuthSuccess = true;
            m_Username = txtUserName.Text;
            m_Password = txtPassword.Text;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Just hide
            this.Hide();
        }
    }
}