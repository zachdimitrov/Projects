using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using System;
using System.Text;

namespace Demo.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string request = "POST /url/asd?name=john&id=1#fragment HTTP/1.1\r\n"
                + "Authorization: Basic239439848383\r\n"
                + "Host: localhost:5000\r\n"
                + "Date: " + string.Join('.', DateTime.Now.ToString().Split(new char[] {' ', ':'}, StringSplitOptions.RemoveEmptyEntries)) + "\r\n"
                +"\r\n"
                + "username=johndoe&password=1234&car=porshe&car=lada&car=ferrari";

            Console.WriteLine(request);
            Console.WriteLine(new string('=', 20));

            HttpRequest httpRequest = new HttpRequest(request);

            Console.WriteLine(httpRequest);
            Console.WriteLine(new string('=', 20));

            HttpResponseStatusCode status = HttpResponseStatusCode.Unauthorized;
            HttpResponse response = new HttpResponse(status);
            response.AddHeader(new HttpHeader("host", "localhost:5000"));
            response.AddHeader(new HttpHeader("user", "Pesho"));
            response.AddHeader(new HttpHeader("country", "Haskovo"));
            response.Content = Encoding.UTF8.GetBytes("<h1>Hello World!</h1>");

            Console.WriteLine(Encoding.UTF8.GetString(response.GetBytes()));
            Console.ReadLine();
        }
    }
}
