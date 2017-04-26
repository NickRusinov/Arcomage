using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Arcomage.Network.Requests;
using MediatR;

namespace Arcomage.WebApi.Controllers
{
    [Authorize]
    public class PlayGameApiController : ApplicationApiController
    {
        private readonly IMediator mediator;

        public PlayGameApiController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost, Route("~/api/game/play")]
        public async Task PlayCard(int cardIndex)
        {
            var gameContext = await mediator.Send(new GetPlayingGameRequest(Identity.UserContext)) ??
                throw new HttpException();

            await mediator.Send(new PlayCardGameRequest(gameContext, Identity.UserContext, cardIndex));
        }

        [HttpPost, Route("~/api/game/discard")]
        public async Task DiscardCard(int cardIndex)
        {
            var gameContext = await mediator.Send(new GetPlayingGameRequest(Identity.UserContext)) ??
                throw new HttpException();

            await mediator.Send(new DiscardCardGameRequest(gameContext, Identity.UserContext, cardIndex));
        }
    }
}