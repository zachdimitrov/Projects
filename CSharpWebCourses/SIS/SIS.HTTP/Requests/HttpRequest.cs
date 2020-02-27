using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Extensions;
using SIS.HTTP.Headers;
using SIS.HTTP.Headers.Contracts;
using SIS.HTTP.Requests.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestString, nameof(requestString));

            this.FormData = new Dictionary<string, ISet<string>>();
            this.QueryData = new Dictionary<string, ISet<string>>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, ISet<string>> FormData { get; private set; }

        public Dictionary<string, ISet<string>> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }

        private bool IsValidRequestLine(string[] requestLineParams)
        {
            if(requestLineParams.Length != 3 || requestLineParams[2] != GlobalConstants.HttpOneProtocolFragment)
            {
                return false;
            }

            return true;
        } 

        private bool IsValidRequestQieryString(string queryString, string[] queryParameters)
        {
            throw new NotImplementedException();
        }

        private void ParseRequestQueryParameters()
        {
            var parameters = this.Url
                .Split('?', '#')[1]
                .Split('&')
                .Select(plainQueryParam => plainQueryParam.Split('='))
                .ToList();

            foreach (var parameter in parameters)
            {
                if (this.QueryData.ContainsKey(parameter[0]) == false)
                {
                    this.QueryData.Add(parameter[0], new HashSet<string>());
                }

                this.QueryData[parameter[0]].Add(parameter[1]);
            }
        }

        private void ParseRequestFormDataParameters(string requestBody)
        {
            if (string.IsNullOrEmpty(requestBody) == false)
            {
                var paramPairs = requestBody
                    .Split('&')
                    .Select(plainQueryParameter => plainQueryParameter.Split('='))
                    .ToList();

                foreach (var paramPair in paramPairs)
                {
                    if (this.FormData.ContainsKey(paramPair[0]) == false)
                    {
                        this.FormData.Add(paramPair[0], new HashSet<string>());
                    }

                    this.FormData[paramPair[0]].Add(paramPair[1]);
                }
            }

            //TODO: Parse multiple parameters by name
            /*
            requestBody
                .Split('?')[1]
                .Split('&')
                .Select(plainFormParam => plainFormParam.Split('='))
                .ToList()
                .ForEach(formParamKeyValuePair => 
                {
                    if (this.FormData.ContainsKey(formParamKeyValuePair[0]) && formParamKeyValuePair[0] != "id")
                    {
                        var existingEntry = this.FormData.FirstOrDefault(elem => elem.Key == formParamKeyValuePair[0]);

                        if (existingEntry.Value is IEnumerable)
                        {
                            List<string> valuesList = (List<string>)existingEntry.Value;
                            valuesList.Append<string>(formParamKeyValuePair[1]);
                        }
                        else
                        {
                            List<string> values = new List<string>();
                            values.Add(formParamKeyValuePair[1]);
                            this.FormData.Remove(existingEntry.Key);
                            this.FormData.Add(formParamKeyValuePair[0], values);
                        }
                    }
                    else
                    {
                        this.FormData.Add(formParamKeyValuePair[0], formParamKeyValuePair[1]);
                    }
                });
                */
        }

        private void ParseRequestParameters(string requestBody)
        {
            this.ParseRequestQueryParameters();
            this.ParseRequestFormDataParameters(requestBody);
        }

        private void ParseRequestHeaders(string[] plainHeaders)
        {
            plainHeaders
                .Select(plainHeader => plainHeader.Split(new[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries))
                .ToList()
                .ForEach(HeaderKeyValuePair => this.Headers.AddHeader(new HttpHeader(HeaderKeyValuePair[0], HeaderKeyValuePair[1])));
        }

        private string[] GetPlainHeaders(string[] splitRequestString)
        {
            int blankIndex = Array.IndexOf(splitRequestString, splitRequestString.FirstOrDefault(a => string.IsNullOrEmpty(a)));
            return splitRequestString
                .SkipLast(splitRequestString.Count() - blankIndex)
                .Skip(1)
                .ToArray();
        }

        private void ParseRequestPath()
        {
            this.Path = this.Url.Split('?')[0];
        }

        private void ParseRequestUrl(string[] requestLineParams)
        {
            this.Url = requestLineParams[1];
        }

        private void ParseRequestMethod(string[] requestLineParams)
        {
            string methodStr = StringExtensions.Capitalize(requestLineParams[0]);
            HttpRequestMethod method;
            bool parseResult = HttpRequestMethod.TryParse(methodStr, out method);
            if (!parseResult)
            {
                throw new BadRequestException(string.Format(GlobalConstants.BadRequestMethodMessage, requestLineParams[0]));
            }
            this.RequestMethod = method;
        }

        private void ParseRequest(string requestString)
        {
            string[] splitRequestString = requestString
                .Split(new[] {GlobalConstants.HttpNewLine}, StringSplitOptions.None);

            string[] requestLineParams = splitRequestString[0]
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (!this.IsValidRequestLine(requestLineParams))
            {
                throw new BadRequestException();
            }

            this.ParseRequestMethod(requestLineParams);
            this.ParseRequestUrl(requestLineParams);
            this.ParseRequestPath();
            string[] plainHeaders = GetPlainHeaders(splitRequestString);
            this.ParseRequestHeaders(plainHeaders);
            //this.ParseCookies();
            this.ParseRequestParameters(splitRequestString[splitRequestString.Length - 1]);
        }

        public override string ToString()
        {
            return $"    path: {this.Path}\r\n"
                + $"    url: {this.Url}\r\n"
                + $"    method: {RequestMethod.ToString()}\r\n"
                + "    Headers:\r\n"
                + this.Headers.ToString() + "\r\n"
                + "    Query Data:\r\n"
                + string.Join("\r\n", QueryData) + "\r\n"
                + "    Form Data:\r\n"
                + string.Join("\r\n", FormData) + "\r\n"; 
        }
    }
}
