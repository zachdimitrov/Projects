using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

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
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] requestBytes = new byte[500000];
                    int readBytes = stream.Read(requestBytes, 0, requestBytes.Length);
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
                        stream.Write(bytesResponseImg, 0, bytesResponseImg.Length);
                        stream.Write(bytesImage, 0, bytesImage.Length);
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
                        stream.Write(bytesResponseImg, 0, bytesResponseImg.Length);
                        stream.Write(bytesImage, 0, bytesImage.Length);
                    }
                    else
                    {
                        string content = File.ReadAllText("../../../Views/Index.html");
                        string response = "HTTP/1.1 201 Created\r\n" +
                        "Date: " + DateTime.Now.ToString() + "\r\n" +
                        "Server: The-Best-Server\r\n" +
                        "Content-type: Text/html\r\n" +
                        $"Content-length: {content.Length}" +
                        "\r\n" + "\r\n" +
                        content;

                        byte[] bytesResponse = Encoding.UTF8.GetBytes(response);
                        stream.Write(bytesResponse, 0, bytesResponse.Length);
                    }
                }
            }
        }
    }
}
