using System;
using System.Collections.Generic;
using System.Linq;
using Arcomage.Network.Notifications;
using Arcomage.WebApi.Hubs;
using Arcomage.WebApi.Models.Game;
using AutoMapper;
using MediatR;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi.Handlers
{
    public class SignalRUpdateGameNotificationHandler : INotificationHandler<AfterPlayCardGameNotification>
    {
        private readonly IHubContext<IPlayGameClient> playGameHubContext;

        public SignalRUpdateGameNotificationHandler(IHubContext<IPlayGameClient> playGameHubContext)
        {
            this.playGameHubContext = playGameHubContext;
        }

        public void Handle(AfterPlayCardGameNotification notification)
        {
            var model = Mapper.Map<GameModel>((notification.GameContext, notification.Game));

            var firstUser = notification.GameContext.FirstUser.Id.ToString();
            var secondUser = notification.GameContext.SecondUser.Id.ToString();
            var users = new[] { firstUser, secondUser };

            playGameHubContext.Clients.Users(users).Update(model);
        }
    }
}