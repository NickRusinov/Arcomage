using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.WebApi.Client.Controllers;
using Arcomage.WebApi.Client.Models.About;
using MediatR;

namespace Arcomage.Unity.NetworkScene.Requests
{
    public class GetVersionRequestHandler : IAsyncRequestHandler<GetVersionRequest, VersionModel>
    {
        private readonly AboutControllerClient aboutControllerClient;

        public GetVersionRequestHandler(AboutControllerClient aboutControllerClient)
        {
            this.aboutControllerClient = aboutControllerClient;
        }

        public Task<VersionModel> Handle(GetVersionRequest message)
        {
            return aboutControllerClient.GetVersion();
        }
    }
}
