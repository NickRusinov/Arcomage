using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Repositories;

namespace Arcomage.Network.Queries
{
    public class GetConnectingGameQuery
    {
        private readonly IGameContextRepository gameContextRepository;

        public GetConnectingGameQuery(IGameContextRepository gameContextRepository)
        {
            this.gameContextRepository = gameContextRepository;
        }

        public async Task<GameContext> Handle(Guid userId)
        {
            var gameContext = await gameContextRepository.GetByUserId(userId, GameState.Created | GameState.Playing);

            return gameContext;
        }
    }
}
