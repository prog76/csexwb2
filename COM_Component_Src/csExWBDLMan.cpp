// csExWBDLMan.cpp : Implementation of DLL Exports.


// Note: Proxy/Stub Information
//      To build a separate proxy/stub DLL, 
//      run nmake -f csExWBDLManps.mk in the project directory.

#include "stdafx.h"
#include "resource.h"
#include <initguid.h>

CSimpleArray<void*> gCtrlInstances;
BOOL gb_IsHttpRegistered;
BOOL gb_IsHttpsRegistered;
CComPtr<IClassFactory> m_spCFHTTP;
CComPtr<IClassFactory> m_spCFHTTPS;

#include "csExWBDLMan.h"

#include "csExWBDLMan_i.c"
#include "csDLMan.h"


CComModule _Module;

BEGIN_OBJECT_MAP(ObjectMap)
OBJECT_ENTRY(CLSID_csDLMan, CcsDLMan)
END_OBJECT_MAP()

/////////////////////////////////////////////////////////////////////////////
// DLL Entry Point

extern "C"
BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID /*lpReserved*/)
{
    if (dwReason == DLL_PROCESS_ATTACH)
    {
		//Default is false
		gb_IsHttpRegistered = FALSE;
		gb_IsHttpsRegistered = FALSE;
        _Module.Init(ObjectMap, hInstance, &LIBID_CSEXWBDLMANLib);
        DisableThreadLibraryCalls(hInstance);
		// Initialize COM library
		OleInitialize(NULL);
    }
    else if (dwReason == DLL_PROCESS_DETACH)
	{
		// Release COM library
	    OleUninitialize();
		//Any registered HTTPProtocol + HTTPSProtocol
		//will be unregistered once we are done here
		if(gCtrlInstances.GetSize() > 0)
		{
			for(int i = 0; i < gCtrlInstances.GetSize(); i++)
				gCtrlInstances[i] = NULL;
		}
		gCtrlInstances.RemoveAll();
        _Module.Term();
	}
    return TRUE;    // ok
}

/////////////////////////////////////////////////////////////////////////////
// Used to determine whether the DLL can be unloaded by OLE

STDAPI DllCanUnloadNow(void)
{
    return (_Module.GetLockCount()==0) ? S_OK : S_FALSE;
}

/////////////////////////////////////////////////////////////////////////////
// Returns a class factory to create an object of the requested type

STDAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, LPVOID* ppv)
{
    return _Module.GetClassObject(rclsid, riid, ppv);
}

/////////////////////////////////////////////////////////////////////////////
// DllRegisterServer - Adds entries to the system registry

STDAPI DllRegisterServer(void)
{
    // registers object, typelib and all interfaces in typelib
    return _Module.RegisterServer(TRUE);
}

/////////////////////////////////////////////////////////////////////////////
// DllUnregisterServer - Removes entries from the system registry

STDAPI DllUnregisterServer(void)
{
    return _Module.UnregisterServer(TRUE);
}


