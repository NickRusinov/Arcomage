using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Добавляет карту в историю хода текущего игрока
    /// </summary>
    public class AddHistoryAction : IAfterPlayAction
    {
        /// <inheritdoc/>
        public void Play(Game game, PlayResult playResult)
        {
            var historyCard = new HistoryCard(game.Players.CurrentPlayer.Hand.Cards[playResult.Card], playResult.IsPlay);

            game.History.Cards.Add(historyCard);
        }
    }
}
