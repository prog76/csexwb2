namespace DemoApp
{
    partial class frmFind
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboColors = new System.Windows.Forms.ComboBox();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.chkMatchWholeWord = new System.Windows.Forms.CheckBox();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.chkSearchAndHighlightMatches = new System.Windows.Forms.CheckBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBtnUpward = new System.Windows.Forms.RadioButton();
            this.radioBtnDownward = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboColors
            // 
            this.comboColors.FormattingEnabled = true;
            this.comboColors.Items.AddRange(new object[] {
            "aliceblue",
            "antiquewhite",
            "aqua",
            "aquamarine",
            "azure",
            "beige",
            "bisque",
            "black",
            "blanchedalmond",
            "blue",
            "blueviolet",
            "brown ",
            "burlywood",
            "cadetblue",
            "chartreuse",
            "chocolate ",
            "coral",
            "cornflowerblue",
            "cornsilk",
            "crimson",
            "cyan",
            "darkblue",
            "darkcyan",
            "darkgoldenrod ",
            "darkgray",
            "darkgreen",
            "darkkhaki",
            "darkmagenta",
            "darkolivegreen",
            "darkorange",
            "darkorchid",
            "darkred",
            "darksalmon",
            "darkseagreen",
            "darkslateblue",
            "darkslategray ",
            "darkturquoise",
            "darkviolet",
            "deeppink",
            "deepskyblue",
            "dimgray",
            "dodgerblue",
            "firebrick",
            "floralwhite ",
            "forestgreen",
            "fuchsia",
            "gainsboro",
            "ghostwhite ",
            "gold",
            "goldenrod",
            "gray",
            "green",
            "greenyellow",
            "honeydew",
            "hotpink",
            "indianred",
            "indigo",
            "ivory",
            "khaki",
            "lavender",
            "lavenderblush",
            "lawngreen",
            "lemonchiffon",
            "lightblue ",
            "lightcoral",
            "lightcyan",
            "lightgoldenrodyellow",
            "lightgreen",
            "lightgrey",
            "lightpink",
            "lightsalmon",
            "lightseagreen",
            "lightskyblue",
            "lightslategray",
            "lightsteelblue",
            "lightyellow",
            "lime",
            "limegreen",
            "linen",
            "magenta",
            "maroon",
            "mediumaquamarine",
            "mediumblue",
            "mediumorchid",
            "mediumpurple",
            "mediumseagreen",
            "mediumslateblue",
            "mediumspringgreen",
            "mediumturquoise",
            "mediumvioletred",
            "midnightblue",
            "mintcream",
            "mistyrose",
            "moccasin",
            "navajowhite",
            "navy",
            "oldlace",
            "olive",
            "olivedrab",
            "orange",
            "orangered",
            "orchid",
            "palegoldenrod",
            "palegreen",
            "paleturquoise",
            "palevioletred",
            "papayawhip",
            "peachpuff",
            "peru",
            "pink",
            "plum",
            "powderblue",
            "purple",
            "red",
            "rosybrown",
            "royalblue ",
            "saddlebrown",
            "salmon",
            "sandybrown",
            "seagreen",
            "seashell",
            "sienna",
            "silver",
            "skyblue ",
            "slateblue",
            "slategray",
            "snow",
            "springgreen",
            "steelblue",
            "tan",
            "teal",
            "thistle",
            "tomato",
            "turquoise",
            "violet",
            "wheat",
            "white",
            "whitesmoke ",
            "yellowgreen"});
            this.comboColors.Location = new System.Drawing.Point(87, 126);
            this.comboColors.Name = "comboColors";
            this.comboColors.Size = new System.Drawing.Size(114, 21);
            this.comboColors.TabIndex = 5;
            // 
            // txtFind
            // 
            this.txtFind.Location = new System.Drawing.Point(12, 12);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(189, 20);
            this.txtFind.TabIndex = 0;
            this.txtFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyUp);
            // 
            // chkMatchWholeWord
            // 
            this.chkMatchWholeWord.AutoSize = true;
            this.chkMatchWholeWord.Location = new System.Drawing.Point(12, 52);
            this.chkMatchWholeWord.Name = "chkMatchWholeWord";
            this.chkMatchWholeWord.Size = new System.Drawing.Size(119, 17);
            this.chkMatchWholeWord.TabIndex = 2;
            this.chkMatchWholeWord.Text = "Match Whole Word";
            this.chkMatchWholeWord.UseVisualStyleBackColor = true;
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.AutoSize = true;
            this.chkMatchCase.Location = new System.Drawing.Point(12, 75);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(83, 17);
            this.chkMatchCase.TabIndex = 3;
            this.chkMatchCase.Text = "Match Case";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // chkSearchAndHighlightMatches
            // 
            this.chkSearchAndHighlightMatches.AutoSize = true;
            this.chkSearchAndHighlightMatches.Location = new System.Drawing.Point(12, 103);
            this.chkSearchAndHighlightMatches.Name = "chkSearchAndHighlightMatches";
            this.chkSearchAndHighlightMatches.Size = new System.Drawing.Size(169, 17);
            this.chkSearchAndHighlightMatches.TabIndex = 4;
            this.chkSearchAndHighlightMatches.Text = "Search and Highlight Matches";
            this.chkSearchAndHighlightMatches.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(217, 12);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(111, 23);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(217, 45);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnUpward);
            this.groupBox1.Controls.Add(this.radioBtnDownward);
            this.groupBox1.Location = new System.Drawing.Point(217, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 73);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Direction";
            // 
            // radioBtnUpward
            // 
            this.radioBtnUpward.AutoSize = true;
            this.radioBtnUpward.Location = new System.Drawing.Point(15, 42);
            this.radioBtnUpward.Name = "radioBtnUpward";
            this.radioBtnUpward.Size = new System.Drawing.Size(62, 17);
            this.radioBtnUpward.TabIndex = 7;
            this.radioBtnUpward.Text = "Upward";
            this.radioBtnUpward.UseVisualStyleBackColor = true;
            // 
            // radioBtnDownward
            // 
            this.radioBtnDownward.AutoSize = true;
            this.radioBtnDownward.Checked = true;
            this.radioBtnDownward.Location = new System.Drawing.Point(15, 19);
            this.radioBtnDownward.Name = "radioBtnDownward";
            this.radioBtnDownward.Size = new System.Drawing.Size(76, 17);
            this.radioBtnDownward.TabIndex = 6;
            this.radioBtnDownward.TabStop = true;
            this.radioBtnDownward.Text = "Downward";
            this.radioBtnDownward.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(9, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Highligh Color";
            // 
            // frmFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(341, 159);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.chkSearchAndHighlightMatches);
            this.Controls.Add(this.chkMatchCase);
            this.Controls.Add(this.chkMatchWholeWord);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.comboColors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFind";
            this.Text = "Find";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFind_FormClosing);
            this.Load += new System.EventHandler(this.frmFind_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboColors;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.CheckBox chkMatchWholeWord;
        private System.Windows.Forms.CheckBox chkMatchCase;
        private System.Windows.Forms.CheckBox chkSearchAndHighlightMatches;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtnUpward;
        private System.Windows.Forms.RadioButton radioBtnDownward;
        private System.Windows.Forms.Label label1;
    }
}