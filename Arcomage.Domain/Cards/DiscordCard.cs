using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Cards
{
    [Serializable]
    public class DiscordCard : GemsCard
    {
        public override int ResourcePrice { get; set; } = 5;

        public override void Activate(Game game)
        {
            game.FirstPlayer.Resources.Magic -= 1;
            game.SecondPlayer.Resources.Magic -= 1;
            game.FirstPlayer.Buildings.Tower -= 7;
            game.SecondPlayer.Buildings.Tower -= 7;
        }
    }
}
