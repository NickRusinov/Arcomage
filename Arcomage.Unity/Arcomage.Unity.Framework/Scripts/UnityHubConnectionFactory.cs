using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.WebApi.Client;
using Microsoft.AspNet.SignalR.Client;
using UnityEngine;

namespace Arcomage.Unity.Framework.Scripts
{
    public class UnityHubConnectionFactory : MonoBehaviour, IHubConnectionFactory
    {
        [Tooltip("Адрес веб-сервера игры")]
        public string BaseUrl;

        public HubConnection Open()
        {
            var authorizationHeader = Global.Authorization.GetAuthorizationHeader();
            var authorizationToken = Global.Authorization.GetAuthorizationToken();

            var hubConnection = new HubConnection(BaseUrl);
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
