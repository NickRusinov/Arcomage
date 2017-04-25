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
    public class SignalRCreateGameService : ICreateGameService
    {
        private readonly ICreateGameService createGameService;

        private readonly IHubContext<IConnectGameClient> connectGameHubContext;

        public SignalRCreateGameService(ICreateGameService createGameService, IHubContext<IConnectGameClient> connectGameHubContext)
        {
            this.createGameService = createGameService;
            this.connectGameHubContext = connectGameHubContext;
        }

        public async Task<GameContext> CreateGame(UserContext firstUserContext, UserContext secondUserContext)
        {
            var gameContext = await createGameService.CreateGame(firstUserContext, secondUserContext);
            
            var users = new[] { firstUserContext.Id.ToString(), secondUserContext.Id.ToString() };
            connectGameHubContext.Clients.Users(users).Connected(gameContext.Id);

            return gameContext;
        }
    }
}