// csDLMan.h : Declaration of the CcsDLMan

#ifndef __CSDLMAN_H_
#define __CSDLMAN_H_

#include "resource.h"       // main symbols
#include <urlmon.h> //needs Urlmon.lib
#include "UrlParts.h" //Requires wininet.lib
#include "csExWBDLManCP.h"
//To use our own protocol handlers for HTTP and HTTPS
#include "ProtocolImpl.h"


class CTmpBuffer;
class WBBSCBFileDL;

////////////////////////
//Simple buffer class.
//Since we are building this control with min dep
//we need a simple str buffer, can't use CString,....
////////////////////////
class CTmpBuffer
{
	#define STARTUP_TEMP_BUFFER MAX_PATH
	#define RES_BUFFER_SIZE 512
	#ifdef _UNICODE
		#define CHAR_FUDGE 1    // one TCHAR unused is good enough
	#else
		#define CHAR_FUDGE 2    // two BYTES unused for case of DBC last char
	#endif
public:
	CTmpBuffer();
	CTmpBuffer(LPCTSTR strText);
	CTmpBuffer(UINT iSize);
	~CTmpBuffer();
	
	// *** Local ***

	//We don't destroy the buffer
	//Usefull in loops when reading values into the buffer
	//using = operator.
	void ResetBuffer();
//Allocate buffer
	UINT AllocateBuffer(UINT nsize);
//Append a string
	UINT Append(LPCTSTR strText, UINT iMaxLen = 0);
//Append a BSTR
	UINT AppendBSTR(BSTR strText, UINT iMaxLen = 0);
//Append an int value
	UINT Appendint(int iNumber, int radix = 10);
//Append a long value
	UINT Appendlong(long lNumber, int radix = 10);
//Append resource string
	UINT AppendResStr(UINT nID, UINT iMaxLen = 0);
//Append GUID
	UINT AppendGUID(REFGUID src);

//Accessors
	TCHAR* GetString(void);
	UINT ReleaseString(void);
	LPCTSTR GetBuffer(void) const;
	//Get buffer len, may or may not contain any characters
	UINT GetBufferLen(void) const;
	//Get the Text len (number of actual chars)
	UINT GetBufferTextLen(void) const;
	TCHAR GetAt(int nIndex);
	void SetAt(int nIndex, TCHAR ch);

//Operators
	TCHAR* operator &() { return m_Buffer; }
	operator LPCTSTR() const { return m_Buffer; }
	TCHAR operator[] (int nIndex);

	CTmpBuffer& operator=(const CTmpBuffer& src);
	CTmpBuffer& operator=(const LPCTSTR src);
	CTmpBuffer& operator+=(const CTmpBuffer& strSrc);
	CTmpBuffer& operator+=(const LPCTSTR strSrc);
	CTmpBuffer& operator=(const UINT nID);
	CTmpBuffer& operator+=(const UINT nID);

private:
	ULONG		m_cRef;
	LPTSTR		m_Buffer;
	UINT		m_BufferLen;
	//where to write
	UINT		m_BufferTextLen;
	bool		m_Allocated;
	HINSTANCE	m_hInst;
	
	void InitLocalResources();
	void ClearLocalResources();
};


