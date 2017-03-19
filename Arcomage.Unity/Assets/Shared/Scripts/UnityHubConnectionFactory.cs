using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.WebApi.Client;
using Microsoft.AspNet.SignalR.Client;
using UnityEngine;

namespace Arcomage.Unity.Shared.Scripts
{
    public class UnityHubConnectionFactory : MonoBehaviour, IHubConnectionFactory
    {
        [Tooltip("Адрес веб-сервера игры")]
        public string BaseUrl;

        public HubConnection Open()
        {
            var hubConnection = new HubConnection(BaseUrl);
            hubConnection.TraceLevel = TraceLevels.All;
            hubConnection.TraceWriter = new UnityLogTextWriter();
            //hubConnection.Headers.Add("Authenticate", "authenticate");
            //hubConnection.Headers.Add("Content-Type", "application/json");

            return hubConnection;
        }

        public void Close(HubConnection connection)
        {
            throw new NotImplementedException();
        }
    }
}
