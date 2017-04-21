using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Hubs;

namespace Arcomage.Unity.NetworkScene.Commands
{
    public class ConnectGameCommand : Command<object>
    {
        private readonly ConnectGameHubClient connectGameHubClient;

        private readonly NetworkSettings settings;

        public ConnectGameCommand(ConnectGameHubClient connectGameHubClient, NetworkSettings settings)
        {
            this.connectGameHubClient = connectGameHubClient;
            this.settings = settings;
        }
        
        public override Task Execute(object state)
        {
            var taskCompletionSource = new TaskCompletionSource<Guid>();
            connectGameHubClient.OnConnected += id => taskCompletionSource.TrySetResult(id);

            return connectGameHubClient.Connect()
                .ContinueWith(t => taskCompletionSource.Task, TaskContinuationOptions.ExecuteSynchronously).Unwrap()
                .ContinueWith(t => settings.GameId = t.Result, TaskContinuationOptions.ExecuteSynchronously);
        }
    }
}
