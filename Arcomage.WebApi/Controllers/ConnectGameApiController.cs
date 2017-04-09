using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Arcomage.Network.Games;
using Arcomage.Network.Users;

namespace Arcomage.WebApi.Controllers
{
    [Authorize]
    public class ConnectGameApiController : ApplicationApiController
    {
        private readonly IGetUserByIdQuery getUserByIdQuery;

        private readonly ICreateGameCommand createGameCommand;

        public ConnectGameApiController(IGetUserByIdQuery getUserByIdQuery, ICreateGameCommand createGameCommand)
        {
            this.getUserByIdQuery = getUserByIdQuery;
            this.createGameCommand = createGameCommand;
        }

        [HttpPost, Route("~/api/game/connect")]
        public async Task<Guid> Connect()
        {
            var firstUserContext = await getUserByIdQuery.Get(Identity.Id);
            var secondUserContext = await getUserByIdQuery.Get(Identity.Id);

            var gameContext = await createGameCommand.Create(firstUserContext, secondUserContext);

            return gameContext.Id;
        }
    }
}