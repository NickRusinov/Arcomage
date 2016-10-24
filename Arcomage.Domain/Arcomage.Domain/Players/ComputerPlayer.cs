using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.ArtificialIntelligence;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Players
{
    public class ComputerPlayer : Player
    {
        private readonly IArtificialIntelligence artificialIntelligence;

        public ComputerPlayer(IArtificialIntelligence artificialIntelligence)
        {
            this.artificialIntelligence = artificialIntelligence;
        }

        public override void Play(Game game)
        {
            artificialIntelligence.Execute(game);
        }
    }
}
