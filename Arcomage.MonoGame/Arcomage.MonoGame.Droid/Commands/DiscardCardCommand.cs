using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Services;

namespace Arcomage.MonoGame.Droid.Commands
{
    public class DiscardCardCommand : Command
    {
        private readonly Game game;

        private readonly IGameAction discardGameAction;

        public DiscardCardCommand(Game game, IGameAction discardGameAction)
        {
            this.game = game;
            this.discardGameAction = discardGameAction;
        }

        public override void Execute(object parameter)
        {
            discardGameAction.Execute(game, 0 /* TODO Resolve Card Index */);
        }
    }
}