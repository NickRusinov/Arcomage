using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Services
{
    public class ActivateCardGameAction : IGameAction
    {
        public void Execute(Game game, int cardIndex)
        {
            var player = game.GetCurrentPlayer();
            var card = player.CardSet.Cards[cardIndex];
            
            card.Activate(game);
            card.PaymentResources(player.Resources);
        }
    }
}
