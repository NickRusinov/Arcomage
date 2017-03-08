using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.WebApi.Client.Controllers;
using Arcomage.WebApi.Client.Hubs;
using Zenject;

namespace Arcomage.Unity.NetworkScene
{
    public class NetworkSceneInstaller : Installer<NetworkSceneInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<AboutClient>()
                .ToSelf()
                .AsSingle(0);

            Container.Bind<NetworkGameClient>()
                .ToSelf()
                .AsSingle(0);
        }
    }
}
