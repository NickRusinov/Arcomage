using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Queries
{
    public class MemoryGetPlayingGameQuery : IGetPlayingGameQuery
    {
        private readonly ConcurrentDictionary<Guid, GameContext> gameStorage;

        public MemoryGetPlayingGameQuery(ConcurrentDictionary<Guid, GameContext> gameStorage)
        {
            this.gameStorage = gameStorage;
        }

        public Task<GameContext> Handle(UserContext userContext)
        {
            var gameContext = gameStorage.Values
                .Where(gc => gc.State.HasFlag(GameState.Playing))
                .Where(gc => gc.FirstUser.Id == userContext.Id || gc.SecondUser.Id == userContext.Id)
                .FirstOrDefault();

            return Task.FromResult(gameContext);
        }
    }
}
