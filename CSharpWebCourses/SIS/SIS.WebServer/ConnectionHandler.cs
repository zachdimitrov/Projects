using SIS.HTTP.Common;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Routing;
using System;
using System.Net.Sockets;

namespace SIS.WebServer
{
    public class ConnectionHandler
    {
        private Socket client;
        private IServerRoutingTable serverRoutingTable;

        public ConnectionHandler(Socket client, IServerRoutingTable serverRoutingTable)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(serverRoutingTable, nameof(serverRoutingTable));

            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }

        public void ProcessRequest()
        {

        }

        private IHttpRequest ReadRequest()
        {
            throw new NotFiniteNumberException();
        }

        private IHttpResponse HandleRequest(IHttpRequestTable httpRequestTable)
        {
            throw new NotFiniteNumberException();
        }

        private void PrepareResponse(IHttpResponse httpResponse)
        {
            throw new NotFiniteNumberException();
        }
    }
}
