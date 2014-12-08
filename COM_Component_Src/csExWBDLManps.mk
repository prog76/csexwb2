
csExWBDLManps.dll: dlldata.obj csExWBDLMan_p.obj csExWBDLMan_i.obj
	link /dll /out:csExWBDLManps.dll /def:csExWBDLManps.def /entry:DllMain dlldata.obj csExWBDLMan_p.obj csExWBDLMan_i.obj \
		kernel32.lib rpcndr.lib rpcns4.lib rpcrt4.lib oleaut32.lib uuid.lib \

.c.obj:
	cl /c /Ox /DWIN32 /D_WIN32_WINNT=0x0400 /DREGISTER_PROXY_DLL \
		$<

clean:
	@del csExWBDLManps.dll
	@del csExWBDLManps.lib
	@del csExWBDLManps.exp
	@del dlldata.obj
	@del csExWBDLMan_p.obj
	@del csExWBDLMan_i.obj
