using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Services;

namespace Arcomage.MonoGame.Droid.Commands
{
    public class PlayCardCommand : Command
    {
        private readonly IGameAction playGameAction;

        public PlayCardCommand(IGameAction playGameAction)
        {
            this.playGameAction = playGameAction;
        }

        public override void Execute(object parameter)
        {
            playGameAction.Execute(0 /* TODO Resolve Card Index */);
        }
    }
}