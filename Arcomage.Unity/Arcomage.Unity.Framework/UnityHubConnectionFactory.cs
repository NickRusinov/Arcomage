using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Framework.Services;
using Arcomage.WebApi.Client;
using Microsoft.AspNet.SignalR.Client;

namespace Arcomage.Unity.Framework
{
    public class UnityHubConnectionFactory : IHubConnectionFactory
    {
        private readonly string baseUrl;

        private readonly Authorization authorization;

        public UnityHubConnectionFactory(string baseUrl, Authorization authorization)
        {
            this.baseUrl = baseUrl;
            this.authorization = authorization;
        }

        public HubConnection Open()
        {
            var authorizationHeader = authorization.GetAuthorizationHeader();
            var authorizationToken = authorization.GetAuthorizationToken();

            var hubConnection = new HubConnection(baseUrl);
            hubConnection.TransportConnectTimeout = TimeSpan.FromSeconds(30);
            hubConnection.TraceLevel = TraceLevels.All;
            hubConnection.TraceWriter = new UnityLogTextWriter();
            hubConnection.Headers.Add(authorizationHeader, authorizationToken);

            return hubConnection;
        }

        public void Close(HubConnection connection)
        {
            throw new NotImplementedException();
        }
    }
}
