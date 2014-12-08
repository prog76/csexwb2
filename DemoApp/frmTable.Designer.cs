namespace DemoApp
{
    partial class frmTable
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
            this.UpDownNumberOfCols = new System.Windows.Forms.NumericUpDown();
            this.UpDownNumberOfRows = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioBtnWidthInPercentage = new System.Windows.Forms.RadioButton();
            this.radioBtnWidthInPixels = new System.Windows.Forms.RadioButton();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.chkSpecifyWidth = new System.Windows.Forms.CheckBox();
            this.UpDownCellSpacing = new System.Windows.Forms.NumericUpDown();
            this.UpDownCellPadding = new System.Windows.Forms.NumericUpDown();
            this.UpDownBorderSize = new System.Windows.Forms.NumericUpDown();
            this.comboAlignment = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.comboBackColor = new DemoApp.HtmlColorSelectorComboBox();
            this.comboBorderColor = new DemoApp.HtmlColorSelectorComboBox();
            this.comboLightBorder = new DemoApp.HtmlColorSelectorComboBox();
            this.comboDarkBorder = new DemoApp.HtmlColorSelectorComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownNumberOfCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownNumberOfRows)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownCellSpacing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownCellPadding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownBorderSize)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UpDownNumberOfCols);
            this.groupBox1.Controls.Add(this.UpDownNumberOfRows);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Size:";
            // 
            // UpDownNumberOfCols
            // 
            this.UpDownNumberOfCols.Location = new System.Drawing.Point(230, 16);
            this.UpDownNumberOfCols.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownNumberOfCols.Name = "UpDownNumberOfCols";
            this.UpDownNumberOfCols.Size = new System.Drawing.Size(69, 20);
            this.UpDownNumberOfCols.TabIndex = 3;
            this.UpDownNumberOfCols.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // UpDownNumberOfRows
            // 
            this.UpDownNumberOfRows.Location = new System.Drawing.Point(64, 16);
            this.UpDownNumberOfRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownNumberOfRows.Name = "UpDownNumberOfRows";
            this.UpDownNumberOfRows.Size = new System.Drawing.Size(60, 20);
            this.UpDownNumberOfRows.TabIndex = 2;
            this.UpDownNumberOfRows.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Columns:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Rows:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.UpDownCellSpacing);
            this.groupBox2.Controls.Add(this.UpDownCellPadding);
            this.groupBox2.Controls.Add(this.UpDownBorderSize);
            this.groupBox2.Controls.Add(this.comboAlignment);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 142);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Layout:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioBtnWidthInPercentage);
            this.panel1.Controls.Add(this.radioBtnWidthInPixels);
            this.panel1.Controls.Add(this.txtWidth);
            this.panel1.Controls.Add(this.chkSpecifyWidth);
            this.panel1.Location = new System.Drawing.Point(173, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(126, 100);
            this.panel1.TabIndex = 8;
            // 
            // radioBtnWidthInPercentage
            // 
            this.radioBtnWidthInPercentage.AutoSize = true;
            this.radioBtnWidthInPercentage.Checked = true;
            this.radioBtnWidthInPercentage.Location = new System.Drawing.Point(45, 63);
            this.radioBtnWidthInPercentage.Name = "radioBtnWidthInPercentage";
            this.radioBtnWidthInPercentage.Size = new System.Drawing.Size(74, 17);
            this.radioBtnWidthInPercentage.TabIndex = 3;
            this.radioBtnWidthInPercentage.TabStop = true;
            this.radioBtnWidthInPercentage.Text = "In Percent";
            this.radioBtnWidthInPercentage.UseVisualStyleBackColor = true;
            // 
            // radioBtnWidthInPixels
            // 
            this.radioBtnWidthInPixels.AutoSize = true;
            this.radioBtnWidthInPixels.Location = new System.Drawing.Point(45, 40);
            this.radioBtnWidthInPixels.Name = "radioBtnWidthInPixels";
            this.radioBtnWidthInPixels.Size = new System.Drawing.Size(64, 17);
            this.radioBtnWidthInPixels.TabIndex = 2;
            this.radioBtnWidthInPixels.Text = "In Pixels";
            this.radioBtnWidthInPixels.UseVisualStyleBackColor = true;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(8, 40);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(31, 20);
            this.txtWidth.TabIndex = 1;
            this.txtWidth.Text = "50";
            // 
            // chkSpecifyWidth
            // 
            this.chkSpecifyWidth.AutoSize = true;
            this.chkSpecifyWidth.Checked = true;
            this.chkSpecifyWidth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSpecifyWidth.Location = new System.Drawing.Point(8, 12);
            this.chkSpecifyWidth.Name = "chkSpecifyWidth";
            this.chkSpecifyWidth.Size = new System.Drawing.Size(92, 17);
            this.chkSpecifyWidth.TabIndex = 0;
            this.chkSpecifyWidth.Text = "Specify Width";
            this.chkSpecifyWidth.UseVisualStyleBackColor = true;
            // 
            // UpDownCellSpacing
            // 
            this.UpDownCellSpacing.Location = new System.Drawing.Point(88, 106);
            this.UpDownCellSpacing.Name = "UpDownCellSpacing";
            this.UpDownCellSpacing.Size = new System.Drawing.Size(78, 20);
            this.UpDownCellSpacing.TabIndex = 7;
            this.UpDownCellSpacing.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // UpDownCellPadding
            // 
            this.UpDownCellPadding.Location = new System.Drawing.Point(88, 80);
            this.UpDownCellPadding.Name = "UpDownCellPadding";
            this.UpDownCellPadding.Size = new System.Drawing.Size(79, 20);
            this.UpDownCellPadding.TabIndex = 6;
            this.UpDownCellPadding.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // UpDownBorderSize
            // 
            this.UpDownBorderSize.Location = new System.Drawing.Point(88, 53);
            this.UpDownBorderSize.Name = "UpDownBorderSize";
            this.UpDownBorderSize.Size = new System.Drawing.Size(79, 20);
            this.UpDownBorderSize.TabIndex = 5;
            this.UpDownBorderSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboAlignment
            // 
            this.comboAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAlignment.FormattingEnabled = true;
            this.comboAlignment.Items.AddRange(new object[] {
            "Default",
            "left",
            "center",
            "right",
            "justify"});
            this.comboAlignment.Location = new System.Drawing.Point(88, 26);
            this.comboAlignment.Name = "comboAlignment";
            this.comboAlignment.Size = new System.Drawing.Size(79, 21);
            this.comboAlignment.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Cell Spacing:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Cell Padding:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Border Size:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Alignment:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboDarkBorder);
            this.groupBox3.Controls.Add(this.comboLightBorder);
            this.groupBox3.Controls.Add(this.comboBorderColor);
            this.groupBox3.Controls.Add(this.comboBackColor);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(12, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(313, 140);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Colors:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Background:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Dark Border:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Light Border:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Border:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(113, 374);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 29);
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(230, 374);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 29);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // comboBackColor
            // 
            this.comboBackColor.DefaultColor = System.Drawing.Color.Empty;
            this.comboBackColor.DefaultColorText = "Default";
            this.comboBackColor.GradientEndColor = System.Drawing.Color.White;
            this.comboBackColor.GradientStartColor = System.Drawing.Color.White;
            this.comboBackColor.Location = new System.Drawing.Point(121, 25);
            this.comboBackColor.Name = "comboBackColor";
            this.comboBackColor.SelectedColor = System.Drawing.Color.Empty;
            this.comboBackColor.Size = new System.Drawing.Size(178, 21);
            this.comboBackColor.TabIndex = 8;
            this.comboBackColor.Text = "htmlColorSelectorComboBox1";
            this.comboBackColor.TextHoverColor = System.Drawing.Color.Blue;
            // 
            // comboBorderColor
            // 
            this.comboBorderColor.DefaultColor = System.Drawing.Color.Empty;
            this.comboBorderColor.DefaultColorText = "Default";
            this.comboBorderColor.GradientEndColor = System.Drawing.Color.White;
            this.comboBorderColor.GradientStartColor = System.Drawing.Color.White;
            this.comboBorderColor.Location = new System.Drawing.Point(121, 55);
            this.comboBorderColor.Name = "comboBorderColor";
            this.comboBorderColor.SelectedColor = System.Drawing.Color.Empty;
            this.comboBorderColor.Size = new System.Drawing.Size(178, 21);
            this.comboBorderColor.TabIndex = 9;
            this.comboBorderColor.Text = "htmlColorSelectorComboBox1";
            this.comboBorderColor.TextHoverColor = System.Drawing.Color.Blue;
            // 
            // comboLightBorder
            // 
            this.comboLightBorder.DefaultColor = System.Drawing.Color.Empty;
            this.comboLightBorder.DefaultColorText = "Default";
            this.comboLightBorder.GradientEndColor = System.Drawing.Color.White;
            this.comboLightBorder.GradientStartColor = System.Drawing.Color.White;
            this.comboLightBorder.Location = new System.Drawing.Point(121, 82);
            this.comboLightBorder.Name = "comboLightBorder";
            this.comboLightBorder.SelectedColor = System.Drawing.Color.Empty;
            this.comboLightBorder.Size = new System.Drawing.Size(178, 21);
            this.comboLightBorder.TabIndex = 10;
            this.comboLightBorder.Text = "htmlColorSelectorComboBox1";
            this.comboLightBorder.TextHoverColor = System.Drawing.Color.Blue;
            // 
            // comboDarkBorder
            // 
            this.comboDarkBorder.DefaultColor = System.Drawing.Color.Empty;
            this.comboDarkBorder.DefaultColorText = "Default";
            this.comboDarkBorder.GradientEndColor = System.Drawing.Color.White;
            this.comboDarkBorder.GradientStartColor = System.Drawing.Color.White;
            this.comboDarkBorder.Location = new System.Drawing.Point(121, 110);
            this.comboDarkBorder.Name = "comboDarkBorder";
            this.comboDarkBorder.SelectedColor = System.Drawing.Color.Empty;
            this.comboDarkBorder.Size = new System.Drawing.Size(178, 21);
            this.comboDarkBorder.TabIndex = 11;
            this.comboDarkBorder.Text = "htmlColorSelectorComboBox1";
            this.comboDarkBorder.TextHoverColor = System.Drawing.Color.Blue;
            // 
            // frmTable
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(339, 411);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Table";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTable_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownNumberOfCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownNumberOfRows)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownCellSpacing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownCellPadding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownBorderSize)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown UpDownNumberOfCols;
        private System.Windows.Forms.NumericUpDown UpDownNumberOfRows;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboAlignment;
        private System.Windows.Forms.NumericUpDown UpDownCellSpacing;
        private System.Windows.Forms.NumericUpDown UpDownCellPadding;
        private System.Windows.Forms.NumericUpDown UpDownBorderSize;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkSpecifyWidth;
        private System.Windows.Forms.RadioButton radioBtnWidthInPercentage;
        private System.Windows.Forms.RadioButton radioBtnWidthInPixels;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private HtmlColorSelectorComboBox comboDarkBorder;
        private HtmlColorSelectorComboBox comboLightBorder;
        private HtmlColorSelectorComboBox comboBorderColor;
        private HtmlColorSelectorComboBox comboBackColor;
    }
}