using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Repositories;
using Arcomage.Network.Notifications;
using MediatR;

namespace Arcomage.Network.Handlers
{
    public class StartGameNotificationHandler : IAsyncNotificationHandler<StartGameNotification>
    {
        private readonly IRepository<GameContext> gameContextRepository;

        private readonly IRepository<User> userRepository;
        
        public StartGameNotificationHandler(IRepository<GameContext> gameContextRepository, IRepository<User> userRepository)
        {
            this.gameContextRepository = gameContextRepository;
            this.userRepository = userRepository;
        }

        public async Task Handle(StartGameNotification message)
        {
            await gameContextRepository.Update(message.GameContext,
                new Action<GameContext>(gc => gc.State = GameState.Started) +
                new Action<GameContext>(gc => gc.StartedDate = DateTime.UtcNow));

            await userRepository.Update(message.GameContext.FirstUser, u => u.State = UserState.Playing);
            await userRepository.Update(message.GameContext.SecondUser, u => u.State = UserState.Playing);
        }
    }
}
