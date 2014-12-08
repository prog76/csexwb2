////////////////////////////////////////////////////////////////////////////////
// ATL/AUX -- COM/C++ Exception handling & diagnostics
// Copyright (c) by Andrew Nosenko (andien@geocities.com), 1999
// http://www.geocities.com/~andien/atlaux.htm
// Version: 1.00.0001

/* Change Log:
1.00.0001
  - _CATCH_ANY added / catch(...) /
  - _CATCH_ALL() is defined as _CATCH_COM() _CATCH_AFX() _CATCH_ANY() 
1.00.0000
  - initial release
*/

#pragma once
#ifndef _AUXEH_H
#define _AUXEH_H

#ifndef _INC_COMDEF 
  #error You should #include <comdef.h> (VC COM support) before.
#endif

#ifndef _AUX_ATL_INDEPENDENT
  #error You should #include <AtlAux.h> (ATL/AUX main header) before.
#endif

#if (_MSC_VER >= 1200)  // VC6 or greater
  #pragma warning(push)
#endif    
#pragma warning(disable : 4290) // C++ Exception Specification ignored

inline AUXAPI_(void) AuxSetComErrorInfo(const _com_error& e) throw() {
  IErrorInfo* pErrorInfo = e.ErrorInfo();
  SetErrorInfo(0, pErrorInfo);
  if ( pErrorInfo ) 
    pErrorInfo->Release();
}

inline AUXAPI_(void) AuxRaiseComError(HRESULT hr) throw(_com_error) {
  void __stdcall _com_raise_error(HRESULT, IErrorInfo*) throw(_com_error); // from COMMSUPP.LIB
  IErrorInfo* pErrorInfo = NULL;
  GetErrorInfo(0, &pErrorInfo);
  if ( pErrorInfo ) {
    // cannot check for ISupportErrorInfo as there is no the interface
    // but put a simple check for FACILITY_DISPATCH:
    // isn't it a trashy ErrorInfo?
    if ( HRESULT_FACILITY(hr) != FACILITY_DISPATCH ) {
      // yes, don't consider it
      // SetErrorInfo(0, pErrorInfo);
      pErrorInfo->Release();
      pErrorInfo = NULL;
    }
  }
  _com_raise_error(hr, pErrorInfo); // pass pErrorInfo ownership
}

#define _CATCH_COM() \
  catch (_com_error& e) { \
    AuxSetComErrorInfo(e); \
    return _HR(e.Error()); } 

#define _CATCH_ANY() \
  catch ( ... ) { \
    HRESULT hr = HRESULT_FROM_WIN32(GetLastError()); \
    if ( hr == NOERROR ) hr = E_UNEXPECTED; \
    return _HR(hr); }

#ifdef __AFX_H__ // handle MFC CException

// set COM ErrorInfo from AFX CException
inline AUXAPI_(void) AuxSetAfxErrorInfo(CException* e) throw() {
  ICreateErrorInfo* pICEI = NULL;
  if ( SUCCEEDED(CreateErrorInfo(&pICEI)) )
  {
    USES_CONVERSION;
    TCHAR szBuff[_AUX_MAX_DESC_TEXT]; szBuff[0] = '\0';
    UINT nHelpContext = 0;
    e->GetErrorMessage(szBuff, _countof(szBuff), &nHelpContext);
    CWinApp* pApp = AfxGetApp();
    ASSERT(pApp);
    pICEI->SetSource(T2OLE(pApp->m_pszAppName));
    pICEI->SetDescription(T2OLE(szBuff));
    if ( nHelpContext != 0 && pApp->m_pszHelpFilePath != NULL )
    {
      pICEI->SetHelpContext(0x00030000UL+nHelpContext); // HID_BASE_PROMPT
      pICEI->SetHelpFile(T2OLE(pApp->m_pszHelpFilePath));
    }
		pICEI->SetGUID(IID_NULL);
    IErrorInfo* pErrorInfo = NULL;
    if ( SUCCEEDED(pICEI->QueryInterface(IID_IErrorInfo, (void**)&pErrorInfo)) ) {
      SetErrorInfo(0, pErrorInfo);
      pErrorInfo->Release();
    }
    pICEI->Release();
  }
}

#define _CATCH_AFX() \
  catch ( CException* e ) { \
    AuxSetAfxErrorInfo(e); \
    e->Delete(); \
    return _HR(DISP_E_EXCEPTION); }

#define _SAFE_AFX(exp) \
  try { exp; } _CATCH_AFX()

// helper for _ON_ERROR
#define _ON_ERROR_CATCH_AFX() \
  catch ( CException* e ) { \
    AuxSetAfxErrorInfo(e); \
    e->Delete(); \
    $hr = DISP_E_EXCEPTION; }

#else // no __AFX_H__

#define _CATCH_AFX()
#define _ON_ERROR_CATCH_AFX()

#endif // __AFX_H__

#define _CATCH_ALL() \
  _CATCH_COM() _CATCH_AFX() _CATCH_ANY() 
    
#define _THROW(exp) \
  { HRESULT $hr = (exp); if ( _FAILED($hr) ) AuxRaiseComError($hr); }
  
#define _SAFE(exp) \
  try { exp; } _CATCH_COM()

#define _SAFE_ALL(exp) \
  try { exp; } _CATCH_ALL()

// _ON_ERROR is the universal facility to handle both HRESULT and exception errors.
// The original idea by Dr. John F. Holliday <jholliday@lexcel.com>
// As John noted, this is a real time saver for finding subtle errors that only 
// appear as exceptions. The downside is the amount of code that it generates.
//
// Example:
// _ON_ERROR(p->Test1(), return $hr);
// _ON_ERROR(p->Test2(), return E_FAIL);
// _ON_ERROR(p->Test3(), goto error);

#define _ON_ERROR(exp, action) \
  { \
    HRESULT $hr; \
    try { $hr = (exp); } \
    catch ( _com_error& e ) { \
      AuxSetComErrorInfo(e); \
      $hr = e.Error(); \
    } \
    _ON_ERROR_CATCH_AFX() \
    catch ( ... ) { \
      $hr = HRESULT_FROM_WIN32(GetLastError()); \
      if ( $hr == NOERROR ) $hr = E_UNEXPECTED; \
    } \
    if _FAILED($hr) { action; } \
  }

#if (_MSC_VER >= 1200)  // VC6 or greater
  #pragma warning(pop)
#endif    

#endif // _AUXEH_H
