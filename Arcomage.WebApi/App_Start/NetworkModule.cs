using System;
using System.Collections.Generic;
using System.Linq;
using Arcomage.Network;
using Arcomage.Network.Jobs;
using Arcomage.Network.Repositories;
using Arcomage.Network.Services;
using Arcomage.WebApi.Hubs;
using Arcomage.WebApi.Network;
using Autofac;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi
{
    public class NetworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(GameContext).Assembly)
                .InNamespaceOf<IPlayGameService>()
                .Except<ConnectGameService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(GameContext).Assembly)
                .InNamespaceOf<IGameRepository>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<ConnectGameService>()
                .Named<IConnectGameService>("ConnectGameService")
                .InstancePerDependency();

            builder.RegisterDecorator<IConnectGameService>((c, s) =>
                new SignalRConnectGameService(s,
                    c.Resolve<IHubContext<IConnectGameClient>>()),
                fromKey: "ConnectGameService", toKey: null);

            builder.RegisterType<DefaultPlayGamePublisher>()
                .Named<IPlayGamePublisher>("DefaultPlayGamePublisher")
                .InstancePerDependency();

            builder.RegisterDecorator<IPlayGamePublisher>((c, s) =>
                new GameStatePlayGamePublisher(s,
                    c.Resolve<IGameContextRepository>()),
                fromKey: "DefaultPlayGamePublisher", toKey: "GameStatePlayGamePublisher");

            builder.RegisterDecorator<IPlayGamePublisher>((c, s) =>
                new SignalRPlayGamePublisher(s,
                    c.Resolve<IHubContext<IPlayGameClient>>()),
                fromKey: "GameStatePlayGamePublisher", toKey: null);
        }
    }
}