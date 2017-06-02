using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Notifications;
using MediatR;

namespace Arcomage.Network.NotificationHandlers
{
    public class CancelGameNotificationHandler : IAsyncNotificationHandler<CancelGameNotification>
    {
        private readonly IRepository<GameContext> gameContextRepository;

        private readonly IRepository<User> userRepository;

        public CancelGameNotificationHandler(IRepository<GameContext> gameContextRepository, IRepository<User> userRepository)
        {
            this.gameContextRepository = gameContextRepository;
            this.userRepository = userRepository;
        }

        public async Task Handle(CancelGameNotification message)
        {
            await gameContextRepository.Update(message.GameContext,
                new Action<GameContext>(gc => gc.State = GameState.Cancelled) +
                new Action<GameContext>(gc => gc.CancelledDate = DateTime.UtcNow));

            await userRepository.Update(message.GameContext.FirstUser, u => u.State = UserState.None);
            await userRepository.Update(message.GameContext.SecondUser, u => u.State = UserState.None);
        }
    }
}
