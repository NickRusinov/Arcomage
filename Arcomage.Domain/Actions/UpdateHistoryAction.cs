using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    public class UpdateHistoryAction : ICardAction
    {
        public void PlayExecute(Game game, Player player, int cardIndex)
        {
            game.History.Cards.Add(new HistoryCard(player.Hand.Cards[cardIndex], true));
        }

        public void DiscardExecute(Game game, Player player, int cardIndex)
        {
            game.History.Cards.Add(new HistoryCard(player.Hand.Cards[cardIndex], false));
        }
    }
}
