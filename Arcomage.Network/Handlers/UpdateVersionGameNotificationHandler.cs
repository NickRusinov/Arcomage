using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Notifications;
using Arcomage.Network.Repositories;
using MediatR;

namespace Arcomage.Network.Handlers
{
    public class UpdateVersionGameNotificationHandler : IAsyncNotificationHandler<AfterPlayCardGameNotification>
    {
        private readonly IGameContextRepository gameContextRepository;

        public UpdateVersionGameNotificationHandler(IGameContextRepository gameContextRepository)
        {
            this.gameContextRepository = gameContextRepository;
        }

        public async Task Handle(AfterPlayCardGameNotification notification)
        {
            await gameContextRepository.Update(notification.GameContext,
                gc => gc.Version++);
        }
    }
}
