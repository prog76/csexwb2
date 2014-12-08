////////////////////////////////////////////////////////////////////////////////
// ATL/AUX -- COM/ATL Useful Helpers
// AuxCrt.cpp - custom _ATL_MIN_CRT implementation
// Provides proper initialization/destruction of global C++ objects, ATL2/3-compatible
// Remake of ATL3 ATLIMPL.CPP, by Andrew Nosenko (andien@geocities.com),
// http://www.geocities.com/~andien/atlaux.htm
//
// To use it, take care to:
// - Turn off exception handling
// - DO NOT specify DllMain as EntryPoint at "Linker/Output" Options Tab at all
//   (or specify _DllMainCRTStartup there)
// - Replace AtlImpl.cpp with AuxCrt.cpp at the StdAfx.cpp:
//     #include <AuxCrt.cpp> // includes AtlImpl.cpp inside

/* Change Log:
1.00.0000
  - Created.
*/

#ifndef __ATLBASE_H__
  #error AuxCrt.cpp requires atlbase.h to be included first
#endif

#ifdef _ATL_MIN_CRT

/////////////////////////////////////////////////////////////////////////////
// Heap Allocation

#ifndef _DEBUG

#ifndef _MERGE_PROXYSTUB
//rpcproxy.h does the same thing as this
int __cdecl _purecall()
{
  DebugBreak();
  return 0;
}
#endif

#if !defined(_M_ALPHA) && !defined(_M_PPC)
//RISC always initializes floating point and always defines _fltused
extern "C" const int _fltused = 0;
#endif

static const int nExtraAlloc = 8;
static const int nOffsetBlock = nExtraAlloc/sizeof(HANDLE);

void* __cdecl malloc(size_t n)
{
  HANDLE hHeap;
#if _ATL_VER >= 0x0300 && !defined(_ATL_NO_MP_HEAP)
  if ( _Module.m_phHeaps != NULL ) {
    int nHeap = _Module.m_nHeap++;
    hHeap = _Module.m_phHeaps[nHeap & _Module.m_dwHeaps];
  }
  else
#endif
  // andien: may need to overallocate and remember the heap handle 
  // as ATL heap may be not yet init'ed for use from global C++ objects
  hHeap = _Module.m_hHeap? _Module.m_hHeap: GetProcessHeap();

  // overallocate to remember the heap handle
  void* pv = NULL;
  HANDLE* pBlock = (HANDLE*)HeapAlloc(hHeap, 0, n + nExtraAlloc);
  if ( pBlock != NULL )
  {
    *pBlock = hHeap;
    pv = (void*)(pBlock + nOffsetBlock);
  }
  else
    pv = NULL;
  return pv;
}

void* __cdecl calloc(size_t n, size_t s)
{
  return malloc(n*s);
}

void* __cdecl realloc(void* p, size_t n)
{
  if ( p == NULL )
    return malloc(n);
  HANDLE* pHeap = ((HANDLE*)p)-nOffsetBlock;
  pHeap = (HANDLE*)HeapReAlloc(*pHeap, 0, pHeap, n + nExtraAlloc);
  return (pHeap != NULL) ? pHeap + nOffsetBlock : NULL;
}

void __cdecl free(void* p)
{
  if ( p == NULL )
    return;
  HANDLE* pHeap = ((HANDLE*)p)-nOffsetBlock;
  HeapFree(*pHeap, 0, pHeap);
}

void* __cdecl operator new(size_t n)
{
  return malloc(n);
}

void __cdecl operator delete(void* p)
{
  free(p);
}

#endif  //_DEBUG

