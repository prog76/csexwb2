using System;
using System.Runtime.InteropServices;

namespace IfacesEnumsStructsClasses
{
    public struct INTERNET_PROXY_INFO
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint dwAccessType;
        public IntPtr lpszProxy; //string
        public IntPtr lpszProxyBypass; //string
    }
    /// options manifests for Internet{Query|Set}Option
    ///
    public sealed class InternetSetOptionFlags
    {
        public const int INTERNET_OPTION_CALLBACK = 1;
        public const int INTERNET_OPTION_CONNECT_TIMEOUT = 2;
        public const int INTERNET_OPTION_CONNECT_RETRIES = 3;
        public const int INTERNET_OPTION_CONNECT_BACKOFF = 4;
        public const int INTERNET_OPTION_SEND_TIMEOUT = 5;
        public const int INTERNET_OPTION_CONTROL_SEND_TIMEOUT = INTERNET_OPTION_SEND_TIMEOUT;
        public const int INTERNET_OPTION_RECEIVE_TIMEOUT = 6;
        public const int INTERNET_OPTION_CONTROL_RECEIVE_TIMEOUT = INTERNET_OPTION_RECEIVE_TIMEOUT;
        public const int INTERNET_OPTION_DATA_SEND_TIMEOUT = 7;
        public const int INTERNET_OPTION_DATA_RECEIVE_TIMEOUT = 8;
        public const int INTERNET_OPTION_HANDLE_TYPE = 9;
        public const int INTERNET_OPTION_LISTEN_TIMEOUT = 11;
        public const int INTERNET_OPTION_READ_BUFFER_SIZE = 12;
        public const int INTERNET_OPTION_WRITE_BUFFER_SIZE = 13;
        public const int INTERNET_OPTION_ASYNC_ID = 15;
        public const int INTERNET_OPTION_ASYNC_PRIORITY = 16;
        public const int INTERNET_OPTION_PARENT_HANDLE = 21;
        public const int INTERNET_OPTION_KEEP_CONNECTION = 22;
        public const int INTERNET_OPTION_REQUEST_FLAGS = 23;
        public const int INTERNET_OPTION_EXTENDED_ERROR = 24;
        public const int INTERNET_OPTION_OFFLINE_MODE = 26;
        public const int INTERNET_OPTION_CACHE_STREAM_HANDLE = 27;
        public const int INTERNET_OPTION_USERNAME = 28;
        public const int INTERNET_OPTION_PASSWORD = 29;
        public const int INTERNET_OPTION_ASYNC = 30;
        public const int INTERNET_OPTION_SECURITY_FLAGS = 31;
        public const int INTERNET_OPTION_SECURITY_CERTIFICATE_STRUCT = 32;
        public const int INTERNET_OPTION_DATAFILE_NAME = 33;
        public const int INTERNET_OPTION_URL = 34;
        public const int INTERNET_OPTION_SECURITY_CERTIFICATE = 35;
        public const int INTERNET_OPTION_SECURITY_KEY_BITNESS = 36;
        public const int INTERNET_OPTION_REFRESH = 37;
        public const int INTERNET_OPTION_PROXY = 38;
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_VERSION = 40;
        public const int INTERNET_OPTION_USER_AGENT = 41;
        public const int INTERNET_OPTION_END_BROWSER_SESSION = 42;
        public const int INTERNET_OPTION_PROXY_USERNAME = 43;
        public const int INTERNET_OPTION_PROXY_PASSWORD = 44;
        public const int INTERNET_OPTION_CONTEXT_VALUE = 45;
        public const int INTERNET_OPTION_CONNECT_LIMIT = 46;
        public const int INTERNET_OPTION_SECURITY_SELECT_CLIENT_CERT = 47;
        public const int INTERNET_OPTION_POLICY = 48;
        public const int INTERNET_OPTION_DISCONNECTED_TIMEOUT = 49;
        public const int INTERNET_OPTION_CONNECTED_STATE = 50;
        public const int INTERNET_OPTION_IDLE_STATE = 51;
        public const int INTERNET_OPTION_OFFLINE_SEMANTICS = 52;
        public const int INTERNET_OPTION_SECONDARY_CACHE_KEY = 53;
        public const int INTERNET_OPTION_CALLBACK_FILTER = 54;
        public const int INTERNET_OPTION_CONNECT_TIME = 55;
        public const int INTERNET_OPTION_SEND_THROUGHPUT = 56;
        public const int INTERNET_OPTION_RECEIVE_THROUGHPUT = 57;
        public const int INTERNET_OPTION_REQUEST_PRIORITY = 58;
        public const int INTERNET_OPTION_HTTP_VERSION = 59;
        public const int INTERNET_OPTION_RESET_URLCACHE_SESSION = 60;
        public const int INTERNET_OPTION_ERROR_MASK = 62;
        public const int INTERNET_OPTION_FROM_CACHE_TIMEOUT = 63;
        public const int INTERNET_OPTION_BYPASS_EDITED_ENTRY = 64;
        public const int INTERNET_OPTION_DIAGNOSTIC_SOCKET_INFO = 67;
        public const int INTERNET_OPTION_CODEPAGE = 68;
        public const int INTERNET_OPTION_CACHE_TIMESTAMPS = 69;
        public const int INTERNET_OPTION_DISABLE_AUTODIAL = 70;
        public const int INTERNET_OPTION_MAX_CONNS_PER_SERVER = 73;
        public const int INTERNET_OPTION_MAX_CONNS_PER_1_0_SERVER = 74;
        public const int INTERNET_OPTION_PER_CONNECTION_OPTION = 75;
        public const int INTERNET_OPTION_DIGEST_AUTH_UNLOAD = 76;
        public const int INTERNET_OPTION_IGNORE_OFFLINE = 77;
        public const int INTERNET_OPTION_IDENTITY = 78;
        public const int INTERNET_OPTION_REMOVE_IDENTITY = 79;
        public const int INTERNET_OPTION_ALTER_IDENTITY = 80;
        public const int INTERNET_OPTION_SUPPRESS_BEHAVIOR = 81;
        public const int INTERNET_OPTION_AUTODIAL_MODE = 82;
        public const int INTERNET_OPTION_AUTODIAL_CONNECTION = 83;
        public const int INTERNET_OPTION_CLIENT_CERT_CONTEXT = 84;
        public const int INTERNET_OPTION_AUTH_FLAGS = 85;
        public const int INTERNET_OPTION_COOKIES_3RD_PARTY = 86;
        public const int INTERNET_OPTION_DISABLE_PASSPORT_AUTH = 87;
        public const int INTERNET_OPTION_SEND_UTF8_SERVERNAME_TO_PROXY = 88;
        public const int INTERNET_OPTION_EXEMPT_CONNECTION_LIMIT = 89;
        public const int INTERNET_OPTION_ENABLE_PASSPORT_AUTH = 90;
        public const int INTERNET_OPTION_HIBERNATE_INACTIVE_WORKER_THREADS = 91;
        public const int INTERNET_OPTION_ACTIVATE_WORKER_THREADS = 92;
        public const int INTERNET_OPTION_RESTORE_WORKER_THREAD_DEFAULTS = 93;
        public const int INTERNET_OPTION_SOCKET_SEND_BUFFER_LENGTH = 94;
        public const int INTERNET_OPTION_PROXY_SETTINGS_CHANGED = 95;
        public const int INTERNET_OPTION_DATAFILE_EXT = 96;
    }
}
