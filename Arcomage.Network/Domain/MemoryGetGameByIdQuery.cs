using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;

namespace Arcomage.Network.Domain
{
    public class MemoryGetGameByIdQuery : IGetGameByIdQuery
    {
        private readonly ConcurrentDictionary<Guid, Game> gameStorage;

        public MemoryGetGameByIdQuery(ConcurrentDictionary<Guid, Game> gameStorage)
        {
            this.gameStorage = gameStorage;
        }

        public Task<Game> Get(Guid gameId)
        {
            gameStorage.TryGetValue(gameId, out var game);

            return Task.FromResult(game);
        }
    }
}
