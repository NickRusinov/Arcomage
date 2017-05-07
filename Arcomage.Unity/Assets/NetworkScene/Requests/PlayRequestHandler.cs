using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Controllers;
using MediatR;

namespace Arcomage.Unity.NetworkScene.Requests
{
    public class PlayRequestHandler : IAsyncRequestHandler<PlayRequest>
    {
        private readonly NetworkSettings networkSettings;

        private readonly GetGameControllerClient getGameControllerClient;

        public PlayRequestHandler(NetworkSettings networkSettings, GetGameControllerClient getGameControllerClient)
        {
            this.networkSettings = networkSettings;
            this.getGameControllerClient = getGameControllerClient;
        }

        public Task Handle(PlayRequest message)
        {
            return getGameControllerClient.GetGame(networkSettings.GameId)
                .ContinueWith(t => networkSettings.GameModel = t.Result, TaskContinuationOptions.ExecuteSynchronously);
        }
    }
}
