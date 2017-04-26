using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Network.Requests;
using MediatR;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi.Hubs
{
    [Authorize]
    public class PlayGameHub : ApplicationHub<IPlayGameClient>
    {
        private readonly IMediator mediator;

        public PlayGameHub(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task PlayCard(int cardIndex)
        {
            var gameContext = await mediator.Send(new GetPlayingGameRequest(Identity.UserContext)) ??
                throw new HubException();

            await mediator.Send(new PlayCardGameRequest(gameContext, Identity.UserContext, cardIndex));
        }

        public async Task DiscardCard(int cardIndex)
        {
            var gameContext = await mediator.Send(new GetPlayingGameRequest(Identity.UserContext)) ??
                throw new HubException();

            await mediator.Send(new DiscardCardGameRequest(gameContext, Identity.UserContext, cardIndex));
        }
    }
}