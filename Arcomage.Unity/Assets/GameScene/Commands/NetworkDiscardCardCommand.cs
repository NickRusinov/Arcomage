using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Hubs;
using Arcomage.WebApi.Client.Models.Game;

namespace Arcomage.Unity.GameScene.Commands
{
    public class NetworkDiscardCardCommand : Command<CardViewModel>
    {
        private readonly PlayGameHubClient playGameHubClient;

        public NetworkDiscardCardCommand(PlayGameHubClient playGameHubClient)
        {
            this.playGameHubClient = playGameHubClient;
        }

        public override Task Execute(CardViewModel state)
        {
            var cancellationTokenSource = new CancellationTokenSource();

            Action<GameModel> playGameHubOnUpdate = gm => cancellationTokenSource.Cancel();
            playGameHubClient.OnUpdate += playGameHubOnUpdate;

            return playGameHubClient.DiscardCard(state.Index)
                .ContinueWith(t => TaskEx.Delay(5000, cancellationTokenSource.Token),
                    TaskContinuationOptions.ExecuteSynchronously).Unwrap()
                .ContinueWith(t => playGameHubClient.OnUpdate -= playGameHubOnUpdate,
                    TaskContinuationOptions.ExecuteSynchronously);
        }
    }
}
