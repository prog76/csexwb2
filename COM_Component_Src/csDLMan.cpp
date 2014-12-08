// csDLMan.cpp : Implementation of CcsDLMan
#include "stdafx.h"
#include "CsExWBDLMan.h"
#include "csDLMan.h"
#include "ProtocolCF.h"

//hookShell = SetWindowsHookEx(WH_SHELL, (HOOKPROC)ShellHookCallback, g_appInstance, threadID);

///////////////////////////////////////////////
//Macros
BOOL VARIANTBOOLTOBOOL(VARIANT_BOOL x) { return (x == VARIANT_TRUE) ? TRUE : FALSE; }
bool VARIANTBOOLTObool(VARIANT_BOOL x) { return (x == VARIANT_TRUE) ? true : false; }
VARIANT_BOOL BOOLTOVARIANTBOOL(BOOL x) { return (x) ? VARIANT_TRUE : VARIANT_FALSE; }
VARIANT_BOOL boolTOVARIANTBOOL(bool x) { return (x) ? VARIANT_TRUE : VARIANT_FALSE; }

///////////////////////////////////////////////
//APP
typedef PassthroughAPP::CMetaFactory<PassthroughAPP::CComClassFactoryProtocol,
	WBPassthru> MetaFactory;

////////////////////////////////////////////////
//Windows hooks structure, vars and callbacks

/*
Hook				Scope 
WH_CALLWNDPROC		Thread or global 
WH_CALLWNDPROCRET	Thread or global 
WH_CBT				Thread or global 
WH_DEBUG			Thread or global 
WH_FOREGROUNDIDLE	Thread or global 
WH_GETMESSAGE		Thread or global 
WH_JOURNALPLAYBACK	Global only 
WH_JOURNALRECORD	Global only 
WH_KEYBOARD			Thread or global 
WH_KEYBOARD_LL		Global only 
WH_MOUSE			Thread or global 
WH_MOUSE_LL			Global only 
WH_MSGFILTER		Thread or global 
WH_SHELL			Thread or global 
WH_SYSMSGFILTER		Global only 
*/

typedef struct WBHOOKDATA 
{ 
    int nType;
	HWND hwndTarget;
	BOOL bHookInstalled;
	UINT uiHookMsgID;
    HOOKPROC hkprc;
    HHOOK hhook;
} WBHOOKDATA; 

#define NUMHOOKS 12

static WBHOOKDATA wbhookdata[NUMHOOKS];
static LRESULT CALLBACK MouseProc(int nCode, WPARAM wParam, LPARAM lParam);
static LRESULT CALLBACK KeyboardProc(int nCode, WPARAM wParam, LPARAM lParam);
static LRESULT CALLBACK LowLevelKeyboardProc(int nCode, WPARAM wParam, LPARAM lParam);
static LRESULT CALLBACK CallWndProc(int nCode, WPARAM wParam, LPARAM lParam);
static LRESULT CALLBACK CBTProc(int nCode, WPARAM wParam, LPARAM lParam);
static LRESULT CALLBACK GetMsgProc(int nCode, WPARAM wParam, LPARAM lParam);
static LRESULT CALLBACK MessageProc(int nCode, WPARAM wParam, LPARAM lParam);
static LRESULT CALLBACK LowLevelMouseProc(int nCode, WPARAM wParam, LPARAM lParam);
static LRESULT CALLBACK ForegroundIdleProc(int nCode, WPARAM wParam, LPARAM lParam);
static LRESULT CALLBACK CallWndRetProc(int nCode, WPARAM wParam, LPARAM lParam);
static LRESULT CALLBACK SysMsgProc(int nCode, WPARAM wParam, LPARAM lParam);
static LRESULT CALLBACK ShellProc(int nCode, WPARAM wParam, LPARAM lParam);

static int nCode_CBTProc; //(CBTProc)
static int nCode_MessageProc; //(MessageProc)
static int nCode_SysMsgProc; //(SysMsgProc)
static int nCode_ShellProc; //(ShellProc)

#define H_CALLWNDPROC		0 //CallWndProc
#define H_CBT				1 //CBTProc
#define H_GETMESSAGE		2 //GetMsgProc
#define H_KEYBOARD			3 //KeyboardProc
#define H_MOUSE				4 //MouseProc
#define H_MSGFILTER			5 //MessageProc
#define H_KEYBOARD_LL		6 //LowLevelKeyboardProc 
#define H_MOUSE_LL			7 //LowLevelMouseProc
#define H_FOREGROUNDIDLE	8 //ForegroundIdleProc
#define H_CALLWNDPROCRET	9 //CallWndRetProc
#define H_SYSMSGFILTER		10 //SysMsgProc
#define H_SHELL				11 //ShellProc

//Define Hook msgs
//Guids generated using sdk GuidGen util
#define UWM_MOUSE_HOOKPROC_MSG _T("UWM_MOUSE-{A89C6106-B837-4ce9-A1D2-B55B833272D2}")
#define UWM_KEYBOARD_HOOKPROC_MSG _T("UWM_KEYBOARD-{DD6BA45D-0A52-442b-A58D-75273C3C1E0D}")
#define UWM_LOWLEVELKEYBOARD_HOOKPROC_MSG _T("UWM_LOWLEVELKEYBOARD-{636CD093-89D0-46da-98D8-A756B190033A}")
#define UWM_CALLWND_HOOKPROC_MSG _T("UWM_CALLWND-{6CF01631-BF0B-4479-B86A-198C63285B5E}")
#define UWM_CBT_HOOKPROC_MSG _T("UWM_CBT-{AD48A334-EE9C-4ef9-AFE4-0EB2483DE790}")
#define UWM_GETMSG_HOOKPROC_MSG _T("UWM_GETMSG-{2EEFC149-231C-4636-B24F-1788CA63AE0A}")
#define UWM_MESSAGE_HOOKPROC_MSG _T("UWM_MESSAGE-{9508F07B-50F9-4d19-B6C2-99FE5F7E99C1}")
#define UWM_LOWLEVELMOUSE_HOOKPROC_MSG _T("UWM_LOWLEVELMOUSE-{DF69AA88-8F7E-44ac-A1B3-3CED59C77E39}")
#define UWM_FORGROUNDIDLE_HOOKPROC_MSG _T("UWM_FORGROUNDIDLE-{88E3AE4F-103F-4549-B24F-8964C6335706}")
#define UWM_CALLWNDRET_HOOKPROC_MSG _T("UWM_CALLWNDRET-{6C5FD4ED-B340-4563-9F74-908F8E292635}")
#define UWM_SYSMSG_HOOKPROC_MSG _T("UWM_SYSMSG-{13480F7E-5357-4eb3-979C-94CB6BE2B106}")
#define UMW_SHELL_HOOKPROC_MSG _T("UMW_SHELL-{1E09A616-CBF9-4aaa-9A15-131B4A46A6E1}")

/////////////////////////////////////////////////////////////////////////////
// CcsDLMan

STDMETHODIMP CcsDLMan::InterfaceSupportsErrorInfo(REFIID riid)
{
	static const IID* arr[] = 
	{
		&IID_IcsDLMan
	};
	for (int i=0; i < sizeof(arr) / sizeof(arr[0]); i++)
	{
		if (InlineIsEqualGUID(*arr[i],riid))
			return S_OK;
	}
	return S_FALSE;
}

CcsDLMan::CcsDLMan()
{
	m_Uid = 0;
	m_IEServerHwnd = NULL;
	//Add this instance to our global ptrs
	LPVOID thisPtr = reinterpret_cast<LPVOID>(this);
	//Just in case
	if(gCtrlInstances.Find(thisPtr) == -1)
		gCtrlInstances.Add(thisPtr);

	nCode_CBTProc = 0;
	nCode_MessageProc = 0;
	nCode_SysMsgProc = 0;
	nCode_ShellProc = 0;

	wbhookdata[H_CALLWNDPROC].bHookInstalled = FALSE;
	wbhookdata[H_CALLWNDPROC].hhook = NULL;
	wbhookdata[H_CALLWNDPROC].hkprc = (HOOKPROC)CallWndProc;
	wbhookdata[H_CALLWNDPROC].hwndTarget = NULL;
	wbhookdata[H_CALLWNDPROC].nType = WH_CALLWNDPROC;
	wbhookdata[H_CALLWNDPROC].uiHookMsgID = ::RegisterWindowMessage(UWM_CALLWND_HOOKPROC_MSG);

	wbhookdata[H_CBT].bHookInstalled = FALSE;
	wbhookdata[H_CBT].hhook = NULL;
	wbhookdata[H_CBT].hkprc = (HOOKPROC)CBTProc;
	wbhookdata[H_CBT].hwndTarget = NULL;
	wbhookdata[H_CBT].nType = WH_CBT;
	wbhookdata[H_CBT].uiHookMsgID = ::RegisterWindowMessage(UWM_CBT_HOOKPROC_MSG);

	wbhookdata[H_GETMESSAGE].bHookInstalled = FALSE;
	wbhookdata[H_GETMESSAGE].hhook = NULL;
	wbhookdata[H_GETMESSAGE].hkprc = (HOOKPROC)GetMsgProc;
	wbhookdata[H_GETMESSAGE].hwndTarget = NULL;
	wbhookdata[H_GETMESSAGE].nType = WH_GETMESSAGE;
	wbhookdata[H_GETMESSAGE].uiHookMsgID = ::RegisterWindowMessage(UWM_GETMSG_HOOKPROC_MSG);

	wbhookdata[H_KEYBOARD].bHookInstalled = FALSE;
	wbhookdata[H_KEYBOARD].hhook = NULL;
	wbhookdata[H_KEYBOARD].hkprc = (HOOKPROC)KeyboardProc;
	wbhookdata[H_KEYBOARD].hwndTarget = NULL;
	wbhookdata[H_KEYBOARD].nType = WH_KEYBOARD;
	wbhookdata[H_KEYBOARD].uiHookMsgID = ::RegisterWindowMessage(UWM_KEYBOARD_HOOKPROC_MSG);

	wbhookdata[H_MOUSE].bHookInstalled = FALSE;
	wbhookdata[H_MOUSE].hhook = NULL;
	wbhookdata[H_MOUSE].hkprc = (HOOKPROC)MouseProc;
	wbhookdata[H_MOUSE].hwndTarget = NULL;
	wbhookdata[H_MOUSE].nType = WH_MOUSE;
	wbhookdata[H_MOUSE].uiHookMsgID = ::RegisterWindowMessage(UWM_MOUSE_HOOKPROC_MSG);

	wbhookdata[H_MSGFILTER].bHookInstalled = FALSE;
	wbhookdata[H_MSGFILTER].hhook = NULL;
	wbhookdata[H_MSGFILTER].hkprc = (HOOKPROC)MessageProc;
	wbhookdata[H_MSGFILTER].hwndTarget = NULL;
	wbhookdata[H_MSGFILTER].nType = WH_MSGFILTER;
	wbhookdata[H_MSGFILTER].uiHookMsgID = ::RegisterWindowMessage(UWM_MESSAGE_HOOKPROC_MSG);

	wbhookdata[H_KEYBOARD_LL].bHookInstalled = FALSE;
	wbhookdata[H_KEYBOARD_LL].hhook = NULL;
	wbhookdata[H_KEYBOARD_LL].hkprc = (HOOKPROC)LowLevelKeyboardProc;
	wbhookdata[H_KEYBOARD_LL].hwndTarget = NULL;
	wbhookdata[H_KEYBOARD_LL].nType = WH_KEYBOARD_LL;
	wbhookdata[H_KEYBOARD_LL].uiHookMsgID = ::RegisterWindowMessage(UWM_LOWLEVELKEYBOARD_HOOKPROC_MSG);

	wbhookdata[H_MOUSE_LL].bHookInstalled = FALSE;
	wbhookdata[H_MOUSE_LL].hhook = NULL;
	wbhookdata[H_MOUSE_LL].hkprc = (HOOKPROC)LowLevelMouseProc;
	wbhookdata[H_MOUSE_LL].hwndTarget = NULL;
	wbhookdata[H_MOUSE_LL].nType = WH_MOUSE_LL;
	wbhookdata[H_MOUSE_LL].uiHookMsgID = ::RegisterWindowMessage(UWM_LOWLEVELMOUSE_HOOKPROC_MSG);

	wbhookdata[H_FOREGROUNDIDLE].bHookInstalled = FALSE;
	wbhookdata[H_FOREGROUNDIDLE].hhook = NULL;
	wbhookdata[H_FOREGROUNDIDLE].hkprc = (HOOKPROC)ForegroundIdleProc;
	wbhookdata[H_FOREGROUNDIDLE].hwndTarget = NULL;
	wbhookdata[H_FOREGROUNDIDLE].nType = WH_FOREGROUNDIDLE;
	wbhookdata[H_FOREGROUNDIDLE].uiHookMsgID = ::RegisterWindowMessage(UWM_FORGROUNDIDLE_HOOKPROC_MSG);

	wbhookdata[H_CALLWNDPROCRET].bHookInstalled = FALSE;
	wbhookdata[H_CALLWNDPROCRET].hhook = NULL;
	wbhookdata[H_CALLWNDPROCRET].hkprc = (HOOKPROC)CallWndRetProc;
	wbhookdata[H_CALLWNDPROCRET].hwndTarget = NULL;
	wbhookdata[H_CALLWNDPROCRET].nType = WH_CALLWNDPROCRET;
	wbhookdata[H_CALLWNDPROCRET].uiHookMsgID = ::RegisterWindowMessage(UWM_CALLWNDRET_HOOKPROC_MSG);

	wbhookdata[H_SYSMSGFILTER].bHookInstalled = FALSE;
	wbhookdata[H_SYSMSGFILTER].hhook = NULL;
	wbhookdata[H_SYSMSGFILTER].hkprc = (HOOKPROC)SysMsgProc;
	wbhookdata[H_SYSMSGFILTER].hwndTarget = NULL;
	wbhookdata[H_SYSMSGFILTER].nType = WH_SYSMSGFILTER;
	wbhookdata[H_SYSMSGFILTER].uiHookMsgID = ::RegisterWindowMessage(UWM_SYSMSG_HOOKPROC_MSG);

	wbhookdata[H_SHELL].bHookInstalled = FALSE;
	wbhookdata[H_SHELL].hhook = NULL;
	wbhookdata[H_SHELL].hkprc = (HOOKPROC)ShellProc;
	wbhookdata[H_SHELL].hwndTarget = NULL;
	wbhookdata[H_SHELL].nType = WH_SHELL;
	wbhookdata[H_SHELL].uiHookMsgID = ::RegisterWindowMessage(UMW_SHELL_HOOKPROC_MSG);

}

