

/* this ALWAYS GENERATED file contains the definitions for the interfaces */


 /* File created by MIDL compiler version 8.00.0603 */
/* at Sat Dec 06 22:56:54 2014
 */
/* Compiler settings for csExWBDLMan.idl:
    Oicf, W1, Zp8, env=Win64 (32b run), target_arch=AMD64 8.00.0603 
    protocol : dce , ms_ext, c_ext, robust
    error checks: allocation ref bounds_check enum stub_data 
    VC __declspec() decoration level: 
         __declspec(uuid()), __declspec(selectany), __declspec(novtable)
         DECLSPEC_UUID(), MIDL_INTERFACE()
*/
/* @@MIDL_FILE_HEADING(  ) */

#pragma warning( disable: 4049 )  /* more than 64k source lines */


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 475
#endif

#include "rpc.h"
#include "rpcndr.h"

#ifndef __RPCNDR_H_VERSION__
#error this stub requires an updated version of <rpcndr.h>
#endif // __RPCNDR_H_VERSION__

#ifndef COM_NO_WINDOWS_H
#include "windows.h"
#include "ole2.h"
#endif /*COM_NO_WINDOWS_H*/

#ifndef __csExWBDLMan_h__
#define __csExWBDLMan_h__

#if defined(_MSC_VER) && (_MSC_VER >= 1020)
#pragma once
#endif

/* Forward Declarations */ 

#ifndef __IDownloadManager_FWD_DEFINED__
#define __IDownloadManager_FWD_DEFINED__
typedef interface IDownloadManager IDownloadManager;

#endif 	/* __IDownloadManager_FWD_DEFINED__ */


#ifndef __IcsDLMan_FWD_DEFINED__
#define __IcsDLMan_FWD_DEFINED__
typedef interface IcsDLMan IcsDLMan;

#endif 	/* __IcsDLMan_FWD_DEFINED__ */


#ifndef ___IcsDLManEvents_FWD_DEFINED__
#define ___IcsDLManEvents_FWD_DEFINED__
typedef interface _IcsDLManEvents _IcsDLManEvents;

#endif 	/* ___IcsDLManEvents_FWD_DEFINED__ */


#ifndef __csDLMan_FWD_DEFINED__
#define __csDLMan_FWD_DEFINED__

#ifdef __cplusplus
typedef class csDLMan csDLMan;
#else
typedef struct csDLMan csDLMan;
#endif /* __cplusplus */

#endif 	/* __csDLMan_FWD_DEFINED__ */


/* header files for imported files */
#include "oaidl.h"
#include "ocidl.h"

