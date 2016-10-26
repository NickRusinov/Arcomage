using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Services
{
    public class ReplaceCardGameAction : IGameAction
    {
        public void Execute(Game game, int cardIndex)
        {
            var player = game.GetCurrentPlayer();
            var oldCard = player.CardSet.Cards[cardIndex];

            game.Deck.PushCard(game, oldCard);
            var newCard = game.Deck.PopCard(game);

            player.CardSet.Cards[cardIndex] = newCard;
        }
    }
}
