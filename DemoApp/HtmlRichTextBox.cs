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
}
