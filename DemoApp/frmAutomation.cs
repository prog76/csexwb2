using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DemoApp
{
    //Nav to google and,
    //cEXWB1.AutomationTask_PerformEnterData("q", "sea");
    //cEXWB1.AutomationTask_PerformSubmitForm("f");

    public partial class frmAutomation : Form
    {
        public frmAutomation()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmAutomation_Load);
            this.Shown += new EventHandler(frmAutomation_Shown);
            this.StartPosition = FormStartPosition.CenterParent;
            this.cEXWB1.TitleChange += new csExWB.TitleChangeEventHandler(cEXWB1_TitleChange);
            this.toolStrip1.ItemClicked += new ToolStripItemClickedEventHandler(toolStrip1_ItemClicked);
        }

        void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == this.toolStripButtonClickButton.Name)
            {
                this.cEXWB1.AutomationTask_PerformClickButton("Button1");
            }
            else if (e.ClickedItem.Name == toolStripButtonSelectRadio.Name)
            {
                this.cEXWB1.AutomationTask_PerformSelectRadio("Radio2");
            }
            else if (e.ClickedItem.Name == toolStripButtonCheckCheck1.Name)
            {
                this.cEXWB1.AutomationTask_PerformSelectRadio("Check1");
            }
            else if (e.ClickedItem.Name == toolStripButtonEnterdataTextbox.Name)
            {
                this.cEXWB1.AutomationTask_PerformEnterData("TextBox1", "Some text");
            }
            else if (e.ClickedItem.Name == toolStripButton5EnterDataTextArea.Name)
            {
                this.cEXWB1.AutomationTask_PerformEnterDataTextArea("TextArea1", "Some text");
            }
            else if (e.ClickedItem.Name == toolStripButtonKeyStroke.Name)
            {
                this.cEXWB1.AutomationTask_SimulateKeyStroke(Keys.Back);
            }
            else if (e.ClickedItem.Name == toolStripButtonSelectListItem.Name)
            {
                this.cEXWB1.AutomationTask_PerformSelectList("List", "Second");
            }
            else if (e.ClickedItem.Name == toolStripButtonClickLink.Name)
            {
                this.cEXWB1.AutomationTask_PerformClickLink("Link1");
            }
            else if (e.ClickedItem.Name == toolStripButtonSelectMultiListItems.Name)
            {
                List<csExWB.MultiSelectHTMLList> selects = new List<csExWB.MultiSelectHTMLList>();
                List<string> items = new List<string>();
                List<string> items1 = new List<string>();

                //Add list item value or text
                items.Add("First");
                items.Add("Third");
                //set up the class to hold list name and a list of item values or texts
                csExWB.MultiSelectHTMLList select = new csExWB.MultiSelectHTMLList("List", items);

                //Add to collection
                selects.Add(select);

                //set up the next list
                items1.Add("First1");
                items1.Add("Third1");
                csExWB.MultiSelectHTMLList select1 = new csExWB.MultiSelectHTMLList("List1", items1);

                //Add to collection
                selects.Add(select1);

                //call
                cEXWB1.AutomationTask_PerformMultiSelectListItems(selects);
            }
        }

        void frmAutomation_Shown(object sender, EventArgs e)
        {
            string source = "<html><head><title>Automation Demo</title>" + 
            "<script type=\"text/javascript\">" +
            "function myfunction(txt)" +
            "{ alert(\"Hello, button was clicked\") }" +
            "</script></head><body bgcolor=\"#ffffcc\">" +
            "<h3> Web automation example </h3>" +
            "<form>" +
            "Text box:  <input type=\"text\" name=\"TextBox1\" value=\"\" /><br /><br />" +
            "Text Area:  <textarea name=\"TextArea1\" rows=\"5\" cols=\"20\">Hello there</textarea><br /><br />" +
            "<input type=\"button\" name=\"Button1\" onclick=\"myfunction('Hello')\" value=\"Call function\" /><br /><br />" +
            "<input type=\"radio\" name=\"Radio1\"  />Radio choice 1<br />" +
            "<input type=\"radio\" name=\"Radio2\"  />Radio choice 2<br />" +
            "<input type=\"radio\" name=\"Radio3\"  />Radio choice 3<br />" +
            "<input type=\"checkbox\" name=\"Check1\"  />Check 1<br />" +
            "<br />" +
            "<select size=\"5\" name=\"List\" multiple>" +
            "<option value=\"First\">First choice</option>" +
            "<option value=\"Second\">Second choice</option>" +
            "<option value=\"Third\">Third choice</option>" +
            "</select>" +
            "<br />" +
            "<br />" +
            "<select size=\"5\" name=\"List1\" multiple>" +
            "<option value=\"First1\">First1 choice</option>" +
            "<option value=\"Second1\">Second1 choice</option>" +
            "<option value=\"Third1\">Third1 choice</option>" +
            "</select><br />" +
            "</form>" +
            "<p><a href=\"http://www.google.com\" name=\"Link1\">This text</a> is a link to another Web site.</p>" +
            "</body></html>";

            this.cEXWB1.LoadHtmlIntoBrowser(source);
        }

        void cEXWB1_TitleChange(object sender, csExWB.TitleChangeEventArgs e)
        {
            this.Text = e.title;
        }

        void frmAutomation_Load(object sender, EventArgs e)
        {
            this.cEXWB1.NavToBlank();
        }
    }
}