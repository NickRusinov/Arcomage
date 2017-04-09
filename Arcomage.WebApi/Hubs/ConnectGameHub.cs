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

        private readonly ICreateGameCommand createGameService;

        public ConnectGameHub(IGetUserByIdQuery getUserByIdQuery, ICreateGameCommand createGameService)
        {
            this.getUserByIdQuery = getUserByIdQuery;
            this.createGameService = createGameService;
        }

        public async Task Connect()
        {
            var firstUserContext = await getUserByIdQuery.Get(Identity.Id);
            var secondUserContext = await getUserByIdQuery.Get(Identity.Id);

            var gameContext = await createGameService.Create(firstUserContext, secondUserContext);

            Clients.User(Identity.Id.ToString()).Connected(gameContext.Id);
        }
    }
}