using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.GameScene.Requests;
using Arcomage.Unity.GameScene.Scripts;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using Autofac;
using MediatR;

namespace Arcomage.Unity.Configuration
{
    public class GameSceneModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GameViewModel>()
                .PropertiesAutowired()
                .InstancePerLifetimeScope();

            builder.Register(c => c.Resolve<Settings>().IsNetwork ?
                (GameExecutor)c.Resolve<NetworkGameExecutor>() : 
                c.Resolve<SingleGameExecutor>());

            builder.Register(c => c.Resolve<Settings>().IsNetwork ?
                (IAsyncRequestHandler<PlayCardRequest>)c.Resolve<NetworkPlayCardRequestHandler>() :
                c.Resolve<SinglePlayCardRequestHandler>());

            builder.Register(c => c.Resolve<Settings>().IsNetwork ?
                (IAsyncRequestHandler<DiscardCardRequest>)c.Resolve<NetworkDiscardCardRequestHandler>() :
                c.Resolve<SingleDiscardCardRequestHandler>());
        }
    }
}
