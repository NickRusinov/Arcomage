using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Histories;
using Arcomage.Domain.Players;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Добавляет карту в историю хода текущего игрока
    /// </summary>
    public class AddHistoryAction : IPlayAction
    {
        private readonly IPlayAction nextAction;

        public AddHistoryAction(IPlayAction nextAction)
        {
            this.nextAction = nextAction;
        }

        /// <inheritdoc/>
        public Task<GameResult> Play(Game game, Player player, PlayResult playResult)
        {
            if (game.History.Cards.LastOrDefault()?.Player != game.Players.Kind)
                game.History.Cards.Clear();

            var historyCard = new HistoryCard(player.Hand[playResult.Card], game.Players.Kind, playResult.IsPlay);
            game.History.Cards.Add(historyCard);

            return nextAction.Play(game, player, playResult);
        }

        /// <inheritdoc/>
        public bool CanPlay(Game game, Player player, PlayResult playResult)
        {
            return nextAction.CanPlay(game, player, playResult);
        }
    }
}
