using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain;
using Arcomage.Unity.Shared.Scripts;

namespace Arcomage.Unity.GameScene.Commands
{
    public class SingleUpdateCommandExecutor : ICommandExecutor<UpdateCommand>
    {
        private readonly Game game;

        private readonly GameLoop gameLoop;

        public SingleUpdateCommandExecutor(Game game, GameLoop gameLoop)
        {
            this.game = game;
            this.gameLoop = gameLoop;
        }

        public void Execute(UpdateCommand command)
        {
            gameLoop.Update(game);
        }
    }
}
