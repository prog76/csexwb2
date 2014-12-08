////////////////////////////////////////////////////////////////////////////////
// ATL/AUX -- COM/ATL Useful Helpers
// Copyright (c) by Andrew Nosenko (andien@geocities.com), 1997-2000
// http://www.geocities.com/~andien/atlaux.htm
// Version: 1.10.0015
// Look for comments inside

/* Change Log:
1.10.0015
  Added:
  - CAuxGetClassImpl added.
  - CPtr fixed.
1.10.0014
  Added:
  - CAuxSimpleArray, CAuxSimpleMap
  - _R_WIN32_ERROR
  - _S_LAST_ERROR
  - _SALLOC, _RALLOC
  - V_ISIFACE
  - CAutoPtr::Release, CAutoArray::Release
  Updated and fixed:
  - CSinkImpl
  - CAuxByRefVar
  - AuxYield, AuxSleep (WM_CLOSE handling)
  - offsetof
1.10.0012
  - AuxKillTimer added
  - AuxReportError fixed
1.10.0011
  - CAuxByRefVar class added
  - AuxFireOnChanged API added
  - AuxYield, AuxSleep API added
  - AuxIsProxy API added
  - V_ISEMPTY, V_ISBSTR, V_ISBOOL(v), V_ISDISPATCH, V_ISI4, V_ISUNKNOWN macros added.
1.10.0010
  - CPtr<>::CreateObject added
  - AuxFormatString API added
1.10.0009
  - AuxLoadString API added
  - AuxCloneObject API added
  - AuxObjectQS API added
  - CAuxHold class and AuxHold API added
  - IPersistPropertyBag_Save fixed to support ATL3 data map
1.10.0007
  - CRefCntImpl/CPtr
  - CStlAware is revised for CComBSTR; CStlAware is renamed to CStlAdapt
    (CStlAware is #defined as CStlAdapt for compatibility)
1.10.0006
  - CAuto - 3rd param updated to work with VC6 compiler
  - IPersistPropertyBag_Load updated to work with VT_BSTR and VT_VARIANT class members (ATL3 only).
  - _R_LAST_ERROR added
1.10.0005
  - new header file added to distribution: AuxEH.h (exception handling)
  - aux_error_message is revised
  - VarCmp fix revised
1.10.0004
  - Unicode portability fix (sugg. by Shimon Crown <shimonc@tici.co.il>)
  - CAuto changed (now derives from Dtor)
1.10.0003
  - IPersistPropertyBagHelper is reworked to be compatible with ATL3
    (and its name changed to CAuxPersistPropertyBagImpl)
1.10.0002
   - aux_report_failure updated to preserve GetLastError value
   - _R_FALSE
1.10.0001
  - AuxQI is defined conditionally
  - VarCmp fix revised
1.10.0000
  - The code was splitted by two part: self-dependent and ATL-dependent ones,
    updated for more general ATL3 compliance
  - AuxCrt.cpp - new module added, custom _ATL_MIN_CRT support for
    global C++ object consruction/destruction
  - CSinkImpl - ATL3-like event sink class added, TBD.
  - CSinkBase - changed
  - AuxFireEvent - API added
  - CAuxObjectStack - class added
  - CAuxEnum - adopted for ATL3 (sugg. by Vladyslav Hrybok <vlad@atlcon.net>)
  - _R_OK, _R_FAIL (return), _BP (HRESULT breakpoint) - macros added
  - AuxQS (QueryService) - API added
  - Known ATL3 ['VarCmp' : function does not take 3 parameters] bug workaround
  - Several names changed to be more consistent, sorry for inconveniences
1.02.0002
  - StrLen, StrCmp, StrLower, StrUpper, LowerCase, UpperCase - APIs added
  - AUXAPI_, AUXAPI, AUXAPIV_, AUXAPIV - macros added  
1.02.0001
  - minor doc clean-ups
  - COM_MAP_DUAL_ENTRY, COM_MAP_DUAL_ENTRY_IID added
1.02.0000
  - NOTE: minor portability problems may arise
  - ATL3 adoption to accomodate changes made to END_COM_MAP
    (ATL team has added IUnknown ambiguity resolution there):
      DECLARE_UNKNOWN (not required anymore),
      BEGIN_COM_MAP_UNKIMPL/END_COM_MAP_UNKIMPL of CUnkImpl
  - IPtr::CopyTo, IPtr::IsEqualObject
  - CComLock renamed to CAuxLock, because of name colisions.
    I apologize for inconveniences
1.01.0006
  - New Win32 Callback thunking (cool)
  - _R macros added
  - CStlAdapt minor clean-ups
1.01.0005
  - minor Unicode portability fix (sugg. by Darryl Yust <darrylyu@microsoft.com>)
1.01.0004
  - _iface_name doesn't rely on CRegKey anymore
1.01.0003
  - COMSUPP.LIB dispinterface helpers prototyped
1.01.0002
  - CAuto-, CAutoPtr::operator= changed to be consistent with IPtr,
    operator bool() added.
1.01.0001
  - _S_VAR fixed (sugg. by Jared Bluestein <Jared@coopresources.net>)
1.01.0000
  - CUnkImpl, single-step IUnknown implementation
  - CopyInterface, CopyInterfaceQI
  - error diagnostics significantly improved (_error_message) and extended:
    _HR, _S, _S_VAR, _REPORT, ASSERT_HR, VERIFY_HR
  - GetLastResult(), CAuxGuids::ReportErrorf
  - CModuleLock
  - _COM_SMARTPTR_TYPEDEF is defined to use IPtr by default
1.00.0057
  - DECLARE_DEFWNDPROC for message crackers
1.00.0056
  - ASSERT, VERIFY (to reduce the number of helper includes)
1.00.0054
  - CStlAdapt fix (default constructor added)
  - CAuto fix
  - IPtr(int null)
1.00.0053
  - CAuto::operator&, CCoFreeDtor
1.00.0051
  - _FAILED, _SUCCEEDED error diagnostics added
1.00.0050
  - error checking enhanced. Now you can click at error line in debug output window
  and you get to corresponding point of code!
1.00.0049
  - Alternative QI: _IUnknown (TBD)
1.00.0047
  - GetLock bug fixed. Assembling this header first time, I made some stupid
  changes over working code.
  - AuxQI changed to be compatible with querying CCom[QI]Ptr
  - V_FALSE/V_TRUE added. Should have been done a long ago
*/

#ifndef _MSC_VER
  #error This should be significantly reworked for non-MSC compiler
#endif

////////////////////////////////////////////////////////////////////////////////
// ********************** This part is ATL-independed **************************
#ifndef _AUX_ATL_INDEPENDENT
#define _AUX_ATL_INDEPENDENT

#define AUXAPI                    HRESULT __stdcall
#define AUXAPI_(x)                x __stdcall
#define AUXAPIV                   HRESULT __cdecl
#define AUXAPIV_(x)               x __cdecl

////////////////////////////////////////////////////////////////////////////////
/* We can substitute DEFINE_GUID_COMDAT instead of DEFINE_GUID:

#undef DEFINE_GUID
#define DEFINE_GUID DEFINE_GUID_COMDAT
//////////////////////////////////////////////////////////////////////////////*/

#ifndef DEFINE_GUID_COMDAT
  #define DEFINE_GUID_COMDAT(name, l, w1, w2, b1, b2, b3, b4, b5, b6, b7, b8) \
     extern "C" const GUID __declspec(selectany) name \
        = { l, w1, w2, { b1, b2,  b3,  b4,  b5,  b6,  b7,  b8 } }
#endif

////////////////////////////////////////////////////////////////////////////////
/* Seamless error handling.

To use with Smart/Auto pointers to avoid complex branches over right screen side.
Debug output formatting is done the way Developer Studio understands, so it opens
the source file and positions the cursor at the place where an error has occured.

/* Example:

  HRESULT Foo() {
    IClassFactoryPtr class;
    _S( CoGetClassObject(CLSID_Foo, CLSCTX_ALL, class.GetIID(), (void**)&class) );
    IFooPtr foo;
    _S( class->CreateInstance(NULL, foo.GetIID(), (void**)&foo) );
    ...
    _R( foo->Foo() );
  }

  // no HRESULT return, but have a nice diagnostics:
  if ( _FAILED(foo->Foo()) ) return;

  // C++ constructor:

  CFoo::CFoo(HRESULT& hr) {
    _S_VAR(hr, m_bar.CreateInstance(CLSID_Bar));
    ...
    hr = S_OK;
  }

//////////////////////////////////////////////////////////////////////////////*/

#if !defined(_INC_CRTDBG) && !defined(_ATL_NO_DEBUG_CRT)
// Warning: if you define _ATL_NO_DEBUG_CRT, you will have
// to provide your own definition of the _ASSERTE(x) macro
// in order to compile ATL/AUX
  #include <crtdbg.h>
#endif

#ifdef _M_IX86
  #define _DBGBRK() __asm int 3
#else
  #define _DBGBRK() DebugBreak()
#endif

#ifndef _AUX_MAX_IFACE_NAME
  #define _AUX_MAX_IFACE_NAME 100
#endif

#ifndef _AUX_MAX_DESC_TEXT
  #define _AUX_MAX_DESC_TEXT 1024
#endif

#ifdef _DEBUG

inline AUXAPI_(void) aux_iface_name(TCHAR szName[], REFIID iid)
{
  HKEY hkey = NULL, hkeyIface = NULL;
  DWORD dwType, dw = _AUX_MAX_IFACE_NAME; // size of szName;

  if ( IsEqualGUID(GUID_NULL, iid) )
    lstrcpy(szName, TEXT("IID_NULL"));
  else {
    LPOLESTR pszGUID = NULL;
    if ( FAILED(StringFromCLSID(iid, &pszGUID)) ) _ASSERTE(FALSE);
    TCHAR szGuid[64];
#ifdef _UNICODE
    lstrcpyW(szGuid, pszGUID);
#else
    szGuid[0] = '\0';
    WideCharToMultiByte(CP_ACP, 0, pszGUID, -1, szGuid, 64, NULL, NULL);
#endif
    CoTaskMemFree(pszGUID);

    // Attempt to find it in the Interfaces section
    RegOpenKeyEx(HKEY_CLASSES_ROOT, TEXT("Interface"), 0, KEY_ALL_ACCESS, &hkey);
    RegOpenKeyEx(hkey, szGuid, 0, KEY_ALL_ACCESS, &hkeyIface);
    RegCloseKey(hkey);
    if ( hkeyIface ) {
      *szName = 0;
      RegQueryValueEx(hkeyIface, (LPTSTR)NULL, NULL, &dwType, (LPBYTE)szName, &dw);
      RegCloseKey(hkeyIface);
    }
    else {
      // Attempt to find it in the CLSID section
      RegOpenKeyEx(HKEY_CLASSES_ROOT, TEXT("CLSID"), 0, KEY_ALL_ACCESS, &hkey);
      RegOpenKeyEx(hkey, szGuid, 0, KEY_ALL_ACCESS, &hkeyIface);
      RegCloseKey(hkey);
      if ( hkeyIface ) {
        *szName = 0;
        RegQueryValueEx(hkeyIface, (LPTSTR)NULL, NULL, &dwType, (LPBYTE)szName, &dw);
        RegCloseKey(hkeyIface);
      }
      else
        lstrcpy(szName, szGuid);
    }
  }
}

inline AUXAPI_(LPTSTR ) aux_error_message(HRESULT hr)
{
  // check if an Automation error is set
  LPTSTR pszMsg = NULL;
  IErrorInfo* pei = NULL;
  GetErrorInfo(0, &pei);
  if ( pei ) {
    SetErrorInfo(0, pei); // set it back
    IID iid = IID_NULL;
    pei->GetGUID(&iid);
    BSTR source = NULL;
    pei->GetSource(&source);
    if ( !source ) source = SysAllocString(L"Unknown class");
    BSTR desc = NULL;
    pei->GetDescription(&desc);
    if ( !desc ) desc = SysAllocString(L"No description");
    pei->Release();

    TCHAR szIface[_AUX_MAX_IFACE_NAME];
    aux_iface_name(szIface, iid);

    pszMsg = (LPTSTR)LocalAlloc(0,
      (16+lstrlen(szIface)+SysStringLen(source)+SysStringLen(desc))*sizeof(TCHAR));
    if ( !pszMsg ) _ASSERTE(FALSE);
    wsprintf(pszMsg, TEXT("%ls/%s: %ls"), source, szIface, desc);
    SysFreeString(source);
    SysFreeString(desc);
  }
  // try to find system-provided message
  else {
    FormatMessage(
      FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM,
      NULL, hr, MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
      (LPTSTR)&pszMsg, 0, NULL);
    if ( pszMsg == NULL) {
      pszMsg = (LPTSTR)LocalAlloc(0, 32*sizeof(TCHAR));
      if ( !pszMsg ) _ASSERTE(FALSE);
      if ( HRESULT_FACILITY(hr) == FACILITY_DISPATCH )
        wsprintf(pszMsg, TEXT("IDispatch error #%d"), HRESULT_CODE(hr));
      else
        wsprintf(pszMsg, TEXT("Unknown error 0x%08X"), hr);
    }
  }

  int len = lstrlen(pszMsg)-1;
  if ( len >= 0 && pszMsg[len] == '\n' ) pszMsg[len] = '\0';

  return pszMsg;
}

inline AUXAPI aux_report_failure(HRESULT hr, LPCSTR file, int line) throw()
{
  if ( FAILED(hr) ) {
    DWORD dwLastError = GetLastError();
    LPTSTR pszMsg = aux_error_message(hr);
    TCHAR szBuff[_AUX_MAX_DESC_TEXT];
    wsprintf(szBuff, TEXT("%hs(%d) : COM Error #%08X [%s]\n"), file, line, hr, pszMsg);
    OutputDebugString(szBuff);
    LocalFree((HLOCAL)pszMsg);
    SetLastError(dwLastError);
  }
  return hr;
}

inline AUXAPI aux_report_failure_break(HRESULT hr, LPCSTR file, int line) throw()
{
  if ( FAILED(aux_report_failure(hr, file, line)) ) _DBGBRK();
  return hr;
}

#define _HR(exp) aux_report_failure(exp, __FILE__, __LINE__)

#define _BP(exp) aux_report_failure_break(exp, __FILE__, __LINE__)

#else // not _DEBUG

#define _HR(exp) (exp)

#define _BP(exp) (exp)

#endif // _DEBUG

#define _SUCCEEDED(exp)     SUCCEEDED(_HR(exp))

#define _FAILED(exp)        FAILED(_HR(exp))

#define _SUCCEED_VAR(lvalue, exp) \
                            { if ( _FAILED((lvalue) = (exp)) ) return; }

#define _SUCCEED(exp)       { HRESULT $hr$ = (exp); if ( _FAILED($hr$) ) return $hr$; }

#define _RETURN(exp)        return _HR(exp)

#define _R_FALSE            return S_FALSE
#define _R_OK               return S_OK
#define _R_FAIL             _R( E_FAIL )
#define _R_WIN32_ERROR(e)   _R( HRESULT_FROM_WIN32(e) )
#define _R_LAST_ERROR       _R_WIN32_ERROR(GetLastError())
#define _S_LAST_ERROR()     _S( HRESULT_FROM_WIN32(GetLastError()) )

#define _SALLOC(exp)        if ( !(exp) ) _R( E_OUTOFMEMORY ); else;
#define _RALLOC(exp)        _R( (exp)? S_OK: E_OUTOFMEMORY )

#define _S_ALLOC            _SALLOC
#define _R_ALLOC            _RALLOC

#define _S_TEST             _SALLOC
#define _R_TEST             _RALLOC

#define _S                  _SUCCEED
#define _S_VAR              _SUCCEED_VAR                
#define _R                  _RETURN                   

// Example: _REPORT(p->Test(), Errorf(IDP_TESTFAILED))
#define _REPORT(exp, ret_exp) { if ( _FAILED(exp) ) return _HR(ret_exp); }

// simple helpers
inline AUXAPI AuxGetLastResult(DWORD dwErr = GetLastError()) throw() {
  return HRESULT_FROM_WIN32(dwErr);
}

inline void AuxClearErrorInfo() throw() {
  SetErrorInfo(0, NULL);
}

