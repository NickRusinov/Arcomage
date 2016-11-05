using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    public class ReplaceCardAction : UniformCardAction
    {
        protected override void Execute(Game game, Player player, int cardIndex)
        {
            var oldCard = player.Hand.Cards[cardIndex];

            game.Deck.PushCard(game, oldCard);
            var newCard = game.Deck.PopCard(game);

            player.Hand.Cards[cardIndex] = newCard;
        }
    }
}
