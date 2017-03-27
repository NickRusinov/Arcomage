using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Histories;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Добавляет карту в историю хода текущего игрока
    /// </summary>
    public class AddHistoryAction : IPlayCardAction
    {
        private readonly IPlayCardAction nextAction;

        public AddHistoryAction(IPlayCardAction nextAction)
        {
            this.nextAction = nextAction;
        }

        /// <inheritdoc/>
        public Task Play(Game game, PlayResult playResult)
        {
            var historyCard = new HistoryCard(game.Players.CurrentPlayer.Hand[playResult.Card], playResult.IsPlay);
            game.History.Cards.Add(historyCard);

            return nextAction.Play(game, playResult);
        }
    }
}