////////////////////////////////////////////////////////////////////////////////
/* Smart pointer class. Was designed to overcome v2 Com[QI]Ptr limitness.

Incapsulates IID handling and should be interoperable with CCom[QI]Ptr, _com_ptr_t.
Pay special attention to IPtr<IUnknown>: it will still query for IID_IUnknown in
template constructor and operator=. This is by design, to make possible the object
identity testing. If you don't need this, explicitly cast an interface to IUnknown*
when passing it to constructor or operator=.

You may '#define _COM_SMARTPTR IPtr' if you want.

With ATL project, a useful trick might be to ignore MIDL-generated header
and import generated typelib directly with custom _COM_SMARTPTR as IPtr:

  #include <AtlAux.h> // _COM_SMARTPTR is defined here as IPtr by default

  #import "MyTypeLib.tlb" \
    raw_interfaces_only, \
    named_guids, \
    no_namespace

You'll get all the interfaces/SPs automaticaly defined, e. g. IMyIfacePtr.
This way you benefit from #import and get rid of COMSUPP.LIB/CRT dependency.

Currently, however, I'm using another approach: Smart Pointer Generator.
More info on this: http://www.geocities.com/~andien/atlaux.htm#IIDsSPs
//////////////////////////////////////////////////////////////////////////////*/

template<typename I, const GUID* PIID = &__uuidof(I)>
class IPtr
{
public:
  class _NoRefI: public I
  {
    STDMETHOD_(ULONG, AddRef)()=0;
    STDMETHOD_(ULONG, Release)()=0;
  };

  static const GUID& GetIID() { return *PIID; }

  IPtr() throw(): p(NULL) {}
  IPtr(I* ptr, bool fAddRef) throw() { 
    if ( (p = ptr) && fAddRef ) p->AddRef(); }
  IPtr(I& ref) throw(): p(NULL) { 
    ref.QueryInterface(GetIID(), (void**)&p); }
  template<typename Ptr> IPtr(const Ptr& ptr) throw(): p(NULL) {
    // remove "constness" to be compatible with v2 CCom[QI]Ptr
    if ( const_cast<Ptr&>(ptr) )
      const_cast<Ptr&>(ptr)->QueryInterface(GetIID(), (void**)&p);
  }
  template<> IPtr(int null) throw(): p(NULL) { 
    _ASSERTE(null==0); }
  template<> IPtr(I* ptr) throw() { 
    if ( (p = ptr) ) p->AddRef(); }
  template<> IPtr(const IPtr& ptr) throw() { 
    if ( (p = ptr.p) ) p->AddRef(); }

  explicit IPtr(const CLSID& clsid, IUnknown* pOuter = NULL, DWORD dwClsContext = CLSCTX_ALL) throw()
    : p(NULL)
  {
    CreateInstance(clsid, pOuter, dwClsContext);
  }
  explicit IPtr(LPOLESTR str, IUnknown* pOuter = NULL, DWORD dwClsContext = CLSCTX_ALL) throw()
    : p(NULL)
  {
    CreateInstance(str, pOuter, dwClsContext);
  }

  ~IPtr() throw() { if ( p ) p->Release(); }

  operator I*() const throw() { return p; }
  I& operator*() const throw() { _ASSERTE(p!=NULL); return *p; }
  I** operator&() throw() { _ASSERTE(p==NULL); return &p; }
  _NoRefI* operator->() const throw() { _ASSERTE(p!=NULL); return (_NoRefI*)p; }
  bool operator!() const throw() { return p == NULL; }

  template<typename Ptr> I* operator=(const Ptr& ptr) throw()
  {
    if ( p ) { p->Release(); p = NULL; }
    // remove "constness" to be compatible with v2 CCom[QI]Ptr
    if ( const_cast<Ptr&>(ptr) )
      const_cast<Ptr&>(ptr)->QueryInterface(GetIID(), (void**)&p);
    return p;
  }
  template<> I* operator=(I* ptr) throw() {
    if ( p ) p->Release();
    if ( (p = ptr) ) p->AddRef();
    return p;
  }
  template<> I* operator=(const IPtr& ptr) throw()
  {
    return operator=(ptr.p);
  }

  void Attach(I* ptr) throw() { *this = ptr; }
  void Attach(I* ptr, bool fAddRef) throw() {
    if ( p ) p->Release();
    p = ptr;
    if ( fAddRef && p ) p->AddRef();
  }
  I* Detach() throw() { I* tmp = p; p = NULL; return tmp; }
  void Release() throw() { if ( p ) p->Release(); p = NULL; }

  HRESULT CreateInstance(const CLSID& rclsid, IUnknown* pOuter = NULL, DWORD dwClsContext = CLSCTX_ALL) throw()
  {
    return CoCreateInstance(rclsid, pOuter, dwClsContext, GetIID(), reinterpret_cast<void**>(&p));
  }
  HRESULT CreateInstance(LPOLESTR clsidString, IUnknown* pOuter = NULL, DWORD dwClsContext = CLSCTX_ALL) throw()
  {
    if ( clsidString == NULL ) return E_INVALIDARG;
    CLSID clsid;
    HRESULT hr;
    if ( clsidString[0] == '{' ) hr = CLSIDFromString(clsidString, &clsid);
    else hr = CLSIDFromProgID(clsidString, &clsid);
    if ( FAILED(hr) ) return hr;
    return CreateInstance(clsid, pOuter, dwClsContext);
  }

  template<typename Interface>
  HRESULT QueryInterface(Interface** pp) const throw() {
    _ASSERTE(p);
    return p->QueryInterface(__uuidof(Interface), (void**)pp);
  }

  template<typename Interface>
  HRESULT CopyTo(Interface** pp) const throw()
  {
    _ASSERTE(pp != NULL);
    if ( pp == NULL ) return E_POINTER;
    if ( p == NULL ) {
      *pp = NULL;
      return S_OK;
    }
    return QueryInterface(pp);
  }

  template<>
  HRESULT CopyTo(I** pp) const throw()
  {
    _ASSERTE(pp != NULL);
    if ( pp == NULL ) return E_POINTER;
    if ( (*pp = p) )
      p->AddRef();
    return S_OK;
  }

  // Compare two objects for equivalence
  bool IsEqualObject(IUnknown* pOther) const throw()
  {
    if ( p == pOther )
      return true; // they are equal
    if ( p == NULL || pOther == NULL )
      return false; // one is NULL the other is not

    IPtr<IUnknown> unk1, unk2;
    p->QueryInterface(IID_IUnknown, (void**)&unk1);
    pOther->QueryInterface(IID_IUnknown, (void**)&unk2);
    return unk1 == unk2;
  }

public:
  I* p;
};

////////////////////////////////////////////////////////////////////////////////
// Define _COM_SMARTPTR_TYPEDEF via IPtr and don't include <comdef.h> at all.
// Use _AUX_NO_COM_SMARTPTR_TYPEDEF to disable this.

#if !defined(_AUX_NO_COM_SMARTPTR_TYPEDEF) && !defined(_COM_SMARTPTR_TYPEDEF)
  #ifndef _COM_SMARTPTR
    #define _COM_SMARTPTR IPtr
  #endif
  #define _COM_SMARTPTR_TYPEDEF(Interface, IID) \
    typedef _COM_SMARTPTR<Interface, &IID> Interface ## Ptr;
#endif

