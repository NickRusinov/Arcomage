using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using Arcomage.Domain.Players;

namespace Arcomage.Domain.Histories
{
    /// <summary>
    /// Класс, представляющий карту в истории хода
    /// </summary>
    [Serializable]
    public class HistoryCard
    {
        /// <summary>
        /// Инициализирует экземпляр класса <see cref="HistoryCard"/>
        /// </summary>
        /// <param name="card">Карта</param>
        /// <param name="isPlayed">true, если карта была активирована, и false, если сброшена</param>
        public HistoryCard(Card card, PlayerKind player, bool isPlayed)
        {
            Contract.Requires(card != null);

            Card = card;
            Player = player;
            IsPlayed = isPlayed;
        }

        /// <summary>
        /// Карта
        /// </summary>
        public Card Card { get; }

        public PlayerKind Player { get; }

        /// <summary>
        /// Признак активации карты
        /// </summary>
        public bool IsPlayed { get; }
    }
}