CcsDLMan::~CcsDLMan()
{
	//Remove our instance
	//Otherwise, we will crash
	//Attempting to access a deleted object via an invalid ptr
	if(gCtrlInstances.GetSize() > 0)
	{
		LPVOID thisPtr = reinterpret_cast<LPVOID>(this);
		int i = gCtrlInstances.Find(thisPtr);
		if( i > -1)
		{
			gCtrlInstances[i] = NULL;
			gCtrlInstances.RemoveAt(i);
		}
	}

	int iSize = m_arrDL.GetSize();
	if(iSize > 0)
	{
		int i = 0;
		for(i = 0; i < iSize ; i++)
		{
			if( m_arrDL[i] )
			{
				m_arrDL[i] = NULL;
			}
		}
		m_arrDL.RemoveAll();
	}

	//Unhook?
	if(wbhookdata[H_CALLWNDPROC].hhook)
		UnhookWindowsHookEx(wbhookdata[H_CALLWNDPROC].hhook);
	if(wbhookdata[H_CBT].hhook)
		UnhookWindowsHookEx(wbhookdata[H_CBT].hhook);
	if(wbhookdata[H_GETMESSAGE].hhook)
		UnhookWindowsHookEx(wbhookdata[H_GETMESSAGE].hhook);
	if(wbhookdata[H_KEYBOARD].hhook)
		UnhookWindowsHookEx(wbhookdata[H_KEYBOARD].hhook);
	if(wbhookdata[H_MOUSE].hhook)
		UnhookWindowsHookEx(wbhookdata[H_MOUSE].hhook);
	if(wbhookdata[H_MSGFILTER].hhook)
		UnhookWindowsHookEx(wbhookdata[H_MSGFILTER].hhook);
	if(wbhookdata[H_KEYBOARD_LL].hhook)
		UnhookWindowsHookEx(wbhookdata[H_KEYBOARD_LL].hhook);
	if(wbhookdata[H_MOUSE_LL].hhook)
		UnhookWindowsHookEx(wbhookdata[H_MOUSE_LL].hhook);
	if(wbhookdata[H_FOREGROUNDIDLE].hhook)
		UnhookWindowsHookEx(wbhookdata[H_FOREGROUNDIDLE].hhook);
	if(wbhookdata[H_CALLWNDPROCRET].hhook)
		UnhookWindowsHookEx(wbhookdata[H_CALLWNDPROCRET].hhook);
	if(wbhookdata[H_SYSMSGFILTER].hhook)
		UnhookWindowsHookEx(wbhookdata[H_SYSMSGFILTER].hhook);
	if(wbhookdata[H_SHELL].hhook)
		UnhookWindowsHookEx(wbhookdata[H_SHELL].hhook);

	nCode_CBTProc = 0;
	nCode_MessageProc = 0;
	nCode_SysMsgProc = 0;
	nCode_ShellProc = 0;

}

STDMETHODIMP CcsDLMan::get_HTTPSprotocol(VARIANT_BOOL *pVal)
{
	*pVal = (gb_IsHttpsRegistered) ? VARIANT_TRUE : VARIANT_FALSE;
	return S_OK;
}

STDMETHODIMP CcsDLMan::put_HTTPSprotocol(VARIANT_BOOL newVal)
{
	if( (m_IEServerHwnd == NULL) || (!::IsWindow(m_IEServerHwnd)) )
		return AtlReportError(CLSID_csDLMan, _T("To send events to corresponding control, HWNDInternetExplorerServer property must be set."), IID_IcsDLMan,DISP_E_EXCEPTION);

	if( (newVal == VARIANT_TRUE) && (gb_IsHttpsRegistered == TRUE) )
	{
		return AtlReportError(CLSID_csDLMan, _T("HTTPS protocol is already registered."), IID_IcsDLMan,DISP_E_EXCEPTION);
	}
	
	//Get the current InternetSession
	CComPtr<IInternetSession> spSession;
	CoInternetGetSession(0, &spSession, 0);

	if(newVal == VARIANT_TRUE)
	{
		//Register
		MetaFactory::CreateInstance(CLSID_HttpSProtocol, &m_spCFHTTPS);
		spSession->RegisterNameSpace(m_spCFHTTPS, CLSID_NULL, L"https", 0, 0, 0);
		gb_IsHttpsRegistered = TRUE;
	}
	else
	{
		//Unregister
		spSession->UnregisterNameSpace(m_spCFHTTPS, L"https");
		m_spCFHTTPS.Release();
		gb_IsHttpsRegistered = FALSE;
	}
	return S_OK;
}

STDMETHODIMP CcsDLMan::get_HTTPprotocol(VARIANT_BOOL *pVal)
{
	*pVal = (gb_IsHttpRegistered) ? VARIANT_TRUE : VARIANT_FALSE;
	return S_OK;
}

STDMETHODIMP CcsDLMan::put_HTTPprotocol(VARIANT_BOOL newVal)
{
	if( (m_IEServerHwnd == NULL) || (!::IsWindow(m_IEServerHwnd)) )
		return AtlReportError(CLSID_csDLMan, _T("To send events to corresponding control, HWNDInternetExplorerServer property must be set."), IID_IcsDLMan,DISP_E_EXCEPTION);

	if( (newVal == VARIANT_TRUE) && (gb_IsHttpRegistered == TRUE) )
	{
		return AtlReportError(CLSID_csDLMan, _T("HTTP protocol is already registered."), IID_IcsDLMan,DISP_E_EXCEPTION);
	}
	
	//Get the current InternetSession
	CComPtr<IInternetSession> spSession;
	CoInternetGetSession(0, &spSession, 0);

	if(newVal == VARIANT_TRUE)
	{
		//Register
		MetaFactory::CreateInstance(CLSID_HttpProtocol, &m_spCFHTTP);
		spSession->RegisterNameSpace(m_spCFHTTP, CLSID_NULL, L"http", 0, 0, 0);
		gb_IsHttpRegistered = TRUE;
	}
	else
	{
		//Unregister
		spSession->UnregisterNameSpace(m_spCFHTTP, L"http");
		m_spCFHTTP.Release();
		gb_IsHttpRegistered = FALSE;
	}
	return S_OK;
}

STDMETHODIMP CcsDLMan::DownloadUrlAsync(BSTR URL, long *DLUID)
{
	CComPtr<IMoniker> pmk;
	CComPtr<IBindCtx> pbc;
	//CComPtr<IStream> pstm;
	IStream *pstm;
	HRESULT hr;


	if( (m_IEServerHwnd == NULL) || (!::IsWindow(m_IEServerHwnd)) )
		return AtlReportError(CLSID_csDLMan, _T("To send events to corresponding control, HWNDInternetExplorerServer property must be set."), IID_IcsDLMan,DISP_E_EXCEPTION);

	
	WBBSCBFileDL *pBSCB = new WBBSCBFileDL();
	if(!pBSCB)
	{
		return AtlReportError(CLSID_csDLMan, _T("Unable to create Download class."), IID_IcsDLMan,DISP_E_EXCEPTION);
	}

	//Pass uid to client to be used to cancel a dl
	m_Uid++;
	*DLUID = m_Uid;
	pBSCB->InitByClient(m_Uid, this, URL, m_IEServerHwnd);

	USES_CONVERSION;
	//Create URLMonikor
	//http://blogs.msdn.com/ie/archive/2006/09/13/752347.aspx
	hr = CreateURLMonikerEx(NULL, OLE2W(URL), &pmk, URL_MK_UNIFORM);
    //hr = CreateURLMoniker(NULL, OLE2W(URL), &pmk);
	if(FAILED(hr))
	{
		delete pBSCB;
		return AtlReportError(CLSID_csDLMan, _T("Unable to create URL Moniker."),IID_IcsDLMan,DISP_E_EXCEPTION);
	}
	
	//Create BindCtx and register BSCB at the same time, AddRef is called
    hr = CreateAsyncBindCtx(0, pBSCB, NULL, &pbc);
	if(FAILED(hr))
	{
		delete pBSCB;
		if(pmk) pmk.Release();
		return AtlReportError(CLSID_csDLMan, _T("Unable to create AsyncBindCtx."),IID_IcsDLMan,DISP_E_EXCEPTION);
	}
	
	//Bind stream to storage
	hr = pmk->BindToStorage(pbc,NULL,IID_IStream,(void**)&pstm);
	if(FAILED(hr))
	{
		if(pbc) pbc.Release();
		delete pBSCB;
		if(pmk) pmk.Release();
		return AtlReportError(CLSID_csDLMan, _T("BindToStorage failed."),IID_IcsDLMan,DISP_E_EXCEPTION);
	}
	//Add to Ptrarray
	m_arrDL.Add(pBSCB);
	return S_OK;
}

