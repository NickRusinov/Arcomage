using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.NetworkScene.Commands;
using Arcomage.Unity.NetworkScene.ViewModels;
using Arcomage.WebApi.Client.Controllers;
using Arcomage.WebApi.Client.Hubs;
using Zenject;

namespace Arcomage.Unity.NetworkScene
{
    public class NetworkSceneInstaller : Installer<NetworkSceneInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<AboutControllerClient>()
                .ToSelf()
                .AsSingle(0);

            Container.Bind<NetworkGameHubClient>()
                .ToSelf()
                .AsSingle(0);

            Container.Bind<PlayGameHubClient>()
                .ToSelf()
                .AsSingle(0);

            Container.Bind<GetVersionCommand>()
                .ToSelf()
                .AsSingle(0);

            Container.Bind<ConnectGameCommand>()
                .ToSelf()
                .AsSingle(0);

            Container.Bind<DisconnectGameCommand>()
                .ToSelf()
                .AsSingle(0);

            Container.Bind<ConnectViewModel>()
                .FromMethod(c => new ConnectViewModel
                {
                    GetVersionCommand = c.Container.Resolve<GetVersionCommand>(),
                })
                .AsSingle(0);

            Container.Bind<PrepareViewModel>()
                .FromMethod(c => new PrepareViewModel
                {
                    ConnectCommand = c.Container.Resolve<ConnectGameCommand>(),
                    DisconnectCommand = c.Container.Resolve<DisconnectGameCommand>(),
                })
                .AsSingle(0);
        }
    }
}
