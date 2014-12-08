// This is a supplement to the Active Template Library 3.0.
// Copyright (C) 2000 Microsoft Corporation
// All rights reserved.
//
// This source code is only intended for illustration.

//ATL-based ActiveX COM objects
//(including Automation objects and ActiveX controls) typically
//fire events from the same thread in which they were created.
//Sometimes it is desirable to start secondary threads in the COM object
//that fire events to the container. ATLCPImplMT.h provides an enhanced
//implementation of the ATL IConnectionPointImpl class,
//IConnectionPointImplMT, that provides this capability.


#ifndef __CPIMPLMT_H__
#define __CPIMPLMT_H__

#include <atlcom.h>

//////////////////////////////////////////////////////////////////////////////
// IConnectionPointImplMT: Used instead of IConnectionPointImpl:
template <class T, const IID* piid, class CDV = CComDynamicUnkArray>
class ATL_NO_VTABLE IConnectionPointImplMT : public _ICPLocator<piid>
{
	typedef CComEnum<IEnumConnections, &IID_IEnumConnections, CONNECTDATA,
		_Copy<CONNECTDATA> > CComEnumConnections;

	// Use CDV, but store DWORDs instead of IUnknown pointers.
	// ASSUMPTION: sizeof(DWORD) == sizeof(IUnknown *):
	typedef CDV _CDV;
public:
	// Added constructor:
	IConnectionPointImplMT();

	~IConnectionPointImplMT();
	STDMETHOD(_LocCPQueryInterface)(REFIID riid, void ** ppvObject)
	{
		if (::InlineIsEqualGUID(riid, IID_IConnectionPoint) || InlineIsEqualUnknown(riid))
		{
			if (ppvObject == NULL)
				return E_POINTER;
			*ppvObject = this;
			AddRef();
#ifdef _ATL_DEBUG_INTERFACES
			_Module.AddThunk((IUnknown**)ppvObject, _T("IConnectionPointImplMT"), riid);
#endif // _ATL_DEBUG_INTERFACES
			return S_OK;
		}
		else
			return E_NOINTERFACE;
	}

	STDMETHOD(GetConnectionInterface)(IID* piid2)
	{
		if (piid2 == NULL)
			return E_POINTER;
		*piid2 = *piid;
		return S_OK;
	}
	STDMETHOD(GetConnectionPointContainer)(IConnectionPointContainer** ppCPC)
	{
		T* pT = static_cast<T*>(this);
		// No need to check ppCPC for NULL since QI will do that for us
		return pT->QueryInterface(IID_IConnectionPointContainer, (void**)ppCPC);
	}
	STDMETHOD(Advise)(IUnknown* pUnkSink, DWORD* pdwCookie);
	STDMETHOD(Unadvise)(DWORD dwCookie);
	STDMETHOD(EnumConnections)(IEnumConnections** ppEnum);
	CDV m_vec;

	// Using the GIT for access across threads:
	IGlobalInterfaceTable *m_pGIT;

	// Need a separate critical section object:
	CComGlobalsThreadModel::AutoCriticalSection m_CPMTCritSec;

	// For each generated function (named Fire_{EventName}) within the proxy class: 
	// Comment out the following lines, within the generated for loop: 
	//	pT->Lock();
	//	CComPtr<IUnknown> sp = m_vec.GetAt(nConnectionIndex);
	//	pT->Unlock();
	// 
	// Instead, use this function as follows:
	//	CComPtr<IUnknown> sp;
	//	sp.Attach (GetInterfaceAt(nConnectionIndex));
	LPUNKNOWN GetInterfaceAt(int nConnectionIndex);
};

template <class T, const IID* piid, class CDV>
IConnectionPointImplMT<T, piid, CDV>::IConnectionPointImplMT()
{
	// Get the GIT per-process singleton:
	CoCreateInstance(CLSID_StdGlobalInterfaceTable, 0,
		CLSCTX_INPROC_SERVER, 
		IID_IGlobalInterfaceTable, 
		reinterpret_cast<void**>(&m_pGIT));
	ATLASSERT(m_pGIT != NULL);
}

template <class T, const IID* piid, class CDV>
IConnectionPointImplMT<T, piid, CDV>::~IConnectionPointImplMT()
{
	// Revoke interfaces from the GIT:
	DWORD* pDWCookie = (DWORD *)(m_vec.begin());
	while (pDWCookie < (DWORD *) (m_vec.end()))
	{
		if (*pDWCookie != NULL)
		{
			m_pGIT->RevokeInterfaceFromGlobal(*pDWCookie);
		}
		pDWCookie++;
	}
}