#define _COM_SMARTPTR_TYPEDEF_EX(iface) \
  _COM_SMARTPTR_TYPEDEF(iface, IID_##iface)


////////////////////////////////////////////////////////////////////////////////
// CAuto
// Templatized class to release any acquired system resource automatically
// (KERNEL/USER/GDI object, memory, etc.)
// Use it for local and embedded vars. It isn't designed for use with STL.

template<typename T>
struct CAutoDtor {
  static void Destroy(T v); // no implementation
};

// Specialize CAutoDtor<>::Destroy for any unambiguous resource type:
template<> inline void CAutoDtor<HANDLE>::Destroy(HANDLE v) {
  if ( !CloseHandle(v) ) _ASSERTE(FALSE); }

// Or use custom dtor class with CAuto<>

// COM allocted memory 
// CAuto<LPOLESTR, CCoFreeDtor> olestr;
struct CCoFreeDtor {
  static void Destroy(LPVOID v) { CoTaskMemFree(v); }
};

/* Cut & paste samples
// File handle
typedef CAuto<HANDLE, CAutoDtor<HANDLE>, INVALID_HANDLE_VALUE> CAutoFile;

// File mapping view
struct CMapDtor {
  static void Destroy(LPCVOID v) { UnmapViewOfFile(v); }
};
typedef CAuto<LPCVOID, CMapDtor> CAutoMap;

// SOCKET
struct CSocketDtor {
  static void Destroy(SOCKET v) { closesocket(v); }
};
typedef CAuto<SOCKET, CSocketDtor, INVALID_SOCKET> CAutoSocket;

// OleAut TYPEATTR
struct CTADtor {
  ITypeInfoPtr m_p;
  template<class Ptr> CTLADtor(const Ptr& p): m_p(p) {}
  void Destroy(TYPEATTR* v) { m_p->ReleaseTypeAttr(v); }
};
CAuto<TYPEATTR*, CTADtor> typeAttr(pTypeAttr, CTADtor(pTypeInfo));

//////////////////////////////////////////////////////////////////////////////*/

template< typename T, class Dtor = CAutoDtor<T>, int invalid = NULL>
class CAuto: public Dtor {
  // disallow illegal constructions
  void operator=(const CAuto&) throw();
  CAuto(const CAuto&) throw();
public:
  CAuto(Dtor dtor = Dtor()) throw(): Dtor(dtor), v(T(invalid)) {}
  CAuto(T val, Dtor dtor = Dtor()) throw(): Dtor(dtor), v(val) {}
  bool operator!() const throw() { return v == T(invalid); }
  operator bool() const throw() { return v != T(invalid); }
  operator T() const { return v; }
  T operator=(const T val) throw() { if ( v != T(invalid) ) Destroy(v); v = val; return v; }
  T* operator&() throw() { _ASSERTE(v == T(invalid)); return &v; }
// #pragma warning(disable: 4284) // CAuto<>::operator ->' is not a UDT or reference to a UDT
  T operator->() const throw() { _ASSERTE(v != T(invalid)); return v; }
  T Detach() { T tmp = v; v = T(invalid); return tmp; }
  ~CAuto() throw() { if ( v != T(invalid) ) Destroy(v); }
  void Release() throw() { if ( v != T(invalid) ) { Destroy(v); v = T(invalid); } }
public:
  typedef T T;
  T v;
};


////////////////////////////////////////////////////////////////////////////////
// CAutoArray & CAutoPtr
// like IPtr<> and CAuto<>, makes a coding really easier

template<typename T>
class CAutoArray {
  // disallow illegal constructions
  void operator=(const CAutoArray&) throw();
  CAutoArray(const CAutoArray&) throw();
public:
  typedef T T;
  CAutoArray() throw(): p(NULL) {}
  CAutoArray(int nSize): p(new T[nSize]) {}
  CAutoArray(T* ptr) throw(): p(ptr) {}
  ~CAutoArray() throw() {
    if ( p ) delete[] p; }
  operator T*() const throw() {
    return p; }
  // template to eliminate ambiguity between operators [] and T*()
  template<typename Index>
  T& operator[](Index i) throw() {
    _ASSERTE(p); return p[i]; }
  template<typename Index>
  const T& operator[](Index i) const throw() {
    _ASSERTE(p); return p[i]; }
  bool operator!() const throw() {
    return p == NULL; }
  CAutoArray& operator=(T* ptr) {
    if ( p ) delete[] p; p = ptr; return *this; }
  T* Detach() {
    T* tmp = p; p = NULL; return tmp; }
  void Release() throw() { 
    if ( p ) { delete [] p; p = NULL; } }
public:
  T* p;
};

template<typename T>
class CAutoPtr {
  // disallow illegal constructions
  void operator=(const CAutoPtr&) throw();
  CAutoPtr(const CAutoPtr&) throw();
public:
  typedef T T;
  CAutoPtr() throw(): p(NULL) {}
  CAutoPtr(T* ptr) throw(): p(ptr) {}
  ~CAutoPtr() throw() {
    if ( p ) delete p; }
  operator T*() const throw() {
    return p; }
  bool operator!() const throw() {
    return p == NULL; }
  T* operator=(T* ptr) {
    if ( p ) delete p; p = ptr; return p; }
/*
Cut & paste:
#pragma warning(disable: 4284) // CAutoPtr<>::operator ->' is not a UDT or reference to a UDT
*/
  T* operator->() const throw() {
    _ASSERTE(p!=NULL); return p; }
  T* Detach() {
    T* tmp = p; p = NULL; return tmp; }
  void Release() throw() { 
    if ( p ) { delete p; p = NULL; } }
public:
  T* p;
};


////////////////////////////////////////////////////////////////////////////////
// Facilitate CComBSTR comparison

inline AUXAPI_(int) CompareBSTR(BSTR str1, BSTR str2) throw()
{
  if (str1 == NULL) return str2 ? -1 : 0;
  if (str2 == NULL) return 1;

  const unsigned int l1 = ::SysStringLen((BSTR)str1);
  const unsigned int l2 = ::SysStringLen((BSTR)str2);

  unsigned int len = l1;
  if (len > l2) len = l2;

  LPCWSTR bstr1 = str1;
  LPCWSTR bstr2 = str2;

  while (len-- > 0) {
    if (*bstr1++ != *bstr2++) {
      return bstr1[-1] - bstr2[-1];
    }
  }

  return (l1 < l2) ? -1 : (l1 == l2) ? 0 : 1;
}

inline AUXAPI CopyBSTR(BSTR* dest, BSTR src) throw() {
  _ASSERTE(dest != NULL);
  if ( !dest ) return E_POINTER;
  if ( src ) {
    if ( !(*dest = SysAllocStringLen((BSTR)src, SysStringLen((BSTR)src))) )
    return E_OUTOFMEMORY;
  }
  else *dest = NULL;
  return S_OK;
}


////////////////////////////////////////////////////////////////////////////////
// CAuxSimpleArray - 'stolen' from ATL3, const referencing added

template <class T>
class CAuxSimpleArray
{
public:
	T* m_aT;
	int m_nSize;
	int m_nAllocSize;

// Construction/destruction
	CAuxSimpleArray() : m_aT(NULL), m_nSize(0), m_nAllocSize(0)
	{ }

	~CAuxSimpleArray()
	{
		RemoveAll();
	}

// Operations
	int GetSize() const
	{
		return m_nSize;
	}

  BOOL Grow() {
		T* aT;
		int nNewAllocSize = (m_nAllocSize == 0) ? 1 : (m_nSize * 2);
		aT = (T*)realloc(m_aT, nNewAllocSize * sizeof(T));
		if(aT == NULL)
			return FALSE;
		m_nAllocSize = nNewAllocSize;
		m_aT = aT;
    return TRUE;
  }

  template<typename A> 
  BOOL Add(const A& t)
	{
		if(m_nSize == m_nAllocSize)
		{
      if ( !Grow() ) return FALSE;
		}
		m_nSize++;
		SetAtIndex(m_nSize - 1, t);
		return TRUE;
	}

  template<typename A> 
	BOOL Remove(const A& t)
	{
		int nIndex = Find(t);
		if(nIndex == -1)
			return FALSE;
		return RemoveAt(nIndex);
	}

	BOOL RemoveAt(int nIndex)
	{
		if(nIndex != (m_nSize - 1))
		{
			m_aT[nIndex].~T();
			memmove(m_aT+nIndex, m_aT+nIndex+1, (m_nSize - (nIndex + 1)) * sizeof(T));
		}
		m_nSize--;
		return TRUE;
	}

	void RemoveAll()
	{
		if(m_aT != NULL)
		{
			for(int i = 0; i < m_nSize; i++)
				m_aT[i].~T();
			free(m_aT);
			m_aT = NULL;
		}
		m_nSize = 0;
		m_nAllocSize = 0;
	}

	T& operator[] (int nIndex) const
	{
		ATLASSERT(nIndex >= 0 && nIndex < m_nSize);
		return m_aT[nIndex];
	}

	T* GetData() const
	{
		return m_aT;
	}

// Implementation
	class Wrapper
	{
	public:
		Wrapper(const T& _t) : t(_t)
		{
		}
		template <class _Ty>
		void *operator new(size_t, _Ty* p)
		{
			return p;
		}
		T t;
	};

  template<typename A> 
	void SetAtIndex(int nIndex, const A& t)
	{
		ATLASSERT(nIndex >= 0 && nIndex < m_nSize);
		new(m_aT+nIndex) Wrapper(t);
	}

  template<typename A> 
	int Find(const A& t) const
	{
		for(int i = 0; i < m_nSize; i++)
		{
			if(m_aT[i] == const_cast<A&>(t))
				return i;
		}
		return -1;  // not found
	}
};


////////////////////////////////////////////////////////////////////////////////
// CAuxSimpleMap - 'stolen' from ATL3, const referencing added

// intended for small number of simple types or pointers
template <class TKey, class TVal>
class CAuxSimpleMap
{
public:
	TKey* m_aKey;
	TVal* m_aVal;
	int m_nSize;

// Construction/destruction
	CAuxSimpleMap() : m_aKey(NULL), m_aVal(NULL), m_nSize(0)
	{ }

	~CAuxSimpleMap()
	{
		RemoveAll();
	}

// Operations
	int GetSize() const
	{
		return m_nSize;
	}

  BOOL Grow() {
		TKey* pKey;
		pKey = (TKey*)realloc(m_aKey, (m_nSize + 1) * sizeof(TKey));
		if(pKey == NULL)
			return FALSE;
		m_aKey = pKey;
		TVal* pVal;
		pVal = (TVal*)realloc(m_aVal, (m_nSize + 1) * sizeof(TVal));
		if(pVal == NULL)
			return FALSE;
		m_aVal = pVal;
		m_nSize++;
	  return TRUE;
  }

  template<typename Key, typename Val> 
	BOOL Add(const Key& key, const Val& val)
	{
    if ( !Grow() ) return FALSE;
		SetAtIndex(m_nSize - 1, key, val);
		return TRUE;
	}

	void Remove(int nIndex)
  {
		ATLASSERT(nIndex >= 0 && nIndex < m_nSize);
		if(nIndex != (m_nSize - 1))
		{
			m_aKey[nIndex].~TKey();
			m_aVal[nIndex].~TVal();
			memmove(m_aKey+nIndex, m_aKey+nIndex+1, (m_nSize - (nIndex + 1)) * sizeof(TKey));
			memmove(m_aVal+nIndex, m_aVal+nIndex+1, (m_nSize - (nIndex + 1)) * sizeof(TVal));
		}
		TKey* pKey;
		pKey = (TKey*)realloc(m_aKey, (m_nSize - 1) * sizeof(TKey));
		if(pKey != NULL || m_nSize == 1)
			m_aKey = pKey;
		TVal* pVal;
		pVal = (TVal*)realloc(m_aVal, (m_nSize - 1) * sizeof(TVal));
		if(pVal != NULL || m_nSize == 1)
			m_aVal = pVal;
		m_nSize--;
  }

  template<typename Key> 
	BOOL Remove(const Key& key)
	{
		int nIndex = FindKey(key);
		if(nIndex == -1)
			return FALSE;
    Remove(nIndex);
		return TRUE;
	}

	void RemoveAll()
	{
		if(m_aKey != NULL)
		{
			for(int i = 0; i < m_nSize; i++)
			{
				m_aKey[i].~TKey();
				m_aVal[i].~TVal();
			}
			free(m_aKey);
			m_aKey = NULL;
		}
		if(m_aVal != NULL)
		{
			free(m_aVal);
			m_aVal = NULL;
		}

		m_nSize = 0;
	}

  template<typename Key, typename Val> 
	BOOL SetAt(const Key& key, const Val& val)
	{
		int nIndex = FindKey(key);
		if(nIndex == -1)
			return FALSE;
		SetAtIndex(nIndex, key, val);
		return TRUE;
	}

  template<typename Key> 
	TVal Lookup(const Key& key) const
	{
		int nIndex = FindKey(key);
		if(nIndex == -1)
			return NULL;    // must be able to convert
		return GetValueAt(nIndex);
	}

  template<typename Val> 
	TKey ReverseLookup(const Val& val) const
	{
		int nIndex = FindVal(val);
		if(nIndex == -1)
			return NULL;    // must be able to convert
		return GetKeyAt(nIndex);
	}

	TKey& GetKeyAt(int nIndex) const
	{
		ATLASSERT(nIndex >= 0 && nIndex < m_nSize);
		return m_aKey[nIndex];
	}

	TVal& GetValueAt(int nIndex) const
	{
		ATLASSERT(nIndex >= 0 && nIndex < m_nSize);
		return m_aVal[nIndex];
	}

// Implementation

	template <typename T>
	class Wrapper
	{
	public:
		Wrapper(const T& _t) : t(_t)
		{
		}
		template <typename _Ty>
		void *operator new(size_t, _Ty* p)
		{
			return p;
		}
		T t;
	};

  template<typename Key, typename Val> 
	void SetAtIndex(int nIndex, const Key& key, const Val& val)
	{
		ATLASSERT(nIndex >= 0 && nIndex < m_nSize);
		new(m_aKey+nIndex) Wrapper<TKey>(key);
		new(m_aVal+nIndex) Wrapper<TVal>(val);
	}

  template<typename Key> 
	int FindKey(const Key& key) const
	{
		for(int i = 0; i < m_nSize; i++)
		{
			if(m_aKey[i] == const_cast<Key&>(key))
				return i;
		}
		return -1;  // not found
	}

  template<typename Val> 
	int FindVal(const Val& val) const
	{
		for(int i = 0; i < m_nSize; i++)
		{
			if(m_aVal[i] == const_cast<Val&>(val))
				return i;
		}
		return -1;  // not found
	}
};


////////////////////////////////////////////////////////////////////////////////
/* Typesafe CoCreateInstance, QueryInterface, _InternalQueryInterface, QueryService

Example:

  ISome* pSome;
  AuxCreateInstance(CLSID_Some, &pSome); // create
  IAnother* pAnother;
  AuxQI(pSome, &pAnother); // query for iface
  ISerive* pSerive;
  AuxQS(pAnother, SID_Service, &pSerive); // query for service

//////////////////////////////////////////////////////////////////////////////*/

template <typename Interface>
inline AUXAPI AuxCreateInstance(
  REFCLSID rclsid, // Class identifier (CLSID) of the object
  Interface** pp, // Address of output variable that receives the interface
  LPUNKNOWN pUnkOuter = NULL, // Pointer to whether object is or isn't part of an aggregate
  DWORD dwClsContext = CLSCTX_ALL) throw() // Context for running executable code
{
  _ASSERTE(pp);
  return CoCreateInstance(rclsid, pUnkOuter, dwClsContext, __uuidof(Interface), (void**)pp);
}

template <typename Ptr, typename Interface>
inline AUXAPI AuxQI(
  const Ptr& src, // Object being queried on (parametrized so class name could be used)
  Interface** pp) throw() // Address of output variable that receives the interface
{
  _ASSERTE(pp);
  _ASSERTE(static_cast<IUnknown*>(*pp) == NULL);
  // remove "constness" to be compatible with v2 CCom[QI]Ptr
  _ASSERTE(const_cast<Ptr&>(src));
  return const_cast<Ptr&>(src)->QueryInterface(__uuidof(Interface), (void**)pp);
}

// ATL _InternalQueryInterface:

template <class Class, typename Interface>
inline AUXAPI AuxInternalQI(
  Class* src, // ATL object being queried on
  Interface** pp) // Address of output variable that receives the interface
{
  _ASSERTE(pp);
  return src->_InternalQueryInterface(__uuidof(Interface), (void**)pp);
}

// QueryService

#ifdef __IServiceProvider_FWD_DEFINED__

template <typename Interface>
inline AUXAPI AuxQS(
  IServiceProvider* sp, 
  REFGUID guidService, 
  Interface** pp) throw()
{
  _ASSERTE(sp);
  _ASSERTE(pp);
  _ASSERTE(static_cast<IUnknown*>(*pp) == NULL);
  return sp->QueryService(guidService, __uuidof(Interface), (void**)pp);
}

template <typename Interface>
inline AUXAPI AuxObjectQS(
  IUnknown* unk, 
  REFGUID guidService, 
  Interface** pp) throw()
{
  _ASSERTE(pp);
  if ( !unk ) return E_POINTER;
  IPtr<IServiceProvider> sp;
  HRESULT hr = AuxQI(unk, &sp);
  if ( FAILED(hr) ) return hr;
  return AuxQS(sp, guidService, pp);
}

#endif  /* __IServiceProvider_FWD_DEFINED__ */

// AuxCopyObject should be able to take anything (yet typesafe!)
template <typename Dest, typename Src>
inline AUXAPI AuxCopyObject(Dest** dest, const Src& src) throw() {
  _ASSERTE(dest != NULL);
  if ( !dest ) return E_POINTER;
  // remove "constness" to be compatible with v2 CCom[QI]Ptr
  if ( (*dest = const_cast<Src&>(src)) )
    (*dest)->AddRef();
  return S_OK;
}

// AuxCopyQI is the safe wrapper on AuxQI.
// It may copy NULL pointer and makes runtime error checking.
template <typename Dest, typename Src>
inline AUXAPI AuxCopyQI(Dest** dest, const Src& src) throw() {
  _ASSERTE(dest != NULL);
  if ( !dest ) return E_POINTER;
  *dest = NULL;
  // remove "constness" to be compatible with v2 CCom[QI]Ptr
  if ( const_cast<Src&>(src) ) return AuxQI(src, dest);
  return S_OK;
}


////////////////////////////////////////////////////////////////////////////////
/* CAuxLock

C++ helps to release critical section automatically.
Example:
  AUXLOCK lock = AuxLock(cs);
<cs> could be an object of the following types:
  ATL CComCriticalSection, CComAutoCriticalSection, CComFakeCriticalSection,
  DirectShow CCritSec, WIN32 CRITICAL_SECTION.
//////////////////////////////////////////////////////////////////////////////*/

class CAuxLockBase {}; // base class for const referencing

// CAuxLock<> could be used directly by instantiating with one of:
// CComObjectRootEx::_CritSec, CComObjectRootEx::_ThreadModel::AutoCriticalSection

template<class T>
class CAuxLock: public CAuxLockBase {
  // disallow illegal constructions
  CAuxLock() throw();
  void operator=(const CAuxLock&) throw();
public:
  CAuxLock(T& sec) throw(): m_sec(sec) { m_sec.Lock(); }
  ~CAuxLock() throw() { m_sec.Unlock(); }
private:
  T& m_sec;
};

template<>
class CAuxLock<CRITICAL_SECTION>: public CAuxLockBase {
  // disallow illegal constructions
  CAuxLock() throw();
  void operator=(const CAuxLock&) throw();
public:
  CAuxLock(CRITICAL_SECTION& sec) throw(): m_sec(sec) { EnterCriticalSection(&m_sec); }
  ~CAuxLock() throw() { LeaveCriticalSection(&m_sec); }
private:
  CRITICAL_SECTION& m_sec;
};

typedef const CAuxLockBase& AUXLOCK;

template<class T> inline CAuxLock<T> AuxLock(T& lock)
  { return CAuxLock<T>(lock); }


////////////////////////////////////////////////////////////////////////////////
/* AuxHold - keeps the object alive for the scope of the call.
(does AddRef/Release on the passed object)
Example: 
  CFoo* p = new CComObject<CFoo>;

  AUXHOLD hold = AuxHold(p);
  -- or --
  CAuxHold<CFoo> hold = p;
//////////////////////////////////////////////////////////////////////////////*/
  
template<class T>
class CAuxHold: public CAuxLockBase {
  CAuxHold() throw();
  void operator=(const CAuxHold&) throw();
  T* m_p;
public:
  CAuxHold(T* p): m_p(p) {
    _ASSERTE(m_p);
    m_p->AddRef(); }
  ~CAuxHold() {
    m_p->Release(); }
};

typedef const CAuxLockBase& AUXHOLD;

template<class T> inline CAuxHold<T> AuxHold(T* p)
  { return CAuxHold<T>(p); }


////////////////////////////////////////////////////////////////////////////////
/* Win32 Callback thunking, the main idea was taken from ATL.

Thunks could be used to turn an object+method pair into a closure that could be
passed to Win32 API requiring a callback address. This is a clever idea of ATL
team, I've only tried to propagate it over a general case.
Thunks are very suitable and efficient way to avoid tiresome TLS/CritSecs/maps
(when providing apartment threading and reentrancy).

CAuxThunk<> is provided for __thiscall methods, CAuxStdThunk<> is for __stdcall.

Here is an example of how to set up Win32 hook the reentrant way, without a
use of global variable:

class CHook:
  public CAuxThunk<CHook>
{
public:
  CHook(): m_hhook(NULL)
  {
    InitThunk((TMFP)CBTHook, this);
  }

  LRESULT CBTHook(int nCode, WPARAM wParam, LPARAM lParam);
  BOOL Hook() {
    m_hook = SetWindowsHookEx(WH_CBT, (HOOKPROC)GetThunk(), NULL, GetCurrentThreadId());
    return (BOOL)m_hook;
  }

  HHOOK m_hhook;
...
};

LRESULT CHook::CBTHook(int nCode, WPARAM wParam, LPARAM lParam)
{
  if ( nCode == HCBT_CREATEWND ) {
    UnhookWindowsHookEx(m_hook);
    HWND hwnd = (HWND)wParam;
    // do whatever we want with HWND
    ...
  }
  return CallNextHookEx(m_hook, nCode, wParam, lParam);
}

Another example. I need to process an event in my IE4 simple object
(windowless) *asynchronously* and use SetTimer API for that.
Unfortunately, TIMERPROC doesn't take any context info.
Here is how it has been solved:

struct TIMEOUT: CAuxThunk<TIMEOUT> {
  UINT m_timerID;
  CONTEXT m_contex;

  TIMEOUT(CONTEXT& contex): m_contex(contex)
  {
    InitThunk((TMFP)TimerProc, this);
  }
  void TimerProc(HWND, UINT, UINT idEvent, DWORD dwTime);
  ...
};

void TIMEOUT::TimerProc(HWND, UINT, UINT idEvent, DWORD dwTime)
{
  AuxKillTimer(NULL, m_timerID); // one-shot callback
  // do any processing task
  ...
  delete this;
}
HRESULT CSimpleObj::Post(CONTEXT& contex) {
  TIMEOUT* pTimeout = new TIMEOUT(context);
  pTimeout->m_timerID = ::SetTimer(NULL, 0, timeout, (TIMERPROC)pTimeout->GetThunk());
}
//////////////////////////////////////////////////////////////////////////////*/

#ifndef _M_IX86
  #pragma message("CAuxThunk/CAuxStdThunk is implemented for X86 only!")
#endif

#pragma pack(push, 1)

template <class T>
class CAuxThunk
{
  BYTE    m_mov;          // mov ecx, %pThis
  DWORD   m_this;         //
  BYTE    m_jmp;          // jmp func
  DWORD   m_relproc;      // relative jmp
public:
  typedef void (T::*TMFP)();
  void InitThunk(TMFP method, const T* pThis)
  {
    union { DWORD func; TMFP method; } addr;
    addr.method = (TMFP)method;
    m_mov = 0xB9;
    m_this = (DWORD)pThis;
    m_jmp = 0xE9;
    m_relproc = addr.func - (DWORD)(this+1);
    FlushInstructionCache(GetCurrentProcess(), this, sizeof(*this));
  }
  FARPROC GetThunk() const {
    _ASSERTE(m_mov == 0xB9);
    return (FARPROC)this; }
};

template <class T>
class CAuxStdThunk
{
  BYTE    m_mov;          // mov eax, %pThis
  DWORD   m_this;         //
  DWORD   m_xchg_push;    // xchg eax, [esp] : push eax
  BYTE    m_jmp;          // jmp func
  DWORD   m_relproc;      // relative jmp
public:
  typedef void (__stdcall T::*TMFP)();
  void InitThunk(TMFP method, const T* pThis)
  {
    union {
      DWORD func;
      TMFP method;
    } addr;
    addr.method = method;
    m_mov = 0xB8;
    m_this = (DWORD)pThis;
    m_xchg_push = 0x50240487;
    m_jmp = 0xE9;
    m_relproc = addr.func - (DWORD)(this+1);
    FlushInstructionCache(GetCurrentProcess(), this, sizeof(*this));
  }
  FARPROC GetThunk() const {
    _ASSERTE(m_mov == 0xB8);
    return (FARPROC)this; }
};

#pragma pack(pop) // CAuxThunk


////////////////////////////////////////////////////////////////////////////////
// AuxYield - sleeps until message arives our timeout occur.

inline AUXAPI_(BOOL) AuxYield(DWORD timeout = INFINITE) throw() {
  if ( MsgWaitForMultipleObjects(0, NULL, FALSE, timeout, QS_ALLINPUT) != WAIT_TIMEOUT ) 
  {
    MSG msg;
    while ( PeekMessage(&msg, NULL, 0, 0, PM_REMOVE) )
    {
      if ( msg.message == WM_QUIT || msg.message == WM_CLOSE ) {
        PostMessage(msg.hwnd, msg.message, msg.wParam, msg.lParam);
        return FALSE;
      }
      TranslateMessage(&msg);
      DispatchMessage(&msg);
    }
  }
  return TRUE;
}

////////////////////////////////////////////////////////////////////////////////
// AuxKillTimer - removes pending WM_TIMER messages

struct AUXMSG: MSG {
  AUXMSG* pPrev;
};

inline AUXAPI_(void) AuxRepostTimerMsg(AUXMSG* pMsg) {
  if ( !pMsg ) return;
  AuxRepostTimerMsg(pMsg->pPrev);
  PostMessage(pMsg->hwnd, pMsg->message, pMsg->wParam, pMsg->lParam);
}

inline AUXAPI_(void) AuxRemoveTimerMsg(HWND hwnd, UINT timerID, AUXMSG* pPrev) {
  AUXMSG msg;
  while ( PeekMessage(&msg, hwnd, WM_TIMER, WM_TIMER, PM_NOYIELD | PM_REMOVE) ) {
    if ( msg.wParam == timerID ) continue;
    msg.pPrev = pPrev;
    AuxRemoveTimerMsg(hwnd, timerID, &msg);
    return;
  }
  AuxRepostTimerMsg(pPrev);
}

inline AUXAPI_(void) AuxKillTimer(HWND hwnd, UINT timerID) {
  KillTimer(hwnd, timerID); // one-shot callback
  if ( HIWORD(GetQueueStatus(QS_TIMER)) )
    AuxRemoveTimerMsg(hwnd, timerID, NULL);
}

inline AUXAPI_(void) AuxKillTimerBabe(HWND hwnd, UINT& timerID) {
  if ( timerID != 0xBABEBABE ) {
    KillTimer(hwnd, timerID); // one-shot callback
    timerID = 0xBABEBABE;
    if ( HIWORD(GetQueueStatus(QS_TIMER)) )
      AuxRemoveTimerMsg(hwnd, timerID, NULL);
  }
}

////////////////////////////////////////////////////////////////////////////////
// AuxYield - sleeps dispatching messages until timeout occur.

inline AUXAPI_(BOOL) AuxSleep(long period)
{
  DWORD dwStart = GetTickCount();
  for ( ;; ) {
    MSG msg;
    while ( PeekMessage(&msg, NULL, 0, 0, PM_REMOVE) )
    {
      if ( msg.message == WM_QUIT || msg.message == WM_CLOSE ) {
        PostMessage(msg.hwnd, msg.message, msg.wParam, msg.lParam);
        return FALSE;
      }
      TranslateMessage(&msg);
      DispatchMessage(&msg);
    }

    DWORD dwTime = GetTickCount();
    period -= dwTime - dwStart;
    if ( period <= 0 ) break;
    dwStart = dwTime;

    MsgWaitForMultipleObjects(0, NULL, FALSE, period, QS_ALLINPUT);
  }
  return TRUE;
}

////////////////////////////////////////////////////////////////////////////////
// AuxYield - sleeps dispatching messages until handle gets signalled or timeout occur;
// similar to AtlWaitWithMessageLoop but takes a timeout value

inline AUXAPI_(BOOL) AuxWait(long period, HANDLE hWait)
{
  DWORD dwStart = GetTickCount();
  for ( ;; ) {
		if ( MsgWaitForMultipleObjects(1, &hWait, FALSE, period, QS_ALLINPUT) == WAIT_OBJECT_0 )
      return FALSE;

    MSG msg;
    while ( PeekMessage(&msg, NULL, 0, 0, PM_REMOVE) )
    {
      if ( msg.message == WM_QUIT || msg.message == WM_CLOSE ) {
        PostMessage(msg.hwnd, msg.message, msg.wParam, msg.lParam);
        return FALSE;
      }
      TranslateMessage(&msg);
      DispatchMessage(&msg);
    }

    DWORD dwTime = GetTickCount();
    period -= dwTime - dwStart;
    if ( period <= 0 ) break;
    dwStart = dwTime;
  }
  return TRUE;
}

////////////////////////////////////////////////////////////////////////////////
// Simple string helpers

inline AUXAPI_(LPWSTR) AuxStrCpy(LPWSTR dst, LPCWSTR src) throw() {
  LPWSTR dest = dst;
  while ( (*dest = *src) ) { dest++; src++; }
  return dst;
}

inline AUXAPI_(WCHAR) AuxLowerCase(WCHAR c) throw() {
  return (WCHAR)CharLower((LPTSTR)c); }
//  return (c >= 'A' && c <= 'Z')? c + ('a'-'A'): c; }

inline AUXAPI_(WCHAR) AuxUpperCase(WCHAR c) throw() {
  return (WCHAR)CharUpper((LPTSTR)c); }
//  return (c >= 'a' && c <= 'z')? c - ('a'-'A'): c; }

inline AUXAPI_(LPCWSTR) AuxStrLower(LPWSTR psz) throw() {
  for ( LPWSTR p = psz; *p; p++ )
    *p = (WCHAR)CharLower((LPTSTR)*p);
//    if ( *p >= 'A' && *p <= 'Z' ) *p += 'a'-'A';
  return psz;
}

inline AUXAPI_(LPCWSTR) AuxStrUpper(LPWSTR psz) throw() {
  for ( LPWSTR p = psz; *p; p++ )
    *p = (WCHAR)CharUpper((LPTSTR)*p);
//    if ( *p >= 'a' && *p <= 'z' ) *p -= 'a'-'A';
  return psz;
}

inline AUXAPI_(UINT) AuxStrLen(LPCWSTR psz) throw() {
  LPCWSTR p = psz;
  while ( *p ) p++;
  return psz-p;
}

inline AUXAPI_(int) AuxStrCmp(LPCWSTR src, LPCWSTR dst) throw() {
  int ret = 0;
  while ( !(ret = *src - *dst) && *dst ) ++src, ++dst;
  if ( ret < 0 ) ret = -1;
  else if ( ret > 0 ) ret = 1;
  return ret;
}

inline AUXAPI_(int) AuxStrNCmp(LPCWSTR src, LPCWSTR dst, UINT n) throw() {
  int ret = 0;
  while ( !(ret = *src - *dst) && *dst && n ) ++src, ++dst, n--;
  if ( ret < 0 ) ret = -1;
  else if ( ret > 0 ) ret = 1;
  return ret;
}

inline AUXAPI_(int) AuxStrICmp(LPCWSTR src, LPCWSTR dst) throw() {
  int ret = 0;
  while ( !(ret = AuxUpperCase(*src) - AuxUpperCase(*dst)) && *dst ) ++src, ++dst;
  if ( ret < 0 ) ret = -1;
  else if ( ret > 0 ) ret = 1;
  return ret;
}

inline AUXAPI_(int) AuxStrNICmp(LPCWSTR src, LPCWSTR dst, UINT n) throw() {
  int ret = 0;
  while ( !(ret = AuxUpperCase(*src) - AuxUpperCase(*dst)) && *dst && n ) ++src, ++dst, n--;
  if ( ret < 0 ) ret = -1;
  else if ( ret > 0 ) ret = 1;
  return ret;
}


// this is the useful helpers to deal with dispinterfaces, privided by COMSUPP.LIB
HRESULT __stdcall _com_dispatch_raw_propget(IDispatch*, DISPID, VARTYPE, void*) throw();
HRESULT __cdecl _com_dispatch_raw_propput(IDispatch*, DISPID, VARTYPE, ...) throw();
HRESULT __cdecl _com_dispatch_raw_method(IDispatch*, DISPID, WORD, VARTYPE, void*, const wchar_t*, ...) throw();
HRESULT __cdecl _com_invoke_helper(IDispatch*, DISPID, WORD, VARTYPE, void*, const wchar_t*, va_list, IErrorInfo**) throw();

#endif // _AUX_ATL_INDEPENDENT


////////////////////////////////////////////////////////////////////////////////
// *********************** This part is ATL-dependend **************************

#ifdef __ATLBASE_H__

#ifndef _AUX_ATL_DEPENDENT
#define _AUX_ATL_DEPENDENT

#pragma pack(push, _ATL_PACKING)

#define UUID_SPEC(x)              __declspec(uuid(x))

#define UUIDOF(id)                __uuidof(id)

#define SWAPWB(a)                 MAKEWORD(HIBYTE(a), LOBYTE(a))
#define SWAPLW(a)                 MAKELONG(HIWORD(a), LOWORD(a))
#define SWAPLB(a)                 MAKELONG(SWAPWB(HIWORD(a)), SWAPWB(LOWORD(a)))

#define MK_FCC                    SWAPLB // make fourcc
#define MK_TCC                    SWAPWB // make twocc

#ifndef _countof
  #define _countof(array)         (sizeof(array)/sizeof((array)[0]))
#endif

#ifndef _zeroinit
  #ifndef ZERO_INIT // for compatibility
    #define ZERO_INIT(lvalue)     memset(&(lvalue), 0, sizeof(lvalue))
  #endif
  #define _zeroinit(lvalue)       ZERO_INIT(lvalue)
#endif

#ifndef _offsetof
  #ifndef offsetof // for compatibility
    #define offsetof(type, field)   ((int)&((type*)0)->field)
  #endif
  #define _offsetof               offsetof
#endif

#ifndef V_FALSE
  #define V_FALSE                 VARIANT_FALSE
  #define V_TRUE                  VARIANT_TRUE
#endif

#define V_ISEMPTY(v)              (V_VT(v) == VT_EMPTY || V_VT(v) == VT_ERROR || V_VT(v) == VT_NULL)
#define V_ISBSTR(v)               (V_VT(v) == VT_BSTR)
#define V_ISBOOL(v)               (V_VT(v) == VT_BOOL)
#define V_ISDISPATCH(v)           (V_VT(v) == VT_DISPATCH)
#define V_ISI4(v)                 (V_VT(v) == VT_I4)
#define V_ISUNKNOWN(v)            (V_VT(v) == VT_UNKNOWN)
#define V_ISIFACE(v)              (V_ISUNKNOWN(v) || V_ISDISPATCH(v))

#define LCID_US                   MAKELCID(MAKELANGID(LANG_ENGLISH, SUBLANG_ENGLISH_US), SORT_DEFAULT)

#ifndef ASSERT
  #define ASSERT                  ATLASSERT
#endif

#ifndef ATLASSERT
  #define ATLASSERT               _ASSERTE
#endif

#ifndef VERIFY
  #ifdef _DEBUG
    #define VERIFY(f)             ASSERT(f)
  #else
    #define VERIFY(f)             (void(f))
  #endif
#endif

#ifndef DEBUG_ONLY
  #ifdef _DEBUG
    #define DEBUG_ONLY(f)         (f)
    #define UNUSED(x)             x
  #else
    #define DEBUG_ONLY(f)         ((void)0)
    #define UNUSED(x)
  #endif
#endif

#define ASSERT_HR(exp)            ASSERT(_SUCCEEDED(exp))
#define VERIFY_HR(exp)            VERIFY(_SUCCEEDED(exp))

#ifndef TRACE
  #define TRACE                   ATLTRACE
#endif

#ifndef TRACE0
  #ifdef _DEBUG
    #define TRACE0(fmt) TRACE(fmt)
    #define TRACE1(fmt, a1) TRACE(fmt, a1)
    #define TRACE2(fmt, a1, a2) TRACE(fmt, a1, a2)
    #define TRACE3(fmt, a1, a2, a3) TRACE(fmt, a1, a2, a3)
    #define TRACE4(fmt, a1, a2, a3, a4) TRACE(fmt, a1, a2, a3, a4)
  #else // _DEBUG
    #define TRACE0(fmt)
    #define TRACE1(fmt, a1)
    #define TRACE2(fmt, a1, a2)
    #define TRACE3(fmt, a1, a2, a3)
    #define TRACE4(fmt, a1, a2, a3, a4)
  #endif // _DEBUG
#endif // TRACE0

////////////////////////////////////////////////////////////////////////////////
/* CPtr - C++ Smart Pointer
CPtr<> is similar to CComPtr but designed to hold a reference on a class that is 
not neccessarilly should be a COM class. The only requirement the class should have 
AddRef() and Release() methods.
It differs from CComPtr in that direct class (not interface) pointer is being hold on. 
The class may not derive from IUnknown, and AddRef/Release may not even be virtual.
You may use CRefCntImpl<> to quickly add AddRef/Release refcounting to any C++ class,
look for CRefCntImpl below.

Handy to create ATL objects, it does FinalConstruct/AddRef:

  CPtr< CComObjectNoLock<CFoo> > foo;
  _S( foo.CreateObject() );

//////////////////////////////////////////////////////////////////////////////*/
                           
template<typename T>
class CPtr
{
public:
  class _NoRefT: public T
  {
    STDMETHOD_(ULONG, AddRef)()=0;
    STDMETHOD_(ULONG, Release)()=0;
  };

  CPtr() throw(): p(NULL) {}
  CPtr(T* ptr, bool fAddRef) throw() { 
    if ( (p = ptr) && fAddRef ) p->AddRef(); }
  CPtr(T* ptr) throw() { 
    if ( (p = ptr) ) p->AddRef(); }
  CPtr(const CPtr& ptr) throw() { 
    if ( (p = ptr.p) ) p->AddRef(); }

  ~CPtr() throw() { if ( p ) p->Release(); }

  operator T*() const throw() { return p; }
  T& operator*() const throw() { _ASSERTE(p!=NULL); return *p; }
  T** operator&() throw() { _ASSERTE(p==NULL); return &p; }
  _NoRefT* operator->() const throw() {
    _ASSERTE(p!=NULL); return (_NoRefT*)p; }
  bool operator!() const throw() { return p == NULL; }

  T* operator=(T* ptr) throw() {
    if ( p ) p->Release();
    if ( (p = ptr) ) p->AddRef();
    return p;
  }
  T* operator=(const CPtr& ptr) throw()
  {
    return operator=(ptr.p);
  }

  void Attach(T* ptr) throw() { *this = ptr; }
  void Attach(T* ptr, bool fAddRef) throw() {
    if ( p ) p->Release();
    p = ptr;
    if ( fAddRef && p ) p->AddRef();
  }
  T* Detach() throw() { T* tmp = p; p = NULL; return tmp; }
  void Release() throw() { if ( p ) p->Release(); p = NULL; }

  HRESULT CopyTo(T** pp) const throw()
  {
    _ASSERTE(pp != NULL);
    if ( pp == NULL ) return E_POINTER;
    if ( (*pp = p) )
      p->AddRef();
    return S_OK;
  }

  HRESULT CreateObject(void* pCtx = NULL) {
    _ASSERTE(p == NULL);
    HRESULT hr = E_OUTOFMEMORY;
    ATLTRY(p = new T());
    if ( p ) {
      p->SetVoid(pCtx);
      p->InternalFinalConstructAddRef();
      hr = p->FinalConstruct();
      p->InternalFinalConstructRelease();
      if ( hr != S_OK ) {
        delete p;
        p = NULL;
      }
      else
        p->AddRef();
    }
    return hr;
  }

public:
  T* p;
};

////////////////////////////////////////////////////////////////////////////////
/* Smart pointer/CComBSTR wrapper for STL awareness.

Example: CStlAdapt< IPtr<IFoo> >

For STL operator& is required to return a phys address of object.
SGI-STL often does something like:

  ForwardIterator cur = result;
  construct(&*cur, *first);

If interator "cur" is of smart pointer type, we basically get assertion
due to &*cur sequence on uninitialized memory. We need operator& to return 
physical address instantly.
//////////////////////////////////////////////////////////////////////////////*/

template<class Base>
class CStlAdapt: public Base {
public:
  CStlAdapt() {}
  template<typename A>
  CStlAdapt(const A& src):
    Base(src) {}
  template<typename A>
  CStlAdapt& operator=(const A& src) { 
    val() = src; return *this; }

  // CComBSTR workaround specializations
  template<> CStlAdapt(const CComBSTR& src) {
    m_str = src.m_str? src.Copy(): NULL; }
  template<> CStlAdapt(const CStlAdapt<CComBSTR>& src) {
    m_str = src.m_str? src.Copy(): NULL; }
  template<> CStlAdapt& operator=(const CComBSTR& src) {
    if ( m_str != src.m_str ) {
      if ( m_str ) ::SysFreeString(m_str);
      m_str = src.m_str? src.Copy(): NULL;
    }
    return *this;
  }
  template<> CStlAdapt& operator=(const CStlAdapt<CComBSTR>& src) {
    return operator=(src.val()); }

  CStlAdapt* operator&() throw() { return this; }
  const CStlAdapt* operator&() const throw() { return this; }

  // now CStlAdapt< IPtr<IDispatch> > can be compared with IDispatch*
  template<typename A>
  bool operator==(const A& ptr) const throw() {
    return val() == ptr; }

  template<typename A>
  bool operator!=(const A& ptr) const throw() {
    return !(val() == ptr); }

  Base& val() throw() { return *this; }
  const Base& val() const throw() { return *this; }
};

#define CStlAware CStlAdapt

////////////////////////////////////////////////////////////////////////////////
/* CAuxByRefVar transparent handling of by-ref arguments for both JScript(!) and VBscript.

Example:

[VBScript]

dim a, b, c, d
factory.GetComponentVersion "msxml", a, b, c, d
alert a & "." & b & "." & c & "." & d

[JScript]

a = new Array(1); // possible as well: a = new Array
b = new Array(1); // possible as well: a = new Object
c = new Array(1);
d = new Array(1);
factory.GetComponentVersion("msxml", a, b, c, d);
alert(a[0]+"."+b[0]+"."+c[0]+"."+d[0]);

[IDL]

HRESULT GetComponentVersion([in] BSTR cls,
  [in, out] VARIANT* a,
  [in, out] VARIANT* b,
  [in, out] VARIANT* c,
  [in, out] VARIANT* d);

[C++]

STDMETHODIMP CFactory::GetComponentVersion(BSTR cls,
    VARIANT* a,
    VARIANT* b,
    VARIANT* c,
    VARIANT* d)
{
  // get version info stuff
  
  ...

  // return it to the caller
  CAuxByRefVar va(a), vb(b), vc(c), vd(d);

  VariantClear(va);
  V_VT(va) = VT_I4;
  V_I4(va) = HIWORD(vInfo->dwFileVersionMS);

  VariantClear(vb);
  V_VT(vb) = VT_I4;
  V_I4(vb) = LOWORD(vInfo->dwFileVersionMS);

  VariantClear(vc);
  V_VT(vc) = VT_I4;
  V_I4(vc) = HIWORD(vInfo->dwFileVersionLS);

  VariantClear(vd);
  V_VT(vd) = VT_I4;
  V_I4(vd) = LOWORD(vInfo->dwFileVersionLS);

  return S_OK;
}

//////////////////////////////////////////////////////////////////////////////*/

struct CAuxHRESULT {
  HRESULT m_hr;
  operator HRESULT*() {
    return &m_hr;
  }
};

#ifdef __IDispatchEx_FWD_DEFINED__

struct CAuxByRefVar {
  VARIANT m_v;
  VARIANT* m_arg;
  DISPID m_dispid;
  IPtr<IDispatchEx> m_dex;

  CAuxByRefVar() {
    m_dispid = DISPID_UNKNOWN;
  }

  CAuxByRefVar(VARIANT* arg, HRESULT& hr = *CAuxHRESULT()) {
    this->CAuxByRefVar::CAuxByRefVar();
    hr = Attach(arg);
  }

  ~CAuxByRefVar() {
    Detach();
  }

  HRESULT Attach(VARIANT* arg) {
    ASSERT(m_dispid == DISPID_UNKNOWN);
    HRESULT hr = S_OK;
    if ( V_ISDISPATCH(arg) ) {
      VariantInit(&m_v);
      m_arg = &m_v;
      hr = AuxQI(V_DISPATCH(arg), &m_dex);
      if ( m_dex ) {
        hr = m_dex->GetDispID(CComBSTR(L"0"), fdexNameCaseSensitive | fdexNameEnsure, &m_dispid);
        if ( m_dispid != DISPID_UNKNOWN ) {
          DISPPARAMS dispparams = { NULL, NULL, 0, 0 };
          hr = m_dex->InvokeEx(m_dispid, 0, DISPATCH_PROPERTYGET, &dispparams, &m_v, NULL, NULL);
        }
      }
    }
    else 
      m_arg = arg;
    return hr;
  }

  HRESULT Detach() {
    HRESULT hr = S_OK;
    if ( m_dispid != DISPID_UNKNOWN ) {
      DISPID dispidNamed = DISPID_PROPERTYPUT;
      DISPPARAMS dispparams = { &m_v, &dispidNamed, 1, 1 };
      hr = m_dex->InvokeEx(m_dispid, 0, V_ISDISPATCH(&m_v)? DISPATCH_PROPERTYPUTREF: DISPATCH_PROPERTYPUT, 
        &dispparams, NULL, NULL, NULL);
      VariantClear(&m_v);
      m_dispid = DISPID_UNKNOWN;
    }
    return hr;
  }

  operator VARIANT*() const {
    return m_arg;
  }

  VARIANT* operator->() const {
    ASSERT(m_arg);
    return m_arg;
  }
};

#endif __IDispatchEx_FWD_DEFINED__

////////////////////////////////////////////////////////////////////////////////
// Formatting and reporting Automation errors

#ifdef __ATLCOM_H__

inline AUXAPI AuxReportError(
  const CLSID& clsid,
  const IID& iid,
  UINT nID,
  va_list args = NULL,
  LPCOLESTR lpszHelpFile = NULL,
  DWORD dwHelpID = 0,
  HRESULT hRes = 0,
  HINSTANCE hInst = _Module.GetResourceInstance() ) throw()
{
  USES_CONVERSION;
  TCHAR szFormat[512]; // hardcoded
  TCHAR szDesc[_AUX_MAX_DESC_TEXT];

  if ( lpszHelpFile && dwHelpID == 0 ) dwHelpID = nID;
  
  if ( hRes == 0 ) hRes = MAKE_HRESULT(SEVERITY_ERROR, FACILITY_ITF, nID);

  LPCTSTR lpszDesc = szFormat;
  if ( LoadString(hInst, nID, szFormat, _countof(szFormat)) == 0 ) {
    ASSERT(FALSE);
    lstrcpy(szFormat, _T("Unknown Error"));
  }
  else if ( args ) {
    lpszDesc = szDesc;
    int c = wvsprintf(szDesc, szFormat, args);
    ASSERT(c < _countof(szDesc));
  }

  return AtlSetErrorInfo(clsid, T2COLE(lpszDesc), dwHelpID, lpszHelpFile, iid, hRes, hInst);
}

inline AUXAPIV AuxReportErrorf(const CLSID& clsid, const IID& iid, UINT nID, ...) throw() {
  va_list arglist;
  va_start(arglist, nID);
  HRESULT hr = AuxReportError(clsid, iid, nID, arglist);
  va_end(arglist);
  return hr;
}

inline AUXAPIV Errorf(UINT nID, ...) throw() {
  va_list arglist;
  va_start(arglist, nID);
  HRESULT hr = AuxReportError(GUID_NULL, GUID_NULL, nID, arglist);
  va_end(arglist);
  return hr;
}

////////////////////////////////////////////////////////////////////////////////
// Lock the module for the scope where the object lives.

class CModuleLock
{
public:
  CModuleLock() { _Module.Lock(); }
  ~CModuleLock() { _Module.Unlock(); }
};


////////////////////////////////////////////////////////////////////////////////
/* CAuxObjectStack

CAuxObjectStack is the same as ATL CComObjectStack, but now annoying ASSERTs.
AddRef/Release are ok as far *is known* there is no more outstanding references 
when the object's scope is over.
Example of such a case:

  {
    CAuxObjectStack<CFoo> foo;
    _S( AtlAdvise(src, foo.GetUnknown(), ...) ); // event source from other appartment
    // message loop
    ...
    AtlUnadvise(src, ...)
  }  

//////////////////////////////////////////////////////////////////////////////*/

template <class Base>
class CAuxObjectStack: public Base
{
public:
  typedef Base _BaseClass;
  CAuxObjectStack(HRESULT* phr = NULL) {
    HRESULT hr = FinalConstruct();
    if ( phr ) *phr = hr;
  }
  ~CAuxObjectStack() {
    CoDisconnectObject(GetUnknown(), 0); // required
    ASSERT(m_dwRef == 0);
    FinalRelease(); 
  }

  STDMETHOD_(ULONG, AddRef)() { 
    DEBUG_ONLY( InternalAddRef() ); return 1; }
  STDMETHOD_(ULONG, Release)() { 
    ASSERT( InternalRelease() >= 0 ); return 1; }

  //if _InternalQueryInterface is undefined then you forgot BEGIN_COM_MAP
  STDMETHOD(QueryInterface)(REFIID iid, void ** ppvObject) { 
    return _InternalQueryInterface(iid, ppvObject); }
};


////////////////////////////////////////////////////////////////////////////////
/* IUnknown method ambiguity

Orginal code:

// Use this to resolve ambiguity when you call IUnknown's
// methods within class derived from multiple interfaces.
// They will anyway get overriden by CComObject<>

#define DECLARE_UNKNOWN() public: \
  STDMETHOD(QueryInterface)(REFIID iid, void ** ppvObject) = 0; \
  STDMETHOD_(ULONG, AddRef)() = 0; \
  STDMETHOD_(ULONG, Release)() = 0; 

With ATL3, I've got to modify this to accomodate END_COM_MAP changes
//////////////////////////////////////////////////////////////////////////////*/

#if _ATL_VER < 0x0300 // but need to handle this properly for ATL2
  #undef END_COM_MAP
  #if defined(_ATL_DEBUG_QI)
    // debug version
    #define END_COM_MAP() \
      {NULL, 0, 0}}; return &_entries[1];} \
      STDMETHOD_(ULONG, AddRef)() = 0; \
      STDMETHOD_(ULONG, Release)() = 0; \
      STDMETHOD(QueryInterface)(REFIID iid, void ** ppvObject) = 0;
  #else
    // non-debug version
    #define END_COM_MAP() \
      {NULL, 0, 0}}; return _entries;} \
      STDMETHOD_(ULONG, AddRef)() = 0; \
      STDMETHOD_(ULONG, Release)() = 0; \
      STDMETHOD(QueryInterface)(REFIID iid, void ** ppvObject) = 0;
  #endif
