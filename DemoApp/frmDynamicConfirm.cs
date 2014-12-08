using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class frmDynamicConfirm : Form
    {
        private string m_Result = string.Empty;
        public string DisplayConfirm(IWin32Window win, string msg, string text, string btn1, string btn2, string btn3, string btn4)
        {
            //Reset all
            m_Result = string.Empty;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            //Which btn to setup

            if (!string.IsNullOrEmpty(text))
                this.Text = text;
            else
                this.Text = "Confirmation Required";

            txtDisplay.Text = msg;

            if (!string.IsNullOrEmpty(btn1))                
            {
                button1.Visible = true;
                button1.Text = btn1;
            }
            if (!string.IsNullOrEmpty(btn2))
            {
                button2.Visible = true;
                button2.Text = btn2;
            }
            if (!string.IsNullOrEmpty(btn3))
            {
                button3.Visible = true;
                button3.Text = btn3;
            }
            if (!string.IsNullOrEmpty(btn4))
            {
                button4.Visible = true;
                button4.Text = btn4;
            }

            this.ShowDialog(win);

            return m_Result;
        }

        public frmDynamicConfirm()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmDynamicConfirm_Load);
            this.FormClosing += new FormClosingEventHandler(frmDynamicConfirm_FormClosing);
            this.button1.Click += new EventHandler(button_Click);
            this.button2.Click += new EventHandler(button_Click);
            this.button3.Click += new EventHandler(button_Click);
            this.button4.Click += new EventHandler(button_Click);
        }

        void button_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btn = sender as Button;
                if (btn != null)
                    m_Result = btn.Text;
                this.Hide();
            }
        }

        void frmDynamicConfirm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        void frmDynamicConfirm_Load(object sender, EventArgs e)
        {
            
        }
    }
}