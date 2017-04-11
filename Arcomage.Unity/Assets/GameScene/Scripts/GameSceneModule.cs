using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using Autofac;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class GameSceneModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GameViewModel>()
                .InstancePerLifetimeScope();

            builder.Register(c => c.Resolve<Settings>().IsNetwork ?
                c.Resolve<NetworkGameExecutor>() as GameExecutor : 
                c.Resolve<SingleGameExecutor>() as GameExecutor);
        }
    }
}
