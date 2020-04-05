using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Common
{
    public static class GlobalConstants
    {
        public const string HttpOneProtocolFragment = "HTTP/1.1";

        public const string HostReaderKey = "Host";

        public const string HttpNewLine = "\r\n";

        public const string BadRequestMethodMessage = "Request method {0} is not supported!";
    }
}