////////////////////////////////////////////////////////////////////////
// Application/DLL entry point with C++ ctors/dtors invocation
extern "C" {

////////////////////////////////////////////////////////////////////////
// init/term tables

typedef void (__cdecl *_PVFV)(void);

#pragma comment(linker, "/merge:.CRT=.data")

#pragma data_seg(".CRT$XIA")
// Begin C Initializer Sections
_PVFV xia[] = { NULL };

#pragma data_seg(".CRT$XIZ")
// End C Initializer Sections
_PVFV xiz[] = { NULL };

#pragma data_seg(".CRT$XCA")
// Begin C++ Constructor Sections
_PVFV xca[] = { NULL };

#pragma data_seg(".CRT$XCZ")
// End C++ Constructor Sections
_PVFV xcz[] = { NULL };

#pragma data_seg(".CRT$XPA")
// Begin C Pre-Terminator Sections
_PVFV xpa[] = { NULL };

#pragma data_seg(".CRT$XPZ")
// End C Pre-Terminator Sections
_PVFV xpz[] = { NULL };

#pragma data_seg(".CRT$XTA")
// Begin C Terminator Sections
_PVFV xta[] = { NULL };

#pragma data_seg(".CRT$XTZ")
// End C Terminator Sections
_PVFV xtz[] = { NULL };

#pragma data_seg()  // reset

static void initterm(_PVFV pfn[], UINT c) {
  for ( UINT i = 0; i < c; i++ )
    if ( pfn[i] ) (*pfn[i])();
}

static void invokedtors(_PVFV pfn[], UINT c) {
  if ( c > 0 ) { // reverse order
    do (*pfn[--c])(); while ( c );
  }
}

////////////////////////////////////////////////////////////////////////
// abort
// unconditionally terminates application

void __cdecl abort() {
  LPTSTR lpMessage;
  DWORD dwErrCode = GetLastError();
  FormatMessage(
    FORMAT_MESSAGE_ALLOCATE_BUFFER |
    FORMAT_MESSAGE_FROM_SYSTEM,
    NULL,     // no source buffer needed
    dwErrCode,// error code for this message
    NULL,     // default language ID
    (LPTSTR)&lpMessage,  // allocated by fcn
    NULL,     // minimum size of buffer
    NULL);    // no inserts

  HWND hwndParent = GetActiveWindow();
  if ( hwndParent ) hwndParent = GetLastActivePopup(hwndParent);
  MessageBox(
    hwndParent, lpMessage, _T("Abnormal program termination"),
    MB_SETFOREGROUND | MB_ICONSTOP | MB_OK );
  ExitProcess(dwErrCode? dwErrCode: ~0);
}

////////////////////////////////////////////////////////////////////////
// atexit
// maintain the table of dtor ptrs

static _PVFV* ppfnTerm;
static UINT cTerms;

int __cdecl atexit(_PVFV pfn) {
  static UINT cAlloc;
  const ALLOC_STEP = 16;

  if ( cTerms >= cAlloc ) {
    cAlloc += ALLOC_STEP;
    ppfnTerm = (_PVFV*)realloc(ppfnTerm, sizeof(_PVFV)*cAlloc);
    if ( !ppfnTerm ) abort();
  }

  ppfnTerm[cTerms++] = pfn;
  return 0;
}

/////////////////////////////////////////////////////////////////////////////
// Startup Code

#if defined(_WINDLL) || defined(_USRDLL)

// Declare DllMain
BOOL WINAPI DllMain(HANDLE hDllHandle, DWORD dwReason, LPVOID lpReserved);

BOOL WINAPI _DllMainCRTStartup(HANDLE hDllHandle, DWORD dwReason, LPVOID lpReserved)
{
  if ( dwReason == DLL_PROCESS_ATTACH ) {
    // invoke initializers
    initterm(xia, xiz-xia); // C initializers
    initterm(xca, xcz-xca); // C++ constructors
  }
  else if ( dwReason == DLL_PROCESS_DETACH ) {
    BOOL fRes = DllMain(hDllHandle, dwReason, lpReserved);

    // invoke terminators
    invokedtors(ppfnTerm, cTerms);
    free(ppfnTerm);

    initterm(xpa, xpz-xpa); // C Pre-Terminator Sections
    initterm(xta, xtz-xta); // C Terminator Sections

    return fRes;
  }
  return DllMain(hDllHandle, dwReason, lpReserved);
}

#else

// wWinMain is not defined in winbase.h.
int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPWSTR lpCmdLine, int nShowCmd);

#define SPACECHAR   _T(' ')
#define DQUOTECHAR  _T('\"')


#ifdef _UNICODE
void wWinMainCRTStartup()
#else // _UNICODE
void WinMainCRTStartup()
#endif // _UNICODE
{
  SetLastError(NO_ERROR);

  LPTSTR lpszCommandLine = ::GetCommandLine();
  if(lpszCommandLine == NULL)
    ::ExitProcess((UINT)-1);

  // Skip past program name (first token in command line).
  // Check for and handle quoted program name.
  if(*lpszCommandLine == DQUOTECHAR)
  {
    // Scan, and skip over, subsequent characters until
    // another double-quote or a null is encountered.
    do
    {
      lpszCommandLine = ::CharNext(lpszCommandLine);
    }
    while((*lpszCommandLine != DQUOTECHAR) && (*lpszCommandLine != _T('\0')));

    // If we stopped on a double-quote (usual case), skip over it.
    if(*lpszCommandLine == DQUOTECHAR)
      lpszCommandLine = ::CharNext(lpszCommandLine);
  }
  else
  {
    while(*lpszCommandLine > SPACECHAR)
      lpszCommandLine = ::CharNext(lpszCommandLine);
  }

  // Skip past any white space preceeding the second token.
  while(*lpszCommandLine && (*lpszCommandLine <= SPACECHAR))
    lpszCommandLine = ::CharNext(lpszCommandLine);

  STARTUPINFO StartupInfo;
  StartupInfo.dwFlags = 0;
  ::GetStartupInfo(&StartupInfo);

  // invoke initializers
  initterm(xia, xiz-xia); // C initializers
  initterm(xca, xcz-xca); // C++ constructors

  // run WinMain
  int nRet = _tWinMain(::GetModuleHandle(NULL), NULL, lpszCommandLine,
    (StartupInfo.dwFlags & STARTF_USESHOWWINDOW) ?
    StartupInfo.wShowWindow : SW_SHOWDEFAULT);

  // invoke terminators
  invokedtors(ppfnTerm, cTerms);
  free(ppfnTerm);

  initterm(xpa, xpz-xpa); // C Pre-Terminator Sections
  initterm(xta, xtz-xta); // C Terminator Sections

  ::ExitProcess((UINT)nRet);
}

#endif // defined(_WINDLL) | defined(_USRDLL)

} // extern "C"

#undef _ATL_MIN_CRT // andien: to block AtlImpl.cpp
#include <AtlImpl.cpp>
#define _ATL_MIN_CRT

#else //_ATL_MIN_CRT

#include <AtlImpl.cpp>

#endif //_ATL_MIN_CRT
