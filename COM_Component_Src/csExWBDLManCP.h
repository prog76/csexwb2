#ifndef _CSEXWBDLMANCP_H_
#define _CSEXWBDLMANCP_H_

//
//WARNNING:
//
//DO NOT USE WIZARD, EDIT BY HAND
//BACKUP BEFORE MODIFICATION

#include "ATLCPImplMT.h"

template <class T>
class CProxy_IcsDLManEvents : public IConnectionPointImplMT<T, &DIID__IcsDLManEvents, CComDynamicUnkArray>
{

public:
	VOID Fire_FileDownloadEx(LONG dlUID, BSTR sURL, BSTR sFilename, BSTR sExt, BSTR sFileSize, BSTR sExtraHeaders, BSTR sRedirURL, VARIANT_BOOL * SendProgressEvents, VARIANT_BOOL * bStopDownload, BSTR * sPathToSave)
	{
		//T* pT = static_cast<T*>(this);
		int nConnectionIndex;
		CComVariant* pvars = new CComVariant[10];
		int nConnections = m_vec.GetSize();
		
		for (nConnectionIndex = 0; nConnectionIndex < nConnections; nConnectionIndex++)
		{
			//pT->Lock();
			//CComPtr<IUnknown> sp = m_vec.GetAt(nConnectionIndex);
			//pT->Unlock();
			CComPtr<IUnknown> sp;
			sp.Attach (GetInterfaceAt(nConnectionIndex));

			IDispatch* pDispatch = reinterpret_cast<IDispatch*>(sp.p);
			if (pDispatch != NULL)
			{
				pvars[9] = dlUID;
				pvars[8] = sURL;
				pvars[7] = sFilename;
				pvars[6] = sExt;
				pvars[5] = sFileSize;
				pvars[4] = sExtraHeaders;
				pvars[3] = sRedirURL;

				pvars[2].vt = VT_BYREF|VT_BOOL;
				pvars[2].byref = SendProgressEvents;

				pvars[1].vt = VT_BYREF|VT_BOOL;
				pvars[1].byref = bStopDownload;
				
				pvars[0].vt = VT_BYREF|VT_BSTR;
				pvars[0].byref = sPathToSave;
				DISPPARAMS disp = { pvars, NULL, 10, 0 };
				pDispatch->Invoke(0x1, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &disp, NULL, NULL, NULL);
			}
		}
		delete[] pvars;
	
	}
	VOID Fire_OnFileDLProgress(LONG dlUID, BSTR sURL, LONG lProgress, LONG lProgressMax, VARIANT_BOOL * CancelDl)
	{
		//T* pT = static_cast<T*>(this);
		int nConnectionIndex;
		CComVariant* pvars = new CComVariant[5];
		int nConnections = m_vec.GetSize();
		
		for (nConnectionIndex = 0; nConnectionIndex < nConnections; nConnectionIndex++)
		{
			CComPtr<IUnknown> sp;
			sp.Attach (GetInterfaceAt(nConnectionIndex));
			IDispatch* pDispatch = reinterpret_cast<IDispatch*>(sp.p);
			if (pDispatch != NULL)
			{
				pvars[4] = dlUID;
				pvars[3] = sURL;
				pvars[2] = lProgress;
				pvars[1] = lProgressMax;
				pvars[0].vt = VT_BYREF|VT_BOOL;
				pvars[0].byref = CancelDl;
				DISPPARAMS disp = { pvars, NULL, 5, 0 };
				pDispatch->Invoke(0x2, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &disp, NULL, NULL, NULL);
			}
		}
		delete[] pvars;
	
	}
	VOID Fire_OnFileDLEndDownload(LONG dlUID, BSTR sURL, BSTR sSavedFilePath)
	{
		//T* pT = static_cast<T*>(this);
		int nConnectionIndex;
		CComVariant* pvars = new CComVariant[3];
		int nConnections = m_vec.GetSize();
		
		for (nConnectionIndex = 0; nConnectionIndex < nConnections; nConnectionIndex++)
		{
			CComPtr<IUnknown> sp;
			sp.Attach (GetInterfaceAt(nConnectionIndex));
			IDispatch* pDispatch = reinterpret_cast<IDispatch*>(sp.p);
			if (pDispatch != NULL)
			{
				pvars[2] = dlUID;
				pvars[1] = sURL;
				pvars[0] = sSavedFilePath;
				DISPPARAMS disp = { pvars, NULL, 3, 0 };
				pDispatch->Invoke(0x3, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &disp, NULL, NULL, NULL);
			}
		}
		delete[] pvars;
	
	}
	VOID Fire_OnFileDLDownloadError(LONG dlUID, BSTR sURL, BSTR sErrorMsg)
	{
		//T* pT = static_cast<T*>(this);
		int nConnectionIndex;
		CComVariant* pvars = new CComVariant[3];
		int nConnections = m_vec.GetSize();
		
		for (nConnectionIndex = 0; nConnectionIndex < nConnections; nConnectionIndex++)
		{
			CComPtr<IUnknown> sp;
			sp.Attach (GetInterfaceAt(nConnectionIndex));
			IDispatch* pDispatch = reinterpret_cast<IDispatch*>(sp.p);
			if (pDispatch != NULL)
			{
				pvars[2] = dlUID;
				pvars[1] = sURL;
				pvars[0] = sErrorMsg;
				DISPPARAMS disp = { pvars, NULL, 3, 0 };
				pDispatch->Invoke(0x4, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &disp, NULL, NULL, NULL);
			}
		}
		delete[] pvars;
	
	}
	VOID Fire_OnFileDLAuthenticate(LONG dlUID, BSTR * sUsername, BSTR * sPassword, VARIANT_BOOL * Cancel)
	{
		//T* pT = static_cast<T*>(this);
		int nConnectionIndex;
		CComVariant* pvars = new CComVariant[4];
		int nConnections = m_vec.GetSize();
		
		for (nConnectionIndex = 0; nConnectionIndex < nConnections; nConnectionIndex++)
		{
			CComPtr<IUnknown> sp;
			sp.Attach (GetInterfaceAt(nConnectionIndex));
			IDispatch* pDispatch = reinterpret_cast<IDispatch*>(sp.p);
			if (pDispatch != NULL)
			{
				pvars[3] = dlUID;
				pvars[2].vt = VT_BYREF|VT_BSTR;
 				pvars[2].byref = sUsername;

				pvars[1].vt = VT_BYREF|VT_BSTR;
 				pvars[1].byref = sPassword;

				pvars[0].vt = VT_BYREF|VT_BOOL;
				pvars[0].byref = Cancel;
				DISPPARAMS disp = { pvars, NULL, 4, 0 };
				pDispatch->Invoke(0x5, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &disp, NULL, NULL, NULL);
			}
		}
		delete[] pvars;
	
	}