STDMETHODIMP CcsDLMan::Download(IMoniker *pmk,IBindCtx *pbc,DWORD dwBindVerb,
									LONG grfBINDF,
									BINDINFO *pBindInfo,
									LPCOLESTR pszHeaders,
									LPCOLESTR pszRedir,
									UINT uiCP)
{
	HRESULT hr;
	//Stream will be released in the BSCB OnDataArrival
	IStream *pstm;

	//Attempt to create our BindStatusCallBack
	WBBSCBFileDL *filedl = NULL;
	//Returns a NonAddRef pointer to a new BSCB
	//AddRef is called on this BSCB during a successfull call
	//to RegisterBindStatusCallback
	if(WBCreateBSCBFileDL(&filedl) != S_OK)
	{
		return E_FAIL;
	}
	//Init the BSCB
	m_Uid++;
	filedl->InitByUser(m_Uid, this, pszHeaders, m_IEServerHwnd);
	
	IBindStatusCallback *pPrevBSCB = NULL;
	hr = RegisterBindStatusCallback(pbc, 
			reinterpret_cast<IBindStatusCallback*>(filedl), &pPrevBSCB, 0L);
	/*
		Exception to the rule
		RegisterBindStatusCallback return E_FAIL
		Cause: Content_Disposition header returned from a server
		in response to a file download via a post or ,..
		Example: downloading attachements from Hotmail, Yahoo, ...

Unfortunately, due to no documentation regarding an E_FAIL return,
and more specifically, regarding RegisterBindStatusCallback internal workings,
I had to resort to using RevokeObjectParam on the previous BSCB and in my
implementation of BSCB, relay certain calls to the previous BSCB to make DL work.
I do not know if this is a bug or done intentionaly.
	*/

	/*
	KB article http://support.microsoft.com/default.aspx?scid=kb;en-us;274201
	Notifies the client application that this resource contained a
	Content-Disposition header that indicates that this resource is an attachment.
	The content of this resource should not be automatically displayed.
	Client applications should request permission from the user.
	This value was added for Internet Explorer 5. 
	*/

	if( (FAILED(hr)) && (pPrevBSCB) )
	{
		//RevokeObjectParam for current BSCB, so we can register our BSCB
		LPOLESTR oParam = L"_BSCB_Holder_";
		hr = pbc->RevokeObjectParam(oParam);
		if(SUCCEEDED(hr))
		{
			//Attempt register again, should succeed now
			hr = RegisterBindStatusCallback(pbc, 
					reinterpret_cast<IBindStatusCallback*>(filedl), 0, 0L);
			if(SUCCEEDED(hr))
			{
				filedl->m_pPrevBSCB = pPrevBSCB;
				//Need to add ref to our DLMan
				filedl->AddRef();
				pPrevBSCB->AddRef();
				filedl->m_pBindCtx = pbc;
				pbc->AddRef();
			}
		}
	}

	if(SUCCEEDED(hr))
	{
		this->m_arrDL.Add(filedl);
		hr = pmk->BindToStorage(pbc, 0, IID_IStream, (void**)&pstm);
	}
	else
	{
		delete filedl;
	}
	return hr;
}

HRESULT CcsDLMan::WBCreateBSCBFileDL(WBBSCBFileDL **ppTargetBSCBFileDL)
{
	if(ppTargetBSCBFileDL == NULL) return E_INVALIDARG;

	*ppTargetBSCBFileDL = new WBBSCBFileDL();
	if(*ppTargetBSCBFileDL == NULL)
		return E_OUTOFMEMORY;
	return S_OK;
}

//This has to be set first and passed to ever BSCB for verification
//before sending events, just in case client was deleted.
STDMETHODIMP CcsDLMan::get_HWNDInternetExplorerServer(long *pVal)
{
	*pVal = (long)m_IEServerHwnd;
	return S_OK;
}

STDMETHODIMP CcsDLMan::put_HWNDInternetExplorerServer(long newVal)
{
	m_IEServerHwnd = (HWND)newVal;
	if( (m_IEServerHwnd == NULL) || (!::IsWindow(m_IEServerHwnd)) )
		return AtlReportError(CLSID_csDLMan, _T("IE Server HWND must be a valid window!."), IID_IcsDLMan,DISP_E_EXCEPTION);
	return S_OK;
}

BOOL CcsDLMan::RemoveBSCBFromDLArr(long Uid)
{
	int iSize = m_arrDL.GetSize();
	if(iSize > 0)
	{
		int i = 0;
		for(i = 0; i < iSize ; i++)
		{
			if( (m_arrDL[i]) && (m_arrDL[i]->m_Uid == Uid) )
			{
				m_arrDL[i] = NULL;
				m_arrDL.RemoveAt(i);
				return TRUE;
			}
		}
	}
	return FALSE;
}

HRESULT CcsDLMan::CancelFileDl(long Uid)
{
	int isize = m_arrDL.GetSize();
	if(isize > 0)
	{
		int i = 0;
		for(i = 0; i < isize ; i++)
		{
			if( (m_arrDL[i]) && 
				(m_arrDL[i]->m_Uid == Uid) && 
				(m_arrDL[i]->IsDownloading() == true) )
			{
				//This should trigger a stop binding
				//which should notify the client
				m_arrDL[i]->CancelDL();
			}
		}
	}
	return S_OK;
}

STDMETHODIMP CcsDLMan::CancelFileDownload(long DlUid)
{
	if(CancelFileDl(DlUid) != S_OK)
		return AtlReportError(CLSID_csDLMan, _T("Unable to cancel file download."), IID_IcsDLMan,DISP_E_EXCEPTION);
	return S_OK;
}


STDMETHODIMP CcsDLMan::HookProcNCode(WINDOWSHOOK_TYPES lHookType, long *nCode)
{
	if(lHookType == WHT_CBT)
	{
		*nCode = (long)nCode_CBTProc;
	}
	else if(lHookType == WHT_MSGFILTER)
	{
		*nCode = (long)nCode_MessageProc;
	}
	else if(lHookType == WHT_SYSMSGFILTER)
	{
		*nCode = (long)nCode_SysMsgProc;
	}
	else
		*nCode = -1;
	return S_OK;
}

//lUWMHookMsgID is our own registered messageid which is passed along
//SendMessageTimeout to the client app so they can intercept the hook callback
STDMETHODIMP CcsDLMan::SetupWindowsHook(WINDOWSHOOK_TYPES lHookType, long hwndTargetWnd, VARIANT_BOOL bStart, long *lUWMHookMsgID)
{
	BOOL bInstall = VARIANTBOOLTOBOOL(bStart);
	
	if( (bInstall == TRUE) && (wbhookdata[lHookType].bHookInstalled == FALSE) )
	{
		if(hwndTargetWnd == 0)
			return AtlReportError(CLSID_csDLMan, _T("Windows Hook requires a valid window handle!") ,IID_IcsDLMan,DISP_E_EXCEPTION);
		else
			wbhookdata[lHookType].hwndTarget = (HWND)hwndTargetWnd;

		wbhookdata[lHookType].hhook = SetWindowsHookEx( wbhookdata[lHookType].nType, 
			wbhookdata[lHookType].hkprc, 
			//_Module.GetModuleInstance(), GetCurrentThreadId());
			_Module.GetModuleInstance(), 0);
			//(HINSTANCE) NULL, GetCurrentThreadId());
		//Check and send back hook msgid for the client to intercept
		if(wbhookdata[lHookType].hhook)
		{
			*lUWMHookMsgID = (long)wbhookdata[lHookType].uiHookMsgID;
			wbhookdata[lHookType].bHookInstalled = bInstall;
		}
		else
		{
			return AtlReportError(CLSID_csDLMan, _T("Failed to install Hook!") ,IID_IcsDLMan,DISP_E_EXCEPTION);
		}
	}
	else if( (bInstall == FALSE) && (wbhookdata[lHookType].bHookInstalled == TRUE) )
	{
		if(wbhookdata[lHookType].hhook)
			UnhookWindowsHookEx(wbhookdata[lHookType].hhook);
		wbhookdata[lHookType].bHookInstalled = bInstall;
		wbhookdata[lHookType].hwndTarget = NULL;
	}

	return S_OK;
}

/////////////////////////////////////////////////////////////////////
//WBBSCBFileDL
/////////////////////////////////////////////////////////////////////

//Constructor
WBBSCBFileDL::WBBSCBFileDL()
{
	ResetInternalVars();
}

WBBSCBFileDL::~WBBSCBFileDL()
{
	if(hFile != INVALID_HANDLE_VALUE)
	{
		CloseHandle(hFile);
	}
}

//Urlmon.dll uses the QueryInterface method on your implementation of
//IBindStatusCallback to obtain a pointer to your IHttpNegotiate interface.
//Only if we have initiated the download from code by creating own Moniker
STDMETHODIMP WBBSCBFileDL::QueryInterface(REFIID iid, void ** ppvObject)
{
	if(ppvObject == NULL) return E_INVALIDARG;
	*ppvObject = NULL;

	if( (iid==IID_IBindStatusCallback) || (iid==IID_IUnknown) )
	{
       *ppvObject = (IBindStatusCallback*)this;
	}
	else if ( iid == IID_IHttpNegotiate )
	{
		*ppvObject = (IHttpNegotiate*)this;
	}
	else if(iid == IID_IAuthenticate)
	{
		*ppvObject = (IAuthenticate*)this;
	}

	if (NULL != *ppvObject)
	{
        AddRef();
        return S_OK;
    }

//	{
//	OLECHAR wszBuff[39];
//	int i = StringFromGUID2(iid, wszBuff, 39);
//	TCHAR szBuff[39];
//	i = WideCharToMultiByte(CP_ACP, 0, wszBuff, -1, szBuff, 39, NULL, NULL);
//	vbLog((LPCTSTR)szBuff,_T("WBBSCBFileDL::QueryInterface"));
//	}

	return E_NOINTERFACE;
}

ULONG STDMETHODCALLTYPE WBBSCBFileDL::AddRef()
{
	return ++m_cRef;
}

ULONG STDMETHODCALLTYPE WBBSCBFileDL::Release()
{
	if(--m_cRef == 0)
	{
        delete this;
		return 0;
	}
	return m_cRef;
}

void WBBSCBFileDL::ResetInternalVars(void)
{
	m_cRef = 0;
	m_Uid = 0;
	m_pPrevBSCB = NULL;
	m_pBindCtx = NULL;

	m_vboolCancelDL = VARIANT_FALSE;
	m_bCancelled = FALSE;

	m_fRedirect = FALSE;
	m_pBinding = NULL;
	m_pstm = NULL;
	m_cbOld = 0;
	hFile = INVALID_HANDLE_VALUE;

	m_Events = NULL;
	m_hwndEvents = NULL;
	m_SendProgressEvent = VARIANT_TRUE;
	m_strRedirectedURL = L"";
	m_vboolResuming = VARIANT_FALSE;
	m_hwndClient = NULL;
}

//This is used when client app initiates the dl
//In this case OnResponse and BeginningTransaction are called
//Here we we can resume a broken dl using OnResponse, by sending additional headers
bool WBBSCBFileDL::InitByClient(long uID, CcsDLMan *EventsPtr, BSTR lpUrl, HWND client)
{
	m_Uid = uID;
	m_Events = EventsPtr;
	fUrl = lpUrl;
	m_hwndClient = client;

	return true;
}

//This is used when client initiates dl, clicking on a dl link
//In this case OnResponse and BeginningTransaction are never called.
//WB queries our service provider for a download manager interface and calls download method
//in which case we create an instance of this class and set up dl
bool WBBSCBFileDL::InitByUser(long uID, CcsDLMan *pHost, LPCOLESTR UrlMonExtraHeaders, HWND client)
{
	if(UrlMonExtraHeaders)
		m_strDLManExtraHeaders = UrlMonExtraHeaders;
	m_Events = pHost;
	m_Uid = uID;
	m_hwndClient = client;

	return true;
}


