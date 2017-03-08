using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi.Hubs
{
    public class NetworkGameHub : Hub<INetworkGameClient>
    {
        public override Task OnConnected()
        {
            var userName = Context.User.Identity.Name;

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var userName = Context.User.Identity.Name;

            return base.OnDisconnected(stopCalled);
        }
    }
}