// UrlParts.cpp: implementation of the CUrlParts class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "UrlParts.h"

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CUrlParts::CUrlParts()
{
	Allocated = false;
	dwScheme = (DWORD)0;
	dwHostName = (DWORD)0;
	dwUserName = (DWORD)0;
	dwPassword = (DWORD)0;
	dwUrlPath = (DWORD)0;
	dwExtraInfo = (DWORD)0;
	dwFileName = (DWORD)0;
	dwFileExtension = (DWORD)0;
	dwPort = (DWORD)0;
	lnScheme = INTERNET_SCHEME_DEFAULT;
}

CUrlParts::~CUrlParts()
{
	ResetBuffers();
}

void CUrlParts::ResetBuffers()
{
	if(Allocated == true)
	{
		free(szScheme);
		free(szHostName);
		free(szUserName);
		free(szPassword);
		free(szUrlPath);
		free(szExtraInfo);
		free(szFileName);
		free(szFileExtension);
		dwScheme = (DWORD)0;
		dwHostName = (DWORD)0;
		dwUserName = (DWORD)0;
		dwPassword = (DWORD)0;
		dwUrlPath = (DWORD)0;
		dwExtraInfo = (DWORD)0;
		dwFileName = (DWORD)0;
		dwFileExtension = (DWORD)0;
		dwPort = (DWORD)0;
	}
	Allocated = false;
}

bool CUrlParts::AllocateBuffers(int iNum)
{
	if(Allocated == true)
		ResetBuffers();
	szScheme = (LPTSTR) malloc( (iNum+1) * sizeof(TCHAR));
	//Check
	if(!szScheme)
		return false;
	szHostName = (LPTSTR) malloc((iNum+1) * sizeof(TCHAR));
	szUserName = (LPTSTR) malloc((iNum+1) * sizeof(TCHAR));
	szPassword = (LPTSTR) malloc((iNum+1) * sizeof(TCHAR));
	szUrlPath = (LPTSTR) malloc((iNum+1) * sizeof(TCHAR));
	szExtraInfo = (LPTSTR) malloc((iNum+1) * sizeof(TCHAR));
	szFileName = (LPTSTR) malloc((iNum+1) * sizeof(TCHAR));
	szFileExtension = (LPTSTR) malloc((iNum+1) * sizeof(TCHAR));
	//Check the last one
	if(!szFileExtension)
		return false;
	szScheme[iNum] = _T('\0');
	szHostName[iNum] = _T('\0');
	szUserName[iNum] = _T('\0');
	szPassword[iNum] = _T('\0');
	szUrlPath[iNum] = _T('\0');
	szExtraInfo[iNum] = _T('\0');
	szFileName[iNum] = _T('\0');
	szFileExtension[iNum] = _T('\0');
	return true;
}

