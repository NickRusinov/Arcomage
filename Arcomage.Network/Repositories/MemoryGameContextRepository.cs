using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Repositories
{
    public class MemoryGameContextRepository : IGameContextRepository
    {
        private readonly ConcurrentDictionary<Guid, GameContext> gameStorage =
            new ConcurrentDictionary<Guid, GameContext>();

        public Task<bool> Add(GameContext gameContext)
        {
            gameStorage.AddOrUpdate(gameContext.Id, gameContext, (_, g) => g);

            return Task.FromResult(true);
        }

        public Task<GameContext> GetById(Guid id)
        {
            gameStorage.TryGetValue(id, out var gameContext);

            return Task.FromResult(gameContext);
        }

        public Task<GameContext> GetByUserId(Guid id)
        {
            var gameContext = gameStorage.Values
                .SingleOrDefault(gc => gc.FirstUser.Id == id || gc.SecondUser.Id == id);

            return Task.FromResult(gameContext);
        }
    }
}
