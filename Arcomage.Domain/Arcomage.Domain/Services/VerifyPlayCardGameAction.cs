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
    public class VerifyPlayCardGameAction : IGameAction
    {
        private readonly PlayerMode playerMode;

        public VerifyPlayCardGameAction(PlayerMode playerMode)
        {
            this.playerMode = playerMode;
        }

        public void Execute(Game game, int cardIndex)
        {
            var player = game.GetCurrentPlayer();

            if (game.IsFinished)
                throw new GameFinishedException();

            if (game.PlayerMode != playerMode)
                throw new NotCurrentPlayerException();

            if (!player.Hand.Cards[cardIndex].IsEnoughResources(player.Resources))
                throw new NotEnoughResourcesException();
        }
    }
}
