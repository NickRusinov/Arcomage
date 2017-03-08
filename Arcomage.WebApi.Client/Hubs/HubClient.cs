using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;

namespace Arcomage.WebApi.Client.Hubs
{
    public abstract class HubClient
    {
        private readonly ISignalRClient signalRClient;

        private readonly string hubName;

        private HubConnection hubConnection;

        private IHubProxy hubProxy;

        protected HubClient(ISignalRClient signalRClient, string hubName)
        {
            this.signalRClient = signalRClient;
            this.hubName = hubName;
        }

        public HubConnection HubConnection => hubConnection = hubConnection ?? signalRClient.Open();

        public IHubProxy HubProxy => hubProxy = hubProxy ?? HubConnection.CreateHubProxy(hubName);
        
        public virtual Task Start()
        {
            return HubConnection.Start();
        }

        public virtual void Stop()
        {
            hubConnection?.Stop();

            hubConnection = null;
            hubProxy = null;
        }

        protected virtual Task Invoke(string methodName, params object[] args)
        {
            return HubProxy.Invoke(methodName, args);
        }

        protected virtual Task<T> Invoke<T>(string methodName, params object[] args)
        {
            return HubProxy.Invoke<T>(methodName, args);
        }
    }
}
