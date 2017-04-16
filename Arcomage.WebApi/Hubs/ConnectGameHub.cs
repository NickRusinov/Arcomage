using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Network.Services;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi.Hubs
{
    [Authorize]
    public class ConnectGameHub : ApplicationHub<IConnectGameClient>
    {
        private readonly IConnectGameService connectGameService;

        public ConnectGameHub(IConnectGameService connectGameService)
        {
            this.connectGameService = connectGameService;
        }
        
        public async Task Connect()
        {
            var gameContext = await connectGameService.ConnectGame(Identity.Id);

            Clients.User(Identity.Id.ToString()).Connected(gameContext.Id);
        }
    }
}