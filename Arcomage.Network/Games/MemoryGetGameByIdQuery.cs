using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Games
{
    public class MemoryGetGameByIdQuery : IGetGameByIdQuery
    {
        private readonly ConcurrentDictionary<Guid, GameContext> gameStorage;

        public MemoryGetGameByIdQuery(ConcurrentDictionary<Guid, GameContext> gameStorage)
        {
            this.gameStorage = gameStorage;
        }

        public Task<GameContext> Get(Guid gameId)
        {
            gameStorage.TryGetValue(gameId, out var gameContext);

            return Task.FromResult(gameContext);
        }
    }
}