//IAuthenticate
STDMETHODIMP WBBSCBFileDL::Authenticate(HWND *phwnd, LPWSTR *pszUsername, LPWSTR *pszPassword)
{
	if (!phwnd || !pszUsername || !pszPassword)
	{
	  return E_INVALIDARG;
	}

	*phwnd = NULL;
	*pszUsername = NULL;
	*pszPassword = NULL;
	CComBSTR strUsername(L"");
	CComBSTR strPassword(L"");
	//Default, do not cancel
	VARIANT_BOOL bCancel = VARIANT_TRUE;
	//Fire event to obtain Uname+Password
	if( (m_hwndClient != NULL) && (::IsWindow(m_hwndClient)) )
		m_Events->Fire_OnFileDLAuthenticate(m_Uid, &strUsername, &strPassword, &bCancel);
	//Cancelled, bail
	if(bCancel == VARIANT_TRUE)
		return E_ACCESSDENIED;
	//allocate mem
	WCHAR *wszUsername =  (WCHAR *)CoTaskMemAlloc((strUsername.Length()+1) *sizeof(WCHAR));
	if(!wszUsername)
	{
		return E_OUTOFMEMORY;
	}
	WCHAR *wszPassword =  (WCHAR *)CoTaskMemAlloc((strPassword.Length()+1) *sizeof(WCHAR));
	if(!wszPassword)
	{
		return E_OUTOFMEMORY;
	}
	USES_CONVERSION;
	//Copy
	wcscpy(wszUsername, strUsername.m_str);  //OLE2W(strUsername));
	wszUsername[strUsername.Length()] = (WCHAR)NULL;
	wcscpy(wszPassword, strPassword.m_str);  //OLE2W(strPassword));
	wszPassword[strPassword.Length()] = (WCHAR)NULL;
	//Assign to out params
	*pszUsername = wszUsername;
	*pszPassword = wszPassword;
	return S_OK;
}

//IBindStatusCallback
STDMETHODIMP WBBSCBFileDL::OnStartBinding(DWORD dwReserved, IBinding * pib)
{
	//Although, MSDN, states that simply returning E_FAIL should stop the DL. But as ususal
	//it does not work as documented. Well, returnning E_FAIL will not stop the save as dlg
	//from poping up. Releasing IBinding and returning E_FAIL does the trick.
	//Cache the URLMON-provided IBinding interface so that we can control the download,
	if(m_pBinding)
		m_pBinding->Release();
	m_pBinding = pib;
	if(m_pBinding)
	{
		m_pBinding->AddRef();
	}

	if(m_pPrevBSCB)
	{
		m_pPrevBSCB->OnStopBinding(HTTP_STATUS_OK, NULL);
	}

	return S_OK;
}

STDMETHODIMP WBBSCBFileDL::GetPriority(LONG * pnPriority)
{
	return E_NOTIMPL;
}

STDMETHODIMP WBBSCBFileDL::OnLowResource(DWORD reserved)
{
	return E_NOTIMPL;
}

STDMETHODIMP WBBSCBFileDL::OnProgress(ULONG ulProgress, ULONG ulProgressMax, ULONG ulStatusCode, LPCWSTR szStatusText)
{ 
	USES_CONVERSION;
	//Default = Continue download
	m_vboolCancelDL = VARIANT_FALSE;
	
	//After this call we get OnDataArrival
	//Notify client and set internal vars up
	if( ulStatusCode == BINDSTATUS_BEGINDOWNLOADDATA)
	{

		//Get the URL resource display name and extract filename + extension
		CUrlParts parts;
		fFullSavePath.Empty();
		fFileName.Empty();
		fFileExt.Empty();
		fFileSize.Empty();
		fUrl.Empty();

		fUrl = szStatusText;
		
//HTTP_QUERY_CONTENT_TYPE (text/html)
//HTTP_QUERY_CONTENT_LENGTH
//HTTP_QUERY_RAW_HEADERS_CRLF
		CComBSTR m_bstrResponseHeaders;

		if(m_pBinding)
		{
			//Get raw request headers and send them to client
			CComPtr<IWinInetHttpInfo> spWinInetHttpInfo;
			CComPtr<IBinding> pBinding = m_pBinding;
			HRESULT hrTemp = pBinding->QueryInterface(IID_IWinInetHttpInfo,
				(void**)&spWinInetHttpInfo);
			if( (SUCCEEDED(hrTemp)) && (spWinInetHttpInfo) )
			{
				DWORD size = 0; //sizeof(DWORD)
				DWORD flags = 0;
				//Get all headers
				hrTemp = spWinInetHttpInfo->QueryInfo( HTTP_QUERY_RAW_HEADERS_CRLF,
					0, &size, &flags, 0);
				if(SUCCEEDED(hrTemp) && (size > 0))
				{
					LPSTR pbuf = new char[size+1];
					if(pbuf)
					{
						pbuf[size] = '\0';
						hrTemp = spWinInetHttpInfo->QueryInfo( HTTP_QUERY_RAW_HEADERS_CRLF,
							pbuf, &size, &flags, 0);
						if( (SUCCEEDED(hrTemp)) && (pbuf[0] != '\0') )
						{
							//pbuf should contain all request headers
							m_bstrResponseHeaders.Append(pbuf);
						}
						delete[] pbuf;
					}
				}

				size = 0;
				flags = 0;
				//Get the filesize, if content-length header is provided by server | HTTP_QUERY_FLAG_NUMBER
				hrTemp = spWinInetHttpInfo->QueryInfo( HTTP_QUERY_CONTENT_LENGTH,
					0, &size, &flags, 0);
				if(SUCCEEDED(hrTemp) && (size > 0))
				{
					LPSTR pbuf = new char[size+1];
					if(pbuf)
					{
						pbuf[size] = '\0';
						hrTemp = spWinInetHttpInfo->QueryInfo( HTTP_QUERY_CONTENT_LENGTH,
							pbuf, &size, &flags, 0);
						if( (SUCCEEDED(hrTemp)) && (pbuf[0] != '\0') )
						{
							//pbuf should contain size in bytes. i.e. 24955
							fFileSize.Append(pbuf);
						}
						delete[] pbuf;
					}
				}

				//Grab the Content_Disposition header to get the filename
				//Content-Disposition: attachment; filename="Somefile.zip"
				if(m_pPrevBSCB)
				{
					size = 0;
					flags = 0;
					hrTemp = spWinInetHttpInfo->QueryInfo( HTTP_QUERY_CONTENT_DISPOSITION,
						0, &size, &flags, 0);
					if(SUCCEEDED(hrTemp) && (size > 0))
					{
						LPSTR pbuf = new char[size+1];
						if(pbuf)
						{
							pbuf[size] = '\0';
							hrTemp = spWinInetHttpInfo->QueryInfo( HTTP_QUERY_CONTENT_DISPOSITION,
								pbuf, &size, &flags, 0);
							if( (SUCCEEDED(hrTemp)) && (pbuf[0] != '\0') )
							{
								int i = size - 2;
								CTmpBuffer final(size);
								while ( ( i > -1 ) && (pbuf[i] != '"') )
								{
									if(pbuf[i] == '.')
									{
										LPSTR pext = &pbuf[i];
										final.Append(pext, size - (i+1));
										fFileExt.Append(final);
									}
									--i;
								}
								if( i > 0 )
								{
									LPSTR pname = &pbuf[i+1]; //="
									final.ResetBuffer();
									final.Append(pname, size - (i+2));
									fFileName.Append(final);
								}
							}
							delete[] pbuf;
						}
					}
				}


			} //No wininet
		}//No binding

		//Get file name and extension, if empty
		if(fFileName.Length() == 0)
		{
			if(parts.SplitUrl(fUrl) == true)
			{
				if(parts.GetFileNameLen() > 0)
				{
					fFileName = parts.GetFileNameAsBSTR();
				}
				if(parts.GetFileExtensionLen() > 0)
				{
					fFileExt =  parts.GetFileExtensionAsBSTR(); 
				}
			}
			parts.ResetBuffers();
		}

		//Final checks, if failed, set to default
		if(fFileName.Length() == 0)
			fFileName = L"";
		if(fFileExt.Length() == 0)
			fFileExt = L"";
		if(fFileSize.Length() == 0)
			fFileSize = L"0";
		if(m_strRedirectedURL.Length() == 0)
			m_strRedirectedURL = L"";
		if(m_bstrResponseHeaders.Length() == 0)
			m_bstrResponseHeaders = L"";

		fPathToSave = L"";

		if( (m_hwndClient != NULL) && (::IsWindow(m_hwndClient)) )
		{
			//Extra headers + redirect
			m_Events->Fire_FileDownloadEx(m_Uid, fUrl,
									fFileName, fFileExt, fFileSize,
									m_bstrResponseHeaders, 
									m_strRedirectedURL,
									&m_SendProgressEvent,
									&m_vboolCancelDL,
									&fPathToSave);
			//fPathToSave would be a path/filename.ext

			//Cancel?
			if(m_vboolCancelDL == VARIANT_TRUE)
			{
				CancelDL();
				return S_OK;
			}
		}
		//Set up fullpath for download
		if(fPathToSave.Length() > 0)
		{
			fFullSavePath = fPathToSave;		
		}
		else
		{
			if(fFileName.Length() > 0)
				fFullSavePath = fFileName; //Save in the same dir as client exe
			else
				fFullSavePath = L"UNKNOWN"; //Desparate???
		}
	}
	else if( ulStatusCode == BINDSTATUS_REDIRECTING)
	{
		m_fRedirect = TRUE;
		m_strRedirectedURL.Empty();
		m_strRedirectedURL.AppendBSTR(W2BSTR(szStatusText));
	}
	else if( (ulStatusCode == BINDSTATUS_DOWNLOADINGDATA) &&
			(m_SendProgressEvent == VARIANT_TRUE) && 
			(m_hwndClient != NULL) && (::IsWindow(m_hwndClient)) )
	{
		long lprogress = static_cast<long>(ulProgress);
		long lprogressmax = static_cast<long>(ulProgressMax);
		m_Events->Fire_OnFileDLProgress(m_Uid, fUrl, 
								lprogress, 
								lprogressmax, 
								&m_vboolCancelDL);
	}
	else if( (ulStatusCode == BINDSTATUS_ENDDOWNLOADDATA) &&
		(m_hwndClient != NULL) && (::IsWindow(m_hwndClient)) )
	{
		m_Events->Fire_OnFileDLEndDownload(m_Uid, fUrl, fFullSavePath);
	}

	//else, pass to previous BSCB coming from IDownloadManager::Download
	if(m_pPrevBSCB)
	{
		//Need to do this otherwise a filedownload dlg wil be displayed
		//as we are downloading the file.
		//Interestingly, according to MSDN, 
		//BINDSTATUS_CONTENTDISPOSITIONATTACH is declared obsolete????
		if(ulStatusCode == BINDSTATUS_CONTENTDISPOSITIONATTACH)
			return S_OK;
		m_pPrevBSCB->OnProgress(ulProgress, ulProgressMax, ulStatusCode, szStatusText);
	}

	if(m_vboolCancelDL == VARIANT_TRUE)
	{
		CancelDL();
	}

	return S_OK;

//Other status codes which may or may not fire
//depending on whatever MS feels like....
//  case BINDSTATUS_SENDINGREQUEST:
//  case BINDSTATUS_CONNECTING:
//  case BINDSTATUS_USINGCACHEDCOPY:
//  case BINDSTATUS_CACHEFILENAMEAVAILABLE:
//	case BINDSTATUS_FINDINGRESOURCE:;
//	case BINDSTATUS_BEGINDOWNLOADCOMPONENTS:
//	case BINDSTATUS_INSTALLINGCOMPONENTS:
//	case BINDSTATUS_ENDDOWNLOADCOMPONENTS:
//	case BINDSTATUS_CLASSIDAVAILABLE:
//	case BINDSTATUS_MIMETYPEAVAILABLE:
//..............
}

