using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;

namespace DemoApp
{
    #region WinExternal class
    /// <summary>
    /// Simple class to demonstrate WindowExternal functionality
    /// Used in frmWindowExternal.cs form
    /// </summary>
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class WinExternal
    {
        private string m_Msg = "Original value of AMessageFromHome property.";
        public WinExternal()
        {

        }

        public void SaySomething()
        {
            System.Windows.Forms.MessageBox.Show("SaySomething method of WinExternal called!");
        }

        public string AMessageFromHome
        {
            get
            {
                return m_Msg;
            }
            set
            {
                System.Windows.Forms.MessageBox.Show("Setting value of AMessageFromHome property via window.external from:\r\n" + m_Msg + "\r\nTo:\r\n" + value);
                m_Msg = value;
            }
        }
    }
    #endregion
}
