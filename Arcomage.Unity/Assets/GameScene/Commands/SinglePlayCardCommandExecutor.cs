using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain;
using Arcomage.Domain.Players;
using Arcomage.Domain.Services;
using Arcomage.Unity.Shared.Scripts;

namespace Arcomage.Unity.GameScene.Commands
{
    public class SinglePlayCardCommandExecutor : ICommandExecutor<PlayCardCommand>, ICommandCanExecutor<PlayCardCommand>
    {
        private readonly Game game;

        private readonly HumanPlayer player;

        private readonly IPlayCardCriteria playCardCriteria;

        public SinglePlayCardCommandExecutor(Game game, HumanPlayer player, IPlayCardCriteria playCardCriteria)
        {
            this.game = game;
            this.player = player;
            this.playCardCriteria = playCardCriteria;
        }

        public void Execute(PlayCardCommand command)
        {
            player.SetPlayResult(new PlayResult(command.Index, true));
        }

        public bool CanExecute(PlayCardCommand command)
        {
            return playCardCriteria.CanPlayCard(game, player, command.Index);
        }
    }
}
