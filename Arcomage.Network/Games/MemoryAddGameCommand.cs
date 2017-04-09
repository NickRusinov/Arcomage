using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Games
{
    public class MemoryAddGameCommand : IAddGameCommand
    {
        private readonly ConcurrentDictionary<Guid, GameContext> gameStorage;

        public MemoryAddGameCommand(ConcurrentDictionary<Guid, GameContext> gameStorage)
        {
            this.gameStorage = gameStorage;
        }

        public Task Add(GameContext gameContext)
        {
            gameStorage.AddOrUpdate(gameContext.Id, gameContext, (_, g) => g);

            return Task.CompletedTask;
        }
    }
}
