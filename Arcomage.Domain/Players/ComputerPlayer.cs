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

        public ComputerPlayer(IArtificialIntelligence artificialIntelligence, Buildings buildings, Resources resources, Hand hand)
            : base(buildings, resources, hand)
        {
            this.artificialIntelligence = artificialIntelligence;
        }

        public override Task<PlayResult> Play(Game game)
        {
            return artificialIntelligence.Execute(game, this);
        }
    }
}