//This function is called regardless of success or failer in dl
STDMETHODIMP WBBSCBFileDL::OnStopBinding(HRESULT hresult,LPCWSTR szError)
{

	if(m_pBinding)
	{
		m_pBinding->Release();
		m_pBinding = NULL;
	}

	//Notify the client that we are done
	//If client has not cancelled during actual dl via OnProgress
	if( (m_hwndClient != NULL) && (::IsWindow(m_hwndClient)) )
	{
		if((hresult) && (szError))
		{
//One of
//INET_E_INVALID_URL
//INET_E_RESOURCE_NOT_FOUND
//.....
			USES_CONVERSION;
			CTmpBuffer buff(MAX_PATH);
			buff += W2CT(szError);
			buff += _T(" Error Number = ");

			buff.Appendlong(static_cast<long>(hresult));
			CComBSTR sMsg;
			sMsg.Append(buff);
			m_Events->Fire_OnFileDLDownloadError(m_Uid, fUrl, sMsg);
		}
		else if(m_bCancelled == TRUE) //set to true in CancelDL method
		{
			//Cancelled by client or errors in OnDataAvailable method
			m_Events->Fire_OnFileDLEndDownload(m_Uid, fUrl, fFullSavePath);
		}
		m_Events->RemoveBSCBFromDLArr(m_Uid);
	}

	if( (m_pPrevBSCB) && (m_pBindCtx) )
	{
		//Register PrevBSCB and release our pointers
		LPOLESTR oParam = L"_BSCB_Holder_";
		m_pBindCtx->RegisterObjectParam(oParam, 
					reinterpret_cast<IUnknown*>(m_pPrevBSCB));
		m_pPrevBSCB->Release();
		m_pPrevBSCB = NULL;
		m_pBindCtx->Release();
		m_pBindCtx = NULL;
		//Decrease our ref count, so when release is called
		//we delete this object
		--m_cRef;
	}
	//URLmon.dll will call release on this object, so says MSDN
	return S_OK;
}

STDMETHODIMP WBBSCBFileDL::GetBindInfo(DWORD *grfBINDF, BINDINFO * pbindinfo)
{
	if (pbindinfo==NULL || pbindinfo->cbSize==0 || grfBINDF==NULL)
		return E_INVALIDARG;

	//Set up bind flags
	*grfBINDF = BINDF_ASYNCHRONOUS | BINDF_ASYNCSTORAGE | BINDF_PULLDATA | BINDF_GETNEWESTVERSION | BINDF_NOWRITECACHE;
	//*grfBINDF |= BINDF_IGNORESECURITYPROBLEM;

	// Set up the BINDINFO data structure
//	pbindinfo->cbSize = sizeof(BINDINFO);

	//Clear and setup
	DWORD cbSize = pbindinfo->cbSize = sizeof(BINDINFO);
	memset(pbindinfo,0,cbSize);
	pbindinfo->cbSize = cbSize;

//BINDVERB_GET,
//BINDVERB_POST,
//BINDVERB_PUT,
//BINDVERB_CUSTOM
	pbindinfo->dwBindVerb = BINDVERB_GET;
	pbindinfo->szExtraInfo = NULL;

	//The stgmedData member of the BINDINFO structure should be set 
	//to TYMED_NULL for the GET operation.
	memset(&pbindinfo->stgmedData, 0, TYMED_NULL);

//BINDINFOF_URLENCODESTGMEDDATA = 0
//BINDINFOF_URLENCODEDEXTRAINFO = 1
	pbindinfo->grfBindInfoF = 0;
//BSTR specifying a protocol-specific custom action to be performed
//during the bind operation (only if dwBindVerb is set to BINDVERB_CUSTOM)
	pbindinfo->szCustomVerb = NULL;
//Reserved. Must be set to 0
	pbindinfo->dwOptions = 0;
	pbindinfo->dwOptionsFlags = 0;
	pbindinfo->dwReserved = 0;

	return S_OK;
}

STDMETHODIMP WBBSCBFileDL::OnDataAvailable(DWORD grfBSCF, DWORD dwSize, FORMATETC* pformatetc, STGMEDIUM* pstgmed)
{
	HRESULT hr = S_OK;
	
	//First call here
    if (BSCF_FIRSTDATANOTIFICATION & grfBSCF)
    {
		// Cache the incoming Stream
        if (m_pstm == NULL &&  pstgmed->tymed == TYMED_ISTREAM)
	    {
			//Get a local copy of the stream
			m_pstm = pstgmed->pstm;
			if (m_pstm)
			{
				m_pstm->AddRef();
				if(fFullSavePath.Length() > 0)
				{
					USES_CONVERSION;
					hFile = CreateFile(OLE2T(fFullSavePath), GENERIC_WRITE, 0, NULL,
										OPEN_ALWAYS, FILE_ATTRIBUTE_NORMAL, NULL);
					if(hFile == INVALID_HANDLE_VALUE)
					{
						goto Error;
					}
					
					if(m_vboolResuming == VARIANT_TRUE)
					{
						//Move pointer to the end of file, if we have anything
						//#define INVALID_SET_FILE_POINTER ((DWORD)-1)
						if (SetFilePointer(hFile, 0, NULL, FILE_END) == ((DWORD)-1))
						{
							goto Error;
						}
					}

				}
				else
				{
					goto Error;
				}
			}
    	}
    }

    // If there is some data to be read then go ahead and read it
    if (m_pstm && dwSize > m_cbOld)
	{
        DWORD dwRead = dwSize - m_cbOld; // Minimum amount available that hasn't been read
        DWORD dwActuallyRead = 0;            // Placeholder for amount read during this pull
		DWORD dwWritten = 0; //WriteFile

		if (dwRead > 0)
		do
		{
	        //BYTE* pBytes = NULL;
			//pBytes = new BYTE[dwRead + 1]);
			//if(pBytes == NULL) goto Error;

			//Servers serve non Unicode content
			LPSTR pNewstr = new char[dwRead + 1];
			if (!pNewstr)
			{
				//E_OUTOFMEMORY
				//vbLog(_T("E_OUTOFMEMORY"),_T("WBBSCBFileDL::OnDataAvailable"));
				goto Error;
			}

			//hr= m_pstm->Read(pBytes, dwRead, &dwActuallyRead);
			hr = m_pstm->Read(pNewstr, dwRead, &dwActuallyRead);
			//pBytes[dwActuallyRead] = 0;
			pNewstr[dwActuallyRead] = '\0';
			// If we really read something then lets write it to file
			if (dwActuallyRead > 0)
			{
				m_cbOld += dwActuallyRead;
				//WriteFile(hFile, pBytes, dwActuallyRead, &dwWritten, NULL);
				WriteFile(hFile, pNewstr, dwActuallyRead, &dwWritten, NULL);
			}

			//delete[] pBytes;
			delete[] pNewstr;

		} while (!(hr == E_PENDING || hr == S_FALSE) && SUCCEEDED(hr));
	}

	// Clean up
	if (BSCF_LASTDATANOTIFICATION & grfBSCF)
	{
        if (m_pstm)
		{
            m_pstm->Release();
			m_pstm = NULL;
			if(hFile != INVALID_HANDLE_VALUE)
			{
				CloseHandle(hFile);
				hFile = INVALID_HANDLE_VALUE;
			}
		}
		hr = S_OK;  // If it was the last data then we should return S_OK as we just finished reading everything
	}

	return hr;

Error:
	//Just cancel
	//We will notify client in OnStopBinding, since hresult
	//will have a value
	CancelDL();
	return S_FALSE;
}

STDMETHODIMP WBBSCBFileDL::OnObjectAvailable(REFIID riid,IUnknown* punk)
{
	return E_NOTIMPL;
}

STDMETHODIMP WBBSCBFileDL::BeginningTransaction(
												LPCWSTR szURL,
                								LPCWSTR szHeaders,
                								DWORD dwReserved,
                								LPWSTR *pszAdditionalHeaders)
{
	// Here's our opportunity to add headers
	if (!pszAdditionalHeaders)
	{
		return E_POINTER;
	}
	*pszAdditionalHeaders = NULL;

	USES_CONVERSION;

	m_vboolResuming = VARIANT_FALSE;
	m_vboolCancelDL = VARIANT_FALSE;

	CComBSTR sAddClientHeaders(L"");
	CComBSTR sHeaders;

	fUrl.Empty();
	fUrl = szURL;

	if(szHeaders)
		sHeaders = szHeaders;
	else
		sHeaders = L"";

	//
	//Fire the event
	if( (m_hwndClient != NULL) && (::IsWindow(m_hwndClient)) )
	{
		m_Events->Fire_OnFileDLBeginningTransaction(
												m_Uid, 
												fUrl, 
												sHeaders, 
												&sAddClientHeaders,
												&m_vboolResuming, 
												&m_vboolCancelDL);
		if(m_vboolCancelDL == VARIANT_TRUE)
			CancelDL();
	}
	//See if we were send extra headers from IDownloadManager::Download method
	if(m_strDLManExtraHeaders.Length() > 0)
	{
		sAddClientHeaders += m_strDLManExtraHeaders;
	}

	//Add additional headers
	if(sAddClientHeaders.Length() > 0)
	{
		//Set additional headers
		LPWSTR wszAdditionalHeaders = 
			(LPWSTR)CoTaskMemAlloc((sAddClientHeaders.Length()+1) *sizeof(WCHAR));
		if (wszAdditionalHeaders)
		{
			//Copy
			wcscpy(wszAdditionalHeaders, OLE2W(sAddClientHeaders));
			wszAdditionalHeaders[sAddClientHeaders.Length()] = (WCHAR)NULL;
			//Give URLmon a handle to our header
			*pszAdditionalHeaders = wszAdditionalHeaders;
		}
	}

	return S_OK;
}

STDMETHODIMP WBBSCBFileDL::OnResponse(
                DWORD dwResponseCode,
                LPCWSTR szResponseHeaders,
                LPCWSTR szRequestHeaders,
                LPWSTR *pszAdditionalRequestHeaders)
{
	if (!pszAdditionalRequestHeaders)
	{
		return E_POINTER;
	}
	*pszAdditionalRequestHeaders = NULL;

	if( (m_hwndClient != NULL) && (::IsWindow(m_hwndClient)) )
	{
		USES_CONVERSION;
		CTmpBuffer buff(MAX_PATH*2);
		buff = W2CT(szResponseHeaders);
		if (szRequestHeaders)
		{
			//buff += _T("(Repeat request)\r\n");
			buff += W2CT(szRequestHeaders);
		}
		m_vboolCancelDL = VARIANT_FALSE;

		//Fire event
		m_Events->Fire_OnFileDLResponse(m_Uid, fUrl, 
									(long)(dwResponseCode), 
									T2BSTR(buff), &m_vboolCancelDL);
		if(m_vboolCancelDL == VARIANT_TRUE)
			CancelDL();
	}

	return S_OK;
}

bool WBBSCBFileDL::CancelDL(void)
{
	m_bCancelled = TRUE;
    if (m_pstm)
	{
        m_pstm->Release();
		m_pstm = NULL;
	}
	if(hFile != INVALID_HANDLE_VALUE)
	{
		CloseHandle(hFile);
		hFile = INVALID_HANDLE_VALUE;
	}
	if(m_pBinding)
	{
		m_pBinding->Abort();
	}
	return true;
}

bool WBBSCBFileDL::IsDownloading(void)
{
	return (m_pBinding) ? true : false;
}

//////////////////////////////////////////////////////////////
//CTmpBuffer
//////////////////////////////////////////////////////////////
CTmpBuffer::CTmpBuffer()
{
	InitLocalResources();
	AllocateBuffer(STARTUP_TEMP_BUFFER);
}

CTmpBuffer::CTmpBuffer(LPCTSTR strText)
{
	InitLocalResources();
	Append(strText);
}

CTmpBuffer::CTmpBuffer(UINT iSize)
{
	InitLocalResources();
	AllocateBuffer(iSize);
}

CTmpBuffer::~CTmpBuffer()
{
	ClearLocalResources();
}

void CTmpBuffer::ResetBuffer()
{
	if( (m_Buffer) && (m_BufferLen > 0) && (m_Allocated == true) )
	{
		//Mark the beginning and end
		m_Buffer[m_BufferLen] = _T('\0');
		m_Buffer[0] = _T('\0');
	}
	m_BufferTextLen = 0;
}

