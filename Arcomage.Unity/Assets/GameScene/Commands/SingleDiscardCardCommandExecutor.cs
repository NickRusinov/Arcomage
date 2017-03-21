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
    public class SingleDiscardCardCommandExecutor : ICommandExecutor<DiscardCardCommand>, ICommandCanExecutor<DiscardCardCommand>
    {
        private readonly Game game;

        private readonly HumanPlayer player;

        private readonly IDiscardCardCriteria discardCardCriteria;

        public SingleDiscardCardCommandExecutor(Game game, HumanPlayer player, IDiscardCardCriteria discardCardCriteria)
        {
            this.game = game;
            this.player = player;
            this.discardCardCriteria = discardCardCriteria;
        }

        public void Execute(DiscardCardCommand command)
        {
            player.SetPlayResult(new PlayResult(command.Index, false));
        }

        public bool CanExecute(DiscardCardCommand command)
        {
            return discardCardCriteria.CanDiscardCard(game, player, command.Index);
        }
    }
}
