using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi.Hubs
{
    [Authorize]
    public class NetworkGameHub : ApplicationHub<INetworkGameClient>
    {
        private readonly NetworkGameService networkGameService;

        public NetworkGameHub(NetworkGameService networkGameService)
        {
            this.networkGameService = networkGameService;
        }

        public void Connect()
        {
            //networkGameService.ConnectUser(Identity.Id);
            Clients.User(Identity.Id.ToString()).StartGame(Guid.NewGuid());
        }
    }
}