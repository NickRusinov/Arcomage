using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;
using static System.Math;

namespace Arcomage.Domain.Cards
{
    public class ThiefCard : RecruitsCard
    {
        public override int ResourcePrice { get; set; } = 12;

        public override void Activate(Game game)
        {
            var oldBricks = game.GetAdversaryPlayer().Resources.Bricks;
            var oldGems = game.GetAdversaryPlayer().Resources.Gems;

            game.GetAdversaryPlayer().Resources.Bricks -= 5;
            game.GetAdversaryPlayer().Resources.Gems -= 10;
            game.GetCurrentPlayer().Resources.Bricks += Min(5, oldBricks) / 2;
            game.GetCurrentPlayer().Resources.Gems += Min(10, oldGems) / 2;
        }
    }
}
