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
        private readonly ConcurrentDictionary<Guid, GameContext> gameStorage;

        public MemoryGameContextRepository(ConcurrentDictionary<Guid, GameContext> gameStorage)
        {
            this.gameStorage = gameStorage;
        }

        public Task<bool> Add(GameContext gameContext)
        {
            gameStorage.AddOrUpdate(gameContext.Id, gameContext, (_, g) => g);

            return Task.FromResult(true);
        }

        public Task<bool> Save(GameContext gameContext)
        {
            gameStorage.AddOrUpdate(gameContext.Id, gameContext, (_, g) => gameContext);

            return Task.FromResult(true);
        }

        public Task<bool> Update(GameContext gameContext, params Action<GameContext>[] update)
        {
            gameStorage.AddOrUpdate(gameContext.Id,
                id =>
                {
                    Array.ForEach(update, u => u.Invoke(gameContext));

                    return gameContext;
                },
                (id, gc) =>
                {
                    Array.ForEach(update, u => u.Invoke(gameContext));
                    Array.ForEach(update, u => u.Invoke(gc));

                    return gc;
                });

            return Task.FromResult(true);
        }

        public Task<GameContext> GetById(Guid id)
        {
            gameStorage.TryGetValue(id, out var gameContext);

            return Task.FromResult(gameContext);
        }
    }
}
