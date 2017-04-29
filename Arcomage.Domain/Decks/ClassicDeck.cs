using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;
using static Arcomage.Domain.Extensions;

namespace Arcomage.Domain.Decks
{
    /// <summary>
    /// Классическая колода карт
    /// </summary>
    [Serializable]
    public class ClassicDeck : Deck
    {
        /// <summary>
        /// Порядковый номер последней извлеченной из колоды карты
        /// </summary>
        private int index;

        /// <summary>
        /// Описание классической колоды карт
        /// </summary>
        private readonly ClassicDeckInfo deckInfo;

        /// <summary>
        /// Список всех карт, включенных в колоду на текущий момент
        /// </summary>
        private readonly List<Card> cardCollection;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="ClassicDeck"/>
        /// </summary>
        /// <param name="deckInfo">Описание классической колоды карт</param>
        /// <param name="cardCollection">Список всех карт, включенных в колоду на текущий момент</param>
        public ClassicDeck(ClassicDeckInfo deckInfo, ICollection<Card> cardCollection)
        {
            Contract.Requires(deckInfo != null);
            Contract.Requires(cardCollection != null);

            this.deckInfo = deckInfo;
            this.cardCollection = cardCollection.ToList();
        }

        /// <inheritdoc/>
        public override Card PopCard(Game game)
        {
            var randomCardIndex = deckInfo.Random.Next(cardCollection.Count / 2);

            var card = Copy(cardCollection[randomCardIndex]);
            card.Index = ++index;
            cardCollection.RemoveAt(randomCardIndex);

            return card;
        }

        /// <inheritdoc/>
        public override void PushCard(Game game, Card card)
        {
            cardCollection.Add(card);
        }
    }
}
