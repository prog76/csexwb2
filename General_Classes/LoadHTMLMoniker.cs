using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace IfacesEnumsStructsClasses
{
    /// <summary>
    /// For loading html into document while having the ability to set the baseUrl
    /// Only two methods of IMoniker are called BindToStorage and GetDisplayName
    /// In BindToStorage, we pass a ref to our stream object to be used for loading page
    /// data. In GetDisplayName, we pass our baseUrl to MSHTML to be used.
    /// BaseUrl must be in form of http://www.sitename.com
    /// <code>
    /// string html = "<HTML><HEAD></Head><Body><p><a href=\"gosearch\">Second link</a></p><p>1 This HTML content is being loaded from a stream.</p><p>2 This HTML content is being loaded from a stream.</p><p><a href=\"goHome\">Second link</a></p></Body></HTML>";
    /// m_CurWB.LoadHtmlIntoBrowser(html, "http://www.google.com");
    /// </code>
    /// </summary>
    public class LoadHTMLMoniker : IMoniker, IAsyncMoniker
    {
        private IStream m_stream = null;
        private string m_sBaseName = string.Empty;

        public void InitLoader(string sContent, string sBaseUrl)
        {
            m_sBaseName = sBaseUrl;
            int hr = WinApis.CreateStreamOnHGlobal(Marshal.StringToHGlobalAuto(sContent), true, out m_stream);
            if ((hr != 0) || (m_stream == null))
                return;
        }

        #region IMoniker Members

        void IMoniker.BindToObject(IBindCtx pbc, IMoniker pmkToLeft, ref Guid riidResult, out object ppvResult)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.BindToStorage(IBindCtx pbc, IMoniker pmkToLeft, ref Guid riid, out object ppvObj)
        {
            ppvObj = null;
            if (riid.Equals(Iid_Clsids.IID_IStream))
                ppvObj = (IStream)m_stream;
        }

        void IMoniker.CommonPrefixWith(IMoniker pmkOther, out IMoniker ppmkPrefix)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.ComposeWith(IMoniker pmkRight, bool fOnlyIfNotGeneric, out IMoniker ppmkComposite)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.Enum(bool fForward, out IEnumMoniker ppenumMoniker)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.GetClassID(out Guid pClassID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.GetDisplayName(IBindCtx pbc, IMoniker pmkToLeft, out string ppszDisplayName)
        {
            ppszDisplayName = m_sBaseName;
        }

        void IMoniker.GetSizeMax(out long pcbSize)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.GetTimeOfLastChange(IBindCtx pbc, IMoniker pmkToLeft, out System.Runtime.InteropServices.ComTypes.FILETIME pFileTime)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.Hash(out int pdwHash)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.Inverse(out IMoniker ppmk)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        int IMoniker.IsDirty()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        int IMoniker.IsEqual(IMoniker pmkOtherMoniker)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        int IMoniker.IsRunning(IBindCtx pbc, IMoniker pmkToLeft, IMoniker pmkNewlyRunning)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        int IMoniker.IsSystemMoniker(out int pdwMksys)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.Load(IStream pStm)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.ParseDisplayName(IBindCtx pbc, IMoniker pmkToLeft, string pszDisplayName, out int pchEaten, out IMoniker ppmkOut)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.Reduce(IBindCtx pbc, int dwReduceHowFar, ref IMoniker ppmkToLeft, out IMoniker ppmkReduced)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.RelativePathTo(IMoniker pmkOther, out IMoniker ppmkRelPath)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.Save(IStream pStm, bool fClearDirty)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
