using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Notifications;
using MediatR;

namespace Arcomage.Network.NotificationHandlers
{
    public class UpdateGameNotificationHandler : IAsyncNotificationHandler<AfterPlayCardGameNotification>
    {
        private readonly IRepository<GameContext> gameContextRepository;

        public UpdateGameNotificationHandler(IRepository<GameContext> gameContextRepository)
        {
            this.gameContextRepository = gameContextRepository;
        }

        public async Task Handle(AfterPlayCardGameNotification notification)
        {
            var game = notification.GameContext.Game;

            await gameContextRepository.Update(notification.GameContext,
                new Action<GameContext>(gc => gc.Game = game) +
                new Action<GameContext>(gc => gc.Version++));
        }
    }
}