#ifdef __cplusplus
extern "C"{
#endif 


#ifndef __IDownloadManager_INTERFACE_DEFINED__
#define __IDownloadManager_INTERFACE_DEFINED__

/* interface IDownloadManager */
/* [local][unique][uuid][object][helpstring] */ 


EXTERN_C const IID IID_IDownloadManager;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("988934A4-064B-11D3-BB80-00104B35E7F9")
    IDownloadManager : public IUnknown
    {
    public:
        virtual HRESULT STDMETHODCALLTYPE Download( 
            /* [in] */ IMoniker *pmk,
            /* [in] */ IBindCtx *pbc,
            /* [in] */ DWORD dwBindVerb,
            /* [in] */ LONG grfBINDF,
            /* [in] */ BINDINFO *pBindInfo,
            /* [in] */ LPCOLESTR pszHeaders,
            /* [in] */ LPCOLESTR pszRedir,
            /* [in] */ UINT uiCP) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IDownloadManagerVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IDownloadManager * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IDownloadManager * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IDownloadManager * This);
        
        HRESULT ( STDMETHODCALLTYPE *Download )( 
            IDownloadManager * This,
            /* [in] */ IMoniker *pmk,
            /* [in] */ IBindCtx *pbc,
            /* [in] */ DWORD dwBindVerb,
            /* [in] */ LONG grfBINDF,
            /* [in] */ BINDINFO *pBindInfo,
            /* [in] */ LPCOLESTR pszHeaders,
            /* [in] */ LPCOLESTR pszRedir,
            /* [in] */ UINT uiCP);
        
        END_INTERFACE
    } IDownloadManagerVtbl;

    interface IDownloadManager
    {
        CONST_VTBL struct IDownloadManagerVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IDownloadManager_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IDownloadManager_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IDownloadManager_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IDownloadManager_Download(This,pmk,pbc,dwBindVerb,grfBINDF,pBindInfo,pszHeaders,pszRedir,uiCP)	\
    ( (This)->lpVtbl -> Download(This,pmk,pbc,dwBindVerb,grfBINDF,pBindInfo,pszHeaders,pszRedir,uiCP) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IDownloadManager_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_csExWBDLMan_0000_0001 */
/* [local] */ 

typedef 
enum WINDOWSHOOK_TYPES
    {
        WHT_CALLWNDPROC	= 0,
        WHT_CBT	= 1,
        WHT_GETMESSAGE	= 2,
        WHT_KEYBOARD	= 3,
        WHT_MOUSE	= 4,
        WHT_MSGFILTER	= 5,
        WHT_KEYBOARD_LL	= 6,
        WHT_MOUSE_LL	= 7,
        WHT_FOREGROUNDIDLE	= 8,
        WHT_CALLWNDPROCRET	= 9,
        WHT_SYSMSGFILTER	= 10,
        WHT_SHELL	= 11
    } 	WINDOWSHOOK_TYPES;



extern RPC_IF_HANDLE __MIDL_itf_csExWBDLMan_0000_0001_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_csExWBDLMan_0000_0001_v0_0_s_ifspec;

#ifndef __IcsDLMan_INTERFACE_DEFINED__
#define __IcsDLMan_INTERFACE_DEFINED__

/* interface IcsDLMan */
/* [unique][helpstring][dual][uuid][object] */ 


EXTERN_C const IID IID_IcsDLMan;

#if defined(__cplusplus) && !defined(CINTERFACE)
    
    MIDL_INTERFACE("5E0CF8CC-2057-4566-B5F6-9AE817E3FB0A")
    IcsDLMan : public IDispatch
    {
    public:
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE DownloadUrlAsync( 
            /* [in] */ BSTR URL,
            /* [out][in] */ long *DLUID) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_HWNDInternetExplorerServer( 
            /* [retval][out] */ long *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_HWNDInternetExplorerServer( 
            /* [in] */ long newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_HTTPSprotocol( 
            /* [retval][out] */ VARIANT_BOOL *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_HTTPSprotocol( 
            /* [in] */ VARIANT_BOOL newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_HTTPprotocol( 
            /* [retval][out] */ VARIANT_BOOL *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_HTTPprotocol( 
            /* [in] */ VARIANT_BOOL newVal) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE CancelFileDownload( 
            /* [in] */ long DlUid) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE SetupWindowsHook( 
            /* [in] */ WINDOWSHOOK_TYPES lHookType,
            /* [in] */ long hwndTargetWnd,
            /* [in] */ VARIANT_BOOL bStart,
            /* [out][in] */ long *lUWMHookMsgID) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE HookProcNCode( 
            /* [in] */ WINDOWSHOOK_TYPES lHookType,
            /* [out][in] */ long *nCode) = 0;
        
    };
    
    
#else 	/* C style interface */

    typedef struct IcsDLManVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            IcsDLMan * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            IcsDLMan * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            IcsDLMan * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            IcsDLMan * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            IcsDLMan * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            IcsDLMan * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            IcsDLMan * This,
            /* [annotation][in] */ 
            _In_  DISPID dispIdMember,
            /* [annotation][in] */ 
            _In_  REFIID riid,
            /* [annotation][in] */ 
            _In_  LCID lcid,
            /* [annotation][in] */ 
            _In_  WORD wFlags,
            /* [annotation][out][in] */ 
            _In_  DISPPARAMS *pDispParams,
            /* [annotation][out] */ 
            _Out_opt_  VARIANT *pVarResult,
            /* [annotation][out] */ 
            _Out_opt_  EXCEPINFO *pExcepInfo,
            /* [annotation][out] */ 
            _Out_opt_  UINT *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *DownloadUrlAsync )( 
            IcsDLMan * This,
            /* [in] */ BSTR URL,
            /* [out][in] */ long *DLUID);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_HWNDInternetExplorerServer )( 
            IcsDLMan * This,
            /* [retval][out] */ long *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_HWNDInternetExplorerServer )( 
            IcsDLMan * This,
            /* [in] */ long newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_HTTPSprotocol )( 
            IcsDLMan * This,
            /* [retval][out] */ VARIANT_BOOL *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_HTTPSprotocol )( 
            IcsDLMan * This,
            /* [in] */ VARIANT_BOOL newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE *get_HTTPprotocol )( 
            IcsDLMan * This,
            /* [retval][out] */ VARIANT_BOOL *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE *put_HTTPprotocol )( 
            IcsDLMan * This,
            /* [in] */ VARIANT_BOOL newVal);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *CancelFileDownload )( 
            IcsDLMan * This,
            /* [in] */ long DlUid);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *SetupWindowsHook )( 
            IcsDLMan * This,
            /* [in] */ WINDOWSHOOK_TYPES lHookType,
            /* [in] */ long hwndTargetWnd,
            /* [in] */ VARIANT_BOOL bStart,
            /* [out][in] */ long *lUWMHookMsgID);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE *HookProcNCode )( 
            IcsDLMan * This,
            /* [in] */ WINDOWSHOOK_TYPES lHookType,
            /* [out][in] */ long *nCode);
        
        END_INTERFACE
    } IcsDLManVtbl;

    interface IcsDLMan
    {
        CONST_VTBL struct IcsDLManVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IcsDLMan_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define IcsDLMan_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define IcsDLMan_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define IcsDLMan_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define IcsDLMan_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define IcsDLMan_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define IcsDLMan_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 


#define IcsDLMan_DownloadUrlAsync(This,URL,DLUID)	\
    ( (This)->lpVtbl -> DownloadUrlAsync(This,URL,DLUID) ) 

#define IcsDLMan_get_HWNDInternetExplorerServer(This,pVal)	\
    ( (This)->lpVtbl -> get_HWNDInternetExplorerServer(This,pVal) ) 

#define IcsDLMan_put_HWNDInternetExplorerServer(This,newVal)	\
    ( (This)->lpVtbl -> put_HWNDInternetExplorerServer(This,newVal) ) 

#define IcsDLMan_get_HTTPSprotocol(This,pVal)	\
    ( (This)->lpVtbl -> get_HTTPSprotocol(This,pVal) ) 

#define IcsDLMan_put_HTTPSprotocol(This,newVal)	\
    ( (This)->lpVtbl -> put_HTTPSprotocol(This,newVal) ) 

#define IcsDLMan_get_HTTPprotocol(This,pVal)	\
    ( (This)->lpVtbl -> get_HTTPprotocol(This,pVal) ) 

#define IcsDLMan_put_HTTPprotocol(This,newVal)	\
    ( (This)->lpVtbl -> put_HTTPprotocol(This,newVal) ) 

#define IcsDLMan_CancelFileDownload(This,DlUid)	\
    ( (This)->lpVtbl -> CancelFileDownload(This,DlUid) ) 

#define IcsDLMan_SetupWindowsHook(This,lHookType,hwndTargetWnd,bStart,lUWMHookMsgID)	\
    ( (This)->lpVtbl -> SetupWindowsHook(This,lHookType,hwndTargetWnd,bStart,lUWMHookMsgID) ) 

#define IcsDLMan_HookProcNCode(This,lHookType,nCode)	\
    ( (This)->lpVtbl -> HookProcNCode(This,lHookType,nCode) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */




#endif 	/* __IcsDLMan_INTERFACE_DEFINED__ */



#ifndef __CSEXWBDLMANLib_LIBRARY_DEFINED__
#define __CSEXWBDLMANLib_LIBRARY_DEFINED__

/* library CSEXWBDLMANLib */
/* [helpstring][version][uuid] */ 


EXTERN_C const IID LIBID_CSEXWBDLMANLib;

#ifndef ___IcsDLManEvents_DISPINTERFACE_DEFINED__
#define ___IcsDLManEvents_DISPINTERFACE_DEFINED__

/* dispinterface _IcsDLManEvents */
/* [helpstring][uuid] */ 


EXTERN_C const IID DIID__IcsDLManEvents;

#if defined(__cplusplus) && !defined(CINTERFACE)

    MIDL_INTERFACE("AD7128D1-B6B9-4F0F-A021-5F2486CCBCC3")
    _IcsDLManEvents : public IDispatch
    {
    };
    
#else 	/* C style interface */

    typedef struct _IcsDLManEventsVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE *QueryInterface )( 
            _IcsDLManEvents * This,
            /* [in] */ REFIID riid,
            /* [annotation][iid_is][out] */ 
            _COM_Outptr_  void **ppvObject);
        
        ULONG ( STDMETHODCALLTYPE *AddRef )( 
            _IcsDLManEvents * This);
        
        ULONG ( STDMETHODCALLTYPE *Release )( 
            _IcsDLManEvents * This);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfoCount )( 
            _IcsDLManEvents * This,
            /* [out] */ UINT *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetTypeInfo )( 
            _IcsDLManEvents * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo **ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE *GetIDsOfNames )( 
            _IcsDLManEvents * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR *rgszNames,
            /* [range][in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE *Invoke )( 
            _IcsDLManEvents * This,
            /* [annotation][in] */ 
            _In_  DISPID dispIdMember,
            /* [annotation][in] */ 
            _In_  REFIID riid,
            /* [annotation][in] */ 
            _In_  LCID lcid,
            /* [annotation][in] */ 
            _In_  WORD wFlags,
            /* [annotation][out][in] */ 
            _In_  DISPPARAMS *pDispParams,
            /* [annotation][out] */ 
            _Out_opt_  VARIANT *pVarResult,
            /* [annotation][out] */ 
            _Out_opt_  EXCEPINFO *pExcepInfo,
            /* [annotation][out] */ 
            _Out_opt_  UINT *puArgErr);
        
        END_INTERFACE
    } _IcsDLManEventsVtbl;

    interface _IcsDLManEvents
    {
        CONST_VTBL struct _IcsDLManEventsVtbl *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _IcsDLManEvents_QueryInterface(This,riid,ppvObject)	\
    ( (This)->lpVtbl -> QueryInterface(This,riid,ppvObject) ) 

#define _IcsDLManEvents_AddRef(This)	\
    ( (This)->lpVtbl -> AddRef(This) ) 

#define _IcsDLManEvents_Release(This)	\
    ( (This)->lpVtbl -> Release(This) ) 


#define _IcsDLManEvents_GetTypeInfoCount(This,pctinfo)	\
    ( (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo) ) 

#define _IcsDLManEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    ( (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo) ) 

#define _IcsDLManEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    ( (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId) ) 

#define _IcsDLManEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    ( (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr) ) 

#endif /* COBJMACROS */


#endif 	/* C style interface */


#endif 	/* ___IcsDLManEvents_DISPINTERFACE_DEFINED__ */


EXTERN_C const CLSID CLSID_csDLMan;

#ifdef __cplusplus

class DECLSPEC_UUID("A1FE23EF-03EF-4759-B021-668443C37A24")
csDLMan;
#endif
#endif /* __CSEXWBDLMANLib_LIBRARY_DEFINED__ */

/* Additional Prototypes for ALL interfaces */

unsigned long             __RPC_USER  BSTR_UserSize(     unsigned long *, unsigned long            , BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserMarshal(  unsigned long *, unsigned char *, BSTR * ); 
unsigned char * __RPC_USER  BSTR_UserUnmarshal(unsigned long *, unsigned char *, BSTR * ); 
void                      __RPC_USER  BSTR_UserFree(     unsigned long *, BSTR * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif


