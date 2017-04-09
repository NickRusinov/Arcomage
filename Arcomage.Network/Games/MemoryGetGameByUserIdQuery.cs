using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Games
{
    public class MemoryGetGameByUserIdQuery : IGetGameByUserIdQuery
    {
        private readonly ConcurrentDictionary<Guid, GameContext> gameStorage;

        public MemoryGetGameByUserIdQuery(ConcurrentDictionary<Guid, GameContext> gameStorage)
        {
            this.gameStorage = gameStorage;
        }

        public Task<GameContext> Get(Guid userId)
        {
            var gameContext = gameStorage.Values
                .SingleOrDefault(gc => gc.FirstUser.Id == userId || gc.SecondUser.Id == userId);

            return Task.FromResult(gameContext);
        }
    }
}
