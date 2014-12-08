/* this ALWAYS GENERATED file contains the definitions for the interfaces */


/* File created by MIDL compiler version 5.01.0164 */
/* at Wed Aug 22 07:24:48 2007
 */
/* Compiler settings for C:\Temp\COM_Component_Source_Binaries\csExWBDLMan.idl:
    Oicf (OptLev=i2), W1, Zp8, env=Win32, ms_ext, c_ext
    error checks: allocation ref bounds_check enum stub_data 
*/
//@@MIDL_FILE_HEADING(  )


/* verify that the <rpcndr.h> version is high enough to compile this file*/
#ifndef __REQUIRED_RPCNDR_H_VERSION__
#define __REQUIRED_RPCNDR_H_VERSION__ 440
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

#ifdef __cplusplus
extern "C"{
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

void __RPC_FAR * __RPC_USER MIDL_user_allocate(size_t);
void __RPC_USER MIDL_user_free( void __RPC_FAR * ); 

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
            /* [in] */ IMoniker __RPC_FAR *pmk,
            /* [in] */ IBindCtx __RPC_FAR *pbc,
            /* [in] */ DWORD dwBindVerb,
            /* [in] */ LONG grfBINDF,
            /* [in] */ BINDINFO __RPC_FAR *pBindInfo,
            /* [in] */ LPCOLESTR pszHeaders,
            /* [in] */ LPCOLESTR pszRedir,
            /* [in] */ UINT uiCP) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IDownloadManagerVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IDownloadManager __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IDownloadManager __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IDownloadManager __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Download )( 
            IDownloadManager __RPC_FAR * This,
            /* [in] */ IMoniker __RPC_FAR *pmk,
            /* [in] */ IBindCtx __RPC_FAR *pbc,
            /* [in] */ DWORD dwBindVerb,
            /* [in] */ LONG grfBINDF,
            /* [in] */ BINDINFO __RPC_FAR *pBindInfo,
            /* [in] */ LPCOLESTR pszHeaders,
            /* [in] */ LPCOLESTR pszRedir,
            /* [in] */ UINT uiCP);
        
        END_INTERFACE
    } IDownloadManagerVtbl;

    interface IDownloadManager
    {
        CONST_VTBL struct IDownloadManagerVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IDownloadManager_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IDownloadManager_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IDownloadManager_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IDownloadManager_Download(This,pmk,pbc,dwBindVerb,grfBINDF,pBindInfo,pszHeaders,pszRedir,uiCP)	\
    (This)->lpVtbl -> Download(This,pmk,pbc,dwBindVerb,grfBINDF,pBindInfo,pszHeaders,pszRedir,uiCP)

#endif /* COBJMACROS */


#endif 	/* C style interface */



HRESULT STDMETHODCALLTYPE IDownloadManager_Download_Proxy( 
    IDownloadManager __RPC_FAR * This,
    /* [in] */ IMoniker __RPC_FAR *pmk,
    /* [in] */ IBindCtx __RPC_FAR *pbc,
    /* [in] */ DWORD dwBindVerb,
    /* [in] */ LONG grfBINDF,
    /* [in] */ BINDINFO __RPC_FAR *pBindInfo,
    /* [in] */ LPCOLESTR pszHeaders,
    /* [in] */ LPCOLESTR pszRedir,
    /* [in] */ UINT uiCP);


void __RPC_STUB IDownloadManager_Download_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



#endif 	/* __IDownloadManager_INTERFACE_DEFINED__ */


/* interface __MIDL_itf_csExWBDLMan_0258 */
/* [local] */ 

typedef 
enum WINDOWSHOOK_TYPES
    {	WHT_CALLWNDPROC	= 0,
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
    }	WINDOWSHOOK_TYPES;



extern RPC_IF_HANDLE __MIDL_itf_csExWBDLMan_0258_v0_0_c_ifspec;
extern RPC_IF_HANDLE __MIDL_itf_csExWBDLMan_0258_v0_0_s_ifspec;

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
            /* [out][in] */ long __RPC_FAR *DLUID) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_HWNDInternetExplorerServer( 
            /* [retval][out] */ long __RPC_FAR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_HWNDInternetExplorerServer( 
            /* [in] */ long newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_HTTPSprotocol( 
            /* [retval][out] */ VARIANT_BOOL __RPC_FAR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_HTTPSprotocol( 
            /* [in] */ VARIANT_BOOL newVal) = 0;
        
        virtual /* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE get_HTTPprotocol( 
            /* [retval][out] */ VARIANT_BOOL __RPC_FAR *pVal) = 0;
        
        virtual /* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE put_HTTPprotocol( 
            /* [in] */ VARIANT_BOOL newVal) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE CancelFileDownload( 
            /* [in] */ long DlUid) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE SetupWindowsHook( 
            /* [in] */ WINDOWSHOOK_TYPES lHookType,
            /* [in] */ long hwndTargetWnd,
            /* [in] */ VARIANT_BOOL bStart,
            /* [out][in] */ long __RPC_FAR *lUWMHookMsgID) = 0;
        
        virtual /* [helpstring][id] */ HRESULT STDMETHODCALLTYPE HookProcNCode( 
            /* [in] */ WINDOWSHOOK_TYPES lHookType,
            /* [out][in] */ long __RPC_FAR *nCode) = 0;
        
    };
    