//Allocate buffer
UINT CTmpBuffer::AllocateBuffer(UINT nsize)
{
	if(nsize < 1)
		return 0;
	//Attempting to increase storage
	if( (m_Buffer) && (m_Allocated == true) )
	{
		LPTSTR tempbuffer = (LPTSTR)malloc((m_BufferLen+nsize+1) * sizeof(TCHAR));
		if(tempbuffer == NULL)
			return -1;
		//Adjust actual size of buffer
		m_BufferLen += nsize;
		tempbuffer[m_BufferLen] = _T('\0');
		//Copy what we have (m_BufferTextLen = actual number of characters in the buffer)
		if(m_BufferTextLen > 0)
			memcpy(tempbuffer, m_Buffer, m_BufferTextLen * sizeof(TCHAR));

		tempbuffer[m_BufferTextLen] = _T('\0');
		//Free current buffer and reassign
		free(m_Buffer);
		m_Buffer = tempbuffer;
	}
	else
	{
		//First time, just allocate
		m_Buffer = (LPTSTR)malloc( (nsize+1) * sizeof(TCHAR));
		if(m_Buffer == NULL)
			return -1;
		m_BufferLen = nsize;

		m_Buffer[m_BufferLen] = _T('\0');
		m_Buffer[0] = _T('\0');

		//No text in the buffer
		m_BufferTextLen = 0;
	}
	m_Allocated = true;
	return m_BufferLen;
}

//Append a string
UINT CTmpBuffer::Append(LPCTSTR strText, UINT iMaxLen)
{
	if( (strText == NULL) || (*strText == _T('\0')) )
		return 0;

	UINT nappend = 0;
	if(iMaxLen > 0)
		nappend = iMaxLen;
	else
		nappend = _tcslen(strText);

	if(nappend == 0)
		return 0;

	//Get actual buffer len + len of new text
	//to compare with the total buffer len
	UINT newlen = m_BufferTextLen + nappend;

	//Check
	if( (m_Buffer == NULL) || (m_Allocated == false) )
	{
		AllocateBuffer(newlen);
	}

	//Still have room
	if(m_BufferLen >= newlen)
	{
		//Just copy data
		memcpy(m_Buffer+m_BufferTextLen, strText, nappend * sizeof(TCHAR));
	}
	else
	{
		//Create a new storage + nGrowSize for the next strText
		LPTSTR tempbuffer = (LPTSTR)malloc( (newlen+1) * sizeof(TCHAR));
		if(tempbuffer == NULL)
			return 0;
		m_BufferLen = newlen;
		tempbuffer[m_BufferLen] = _T('\0');
		//Copy from buffer first and then the actual data
		memcpy(tempbuffer, m_Buffer, m_BufferTextLen * sizeof(TCHAR));
		memcpy(tempbuffer+m_BufferTextLen, strText, nappend * sizeof(TCHAR));
		//Empty buffer and reassign
		free(m_Buffer);
		m_Buffer = tempbuffer;
	}
	//Adjust actual number of text in buffer
	m_BufferTextLen = newlen;
	//Mark the end of actual text appended
	m_Buffer[m_BufferTextLen] = _T('\0');
	return newlen;
}

//Append a BSTR
UINT CTmpBuffer::AppendBSTR(BSTR strText, UINT iMaxLen)
{
	if(strText == NULL)
		return 0;
	UINT dwChars = ::SysStringLen(strText);
	LPTSTR pLocal = (LPTSTR)malloc( (dwChars+1) * sizeof(TCHAR));
	if(pLocal == NULL)
		return 0;
	pLocal[dwChars] = _T('\0');
#ifdef UNICODE
	lstrcpyn(pLocal, strText, dwChars);
#else
	WideCharToMultiByte(CP_ACP, 0, strText, -1, pLocal, dwChars, NULL, NULL);
#endif
	
	UINT iRet = Append(pLocal, iMaxLen);
	free(pLocal);
	return iRet;
}

//Append an int value
UINT CTmpBuffer::Appendint(int iNumber, int radix)
{
	TCHAR tmp[50];
#ifdef UNICODE
	_itow(iNumber, tmp, radix);
#else
	_itoa(iNumber, tmp, radix);
#endif
	return Append(tmp);
}

//Append a long value
UINT CTmpBuffer::Appendlong(long lNumber, int radix)
{
	TCHAR tmp[50];
#ifdef UNICODE
	_ltow(lNumber, tmp, radix);
#else
	_ltoa(lNumber, tmp, radix);
#endif
	return Append(tmp);
}

UINT CTmpBuffer::AppendGUID(REFGUID src)
{
	OLECHAR wszBuff[39];
	int i = StringFromGUID2(src, wszBuff, 39);
	TCHAR szBuff[39];
#ifdef UNICODE
	lstrcpyn(szBuff, wszBuff, 39);
#else
	WideCharToMultiByte(CP_ACP, 0, wszBuff, -1, szBuff, 39, NULL, NULL);
#endif
	return Append((LPCTSTR)szBuff);
}

UINT CTmpBuffer::AppendResStr(UINT nID, UINT iMaxLen)
{
	TCHAR sz[RES_BUFFER_SIZE];
	int nCount =  sizeof(sz) / sizeof(sz[0]);
//	UINT nLen = ::LoadString(m_hInst, nID, sz, sizeof(sz)/sizeof(TCHAR));
	UINT nLen = ::LoadString(m_hInst, nID, sz, nCount);
	UINT iRet = 0;
	if(nLen == 0)
		return iRet;
	//All string was read else need to read entire string
	//by increasing buffer size and trying again.
	//if (nCount - nLen > CHAR_FUDGE)
	iRet = Append( (LPCTSTR)sz, iMaxLen );
	return iRet;
}

//Accessors
TCHAR* CTmpBuffer::GetString(void)
{ return m_Buffer; }

UINT CTmpBuffer::ReleaseString(void)
{
	UINT iRet = 0;
	if(m_Buffer)
	{
		iRet = _tcslen(m_Buffer);
		if (iRet > 0)
		{
			m_BufferLen = iRet;
			m_BufferTextLen = iRet;
			m_Buffer[m_BufferTextLen] = _T('\0');
		}
	}
	return iRet;
}

LPCTSTR CTmpBuffer::GetBuffer(void) const
{ return m_Buffer; }

UINT CTmpBuffer::GetBufferLen(void) const
{ return m_BufferLen; }

UINT CTmpBuffer::GetBufferTextLen(void) const
{ return m_BufferTextLen; }

TCHAR CTmpBuffer::GetAt(int nIndex)
{
	if((UINT)nIndex < m_BufferLen) 
		return m_Buffer[nIndex];
	else
		return 0;
}
void CTmpBuffer::SetAt(int nIndex, TCHAR ch)
{
	if((UINT)nIndex < m_BufferLen)
		m_Buffer[nIndex] = ch;
}

TCHAR CTmpBuffer::operator[] (int nIndex)
{
	if((UINT)nIndex < m_BufferLen) 
		return m_Buffer[nIndex];
	else
		return 0;
}

CTmpBuffer& CTmpBuffer::operator=(const CTmpBuffer& src)
{
	//We don't destroy any buffers allocated
	ResetBuffer();
	Append(src);
	return *this;
}

CTmpBuffer& CTmpBuffer::operator=(const LPCTSTR src)
{
	ResetBuffer();
	Append(src);
	return *this;
}

CTmpBuffer& CTmpBuffer::operator+=(const CTmpBuffer& strSrc)
{
	Append(strSrc);
	return *this;
}

CTmpBuffer& CTmpBuffer::operator+=(const LPCTSTR strSrc)
{
	Append(strSrc);
	return *this;
}

CTmpBuffer& CTmpBuffer::operator=(const UINT nID)
{
	ResetBuffer();
	AppendResStr(nID);
	return *this;
}

CTmpBuffer& CTmpBuffer::operator+=(const UINT nID)
{
	AppendResStr(nID);
	return *this;
}

void CTmpBuffer::InitLocalResources()
{
	m_cRef = 1;
	m_Buffer = NULL;
	m_BufferLen = 0;
	m_BufferTextLen = 0;
	m_Allocated = false;
	#if (_ATL_VER >= 0x0700)
		m_hInst = ATL::_AtlBaseModule.GetResourceInstance();
	#else //#if (_ATL_VER == 0x0300)
		m_hInst = _Module.GetResourceInstance();
	#endif
}

void CTmpBuffer::ClearLocalResources()
{
	if( (m_Buffer) && (m_BufferLen > 0) && (m_Allocated == true) )
		free(m_Buffer);
	m_Buffer = NULL;
	m_BufferLen = 0;
	m_BufferTextLen = 0;
	m_Allocated = false;
}

////////////////////////////////////////////////////////////////////////////////////////
//WBPassthruSink
//Monitor and/or cancel every request and responde
//WB makes, including images, sounds, scripts, etc
////////////////////////////////////////////////////////////////////////////////////////
HRESULT WBPassthruSink::OnStart(LPCWSTR szUrl, IInternetProtocolSink *pOIProtSink,
		IInternetBindInfo *pOIBindInfo, DWORD grfPI, DWORD dwReserved,
		IInternetProtocol* pTargetProtocol)
{
	HRESULT hr = BaseClass::OnStart(szUrl, pOIProtSink, pOIBindInfo, grfPI,
		dwReserved, pTargetProtocol);
	
	//Initialize our variables
	m_pEvents = NULL;
	m_hwndIEServer = 0;
	m_strUrl.Empty();
	m_strRedirUrl.Empty();
	m_strRedirHeaders.Empty();

	//Find the instance of WB and IWB (host)
	CComPtr<IWindowForBindingUI> objWindowForBindingUI;
	HRESULT hret = QueryServiceFromClient(&objWindowForBindingUI);
	if( (SUCCEEDED(hret)) && (objWindowForBindingUI) )
	{
		HWND hwndIEServer = NULL;
		//Should return InternetExplorerServer HWND
		objWindowForBindingUI->GetWindow(IID_IHttpSecurity, &hwndIEServer);
		//From here we can find the ATL window hosting this instance of our control
		//and have it fire an event for the form/dlg hosting this instance of our control
		if( (hwndIEServer) && (::IsWindow(hwndIEServer)) )
		{
			m_hwndIEServer = (long)hwndIEServer;
			int i = 0;
			int isize = gCtrlInstances.GetSize();
			for(i = 0; i < isize; i++)
			{
				CcsDLMan *pDLMan = reinterpret_cast<CcsDLMan*>(gCtrlInstances[i]);
				if( (pDLMan) && (pDLMan->m_IEServerHwnd == hwndIEServer) )
				{
					m_pEvents = pDLMan;
					break;
				}
			}
		}
	}

	//This is available for the primary connection (once per request)
	//and not for images,...
//	QueryServiceFromClient(&spBSCB);
//	if(spBscb)

	return hr;
}

STDMETHODIMP WBPassthruSink::Switch(
	/* [in] */ PROTOCOLDATA *pProtocolData)
{
	ATLASSERT(m_spInternetProtocolSink != 0);

/*
From Igor Tandetnik "itandetnik@mvps.org"
"
Beware multithreading. URLMon has this nasty habit of spinning worker 
threads, not even bothering to initialize COM on them, and calling APP 
methods on those threads. If you try to raise COM events directly from 
such a thread, bad things happen (random crashes, events being lost). 
You are only guaranteed to be on the main STA thread in two cases. 
First, in methods of interfaces that were obtained with 
IServiceProvider, such as IHttpNegotiage::BeginningTransaction or 
IAuthenticate::Authenticate. Second, you can call 
IInternetProtocolSink::Switch with PD_FORCE_SWITCH flag in 
PROTOCOLDATA::grfFlags, eventually URLMon will turn around and call 
IInternetProtocol::Continue on the main thread. 

Or, if you happen to have a window handy that was created on the main 
thread, you can post yourself a message.
"
*/
	//if( (pProtocolData->grfFlags & PD_FORCE_SWITCH) != PD_FORCE_SWITCH)
	if( (pProtocolData->grfFlags & PD_FORCE_SWITCH) == 0)
		pProtocolData->grfFlags |= PD_FORCE_SWITCH;

	return m_spInternetProtocolSink ?
		m_spInternetProtocolSink->Switch(pProtocolData) :
		E_UNEXPECTED;
}


