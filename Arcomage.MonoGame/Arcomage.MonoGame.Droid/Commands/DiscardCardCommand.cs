using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Services;

namespace Arcomage.MonoGame.Droid.Commands
{
    public class DiscardCardCommand : Command
    {
        private readonly IGameAction discardGameAction;

        public DiscardCardCommand(IGameAction discardGameAction)
        {
            this.discardGameAction = discardGameAction;
        }

        public override void Execute(object parameter)
        {
            discardGameAction.Execute(0 /* TODO Resolve Card Index */);
        }
    }
}