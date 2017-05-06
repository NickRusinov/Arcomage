using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Arcomage.Unity.Framework;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Controllers;
using Arcomage.WebApi.Client.Hubs;
using Arcomage.WebApi.Client.Models.Game;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class NetworkGameExecutor : GameExecutor
    {
        private readonly NetworkSettings settings;

        private readonly PlayGameHubClient playGameHubClient;

        private readonly GetGameControllerClient getGameControllerClient;

        private readonly NetworkViewModelUpdater viewModelUpdater;

        public NetworkGameExecutor(NetworkSettings settings, PlayGameHubClient playGameHubClient, GetGameControllerClient getGameControllerClient, NetworkViewModelUpdater viewModelUpdater)
        {
            this.settings = settings;
            this.playGameHubClient = playGameHubClient;
            this.getGameControllerClient = getGameControllerClient;
            this.viewModelUpdater = viewModelUpdater;
        }

        public override IEnumerator Execute()
        {
            GameModel gameModel = null;
            playGameHubClient.OnUpdate += gm => Interlocked.Exchange(ref gameModel, gm);

            var getGameTask = getGameControllerClient.GetGame(settings.GameId);

            yield return new TaskYieldInstruction(getGameTask);
            var viewModel = viewModelUpdater.Update(getGameTask.Result);

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
