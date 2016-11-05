using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain;
using Arcomage.Domain.Entities;

namespace Arcomage.MonoGame.Droid.Commands
{
    public class UpdateCommand : Command
    {
        private readonly Game game;

        private readonly GameLoop gameLoop;

        public UpdateCommand(Game game, GameLoop gameLoop)
        {
            this.game = game;
            this.gameLoop = gameLoop;
        }

        public override void Execute(object parameter)
        {
            gameLoop.Update();
        }

        public override bool CanExecute(object parameter)
        {
            return Equals(game.Result, GameResult.None);
        }
    }
}