using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DemoApp
{
    public delegate void FindInPage(string FindPhrase,bool MatchWholeWord,bool MatchCase, bool Downward, bool HighlightAll, string sColor);
    public partial class frmFind : Form
    {
        public event FindInPage FindInPageEvent;
        public frmFind()
        {
            InitializeComponent();
        }

        private void frmFind_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (FindInPageEvent != null)
            {
                FindInPageEvent(txtFind.Text, chkMatchWholeWord.Checked,
                    chkMatchCase.Checked, ((radioBtnDownward.Checked) ? true : false),
                    chkSearchAndHighlightMatches.Checked, comboColors.Text);
            }
        }

        private void frmFind_Load(object sender, EventArgs e)
        {
            comboColors.SelectedIndex = 0;
        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (FindInPageEvent != null)
                {
                    FindInPageEvent(txtFind.Text, chkMatchWholeWord.Checked,
                        chkMatchCase.Checked, ((radioBtnDownward.Checked) ? true : false),
                        chkSearchAndHighlightMatches.Checked, comboColors.Text);
                }
            }
        }
    }
}