using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Players;
using Arcomage.Domain.Services;
using Arcomage.MonoGame.Droid.ViewModels;

namespace Arcomage.MonoGame.Droid.Commands
{
    public class DiscardCardCommand : Command
    {
        private readonly Game game;

        private readonly HumanPlayer player;

        private readonly IDiscardCardCriteria discardCardCriteria;

        public DiscardCardCommand(Game game, HumanPlayer player, IDiscardCardCriteria discardCardCriteria)
        {
            this.game = game;
            this.player = player;
            this.discardCardCriteria = discardCardCriteria;
        }

        public override void Execute(object parameter)
        {
            player.PlayResult = new PlayResult(((CardViewModel)parameter).Index, false);
        }

        public override bool CanExecute(object parameter)
        {
            return discardCardCriteria.CanDiscardCard(game, ((CardViewModel)parameter).Index);
        }
    }
}