#else 	/* C style interface */

    typedef struct IcsDLManVtbl
    {
        BEGIN_INTERFACE
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            IcsDLMan __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            IcsDLMan __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            IcsDLMan __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTypeInfoCount )( 
            IcsDLMan __RPC_FAR * This,
            /* [out] */ UINT __RPC_FAR *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTypeInfo )( 
            IcsDLMan __RPC_FAR * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo __RPC_FAR *__RPC_FAR *ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetIDsOfNames )( 
            IcsDLMan __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR __RPC_FAR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID __RPC_FAR *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Invoke )( 
            IcsDLMan __RPC_FAR * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS __RPC_FAR *pDispParams,
            /* [out] */ VARIANT __RPC_FAR *pVarResult,
            /* [out] */ EXCEPINFO __RPC_FAR *pExcepInfo,
            /* [out] */ UINT __RPC_FAR *puArgErr);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *DownloadUrlAsync )( 
            IcsDLMan __RPC_FAR * This,
            /* [in] */ BSTR URL,
            /* [out][in] */ long __RPC_FAR *DLUID);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *get_HWNDInternetExplorerServer )( 
            IcsDLMan __RPC_FAR * This,
            /* [retval][out] */ long __RPC_FAR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *put_HWNDInternetExplorerServer )( 
            IcsDLMan __RPC_FAR * This,
            /* [in] */ long newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *get_HTTPSprotocol )( 
            IcsDLMan __RPC_FAR * This,
            /* [retval][out] */ VARIANT_BOOL __RPC_FAR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *put_HTTPSprotocol )( 
            IcsDLMan __RPC_FAR * This,
            /* [in] */ VARIANT_BOOL newVal);
        
        /* [helpstring][id][propget] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *get_HTTPprotocol )( 
            IcsDLMan __RPC_FAR * This,
            /* [retval][out] */ VARIANT_BOOL __RPC_FAR *pVal);
        
        /* [helpstring][id][propput] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *put_HTTPprotocol )( 
            IcsDLMan __RPC_FAR * This,
            /* [in] */ VARIANT_BOOL newVal);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *CancelFileDownload )( 
            IcsDLMan __RPC_FAR * This,
            /* [in] */ long DlUid);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *SetupWindowsHook )( 
            IcsDLMan __RPC_FAR * This,
            /* [in] */ WINDOWSHOOK_TYPES lHookType,
            /* [in] */ long hwndTargetWnd,
            /* [in] */ VARIANT_BOOL bStart,
            /* [out][in] */ long __RPC_FAR *lUWMHookMsgID);
        
        /* [helpstring][id] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *HookProcNCode )( 
            IcsDLMan __RPC_FAR * This,
            /* [in] */ WINDOWSHOOK_TYPES lHookType,
            /* [out][in] */ long __RPC_FAR *nCode);
        
        END_INTERFACE
    } IcsDLManVtbl;

    interface IcsDLMan
    {
        CONST_VTBL struct IcsDLManVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define IcsDLMan_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define IcsDLMan_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define IcsDLMan_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define IcsDLMan_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define IcsDLMan_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define IcsDLMan_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define IcsDLMan_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)


#define IcsDLMan_DownloadUrlAsync(This,URL,DLUID)	\
    (This)->lpVtbl -> DownloadUrlAsync(This,URL,DLUID)

#define IcsDLMan_get_HWNDInternetExplorerServer(This,pVal)	\
    (This)->lpVtbl -> get_HWNDInternetExplorerServer(This,pVal)

