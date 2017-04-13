using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Network.Games;
using Arcomage.Network.Users;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi.Hubs
{
    [Authorize]
    public class ConnectGameHub : ApplicationHub<IConnectGameClient>
    {
        private readonly IGetUserByIdQuery getUserByIdQuery;

        private readonly IGetGameByUserIdQuery getGameByUserIdQuery;

        private readonly ICreateGameCommand createGameService;

        public ConnectGameHub(IGetUserByIdQuery getUserByIdQuery, IGetGameByUserIdQuery getGameByUserIdQuery, ICreateGameCommand createGameService)
        {
            this.getUserByIdQuery = getUserByIdQuery;
            this.getGameByUserIdQuery = getGameByUserIdQuery;
            this.createGameService = createGameService;
        }

        public async Task Connect()
        {
            var gameContext = await getGameByUserIdQuery.Get(Identity.Id);
            if (gameContext == null)
            {
                var firstUserContext = await getUserByIdQuery.Get(Identity.Id);
                var secondUserContext = await getUserByIdQuery.Get(Identity.Id);

                gameContext = await createGameService.Create(firstUserContext, secondUserContext);
            }

            Clients.User(Identity.Id.ToString()).Connected(gameContext.Id);
        }
    }
}