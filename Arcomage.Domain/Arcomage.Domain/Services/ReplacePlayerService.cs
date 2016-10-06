using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Services
{
    public class ReplacePlayerService : IReplacePlayerService
    {
        private readonly Game game;

        public ReplacePlayerService(Game game)
        {
            this.game = game;
        }

        public void ReplacePlayer()
        {
            if (game.PlayAgainTurns == 0)
                game.PlayerMode = game.PlayerMode.GetAdversary();

            game.PlayAgainTurns--;
        }
    }
}
