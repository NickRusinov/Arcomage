using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Cards
{
    [Serializable]
    public class LightningShardCard : GemsCard
    {
        public override int ResourcePrice { get; set; } = 11;

        public override void Activate(Game game)
        {
            if (game.CurrentPlayer.Buildings.Tower > game.AdversaryPlayer.Buildings.Wall)
            {
                game.AdversaryPlayer.Buildings.Tower -= 8;
            }
            else
            {
                game.FirstPlayer.Buildings.Damage(8);
                game.SecondPlayer.Buildings.Damage(8);
            }
        }
    }
}
