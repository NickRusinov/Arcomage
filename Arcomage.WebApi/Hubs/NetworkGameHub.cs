using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi.Hubs
{
    public class NetworkGameHub : Hub<INetworkGameClient>
    {
        private readonly NetworkGameService networkGameService;

        public NetworkGameHub(NetworkGameService networkGameService)
        {
            this.networkGameService = networkGameService;
        }

        public override Task OnConnected()
        {
            var userId = ((ApplicationIdentity)Context.User.Identity).Id;
            networkGameService.ConnectUser(userId);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var userId = ((ApplicationIdentity)Context.User.Identity).Id;
            networkGameService.DisconnectUser(userId);

            return base.OnDisconnected(stopCalled);
        }
    }
}