/////////////////////////////////////////////////////////////////////////////
// CcsDLMan
class ATL_NO_VTABLE CcsDLMan : 
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CcsDLMan, &CLSID_csDLMan>,
	public ISupportErrorInfo,
	public IConnectionPointContainerImpl<CcsDLMan>,
	public IDispatchImpl<IcsDLMan, &IID_IcsDLMan, &LIBID_CSEXWBDLMANLib>,
	public IDownloadManager,
	public CProxy_IcsDLManEvents< CcsDLMan >
{
public:
	CcsDLMan();
	~CcsDLMan();

DECLARE_REGISTRY_RESOURCEID(IDR_CSDLMAN)

DECLARE_PROTECT_FINAL_CONSTRUCT()

BEGIN_COM_MAP(CcsDLMan)
	COM_INTERFACE_ENTRY(IcsDLMan)
	COM_INTERFACE_ENTRY(IDispatch)
	COM_INTERFACE_ENTRY(ISupportErrorInfo)
	COM_INTERFACE_ENTRY(IDownloadManager) //Added
	COM_INTERFACE_ENTRY(IConnectionPointContainer)
	COM_INTERFACE_ENTRY_IMPL(IConnectionPointContainer)
END_COM_MAP()
BEGIN_CONNECTION_POINT_MAP(CcsDLMan)
CONNECTION_POINT_ENTRY(DIID__IcsDLManEvents)
END_CONNECTION_POINT_MAP()


// ISupportsErrorInfo
	STDMETHOD(InterfaceSupportsErrorInfo)(REFIID riid);

// IcsDLMan
public:
	STDMETHOD(HookProcNCode)(/*[in]*/ WINDOWSHOOK_TYPES lHookType, /*[in,out]*/ long *nCode);
	STDMETHOD(SetupWindowsHook)(/*[in]*/ WINDOWSHOOK_TYPES lHookType, /*[in]*/ long hwndTargetWnd , /*[in]*/ VARIANT_BOOL bStart, /*[in,out]*/ long *lUWMHookMsgID);
	STDMETHOD(CancelFileDownload)(long DlUid);
	BOOL RemoveBSCBFromDLArr(long Uid);
	STDMETHOD(get_HTTPprotocol)(/*[out, retval]*/ VARIANT_BOOL *pVal);
	STDMETHOD(put_HTTPprotocol)(/*[in]*/ VARIANT_BOOL newVal);
	STDMETHOD(get_HTTPSprotocol)(/*[out, retval]*/ VARIANT_BOOL *pVal);
	STDMETHOD(put_HTTPSprotocol)(/*[in]*/ VARIANT_BOOL newVal);
	STDMETHOD(get_HWNDInternetExplorerServer)(/*[out, retval]*/ long *pVal);
	STDMETHOD(put_HWNDInternetExplorerServer)(/*[in]*/ long newVal);
	STDMETHOD(DownloadUrlAsync)(BSTR URL, long *DLUID);
	STDMETHOD(Download)(IMoniker *pmk,IBindCtx *pbc,DWORD dwBindVerb,
										LONG grfBINDF,
										BINDINFO *pBindInfo,
										LPCOLESTR pszHeaders,
										LPCOLESTR pszRedir,
										UINT uiCP);
	HWND m_IEServerHwnd;
private:
	HRESULT CancelFileDl(long Uid);
	HRESULT WBCreateBSCBFileDL(WBBSCBFileDL **ppTargetBSCBFileDL);
	long m_Uid;
	//Array of BindStatusCallBacks for file downloads
	//Used from client side to abort timed out dls, ...
	CSimpleArray<WBBSCBFileDL*> m_arrDL;
};


///////////////////////////////////////////////////////////////////////
///////////A simple download manager with resume capabilities
////////////////////////////////////////////////////////////////////////
class WBBSCBFileDL : 
		public IBindStatusCallback, 
		public IHttpNegotiate,
		public IAuthenticate
{
public:
	WBBSCBFileDL();
	~WBBSCBFileDL();

    // IUnknown
    ULONG STDMETHODCALLTYPE AddRef();
    ULONG STDMETHODCALLTYPE Release();
    STDMETHODIMP QueryInterface(REFIID iid, void ** ppvObject);

	//IBindStatusCallback
    STDMETHODIMP OnStartBinding(DWORD dwReserved, IBinding * pib);
    STDMETHODIMP GetPriority(LONG * pnPriority);
    STDMETHODIMP OnLowResource(DWORD reserved);
    STDMETHODIMP OnProgress(ULONG ulProgress, ULONG ulProgressMax, ULONG ulStatusCode, LPCWSTR szStatusText);
    STDMETHODIMP OnStopBinding(HRESULT hresult,LPCWSTR szError);
    STDMETHODIMP GetBindInfo(DWORD *grfBINDF, BINDINFO * pbindinfo);
    STDMETHODIMP OnDataAvailable(DWORD grfBSCF, DWORD dwSize, FORMATETC* pformatetc, STGMEDIUM* pstgmed);
    STDMETHODIMP OnObjectAvailable(REFIID riid,IUnknown* punk);

	// IHttpNegotiate methods
    STDMETHODIMP BeginningTransaction(
                LPCWSTR szURL,
                LPCWSTR szHeaders,
                DWORD dwReserved,
                LPWSTR *pszAdditionalHeaders);

    STDMETHODIMP OnResponse(
                DWORD dwResponseCode,
                LPCWSTR szResponseHeaders,
                LPCWSTR szRequestHeaders,
                LPWSTR *pszAdditionalRequestHeaders);

	// IAuthenticate
	
	//Returns one of the following values:;
	//S_OK Authentication was successful. 
	//E_ACCESSDENIED Authentication failed. 
	//E_INVALIDARG One or more parameters are invalid.
	//Currently, the user name and password options handle only
	//the Basic authentication scheme and N..
	STDMETHODIMP Authenticate(HWND *phwnd, LPWSTR *pszUsername, LPWSTR *pszPassword);

	//Class specific
	bool InitByClient(long uID, CcsDLMan *EventsPtr, BSTR lpUrl, HWND client);
	bool InitByUser(long uID, CcsDLMan *pHost, LPCOLESTR UrlMonExtraHeaders, HWND client);

	bool CancelDL(void);
	bool IsDownloading(void);

	//Previous BSCB before we used RegisterBindStatuscallback
	IBindStatusCallback *m_pPrevBSCB;
	IBindCtx			*m_pBindCtx;
	long				m_Uid;

private:
	ULONG				m_cRef;
	BOOL				m_fRedirect; // need to be informed when we're being redirected by the server


	IBinding			*m_pBinding;
	LPSTREAM			m_pstm;
	//Path with backslash m_bstr
	CComBSTR			fPathToSave;
	//File name
	CComBSTR			fFileName; //filename.zip
	CComBSTR			fFileExt; //.zip
	CComBSTR			fFileSize; //in bytes
	//Contains URL
	//This can change if we receive a redirect in onprogress
	CComBSTR			fUrl;
	CComBSTR			m_strRedirectedURL;
	CComBSTR			m_strDLManExtraHeaders;
	//This is the full path (Path+filename) of save target file
	//If we receive a redirect in BeginningTranscaction, URL will change
	CComBSTR			fFullSavePath;
	//To write to file
	DWORD				m_cbOld;
	HANDLE				hFile;
	//This flag is used to send/not progress events
	//decided to have it to avoid unnecessary events fired
	//when client does not care to have them
	VARIANT_BOOL		m_SendProgressEvent;
	//To relay events
	CcsDLMan			*m_Events;
	//To make sure we have a client to send info to
	//This is needed since we can end our app while URLMon
	//is using this class to continue download. Independent of
	//our app. Cool.
	HWND				m_hwndEvents;
	//To get client return value for Cancel
	VARIANT_BOOL		m_vboolCancelDL;
	VARIANT_BOOL		m_vboolResuming;
	BOOL				m_bCancelled;
	HWND				m_hwndClient;
	//To reset internal vars since we are reusing this class
	void ResetInternalVars(void);
};

