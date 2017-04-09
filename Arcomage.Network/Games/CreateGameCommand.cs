using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Network.Domain;

namespace Arcomage.Network.Games
{
    public class CreateGameCommand : ICreateGameCommand
    {
        private readonly IStartGameCommand startGameCommand;

        private readonly IAddGameCommand addGameCommand;
        
        public CreateGameCommand(IStartGameCommand startGameCommand, IAddGameCommand addGameCommand)
        {
            this.startGameCommand = startGameCommand;
            this.addGameCommand = addGameCommand;
        }

        public async Task<GameContext> Create(UserContext firstUserContext, UserContext secondUserContext)
        {
            var gameContext = new GameContext
            {
                Id = Guid.NewGuid(),
                State = GameState.Created,
                FirstUser = firstUserContext,
                SecondUser = secondUserContext,
            };

            await addGameCommand.Add(gameContext);
            await startGameCommand.Start(gameContext);

            return gameContext;
        }
    }
}
