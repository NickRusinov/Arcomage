using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.GameScene.ViewModels;
using Autofac;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class GameSceneModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GameViewModel>()
                .InstancePerLifetimeScope();
        }
    }
}
