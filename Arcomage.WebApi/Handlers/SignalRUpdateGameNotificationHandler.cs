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
            var firstUser = notification.GameContext.FirstUser.Id.ToString();
            var secondUser = notification.GameContext.SecondUser.Id.ToString();

            var firstUserModel = Mapper.Map<GameModel>((notification.GameContext, notification.GameContext.FirstUser, notification.Game));
            var secondUserModel = Mapper.Map<GameModel>((notification.GameContext, notification.GameContext.SecondUser, notification.Game));

            playGameHubContext.Clients.User(firstUser).Update(firstUserModel);
            playGameHubContext.Clients.User(secondUser).Update(secondUserModel);
        }
    }
}