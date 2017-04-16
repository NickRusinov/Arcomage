using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Network;
using Arcomage.Network.Services;
using Arcomage.WebApi.Hubs;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi.Network
{
    public class SignalRConnectGameService : IConnectGameService
    {
        private readonly IConnectGameService connectGameService;

        private readonly IHubContext<IConnectGameClient> connectGameHubContext;

        public SignalRConnectGameService(IConnectGameService connectGameService, IHubContext<IConnectGameClient> connectGameHubContext)
        {
            this.connectGameService = connectGameService;
            this.connectGameHubContext = connectGameHubContext;
        }

        public async Task<GameContext> ConnectGame(Guid userId)
        {
            var gameContext = await connectGameService.ConnectGame(userId);

            var firstUser = gameContext.FirstUser.Id.ToString();
            var secondUser = gameContext.SecondUser.Id.ToString();
            var users = new[] { firstUser, secondUser };

            connectGameHubContext.Clients.Users(users).Connected(gameContext.Id);

            return gameContext;
        }
    }
}