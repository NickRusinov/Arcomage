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
            var oldBricks = game.AdversaryPlayer.Resources.Bricks;
            var oldGems = game.AdversaryPlayer.Resources.Gems;

            game.AdversaryPlayer.Resources.Bricks -= 5;
            game.AdversaryPlayer.Resources.Gems -= 10;
            game.CurrentPlayer.Resources.Bricks += Min(5, oldBricks) / 2;
            game.CurrentPlayer.Resources.Gems += Min(10, oldGems) / 2;
        }
    }
}