#define IcsDLMan_put_HWNDInternetExplorerServer(This,newVal)	\
    (This)->lpVtbl -> put_HWNDInternetExplorerServer(This,newVal)

#define IcsDLMan_get_HTTPSprotocol(This,pVal)	\
    (This)->lpVtbl -> get_HTTPSprotocol(This,pVal)

#define IcsDLMan_put_HTTPSprotocol(This,newVal)	\
    (This)->lpVtbl -> put_HTTPSprotocol(This,newVal)

#define IcsDLMan_get_HTTPprotocol(This,pVal)	\
    (This)->lpVtbl -> get_HTTPprotocol(This,pVal)

#define IcsDLMan_put_HTTPprotocol(This,newVal)	\
    (This)->lpVtbl -> put_HTTPprotocol(This,newVal)

#define IcsDLMan_CancelFileDownload(This,DlUid)	\
    (This)->lpVtbl -> CancelFileDownload(This,DlUid)

#define IcsDLMan_SetupWindowsHook(This,lHookType,hwndTargetWnd,bStart,lUWMHookMsgID)	\
    (This)->lpVtbl -> SetupWindowsHook(This,lHookType,hwndTargetWnd,bStart,lUWMHookMsgID)

#define IcsDLMan_HookProcNCode(This,lHookType,nCode)	\
    (This)->lpVtbl -> HookProcNCode(This,lHookType,nCode)

#endif /* COBJMACROS */


#endif 	/* C style interface */



/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IcsDLMan_DownloadUrlAsync_Proxy( 
    IcsDLMan __RPC_FAR * This,
    /* [in] */ BSTR URL,
    /* [out][in] */ long __RPC_FAR *DLUID);


void __RPC_STUB IcsDLMan_DownloadUrlAsync_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE IcsDLMan_get_HWNDInternetExplorerServer_Proxy( 
    IcsDLMan __RPC_FAR * This,
    /* [retval][out] */ long __RPC_FAR *pVal);


void __RPC_STUB IcsDLMan_get_HWNDInternetExplorerServer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE IcsDLMan_put_HWNDInternetExplorerServer_Proxy( 
    IcsDLMan __RPC_FAR * This,
    /* [in] */ long newVal);


void __RPC_STUB IcsDLMan_put_HWNDInternetExplorerServer_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE IcsDLMan_get_HTTPSprotocol_Proxy( 
    IcsDLMan __RPC_FAR * This,
    /* [retval][out] */ VARIANT_BOOL __RPC_FAR *pVal);


void __RPC_STUB IcsDLMan_get_HTTPSprotocol_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE IcsDLMan_put_HTTPSprotocol_Proxy( 
    IcsDLMan __RPC_FAR * This,
    /* [in] */ VARIANT_BOOL newVal);


void __RPC_STUB IcsDLMan_put_HTTPSprotocol_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propget] */ HRESULT STDMETHODCALLTYPE IcsDLMan_get_HTTPprotocol_Proxy( 
    IcsDLMan __RPC_FAR * This,
    /* [retval][out] */ VARIANT_BOOL __RPC_FAR *pVal);


void __RPC_STUB IcsDLMan_get_HTTPprotocol_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id][propput] */ HRESULT STDMETHODCALLTYPE IcsDLMan_put_HTTPprotocol_Proxy( 
    IcsDLMan __RPC_FAR * This,
    /* [in] */ VARIANT_BOOL newVal);


void __RPC_STUB IcsDLMan_put_HTTPprotocol_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IcsDLMan_CancelFileDownload_Proxy( 
    IcsDLMan __RPC_FAR * This,
    /* [in] */ long DlUid);


void __RPC_STUB IcsDLMan_CancelFileDownload_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IcsDLMan_SetupWindowsHook_Proxy( 
    IcsDLMan __RPC_FAR * This,
    /* [in] */ WINDOWSHOOK_TYPES lHookType,
    /* [in] */ long hwndTargetWnd,
    /* [in] */ VARIANT_BOOL bStart,
    /* [out][in] */ long __RPC_FAR *lUWMHookMsgID);


void __RPC_STUB IcsDLMan_SetupWindowsHook_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);


/* [helpstring][id] */ HRESULT STDMETHODCALLTYPE IcsDLMan_HookProcNCode_Proxy( 
    IcsDLMan __RPC_FAR * This,
    /* [in] */ WINDOWSHOOK_TYPES lHookType,
    /* [out][in] */ long __RPC_FAR *nCode);


