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
        private readonly Game game;

        private readonly Player player;

        public VerifyPlayCardGameAction(Game game, Player player)
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

            if (!player.CardSet.Cards[cardIndex].IsEnoughResources(player.Resources))
                throw new NotEnoughResourcesException();
        }
    }
}
