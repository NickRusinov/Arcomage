using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.ArtificialIntelligence
{
    public class FakeArtificialIntelligence : IArtificialIntelligence
    {
        public Task<PlayResult> Execute(Game game, Player player)
        {
            return Internal.TaskExtensions.Delay(1000)
                .ContinueWith(t =>
                {
                    if (player.Hand.Cards[0].IsEnoughResources(player.Resources))
                        return new PlayResult(0, true);

                    return new PlayResult(0, false);
                });
        }
    }
}
