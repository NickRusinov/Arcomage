using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;
using Arcomage.Domain.Services;

namespace Arcomage.Domain.ArtificialIntelligence
{
    public class FakeArtificialIntelligence : IArtificialIntelligence
    {
        private readonly IGameAction playCardGameAction;

        private readonly IGameAction discardCardGameAction;

        public FakeArtificialIntelligence(IGameAction playCardGameAction, IGameAction discardCardGameAction)
        {
            this.playCardGameAction = playCardGameAction;
            this.discardCardGameAction = discardCardGameAction;
        }

        public void Execute(Game game)
        {
            var player = game.GetCurrentPlayer();

            Task.Delay(1000).Wait();

            if (player.Hand.Cards[0].IsEnoughResources(player.Resources))
                playCardGameAction.Execute(game, 0);
            else
                discardCardGameAction.Execute(game, 0);
        }
    }
}
