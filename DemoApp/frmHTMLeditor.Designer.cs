namespace DemoApp
{
    partial class frmHTMLeditor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHTMLeditor));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.editorfontCombo = new DemoApp.ToolStripCustomComboBox();
            this.tsComboFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnBold = new System.Windows.Forms.ToolStripButton();
            this.tsBtnItalic = new System.Windows.Forms.ToolStripButton();
            this.tsBtnUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnLeftAlign = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCenterAlign = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRightAlign = new System.Windows.Forms.ToolStripButton();
            this.tsBtnFullAlign = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnNumberList = new System.Windows.Forms.ToolStripButton();
            this.tsBtnBulletList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel10 = new System.Windows.Forms.ToolStripLabel();
            this.selectionbackcolor = new System.Windows.Forms.ToolStripDropDownButton();
            this.selectionbackcolorSelector = new DemoApp.ToolStripHtmlColorSelector();
            this.selectionforecolor = new System.Windows.Forms.ToolStripDropDownButton();
            this.selectionforecolorSelector1 = new DemoApp.ToolStripHtmlColorSelector();
            this.tsFile = new System.Windows.Forms.ToolStrip();
            this.tsBtnNew = new System.Windows.Forms.ToolStripButton();
            this.tsBtnOpenEdit = new System.Windows.Forms.ToolStripDropDownButton();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnCut = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCopy = new System.Windows.Forms.ToolStripButton();
            this.tsBtnPaste = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSelectAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnOutdent = new System.Windows.Forms.ToolStripButton();
            this.tsBtnIndent = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnTable = new System.Windows.Forms.ToolStripButton();
            this.tsBtnPicture = new System.Windows.Forms.ToolStripButton();
            this.tsBtnLink = new System.Windows.Forms.ToolStripButton();
            this.tsBtnBR = new System.Windows.Forms.ToolStripButton();
            this.tsBtnHorizontalLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnUndo = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRedo = new System.Windows.Forms.ToolStripButton();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.tsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ctxMnuHTMLEditor = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTablePropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCellPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertColToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteColToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageEdit = new System.Windows.Forms.TabPage();
            this.cEXWB1 = new csExWB.cEXWB();
            this.tabPageSource = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new DemoApp.CustomSplitter();
            this.treeHTMLTags = new System.Windows.Forms.TreeView();
            this.htmlRichTextBox1 = new DemoApp.HtmlRichTextBox();
            this.ctxMnuRichTextBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutRtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyRtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteRtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.insertSpecialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftarrowtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightarrowtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.amptoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPagePreview = new System.Windows.Forms.TabPage();
            this.cEXWB2 = new csExWB.cEXWB();
            this.tsColors = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.docbackcolor = new System.Windows.Forms.ToolStripDropDownButton();
            this.docbackcolorselector = new DemoApp.ToolStripHtmlColorSelector();
            this.docforecolor = new System.Windows.Forms.ToolStripDropDownButton();
            this.docforecolorselector = new DemoApp.ToolStripHtmlColorSelector();
            this.doclinkcolor = new System.Windows.Forms.ToolStripDropDownButton();
            this.doclinkcolorselector = new DemoApp.ToolStripHtmlColorSelector();
            this.docalinkcolor = new System.Windows.Forms.ToolStripDropDownButton();
            this.docalinkcolorselector = new DemoApp.ToolStripHtmlColorSelector();
            this.docvlinkcolor = new System.Windows.Forms.ToolStripDropDownButton();
            this.docvlinkcolorselector = new DemoApp.ToolStripHtmlColorSelector();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnRemoveFormat = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.tsFile.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.ctxMnuHTMLEditor.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageEdit.SuspendLayout();
            this.tabPageSource.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ctxMnuRichTextBox.SuspendLayout();
            this.tabPagePreview.SuspendLayout();
            this.tsColors.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editorfontCombo,
            this.tsComboFontSize,
            this.toolStripSeparator1,
            this.tsBtnBold,
            this.tsBtnItalic,
            this.tsBtnUnderline,
            this.toolStripSeparator2,
            this.tsBtnLeftAlign,
            this.tsBtnCenterAlign,
            this.tsBtnRightAlign,
            this.tsBtnFullAlign,
            this.toolStripSeparator3,
            this.tsBtnNumberList,
            this.tsBtnBulletList,
            this.toolStripSeparator4,
            this.toolStripLabel10,
            this.selectionbackcolor,
            this.selectionforecolor});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(920, 25);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "toolStrip1";
            this.tsMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsMain_ItemClicked);
            // 
            // editorfontCombo
            // 
            this.editorfontCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.editorfontCombo.Images = null;
            this.editorfontCombo.InternalCall = false;
            this.editorfontCombo.Name = "editorfontCombo";
            this.editorfontCombo.SelectedColorItem = System.Drawing.Color.Empty;
            this.editorfontCombo.SelectedFontItem = null;
            this.editorfontCombo.SelectedFontNameItem = "";
            this.editorfontCombo.Size = new System.Drawing.Size(200, 25);
            this.editorfontCombo.SelectedIndexChanged += new System.EventHandler(this.editorfontCombo_SelectedIndexChanged);
            // 
            // tsComboFontSize
            // 
            this.tsComboFontSize.Name = "tsComboFontSize";
            this.tsComboFontSize.Size = new System.Drawing.Size(75, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnBold
            // 
            this.tsBtnBold.CheckOnClick = true;
            this.tsBtnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnBold.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnBold.Image")));
            this.tsBtnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnBold.Name = "tsBtnBold";
            this.tsBtnBold.Size = new System.Drawing.Size(23, 22);
            this.tsBtnBold.Text = "toolStripButton1";
            this.tsBtnBold.ToolTipText = "Bold";
            // 
            // tsBtnItalic
            // 
            this.tsBtnItalic.CheckOnClick = true;
            this.tsBtnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnItalic.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnItalic.Image")));
            this.tsBtnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnItalic.Name = "tsBtnItalic";
            this.tsBtnItalic.Size = new System.Drawing.Size(23, 22);
            this.tsBtnItalic.Text = "toolStripButton2";
            this.tsBtnItalic.ToolTipText = "Italic";
            // 
            // tsBtnUnderline
            // 
            this.tsBtnUnderline.CheckOnClick = true;
            this.tsBtnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnUnderline.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnUnderline.Image")));
            this.tsBtnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnUnderline.Name = "tsBtnUnderline";
            this.tsBtnUnderline.Size = new System.Drawing.Size(23, 22);
            this.tsBtnUnderline.Text = "toolStripButton3";
            this.tsBtnUnderline.ToolTipText = "Underline";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnLeftAlign
            // 
            this.tsBtnLeftAlign.CheckOnClick = true;
            this.tsBtnLeftAlign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnLeftAlign.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnLeftAlign.Image")));
            this.tsBtnLeftAlign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnLeftAlign.Name = "tsBtnLeftAlign";
            this.tsBtnLeftAlign.Size = new System.Drawing.Size(23, 22);
            this.tsBtnLeftAlign.Text = "toolStripButton4";
            this.tsBtnLeftAlign.ToolTipText = "Left align";
            // 
            // tsBtnCenterAlign
            // 
            this.tsBtnCenterAlign.CheckOnClick = true;
            this.tsBtnCenterAlign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnCenterAlign.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCenterAlign.Image")));
            this.tsBtnCenterAlign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCenterAlign.Name = "tsBtnCenterAlign";
            this.tsBtnCenterAlign.Size = new System.Drawing.Size(23, 22);
            this.tsBtnCenterAlign.Text = "toolStripButton5";
            this.tsBtnCenterAlign.ToolTipText = "Center align";
            // 
            // tsBtnRightAlign
            // 
            this.tsBtnRightAlign.CheckOnClick = true;
            this.tsBtnRightAlign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnRightAlign.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRightAlign.Image")));
            this.tsBtnRightAlign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRightAlign.Name = "tsBtnRightAlign";
            this.tsBtnRightAlign.Size = new System.Drawing.Size(23, 22);
            this.tsBtnRightAlign.Text = "toolStripButton6";
            this.tsBtnRightAlign.ToolTipText = "Right align";
            // 
            // tsBtnFullAlign
            // 
            this.tsBtnFullAlign.CheckOnClick = true;
            this.tsBtnFullAlign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnFullAlign.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnFullAlign.Image")));
            this.tsBtnFullAlign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnFullAlign.Name = "tsBtnFullAlign";
            this.tsBtnFullAlign.Size = new System.Drawing.Size(23, 22);
            this.tsBtnFullAlign.Text = "Full Align";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnNumberList
            // 
            this.tsBtnNumberList.CheckOnClick = true;
            this.tsBtnNumberList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnNumberList.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNumberList.Image")));
            this.tsBtnNumberList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNumberList.Name = "tsBtnNumberList";
            this.tsBtnNumberList.Size = new System.Drawing.Size(23, 22);
            this.tsBtnNumberList.Text = "toolStripButton7";
            this.tsBtnNumberList.ToolTipText = "Number list";
            // 
            // tsBtnBulletList
            // 
            this.tsBtnBulletList.CheckOnClick = true;
            this.tsBtnBulletList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnBulletList.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnBulletList.Image")));
            this.tsBtnBulletList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnBulletList.Name = "tsBtnBulletList";
            this.tsBtnBulletList.Size = new System.Drawing.Size(23, 22);
            this.tsBtnBulletList.Text = "toolStripButton8";
            this.tsBtnBulletList.ToolTipText = "Bullet list";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel10
            // 
            this.toolStripLabel10.Name = "toolStripLabel10";
            this.toolStripLabel10.Size = new System.Drawing.Size(54, 22);
            this.toolStripLabel10.Text = "Selection:";
            // 
            // selectionbackcolor
            // 
            this.selectionbackcolor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectionbackcolor.DropDown = this.selectionbackcolorSelector;
            this.selectionbackcolor.Image = ((System.Drawing.Image)(resources.GetObject("selectionbackcolor.Image")));
            this.selectionbackcolor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectionbackcolor.Name = "selectionbackcolor";
            this.selectionbackcolor.ShowDropDownArrow = false;
            this.selectionbackcolor.Size = new System.Drawing.Size(61, 22);
            this.selectionbackcolor.Text = "Back Color";
            // 
            // selectionbackcolorSelector
            // 
            this.selectionbackcolorSelector.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.selectionbackcolorSelector.Name = "selectionbackcolorSelector";
            this.selectionbackcolorSelector.OwnerItem = this.selectionbackcolor;
            this.selectionbackcolorSelector.Size = new System.Drawing.Size(344, 162);
            // 
            // selectionforecolor
            // 
            this.selectionforecolor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.selectionforecolor.DropDown = this.selectionforecolorSelector1;
            this.selectionforecolor.Image = ((System.Drawing.Image)(resources.GetObject("selectionforecolor.Image")));
            this.selectionforecolor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.selectionforecolor.Name = "selectionforecolor";
            this.selectionforecolor.ShowDropDownArrow = false;
            this.selectionforecolor.Size = new System.Drawing.Size(61, 22);
            this.selectionforecolor.Text = "Fore Color";
            // 
            // selectionforecolorSelector1
            // 
            this.selectionforecolorSelector1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.selectionforecolorSelector1.Name = "selectionforecolorSelector1";
            this.selectionforecolorSelector1.OwnerItem = this.selectionforecolor;
            this.selectionforecolorSelector1.Size = new System.Drawing.Size(344, 162);
            // 
            // tsFile
            // 
            this.tsFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnNew,
            this.tsBtnOpenEdit,
            this.tsBtnSave,
            this.toolStripSeparator5,
            this.tsBtnPrint,
            this.toolStripSeparator6,
            this.tsBtnCut,
            this.tsBtnCopy,
            this.tsBtnPaste,
            this.tsBtnSelectAll,
            this.toolStripSeparator7,
            this.tsBtnOutdent,
            this.tsBtnIndent,
            this.toolStripSeparator8,
            this.tsBtnTable,
            this.tsBtnPicture,
            this.tsBtnLink,
            this.tsBtnBR,
            this.tsBtnHorizontalLine,
            this.toolStripSeparator9,
            this.tsBtnUndo,
            this.tsBtnRedo,
            this.toolStripSeparator14,
            this.tsBtnRemoveFormat});
            this.tsFile.Location = new System.Drawing.Point(0, 25);
            this.tsFile.Name = "tsFile";
            this.tsFile.Size = new System.Drawing.Size(920, 25);
            this.tsFile.TabIndex = 1;
            this.tsFile.Text = "toolStrip1";
            this.tsFile.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsFile_ItemClicked);
            // 
            // tsBtnNew
            // 
            this.tsBtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnNew.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNew.Image")));
            this.tsBtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNew.Name = "tsBtnNew";
            this.tsBtnNew.Size = new System.Drawing.Size(23, 22);
            this.tsBtnNew.Text = "toolStripButton11";
            this.tsBtnNew.ToolTipText = "New";
            // 
            // tsBtnOpenEdit
            // 
            this.tsBtnOpenEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnOpenEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.currentBrowserToolStripMenuItem,
            this.clipboardToolStripMenuItem});
            this.tsBtnOpenEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnOpenEdit.Image")));
            this.tsBtnOpenEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOpenEdit.Name = "tsBtnOpenEdit";
            this.tsBtnOpenEdit.Size = new System.Drawing.Size(29, 22);
            this.tsBtnOpenEdit.Text = "toolStripDropDownButton1";
            this.tsBtnOpenEdit.ToolTipText = "Open";
            this.tsBtnOpenEdit.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsBtnOpenEdit_DropDownItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // currentBrowserToolStripMenuItem
            // 
            this.currentBrowserToolStripMenuItem.Name = "currentBrowserToolStripMenuItem";
            this.currentBrowserToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.currentBrowserToolStripMenuItem.Text = "Current Browser";
            // 
            // clipboardToolStripMenuItem
            // 
            this.clipboardToolStripMenuItem.Name = "clipboardToolStripMenuItem";
            this.clipboardToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.clipboardToolStripMenuItem.Text = "Clipboard";
            // 
            // tsBtnSave
            // 
            this.tsBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSave.Image")));
            this.tsBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSave.Name = "tsBtnSave";
            this.tsBtnSave.Size = new System.Drawing.Size(23, 22);
            this.tsBtnSave.Text = "toolStripButton13";
            this.tsBtnSave.ToolTipText = "Save";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnPrint
            // 
            this.tsBtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnPrint.Image")));
            this.tsBtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPrint.Name = "tsBtnPrint";
            this.tsBtnPrint.Size = new System.Drawing.Size(23, 22);
            this.tsBtnPrint.Text = "toolStripButton14";
            this.tsBtnPrint.ToolTipText = "Print";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnCut
            // 
            this.tsBtnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnCut.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCut.Image")));
            this.tsBtnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCut.Name = "tsBtnCut";
            this.tsBtnCut.Size = new System.Drawing.Size(23, 22);
            this.tsBtnCut.Text = "toolStripButton16";
            this.tsBtnCut.ToolTipText = "Cut";
            // 
            // tsBtnCopy
            // 
            this.tsBtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCopy.Image")));
            this.tsBtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCopy.Name = "tsBtnCopy";
            this.tsBtnCopy.Size = new System.Drawing.Size(23, 22);
            this.tsBtnCopy.Text = "toolStripButton17";
            this.tsBtnCopy.ToolTipText = "Copy";
            // 
            // tsBtnPaste
            // 
            this.tsBtnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnPaste.Image")));
            this.tsBtnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPaste.Name = "tsBtnPaste";
            this.tsBtnPaste.Size = new System.Drawing.Size(23, 22);
            this.tsBtnPaste.Text = "toolStripButton18";
            this.tsBtnPaste.ToolTipText = "Paste";
            // 
            // tsBtnSelectAll
            // 
            this.tsBtnSelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSelectAll.Image")));
            this.tsBtnSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSelectAll.Name = "tsBtnSelectAll";
            this.tsBtnSelectAll.Size = new System.Drawing.Size(23, 22);
            this.tsBtnSelectAll.Text = "toolStripButton1";
            this.tsBtnSelectAll.ToolTipText = "Select all";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnOutdent
            // 
            this.tsBtnOutdent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnOutdent.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnOutdent.Image")));
            this.tsBtnOutdent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnOutdent.Name = "tsBtnOutdent";
            this.tsBtnOutdent.Size = new System.Drawing.Size(23, 22);
            this.tsBtnOutdent.Text = "Outdent";
            // 
            // tsBtnIndent
            // 
            this.tsBtnIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnIndent.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnIndent.Image")));
            this.tsBtnIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnIndent.Name = "tsBtnIndent";
            this.tsBtnIndent.Size = new System.Drawing.Size(23, 22);
            this.tsBtnIndent.Text = "Indent";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnTable
            // 
            this.tsBtnTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnTable.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnTable.Image")));
            this.tsBtnTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnTable.Name = "tsBtnTable";
            this.tsBtnTable.Size = new System.Drawing.Size(23, 22);
            this.tsBtnTable.Text = "Add Table";
            this.tsBtnTable.ToolTipText = "Add Table";
            // 
            // tsBtnPicture
            // 
            this.tsBtnPicture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnPicture.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnPicture.Image")));
            this.tsBtnPicture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnPicture.Name = "tsBtnPicture";
            this.tsBtnPicture.Size = new System.Drawing.Size(23, 22);
            this.tsBtnPicture.Text = "Add Image";
            this.tsBtnPicture.ToolTipText = "Add Image";
            // 
            // tsBtnLink
            // 
            this.tsBtnLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnLink.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnLink.Image")));
            this.tsBtnLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnLink.Name = "tsBtnLink";
            this.tsBtnLink.Size = new System.Drawing.Size(23, 22);
            this.tsBtnLink.Text = "Add Link";
            this.tsBtnLink.ToolTipText = "Add Link";
            // 
            // tsBtnBR
            // 
            this.tsBtnBR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnBR.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnBR.Image")));
            this.tsBtnBR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnBR.Name = "tsBtnBR";
            this.tsBtnBR.Size = new System.Drawing.Size(23, 22);
            this.tsBtnBR.Text = "Insert BR";
            // 
            // tsBtnHorizontalLine
            // 
            this.tsBtnHorizontalLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnHorizontalLine.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnHorizontalLine.Image")));
            this.tsBtnHorizontalLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnHorizontalLine.Name = "tsBtnHorizontalLine";
            this.tsBtnHorizontalLine.Size = new System.Drawing.Size(23, 22);
            this.tsBtnHorizontalLine.Text = "Add Horizontal Line";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnUndo
            // 
            this.tsBtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnUndo.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnUndo.Image")));
            this.tsBtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnUndo.Name = "tsBtnUndo";
            this.tsBtnUndo.Size = new System.Drawing.Size(23, 22);
            this.tsBtnUndo.Text = "toolStripButton19";
            this.tsBtnUndo.ToolTipText = "Undo";
            // 
            // tsBtnRedo
            // 
            this.tsBtnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnRedo.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRedo.Image")));
            this.tsBtnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRedo.Name = "tsBtnRedo";
            this.tsBtnRedo.Size = new System.Drawing.Size(23, 22);
            this.tsBtnRedo.Text = "toolStripButton20";
            this.tsBtnRedo.ToolTipText = "Redo";
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStatus});
            this.statusStripMain.Location = new System.Drawing.Point(0, 416);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(920, 22);
            this.statusStripMain.TabIndex = 3;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // tsStatus
            // 
            this.tsStatus.Name = "tsStatus";
            this.tsStatus.Size = new System.Drawing.Size(905, 17);
            this.tsStatus.Spring = true;
            this.tsStatus.Text = "Ready...";
            this.tsStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ctxMnuHTMLEditor
            // 
            this.ctxMnuHTMLEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.viewSourceToolStripMenuItem,
            this.editLinkToolStripMenuItem,
            this.undoLinkToolStripMenuItem,
            this.deleteLinkToolStripMenuItem,
            this.editImageToolStripMenuItem,
            this.deleteImageToolStripMenuItem,
            this.editTablePropertiesToolStripMenuItem,
            this.editCellPropertiesToolStripMenuItem,
            this.insertRowToolStripMenuItem,
            this.insertColToolStripMenuItem,
            this.deleteRowToolStripMenuItem,
            this.deleteColToolStripMenuItem});
            this.ctxMnuHTMLEditor.Name = "ctxMnuHTMLEditor";
            this.ctxMnuHTMLEditor.Size = new System.Drawing.Size(185, 334);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.BrowserCtxMenuClickHandler);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.BrowserCtxMenuClickHandler);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.BrowserCtxMenuClickHandler);
            // 
            // viewSourceToolStripMenuItem
            // 
            this.viewSourceToolStripMenuItem.Name = "viewSourceToolStripMenuItem";
            this.viewSourceToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.viewSourceToolStripMenuItem.Text = "View Source";
            this.viewSourceToolStripMenuItem.Click += new System.EventHandler(this.BrowserCtxMenuClickHandler);
            // 
            // editLinkToolStripMenuItem
            // 
            this.editLinkToolStripMenuItem.Name = "editLinkToolStripMenuItem";
            this.editLinkToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.editLinkToolStripMenuItem.Text = "Edit Link";
            this.editLinkToolStripMenuItem.Click += new System.EventHandler(this.BrowserCtxMenuClickHandler);
            // 
            // undoLinkToolStripMenuItem
            // 
            this.undoLinkToolStripMenuItem.Name = "undoLinkToolStripMenuItem";
            this.undoLinkToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.undoLinkToolStripMenuItem.Text = "Undo Link";
            this.undoLinkToolStripMenuItem.Click += new System.EventHandler(this.BrowserCtxMenuClickHandler);
            // 
            // deleteLinkToolStripMenuItem
            // 
            this.deleteLinkToolStripMenuItem.Name = "deleteLinkToolStripMenuItem";
            this.deleteLinkToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.deleteLinkToolStripMenuItem.Text = "Delete Link";
            this.deleteLinkToolStripMenuItem.Click += new System.EventHandler(this.BrowserCtxMenuClickHandler);
            // 
            // editImageToolStripMenuItem
            // 
            this.editImageToolStripMenuItem.Name = "editImageToolStripMenuItem";
            this.editImageToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.editImageToolStripMenuItem.Text = "Edit Image";
            this.editImageToolStripMenuItem.Click += new System.EventHandler(this.BrowserCtxMenuClickHandler);
            // 
            // deleteImageToolStripMenuItem
            // 
            this.deleteImageToolStripMenuItem.Name = "deleteImageToolStripMenuItem";
            this.deleteImageToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.deleteImageToolStripMenuItem.Text = "Delete Image";
            this.deleteImageToolStripMenuItem.Click += new System.EventHandler(this.BrowserCtxMenuClickHandler);
            // 
            // editTablePropertiesToolStripMenuItem
            // 
            this.editTablePropertiesToolStripMenuItem.Name = "editTablePropertiesToolStripMenuItem";
            this.editTablePropertiesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.editTablePropertiesToolStripMenuItem.Text = "Edit Table Properties";
            this.editTablePropertiesToolStripMenuItem.Click += new System.EventHandler(this.BrowserCtxMenuClickHandler);
            // 
            // editCellPropertiesToolStripMenuItem
            // 
            this.editCellPropertiesToolStripMenuItem.Name = "editCellPropertiesToolStripMenuItem";
            this.editCellPropertiesToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.editCellPropertiesToolStripMenuItem.Text = "Edit Cell Properties";
            this.editCellPropertiesToolStripMenuItem.Click += new System.EventHandler(this.BrowserCtxMenuClickHandler);
            // 
            // insertRowToolStripMenuItem
            // 
            this.insertRowToolStripMenuItem.Name = "insertRowToolStripMenuItem";
            this.insertRowToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.insertRowToolStripMenuItem.Text = "Insert Row";
            this.insertRowToolStripMenuItem.Click += new System.EventHandler(this.BrowserCtxMenuClickHandler);
            // 
            // insertColToolStripMenuItem
            // 
            this.insertColToolStripMenuItem.Name = "insertColToolStripMenuItem";
            this.insertColToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.insertColToolStripMenuItem.Text = "Insert Col";
            this.insertColToolStripMenuItem.Click += new System.EventHandler(this.BrowserCtxMenuClickHandler);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.deleteRowToolStripMenuItem.Text = "Delete Row";
            this.deleteRowToolStripMenuItem.Click += new System.EventHandler(this.BrowserCtxMenuClickHandler);
            // 
            // deleteColToolStripMenuItem
            // 
            this.deleteColToolStripMenuItem.Name = "deleteColToolStripMenuItem";
            this.deleteColToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.deleteColToolStripMenuItem.Text = "Delete Col";
            this.deleteColToolStripMenuItem.Click += new System.EventHandler(this.BrowserCtxMenuClickHandler);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageEdit);
            this.tabControl1.Controls.Add(this.tabPageSource);
            this.tabControl1.Controls.Add(this.tabPagePreview);
            this.tabControl1.Location = new System.Drawing.Point(0, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(920, 335);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageEdit
            // 
            this.tabPageEdit.Controls.Add(this.cEXWB1);
            this.tabPageEdit.Location = new System.Drawing.Point(4, 4);
            this.tabPageEdit.Name = "tabPageEdit";
            this.tabPageEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEdit.Size = new System.Drawing.Size(912, 309);
            this.tabPageEdit.TabIndex = 0;
            this.tabPageEdit.Text = "Edit";
            this.tabPageEdit.UseVisualStyleBackColor = true;
            // 
            // cEXWB1
            // 
            this.cEXWB1.Border3DEnabled = false;
            this.cEXWB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cEXWB1.DocumentSource = "<HTML><HEAD></HEAD>\r\n<BODY></BODY></HTML>";
            this.cEXWB1.DocumentTitle = "";
            this.cEXWB1.DownloadActiveX = true;
            this.cEXWB1.DownloadFrames = true;
            this.cEXWB1.DownloadImages = true;
            this.cEXWB1.DownloadJava = true;
            this.cEXWB1.DownloadScripts = true;
            this.cEXWB1.DownloadSounds = true;
            this.cEXWB1.DownloadVideo = true;
            this.cEXWB1.FileDownloadDirectory = "C:\\Documents and Settings\\Mike\\My Documents\\";
            this.cEXWB1.Location = new System.Drawing.Point(3, 3);
            this.cEXWB1.LocationUrl = "about:blank";
            this.cEXWB1.Name = "cEXWB1";
            this.cEXWB1.ObjectForScripting = null;
            this.cEXWB1.OffLine = false;
            this.cEXWB1.RegisterAsBrowser = false;
            this.cEXWB1.RegisterAsDropTarget = false;
            this.cEXWB1.RegisterForInternalDragDrop = true;
            this.cEXWB1.ScrollBarsEnabled = true;
            this.cEXWB1.SendSourceOnDocumentCompleteWBEx = false;
            this.cEXWB1.Silent = false;
            this.cEXWB1.Size = new System.Drawing.Size(906, 303);
            this.cEXWB1.TabIndex = 4;
            this.cEXWB1.Text = "cEXWB1";
            this.cEXWB1.TextSize = IfacesEnumsStructsClasses.TextSizeWB.Medium;
            this.cEXWB1.UseInternalDownloadManager = true;
            this.cEXWB1.WBDOCDOWNLOADCTLFLAG = 112;
            this.cEXWB1.WBDOCHOSTUIDBLCLK = IfacesEnumsStructsClasses.DOCHOSTUIDBLCLK.DEFAULT;
            this.cEXWB1.WBDOCHOSTUIFLAG = 262276;
            this.cEXWB1.DocumentComplete += new csExWB.DocumentCompleteEventHandler(this.cEXWB1_DocumentComplete);
            this.cEXWB1.WBKeyDown += new csExWB.WBKeyDownEventHandler(this.cEXWB1_WBKeyDown);
            this.cEXWB1.StatusTextChange += new csExWB.StatusTextChangeEventHandler(this.cEXWB1_StatusTextChange);
            this.cEXWB1.BeforeNavigate2 += new csExWB.BeforeNavigate2EventHandler(this.cEXWB1_BeforeNavigate2);
            // 
            // tabPageSource
            // 
            this.tabPageSource.Controls.Add(this.splitContainer1);
            this.tabPageSource.Location = new System.Drawing.Point(4, 4);
            this.tabPageSource.Name = "tabPageSource";
            this.tabPageSource.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSource.Size = new System.Drawing.Size(912, 309);
            this.tabPageSource.TabIndex = 1;
            this.tabPageSource.Text = "Source";
            this.tabPageSource.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.ArrowColor = System.Drawing.Color.Blue;
            this.splitContainer1.ArrowColorHot = System.Drawing.Color.Red;
            this.splitContainer1.ArrowHeight = 20;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.DotsColor = System.Drawing.SystemColors.ControlDarkDark;
            this.splitContainer1.GradientBegingColor = System.Drawing.Color.Orange;
            this.splitContainer1.GradientEndColor = System.Drawing.Color.Yellow;
            this.splitContainer1.LineColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeHTMLTags);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.htmlRichTextBox1);
            this.splitContainer1.PixelsBetweenDots = new System.Drawing.Size(2, 2);
            this.splitContainer1.Size = new System.Drawing.Size(906, 303);
            this.splitContainer1.SplitterDistance = 145;
            this.splitContainer1.SplitterHandleStyle = DemoApp.CustomSplitter.SplitterVisualStyle.Gradient;
            this.splitContainer1.SplitterWidth = 7;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TooltipText = "Double click to change orientation.\r\nClick on Arrows to collapse or expand splitt" +
                "er panes.\r\nRight click for more options.";
            // 
            // treeHTMLTags
            // 
            this.treeHTMLTags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeHTMLTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeHTMLTags.Location = new System.Drawing.Point(0, 0);
            this.treeHTMLTags.Name = "treeHTMLTags";
            this.treeHTMLTags.ShowNodeToolTips = true;
            this.treeHTMLTags.ShowPlusMinus = false;
            this.treeHTMLTags.ShowRootLines = false;
            this.treeHTMLTags.Size = new System.Drawing.Size(145, 303);
            this.treeHTMLTags.TabIndex = 0;
            this.treeHTMLTags.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.treeHTMLTags_NodeMouseHover);
            this.treeHTMLTags.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeHTMLTags_NodeMouseClick);
            // 
            // htmlRichTextBox1
            // 
            this.htmlRichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.htmlRichTextBox1.ContextMenuStrip = this.ctxMnuRichTextBox;
            this.htmlRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlRichTextBox1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.htmlRichTextBox1.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.htmlRichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.htmlRichTextBox1.Name = "htmlRichTextBox1";
            this.htmlRichTextBox1.Size = new System.Drawing.Size(754, 303);
            this.htmlRichTextBox1.SuppressHightlighting = false;
            this.htmlRichTextBox1.TabIndex = 0;
            this.htmlRichTextBox1.Text = "";
            // 
            // ctxMnuRichTextBox
            // 
            this.ctxMnuRichTextBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutRtToolStripMenuItem,
            this.copyRtToolStripMenuItem,
            this.pasteRtToolStripMenuItem,
            this.toolStripSeparator10,
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator12,
            this.selectAllToolStripMenuItem,
            this.toolStripSeparator11,
            this.saveToolStripMenuItem,
            this.toolStripSeparator13,
            this.insertSpecialToolStripMenuItem});
            this.ctxMnuRichTextBox.Name = "ctxMnuRichTextBox";
            this.ctxMnuRichTextBox.Size = new System.Drawing.Size(151, 204);
            this.ctxMnuRichTextBox.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMnuRichTextBox_Opening);
            // 
            // cutRtToolStripMenuItem
            // 
            this.cutRtToolStripMenuItem.Name = "cutRtToolStripMenuItem";
            this.cutRtToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.cutRtToolStripMenuItem.Text = "Cut";
            this.cutRtToolStripMenuItem.Click += new System.EventHandler(this.ctxMnuRichTextBoxMenuItem1_Click);
            // 
            // copyRtToolStripMenuItem
            // 
            this.copyRtToolStripMenuItem.Name = "copyRtToolStripMenuItem";
            this.copyRtToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.copyRtToolStripMenuItem.Text = "Copy";
            this.copyRtToolStripMenuItem.Click += new System.EventHandler(this.ctxMnuRichTextBoxMenuItem1_Click);
            // 
            // pasteRtToolStripMenuItem
            // 
            this.pasteRtToolStripMenuItem.Name = "pasteRtToolStripMenuItem";
            this.pasteRtToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.pasteRtToolStripMenuItem.Text = "Paste";
            this.pasteRtToolStripMenuItem.Click += new System.EventHandler(this.ctxMnuRichTextBoxMenuItem1_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(147, 6);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.ctxMnuRichTextBoxMenuItem1_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.ctxMnuRichTextBoxMenuItem1_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(147, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.ctxMnuRichTextBoxMenuItem1_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(147, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.ctxMnuRichTextBoxMenuItem1_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(147, 6);
            // 
            // insertSpecialToolStripMenuItem
            // 
            this.insertSpecialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leftarrowtoolStripMenuItem,
            this.rightarrowtoolStripMenuItem,
            this.spaceToolStripMenuItem,
            this.amptoolStripMenuItem});
            this.insertSpecialToolStripMenuItem.Name = "insertSpecialToolStripMenuItem";
            this.insertSpecialToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.insertSpecialToolStripMenuItem.Text = "Insert Special";
            // 
            // leftarrowtoolStripMenuItem
            // 
            this.leftarrowtoolStripMenuItem.Name = "leftarrowtoolStripMenuItem";
            this.leftarrowtoolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.leftarrowtoolStripMenuItem.Text = "<";
            this.leftarrowtoolStripMenuItem.Click += new System.EventHandler(this.ctxMnuRichTextBoxMenuItem1_Click);
            // 
            // rightarrowtoolStripMenuItem
            // 
            this.rightarrowtoolStripMenuItem.Name = "rightarrowtoolStripMenuItem";
            this.rightarrowtoolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.rightarrowtoolStripMenuItem.Text = ">";
            this.rightarrowtoolStripMenuItem.Click += new System.EventHandler(this.ctxMnuRichTextBoxMenuItem1_Click);
            // 
            // spaceToolStripMenuItem
            // 
            this.spaceToolStripMenuItem.Name = "spaceToolStripMenuItem";
            this.spaceToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.spaceToolStripMenuItem.Text = "Space";
            this.spaceToolStripMenuItem.Click += new System.EventHandler(this.ctxMnuRichTextBoxMenuItem1_Click);
            // 
            // amptoolStripMenuItem
            // 
            this.amptoolStripMenuItem.Name = "amptoolStripMenuItem";
            this.amptoolStripMenuItem.ShowShortcutKeys = false;
            this.amptoolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.amptoolStripMenuItem.Text = "Ampersand";
            this.amptoolStripMenuItem.Click += new System.EventHandler(this.ctxMnuRichTextBoxMenuItem1_Click);
            // 
            // tabPagePreview
            // 
            this.tabPagePreview.Controls.Add(this.cEXWB2);
            this.tabPagePreview.Location = new System.Drawing.Point(4, 4);
            this.tabPagePreview.Name = "tabPagePreview";
            this.tabPagePreview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePreview.Size = new System.Drawing.Size(912, 309);
            this.tabPagePreview.TabIndex = 2;
            this.tabPagePreview.Text = "Preview";
            this.tabPagePreview.UseVisualStyleBackColor = true;
            // 
            // cEXWB2
            // 
            this.cEXWB2.Border3DEnabled = false;
            this.cEXWB2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cEXWB2.DocumentSource = "<HTML><HEAD></HEAD>\r\n<BODY></BODY></HTML>";
            this.cEXWB2.DocumentTitle = "";
            this.cEXWB2.DownloadActiveX = true;
            this.cEXWB2.DownloadFrames = true;
            this.cEXWB2.DownloadImages = true;
            this.cEXWB2.DownloadJava = true;
            this.cEXWB2.DownloadScripts = true;
            this.cEXWB2.DownloadSounds = true;
            this.cEXWB2.DownloadVideo = true;
            this.cEXWB2.FileDownloadDirectory = "C:\\Documents and Settings\\Mike\\My Documents\\";
            this.cEXWB2.Location = new System.Drawing.Point(3, 3);
            this.cEXWB2.LocationUrl = "about:blank";
            this.cEXWB2.Name = "cEXWB2";
            this.cEXWB2.ObjectForScripting = null;
            this.cEXWB2.OffLine = false;
            this.cEXWB2.RegisterAsBrowser = false;
            this.cEXWB2.RegisterAsDropTarget = false;
            this.cEXWB2.RegisterForInternalDragDrop = true;
            this.cEXWB2.ScrollBarsEnabled = true;
            this.cEXWB2.SendSourceOnDocumentCompleteWBEx = false;
            this.cEXWB2.Silent = false;
            this.cEXWB2.Size = new System.Drawing.Size(906, 303);
            this.cEXWB2.TabIndex = 0;
            this.cEXWB2.Text = "cEXWB2";
            this.cEXWB2.TextSize = IfacesEnumsStructsClasses.TextSizeWB.Medium;
            this.cEXWB2.UseInternalDownloadManager = true;
            this.cEXWB2.WBDOCDOWNLOADCTLFLAG = 112;
            this.cEXWB2.WBDOCHOSTUIDBLCLK = IfacesEnumsStructsClasses.DOCHOSTUIDBLCLK.DEFAULT;
            this.cEXWB2.WBDOCHOSTUIFLAG = 262276;
            this.cEXWB2.StatusTextChange += new csExWB.StatusTextChangeEventHandler(this.cEXWB1_StatusTextChange);
            // 
            // tsColors
            // 
            this.tsColors.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.docbackcolor,
            this.docforecolor,
            this.doclinkcolor,
            this.docalinkcolor,
            this.docvlinkcolor});
            this.tsColors.Location = new System.Drawing.Point(0, 50);
            this.tsColors.Name = "tsColors";
            this.tsColors.Size = new System.Drawing.Size(920, 25);
            this.tsColors.TabIndex = 2;
            this.tsColors.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel1.Text = "Document:";
            // 
            // docbackcolor
            // 
            this.docbackcolor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.docbackcolor.DropDown = this.docbackcolorselector;
            this.docbackcolor.Image = ((System.Drawing.Image)(resources.GetObject("docbackcolor.Image")));
            this.docbackcolor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.docbackcolor.Name = "docbackcolor";
            this.docbackcolor.ShowDropDownArrow = false;
            this.docbackcolor.Size = new System.Drawing.Size(61, 22);
            this.docbackcolor.Text = "Back Color";
            // 
            // docbackcolorselector
            // 
            this.docbackcolorselector.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.docbackcolorselector.Name = "docbackcolorselector";
            this.docbackcolorselector.OwnerItem = this.docbackcolor;
            this.docbackcolorselector.Size = new System.Drawing.Size(344, 162);
            // 
            // docforecolor
            // 
            this.docforecolor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.docforecolor.DropDown = this.docforecolorselector;
            this.docforecolor.Image = ((System.Drawing.Image)(resources.GetObject("docforecolor.Image")));
            this.docforecolor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.docforecolor.Name = "docforecolor";
            this.docforecolor.ShowDropDownArrow = false;
            this.docforecolor.Size = new System.Drawing.Size(61, 22);
            this.docforecolor.Text = "Fore Color";
            // 
            // docforecolorselector
            // 
            this.docforecolorselector.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.docforecolorselector.Name = "docforecolorselector";
            this.docforecolorselector.OwnerItem = this.docforecolor;
            this.docforecolorselector.Size = new System.Drawing.Size(344, 162);
            // 
            // doclinkcolor
            // 
            this.doclinkcolor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.doclinkcolor.DropDown = this.doclinkcolorselector;
            this.doclinkcolor.Image = ((System.Drawing.Image)(resources.GetObject("doclinkcolor.Image")));
            this.doclinkcolor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.doclinkcolor.Name = "doclinkcolor";
            this.doclinkcolor.ShowDropDownArrow = false;
            this.doclinkcolor.Size = new System.Drawing.Size(57, 22);
            this.doclinkcolor.Text = "Link Color";
            // 
            // doclinkcolorselector
            // 
            this.doclinkcolorselector.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.doclinkcolorselector.Name = "doclinkcolorselector";
            this.doclinkcolorselector.OwnerItem = this.doclinkcolor;
            this.doclinkcolorselector.Size = new System.Drawing.Size(344, 162);
            // 
            // docalinkcolor
            // 
            this.docalinkcolor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.docalinkcolor.DropDown = this.docalinkcolorselector;
            this.docalinkcolor.Image = ((System.Drawing.Image)(resources.GetObject("docalinkcolor.Image")));
            this.docalinkcolor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.docalinkcolor.Name = "docalinkcolor";
            this.docalinkcolor.ShowDropDownArrow = false;
            this.docalinkcolor.Size = new System.Drawing.Size(64, 22);
            this.docalinkcolor.Text = "ALink Color";
            // 
            // docalinkcolorselector
            // 
            this.docalinkcolorselector.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.docalinkcolorselector.Name = "docalinkcolorselector";
            this.docalinkcolorselector.OwnerItem = this.docalinkcolor;
            this.docalinkcolorselector.Size = new System.Drawing.Size(344, 162);
            // 
            // docvlinkcolor
            // 
            this.docvlinkcolor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.docvlinkcolor.DropDown = this.docvlinkcolorselector;
            this.docvlinkcolor.Image = ((System.Drawing.Image)(resources.GetObject("docvlinkcolor.Image")));
            this.docvlinkcolor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.docvlinkcolor.Name = "docvlinkcolor";
            this.docvlinkcolor.ShowDropDownArrow = false;
            this.docvlinkcolor.Size = new System.Drawing.Size(63, 22);
            this.docvlinkcolor.Text = "VLink Color";
            // 
            // docvlinkcolorselector
            // 
            this.docvlinkcolorselector.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.docvlinkcolorselector.Name = "docvlinkcolorselector";
            this.docvlinkcolorselector.OwnerItem = this.docvlinkcolor;
            this.docvlinkcolorselector.Size = new System.Drawing.Size(344, 162);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnRemoveFormat
            // 
            this.tsBtnRemoveFormat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnRemoveFormat.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRemoveFormat.Image")));
            this.tsBtnRemoveFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRemoveFormat.Name = "tsBtnRemoveFormat";
            this.tsBtnRemoveFormat.Size = new System.Drawing.Size(23, 22);
            this.tsBtnRemoveFormat.Text = "Remove selection formating";
            // 
            // frmHTMLeditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 438);
            this.Controls.Add(this.tsColors);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.tsFile);
            this.Controls.Add(this.tsMain);
            this.Name = "frmHTMLeditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HTMLEditor";
            this.Shown += new System.EventHandler(this.frmHTMLeditor_Shown);
            this.Activated += new System.EventHandler(this.frmHTMLeditor_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHTMLeditor_FormClosing);
            this.Load += new System.EventHandler(this.frmHTMLeditor_Load);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.tsFile.ResumeLayout(false);
            this.tsFile.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.ctxMnuHTMLEditor.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageEdit.ResumeLayout(false);
            this.tabPageSource.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ctxMnuRichTextBox.ResumeLayout(false);
            this.tabPagePreview.ResumeLayout(false);
            this.tsColors.ResumeLayout(false);
            this.tsColors.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripComboBox tsComboFontSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnBold;
        private System.Windows.Forms.ToolStripButton tsBtnItalic;
        private System.Windows.Forms.ToolStripButton tsBtnUnderline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsBtnLeftAlign;
        private System.Windows.Forms.ToolStripButton tsBtnCenterAlign;
        private System.Windows.Forms.ToolStripButton tsBtnRightAlign;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsBtnNumberList;
        private System.Windows.Forms.ToolStripButton tsBtnBulletList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStrip tsFile;
        private System.Windows.Forms.ToolStripButton tsBtnNew;
        private System.Windows.Forms.ToolStripButton tsBtnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsBtnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsBtnCut;
        private System.Windows.Forms.ToolStripButton tsBtnCopy;
        private System.Windows.Forms.ToolStripButton tsBtnPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsBtnUndo;
        private System.Windows.Forms.ToolStripButton tsBtnRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel tsStatus;
        private System.Windows.Forms.ToolStripButton tsBtnTable;
        private System.Windows.Forms.ToolStripButton tsBtnPicture;
        private System.Windows.Forms.ToolStripButton tsBtnLink;
        private System.Windows.Forms.ToolStripButton tsBtnSelectAll;
        private System.Windows.Forms.ToolStripButton tsBtnFullAlign;
        private System.Windows.Forms.ToolStripButton tsBtnBR;
        private System.Windows.Forms.ToolStripButton tsBtnIndent;
        private System.Windows.Forms.ToolStripButton tsBtnOutdent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton tsBtnHorizontalLine;
        private System.Windows.Forms.ContextMenuStrip ctxMnuHTMLEditor;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editLinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoLinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteLinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editTablePropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCellPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertColToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteColToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton tsBtnOpenEdit;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clipboardToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageEdit;
        private csExWB.cEXWB cEXWB1;
        private System.Windows.Forms.TabPage tabPageSource;
        private System.Windows.Forms.TabPage tabPagePreview;
        private csExWB.cEXWB cEXWB2;
        private System.Windows.Forms.ContextMenuStrip ctxMnuRichTextBox;
        private System.Windows.Forms.ToolStripMenuItem cutRtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyRtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteRtToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.TreeView treeHTMLTags;
        private HtmlRichTextBox htmlRichTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem insertSpecialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leftarrowtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rightarrowtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem amptoolStripMenuItem;
        private System.Windows.Forms.ToolStrip tsColors;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private ToolStripCustomComboBox editorfontCombo;
        private System.Windows.Forms.ToolStripLabel toolStripLabel10;
        private CustomSplitter splitContainer1;
        private System.Windows.Forms.ToolStripDropDownButton selectionbackcolor;
        private System.Windows.Forms.ToolStripDropDownButton selectionforecolor;
        private ToolStripHtmlColorSelector selectionbackcolorSelector;
        private ToolStripHtmlColorSelector selectionforecolorSelector1;
        private System.Windows.Forms.ToolStripDropDownButton docbackcolor;
        private System.Windows.Forms.ToolStripDropDownButton docforecolor;
        private System.Windows.Forms.ToolStripDropDownButton doclinkcolor;
        private System.Windows.Forms.ToolStripDropDownButton docalinkcolor;
        private System.Windows.Forms.ToolStripDropDownButton docvlinkcolor;
        private ToolStripHtmlColorSelector docbackcolorselector;
        private ToolStripHtmlColorSelector docforecolorselector;
        private ToolStripHtmlColorSelector doclinkcolorselector;
        private ToolStripHtmlColorSelector docalinkcolorselector;
        private ToolStripHtmlColorSelector docvlinkcolorselector;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton tsBtnRemoveFormat;
    }
}