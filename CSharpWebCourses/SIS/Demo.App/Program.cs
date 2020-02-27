using SIS.HTTP.Requests;
using System;

namespace Demo.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string request = "POST /url/asd?name=john&id=1#fragment HTTP/1.1\r\n"
                + "Authorization: Basic239439848383\r\n"
                + "Host: localhost:5000\r\n"
                + "Date: " + DateTime.Now + "\r\n"
                +"\r\n"
                + "username=johndoe&password=1234&car=porshe&car=lada&car=ferrari";

            Console.WriteLine(request);
            Console.WriteLine(new string('=', 20));

            HttpRequest httpRequest = new HttpRequest(request);

            Console.WriteLine(httpRequest);

            Console.ReadLine();
        }
    }
}
