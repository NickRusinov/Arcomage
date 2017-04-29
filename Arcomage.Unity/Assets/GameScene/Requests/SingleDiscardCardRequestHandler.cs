using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Players;
using MediatR;

namespace Arcomage.Unity.GameScene.Requests
{
    public class SingleDiscardCardRequestHandler : IAsyncRequestHandler<DiscardCardRequest>
    {
        private readonly HumanPlayer player;

        public SingleDiscardCardRequestHandler(HumanPlayer player)
        {
            this.player = player;
        }

        public Task Handle(DiscardCardRequest message)
        {
            player.SetPlayResult(new PlayResult(message.Index, false));

            return TaskEx.FromResult<object>(null);
        }
    }
}