/* this file contains the actual definitions of */
/* the IIDs and CLSIDs */

/* link this file in with the server and any clients */


/* File created by MIDL compiler version 5.01.0164 */
/* at Wed Aug 22 07:24:48 2007
 */
/* Compiler settings for C:\Temp\COM_Component_Source_Binaries\csExWBDLMan.idl:
    Oicf (OptLev=i2), W1, Zp8, env=Win32, ms_ext, c_ext
    error checks: allocation ref bounds_check enum stub_data 
*/
//@@MIDL_FILE_HEADING(  )
#ifdef __cplusplus
extern "C"{
#endif 


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

const IID IID_IDownloadManager = {0x988934A4,0x064B,0x11D3,{0xBB,0x80,0x00,0x10,0x4B,0x35,0xE7,0xF9}};


const IID IID_IcsDLMan = {0x5E0CF8CC,0x2057,0x4566,{0xB5,0xF6,0x9A,0xE8,0x17,0xE3,0xFB,0x0A}};


const IID LIBID_CSEXWBDLMANLib = {0x8F81BC06,0xC252,0x4437,{0x92,0xEC,0xE3,0x43,0xAF,0xBA,0xA0,0x3A}};


const IID DIID__IcsDLManEvents = {0xAD7128D1,0xB6B9,0x4F0F,{0xA0,0x21,0x5F,0x24,0x86,0xCC,0xBC,0xC3}};


const CLSID CLSID_csDLMan = {0xA1FE23EF,0x03EF,0x4759,{0xB0,0x21,0x66,0x84,0x43,0xC3,0x7A,0x24}};


#ifdef __cplusplus
}
#endif

