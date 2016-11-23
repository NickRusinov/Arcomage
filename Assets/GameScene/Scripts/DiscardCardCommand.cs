using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Players;
using Arcomage.Domain.Services;
using Arcomage.Unity.Shared.Scripts;

namespace Arcomage.Unity.GameScene.Scripts
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
            player.SetPlayResult(new PlayResult((int)parameter, false));
        }

        public override bool CanExecute(object parameter)
        {
            return discardCardCriteria.CanDiscardCard(game, (int)parameter);
        }
    }
}