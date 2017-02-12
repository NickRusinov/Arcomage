using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Выполянет замену активированной или сброшенной карты на новую из игровой колоды
    /// </summary>
    public class ReplaceCardAction : IAfterPlayAction
    {
        /// <inheritdoc/>
        public void Play(Game game, PlayResult playResult)
        {
            var oldCard = game.Players.CurrentPlayer.Hand.Cards[playResult.Card];

            game.Deck.PushCard(game, oldCard);
            var newCard = game.Deck.PopCard(game);

            game.Players.CurrentPlayer.Hand.Cards[playResult.Card] = newCard;
        }
    }
}