STDMETHODIMP WBPassthruSink::BeginningTransaction(LPCWSTR szURL, LPCWSTR szHeaders, DWORD dwReserved, LPWSTR *pszAdditionalHeaders)
{
	if (pszAdditionalHeaders)
	{
		*pszAdditionalHeaders = 0;
	}

	CComPtr<IHttpNegotiate> spHttpNegotiate;
	QueryServiceFromClient(&spHttpNegotiate);
	HRESULT hr = spHttpNegotiate ?
		spHttpNegotiate->BeginningTransaction(szURL, szHeaders,
			dwReserved, pszAdditionalHeaders) : S_OK;

	USES_CONVERSION;
	if(szURL)
		m_strUrl.AppendBSTR(W2BSTR(szURL));
	else
		m_strUrl = L"";
	m_strRedirUrl = L"";

		CComBSTR strRequestHeaders;
		//Get raw request headers and send them to client
		CComPtr<IWinInetHttpInfo> spWinInetHttpInfo;
		HRESULT hrTemp = m_spTargetProtocol->QueryInterface(IID_IWinInetHttpInfo,
			reinterpret_cast<void**>(&spWinInetHttpInfo));
		if(SUCCEEDED(hrTemp))
		{
			DWORD size = 0;
			DWORD flags = 0;
			hrTemp = spWinInetHttpInfo->QueryInfo(
				HTTP_QUERY_RAW_HEADERS_CRLF | HTTP_QUERY_FLAG_REQUEST_HEADERS,
				0, &size, &flags, 0);
			if(SUCCEEDED(hrTemp))
			{
				LPSTR pbuf = new char[size+1];
				pbuf[size] = '\0';
				hrTemp = spWinInetHttpInfo->QueryInfo(
					HTTP_QUERY_RAW_HEADERS_CRLF | HTTP_QUERY_FLAG_REQUEST_HEADERS,
					pbuf, &size, &flags, 0);
				if(SUCCEEDED(hrTemp))
				{
					//\r\n\r\n\0 Get rid of extra
					if( (size > 5) &&
						(pbuf[size-1] == '\n') && (pbuf[size-2] == '\r') &&
						(pbuf[size-3] == '\n') && (pbuf[size-4] == '\r') )
					{
						pbuf[size-1] = '\0';
						pbuf[size-2] = '\0';
					}
					//pbuf should contain all request headers
					strRequestHeaders.Append(pbuf);
				}
				else
					strRequestHeaders = L"";
			}
			else
				strRequestHeaders = L"";
		}
		else
			strRequestHeaders = L"";

		//Additional Client headers
		CComBSTR strAddHttpHeaders;

		if(szHeaders)
		{
			//Accept-Encoding: gzip, deflate
			strRequestHeaders += W2BSTR(szHeaders);
			strRequestHeaders.Append(_T("\r\n"));
		}
		if( pszAdditionalHeaders && *pszAdditionalHeaders)
		{
			//Referer: http://www.google.ca/
			//Accept-Language: en-ca
			strAddHttpHeaders = W2BSTR(*pszAdditionalHeaders);
			strRequestHeaders += strAddHttpHeaders;
		}
		//Fire event
		if( m_pEvents )
		{
			VARIANT_BOOL bcancel = VARIANT_FALSE;
			CComBSTR strTempHeaders(L"");
			m_pEvents->Fire_ProtocolHandlerOnBeginTransaction(m_hwndIEServer, 
												m_strUrl, strRequestHeaders, 
												&strTempHeaders, &bcancel);
			if(bcancel == VARIANT_TRUE)
				return E_ABORT;
			
			//Did client add any of their headers
			if(strTempHeaders.Length() > 0)
			{
				strTempHeaders += strAddHttpHeaders;
				if(strTempHeaders.Length() > 0)
				{
					LPWSTR wszAdditionalHeaders = (LPWSTR)CoTaskMemAlloc((strTempHeaders.Length()+1) *sizeof(WCHAR));
					if(wszAdditionalHeaders)
					{
						//Free what we had
						CoTaskMemFree(*pszAdditionalHeaders);
						wcscpy(wszAdditionalHeaders, OLE2W(strTempHeaders));
						wszAdditionalHeaders[strTempHeaders.Length()] = (WCHAR)NULL;
						*pszAdditionalHeaders = wszAdditionalHeaders;
					}
				}
			}
		}

	return hr;
}

STDMETHODIMP WBPassthruSink::OnResponse(DWORD dwResponseCode, LPCWSTR szResponseHeaders, LPCWSTR szRequestHeaders, LPWSTR *pszAdditionalRequestHeaders)
{
	if (pszAdditionalRequestHeaders)
	{
		*pszAdditionalRequestHeaders = 0;
	}
	CComPtr<IHttpNegotiate> spHttpNegotiate;
	QueryServiceFromClient(&spHttpNegotiate);
	HRESULT hr = spHttpNegotiate ?
		spHttpNegotiate->OnResponse(dwResponseCode, szResponseHeaders,
			szRequestHeaders, pszAdditionalRequestHeaders) : S_OK;


	USES_CONVERSION;
	CTmpBuffer buff(MAX_PATH*2);
	buff = W2CT(szResponseHeaders);
	if (szRequestHeaders)
	{
		//buff += _T("(Repeat request)\r\n");
		buff += W2CT(szRequestHeaders);
		if (SUCCEEDED(hr) && pszAdditionalRequestHeaders &&
			*pszAdditionalRequestHeaders)
		{
			buff += W2CT(*pszAdditionalRequestHeaders);
		}
	}
	if( m_pEvents )
	{
		VARIANT_BOOL bcancel = VARIANT_FALSE;
		//Fire event
		m_pEvents->Fire_ProtocolHandlerOnResponse(m_hwndIEServer, m_strUrl, 
											T2BSTR(buff), m_strRedirUrl, 
											m_strRedirHeaders, &bcancel);

		if(bcancel == VARIANT_TRUE)
			return m_spTargetProtocol->Abort(E_ABORT,0);

		if(m_strRedirUrl.Length() > 0)
		{
			m_strUrl.Empty();
			m_strUrl = m_strRedirUrl;
		}
	}

	return hr;
}

STDMETHODIMP WBPassthruSink::ReportProgress(ULONG ulStatusCode, LPCWSTR szStatusText)
{

	ATLASSERT(m_spInternetProtocolSink != 0);
	HRESULT hr = m_spInternetProtocolSink ?
		m_spInternetProtocolSink->ReportProgress(ulStatusCode, szStatusText) :
		S_OK;

	if(ulStatusCode == BINDSTATUS_REDIRECTING)
	{
		USES_CONVERSION;

		//Get redirected URL
		m_strRedirUrl.Empty();
		if(szStatusText)
			m_strRedirUrl.AppendBSTR(W2BSTR(szStatusText));
		else
			m_strRedirUrl = L"";
		
		//To get redirect headers during a redirect
		//No OnResponse is fired for a redirect
		m_strRedirHeaders.Empty();
		//Get raw request headers and send them to client
/*
Client applications can call QueryInterface on the IBinding 
interface to get a pointer to the IWinInetHttpInfo interface 
after your implementation of the IBindStatusCallback::OnProgress 
method has been called.
*/
		CComPtr<IWinInetHttpInfo> spWinInetHttpInfo;
		HRESULT hrTemp = m_spTargetProtocol->QueryInterface(IID_IWinInetHttpInfo,
			reinterpret_cast<void**>(&spWinInetHttpInfo));
		if(SUCCEEDED(hrTemp))
		{
			DWORD size = 0;
			DWORD flags = 0;
			hrTemp = spWinInetHttpInfo->QueryInfo( HTTP_QUERY_RAW_HEADERS_CRLF,
				0, &size, &flags, 0);
			if(SUCCEEDED(hrTemp))
			{
				LPSTR pbuf = new char[size+1];
				pbuf[size] = '\0';
				hrTemp = spWinInetHttpInfo->QueryInfo( HTTP_QUERY_RAW_HEADERS_CRLF,
					pbuf, &size, &flags, 0);
				if(SUCCEEDED(hrTemp))
				{
					//\r\n\r\n\0 Get rid of extra
					if( (size > 5) &&
						(pbuf[size-1] == '\n') && (pbuf[size-2] == '\r') &&
						(pbuf[size-3] == '\n') && (pbuf[size-4] == '\r') )
					{
						pbuf[size-1] = '\0';
						pbuf[size-2] = '\0';
					}
					//pbuf should contain all request headers
					m_strRedirHeaders.Append(pbuf);
				}
				else
					m_strRedirHeaders = L"";
			}
			else
				m_strRedirHeaders = L"";
		}
		else
			m_strRedirHeaders = L"";
	}

	return hr;
}

////////////////////////////////////////////////////////////////////////////////////////////////
//	HOOK CALLBACK IMPLEMENTATION
////////////////////////////////////////////////////////////////////////////////////////////////

static LRESULT CALLBACK KeyboardProc(int nCode, WPARAM wParam, LPARAM lParam)
{
    if (nCode < 0)  // do not process message 
        return CallNextHookEx(wbhookdata[H_KEYBOARD].hhook, nCode, wParam, lParam);

	if( (nCode == HC_ACTION) && (lParam) 
		&& (wbhookdata[H_KEYBOARD].hwndTarget) 
		&& (::IsWindow(wbhookdata[H_KEYBOARD].hwndTarget)) )
	{
		DWORD dwresult = 0;
		//UINT umsg = WM_KEYDOWN;
		////wParam = virtual-key code
		//// Reference: WM_KEYDOWN on MSDN
		//if (lParam & 0x80000000) // check bit 31 for up/down
		//{
		//	umsg = WM_KEYUP;
		//}
		//else
		//{
		//	if (lParam & 0x40000000) // check bit 30 for previous up/down
		//		umsg = WM_KEY_REPEAT; // It was pressed down before this key-down event, so it's a key-repeat for sure
		//	else
		//		umsg = WM_KEYDOWN;
		//}
		//always returns 1
		::SendMessageTimeout(wbhookdata[H_KEYBOARD].hwndTarget,
			wbhookdata[H_KEYBOARD].uiHookMsgID , //sending our own registered message 
			wParam, lParam, SMTO_ABORTIFHUNG, 500, &dwresult);
		//Check dwresult, return value from client, default 0, allow hook to continue
		long lret = (long)dwresult;
		//if return value is greater than 0 then cancel
		if(lret > 0) return lret;
//TCHAR tmp[50];
//#ifdef UNICODE
//	_ltow(lret, tmp, 10);
//#else
//	_ltoa(lret, tmp, 10);
//#endif
//MessageBox(GetDesktopWindow(), tmp, _T("KeyboardProc RETURN VALUE"),MB_OK);
	}

	//Default processing
    return CallNextHookEx(wbhookdata[H_KEYBOARD].hhook, nCode, wParam, lParam);
}

static LRESULT CALLBACK MouseProc(int nCode, WPARAM wParam, LPARAM lParam)
{
    if (nCode < 0)  // do not process message 
        return CallNextHookEx(wbhookdata[H_MOUSE].hhook, nCode, wParam, lParam);
	
	//LPMOUSEHOOKSTRUCT pMsg = (LPMOUSEHOOKSTRUCT)lParam;
	//wParam one of WM_xxx(LBUTTONDOWN, LBUTTONDOWN, MOUSEMOVE, NCMOUSEMOVE, MOUSEWHEEL,  ...)
	if( (nCode == HC_ACTION) && (lParam) 
		&& (wbhookdata[H_MOUSE].hwndTarget) 
		&& (::IsWindow(wbhookdata[H_MOUSE].hwndTarget)) )
	{
		DWORD dwresult = 0;
		::SendMessageTimeout(wbhookdata[H_MOUSE].hwndTarget, wbhookdata[H_MOUSE].uiHookMsgID , 
			wParam, lParam, SMTO_ABORTIFHUNG, 500, &dwresult);
		long lret = (long)dwresult;
		if(lret > 0) return lret;
	}
	
	//Default processingfgt
    return CallNextHookEx(wbhookdata[H_MOUSE].hhook, nCode, wParam, lParam);
}

