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
        private readonly ICollection<ICardAction> cardActionCollection;

        public CompositeCardAction(ICollection<ICardAction> cardActionCollection)
        {
            this.cardActionCollection = cardActionCollection;
        }

        public CompositeCardAction(params ICardAction[] cardActionCollection)
            : this(cardActionCollection as ICollection<ICardAction>)
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
