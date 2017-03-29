using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Hubs;

namespace Arcomage.Unity.NetworkScene.Commands
{
    public class DisconnectGameCommand : Command<object>
    {
        private readonly NetworkGameHubClient networkGameHubClient;

        public DisconnectGameCommand(NetworkGameHubClient networkGameHubClient)
        {
            this.networkGameHubClient = networkGameHubClient;
        }

        public override Task Execute(object state)
        {
            networkGameHubClient.Stop();

            return base.Execute(state);
        }
    }
}
