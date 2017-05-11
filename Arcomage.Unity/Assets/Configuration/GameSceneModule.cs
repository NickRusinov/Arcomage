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

            builder.RegisterType<SingleGameExecutor>()
                .Named<GameExecutor>("SingleGameExecutor");

            builder.RegisterType<NetworkGameExecutor>()
                .Named<GameExecutor>("NetworkGameExecutor");

            builder.RegisterType<SinglePlayCardRequestHandler>()
                .Named<IAsyncRequestHandler<PlayCardRequest>>("SinglePlayCardRequestHandler");

            builder.RegisterType<NetworkPlayCardRequestHandler>()
                .Named<IAsyncRequestHandler<PlayCardRequest>>("NetworkPlayCardRequestHandler");

            builder.RegisterType<SingleDiscardCardRequestHandler>()
                .Named<IAsyncRequestHandler<DiscardCardRequest>>("SingleDiscardCardRequestHandler");

            builder.RegisterType<NetworkDiscardCardRequestHandler>()
                .Named<IAsyncRequestHandler<DiscardCardRequest>>("NetworkDiscardCardRequestHandler");

            builder.Register(c => c.ResolveNamed<GameExecutor>(
                c.Resolve<Settings>().IsNetwork ? "NetworkGameExecutor" : "SingleGameExecutor"));

            builder.Register(c => c.ResolveNamed<IAsyncRequestHandler<PlayCardRequest>>(
                c.Resolve<Settings>().IsNetwork ? "NetworkPlayCardRequestHandler" : "SinglePlayCardRequestHandler"));

            builder.Register(c => c.ResolveNamed<IAsyncRequestHandler<DiscardCardRequest>>(
                c.Resolve<Settings>().IsNetwork ? "NetworkDiscardCardRequestHandler" : "SingleDiscardCardRequestHandler"));
        }
    }
}
