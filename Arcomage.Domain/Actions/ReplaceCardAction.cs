using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Players;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Выполянет замену активированной или сброшенной карты на новую из игровой колоды
    /// </summary>
    public class ReplaceCardAction : IPlayAction
    {
        private readonly IPlayAction nextAction;

        public ReplaceCardAction(IPlayAction nextAction)
        {
            this.nextAction = nextAction;
        }

        /// <inheritdoc/>
        public Task<GameResult> Play(Game game, Player player, PlayResult playResult)
        {
            var oldCard = player.Hand[playResult.Card];

            game.Deck.PushCard(game, oldCard);
            var newCard = game.Deck.PopCard(game);

            player.Hand[playResult.Card] = newCard;

            return nextAction.Play(game, player, playResult);
        }

        /// <inheritdoc/>
        public bool CanPlay(Game game, Player player, PlayResult playResult)
        {
            return nextAction.CanPlay(game, player, playResult);
        }
    }
}
