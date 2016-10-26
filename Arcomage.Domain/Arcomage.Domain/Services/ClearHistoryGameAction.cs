using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Services
{
    public class ClearHistoryGameAction : IGameAction
    {
        public void Execute(Game game, int cardIndex)
        {
            game.History.Cards.Clear();
        }
    }
}
