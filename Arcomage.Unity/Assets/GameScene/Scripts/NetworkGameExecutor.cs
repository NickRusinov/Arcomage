using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Controllers;
using Arcomage.WebApi.Client.Hubs;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class NetworkGameExecutor : GameExecutor
    {
        private readonly UnityDispatcher dispatcher;

        private readonly PlayGameHubClient playGameHubClient;

        private readonly GetGameControllerClient getGameControllerClient;

        private readonly NetworkViewModelUpdater viewModelUpdater;

        public NetworkGameExecutor(UnityDispatcher dispatcher, PlayGameHubClient playGameHubClient, GetGameControllerClient getGameControllerClient, NetworkViewModelUpdater viewModelUpdater)
        {
            this.dispatcher = dispatcher;
            this.playGameHubClient = playGameHubClient;
            this.getGameControllerClient = getGameControllerClient;
            this.viewModelUpdater = viewModelUpdater;
        }

        public override IEnumerator Execute()
        {
            var getGameTask = getGameControllerClient.GetGame();

            playGameHubClient.OnUpdate += dispatcher.Invoke(() =>
                Interlocked.Exchange(ref getGameTask, getGameControllerClient.GetGame()));

            yield return new TaskYieldInstruction(getGameTask);
            var viewModel = viewModelUpdater.Update(getGameTask.Result);

            while (string.IsNullOrEmpty(viewModel.FinishedMenu.Identifier))
            {
                var localGetGameTask = Interlocked.Exchange(ref getGameTask, null);
                if (localGetGameTask != null)
                {
                    yield return new TaskYieldInstruction(localGetGameTask);
                    viewModelUpdater.Update(localGetGameTask.Result);
                }

                yield return null;
            }
        }
    }
}
