using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;
using Arcomage.Domain.Services;

namespace Arcomage.Domain.ArtificialIntelligence
{
    [Serializable]
    public class FakeArtificialIntelligence : IArtificialIntelligence
    {
        private readonly IPlayCardCriteria playCardCriteria;

        public FakeArtificialIntelligence(IPlayCardCriteria playCardCriteria)
        {
            this.playCardCriteria = playCardCriteria;
        }

        public Task<PlayResult> Execute(Game game, Player player)
        {
            return FrameworkExtensions.Delay(1000)
                .ContinueWith(t =>
                {
                    if (playCardCriteria.CanPlayCard(game, player, 0))
                        return new PlayResult(0, true);

                    return new PlayResult(0, false);
                });
        }
    }
}
