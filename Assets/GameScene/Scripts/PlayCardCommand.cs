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
            player.SetPlayResult(new PlayResult((int)parameter, true));
        }

        public override bool CanExecute(object parameter)
        {
            return playCardCriteria.CanPlayCard(game, (int)parameter);
        }
    }
}