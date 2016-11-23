using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    public class ActivateCardAction : ICardAction
    {
        public void PlayExecute(Game game, Player player, int cardIndex)
        {
            var card = player.Hand.Cards[cardIndex];
            
            card.Activate(game);
            card.PaymentResources(player.Resources);
        }

        public void DiscardExecute(Game game, Player player, int cardIndex)
        {

        }
    }
}
