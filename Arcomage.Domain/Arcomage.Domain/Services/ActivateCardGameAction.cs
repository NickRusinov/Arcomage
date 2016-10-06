using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Exceptions;

namespace Arcomage.Domain.Services
{
    public class ActivateCardGameAction : IGameAction
    {
        private readonly Game game;

        private readonly Player player;

        public ActivateCardGameAction(Game game, Player player)
        {
            this.game = game;
            this.player = player;
        }

        public void Execute(int cardIndex)
        {
            var card = player.CardSet.Cards[cardIndex];
            
            card.Activate(game);
            card.PaymentResources(player.Resources);
        }
    }
}
