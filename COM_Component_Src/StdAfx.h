// stdafx.h : include file for standard system include files,
//      or project specific include files that are used frequently,
//      but are changed infrequently

#if !defined(AFX_STDAFX_H__86CFC905_5488_4C8B_BCA0_83C938129AEB__INCLUDED_)
#define AFX_STDAFX_H__86CFC905_5488_4C8B_BCA0_83C938129AEB__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#define STRICT
#ifndef _WIN32_WINNT
#define _WIN32_WINNT 0x0400
#endif
#define _ATL_APARTMENT_THREADED

#include <atlbase.h>

//gCtrlInstances keeps track of each instance of our control
//This global is needed due to the fact that a client may place
//this control on more than one form/dlg or have multiple instances of BW
//hosting in one control. In this case, using one
//global ptr to our control will cause the events to be routed to the
//first control, not the one we want. The control instances (this) is
//added to this array in Constructor and removed in Destructor.
extern CSimpleArray<void*> gCtrlInstances;
//Flag to track registering and unregistering of HTTP/HTTPS protocols
//Can only be done once per DLL load. Effects all instances of WB.
extern BOOL gb_IsHttpRegistered;
extern BOOL gb_IsHttpsRegistered;
//Protocol handling
extern CComPtr<IClassFactory> m_spCFHTTP;
extern CComPtr<IClassFactory> m_spCFHTTPS;

//You may derive a class from CComModule and use it if you want to override
//something, but do not change the name of _Module
extern CComModule _Module;
#include <atlcom.h>

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_STDAFX_H__86CFC905_5488_4C8B_BCA0_83C938129AEB__INCLUDED)
