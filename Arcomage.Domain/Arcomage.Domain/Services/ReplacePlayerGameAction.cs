using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Services
{
    public class ReplacePlayerGameAction : IGameAction
    {
        private readonly Game game;

        public ReplacePlayerGameAction(Game game)
        {
            this.game = game;
        }

        public void Execute(int cardIndex)
        {
            if (game.PlayAgainTurns == 0)
                game.PlayerMode = game.PlayerMode.GetAdversary();

            game.PlayAgainTurns--;
        }
    }
}
