using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Controllers;
using Arcomage.WebApi.Client.Models.About;

namespace Arcomage.Unity.NetworkScene.Commands
{
    public class GetVersionCommand : Command<object, VersionModel>
    {
        private readonly AboutControllerClient aboutControllerClient;

        public GetVersionCommand(AboutControllerClient aboutControllerClient)
        {
            this.aboutControllerClient = aboutControllerClient;
        }

        public override Task<VersionModel> Execute(object state)
        {
            return aboutControllerClient.GetVersion();
        }
    }
}
