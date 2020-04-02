using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SServer
{
    class Program
    {
        static void Main()
        {
            int port = 12345;
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);

            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                Task.Run(() => ProcessClient(client));
            }
        }

        public static async Task ProcessClient(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            {
                byte[] requestBytes = new byte[500000];
                int readBytes = await stream.ReadAsync(requestBytes, 0, requestBytes.Length);
                string stringRequest = Encoding.UTF8.GetString(requestBytes, 0, readBytes);

                string urlLine = stringRequest.Split("/r/n", StringSplitOptions.RemoveEmptyEntries)[0];
                string url = urlLine.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1];

                Console.WriteLine(new string('=', 30));
                Console.WriteLine(stringRequest);

                if (url.Contains("JPG"))
                {
                    var bytesImage = File.ReadAllBytes("../../../Views/plovdiv.jpg");
                    string responseImg = "HTTP/1.1 200 Ok\r\n" +
                    "Date: " + DateTime.Now.ToString() + "\r\n" +
                    "Server: Image-Server-For-You\r\n" +
                    "Content-type: image/*\r\n" +
                    $"Content-length: {bytesImage.Length}" + "\r\n" + "\r\n";

                    byte[] bytesResponseImg = Encoding.UTF8.GetBytes(responseImg);
                    await stream.WriteAsync(bytesResponseImg, 0, bytesResponseImg.Length);
                    await stream.WriteAsync(bytesImage, 0, bytesImage.Length);
                }
                else if (url.Contains("ico"))
                {
                    var bytesImage = File.ReadAllBytes("../../../Views/favicon.ico");
                    string responseImg = "HTTP/1.1 200 Ok\r\n" +
                    "Date: " + DateTime.Now.ToString() + "\r\n" +
                    "Server: Ico-Server-For-You\r\n" +
                    "Content-type: image/x-icon\r\n" +
                    $"Content-length: {bytesImage.Length}" + "\r\n" + "\r\n";

                    byte[] bytesResponseImg = Encoding.UTF8.GetBytes(responseImg);
                    await stream.WriteAsync(bytesResponseImg, 0, bytesResponseImg.Length);
                    await stream.WriteAsync(bytesImage, 0, bytesImage.Length);
                }
                else
                {
                    string content = File.ReadAllText("../../../Views/Index.html");
                    string response = "HTTP/1.1 201 Created\r\n" +
                    "Date: " + DateTime.Now.ToString() + "\r\n" +
                    "Server: The-Best-Server\r\n" +
                    "Content-type: Text/html\r\n" +
                    "Set-Cookie: cookie1=test; Domain=bg.mysite.com\r\n" +
                    "Set-Cookie: cookie2=test2\r\n" +
                    //$"Content-length: {content.Length + DateTime.Now.ToLongTimeString().Length}" +
                    "\r\n" + "\r\n" +
                    content + "\r\n" + "<h2>" +
                    DateTime.Now.ToLongTimeString() + "</h2></body></html>";

                    byte[] bytesResponse = Encoding.UTF8.GetBytes(response);
                    await stream.WriteAsync(bytesResponse, 0, bytesResponse.Length);
                }
            }
        }
    }
}
