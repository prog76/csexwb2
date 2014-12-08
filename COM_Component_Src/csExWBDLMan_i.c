

/* this ALWAYS GENERATED file contains the IIDs and CLSIDs */

/* link this file in with the server and any clients */


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


#ifdef __cplusplus
extern "C"{
#endif 


#include <rpc.h>
#include <rpcndr.h>

#ifdef _MIDL_USE_GUIDDEF_

#ifndef INITGUID
#define INITGUID
#include <guiddef.h>
#undef INITGUID
#else
#include <guiddef.h>
#endif

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        DEFINE_GUID(name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8)

#else // !_MIDL_USE_GUIDDEF_

#ifndef __IID_DEFINED__
#define __IID_DEFINED__

typedef struct _IID
{
    unsigned long x;
    unsigned short s1;
    unsigned short s2;
    unsigned char  c[8];
} IID;

#endif // __IID_DEFINED__

#ifndef CLSID_DEFINED
#define CLSID_DEFINED
typedef IID CLSID;
#endif // CLSID_DEFINED

#define MIDL_DEFINE_GUID(type,name,l,w1,w2,b1,b2,b3,b4,b5,b6,b7,b8) \
        const type name = {l,w1,w2,{b1,b2,b3,b4,b5,b6,b7,b8}}

#endif !_MIDL_USE_GUIDDEF_

MIDL_DEFINE_GUID(IID, IID_IDownloadManager,0x988934A4,0x064B,0x11D3,0xBB,0x80,0x00,0x10,0x4B,0x35,0xE7,0xF9);


MIDL_DEFINE_GUID(IID, IID_IcsDLMan,0x5E0CF8CC,0x2057,0x4566,0xB5,0xF6,0x9A,0xE8,0x17,0xE3,0xFB,0x0A);


MIDL_DEFINE_GUID(IID, LIBID_CSEXWBDLMANLib,0x8F81BC06,0xC252,0x4437,0x92,0xEC,0xE3,0x43,0xAF,0xBA,0xA0,0x3A);


MIDL_DEFINE_GUID(IID, DIID__IcsDLManEvents,0xAD7128D1,0xB6B9,0x4F0F,0xA0,0x21,0x5F,0x24,0x86,0xCC,0xBC,0xC3);


MIDL_DEFINE_GUID(CLSID, CLSID_csDLMan,0xA1FE23EF,0x03EF,0x4759,0xB0,0x21,0x66,0x84,0x43,0xC3,0x7A,0x24);

#undef MIDL_DEFINE_GUID

#ifdef __cplusplus
}
#endif



