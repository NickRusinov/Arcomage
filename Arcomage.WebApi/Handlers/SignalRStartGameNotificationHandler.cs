using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Network.Notifications;
using Arcomage.WebApi.Hubs;
using MediatR;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi.Handlers
{
    public class SignalRStartGameNotificationHandler : INotificationHandler<StartGameNotification>
    {
        private readonly IHubContext<IConnectGameClient> connectGameHubContext;

        public SignalRStartGameNotificationHandler(IHubContext<IConnectGameClient> connectGameHubContext)
        {
            this.connectGameHubContext = connectGameHubContext;
        }

        public void Handle(StartGameNotification notification)
        {
            var firstUser = notification.GameContext.FirstUser.Id.ToString();
            var secondUser = notification.GameContext.SecondUser.Id.ToString();
            var users = new[] { firstUser, secondUser };

            connectGameHubContext.Clients.Users(users).Connected(notification.GameContext.Id);
        }
    }
}