using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using static Arcomage.Domain.Entities.PlayerMode;

namespace Arcomage.Domain.Internal
{
    internal static class GameExtensions
    {
        public static Player GetPlayer(this Game game, PlayerMode playerMode)
        {
            if (playerMode == FirstPlayer)
                return game.FirstPlayer;

            return game.SecondPlayer;
        }

        public static Player GetCurrentPlayer(this Game game)
        {
            return game.GetPlayer(game.PlayerMode);
        }

        public static Player GetAdversaryPlayer(this Game game)
        {
            return game.GetPlayer(game.PlayerMode.GetAdversary());
        }
    }
}
