using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Requests;
using Hangfire;
using MediatR;

namespace Arcomage.Network.RequestHandlers
{
    public class CancelGameRequestHandler : IAsyncRequestHandler<CancelGameRequest>
    {
        private readonly IRepository<GameContext> gameContextRepository;

        private readonly IRepository<User> userRepository;

        public CancelGameRequestHandler(IRepository<GameContext> gameContextRepository, IRepository<User> userRepository)
        {
            this.gameContextRepository = gameContextRepository;
            this.userRepository = userRepository;
        }

        public async Task Handle(CancelGameRequest message)
        {
            BackgroundJob.Delete(message.GameContext.JobId);

            await gameContextRepository.Update(message.GameContext,
                new Action<GameContext>(gc => gc.State = GameState.Cancelled) +
                new Action<GameContext>(gc => gc.CancelledDate = DateTime.UtcNow));

            await userRepository.Update(message.GameContext.FirstUser, u => u.State = UserState.None);
            await userRepository.Update(message.GameContext.SecondUser, u => u.State = UserState.None);
        }
    }
}
