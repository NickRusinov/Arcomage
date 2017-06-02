using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Arcomage.Network.Notifications;
using Arcomage.Network.Requests;
using MediatR;

namespace Arcomage.WebApi.Controllers
{
    [Authorize]
    public class ConnectGameApiController : ApplicationApiController
    {
        private readonly IMediator mediator;

        public ConnectGameApiController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet, Route("~/api/game/connecting")]
        public async Task<Guid?> GetConnecting()
        {
            var gameContext = await mediator.Send(new GetPlayingGameRequest(Identity.User));

            return gameContext?.Id;
        }

        [HttpPost, Route("~/api/game/disconnect")]
        public async Task<Guid?> Disconnect()
        {
            var gameContext = await mediator.Send(new GetPlayingGameRequest(Identity.User));
            if (gameContext != null)
                await mediator.Publish(new CancelGameNotification(gameContext));

            return gameContext?.Id;
        }
    }
}