template <class T, const IID* piid, class CDV>
STDMETHODIMP IConnectionPointImplMT<T, piid, CDV>::Advise(IUnknown* pUnkSink,
	DWORD* pdwCookie)
{
	IUnknown* p;
	HRESULT hRes = S_OK;
	if (pUnkSink == NULL || pdwCookie == NULL)
		return E_POINTER;
	IID iid;
	GetConnectionInterface(&iid);
	hRes = pUnkSink->QueryInterface(iid, (void**)&p);
	if (SUCCEEDED(hRes))
	{
		m_CPMTCritSec.Lock();
		DWORD dwGITCookie;
		hRes = m_pGIT->RegisterInterfaceInGlobal(
			p, iid, &dwGITCookie);
		if(hRes == S_OK)
		{
			// Using the CCom(Dynamic)UnkArray to store the cookie instead of an IUnknown *:
			*pdwCookie = m_vec.Add(reinterpret_cast<IUnknown *>(dwGITCookie));
			hRes = (*pdwCookie != NULL) ? S_OK : CONNECT_E_ADVISELIMIT;

			if (hRes != S_OK)
				m_pGIT->RevokeInterfaceFromGlobal(dwGITCookie);
		}
		m_CPMTCritSec.Unlock();
		// GIT will have AddRef'ed p:
		p->Release();
	}
	else if (hRes == E_NOINTERFACE)
		hRes = CONNECT_E_CANNOTCONNECT;
	if (FAILED(hRes))
		*pdwCookie = 0;
	return hRes;
}

template <class T, const IID* piid, class CDV>
STDMETHODIMP IConnectionPointImplMT<T, piid, CDV>::Unadvise(DWORD dwCookie)
{
	m_CPMTCritSec.Lock();
	DWORD dwGITCookie = (DWORD)_CDV::GetUnknown(dwCookie);
	HRESULT hRes = m_vec.Remove(dwCookie) ? S_OK : CONNECT_E_NOCONNECTION;
	m_CPMTCritSec.Unlock();
	if (hRes == S_OK && dwGITCookie != NULL)
	{
		hRes = m_pGIT->RevokeInterfaceFromGlobal(dwGITCookie);
	}

	return hRes;
}

template <class T, const IID* piid, class CDV>
STDMETHODIMP IConnectionPointImplMT<T, piid, CDV>::EnumConnections(
	IEnumConnections** ppEnum)
{
	if (ppEnum == NULL)
		return E_POINTER;
	*ppEnum = NULL;
	CComObject<CComEnumConnections>* pEnum = NULL;
	ATLTRY(pEnum = new CComObject<CComEnumConnections>)
	if (pEnum == NULL)
		return E_OUTOFMEMORY;
	m_CPMTCritSec.Lock();
	CONNECTDATA* pcd = NULL;
	ATLTRY(pcd = new CONNECTDATA[m_vec.end()-m_vec.begin()])
	if (pcd == NULL)
	{
		delete pEnum;
		m_CPMTCritSec.Unlock();
		return E_OUTOFMEMORY;
	}
	CONNECTDATA* pend = pcd;
	// Copy the valid CONNECTDATA's
	for (DWORD* pDWCookie = (DWORD *)(m_vec.begin());pDWCookie<(DWORD *)(m_vec.end());pDWCookie++)
	{
		if (*pDWCookie != NULL)
		{
			IID iid;
			GetConnectionInterface(&iid);
			IUnknown *pUnk;

			HRESULT hr = m_pGIT->GetInterfaceFromGlobal(
				*pDWCookie, iid, reinterpret_cast<void **>(&pUnk));

			if(hr == S_OK)
			{
				// AddRef() implicit in GetInterfaceFromGlobal():
				pend->pUnk = pUnk;
				pend->dwCookie = _CDV::GetCookie(reinterpret_cast<IUnknown **>(pDWCookie));
				pend++;
			}
		}
	}
	// don't copy the data, but transfer ownership to it
	pEnum->Init(pcd, pend, NULL, AtlFlagTakeOwnership);
	m_CPMTCritSec.Unlock();
	HRESULT hRes = pEnum->_InternalQueryInterface(IID_IEnumConnections, (void**)ppEnum);
	if (FAILED(hRes))
		delete pEnum;
	return hRes;
}

template <class T, const IID* piid, class CDV>
LPUNKNOWN IConnectionPointImplMT<T, piid, CDV>::GetInterfaceAt(
	int nConnectionIndex)
{
	m_CPMTCritSec.Lock();

	LPUNKNOWN pUnk = NULL;
	// IConnectionPointImplMT Vector stores DWORDs instead of IUnknown pointers, 
	// explicit cast required:
	DWORD dwGITCookie = (DWORD)(m_vec.GetAt(nConnectionIndex));
	if (dwGITCookie != NULL)
	{
		IID iid;
		GetConnectionInterface(&iid);
		HRESULT hr = m_pGIT->GetInterfaceFromGlobal(
			dwGITCookie, iid, reinterpret_cast<void **>(&pUnk));
		ATLASSERT(hr == S_OK);
	}

	m_CPMTCritSec.Unlock(); 

	return pUnk;
}

#endif // __CPIMPLMT_H__
