using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Services;
using Arcomage.MonoGame.Droid.ViewModels;

namespace Arcomage.MonoGame.Droid.Commands
{
    public class PlayCardCommand : Command
    {
        private readonly Game game;

        private readonly IGameAction playGameAction;

        private readonly IPlayCardCriteria playCardCriteria;

        public PlayCardCommand(Game game, IGameAction playGameAction, IPlayCardCriteria playCardCriteria)
        {
            this.game = game;
            this.playGameAction = playGameAction;
            this.playCardCriteria = playCardCriteria;
        }

        public override void Execute(object parameter)
        {
            playGameAction.Execute(game, ((CardViewModel)parameter).Index);
        }

        public override bool CanExecute(object parameter)
        {
            return playCardCriteria.CanPlayCard(game, ((CardViewModel)parameter).Index);
        }
    }
}