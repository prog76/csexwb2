// UrlParts.h: interface for the CUrlParts class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_URLPARTS_H__142A1831_D146_4168_B37B_8DEB367FF92D__INCLUDED_)
#define AFX_URLPARTS_H__142A1831_D146_4168_B37B_8DEB367FF92D__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include <wininet.h>

class CUrlParts  
{
public:
	CUrlParts();
	~CUrlParts();

	bool SplitUrl(BSTR bUrl);

	inline INTERNET_SCHEME GetInternetScheme(void) const { return lnScheme; }
	inline LPCTSTR GetScheme(void) const { return szScheme; }
	inline LPCTSTR GetHostName(void) const { return szHostName; }
	inline LPCTSTR GetUserName(void) const { return szUserName; }
	inline LPCTSTR GetPassword(void) const { return szPassword; }
	inline LPCTSTR GetUrlPath(void) const { return szUrlPath; }
	inline LPCTSTR GetExtraInfo(void) const { return szExtraInfo; }
	inline LPCTSTR GetFileName(void) const { return szFileName; }
	inline LPCTSTR GetFileExtension(void) const { return szFileExtension; }

	BSTR GetFileNameAsBSTR(void) const
	{
		CComBSTR m_str1(L"");
		if(dwFileName > 0)
		{
			m_str1.Empty();
			m_str1 = szFileName;
		}
		return m_str1.Copy();
	}

	BSTR GetFileExtensionAsBSTR(void) const
	{
		CComBSTR m_str1(L"");
		if(dwFileName > 0)
		{
			m_str1.Empty();
			m_str1 = szFileExtension;
		}
		return m_str1.Copy();
	}

	inline DWORD GetSchemeLen(void) { return dwScheme; }
	inline DWORD GetHostNameLen(void) { return dwHostName; }
	inline DWORD GetUserNameLen(void) { return dwUserName; }
	inline DWORD GetPasswordLen(void) { return dwPassword; }
	inline DWORD GetUrlPathLen(void) { return dwUrlPath; }
	inline DWORD GetExtraInfoLen(void) { return dwExtraInfo; }
	inline DWORD GetFileNameLen(void) { return dwFileName; }
	inline DWORD GetFileExtensionLen(void) { return dwFileExtension; }
	inline DWORD GetPort(void) { return dwPort; }
	void ResetBuffers();

private:
	bool Allocated;

	LPTSTR szScheme;
	LPTSTR szHostName;
	LPTSTR szUserName;
	LPTSTR szPassword;
	LPTSTR szUrlPath;
	LPTSTR szExtraInfo;
	LPTSTR szFileName;
	LPTSTR szFileExtension;

	DWORD dwScheme;
	DWORD dwHostName;
	DWORD dwUserName;
	DWORD dwPassword;
	DWORD dwUrlPath;
	DWORD dwExtraInfo;
	DWORD dwFileName;
	DWORD dwFileExtension;
	DWORD dwPort;
	
	INTERNET_SCHEME lnScheme;
	
	
	bool AllocateBuffers(int iNum);
};

#endif // !defined(AFX_URLPARTS_H__142A1831_D146_4168_B37B_8DEB367FF92D__INCLUDED_)