#endif


////////////////////////////////////////////////////////////////////////////////
// Use this instead of BEGIN_COM_MAP if IUnknown is the only supported interface,
// i.e. object is reference-counted only.
// Your class should derive from IUnknown some way.

#define COM_MAP_NO_ENTRIES() \
  IUnknown* GetUnknown() { return static_cast<IUnknown*>(this); } \
  HRESULT _InternalQueryInterface(REFIID iid, void** ppvObject) { \
    if ( InlineIsEqualUnknown(iid) ) { \
      IUnknown* pUnk = GetUnknown(); \
      pUnk->AddRef(); \
      *ppvObject = pUnk; \
      return S_OK; \
    } \
    return E_NOINTERFACE; \
  }

// Use this instead of BEGIN_COM_MAP if there is a single interface supported

#define COM_MAP_SINGLE_ENTRY_IID(_iid, _iface) \
  IUnknown* GetUnknown() { \
    return static_cast<_iface*>(this); } \
  HRESULT _InternalQueryInterface(REFIID iid, void** ppvObject) { \
    IUnknown* pUnk; \
    if ( InlineIsEqualUnknown(iid) || InlineIsEqualGUID(_iid, iid) ) \
      pUnk = static_cast<_iface*>(this); \
    else return E_NOINTERFACE; \
    pUnk->AddRef(); \
    *ppvObject = pUnk; \
    return S_OK; \
  }

