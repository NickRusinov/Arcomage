using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Arcomage.WebApi.Client.Hubs;
using Arcomage.WebApi.Client.Models.Game;
using MediatR;

namespace Arcomage.Unity.GameScene.Requests
{
    public class NetworkDiscardCardRequestHandler : IAsyncRequestHandler<DiscardCardRequest>
    {
        private readonly PlayGameHubClient playGameHubClient;

        public NetworkDiscardCardRequestHandler(PlayGameHubClient playGameHubClient)
        {
            this.playGameHubClient = playGameHubClient;
        }

        public Task Handle(DiscardCardRequest message)
        {
            var cancellationTokenSource = new CancellationTokenSource();

            Action<GameModel> playGameHubOnUpdate = gm => cancellationTokenSource.Cancel();
            playGameHubClient.OnUpdate += playGameHubOnUpdate;

            return playGameHubClient.DiscardCard(message.Index)
                .ContinueWith(t => TaskEx.Delay(5000, cancellationTokenSource.Token),
                    TaskContinuationOptions.ExecuteSynchronously).Unwrap()
                .ContinueWith(t => playGameHubClient.OnUpdate -= playGameHubOnUpdate,
                    TaskContinuationOptions.ExecuteSynchronously);
        }
    }
}
