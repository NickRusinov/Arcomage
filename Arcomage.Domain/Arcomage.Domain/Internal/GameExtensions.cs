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
        public static Player GetPlayer(this Game game, PlayerMode playerMode)
        {
            if (game.PlayerMode == playerMode)
                return game.FirstPlayer;

            return game.SecondPlayer;
        }

        public static Player GetCurrentPlayer(this Game game)
        {
            return game.GetPlayer(PlayerMode.FirstPlayer);
        }

        public static Player GetAdversaryPlayer(this Game game)
        {
            return game.GetPlayer(PlayerMode.SecondPlayer);
        }
    }
}