static LRESULT CALLBACK LowLevelKeyboardProc(int nCode, WPARAM wParam, LPARAM lParam)
{
    if (nCode < 0)  // do not process message 
        return CallNextHookEx(wbhookdata[H_KEYBOARD_LL].hhook, nCode, wParam, lParam);
	
	//LPKBDLLHOOKSTRUCT pMsg = (LPKBDLLHOOKSTRUCT)lParam;
	//wParam one of WM_KEYDOWN, WM_KEYUP, WM_SYSKEYDOWN, or WM_SYSKEYUP
	if( (nCode == HC_ACTION) && (lParam) 
		&& (wbhookdata[H_KEYBOARD_LL].hwndTarget) 
		&& (::IsWindow(wbhookdata[H_KEYBOARD_LL].hwndTarget)) )
	{
		DWORD dwresult = 0;
		
		::SendMessageTimeout(wbhookdata[H_KEYBOARD_LL].hwndTarget, 
			wbhookdata[H_KEYBOARD_LL].uiHookMsgID , 
			wParam, lParam, SMTO_ABORTIFHUNG, 500, &dwresult);
		long lret = (long)dwresult;
		if(lret > 0) return lret;
	}
	
	//Default processinghgok
    return CallNextHookEx(wbhookdata[H_KEYBOARD_LL].hhook, nCode, wParam, lParam);
}

static LRESULT CALLBACK CallWndProc(int nCode, WPARAM wParam, LPARAM lParam)
{
    if (nCode < 0)  // do not process message 
        return CallNextHookEx(wbhookdata[H_CALLWNDPROC].hhook, nCode, wParam, lParam);
	
	//wParam: Specifies whether the message was sent by the current thread.
	//If the message was sent by the current thread, it is nonzero; otherwise, it is zero
	//LPCWPSTRUCT lpcp = (LPCWPSTRUCT)wParam
	if( (nCode == HC_ACTION) && (lParam) 
		&& (wbhookdata[H_CALLWNDPROC].hwndTarget) 
		&& (::IsWindow(wbhookdata[H_CALLWNDPROC].hwndTarget)) )
	{
		DWORD dwresult = 0;
		::SendMessageTimeout(wbhookdata[H_CALLWNDPROC].hwndTarget,
			wbhookdata[H_CALLWNDPROC].uiHookMsgID , 
			wParam, lParam, SMTO_ABORTIFHUNG, 500, &dwresult);
		long lret = (long)dwresult;
		if(lret > 0) return lret;
	}
	
	//Default processing
    return CallNextHookEx(wbhookdata[H_CALLWNDPROC].hhook, nCode, wParam, lParam);
}

static LRESULT CALLBACK CBTProc(int nCode, WPARAM wParam, LPARAM lParam)
{
    if (nCode < 0)  // do not process message 
        return CallNextHookEx(wbhookdata[H_CBT].hhook, nCode, wParam, lParam);
	
	if( (nCode) && (lParam) 
		&& (wbhookdata[H_CBT].hwndTarget) 
		&& (::IsWindow(wbhookdata[H_CBT].hwndTarget)) )
	{
		DWORD dwresult = 0;
		nCode_CBTProc = nCode;
		//nCode
//HCBT_ACTIVATE
//HCBT_CLICKSKIPPED
//HCBT_CREATEWND
//HCBT_DESTROYWND
//HCBT_KEYSKIPPED
//HCBT_MINMAX
//HCBT_MOVESIZE
//HCBT_QS
//HCBT_SETFOCUS
//HCBT_SYSCOMMAND
		//lParam and wParam depend on nCode
		::SendMessageTimeout(wbhookdata[H_CBT].hwndTarget, 
			wbhookdata[H_CBT].uiHookMsgID , 
			wParam, lParam, SMTO_ABORTIFHUNG, 500, &dwresult);
		long lret = (long)dwresult;
		if(lret > 0) return lret;
	}
	
	//Default processing
    return CallNextHookEx(wbhookdata[H_CBT].hhook, nCode, wParam, lParam);
}

static LRESULT CALLBACK GetMsgProc(int nCode, WPARAM wParam, LPARAM lParam)
{
    if (nCode < 0)  // do not process message 
        return CallNextHookEx(wbhookdata[H_GETMESSAGE].hhook, nCode, wParam, lParam);
	
	//LPMSG msg = (LPMSG)lParam
	//wParam = PM_NOREMOVE or PM_REMOVE
	if( (nCode == HC_ACTION) && (lParam) 
		&& (wbhookdata[H_GETMESSAGE].hwndTarget) 
		&& (::IsWindow(wbhookdata[H_GETMESSAGE].hwndTarget)) )
	{
		DWORD dwresult = 0;
		::SendMessageTimeout(wbhookdata[H_GETMESSAGE].hwndTarget,
			wbhookdata[H_GETMESSAGE].uiHookMsgID , 
			wParam, lParam, SMTO_ABORTIFHUNG, 500, &dwresult);
		long lret = (long)dwresult;
		if(lret > 0) return lret;
	}
	
	//Default processing
    return CallNextHookEx(wbhookdata[H_GETMESSAGE].hhook, nCode, wParam, lParam);
}

static LRESULT CALLBACK MessageProc(int nCode, WPARAM wParam, LPARAM lParam)
{
    if (nCode < 0)  // do not process message 
        return CallNextHookEx(wbhookdata[H_MSGFILTER].hhook, nCode, wParam, lParam);
	
	if( (nCode) && (lParam) 
		&& (wbhookdata[H_MSGFILTER].hwndTarget) 
		&& (::IsWindow(wbhookdata[H_MSGFILTER].hwndTarget)) )
	{
		DWORD dwresult = 0;
		nCode_MessageProc = nCode;
		//nCode
//MSGF_DDEMGR
//MSGF_DIALOGBOX
//MSGF_MENU
//MSGF_SCROLLBAR
		//LPMSG msg = (LPMSG)lParam;
		//wParam is not used
		::SendMessageTimeout(wbhookdata[H_MSGFILTER].hwndTarget,
			wbhookdata[H_MSGFILTER].uiHookMsgID , 
			wParam, lParam, SMTO_ABORTIFHUNG, 500, &dwresult);
		long lret = (long)dwresult;
		if(lret > 0) return lret;
	}
	return CallNextHookEx(wbhookdata[H_MSGFILTER].hhook, nCode, wParam, lParam);
}

static LRESULT CALLBACK LowLevelMouseProc(int nCode, WPARAM wParam, LPARAM lParam)
{
    if (nCode < 0)  // do not process message 
        return CallNextHookEx(wbhookdata[H_MOUSE_LL].hhook, nCode, wParam, lParam);
	
	if( (nCode == HC_ACTION) && (lParam) 
		&& (wbhookdata[H_MOUSE_LL].hwndTarget) 
		&& (::IsWindow(wbhookdata[H_MOUSE_LL].hwndTarget)) )
	{
		DWORD dwresult = 0;
		//wParam, one of WM_LBUTTONDOWN, WM_LBUTTONUP, WM_MOUSEMOVE,
		//WM_MOUSEWHEEL, WM_RBUTTONDOWN, or WM_RBUTTONUP.
		//LPMSLLHOOKSTRUCT msg = (LPMSLLHOOKSTRUCT)lParam
		::SendMessageTimeout(wbhookdata[H_MOUSE_LL].hwndTarget,
			wbhookdata[H_MOUSE_LL].uiHookMsgID , 
			wParam, lParam, SMTO_ABORTIFHUNG, 500, &dwresult);
		long lret = (long)dwresult;
		if(lret > 0) return lret;
	}
	return CallNextHookEx(wbhookdata[H_MOUSE_LL].hhook, nCode, wParam, lParam);
}

static LRESULT CALLBACK ForegroundIdleProc(int nCode, WPARAM wParam, LPARAM lParam)
{
    if (nCode < 0)  // do not process message 
        return CallNextHookEx(wbhookdata[H_GETMESSAGE].hhook, nCode, wParam, lParam);
	
	if( (nCode == HC_ACTION) && (lParam) 
		&& (wbhookdata[H_FOREGROUNDIDLE].hwndTarget) 
		&& (::IsWindow(wbhookdata[H_FOREGROUNDIDLE].hwndTarget)) )
	{
		DWORD dwresult = 0;
		//wParam and lParam are not used
		::SendMessageTimeout(wbhookdata[H_FOREGROUNDIDLE].hwndTarget,
			wbhookdata[H_FOREGROUNDIDLE].uiHookMsgID , 
			wParam, lParam, SMTO_ABORTIFHUNG, 500, &dwresult);
		long lret = (long)dwresult;
		if(lret > 0) return lret;
	}
	return CallNextHookEx(wbhookdata[H_FOREGROUNDIDLE].hhook, nCode, wParam, lParam);
}

static LRESULT CALLBACK CallWndRetProc(int nCode, WPARAM wParam, LPARAM lParam)
{
    if (nCode < 0)  // do not process message 
        return CallNextHookEx(wbhookdata[H_CALLWNDPROCRET].hhook, nCode, wParam, lParam);
	
	if( (nCode == HC_ACTION) && (lParam) 
		&& (wbhookdata[H_CALLWNDPROCRET].hwndTarget) 
		&& (::IsWindow(wbhookdata[H_CALLWNDPROCRET].hwndTarget)) )
	{
		DWORD dwresult = 0;
		//wParam, Specifies whether the message is sent by the current process.
		//If the message is sent by the current process, it is nonzero; otherwise, it is NULL.
		//LPCWPRETSTRUCT msg = (LPCWPRETSTRUCT)lParam;
		::SendMessageTimeout(wbhookdata[H_CALLWNDPROCRET].hwndTarget,
			wbhookdata[H_CALLWNDPROCRET].uiHookMsgID , 
			wParam, lParam, SMTO_ABORTIFHUNG, 500, &dwresult);
		long lret = (long)dwresult;
		if(lret > 0) return lret;
	}
	return CallNextHookEx(wbhookdata[H_CALLWNDPROCRET].hhook, nCode, wParam, lParam);
}

static LRESULT CALLBACK SysMsgProc(int nCode, WPARAM wParam, LPARAM lParam)
{
    if (nCode < 0)  // do not process message 
        return CallNextHookEx(wbhookdata[H_SYSMSGFILTER].hhook, nCode, wParam, lParam);
	
	if( (nCode) && (lParam) 
		&& (wbhookdata[H_SYSMSGFILTER].hwndTarget) 
		&& (::IsWindow(wbhookdata[H_SYSMSGFILTER].hwndTarget)) )
	{
		DWORD dwresult = 0;
		nCode_SysMsgProc = nCode;
		//nCode
//MSGF_DIALOGBOX
//MSGF_MENU
//MSGF_SCROLLBAR
		//wParam is not used
		//LPMSG msg = (LPMSG)lParam
		::SendMessageTimeout(wbhookdata[H_SYSMSGFILTER].hwndTarget,
			wbhookdata[H_SYSMSGFILTER].uiHookMsgID , 
			wParam, lParam, SMTO_ABORTIFHUNG, 500, &dwresult);
		long lret = (long)dwresult;
		if(lret > 0) return lret;
	}
	return CallNextHookEx(wbhookdata[H_SYSMSGFILTER].hhook, nCode, wParam, lParam);
}

static LRESULT CALLBACK ShellProc(int nCode, WPARAM wParam, LPARAM lParam)
{
    if (nCode < 0)  // do not process message 
        return CallNextHookEx(wbhookdata[H_SHELL].hhook, nCode, wParam, lParam);

	if( (nCode) && (lParam) 
		&& (wbhookdata[H_SHELL].hwndTarget) 
		&& (::IsWindow(wbhookdata[H_SHELL].hwndTarget)) )
	{
		DWORD dwresult = 0;
		nCode_ShellProc = nCode;
		//contents of wParam and lParam depend on nCode
		::SendMessageTimeout(wbhookdata[H_SHELL].hwndTarget,
			wbhookdata[H_SHELL].uiHookMsgID , 
			wParam, lParam, SMTO_ABORTIFHUNG, 500, &dwresult);
		long lret = (long)dwresult;
		if(lret > 0) return lret;
	}
	return CallNextHookEx(wbhookdata[H_SHELL].hhook, nCode, wParam, lParam);

}
