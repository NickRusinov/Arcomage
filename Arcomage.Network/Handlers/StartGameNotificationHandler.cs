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
        private readonly IGameContextRepository gameContextRepository;

        private readonly IUserContextRepository userContextRepository;
        
        public StartGameNotificationHandler(IGameContextRepository gameContextRepository, IUserContextRepository userContextRepository)
        {
            this.gameContextRepository = gameContextRepository;
            this.userContextRepository = userContextRepository;
        }

        public async Task Handle(StartGameNotification message)
        {
            await gameContextRepository.Update(message.GameContext,
                gc => gc.State = GameState.Playing,
                gc => gc.StartedDate = DateTime.UtcNow);

            await userContextRepository.Update(message.GameContext.FirstUser,
                uc => uc.State = UserState.Playing);
            await userContextRepository.Update(message.GameContext.SecondUser,
                uc => uc.State = UserState.Playing);
        }
    }
}
