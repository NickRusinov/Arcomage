using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    public class ClearHistoryAction : IPlayAction
    {
        public void Execute(Game game, Player player)
        {
            game.History.Cards.Clear();
        }
    }
}
