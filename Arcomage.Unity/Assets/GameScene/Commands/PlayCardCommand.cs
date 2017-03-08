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
    public class PlayCardCommand : Command
    {
        private Game game;

        private HumanPlayer player;

        private IPlayCardCriteria playCardCriteria;

        public void Initialize(Game game, HumanPlayer player, IPlayCardCriteria playCardCriteria)
        {
            this.game = game;
            this.player = player;
            this.playCardCriteria = playCardCriteria;
        }

        public override void Execute(object parameter)
        {
            player.SetPlayResult(new PlayResult((int)parameter, true));
        }

        public override bool CanExecute(object parameter)
        {
            return playCardCriteria.CanPlayCard(game, player, (int)parameter);
        }
    }
}