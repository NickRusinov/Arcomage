using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Games
{
    public class MemoryChangeStateCommand : IChangeStateGameCommand
    {
        private readonly ConcurrentDictionary<Guid, GameContext> gameStorage;

        public MemoryChangeStateCommand(ConcurrentDictionary<Guid, GameContext> gameStorage)
        {
            this.gameStorage = gameStorage;
        }

        public Task ChangeState(GameContext gameContext, GameState state)
        {
            if (gameStorage.TryGetValue(gameContext.Id, out var storageGameContext))
            {
                gameContext.State = state;
                storageGameContext.State = state;
            }

            return Task.CompletedTask;
        }
    }
}
