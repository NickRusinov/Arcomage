using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Hubs;
using MediatR;

namespace Arcomage.Unity.NetworkScene.Requests
{
    public class ConnectGameRequestHandler : IAsyncRequestHandler<ConnectGameRequest>
    {
        private readonly ConnectGameHubClient connectGameHubClient;

        private readonly NetworkSettings settings;

        public ConnectGameRequestHandler(ConnectGameHubClient connectGameHubClient, NetworkSettings settings)
        {
            this.connectGameHubClient = connectGameHubClient;
            this.settings = settings;
        }

        public Task Handle(ConnectGameRequest message)
        {
            var taskCompletionSource = new TaskCompletionSource<Guid>();
            connectGameHubClient.OnConnected += id => taskCompletionSource.TrySetResult(id);

            return connectGameHubClient.Connect()
                .ContinueWith(t => taskCompletionSource.Task, 
                    TaskContinuationOptions.ExecuteSynchronously).Unwrap()
                .ContinueWith(t => settings.GameId = t.Result, 
                    TaskContinuationOptions.ExecuteSynchronously);
        }
    }
}
