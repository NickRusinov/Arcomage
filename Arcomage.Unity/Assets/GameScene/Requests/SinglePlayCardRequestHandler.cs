using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Players;
using MediatR;

namespace Arcomage.Unity.GameScene.Requests
{
    public class SinglePlayCardRequestHandler : IAsyncRequestHandler<PlayCardRequest>
    {
        private readonly HumanPlayer player;

        public SinglePlayCardRequestHandler(HumanPlayer player)
        {
            this.player = player;
        }

        public Task Handle(PlayCardRequest message)
        {
            player.SetPlayResult(new PlayResult(message.Index, true));

            return TaskEx.FromResult<object>(null);
        }
    }
}