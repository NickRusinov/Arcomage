using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Network;
using Arcomage.Network.Repositories;
using Arcomage.Network.Requests;
using MediatR;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi.Hubs
{
    [Authorize]
    public class ConnectGameHub : ApplicationHub<IConnectGameClient>
    {
        private readonly IMediator mediator;

        private readonly IUserContextRepository userContextRepository;

        public ConnectGameHub(IMediator mediator, IUserContextRepository userContextRepository)
        {
            this.mediator = mediator;
            this.userContextRepository = userContextRepository;
        }
        
        public async Task Connect()
        {
            var gameContext = await mediator.Send(new GetPlayingGameRequest(Identity.UserContext));
            if (gameContext != null)
            {
                Clients.Users(new[] { gameContext.FirstUser.Id.ToString(), gameContext.SecondUser.Id.ToString() }).Connected(gameContext.Id);
                return;
            }

            await userContextRepository.Update(Identity.UserContext, uc => uc.State = UserState.Connecting);
        }

        public async Task Disconnect()
        {
            var gameContext = await mediator.Send(new GetPlayingGameRequest(Identity.UserContext));
            if (gameContext != null)
                await mediator.Send(new CancelGameRequest(gameContext));
        }
    }
}