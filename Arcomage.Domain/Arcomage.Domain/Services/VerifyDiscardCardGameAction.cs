using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Exceptions;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Services
{
    public class VerifyDiscardCardGameAction : IGameAction
    {
        private readonly Game game;

        private readonly Player player;

        public VerifyDiscardCardGameAction(Game game, Player player)
        {
            this.game = game;
            this.player = player;
        }

        public void Execute(int cardIndex)
        {
            if (game.IsFinished)
                throw new GameFinishedException();

            if (game.GetCurrentPlayer() != player)
                throw new NotCurrentPlayerException();
        }
    }
}
