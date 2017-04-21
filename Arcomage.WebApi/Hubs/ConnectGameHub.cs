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

        private readonly IDisconnectGameService disconnectGameService;

        public ConnectGameHub(IConnectGameService connectGameService, IDisconnectGameService disconnectGameService)
        {
            this.connectGameService = connectGameService;
            this.disconnectGameService = disconnectGameService;
        }
        
        public async Task Connect()
        {
            var gameContext = await connectGameService.ConnectGame(Identity.Id);
        }

        public async Task Disconnect()
        {
            var gameContext = await disconnectGameService.DisconnectGame(Identity.Id);
        }
    }
}