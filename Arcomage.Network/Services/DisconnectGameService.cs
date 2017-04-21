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

        private readonly GetConnectingGameQuery getConnectingGameQuery;

        public DisconnectGameService(IGameContextRepository gameContextRepository, GetConnectingGameQuery getConnectingGameQuery)
        {
            this.gameContextRepository = gameContextRepository;
            this.getConnectingGameQuery = getConnectingGameQuery;
        }

        public async Task<GameContext> DisconnectGame(Guid userId)
        {
            var gameContext = await getConnectingGameQuery.Handle(userId);
            if (gameContext == null)
                return null;

            BackgroundJob.Delete(gameContext.JobId);

            await gameContextRepository.Update(gameContext, 
                gc => gc.State = GameState.Cancelled, 
                gc => gc.CancelledDate = DateTime.UtcNow);

            return gameContext;
        }
    }
}
