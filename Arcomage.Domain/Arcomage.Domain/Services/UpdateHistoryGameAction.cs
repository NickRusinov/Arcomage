using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Services
{
    public class UpdateHistoryGameAction : IGameAction
    {
        public void Execute(Game game, int cardIndex)
        {
            var player = game.GetCurrentPlayer();

            game.History.Cards.Add(player.Hand.Cards[cardIndex]);
        }
    }
}
