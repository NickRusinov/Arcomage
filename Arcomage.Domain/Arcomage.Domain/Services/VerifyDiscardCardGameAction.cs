using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Exceptions;

namespace Arcomage.Domain.Services
{
    public class VerifyDiscardCardGameAction : IGameAction
    {
        private readonly PlayerMode playerMode;

        public VerifyDiscardCardGameAction(PlayerMode playerMode)
        {
            this.playerMode = playerMode;
        }

        public void Execute(Game game, int cardIndex)
        {
            if (game.IsFinished)
                throw new GameFinishedException();

            if (game.PlayerMode != playerMode)
                throw new NotCurrentPlayerException();
        }
    }
}
