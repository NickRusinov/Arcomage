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
    public class BagOfBaublesCard : GemsCard
    {
        public override int ResourcePrice { get; set; } = 0;

        public override void Activate(Game game)
        {
            if (game.CurrentPlayer.Buildings.Tower < game.AdversaryPlayer.Buildings.Tower)
                game.CurrentPlayer.Buildings.Tower += 2;
            else
                game.CurrentPlayer.Buildings.Tower += 1;
        }
    }
}