	VOID Fire_ProtocolHandlerOnBeginTransaction(LONG IEServerHwnd, BSTR sURL, BSTR sRequestHeaders, BSTR * sAdditionalHeaders, VARIANT_BOOL * Cancel)
	{
		int nConnectionIndex;
		CComVariant* pvars = new CComVariant[5];
		int nConnections = m_vec.GetSize();
		
		for (nConnectionIndex = 0; nConnectionIndex < nConnections; nConnectionIndex++)
		{
			CComPtr<IUnknown> sp;
			sp.Attach (GetInterfaceAt(nConnectionIndex));

			IDispatch* pDispatch = reinterpret_cast<IDispatch*>(sp.p);
			if (pDispatch != NULL)
			{
				pvars[4] = IEServerHwnd;
				pvars[3] = sURL;
 				pvars[2] = sRequestHeaders;

				pvars[1].vt = VT_BYREF|VT_BSTR;
				pvars[1].byref = sAdditionalHeaders;

				pvars[0].vt = VT_BYREF|VT_BOOL;
				pvars[0].byref = Cancel;

				DISPPARAMS disp = { pvars, NULL, 5, 0 };
				pDispatch->Invoke(0x6, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &disp, NULL, NULL, NULL);
			}
		}
		delete[] pvars;
	
	}
	VOID Fire_ProtocolHandlerOnResponse(LONG IEServerHwnd, BSTR sURL, BSTR sResponseHeaders, BSTR sRedirectedUrl, BSTR sRedirectHeaders, VARIANT_BOOL * Cancel)
	{
		int nConnectionIndex;
		CComVariant* pvars = new CComVariant[6];
		int nConnections = m_vec.GetSize();
		
		for (nConnectionIndex = 0; nConnectionIndex < nConnections; nConnectionIndex++)
		{
			CComPtr<IUnknown> sp;
			sp.Attach (GetInterfaceAt(nConnectionIndex));

			IDispatch* pDispatch = reinterpret_cast<IDispatch*>(sp.p);
			if (pDispatch != NULL)
			{
				pvars[5] = IEServerHwnd;
				pvars[4] = sURL;
 				pvars[3] = sResponseHeaders;
 				pvars[2] = sRedirectedUrl;
				pvars[1] = sRedirectHeaders;

				pvars[0].vt = VT_BYREF|VT_BOOL;
				pvars[0].byref = Cancel;

				DISPPARAMS disp = { pvars, NULL, 6, 0 };
				pDispatch->Invoke(0x7, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &disp, NULL, NULL, NULL);
			}
		}
		delete[] pvars;
	}
	VOID Fire_OnFileDLBeginningTransaction(LONG dlUID, BSTR sURL, BSTR sRequestHeaders, BSTR * sAdditionalRequestHeaders, VARIANT_BOOL * bResuming, VARIANT_BOOL * bCancel)
	{
		//T* pT = static_cast<T*>(this);
		int nConnectionIndex;
		CComVariant* pvars = new CComVariant[6];
		int nConnections = m_vec.GetSize();
		
		for (nConnectionIndex = 0; nConnectionIndex < nConnections; nConnectionIndex++)
		{
			CComPtr<IUnknown> sp;
			sp.Attach (GetInterfaceAt(nConnectionIndex));

			IDispatch* pDispatch = reinterpret_cast<IDispatch*>(sp.p);
			if (pDispatch != NULL)
			{
				pvars[5] = dlUID;
				pvars[4] = sURL;
				pvars[3] = sRequestHeaders;

				pvars[2].vt = VT_BYREF|VT_BSTR;
 				pvars[2].byref = sAdditionalRequestHeaders;

				pvars[1].vt = VT_BYREF|VT_BOOL;
				pvars[1].byref = bResuming;

				pvars[0].vt = VT_BYREF|VT_BOOL;
				pvars[0].byref = bCancel;

				DISPPARAMS disp = { pvars, NULL, 6, 0 };
				pDispatch->Invoke(0x8, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &disp, NULL, NULL, NULL);
			}
		}
		delete[] pvars;
	
	}
	VOID Fire_OnFileDLResponse(LONG dlUID, BSTR sURL, LONG lResponseCode, BSTR sResponseHeaders, VARIANT_BOOL * CancelDl)
	{
		//T* pT = static_cast<T*>(this);
		int nConnectionIndex;
		CComVariant* pvars = new CComVariant[5];
		int nConnections = m_vec.GetSize();
		
		for (nConnectionIndex = 0; nConnectionIndex < nConnections; nConnectionIndex++)
		{
			CComPtr<IUnknown> sp;
			sp.Attach (GetInterfaceAt(nConnectionIndex));

			IDispatch* pDispatch = reinterpret_cast<IDispatch*>(sp.p);
			if (pDispatch != NULL)
			{
				pvars[4] = dlUID;
				pvars[3] = sURL;
				pvars[2] = lResponseCode;
				pvars[1] = sResponseHeaders;

				pvars[0].vt = VT_BYREF|VT_BOOL;
				pvars[0].byref = CancelDl;
				
				DISPPARAMS disp = { pvars, NULL, 5, 0 };
				pDispatch->Invoke(0x9, IID_NULL, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &disp, NULL, NULL, NULL);
			}
		}
		delete[] pvars;
	}

};
#endif