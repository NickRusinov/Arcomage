using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.WebApi.Client.Controllers;
using MediatR;

namespace Arcomage.Unity.NetworkScene.Requests
{
    public class GetConnectingGameRequestHandler : IAsyncRequestHandler<GetConnectingGameRequest, Guid?>
    {
        private readonly ConnectGameControllerClient connectGameControllerClient;

        public GetConnectingGameRequestHandler(ConnectGameControllerClient connectGameControllerClient)
        {
            this.connectGameControllerClient = connectGameControllerClient;
        }

        public Task<Guid?> Handle(GetConnectingGameRequest message)
        {
            return connectGameControllerClient.GetConnecting();
        }
    }
}
