using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Services;

namespace Arcomage.MonoGame.Droid.Commands
{
    public class PlayCardCommand : Command
    {
        private readonly Game game;

        private readonly IGameAction playGameAction;

        public PlayCardCommand(Game game, IGameAction playGameAction)
        {
            this.game = game;
            this.playGameAction = playGameAction;
        }

        public override void Execute(object parameter)
        {
            playGameAction.Execute(game, 0 /* TODO Resolve Card Index */);
        }
    }
}