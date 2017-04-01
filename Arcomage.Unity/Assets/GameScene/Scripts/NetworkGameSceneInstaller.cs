using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.GameScene.Commands;
using Arcomage.Unity.GameScene.ViewModels;
using Zenject;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class NetworkGameSceneInstaller : Installer<NetworkGameSceneInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<NetworkViewModelUpdater>()
                .ToSelf()
                .AsSingle(0);

            Container.Bind<NetworkPlayCardCommand>()
                .ToSelf()
                .AsSingle(0);

            Container.Bind<NetworkDiscardCardCommand>()
                .ToSelf()
                .AsSingle(0);
        }
    }
}