#define COM_MAP_DUAL_ENTRY_IID(_iid, _iface) \
  IUnknown* GetUnknown() { \
    return static_cast<_iface*>(this); } \
  HRESULT _InternalQueryInterface(REFIID iid, void** ppvObject) { \
    IUnknown* pUnk; \
    if ( InlineIsEqualUnknown(iid) || \
         InlineIsEqualGUID(IID_IDispatch, iid) || \
         InlineIsEqualGUID(_iid, iid) ) \
      pUnk = static_cast<IDispatch*>(static_cast<_iface*>(this)); \
    else return E_NOINTERFACE; \
    pUnk->AddRef(); \
    *ppvObject = pUnk; \
    return S_OK; \
  }

#define COM_MAP_SINGLE_ENTRY(_iface) \
  COM_MAP_SINGLE_ENTRY_IID(UUIDOF(_iface), _iface)

#define COM_MAP_DUAL_ENTRY(_iface) \
  COM_MAP_DUAL_ENTRY_IID(UUIDOF(_iface), _iface)

////////////////////////////////////////////////////////////////////////////////
/* Use CUnkImpl to easily implement IUnknown for a helper object.

CUnkImpl lets you expose NON-DEFAULT constructor of your object
(since there is no ATL object like CComObject derived from yours).
It's for simple object, generally createable by parent objects.

More, you may support interfaces other than IUnknown on the object.
If you support just single interface, say, IFoo, you may derive
from CUnkImpl<CFoo, IFoo>. Otherwise, derive from all the
interfaces you need to support, then use

BEGIN_COM_MAP_UNKIMPL(CFoo)
// ATL COM map entries
  ...
END_COM_MAP_UNKIMPL()

Notes:
- no module locking done by default. To get it, derive from CModuleLock.
- to override threading model, use thrid parameter, e.g.:
  CUnkImpl<CFoo, IFoo, CComSingleThreadModel>
- don't use ATL_NO_VTABLE, since your class is a leaf.
- not suited to construct/destruct aggregates at ctor/dtor time
(reference counter isn't protected)

Examples:

Simple IUnknown-compliant, ref-counted object, to be used with STL and
to avoid copying:

  struct CHelper: CUnkImpl<CHelper>
  {
    CHelper(SAFEARRAY* psa) { m_strings.Attach(psa); }
    CLockedSafeArray<BSTR> m_strings;
  };

  vector< CStlAdapt< IPtr<CHelper, &IID_IUnknown> > > vec;
  vec.push_back(new CHelper(strings));

Single interface:

  class CHelper:
    public CUnkImpl<CHelper, IHelper>
  {
  public:
  // IHelper methods here
    ...
  }

Dual interface:

  class CHelper:
    public CUnkImpl<CHelper, IDispatchImpl<IHelper, &IID_IHelper, &LIBID_Helper> >
  {
  public:
    CHelper(const VARIANT& v); // non-default ctor!
    COM_MAP_DUAL_ENTRY(IHelper)

  // IHelper methods here
    ...
  }

Several interfaces:

  class CHelper:
    public CUnkImpl<CHelper>,
    public IDispatchImpl<IHelper, &IID_IHelper, &LIBID_Helper>,
    public ISupportErrorInfoImpl<&IID_IHelper>
  {
  public:
    CHelper(const VARIANT& v); // non-default ctor!

    BEGIN_COM_MAP_UNKIMPL(CHelper)
      COM_INTERFACE_ENTRY(IDispatch)
      COM_INTERFACE_ENTRY(IHelper)
      COM_INTERFACE_ENTRY(ISupportErrorInfo)
    END_COM_MAP_UNKIMPL()

  // IHelper methods here
    ...
  }
//////////////////////////////////////////////////////////////////////////////*/

template<class Interface>
class ATL_NO_VTABLE CUnkImplHlp: public Interface {
public:
  // _InternalQueryInterface for <Interface> by default
  COM_MAP_SINGLE_ENTRY(Interface)
};

template<>
class ATL_NO_VTABLE CUnkImplHlp<IUnknown>: public IUnknown {
public:
  // _InternalQueryInterface for IUnknown by default
  COM_MAP_NO_ENTRIES()
};

template<class Derived, class Interface = IUnknown, class ThreadModel = CComObjectThreadModel>
class ATL_NO_VTABLE CUnkImpl:
  public CUnkImplHlp<Interface>,
  public CComObjectRootEx<ThreadModel>
{
public:
  typedef CUnkImpl _UnkImpl;

  STDMETHOD(QueryInterface)(REFIID iid, void ** ppvObject) {
     return static_cast<Derived*>(this)->_InternalQueryInterface(iid, ppvObject);
  }
  STDMETHOD_(ULONG, AddRef)() {
    return static_cast<Derived*>(this)->InternalAddRef(); }
  STDMETHOD_(ULONG, Release)()
  {
    ULONG l = static_cast<Derived*>(this)->InternalRelease();
    if ( l == 0 ) {
      delete static_cast<Derived*>(this);
    }
    return l;
  }
};

