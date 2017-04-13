using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Network.Domain;
using Arcomage.Network.Games;
using Arcomage.Network.Users;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi.Hubs
{
    [Authorize]
    public class PlayGameHub : ApplicationHub<IPlayGameClient>
    {
        private readonly IGetUserByIdQuery getUserByIdQuery;

        private readonly IGetGameByUserIdQuery getGameByUserIdQuery;

        private readonly IPlayGameCommand playGameCommand;

        public PlayGameHub(IGetUserByIdQuery getUserByIdQuery, IGetGameByUserIdQuery getGameByUserIdQuery, IPlayGameCommand playGameCommand)
        {
            this.getUserByIdQuery = getUserByIdQuery;
            this.getGameByUserIdQuery = getGameByUserIdQuery;
            this.playGameCommand = playGameCommand;
        }

        public async Task PlayCard(int cardIndex)
        {
            var userContext = await getUserByIdQuery.Get(Identity.Id)
                ?? throw new HubException("User not found");

            var gameContext = await getGameByUserIdQuery.Get(Identity.Id)
                ?? throw new HubException("Game not found");

            await playGameCommand.PlayCard(gameContext, userContext, cardIndex);

            Clients.User(Identity.Id.ToString()).Update();
        }

        public async Task DiscardCard(int cardIndex)
        {
            var userContext = await getUserByIdQuery.Get(Identity.Id)
                ?? throw new HubException("User not found");

            var gameContext = await getGameByUserIdQuery.Get(Identity.Id)
                ?? throw new HubException("Game not found");

            await playGameCommand.DiscardCard(gameContext, userContext, cardIndex);

            Clients.User(Identity.Id.ToString()).Update();
        }
    }
}