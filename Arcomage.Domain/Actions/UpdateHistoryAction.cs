using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    public class UpdateHistoryAction : UniformCardAction
    {
        protected override void Execute(Game game, Player player, int cardIndex)
        {
            game.History.Cards.Add(player.Hand.Cards[cardIndex]);
        }
    }
}
