using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Services;
using Arcomage.MonoGame.Droid.ViewModels;

namespace Arcomage.MonoGame.Droid.Commands
{
    public class DiscardCardCommand : Command
    {
        private readonly Game game;

        private readonly IGameAction discardGameAction;

        private readonly IDiscardCardCriteria discardCardCriteria;

        public DiscardCardCommand(Game game, IGameAction discardGameAction, IDiscardCardCriteria discardCardCriteria)
        {
            this.game = game;
            this.discardGameAction = discardGameAction;
            this.discardCardCriteria = discardCardCriteria;
        }

        public override void Execute(object parameter)
        {
            discardGameAction.Execute(game, ((CardViewModel)parameter).Index);
        }

        public override bool CanExecute(object parameter)
        {
            return discardCardCriteria.CanDiscardCard(game, ((CardViewModel)parameter).Index);
        }
    }
}