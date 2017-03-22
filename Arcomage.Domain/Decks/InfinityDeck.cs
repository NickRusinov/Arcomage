using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Cards;

namespace Arcomage.Domain.Decks
{
    /// <summary>
    /// Бесконечная колода карт
    /// </summary>
    [Serializable]
    public class InfinityDeck : Deck
    {
        /// <summary>
        /// Порядковый номер последней извлеченной из колоды карты
        /// </summary>
        private int index;

        /// <summary>
        /// Описание бесконечной колоды карт
        /// </summary>
        private readonly InfinityDeckInfo deckInfo;

        /// <summary>
        /// Список всех карт, включенных в колоду на текущий момент
        /// </summary>
        private readonly List<Card> cardCollection;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="InfinityDeck"/>
        /// </summary>
        /// <param name="deckInfo">Описание бесконечной колоды карт</param>
        /// <param name="cardCollection">Список всех карт, включенных в колоду на текущий момент</param>
        public InfinityDeck(InfinityDeckInfo deckInfo, ICollection<Card> cardCollection)
        {
            Contract.Requires(deckInfo != null);
            Contract.Requires(cardCollection != null);

            this.deckInfo = deckInfo;
            this.cardCollection = cardCollection.ToList();
        }

        /// <inheritdoc/>
        public override Card PopCard(Game game)
        {
            var randomCardIndex = deckInfo.Random.Next(cardCollection.Count);

            return cardCollection[randomCardIndex].WithIndex(++index);
        }

        /// <inheritdoc/>
        public override void PushCard(Game game, Card card)
        {

        }
    }
}
