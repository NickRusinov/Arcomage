using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;

namespace Arcomage.Network.Repositories
{
    public class MemoryGameRepository : IGameRepository
    {
        private readonly ConcurrentDictionary<Guid, Game> gameStorage;

        public MemoryGameRepository(ConcurrentDictionary<Guid, Game> gameStorage)
        {
            this.gameStorage = gameStorage;
        }

        public Task<bool> Add(Guid id, Game game)
        {
            gameStorage.AddOrUpdate(id, game, (_, g) => g);

            return Task.FromResult(true);
        }

        public Task<Game> GetById(Guid id)
        {
            gameStorage.TryGetValue(id, out var game);

            return Task.FromResult(game);
        }
    }
}
