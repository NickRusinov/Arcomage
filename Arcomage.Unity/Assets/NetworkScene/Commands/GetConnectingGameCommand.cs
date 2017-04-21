using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Controllers;

namespace Arcomage.Unity.NetworkScene.Commands
{
    public class GetConnectingGameCommand : Command<object, Guid?>
    {
        private readonly ConnectGameControllerClient connectGameControllerClient;

        public GetConnectingGameCommand(ConnectGameControllerClient connectGameControllerClient)
        {
            this.connectGameControllerClient = connectGameControllerClient;
        }

        public override Task<Guid?> Execute(object state)
        {
            return connectGameControllerClient.GetConnecting();
        }
    }
}
