using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Domain.Players;
using Arcomage.Domain.Services;
using Arcomage.Unity.Shared.Scripts;
using Zenject;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class SceneInstaller : Installer<SceneInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<Command>()
                .WithId("PlayCardCommand")
                .FromMethod(c => new PlayCardCommand(
                    c.Container.Resolve<Game>(),
                    (HumanPlayer)c.Container.Resolve<Player>("FirstPlayer"),
                    c.Container.Resolve<IPlayCardCriteria>()))
                .AsSingle(0);

            Container.Bind<Command>()
                .WithId("DiscardCardCommand")
                .FromMethod(c => new DiscardCardCommand(
                    c.Container.Resolve<Game>(),
                    (HumanPlayer)c.Container.Resolve<Player>("FirstPlayer"),
                    c.Container.Resolve<IDiscardCardCriteria>()))
                .AsSingle(1);
        }
    }
}
