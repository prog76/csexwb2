using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using IfacesEnumsStructsClasses;

namespace csExWB
{
    public delegate void HTMLEditDesignerEventHandler(object sender, HTMLEditDesignerArgs e);
    public class HTMLEditDesignerArgs : System.ComponentModel.CancelEventArgs
    {
        public HTMLEventDispIds m_EventDispId = 0;
        public IHTMLEventObj m_pEvtObj = null;

        public HTMLEditDesignerArgs()
        {
        }

        public void ResetParameters(HTMLEventDispIds DispID, IHTMLEventObj pEvtObj)
        {
            this.Cancel = false;
            this.m_EventDispId = DispID;
            this.m_pEvtObj = pEvtObj;
        }
    }

    //Note  IME events do not have DISPIDs, so the DISPID parameter
    //will be zero for any IME event. If a designer handles IME events
    //and the DISPID is zero, the designer can determine the event type
    //from the IHTMLEventObj::srcElement property.
    public class HTMLEditDesigner : IHTMLEditDesigner
    {
        #region Events
        public event HTMLEditDesignerEventHandler HTMLEditDesigner_PreHandleEvent = null;
        public event HTMLEditDesignerEventHandler HTMLEditDesigner_PostHandleEvent = null;
        public event HTMLEditDesignerEventHandler HTMLEditDesigner_TranslateAccelerator = null;
        public event HTMLEditDesignerEventHandler HTMLEditDesigner_PostEditorEventNotify = null;
        private HTMLEditDesignerArgs m_HTMLEditDesignerArgs = new HTMLEditDesignerArgs(); 
        #endregion

        public HTMLEditDesigner()
        {
        }

        private IHTMLDocument2 m_pDoc2 = null;
        public bool ActivateDesigner(IHTMLDocument2 pDoc2)
        {
            m_pDoc2 = pDoc2;
            bool bret = false;
            IfacesEnumsStructsClasses.IServiceProvider pSp = pDoc2 as IfacesEnumsStructsClasses.IServiceProvider;
            if (pSp == null)
                return bret;

            IntPtr pout = IntPtr.Zero;
            int hr = pSp.QueryService(ref Iid_Clsids.SID_SHTMLEditServices, 
                ref Iid_Clsids.IID_IHTMLEditServices, out pout);
            if (pout == IntPtr.Zero)
                return bret;

            IHTMLEditServices pEs = Marshal.GetObjectForIUnknown(pout) as IHTMLEditServices;
            if (pEs == null)
                return bret;

            //Add to desiners
            pEs.AddDesigner(this);

            return true;
        }

        public bool DeactivateDesigner()
        {

            bool bret = false;
            if (m_pDoc2 == null)
                return bret;
            IfacesEnumsStructsClasses.IServiceProvider pSp = m_pDoc2 as IfacesEnumsStructsClasses.IServiceProvider;
            if (pSp == null)
                return bret;

            IntPtr pout = IntPtr.Zero;
            int hr = pSp.QueryService(ref Iid_Clsids.SID_SHTMLEditServices,
                ref Iid_Clsids.IID_IHTMLEditServices, out pout);
            if (pout == IntPtr.Zero)
                return bret;

            IHTMLEditServices pEs = Marshal.GetObjectForIUnknown(pout) as IHTMLEditServices;
            if (pEs == null)
                return bret;

            pEs.RemoveDesigner(this);

            return true;
        }

        #region IHTMLEditDesigner Members

        //inEvtDispId one of DISPID_HTMLELEMENTEVENTS2
        int IHTMLEditDesigner.PreHandleEvent(int inEvtDispId, IHTMLEventObj pIEventObj)
        {
            if(HTMLEditDesigner_PreHandleEvent != null)
            {
                m_HTMLEditDesignerArgs.ResetParameters((HTMLEventDispIds)inEvtDispId, pIEventObj);
                HTMLEditDesigner_PreHandleEvent(this, m_HTMLEditDesignerArgs);
                if (m_HTMLEditDesignerArgs.Cancel)
                    return Hresults.S_OK;
            }
            //Default
            return Hresults.S_FALSE;
        }
        
        //MSHTML calls this method after it has processed an event in the editor's 
        //environment. In a custom editor implementation, this method enables you 
        //to alter the behavior of an event after the MSHTML Editor has finished 
        //processing it.
        int IHTMLEditDesigner.PostHandleEvent(int inEvtDispId, IHTMLEventObj pIEventObj)
        {
            if (HTMLEditDesigner_PostHandleEvent != null)
            {
                m_HTMLEditDesignerArgs.ResetParameters((HTMLEventDispIds)inEvtDispId, pIEventObj);
                HTMLEditDesigner_PostHandleEvent(this, m_HTMLEditDesignerArgs);
                if (m_HTMLEditDesignerArgs.Cancel)
                    return Hresults.S_OK;
            }
            //Default
            return Hresults.S_FALSE;
        }

        int IHTMLEditDesigner.TranslateAccelerator(int inEvtDispId, IHTMLEventObj pIEventObj)
        {
            if (HTMLEditDesigner_TranslateAccelerator != null)
            {
                m_HTMLEditDesignerArgs.ResetParameters((HTMLEventDispIds)inEvtDispId, pIEventObj);
                HTMLEditDesigner_TranslateAccelerator(this, m_HTMLEditDesignerArgs);
                if (m_HTMLEditDesignerArgs.Cancel)
                    return Hresults.S_OK;
            }
            //Default
            return Hresults.S_FALSE;
        }

        int IHTMLEditDesigner.PostEditorEventNotify(int inEvtDispId, IHTMLEventObj pIEventObj)
        {
            if (HTMLEditDesigner_PostEditorEventNotify != null)
            {
                m_HTMLEditDesignerArgs.ResetParameters((HTMLEventDispIds)inEvtDispId, pIEventObj);
                HTMLEditDesigner_PostEditorEventNotify(this, m_HTMLEditDesignerArgs);
                //IHTMLEditDesigner::PostEditorEventNotify is not cancellable,
                //and its return value is ignored. 
                //if (m_HTMLEditDesignerArgs.Cancel)
                //    return Hresults.S_OK;
            }
            //Default
            return Hresults.S_FALSE;
        }

        #endregion
    }
}
