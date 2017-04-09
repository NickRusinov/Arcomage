using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Arcomage.Network.Domain;
using Arcomage.Network.Games;
using Arcomage.Network.Users;

namespace Arcomage.WebApi.Controllers
{
    [Authorize]
    public class PlayGameApiController : ApplicationApiController
    {
        private readonly IGetUserByIdQuery getUserByIdQuery;

        private readonly IGetGameByUserIdQuery getGameByUserIdQuery;

        private readonly IPlayGameCommand playGameCommand;

        public PlayGameApiController(IGetUserByIdQuery getUserByIdQuery, IGetGameByUserIdQuery getGameByUserIdQuery, IPlayGameCommand playGameCommand)
        {
            this.getUserByIdQuery = getUserByIdQuery;
            this.getGameByUserIdQuery = getGameByUserIdQuery;
            this.playGameCommand = playGameCommand;
        }

        [HttpPost, Route("~/api/game/play")]
        public async Task PlayCard(int cardIndex)
        {
            var userContext = await getUserByIdQuery.Get(Identity.Id)
                ?? throw new HttpException("User not found");

            var gameContext = await getGameByUserIdQuery.Get(Identity.Id)
                ?? throw new HttpException("Game not found");

            await playGameCommand.PlayCard(gameContext, userContext, cardIndex);
        }

        [HttpPost, Route("~/api/game/discard")]
        public async Task DiscardCard(int cardIndex)
        {
            var userContext = await getUserByIdQuery.Get(Identity.Id)
                ?? throw new HttpException("User not found");

            var gameContext = await getGameByUserIdQuery.Get(Identity.Id)
                ?? throw new HttpException("Game not found");

            await playGameCommand.DiscardCard(gameContext, userContext, cardIndex);
        }
    }
}