#define DECLARE_UNKIMPL() public: \
  STDMETHOD_(ULONG, AddRef)() { return _UnkImpl::AddRef(); } \
  STDMETHOD_(ULONG, Release)() { return _UnkImpl::Release(); } \
  STDMETHOD(QueryInterface)(REFIID iid, void ** ppvObject) { \
    return _UnkImpl::QueryInterface(iid, ppvObject); }

#define BEGIN_COM_MAP_UNKIMPL(cls) \
  BEGIN_COM_MAP(cls)

#if defined(_ATL_DEBUG_QI) || (_ATL_VER >= 0x0300 && defined(_ATL_DEBUG))
  // debug version
  #define END_COM_MAP_UNKIMPL() \
    {NULL, 0, 0}}; return &_entries[1];} \
    DECLARE_UNKIMPL()
#else
  // non-debug version
  #define END_COM_MAP_UNKIMPL() \
    {NULL, 0, 0}}; return _entries;} \
    DECLARE_UNKIMPL()
#endif

////////////////////////////////////////////////////////////////////////////////
/* CRefCntImpl - implement refcounting

CRefCntImpl<> is a template code to add simple ref-counting to any C++ class. 
It may be very handy and efficient to be used with STL containers to avoid redundant copying 
(that is being done intensively behind the scene). 
Application for it is not limited to STL only, use it wherever refcounting is appropriate.
CPtr<> is a companion smart pointer class.

Example:

struct CData: CRefCntImpl<CData>
{
  CComBSTR m_str;
  CComVariant m_var;
  CData(LPCOLESTR bstr, const VARAINT& var): m_str(str), m_var(var) {}
}

// ...

vector< CAdapt<CDataPtr> > vec;
CPtr<CData> data = new CData(L"True", CComVaraint(true));
vec.push_back(data);

//////////////////////////////////////////////////////////////////////////////*/

template<class Derived, class ThreadModel = CComObjectThreadModel>
class ATL_NO_VTABLE CRefCntImpl:
  public CComObjectRootEx<ThreadModel>
{
public:
  typedef CRefCntImpl _CRefCntImpl;

  ULONG STDMETHODCALLTYPE AddRef() { // non-virtual!
    return static_cast<Derived*>(this)->InternalAddRef(); }
  ULONG STDMETHODCALLTYPE Release()
  {
    ULONG l = static_cast<Derived*>(this)->InternalRelease();
    if ( l == 0 ) {
      delete static_cast<Derived*>(this);
    }
    return l;
  }
};

////////////////////////////////////////////////////////////////////////////////
/* Dynamic creation of ATL-based objects: AuxCreateObject

One common way to do this is:

  CComObject<CFoo>* p;
  _S( CComObject<CFoo>::CreateInstance(&p) );

Besides too much typing, we are limited to CComObject<> only. We may use:

  CComObject<CFoo>* p;
  _S( AuxCreateObject(&p) );

Or:

  CComObjectNoLock<CFoo>* p;
  _S( AuxCreateObject(&p) );

ATL prevents us from using of non-default constructors (without CUnkImpl) and 
postpones initialization until FinalConstruct. To do a convenient one-step 
construction of an ATL object passing some initialization information, 
we may override SetVoid, store passed info, then use it at FinalConstruct 
time. FinalConstruct may fail, so does the construction at all.

Example:

  class ATL_NO_VTABLE CHelper:
    public CComObjectRoot,
    public IHelper,
    ...
  {
  public:
    CParent* m_pParent;
    IDispatchPtr m_disp;

    void SetVoid(void* pv) {
      // pv could reference even data on caller stack, since
      // the call is immediately followed by FinalConstruct
      ASSERT(pv); m_pParent = (CParent*)pv;
    }
    HRESULT FinalConstruct() {
      _R( m_pParent->GetDispatch(&m_disp) );
    }
    ...
  };

To construct such an object, use AuxCreateObject helper:

  HRESULT CParent::CreateHelper(CHelper** pHelper) {
    CComObject<CHelper>* p;
    _S( AuxCreateObject(&p, this) );
    *pHelper = p;
    _R_OK;
  }

//////////////////////////////////////////////////////////////////////////////*/

template <class Base>
inline AUXAPI AuxCreateObject(Base** pp, void* pCtx = NULL, bool fAddRef = false) {
  ASSERT(pp != NULL);
  HRESULT hRes = E_OUTOFMEMORY;
  Base* p = NULL;
  ATLTRY(p = new Base())
  if (p != NULL)
  {
    p->SetVoid(pCtx);
    p->InternalFinalConstructAddRef();
    hRes = p->FinalConstruct();
    p->InternalFinalConstructRelease();
    if (hRes != S_OK)
    {
      delete p;
      p = NULL;
    }
  }
  *pp = p;
  if ( fAddRef ) p->AddRef();
  return hRes;
}

template <class Base>
inline AUXAPI AuxCreateObject(Base** pp, bool fAddRef) {
  return AuxCreateObject(pp, NULL, fAddRef);
}

////////////////////////////////////////////////////////////////////////////////
/* Type-unsafe but useful var-params version: AuxCreateObjectV

Example:

  class ATL_NO_VTABLE CHelper:
    public CComObjectRoot,
    ...
  {
    ...
    // if m_pCtx is required only for FinalConstruct, it even can be placed
    // in union with something useful (but one of smart pointer type!)
    CComBSTR m_bstr;
    IUnknownPtr m_unk;
    union {
      void* m_pCtx;
      DWORD m_data;
    }

    void SetVoid(void* pv) { ASSERT(pv); m_pCtx = pv; }
    HRESULT FinalConstruct() {
      va_list arg = (va_list)m_pCtx;
      m_unk = va_arg(arg, IUnknown*);
      m_bstr = va_arg(arg, LPCWSTR);
      m_data = va_arg(arg, DWORD);
      _R( S_OK );
    }
    ...
  };

To construct:

  CComObject<CHelper>* p;
  _S( AuxCreateObjectV(&p, pUnknown, L"Hello!") );
//////////////////////////////////////////////////////////////////////////////*/

template <class Base>
AUXAPI AuxCreateObjectV(Base** pp, ...) {
  va_list arglist;
  va_start(arglist, pp);
  HRESULT hr = AuxCreateObject(pp, arglist);
  va_end(arglist);
  return hr;
}


////////////////////////////////////////////////////////////////////////////////
/* CAuxGuids

Derive from this class:

  public CAuxGuids<&CLSID_Foo, &CLSID_IFoo>

to get inlines for CLSID and major IID, then use GetCLSID() and GetIID()
wherever appropriate. It's handy and makes easier the code porting between 
ATL projects.

Example:
  if ( m_fInited ) _R( Errorf(IDP_E_INITED) );
//////////////////////////////////////////////////////////////////////////////*/

template<const IID* clsid, const IID* iid, LPCOLESTR helpFile = NULL>
class CAuxGuids {
public:
  static const CLSID& GetCLSID() { return *clsid; }
  static const IID& GetIID() { return *iid; }
  static AUXAPIV Errorf(UINT nID, ...) throw() {
    va_list arglist;
    va_start(arglist, nID);
    HRESULT hr = ::AuxReportError(GetCLSID(), GetIID(), nID, arglist, helpFile);
    va_end(arglist);
    return hr;
  }
};


////////////////////////////////////////////////////////////////////////////////
/* Use handy message crackers from windowsx.h with CWindowImpl<>

Example:

  // message map
  DECLARE_DEFWNDPROC()
  BEGIN_MSG_MAP(CHost)
    MESSAGE_CRACKER(WM_DESTROY, Cls_OnDestroy)
    MESSAGE_CRACKER(WM_SIZE, Cls_OnSize)
  END_MSG_MAP()

  void Cls_OnDestroy(HWND);
  void Cls_OnSize(HWND, UINT state, int cx, int cy) {
    ...
    FORWARD_WM_SIZE(m_hWnd, state, cx, cy, DefWndProc)
  }

//////////////////////////////////////////////////////////////////////////////*/

#define DECLARE_DEFWNDPROC() \
  LRESULT DefWndProc(HWND, UINT uMsg, WPARAM wParam, LPARAM lParam) \
  { \
    return ::CallWindowProc(m_pfnSuperWindowProc, m_hWnd, uMsg, wParam, lParam); \
  }

#define MESSAGE_CRACKER(message, fn) \
  if ( uMsg == message ) { \
    lResult = HANDLE_##message((hWnd), (wParam), (lParam), (fn)); \
    return TRUE; \
  }

////////////////////////////////////////////////////////////////////////////////
// _IUnknown
// Implements alternative identity on the same object

#define ALT_BASE(iface) public _##iface

#define ALT_CAST(iface, p) reinterpret_cast<iface*>(static_cast<_##iface*>(p))

