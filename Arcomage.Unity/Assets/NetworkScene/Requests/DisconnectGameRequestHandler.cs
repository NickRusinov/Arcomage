using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.WebApi.Client.Controllers;
using MediatR;

namespace Arcomage.Unity.NetworkScene.Requests
{
    public class DisconnectGameRequestHandler : IAsyncRequestHandler<DisconnectGameRequest>
    {
        private readonly ConnectGameControllerClient connectGameControllerClient;

        public DisconnectGameRequestHandler(ConnectGameControllerClient connectGameControllerClient)
        {
            this.connectGameControllerClient = connectGameControllerClient;
        }

        public Task Handle(DisconnectGameRequest message)
        {
            return connectGameControllerClient.Disconnect();
        }
    }
}
