using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Выполянет замену активированной или сброшенной карты на новую из игровой колоды
    /// </summary>
    public class ReplaceCardAction : IPlayCardAction
    {
        private readonly IPlayCardAction nextAction;

        public ReplaceCardAction(IPlayCardAction nextAction)
        {
            this.nextAction = nextAction;
        }

        /// <inheritdoc/>
        public Task Play(Game game, PlayResult playResult)
        {
            var oldCard = game.Players.CurrentPlayer.Hand[playResult.Card];

            game.Deck.PushCard(game, oldCard);
            var newCard = game.Deck.PopCard(game);

            game.Players.CurrentPlayer.Hand[playResult.Card] = newCard;

            return nextAction.Play(game, playResult);
        }
    }
}
