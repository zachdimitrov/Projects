## HTTP Protocol
#### Overview
- Hypertext Transfer Protocol
- Communication protocol for the web
- Versions - current HTTP1.1, HTTP2.0
- Request-response actions
- Client- server communication - 7 layers
  - HTTP, TCP, IP, Ethernet, Media...
## HTTP Requests
#### Methods
**Common methods**    
|method|description|
|---|---|  
|POST | Create / store a resource  |
|GET | Read / retrieve a resource  |
|PUT | Update / modify a resource  |
|DELETE | Delete / remove a resource|  

**Other methods**  
|method|description|
|---|---| 
|CONNECT||
|HEAD||
|OPTIONS||
|TRACE||
|PATCH||
### HTTP request example
- request
```
GET /courses/javascript HTTP/1.1
Host: www.softuni.bg
User-Agent: Mozilla/5.0
<CRLF>
```
- response
```
HTTP/1.1 200 OK
Date: Mon, 5 Jul 2010 13:09:03 GMT
Server: Microsoft-HTTPAPI/2.0
Last-Modified: 
Content-Length: 54
<CRLF>
<html>
  <htmlcode/>
</html>
```
### URL
**example:**
https://path/to/page?key=value&otherKey=otherValue#fragment

1. URL path - https://path/to/page  
2. Query string - ?key=value&otherKey=otherValue  
3. Fragment - #fragment (browsers find element by #id)

only english letters and no special symbols

### Status Codes
100 - Continue (1xx informational)
200 - Ok (2xx successful)
201 - Created
301 - Moved Permanently
304 - Not Modified (3xx redirection)
307 - Moved Temporarly
400 - Bad Request (4xx client error)
401 - Unauthorized
403 - Forbidden
404 - Not Found 
409 - Conflict
500 - Internal Server Error (5xx server error)
503 - Service Unavailable

[learn visually](https://http.cat/)

### HTTP headers
**syntax:** Header: value
Conent-Type: 
- text/html
- text/plain
- application/json
- image/png
- video/mp4
Location: https://address.com 
Content-Disposition: attachment; filename=file.png
Content-Length: 1024
Host: www.site-address.com

## Simple server
```c#
static void Main()
{
  int port = 12345;
  TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);
  tcpListener.Start();

  while (true)
  {
    TcpClient client = tcpListener.AcceptTcpClient();
    using (NetworkStream stream = client.GetStream())
    {
      byte[] requestBytes = new byte[10000];
      int readBytes = stream.Read(requestBytes, 0, requestBytes.Length);
      string stringRequest = Encoding.UTF8.GetString(requestBytes, 0, readBytes);

      string content = "<H1>Hello, World!</H1>";
      string response = "HTTP/1.1 201 Created\r\n" +
      "Server: The-Best-Server\r\n" +
      "Content-type: Text/html\r\n" +
      $"Content-length: {content.Length}" + "\r\n" +
      "\r\n" + content;

      byte[] bytesResponse = Encoding.UTF8.GetBytes(response);
      stream.Write(bytesResponse, 0, bytesResponse.Length);
    }
  }
}
```