using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Internal
{
    internal static class GameExtensions
    {
        public static Player GetCurrentPlayer(this Game game)
        {
            if (game.PlayerMode == PlayerMode.FirstPlayer)
                return game.FirstPlayer;

            return game.SecondPlayer;
        }

        public static Player GetAdversaryPlayer(this Game game)
        {
            if (game.PlayerMode == PlayerMode.SecondPlayer)
                return game.FirstPlayer;

            return game.SecondPlayer;
        }
    }
}
