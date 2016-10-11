using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Arcomage.MonoGame.Droid.Commands
{
    public class ExitCommand : Command
    {
        private readonly Game game;

        public ExitCommand(Game game)
        {
            this.game = game;
        }

        public override void Execute(object parameter)
        {
            game.Exit();
        }
    }
}