void __RPC_STUB IcsDLMan_HookProcNCode_Stub(
    IRpcStubBuffer *This,
    IRpcChannelBuffer *_pRpcChannelBuffer,
    PRPC_MESSAGE _pRpcMessage,
    DWORD *_pdwStubPhase);



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
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *QueryInterface )( 
            _IcsDLManEvents __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [iid_is][out] */ void __RPC_FAR *__RPC_FAR *ppvObject);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *AddRef )( 
            _IcsDLManEvents __RPC_FAR * This);
        
        ULONG ( STDMETHODCALLTYPE __RPC_FAR *Release )( 
            _IcsDLManEvents __RPC_FAR * This);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTypeInfoCount )( 
            _IcsDLManEvents __RPC_FAR * This,
            /* [out] */ UINT __RPC_FAR *pctinfo);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetTypeInfo )( 
            _IcsDLManEvents __RPC_FAR * This,
            /* [in] */ UINT iTInfo,
            /* [in] */ LCID lcid,
            /* [out] */ ITypeInfo __RPC_FAR *__RPC_FAR *ppTInfo);
        
        HRESULT ( STDMETHODCALLTYPE __RPC_FAR *GetIDsOfNames )( 
            _IcsDLManEvents __RPC_FAR * This,
            /* [in] */ REFIID riid,
            /* [size_is][in] */ LPOLESTR __RPC_FAR *rgszNames,
            /* [in] */ UINT cNames,
            /* [in] */ LCID lcid,
            /* [size_is][out] */ DISPID __RPC_FAR *rgDispId);
        
        /* [local] */ HRESULT ( STDMETHODCALLTYPE __RPC_FAR *Invoke )( 
            _IcsDLManEvents __RPC_FAR * This,
            /* [in] */ DISPID dispIdMember,
            /* [in] */ REFIID riid,
            /* [in] */ LCID lcid,
            /* [in] */ WORD wFlags,
            /* [out][in] */ DISPPARAMS __RPC_FAR *pDispParams,
            /* [out] */ VARIANT __RPC_FAR *pVarResult,
            /* [out] */ EXCEPINFO __RPC_FAR *pExcepInfo,
            /* [out] */ UINT __RPC_FAR *puArgErr);
        
        END_INTERFACE
    } _IcsDLManEventsVtbl;

    interface _IcsDLManEvents
    {
        CONST_VTBL struct _IcsDLManEventsVtbl __RPC_FAR *lpVtbl;
    };

    

#ifdef COBJMACROS


#define _IcsDLManEvents_QueryInterface(This,riid,ppvObject)	\
    (This)->lpVtbl -> QueryInterface(This,riid,ppvObject)

#define _IcsDLManEvents_AddRef(This)	\
    (This)->lpVtbl -> AddRef(This)

#define _IcsDLManEvents_Release(This)	\
    (This)->lpVtbl -> Release(This)


#define _IcsDLManEvents_GetTypeInfoCount(This,pctinfo)	\
    (This)->lpVtbl -> GetTypeInfoCount(This,pctinfo)

#define _IcsDLManEvents_GetTypeInfo(This,iTInfo,lcid,ppTInfo)	\
    (This)->lpVtbl -> GetTypeInfo(This,iTInfo,lcid,ppTInfo)

#define _IcsDLManEvents_GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)	\
    (This)->lpVtbl -> GetIDsOfNames(This,riid,rgszNames,cNames,lcid,rgDispId)

#define _IcsDLManEvents_Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)	\
    (This)->lpVtbl -> Invoke(This,dispIdMember,riid,lcid,wFlags,pDispParams,pVarResult,pExcepInfo,puArgErr)

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

unsigned long             __RPC_USER  BSTR_UserSize(     unsigned long __RPC_FAR *, unsigned long            , BSTR __RPC_FAR * ); 
unsigned char __RPC_FAR * __RPC_USER  BSTR_UserMarshal(  unsigned long __RPC_FAR *, unsigned char __RPC_FAR *, BSTR __RPC_FAR * ); 
unsigned char __RPC_FAR * __RPC_USER  BSTR_UserUnmarshal(unsigned long __RPC_FAR *, unsigned char __RPC_FAR *, BSTR __RPC_FAR * ); 
void                      __RPC_USER  BSTR_UserFree(     unsigned long __RPC_FAR *, BSTR __RPC_FAR * ); 

/* end of Additional Prototypes */

#ifdef __cplusplus
}
#endif

#endif
