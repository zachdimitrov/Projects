using SIS.HTTP.Enums;
using SIS.HTTP.Responses;

namespace SIS.WebServer.Result
{
    public class RedirectResult : HttpResponse
    {
        public RedirectResult(string location) : base(HttpResponseStatusCode.SeeOther)
        {
            this.Headers.Add(new HTTP.Headers.HttpHeader("location", location));
        }
    }
}
