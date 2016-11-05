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
    public class PlayCardCommand : Command
    {
        private readonly Game game;

        private readonly HumanPlayer player;

        private readonly IPlayCardCriteria playCardCriteria;

        public PlayCardCommand(Game game, HumanPlayer player, IPlayCardCriteria playCardCriteria)
        {
            this.game = game;
            this.player = player;
            this.playCardCriteria = playCardCriteria;
        }

        public override void Execute(object parameter)
        {
            player.PlayResult = new PlayResult(((CardViewModel)parameter).Index, true);
        }

        public override bool CanExecute(object parameter)
        {
            return playCardCriteria.CanPlayCard(game, ((CardViewModel)parameter).Index);
        }
    }
}