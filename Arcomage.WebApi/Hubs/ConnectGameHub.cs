using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Network;
using Arcomage.Network.Queries;
using Arcomage.Network.Repositories;
using Arcomage.Network.Services;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi.Hubs
{
    [Authorize]
    public class ConnectGameHub : ApplicationHub<IConnectGameClient>
    {
        private readonly IUserContextRepository userContextRepository;

        private readonly IGetPlayingGameQuery getPlayingGameQuery;

        private readonly IDisconnectGameService disconnectGameService;

        public ConnectGameHub(IUserContextRepository userContextRepository, IGetPlayingGameQuery getPlayingGameQuery, IDisconnectGameService disconnectGameService)
        {
            this.userContextRepository = userContextRepository;
            this.getPlayingGameQuery = getPlayingGameQuery;
            this.disconnectGameService = disconnectGameService;
        }
        
        public async Task Connect()
        {
            var gameContext = await getPlayingGameQuery.Handle(Identity.UserContext);
            if (gameContext != null)
            {
                Clients.Users(new[] { gameContext.FirstUser.Id.ToString(), gameContext.SecondUser.Id.ToString() }).Connected(gameContext.Id);
                return;
            }

            await userContextRepository.Update(Identity.UserContext, uc => uc.State = UserState.Connecting);
        }

        public async Task Disconnect()
        {
            var gameContext = await disconnectGameService.DisconnectGame(Identity.UserContext);
        }
    }
}