#define ALT_UNK_CAST(iface, p) \
  reinterpret_cast<IUnknown*>(static_cast<_IUnknown*>(static_cast<_##iface*>(p)))

#define BEGIN_ALT_MAP(Class) public: \
  IUnknown* GetAltUnknown() { return reinterpret_cast<IUnknown*>(this); } \
  Class* GetAltBase() { return this; } \
  STDMETHOD(_QueryInterface)(REFIID iid, void ** ppvObject) { \
    if ( !ppvObject ) return E_POINTER; \
    IUnknown* p; \
    if ( iid == IID_IUnknown ) p = GetAltUnknown();

#define ALT_MAP_ENTRY(iface) \
    else if ( iid == IID_##iface ) p = ALT_CAST(iface, this);

#define ALT_MAP_ENTRY_IID(_iid, iface) \
    else if ( iid == _iid ) p = ALT_UNK_CAST(iface, this);

#define ALT_MAP_ENTRY2(iface, iface2) \
    else if ( iid == IID_##iface ) p = ALT_CAST(iface, static_cast<_##iface2*>(this));

#define ALT_MAP_ENTRY_IID2(_iid, iface, iface2) \
    else if ( iid == _iid ) p = ALT_CAST(iface, static_cast<_##iface2*>(this));

#define END_ALT_MAP() \
    else { *ppvObject = NULL; return E_NOINTERFACE; } \
    (*reinterpret_cast<IUnknown**>(ppvObject) = p)->AddRef(); \
    return S_OK; \
  }

class ATL_NO_VTABLE _IUnknown {
public:
  STDMETHOD(_QueryInterface)(REFIID iid, void ** ppvObject) = 0;
  STDMETHOD_(ULONG, AddRef)() = 0;
  STDMETHOD_(ULONG, Release)() = 0;
};


////////////////////////////////////////////////////////////////////////////////
/* AuxFireEvent
Fire an event, given CP container and source dispinteface IID

Example:
  AuxFireEvent(GetUnknown(), DIID_DWebBrowserEvents, DISPID_WINDOWMOVE);

//////////////////////////////////////////////////////////////////////////////*/

#ifdef __IConnectionPointContainer_FWD_DEFINED__

inline AUXAPI AuxFireEvent(
  IUnknown* pCPContainer, 
  REFIID riid, 
  DISPID dispid, 
  LCID lcid, WORD wFlags,
  DISPPARAMS* pDispParams, VARIANT* pvarResult,
  EXCEPINFO*  pExcepInfo, UINT* puArgErr) throw()
{
  IPtr<IConnectionPointContainer> cpc;
  _S( AuxQI(pCPContainer, &cpc) );

  IPtr<IConnectionPoint> cp;
  _S( cpc->FindConnectionPoint(riid, &cp) );

  IPtr<IEnumConnections> enumer;
  _S( cp->EnumConnections(&enumer) );

  for ( ;; ) {
    CONNECTDATA cd;
    _zeroinit(cd);
    if ( _HR(enumer->Next(1, &cd, NULL)) != S_OK )
      break;
    if ( cd.pUnk ) {
      IPtr<IDispatch> disp(cd.pUnk);
      if ( disp ) {
        CComVariant var;
        disp->Invoke(dispid, IID_NULL, lcid, wFlags, pDispParams, &var, pExcepInfo, puArgErr);
        if ( pvarResult && V_VT(&var) != VT_EMPTY ) VariantCopy(pvarResult, &var);
      }
      cd.pUnk->Release();
    }
  }
  return S_OK;
}

inline AUXAPI AuxFireEvent(
  IUnknown* pCPContainer, 
  REFIID riid, 
  DISPID dispid, 
  UINT cParams = 0,
  IN VARIANTARG* pvarParams = NULL, 
  OUT VARIANT* pvarRet = NULL) throw()
{
  DISPPARAMS dispparams = { pvarParams, NULL, cParams, 0 };
  _R( AuxFireEvent(pCPContainer, riid, dispid, LOCALE_USER_DEFAULT, DISPATCH_METHOD, &dispparams, pvarRet, NULL, NULL) );
}

// Notify any objects sinking the IPropertyNotifySink notification that a property has changed
inline AUXAPI AuxFireOnChanged(IUnknown* pCPContainer, DISPID dispID)
{
  IPtr<IConnectionPointContainer> cpc;
  _S( AuxQI(pCPContainer, &cpc) );

  IPtr<IConnectionPoint> cp;
  _S( cpc->FindConnectionPoint(IID_IPropertyNotifySink, &cp) );

  IPtr<IEnumConnections> enumer;
  _S( cp->EnumConnections(&enumer) );

  for ( ;; ) {
    CONNECTDATA cd;
    _zeroinit(cd);
    if ( _HR(enumer->Next(1, &cd, NULL)) != S_OK )
      break;
    if ( cd.pUnk ) {
			IPtr<IPropertyNotifySink> sink(cd.pUnk);
			if ( sink )
				sink->OnChanged(dispID);
      cd.pUnk->Release();
    }
  }
  return S_OK;
}

#endif // __IConnectionPointContainer_FWD_DEFINED__

////////////////////////////////////////////////////////////////////////////////
/* AuxCloneObject
Clone an object uding IPersistStream[Init].
May be used recreate a clone at other apartment, a kind of by value marshalling

//////////////////////////////////////////////////////////////////////////////*/

template <typename Interface>
inline AUXAPI AuxCloneObject(IUnknown* unk, OUT Interface** pp) {
  _ASSERTE(unk);
  _ASSERTE(pp);

  IPersistStreamInitPtr persist;
  AuxQI(unk, &persist);
  if ( !persist )
    _S( unk->QueryInterface(IID_IPersistStream, (void**)&persist) );

  CLSID clsid;
  _S( persist->GetClassID(&clsid) );

  IStreamPtr stream;
  _S( CreateStreamOnHGlobal(NULL, TRUE, &stream) );
  _S( persist->Save(stream, FALSE) );
  LARGE_INTEGER move = { 0, 0 };
  _S( stream->Seek(move, STREAM_SEEK_SET, NULL) );
  
  IUnknownPtr obj;
  _S( obj.CreateInstance(clsid) );
  persist = obj;
  if ( persist )
    _S( persist->InitNew() )
  else
    _S( obj->QueryInterface(IID_IPersistStream, (void**)&persist) );

  _S( persist->Load(stream) );
  _R( AuxQI(persist, pp) );
}

inline BOOL AuxIsProxy(IUnknown* unk) {
  class __declspec(uuid("0000001b-0000-0000-c000-000000000046")) IdentityUnmarshal;
  return IPtr<IUnknown, &__uuidof(IdentityUnmarshal)>(*unk) != NULL;
}

inline AUXAPI AuxLoadString(UINT nID, OUT LPTSTR szBuff, IN OUT DWORD* pcb = NULL) {
  szBuff[0] = '\0';
  DWORD cb = LoadString(_Module.GetResourceInstance(), nID, szBuff, pcb? *pcb: MAX_PATH);
  if ( !cb ) _R_FAIL;
  if ( pcb ) *pcb = cb;
  _R_OK;
}

inline AUXAPIV_(UINT) AuxFormatString(UINT nID, OUT LPTSTR szBuff, ...) {
  TCHAR szFmt[512];
  DWORD cch = _countof(szFmt);
  AuxLoadString(nID, szFmt, &cch);
  if ( !cch ) return 0;
  va_list arglist;
  va_start(arglist, szBuff);
  cch = wvsprintf(szBuff, szFmt, arglist);
  va_end(arglist);
  return cch;
}

////////////////////////////////////////////////////////////////////////////////
/* CSinkBase

Simple and efficient way to build multiple dispinterface sinks at single object.
Derive your sink from this class and add IDispatch::Invoke compliant method.
Example:

  // Handle events from IWebBrowser2 object
  struct ATL_NO_VTABLE WBSinkClass: CSinkBase<&DIID_DWebBrowserEvents2> {
    STDMETHOD(WBSink)(DISPID dispidMember, REFIID riid,
      LCID lcid, WORD wFlags, DISPPARAMS* pdispparams, VARIANT* pvarResult,
      EXCEPINFO* pexcepinfo, UINT* puArgErr) = 0;
  };

  // Handle events from IHTMLWindow2 object
  struct ATL_NO_VTABLE WindowSinkClass: CSinkBase<&DIID_HTMLWindowEvents> {
    STDMETHOD(WindowSink)(DISPID dispidMember, REFIID riid,
      LCID lcid, WORD wFlags, DISPPARAMS* pdispparams, VARIANT* pvarResult,
      EXCEPINFO* pexcepinfo, UINT* puArgErr) = 0;
  };

  class ATL_NO_VTABLE CHost :
    public CComObjectRoot,
    ...
    public WBSinkClass,
    public WindowSinkClass
  {
  public:
    ...
  // implement WBSinkClass
    STDMETHOD(WBSink)(DISPID dispidMember, REFIID riid,
      LCID lcid, WORD wFlags, DISPPARAMS* pdispparams, VARIANT* pvarResult,
      EXCEPINFO* pexcepinfo, UINT* puArgErr);

  // implement WindowSinkClass
    STDMETHOD(WindowSink)(DISPID dispidMember, REFIID riid,
      LCID lcid, WORD wFlags, DISPPARAMS* pdispparams, VARIANT* pvarResult,
      EXCEPINFO* pexcepinfo, UINT* puArgErr);
  };

To advise:

  AtlAdvise(webBrowser, 
    WBSinkClass::GetSinkUnk(), WBSinkClass::GetIID(), &m_dwWBCP);
  AtlAdvise(window, 
    WindowSinkClass::GetSinkUnk(), WindowSinkClass::GetIID(), &m_dwWindowCP);
//////////////////////////////////////////////////////////////////////////////*/

// this is to layout IDispatch vtable
struct ATL_NO_VTABLE CSinkDisp {
protected:
  STDMETHOD(_SinkQueryInterface)(REFIID iid, void ** ppvObject) = 0;
  STDMETHOD_(ULONG, AddRef)() { return 1; } // it's likely to be overriden by derived class
  STDMETHOD_(ULONG, Release)() { return 1; }

  STDMETHOD(_SinkGetTypeInfoCount)(UINT* pctinfo)
    { ATLTRACENOTIMPL(_T("CSinkDisp::GetTypeInfoCount")); }
  STDMETHOD(_SinkGetTypeInfo)(UINT itinfo, LCID lcid, ITypeInfo** pptinfo)
    { ATLTRACENOTIMPL(_T("CSinkDisp::GetTypeInfo")); }
  STDMETHOD(_SinkGetIDsOfNames)(REFIID riid, LPOLESTR* rgszNames, UINT cNames,
    LCID lcid, DISPID* rgdispid)
    { ATLTRACENOTIMPL(_T("CSinkDisp::GetIDsOfNames")); }
};

template <const IID* piid = &IID_IDispatch>
struct ATL_NO_VTABLE CSinkBase: public CSinkDisp {
protected:
  STDMETHOD(_SinkQueryInterface)(REFIID iid, void ** ppvObject) {
    IUnknown* pUnk;
    if ( InlineIsEqualUnknown(iid) ||
         InlineIsEqualGUID(IID_IDispatch, iid) ||
         InlineIsEqualGUID(*piid, iid) )
    {
      pUnk = GetSinkUnk();
    }
    else return E_NOINTERFACE;
    pUnk->AddRef();
    *ppvObject = pUnk;
    return S_OK;
  }

public:
  CSinkBase(): 
    m_dwCookie(0xFABCABCD) {}

  // advise/unadvise helpers
  static const IID& GetSinkIID() {
    return *piid; }

  IUnknown* GetSinkUnk() throw() {
    return reinterpret_cast<IUnknown*>(this); }

  bool IsConnected() const throw() {
    return m_dwCookie != 0xFABCABCD; }

  HRESULT Advise(IUnknown* unk) throw() {
    ASSERT(!IsConnected());
    ASSERT(unk);
    _R( AtlAdvise(unk, GetSinkUnk(), *piid, &m_dwCookie) );
  }

  HRESULT Unadvise(IUnknown* unk) throw() {
    ASSERT(IsConnected());
    ASSERT(unk);
    HRESULT hr = _HR( AtlUnadvise(unk, *piid, m_dwCookie) );
    m_dwCookie = 0xFABCABCD;
    return hr;
  }

  HRESULT UnadviseSafe(IUnknown* unk) throw() {
    if ( !IsConnected() ) _R_OK;
    return Unadvise(unk);
  }

  // attributes
  DWORD m_dwCookie;
};

template<> // specialize for IID_IDispatch
inline STDMETHODIMP CSinkBase<&IID_IDispatch>::_SinkQueryInterface(REFIID iid, void ** ppvObject) 
{
  IUnknown* pUnk;
  if ( InlineIsEqualUnknown(iid) ||
       InlineIsEqualGUID(IID_IDispatch, iid) )
  {
    pUnk = GetSinkUnk();
  }
  else return E_NOINTERFACE;
  pUnk->AddRef();
  *ppvObject = pUnk;
  return S_OK;
}


////////////////////////////////////////////////////////////////////////////////
/* CSinkImpl

TBD.

//////////////////////////////////////////////////////////////////////////////*/

#ifndef _AUX_MAX_VARARGS
  #define _AUX_MAX_VARARGS 16
#endif

struct AUX_EVENT_ENTRY {
  MEMBERID memid;
  LPCWSTR pszName;
};

#define AUX_BEGIN_EVENT_MAP() \
public: \
  static AUXAPI_(UINT) _AuxGetEventMap(const AUX_EVENT_ENTRY** ppMap) { \
    static const AUX_EVENT_ENTRY _map[] = {

#define AUX_EVENT_ID(_id) \
  { _id, NULL },

#define AUX_EVENT_NAME(_name) \
  { DISPID_UNKNOWN, L ## #_name },

#define AUX_END_EVENT_MAP() \
  { DISPID_UNKNOWN, NULL } }; \
    ASSERT(ppMap); \
    *ppMap = _map; \
    return _countof(_map)-1; }

struct AUX_METHOD {
  MEMBERID memid;
  UINT nVOffs;
  VARTYPE vtRet;
  UINT cParams;
  VARTYPE params[_AUX_MAX_VARARGS];

  void Fill(FUNCDESC* pfd, UINT nVmtIndex) {
    nVOffs = (nVmtIndex + 7)*sizeof(FARPROC);
    vtRet = pfd->elemdescFunc.tdesc.vt;
    switch ( vtRet ) {
      case VT_INT:
        vtRet = VT_I4; break;
      case VT_UINT:
        vtRet = VT_UI4; break;
      case VT_VOID:
        vtRet = VT_EMPTY; break;
      case VT_HRESULT:
        vtRet = VT_ERROR; break;
    }
    cParams = pfd->cParams;
    ASSERT(cParams <= _AUX_MAX_VARARGS); // need to increase _AUX_MAX_VARARGS
    if ( cParams > _AUX_MAX_VARARGS ) return;
    for ( UINT i = 0; i < cParams; i++ ) {
      ELEMDESC& emdesc = pfd->lprgelemdescParam[cParams-i-1];
      params[i] = emdesc.tdesc.vt;
      if ( params[i] == VT_PTR )
        params[i] = emdesc.tdesc.lptdesc->vt | VT_BYREF;
    }
    memid = pfd->memid;
  }

  AUX_METHOD() {
    memid = DISPID_UNKNOWN; }
  AUX_METHOD(FUNCDESC* pfd, UINT nVmtIndex) {
    Fill(pfd, nVmtIndex); }
};

template <class _Derived, const IID* piid, const GUID* plibid, WORD wMajor = 1, WORD wMinor = 0>
class ATL_NO_VTABLE CSinkImpl: public CSinkBase<piid> {
protected:
  // should go first to comply with IDispatch layout
  STDMETHOD(_SinkInvoke)(DISPID dispidMember, REFIID riid,
    LCID lcid, WORD wFlags, DISPPARAMS* pdispparams, VARIANT* pvarResult,
    EXCEPINFO* pexcepinfo, UINT* puArgErr)
  {
    _S( FillMethods() );
    for ( UINT i = 0; i < m_cMethods; i++ ) {
      if ( m_methods[i].memid == dispidMember ) {
        AUX_METHOD& method = m_methods[i];
        VARIANTARG* apArgs[_AUX_MAX_VARARGS];
        for ( UINT i = 0; i < method.cParams; i++ )
          apArgs[i] = &pdispparams->rgvarg[method.cParams-i-1];

        _R( DispCallFunc(static_cast<_Derived*>(this),
          method.nVOffs,
          CC_STDCALL,
          method.vtRet,
          method.cParams,
          method.params,
          apArgs,
          pvarResult? pvarResult: &CComVariant()) ); // buggy in ATL3
      }
    }
    _R( S_OK );
  }

public:
  static AUXAPI_(UINT) _AuxGetEventMap(const AUX_EVENT_ENTRY** ppMap) {
    return ~0; }

protected:
  HRESULT FillMethods() throw() {
    if ( m_cMethods != ~0 ) _R( S_OK );

    ITypeLibPtr tl;
    _S( LoadRegTypeLib(*plibid, wMajor, wMinor, LOCALE_USER_DEFAULT, &tl) );
    ITypeInfoPtr ti;
    _S( tl->GetTypeInfoOfGuid(*piid, &ti) );

    TYPEATTR* pta;
    _S( ti->GetTypeAttr(&pta) );
    BOOL fDispatch = (pta->typekind == TKIND_DISPATCH);
    UINT cMethods = pta->cFuncs;
    ti->ReleaseTypeAttr(pta);

    if ( !fDispatch ) _R( DISP_E_MEMBERNOTFOUND );

    CAutoArray<AUX_METHOD> methods;
    const AUX_EVENT_ENTRY* pMap = NULL;
    UINT nEvents = static_cast<_Derived*>(this)->_AuxGetEventMap(&pMap);
    if ( nEvents == ~0 ) {
      // all handlers should be present in proper vtable order...
      ATLTRY( methods = new AUX_METHOD[cMethods] );
      if ( !methods ) _R( E_OUTOFMEMORY );
      for ( UINT i = 0; i < cMethods; i++ ) {
        FUNCDESC* pfd;
        _S( ti->GetFuncDesc(i, &pfd) );
        methods[i].Fill(pfd, i);
        ti->ReleaseFuncDesc(pfd);
      }
    }
    else {
      // process selected event handlers only...
      ASSERT(nEvents <= cMethods);
      ITypeInfo2Ptr ti2;
      _S( AuxQI(ti, &ti2) );

      cMethods = nEvents;
      methods = new AUX_METHOD[cMethods];
      for ( UINT i = 0; i < cMethods; i++ ) {
        MEMBERID memid = pMap[i].memid;
        if ( memid == DISPID_UNKNOWN ) {
          ASSERT(pMap[i].pszName);
          _S( ti2->GetIDsOfNames((OLECHAR**)&pMap[i].pszName, 1, &memid) );
        }
        UINT nIndex;
        _S( ti2->GetFuncIndexOfMemId(memid, INVOKE_FUNC, &nIndex) );
        FUNCDESC* pfd;
        _S( ti2->GetFuncDesc(nIndex, &pfd) );
        methods[i].Fill(pfd, i);
        ti2->ReleaseFuncDesc(pfd);
      }
    }

    m_methods = methods.Detach();
    m_cMethods = cMethods;
    _R( S_OK );
  }

protected:
  CSinkImpl(): m_cMethods(~0) {}

  UINT m_cMethods;
  CAutoArray<AUX_METHOD> m_methods;
};


////////////////////////////////////////////////////////////////////////////////
/* CAuxEnum

Enhanced version of CComEnum, allows empty collection.
Bug fixed: incorrect ownership flag test at CComEnum::Clone.
Example of CAuxEnum use:

  CComObject< CAuxEnum<IEnumVARIANT, VARIANT> >* pEnum = NULL;
  _S( pEnum->CreateInstance(&pEnum) );
  IUnknownPtr enumvar(pEnum);
  _S( pEnum->Init(m_vec.begin(), m_vec.end(), NULL, AtlFlagCopy) );
  *val = enumvar.Detach();
  return S_OK;
//////////////////////////////////////////////////////////////////////////////*/

#define CComEnumEx CAuxEnum // compatibility

template <class Base, const IID* piid, class T, class Copy>
class ATL_NO_VTABLE CAuxEnumImpl: public CComEnumImpl<Base, piid, T, Copy>
{
public:
  STDMETHOD(Next)(ULONG celt, T* rgelt, ULONG* pceltFetched)
  {
    if (rgelt == NULL || (celt != 1 && pceltFetched == NULL))
      return E_POINTER;
    /* Andien: this was removed from CComEnumImpl to allow an empty collection
    if (m_begin == NULL || m_end == NULL || m_iter == NULL)
      return E_FAIL;
    */
    ULONG nRem = (ULONG)(m_end - m_iter);
    HRESULT hRes = S_OK;
    if ( nRem < celt )
      hRes = S_FALSE;
    ULONG nMin = min(celt, nRem);
    for ( ULONG i = 0; i < nMin; i++ ) { // was: while(nMin--)
      Copy::init(rgelt);
#if _ATL_VER < 0x0300
      Copy::copy(rgelt++, m_iter++);
#else
      // can handle copy errors with ATL3
      hRes = Copy::copy(rgelt, m_iter++);
      if ( _FAILED(hRes) ) {
        for ( ; i > 0; i-- )
          Copy::destroy(--rgelt);
        if ( pceltFetched != NULL )
          *pceltFetched = 0;
        return hRes;
      }
      rgelt++;
#endif
    }
    if (pceltFetched != NULL)
      *pceltFetched = nMin;
    return hRes;
  }

  /* Original CComEnum::Clone bug:
  The newly created clone 'p' holds onto parent enum object only if
  BitCopy(1) bit was set. BitCopy might be set only if original object
  were initialized with AtlFlagCopy(3). If it were initialized with
  AtlFlagTakeOwnership(2), the clone would hold onto m_pUnk (likely unused)
  while it still should hold onto parent object.
  The right flag should be BitOwn(2).

  The nearest example that might fail here is ATL implementation of
  IConnectionPointImpl::EnumConnections.
  */

  STDMETHOD(Clone)(Base** ppEnum)
  {
    typedef CComObject<CAuxEnum<Base, T, Copy, piid> > _class;
    HRESULT hRes = E_POINTER;
    if (ppEnum != NULL)
    {
      _class* p = NULL;
      ATLTRY(p = new _class)
      if (p == NULL)
      {
        *ppEnum = NULL;
        hRes = E_OUTOFMEMORY;
      }
      else
      {
        // If the data is a owned then we need to keep "this" object around
        // Andien: BitCopy replaced by BitOwn
#if _ATL_VER < 0x0300
        hRes = p->Init(m_begin, m_end, (m_dwFlags & BitOwn) ? this : m_pUnk);
#else
        hRes = p->Init(m_begin, m_end, (m_dwFlags & BitOwn) ? this : m_spUnk);
#endif
        if (FAILED(hRes))
          delete p;
        else
        {
          p->m_iter = m_iter;
          hRes = p->_InternalQueryInterface(*piid, (void**)ppEnum);
          if (FAILED(hRes))
            delete p;
        }
      }
    }
    return hRes;
  }
};

template <class Base, class T, class Copy = _Copy<T>, const IID* piid = &__uuidof(Base), class ThreadModel = CComObjectThreadModel>
class ATL_NO_VTABLE CAuxEnum :
  public CAuxEnumImpl<Base, piid, T, Copy>,
  public CComObjectRootEx<ThreadModel>
{
public:
  typedef CAuxEnum<Base, T, Copy, piid> _CComEnum;
  typedef CAuxEnumImpl<Base, piid, T, Copy> _CComEnumBase;
  COM_MAP_SINGLE_ENTRY_IID(*piid, _CComEnumBase)
};


////////////////////////////////////////////////////////////////////////////////
/* IObjectSafety -- a copy of ATL3 impl (I need it in my ATL2 projects)
//
// 2nd template parameter is the supported safety e.g.
// INTERFACESAFE_FOR_UNTRUSTED_CALLER - safe for scripting
// INTERFACESAFE_FOR_UNTRUSTED_DATA   - safe for initialization from data
//////////////////////////////////////////////////////////////////////////////*/

#ifdef __IObjectSafety_FWD_DEFINED__

#if _ATL_VER >= 0x0300 // no problem

#define CAuxObjectSafetyImpl IObjectSafetyImpl

#else // for ATL2

template <class T, DWORD dwSupportedSafety>
class ATL_NO_VTABLE CAuxObjectSafetyImpl: public IObjectSafety
{
public:
  CAuxObjectSafetyImpl()
  {
    m_dwCurrentSafety = 0;
  }

  STDMETHOD(GetInterfaceSafetyOptions)(REFIID riid, DWORD *pdwSupportedOptions, DWORD *pdwEnabledOptions)
  {
    ATLTRACE(_T("IObjectSafety::GetInterfaceSafetyOptions\n"));
    T* pT = static_cast<T*>(this);
    if (pdwSupportedOptions == NULL || pdwEnabledOptions == NULL)
      return E_POINTER;
    
    HRESULT hr;
    IUnknown* pUnk;
    // Check if we support this interface
    hr = pT->GetUnknown()->QueryInterface(riid, (void**)&pUnk);
    if (SUCCEEDED(hr))
    {
      // We support this interface so set the safety options accordingly
      pUnk->Release();  // Release the interface we just acquired
      *pdwSupportedOptions = dwSupportedSafety;
      *pdwEnabledOptions   = m_dwCurrentSafety;
    }
    else
    {
      // We don't support this interface
      *pdwSupportedOptions = 0;
      *pdwEnabledOptions   = 0;
    }
    return hr;
  }
  STDMETHOD(SetInterfaceSafetyOptions)(REFIID riid, DWORD dwOptionSetMask, DWORD dwEnabledOptions)
  {
    ATLTRACE(_T("IObjectSafety::SetInterfaceSafetyOptions\n"));
    T* pT = static_cast<T*>(this);
    IUnknown* pUnk;
    
    // Check if we support the interface and return E_NOINTEFACE if we don't
    if (FAILED(pT->GetUnknown()->QueryInterface(riid, (void**)&pUnk)))
      return E_NOINTERFACE;
    pUnk->Release();  // Release the interface we just acquired
    
    // If we are asked to set options we don't support then fail
    if (dwOptionSetMask & ~dwSupportedSafety)
      return E_FAIL;

    // Set the safety options we have been asked to
    m_dwCurrentSafety = m_dwCurrentSafety  & ~dwEnabledOptions | dwOptionSetMask;
    return S_OK;
  }
  DWORD m_dwCurrentSafety;
};

#endif // _ATL_VER 

#endif // __IObjectSafety_FWD_DEFINED__

#ifdef __ATLCTL_H__

////////////////////////////////////////////////////////////////////////////////
/* CAuxPersistPropertyBagImpl

Derive from this along to implement IPersistPropertyBag for non-visual objects.

Enhancement: no need to specify DISPID at PROPERTY_MAP since
we use GetIDsOfNames at CAuxPersistPropertyBagImpl
Example:

  class ATL_NO_VTABLE CFoo :
    public CComObjectRoot,
    ...
    public CAuxPersistPropertyBagImpl<CFoo>
  {
    ...
    BEGIN_PROPERTY_MAP(CFoo)
      PROP_ENTRY_JR("prop1")
      PROP_ENTRY_JR("prop2")
    END_PROPERTY_MAP()
  };
//////////////////////////////////////////////////////////////////////////////*/

#define PROP_ENTRY_JR(szDesc) \
  { OLESTR(szDesc), DISPID_UNKNOWN, &GUID_NULL, &IID_IDispatch },

#define IPersistPropertyBagHelper CAuxPersistPropertyBagImpl

template <class T>
class ATL_NO_VTABLE CAuxPersistPropertyBagImpl: public IPersistPropertyBag
{
public:
  CAuxPersistPropertyBagImpl(): m_bRequiresSave(FALSE) {}
  BOOL m_bRequiresSave;

public:
  // IPersist
  STDMETHOD(GetClassID)(CLSID *pClassID)
  {
    ATLTRACE(_T("CAuxPersistPropertyBagImpl::GetClassID\n"));
    *pClassID = T::GetObjectCLSID();
    return S_OK;
  }

  // IPersistPropertyBag
  //
  STDMETHOD(InitNew)()
  {
    ATLTRACE(_T("CAuxPersistPropertyBagImpl::InitNew\n"));
    return S_OK;
  }
  STDMETHOD(Load)(LPPROPERTYBAG pPropBag, LPERRORLOG pErrorLog)
  {
    ATLTRACE(_T("CAuxPersistPropertyBagImpl::Load\n"));
    T* pT = static_cast<T*>(this);
    ATL_PROPMAP_ENTRY* pMap = T::GetPropertyMap();
    ATLASSERT(pMap != NULL);
    return pT->IPersistPropertyBag_Load(pPropBag, pErrorLog, pMap);
  }
  STDMETHOD(Save)(LPPROPERTYBAG pPropBag, BOOL fClearDirty, BOOL fSaveAllProperties)
  {
    ATLTRACE(_T("CAuxPersistPropertyBagImpl::Save\n"));
    T* pT = static_cast<T*>(this);
    ATL_PROPMAP_ENTRY* pMap = T::GetPropertyMap();
    ATLASSERT(pMap != NULL);
    return pT->IPersistPropertyBag_Save(pPropBag, fClearDirty, fSaveAllProperties, pMap);
  }

  HRESULT IPersistPropertyBag_Load(LPPROPERTYBAG pPropBag,
    LPERRORLOG pErrorLog, ATL_PROPMAP_ENTRY* pMap);
  HRESULT IPersistPropertyBag_Save(LPPROPERTYBAG pPropBag,
    BOOL fClearDirty, BOOL /*fSaveAllProperties*/, ATL_PROPMAP_ENTRY* pMap);
};

template<class T>
HRESULT CAuxPersistPropertyBagImpl<T>::IPersistPropertyBag_Load(LPPROPERTYBAG pPropBag,
  LPERRORLOG pErrorLog, ATL_PROPMAP_ENTRY* pMap)
{
  USES_CONVERSION;
  CComPtr<IDispatch> pDispatch;
  const IID* piidOld = NULL;
  for(int i = 0; pMap[i].pclsidPropPage != NULL; i++)
  {
    if (pMap[i].szDesc == NULL)
      continue;
    CComVariant var;

#if _ATL_VER >= 0x0300 // extra features
    T* pThis = static_cast<T*>(this);

    // If raw entry skip it - we don't handle it for property bags just yet
    if (pMap[i].dwSizeData != 0)
    {
      void* pData = (void*) (pMap[i].dwOffsetData + (DWORD)pThis);
      HRESULT hr = pPropBag->Read(pMap[i].szDesc, &var, pErrorLog);
      if (SUCCEEDED(hr))
      {
        // check the type - we only deal with limited set
        _S( var.ChangeType(pMap[i].vt) );
        switch (var.vt)
        {
          case VT_BSTR:
            *(BSTR*)pData = var.bstrVal;
            VariantInit(&var);
            break;
          case VT_VARIANT:
            _S( VariantCopy((VARIANT*)pData, &var) );
            break;
          case VT_I1:
            *((BYTE*)pData) = var.bVal;
            break;
          case VT_BOOL:
            *((VARIANT_BOOL*)pData) = var.boolVal;
            break;
          case VT_UI2:
            *((short*)pData) = var.iVal;
            break;
          case VT_UI4:
          case VT_INT:
          case VT_UINT:
            *((long*)pData) = var.lVal;
            break;
        }
      }
      continue;
    }
#endif

    if(pMap[i].piidDispatch != piidOld)
    {
      pDispatch.Release();
      if(FAILED(QueryInterface(*pMap[i].piidDispatch, (void**)&pDispatch)))
      {
        TRACE(_T("Failed to get a dispatch pointer for property #%i\n"), i);
        return E_FAIL;
      }
      piidOld = pMap[i].piidDispatch;
    }

    // Andien: if DISPID is unknown, try to get it by name
    MEMBERID memberid = pMap[i].dispid;
    if ( memberid == DISPID_UNKNOWN ) {
      if (FAILED(pDispatch->GetIDsOfNames(IID_NULL, &const_cast<OLECHAR*&>(pMap[i].szDesc), 1, LOCALE_USER_DEFAULT, &memberid)))
      {
        TRACE(_T("GetIDsOfNames failed on DISPID %ls\n"), pMap[i].szDesc);
        return E_FAIL;
      }
    }

    if (FAILED(CComDispatchDriver::GetProperty(pDispatch, memberid, &var)))
    {
      TRACE(_T("Invoked failed on DISPID %x\n"), pMap[i].dispid);
      return E_FAIL;
    }

    HRESULT hr = pPropBag->Read(pMap[i].szDesc, &var, pErrorLog);
    if (FAILED(hr))
    {
      if (hr == E_INVALIDARG)
      {
        TRACE(_T("Property %s not in Bag\n"), OLE2CT(pMap[i].szDesc));
      }
      else
      {
        // Many containers return different ERROR values for Member not found
        TRACE(_T("Error attempting to read Property %s from PropertyBag \n"), OLE2CT(pMap[i].szDesc));
      }
      continue;
    }

    if (FAILED(CComDispatchDriver::PutProperty(pDispatch, memberid, &var)))
    {
      TRACE(_T("Invoke failed on DISPID %x\n"), pMap[i].dispid);
      return E_FAIL;
    }
  }
  return S_OK;
}

template<class T>
HRESULT CAuxPersistPropertyBagImpl<T>::IPersistPropertyBag_Save(LPPROPERTYBAG pPropBag,
  BOOL fClearDirty, BOOL /*fSaveAllProperties*/, ATL_PROPMAP_ENTRY* pMap)
{
  if (pPropBag == NULL)
  {
    TRACE(_T("PropBag pointer passed in was invalid\n"));
    return E_POINTER;
  }

  CComPtr<IDispatch> pDispatch;
  const IID* piidOld = NULL;
  for(int i = 0; pMap[i].pclsidPropPage != NULL; i++)
  {
    if (pMap[i].szDesc == NULL)
      continue;
    CComVariant var;

#if _ATL_VER >= 0x0300 // extra features
    T* pThis = static_cast<T*>(this);

    // If raw entry skip it - we don't handle it for property bags just yet
    if (pMap[i].dwSizeData != 0)
    {
      // check the type - we only deal with limited set
      void* pData = (void*) (pMap[i].dwOffsetData + (DWORD)pThis);
      VARIANT v, *pv = &v;
      v.vt = pMap[i].vt;
      switch (v.vt)
      {
        case VT_BSTR:
          v.bstrVal = *(BSTR*)pData;
          break;
        case VT_VARIANT:
          pv = (VARIANT*)pData;
          break;
        case VT_I1:
          v.bVal = *((BYTE*)pData);
          break;
        case VT_BOOL:
          v.boolVal = *((VARIANT_BOOL*)pData);
          break;
        case VT_UI2:
          v.iVal = *((short*)pData);
          break;
        case VT_UI4:
        case VT_INT:
        case VT_UINT:
          v.lVal = *((long*)pData);
          break;
        default:
          return DISP_E_BADVARTYPE;
      }

      HRESULT hr = pPropBag->Write(pMap[i].szDesc, pv);
      if (FAILED(hr))
      return hr;

      continue;
    }
#endif

    if(pMap[i].piidDispatch != piidOld)
    {
      pDispatch.Release();
      if(FAILED(QueryInterface(*pMap[i].piidDispatch, (void**)&pDispatch)))
      {
        TRACE(_T("Failed to get a dispatch pointer for property #%i\n"), i);
        return E_FAIL;
      }
      piidOld = pMap[i].piidDispatch;
    }

    // Andien: if DISPID is unknown, try to get it by name
    MEMBERID memberid = pMap[i].dispid;
    if ( memberid == DISPID_UNKNOWN ) {
      if (FAILED(pDispatch->GetIDsOfNames(IID_NULL, &const_cast<OLECHAR*&>(pMap[i].szDesc), 1, LOCALE_USER_DEFAULT, &memberid)))
      {
        TRACE(_T("GetIDsOfNames failed on DISPID %ls\n"), pMap[i].szDesc);
        return E_FAIL;
      }
    }

    if (FAILED(CComDispatchDriver::GetProperty(pDispatch, memberid, &var)))
    {
      TRACE(_T("Invoke failed on DISPID %x\n"), pMap[i].dispid);
      return E_FAIL;
    }

    if (var.vt == VT_UNKNOWN || var.vt == VT_DISPATCH)
    {
      if (var.punkVal == NULL)
      {
        TRACE(_T("Warning skipping empty IUnknown in Save\n"));
        continue;
      }
    }

    HRESULT hr = pPropBag->Write(pMap[i].szDesc, &var);
    if (FAILED(hr))
      return hr;
  }
  m_bRequiresSave = FALSE;
  return S_OK;
}

#endif // __ATLCTL_H__

////////////////////////////////////////////////////////////////////////////////
// CAuxGetClassImpl

MIDL_INTERFACE("1b572300-b03f-11d3-b934-002018654e2e")
IGetRawClass: public IUnknown
{
public:
    virtual HRESULT STDMETHODCALLTYPE GetThis(OUT void** p) = 0;
};

template <class T>
class ATL_NO_VTABLE CAuxGetClassImpl: public IGetRawClass
{
public:
  // IGetRawClass
  STDMETHOD(GetThis)(OUT void** p)
  {
    *(T**)(p) = static_cast<T*>(this);
    return S_OK;
  }
};

#define COM_INTERFACE_ENTRY_RAW_CLASS() \
  COM_INTERFACE_ENTRY_IID(GetObjectCLSID(), IGetRawClass)

#endif // __ATLCOM_H__

#if _ATL_VER < 0x0300 // for 2.x only
#endif // _ATL_VER 

////////////////////////////////////////////////////////////////////////////////
// Better CComBSTR inlining

inline bool operator==(const CComBSTR& str1, const CComBSTR& str2) throw()
{
  return CompareBSTR(str1, str2) == 0;
}

inline bool operator<(const CComBSTR& str1, const CComBSTR& str2) throw()
{
  return CompareBSTR(str1, str2) < 0;
}

inline bool operator==(const CComBSTR& s1, LPCWSTR const& s2)
{
	return s1 == (LPWSTR)s2;
}

inline bool operator<(const CComBSTR& s1, LPCWSTR const& s2)
{
	return s1 < (LPWSTR)s2;
}

inline bool operator>(const CComBSTR& s1, LPCWSTR const& s2)
{
	return s1 > (LPWSTR)s2;
}


#pragma pack(pop) // _ATL_PACKING

#endif // _AUX_ATL_DEPENDENT

#endif // __ATLBASE_H__

////////////////////////////////////////////////////////////////////////////////
// ********************* _VarCmp@12 workaround for ATL3 ************************
// Most recent info. Sep'98 Platform SDK comes with \include\atl30 folder with 
// correct atlbase.h and comdef.h. Just add \include\atl30 to the top of 
// VS6 'Include directories' option and you're done.

// VS6 vanilla OleAuto.h prototypes VarCmp incorrecly (dwFlags was forgotten)
// More info: MS KB Q191626,
// http://support.microsoft.com/support/kb/articles/q191/6/26.asp
// I'd recommend to use Sep'98 Platform SDK instead of the below workaround

#if !defined(VarCmp) && _MSC_VER == 1200 && defined(_OLEAUTO_H_) && VARIANT_LOCALBOOL != 0x10 && defined(_M_IX86)
  inline __declspec(naked) HRESULT __stdcall _VarCmp(LPVARIANT pvarLeft, LPVARIANT pvarRight, LCID lcid, ULONG dwFlags = 0)
  {
    static DWORD dwVarCmp;
    if ( !dwVarCmp ) dwVarCmp = (DWORD)GetProcAddress(GetModuleHandle(TEXT("OLEAUT32")), LPCSTR(176U));
    _asm jmp dwVarCmp
  }
  inline __declspec(naked) HRESULT __stdcall _VarBstrCmp(BSTR bstrLeft, BSTR bstrRight, LCID lcid, ULONG dwFlags = 0)
  {
    static DWORD dwVarBstrCmp;
    if ( !dwVarBstrCmp ) dwVarBstrCmp = (DWORD)GetProcAddress(GetModuleHandle(TEXT("OLEAUT32")), LPCSTR(314U));
    _asm jmp dwVarBstrCmp
  }
  #define VarCmp _VarCmp
  #define VarBstrCmp _VarBstrCmp
#endif // _VarCmp@12 workaround 
