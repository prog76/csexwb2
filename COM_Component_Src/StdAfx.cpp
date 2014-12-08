// stdafx.cpp : source file that includes just the standard includes
//  stdafx.pch will be the pre-compiled header
//  stdafx.obj will contain the pre-compiled type information

#include "stdafx.h"

#ifdef _ATL_STATIC_REGISTRY
#include <statreg.h>

#if _ATL_VER < 0x0700
#include <statreg.cpp>
#endif // _ATL_VER < 0x0700

#endif

#if _ATL_VER < 0x0700
#include <AuxCrt.cpp> // #include <atlimpl.cpp>
#endif // _ATL_VER < 0x0700

/*
Standard _ATL_MIN_CRT support does the job for eliminating the CRT overhead well.
But unfortunately, it doesn't support the use of global C++ constructs, like the following:
////////////////////
class CTest {
public:
  CTest() { 
    MessageBox(NULL, _T("Hello, I'm intitialized"), 
                     _T("Static object"), MB_SETFOREGROUND | MB_OK);
  }
  ~CTest() { 
    MessageBox(NULL, _T("Bye, I'm done"), _T("Static object"), 
                     MB_SETFOREGROUND | MB_OK);
  }
};

static CTest g_test;
extern CTest *gp_Test;
//////////////////////
The above would lead to linker conflicts, because CRT code for
constructors/destructors invocation would be referenced.
To overcome this, I've made AuxCrt.cpp, a small replacement of
AtlImpl.cpp that provides required CRT functionality at the same cost
(i.e., no extra overhead). Its use is simple:

1) Do not specify DllMain as Entry Point in the project Linker/Output Options tab
   (or specify _DllMainCRTStartup). 
2) Replace AtlImpl.cpp with AuxCrt.cpp at the StdAfx.cpp file:
*/