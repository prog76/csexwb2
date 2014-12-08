namespace DemoApp
{
    partial class frmTableCellProp
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.VerticalAlignmentcomboBox = new System.Windows.Forms.ComboBox();
            this.HorizontalAlignmentcomboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnApplyClose = new System.Windows.Forms.Button();
            this.btnCloseNoChange = new System.Windows.Forms.Button();
            this.chkNoWrap = new System.Windows.Forms.CheckBox();
            this.backgoundcolorcomboBox = new DemoApp.HtmlColorSelectorComboBox();
            this.bordercolorcomboBox = new DemoApp.HtmlColorSelectorComboBox();
            this.borderlightcolorcomboBox = new DemoApp.HtmlColorSelectorComboBox();
            this.borderdarkcolorcomboBox = new DemoApp.HtmlColorSelectorComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.VerticalAlignmentcomboBox);
            this.groupBox1.Controls.Add(this.HorizontalAlignmentcomboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Layout:";
            // 
            // VerticalAlignmentcomboBox
            // 
            this.VerticalAlignmentcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VerticalAlignmentcomboBox.FormattingEnabled = true;
            this.VerticalAlignmentcomboBox.Items.AddRange(new object[] {
            "Default",
            "Top",
            "Middle",
            "Baseline",
            "Bottom"});
            this.VerticalAlignmentcomboBox.Location = new System.Drawing.Point(127, 47);
            this.VerticalAlignmentcomboBox.Name = "VerticalAlignmentcomboBox";
            this.VerticalAlignmentcomboBox.Size = new System.Drawing.Size(126, 21);
            this.VerticalAlignmentcomboBox.TabIndex = 3;
            // 
            // HorizontalAlignmentcomboBox
            // 
            this.HorizontalAlignmentcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HorizontalAlignmentcomboBox.FormattingEnabled = true;
            this.HorizontalAlignmentcomboBox.Items.AddRange(new object[] {
            "Default",
            "left",
            "center",
            "right",
            "justify"});
            this.HorizontalAlignmentcomboBox.Location = new System.Drawing.Point(127, 20);
            this.HorizontalAlignmentcomboBox.Name = "HorizontalAlignmentcomboBox";
            this.HorizontalAlignmentcomboBox.Size = new System.Drawing.Size(126, 21);
            this.HorizontalAlignmentcomboBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vertical Alignment:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Horizontal Alignment:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.borderdarkcolorcomboBox);
            this.groupBox2.Controls.Add(this.borderlightcolorcomboBox);
            this.groupBox2.Controls.Add(this.bordercolorcomboBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 113);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Border:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Dark Color:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Light Color:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Color:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.backgoundcolorcomboBox);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(12, 212);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(279, 56);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Background:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Color:";
            // 
            // btnApplyClose
            // 
            this.btnApplyClose.Location = new System.Drawing.Point(12, 319);
            this.btnApplyClose.Name = "btnApplyClose";
            this.btnApplyClose.Size = new System.Drawing.Size(109, 31);
            this.btnApplyClose.TabIndex = 3;
            this.btnApplyClose.Text = "Apply and Close";
            this.btnApplyClose.UseVisualStyleBackColor = true;
            this.btnApplyClose.Click += new System.EventHandler(this.btnApplyClose_Click);
            // 
            // btnCloseNoChange
            // 
            this.btnCloseNoChange.Location = new System.Drawing.Point(143, 319);
            this.btnCloseNoChange.Name = "btnCloseNoChange";
            this.btnCloseNoChange.Size = new System.Drawing.Size(109, 31);
            this.btnCloseNoChange.TabIndex = 4;
            this.btnCloseNoChange.Text = "Close";
            this.btnCloseNoChange.UseVisualStyleBackColor = true;
            this.btnCloseNoChange.Click += new System.EventHandler(this.btnCloseNoChange_Click);
            // 
            // chkNoWrap
            // 
            this.chkNoWrap.AutoSize = true;
            this.chkNoWrap.Location = new System.Drawing.Point(12, 285);
            this.chkNoWrap.Name = "chkNoWrap";
            this.chkNoWrap.Size = new System.Drawing.Size(66, 17);
            this.chkNoWrap.TabIndex = 5;
            this.chkNoWrap.Text = "NoWrap";
            this.chkNoWrap.UseVisualStyleBackColor = true;
            // 
            // backgoundcolorcomboBox
            // 
            this.backgoundcolorcomboBox.DefaultColor = System.Drawing.Color.Empty;
            this.backgoundcolorcomboBox.DefaultColorText = "Default";
            this.backgoundcolorcomboBox.GradientEndColor = System.Drawing.Color.White;
            this.backgoundcolorcomboBox.GradientStartColor = System.Drawing.Color.White;
            this.backgoundcolorcomboBox.Location = new System.Drawing.Point(127, 25);
            this.backgoundcolorcomboBox.Name = "backgoundcolorcomboBox";
            this.backgoundcolorcomboBox.SelectedColor = System.Drawing.Color.Empty;
            this.backgoundcolorcomboBox.Size = new System.Drawing.Size(126, 21);
            this.backgoundcolorcomboBox.TabIndex = 1;
            this.backgoundcolorcomboBox.Text = "htmlColorSelectorComboBox1";
            this.backgoundcolorcomboBox.TextHoverColor = System.Drawing.Color.Blue;
            // 
            // bordercolorcomboBox
            // 
            this.bordercolorcomboBox.DefaultColor = System.Drawing.Color.Empty;
            this.bordercolorcomboBox.DefaultColorText = "Default";
            this.bordercolorcomboBox.GradientEndColor = System.Drawing.Color.White;
            this.bordercolorcomboBox.GradientStartColor = System.Drawing.Color.White;
            this.bordercolorcomboBox.Location = new System.Drawing.Point(127, 28);
            this.bordercolorcomboBox.Name = "bordercolorcomboBox";
            this.bordercolorcomboBox.SelectedColor = System.Drawing.Color.Empty;
            this.bordercolorcomboBox.Size = new System.Drawing.Size(126, 21);
            this.bordercolorcomboBox.TabIndex = 6;
            this.bordercolorcomboBox.Text = "htmlColorSelectorComboBox1";
            this.bordercolorcomboBox.TextHoverColor = System.Drawing.Color.Blue;
            // 
            // borderlightcolorcomboBox
            // 
            this.borderlightcolorcomboBox.DefaultColor = System.Drawing.Color.Empty;
            this.borderlightcolorcomboBox.DefaultColorText = "Default";
            this.borderlightcolorcomboBox.GradientEndColor = System.Drawing.Color.White;
            this.borderlightcolorcomboBox.GradientStartColor = System.Drawing.Color.White;
            this.borderlightcolorcomboBox.Location = new System.Drawing.Point(127, 55);
            this.borderlightcolorcomboBox.Name = "borderlightcolorcomboBox";
            this.borderlightcolorcomboBox.SelectedColor = System.Drawing.Color.Empty;
            this.borderlightcolorcomboBox.Size = new System.Drawing.Size(126, 21);
            this.borderlightcolorcomboBox.TabIndex = 7;
            this.borderlightcolorcomboBox.Text = "htmlColorSelectorComboBox1";
            this.borderlightcolorcomboBox.TextHoverColor = System.Drawing.Color.Blue;
            // 
            // borderdarkcolorcomboBox
            // 
            this.borderdarkcolorcomboBox.DefaultColor = System.Drawing.Color.Empty;
            this.borderdarkcolorcomboBox.DefaultColorText = "Default";
            this.borderdarkcolorcomboBox.GradientEndColor = System.Drawing.Color.White;
            this.borderdarkcolorcomboBox.GradientStartColor = System.Drawing.Color.White;
            this.borderdarkcolorcomboBox.Location = new System.Drawing.Point(127, 82);
            this.borderdarkcolorcomboBox.Name = "borderdarkcolorcomboBox";
            this.borderdarkcolorcomboBox.SelectedColor = System.Drawing.Color.Empty;
            this.borderdarkcolorcomboBox.Size = new System.Drawing.Size(126, 21);
            this.borderdarkcolorcomboBox.TabIndex = 8;
            this.borderdarkcolorcomboBox.Text = "htmlColorSelectorComboBox1";
            this.borderdarkcolorcomboBox.TextHoverColor = System.Drawing.Color.Blue;
            // 
            // frmTableCellProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 362);
            this.Controls.Add(this.chkNoWrap);
            this.Controls.Add(this.btnCloseNoChange);
            this.Controls.Add(this.btnApplyClose);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmTableCellProp";
            this.Text = "Cell Property";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTableCellProp_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox VerticalAlignmentcomboBox;
        private System.Windows.Forms.ComboBox HorizontalAlignmentcomboBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnApplyClose;
        private System.Windows.Forms.Button btnCloseNoChange;
        private System.Windows.Forms.CheckBox chkNoWrap;
        private HtmlColorSelectorComboBox backgoundcolorcomboBox;
        private HtmlColorSelectorComboBox bordercolorcomboBox;
        private HtmlColorSelectorComboBox borderdarkcolorcomboBox;
        private HtmlColorSelectorComboBox borderlightcolorcomboBox;
    }
}