//////////////////////////////////////////////////////////////////////////////////////////////
//WBPassthruSink
//To allow implementation of temp protocols, http, https,...
//Posted by Igor Tandetnik "itandetnik@mvps.org"
//Can be found using a search for PassthroughApp in google groups
//////////////////////////////////////////////////////////////////////////////////////////////
class WBPassthruSink :
	public PassthroughAPP::CInternetProtocolSinkWithSP<WBPassthruSink>,
	public IHttpNegotiate
{
	typedef PassthroughAPP::CInternetProtocolSinkWithSP<WBPassthruSink> BaseClass;
public:

	BEGIN_COM_MAP(WBPassthruSink)
		COM_INTERFACE_ENTRY(IHttpNegotiate)
		COM_INTERFACE_ENTRY_CHAIN(BaseClass)
	END_COM_MAP()

	BEGIN_SERVICE_MAP(WBPassthruSink)
		SERVICE_ENTRY(IID_IHttpNegotiate)
	END_SERVICE_MAP()


	STDMETHODIMP BeginningTransaction(
		/* [in] */ LPCWSTR szURL,
		/* [in] */ LPCWSTR szHeaders,
		/* [in] */ DWORD dwReserved,
		/* [out] */ LPWSTR *pszAdditionalHeaders);

	STDMETHODIMP OnResponse(
		/* [in] */ DWORD dwResponseCode,
		/* [in] */ LPCWSTR szResponseHeaders,
		/* [in] */ LPCWSTR szRequestHeaders,
		/* [out] */ LPWSTR *pszAdditionalRequestHeaders);

	HRESULT OnStart(LPCWSTR szUrl, IInternetProtocolSink *pOIProtSink,
		IInternetBindInfo *pOIBindInfo, DWORD grfPI, DWORD dwReserved,
		IInternetProtocol* pTargetProtocol);

	STDMETHODIMP ReportProgress(
		/* [in] */ ULONG ulStatusCode,
		/* [in] */ LPCWSTR szStatusText);

	STDMETHODIMP Switch(
		/* [in] */ PROTOCOLDATA *pProtocolData);

	CcsDLMan *m_pEvents;
	long m_hwndIEServer;
//	CComPtr<IBindStatusCallback> spBSCB;
	CComBSTR m_strUrl;
	CComBSTR m_strRedirUrl;
	CComBSTR m_strRedirHeaders;
};

typedef PassthroughAPP::CustomSinkStartPolicy<WBPassthruSink>
	TestStartPolicy;

class WBPassthru :
	public PassthroughAPP::CInternetProtocol<TestStartPolicy>
{
/*
public:

	STDMETHODIMP Start(LPCWSTR szUrl, IInternetProtocolSink *pOIProtSink,
		IInternetBindInfo *pOIBindInfo, DWORD grfPI, DWORD dwReserved)
	{
		::MessageBox(GetDesktopWindow(), _T("Start"),_T("PassthroughAPP::CInternetProtocol"),MB_OK);
		ATLASSERT(m_spInternetProtocol != 0);
		if (!m_spInternetProtocol)
		{
			return E_UNEXPECTED;
		}
		return TestStartPolicy::OnStart(szUrl, pOIProtSink, pOIBindInfo, grfPI,
			dwReserved, m_spInternetProtocol);
	}
*/
};

#endif //__CSDLMAN_H_
