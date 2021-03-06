﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.Domain.Histories
{
    /// <summary>
    /// Описание истории карт в течении одного хода игрока
    /// </summary>
    [Serializable]
    public class History
    {
        /// <summary>
        /// Инициализирует экземпляр класса <see cref="History"/>
        /// </summary>
        /// <param name="cards">Коллекция карт, используемых в течении хода игрока</param>
        public History(ICollection<HistoryCard> cards)
        {
            Contract.Requires(cards != null);

            Cards = cards.ToList();
        }

        /// <summary>
        /// Коллекция карт, используемых в течении хода игрока
        /// </summary>
        public IList<HistoryCard> Cards { get; }

        public HistoryCard this[int index]
        {
            get => Cards[index];
            set => Cards[index] = value;
        }
    }
}
