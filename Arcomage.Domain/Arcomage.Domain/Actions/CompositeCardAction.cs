using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    public class CompositeCardAction : ICardAction
    {
        private readonly IReadOnlyCollection<ICardAction> cardActionCollection;

        public CompositeCardAction(IReadOnlyCollection<ICardAction> cardActionCollection)
        {
            this.cardActionCollection = cardActionCollection;
        }

        public CompositeCardAction(params ICardAction[] cardActionCollection)
            : this(cardActionCollection as IReadOnlyCollection<ICardAction>)
        {
            
        }

        public void PlayExecute(Game game, Player player, int cardIndex)
        {
            foreach (var cardAction in cardActionCollection)
                cardAction.PlayExecute(game, player, cardIndex);
        }

        public void DiscardExecute(Game game, Player player, int cardIndex)
        {
            foreach (var cardAction in cardActionCollection)
                cardAction.DiscardExecute(game, player, cardIndex);
        }
    }
}
