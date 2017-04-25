using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Queries;
using Arcomage.Network.Repositories;
using Hangfire;

namespace Arcomage.Network.Services
{
    public class DisconnectGameService : IDisconnectGameService
    {
        private readonly IGameContextRepository gameContextRepository;

        private readonly IUserContextRepository userContextRepository;

        private readonly IGetPlayingGameQuery getConnectingGameQuery;

        public DisconnectGameService(IGameContextRepository gameContextRepository, IUserContextRepository userContextRepository, IGetPlayingGameQuery getConnectingGameQuery)
        {
            this.gameContextRepository = gameContextRepository;
            this.userContextRepository = userContextRepository;
            this.getConnectingGameQuery = getConnectingGameQuery;
        }

        public async Task<GameContext> DisconnectGame(UserContext userContext)
        {
            var gameContext = await getConnectingGameQuery.Handle(userContext);
            if (gameContext == null)
                return null;

            BackgroundJob.Delete(gameContext.JobId);

            await gameContextRepository.Update(gameContext, 
                gc => gc.State = GameState.Cancelled, 
                gc => gc.CancelledDate = DateTime.UtcNow);

            await userContextRepository.Update(gameContext.FirstUser,
                uc => uc.State = UserState.None);
            await userContextRepository.Update(gameContext.SecondUser,
                uc => uc.State = UserState.None);

            return gameContext;
        }
    }
}
