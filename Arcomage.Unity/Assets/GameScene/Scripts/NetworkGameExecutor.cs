using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Hubs;
using Arcomage.WebApi.Client.Models.Game;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class NetworkGameExecutor : GameExecutor
    {
        private readonly NetworkSettings settings;

        private readonly PlayGameHubClient playGameHubClient;

        private readonly NetworkViewModelUpdater viewModelUpdater;

        public NetworkGameExecutor(NetworkSettings settings, PlayGameHubClient playGameHubClient, NetworkViewModelUpdater viewModelUpdater)
        {
            this.settings = settings;
            this.playGameHubClient = playGameHubClient;
            this.viewModelUpdater = viewModelUpdater;
        }

        public override IEnumerator Execute()
        {
            GameModel gameModel = null;
            playGameHubClient.OnUpdate += gm => Interlocked.Exchange(ref gameModel, gm);
            
            var viewModel = viewModelUpdater.Update(settings.GameModel);

            while (string.IsNullOrEmpty(viewModel.FinishedMenu.Identifier))
            {
                var localGameModel = Interlocked.Exchange(ref gameModel, null);
                if (localGameModel != null)
                    viewModelUpdater.Update(localGameModel);

                yield return null;
            }
        }
    }
}
