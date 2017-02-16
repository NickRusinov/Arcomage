using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Players;
using Arcomage.Domain.Services;
using Arcomage.Unity.GameScene.Views;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Commands
{
    [RequireComponent(typeof(CardView))]
    public class DiscardCardCommand : Command
    {
        private Game game;

        private HumanPlayer player;

        private IDiscardCardCriteria discardCardCriteria;

        public void Initialize(Game game, HumanPlayer player, IDiscardCardCriteria discardCardCriteria)
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
            return discardCardCriteria.CanDiscardCard(game, player, (int)parameter);
        }
    }
}