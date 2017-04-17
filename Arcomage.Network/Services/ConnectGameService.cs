using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Repositories;

namespace Arcomage.Network.Services
{
    public class ConnectGameService : IConnectGameService
    {
        private readonly ICreateGameService createGameService;

        private readonly IGameContextRepository gameContextRepository;

        private readonly IUserContextRepository userContextRepository;

        public ConnectGameService(ICreateGameService createGameService, IGameContextRepository gameContextRepository, IUserContextRepository userContextRepository)
        {
            this.createGameService = createGameService;
            this.gameContextRepository = gameContextRepository;
            this.userContextRepository = userContextRepository;
        }

        public async Task<GameContext> ConnectGame(Guid userId)
        {
            var gameContext = await gameContextRepository.GetByUserId(userId, GameState.Created | GameState.Playing);
            if (gameContext != null)
                return gameContext;

            var firstUserContext = await userContextRepository.GetById(userId) ??
                throw new NetworkException(NetworkResources.NotFoundActiveUserContext);

#warning Hardcode users
            var secondUserContext = await userContextRepository.GetById(Guid.Parse("EB3AB862-E0D0-413B-B732-6BDD86B3A1A3")) ??
                throw new NetworkException(NetworkResources.NotFoundActiveUserContext);

            return await createGameService.CreateGame(firstUserContext, secondUserContext);
        }
    }
}
