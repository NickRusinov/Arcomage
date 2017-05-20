using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Requests;
using MediatR;

namespace Arcomage.Network.Handlers
{
    public class MemoryGetPlayingGameRequestHandler : IRequestHandler<GetPlayingGameRequest, GameContext>
    {
        private readonly ConcurrentDictionary<Guid, GameContext> gameStorage;

        public MemoryGetPlayingGameRequestHandler(ConcurrentDictionary<Guid, GameContext> gameStorage)
        {
            this.gameStorage = gameStorage;
        }

        public GameContext Handle(GetPlayingGameRequest message)
        {
            return gameStorage.Values
                .Where(gc => gc.State.HasFlag(GameState.Started))
                .Where(gc => gc.FirstUser.Id == message.User.Id || gc.SecondUser.Id == message.User.Id)
                .FirstOrDefault();
        }
    }
}
