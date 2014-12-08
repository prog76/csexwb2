using System;
using System.Collections.Generic;

namespace csExWB
{
    /// <summary>
    /// Class is used in combination with AutomationTask_PerformMultiSelectListItems
    /// method of csEXWB class
    /// </summary>
    public class MultiSelectHTMLList
    {
        public MultiSelectHTMLList(string _selectnameorid, List<string> _listitemsnamesorids)
        {
            this.m_SelectNameOrId = _selectnameorid;
            this.m_ListItemsNamesOrIds = _listitemsnamesorids;
        }
        public string m_SelectNameOrId = string.Empty;
        public List<string> m_ListItemsNamesOrIds = new List<string>();
    }
}
