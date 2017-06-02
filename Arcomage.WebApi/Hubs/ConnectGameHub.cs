using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Network;
using Arcomage.Network.Notifications;
using Arcomage.Network.Requests;
using MediatR;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi.Hubs
{
    [Authorize]
    public class ConnectGameHub : ApplicationHub<IConnectGameClient>
    {
        private readonly IMediator mediator;

        private readonly IRepository<User> userRepository;

        public ConnectGameHub(IMediator mediator, IRepository<User> userRepository)
        {
            this.mediator = mediator;
            this.userRepository = userRepository;
        }
        
        public async Task Connect()
        {
            var gameContext = await mediator.Send(new GetPlayingGameRequest(Identity.User));
            if (gameContext != null)
            {
                Clients.Users(new[] { gameContext.FirstUser.Id.ToString(), gameContext.SecondUser.Id.ToString() }).Connected(gameContext.Id);
                return;
            }

            await userRepository.Update(Identity.User, u => u.State = UserState.Connecting);
        }

        public async Task Disconnect()
        {
            var gameContext = await mediator.Send(new GetPlayingGameRequest(Identity.User));
            if (gameContext != null)
                await mediator.Publish(new CancelGameNotification(gameContext));
        }
    }
}