bool CUrlParts::SplitUrl(BSTR bUrl)
{
	if(bUrl == NULL)
		return false;

	DWORD ilen = ::SysStringLen(bUrl);
	if(ilen == 0)
		return false;
	//Allocate buffers
	if(AllocateBuffers(ilen) == false)
		return false;

	URL_COMPONENTS URLComponentsOut;
	ZeroMemory((LPVOID)&URLComponentsOut, sizeof(URLComponentsOut));
	URLComponentsOut.dwStructSize = sizeof(URLComponentsOut);

	URLComponentsOut.lpszScheme = szScheme;         // pointer to scheme name
	URLComponentsOut.dwSchemeLength = ilen;     // length of scheme name
	
	URLComponentsOut.lpszHostName = szHostName;       // pointer to host name
	URLComponentsOut.dwHostNameLength = ilen;   // length of host name
	
	URLComponentsOut.lpszUserName = szUserName;       // pointer to user name
	URLComponentsOut.dwUserNameLength = ilen;   // length of user name
	
	URLComponentsOut.lpszPassword = szPassword;       // pointer to password
	URLComponentsOut.dwPasswordLength = ilen;   // length of password
	
	URLComponentsOut.lpszUrlPath = szUrlPath;        // pointer to URL-path
	URLComponentsOut.dwUrlPathLength = ilen;    // length of URL-path
    
	URLComponentsOut.lpszExtraInfo = szExtraInfo;      // pointer to extra information (e.g. ?foo or #foo)
    URLComponentsOut.dwExtraInfoLength = ilen;  // length of extra information
//Flags
	DWORD dwFlags = ICU_DECODE;

//0 default
	//Return as is
//1 ICU_DECODE Converts encoded characters back to their normal form.
	//This can be used only if the user provides buffers in the URL_COMPONENTS structure to copy the components into. 
//8 ICU_ESCAPE Converts all escape sequences (%xx) to their corresponding characters.
	//This can be used only if the user provides buffers in the URL_COMPONENTS structure to copy the components into. 

	//If the pointer contains the address of the user-supplied buffer,
	//the length member must contain the size of the buffer.
	//InternetCrackUrl copies the component into the buffer, and
	//the length member is set to the length of the copied component, minus 1
	//for the trailing string terminator.
	USES_CONVERSION;
	if(!InternetCrackUrl(OLE2T(bUrl), 0, dwFlags, &URLComponentsOut))
		return false;

	dwScheme = URLComponentsOut.dwSchemeLength;
	dwHostName = URLComponentsOut.dwHostNameLength;
	dwUserName = URLComponentsOut.dwUserNameLength;
	dwPassword = URLComponentsOut.dwPasswordLength;
	dwUrlPath = URLComponentsOut.dwUrlPathLength;
	dwExtraInfo = URLComponentsOut.dwExtraInfoLength;
	
	lnScheme = URLComponentsOut.nScheme;

	if(dwUrlPath > 0)
	{
		//Look for filename here
		TCHAR *lpStr1 = szUrlPath;
		lpStr1 += _tcslen(lpStr1);
    	if (*lpStr1 == _T('/'))
    		--lpStr1;
    	while (*lpStr1 != _T('/'))
		{
			//Look for extension at the same time
			
			//if not using ICU_DECODE flag in InternetCrackUrl function,
			//Watch out for decoded charcters,"%2E" -> "."

			//(dwFileExtension == (DWORD)0),
			//To avoid abc.somesite.com.mpg style of file naming
			
			if( (*lpStr1 == _T('.')) && (dwFileExtension == (DWORD)0) )
			{
				dwFileExtension = _tcslen(lpStr1);
				if(dwFileExtension > 0)
				{
					memcpy(szFileExtension, lpStr1, dwFileExtension * sizeof(TCHAR) );
					szFileExtension[dwFileExtension] = _T('\0');
				}
			}
    		--lpStr1;
		}
		lpStr1++;
		dwFileName = _tcslen(lpStr1);
		if(dwFileName > 0)
		{
			memcpy(szFileName, lpStr1, dwFileName * sizeof(TCHAR));
			szFileName[dwFileName] = _T('\0');
		}
	}
	dwPort = URLComponentsOut.nPort;
	return true;
}
/*
	//To use ICU_XXXXX, we need our own buffers
	TCHAR szScheme[INTERNET_MAX_SCHEME_LENGTH];
	TCHAR szHostName[INTERNET_MAX_HOST_NAME_LENGTH];
	TCHAR szUserName[INTERNET_MAX_USER_NAME_LENGTH];
	TCHAR szPassword[INTERNET_MAX_PASSWORD_LENGTH];
	TCHAR szUrlPath[INTERNET_MAX_PATH_LENGTH];
	TCHAR szExtraInfo[INTERNET_MAX_PATH_LENGTH];

	URL_COMPONENTS URLComponentsOut;
	ZeroMemory((LPVOID)&URLComponentsOut, sizeof(URLComponentsOut));
	URLComponentsOut.dwStructSize = sizeof(URLComponentsOut);

	URLComponentsOut.lpszScheme = szScheme;         // pointer to scheme name
	URLComponentsOut.dwSchemeLength = INTERNET_MAX_SCHEME_LENGTH;     // length of scheme name
	
	URLComponentsOut.lpszHostName = szHostName;       // pointer to host name
	URLComponentsOut.dwHostNameLength = INTERNET_MAX_HOST_NAME_LENGTH;   // length of host name
	
	URLComponentsOut.lpszUserName = szUserName;       // pointer to user name
	URLComponentsOut.dwUserNameLength = INTERNET_MAX_USER_NAME_LENGTH;   // length of user name
	
	URLComponentsOut.lpszPassword = szPassword;       // pointer to password
	URLComponentsOut.dwPasswordLength = INTERNET_MAX_PASSWORD_LENGTH;   // length of password
	
	URLComponentsOut.lpszUrlPath = szUrlPath;        // pointer to URL-path
	URLComponentsOut.dwUrlPathLength = INTERNET_MAX_PATH_LENGTH;    // length of URL-path
    
	URLComponentsOut.lpszExtraInfo = szExtraInfo;      // pointer to extra information (e.g. ?foo or #foo)
    URLComponentsOut.dwExtraInfoLength = INTERNET_MAX_PATH_LENGTH;  // length of extra information


	DWORD dwFlags = ICU_DECODE;

//0 default
	//Return as is
//1 ICU_DECODE Converts encoded characters back to their normal form.
	//This can be used only if the user provides buffers in the URL_COMPONENTS structure to copy the components into. 
//8 ICU_ESCAPE Converts all escape sequences (%xx) to their corresponding characters.
	//This can be used only if the user provides buffers in the URL_COMPONENTS structure to copy the components into. 

	//If the pointer contains the address of the user-supplied buffer,
	//the length member must contain the size of the buffer.
	//InternetCrackUrl copies the component into the buffer, and
	//the length member is set to the length of the copied component, minus 1
	//for the trailing string terminator.
	
	if (!InternetCrackUrl(OLE2T(URL), 0, dwFlags, &URLComponentsOut))
	{
		*bSuccess = VARIANT_FALSE;
		return S_OK;
	}
	//
	if(URLComponentsOut.dwSchemeLength > 0)
	{
		strScheme.m_str = ::SysAllocStringLen(T2OLE(szScheme), URLComponentsOut.dwSchemeLength );
	}
	if(URLComponentsOut.dwHostNameLength > 0)
	{
		strHostName.m_str = ::SysAllocStringLen(T2OLE(szHostName), URLComponentsOut.dwHostNameLength );
	}
	if(URLComponentsOut.dwUserNameLength > 0)
	{
		strUserName.m_str = ::SysAllocStringLen(T2OLE(szUserName), URLComponentsOut.dwUserNameLength );
	}
	if(URLComponentsOut.dwPasswordLength > 0)
	{
		strPassword.m_str = ::SysAllocStringLen(T2OLE(szPassword), URLComponentsOut.dwPasswordLength );
	}
	if(URLComponentsOut.dwUrlPathLength > 0)
	{
		strUrlPath.m_str = ::SysAllocStringLen(T2OLE(szUrlPath), URLComponentsOut.dwUrlPathLength );

			//Look for filename here
			TCHAR *lpStr1 = szUrlPath;
			lpStr1 += _tcslen(lpStr1);
    		if (*lpStr1 == '/')
    			--lpStr1;
    		while (*lpStr1 != '/')
			{
				if(*lpStr1 == '.')
					strFileExtension.m_str =  ::SysAllocStringLen(T2OLE(lpStr1), _tcslen(lpStr1));
    			--lpStr1;
			}
			lpStr1++;
			strFileName.m_str = ::SysAllocStringLen(T2OLE(lpStr1), _tcslen(lpStr1) );
	}
	if(URLComponentsOut.dwExtraInfoLength > 0)
	{
		//Uncomment to rid of ? charachter
		//szExtraInfo++;
		strExtraInfo.m_str = ::SysAllocStringLen(T2OLE(szExtraInfo), URLComponentsOut.dwExtraInfoLength);
	}
	Port = (long)URLComponentsOut.nPort;
	//Always return ok here, the actual result is in bSuccess Variant
	return S_OK;
*/