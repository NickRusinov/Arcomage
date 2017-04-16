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
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(GameContext).Assembly)
                .InNamespaceOf<IGameRepository>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<ConnectGameService>()
                .Named<IConnectGameService>("connectGameService")
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterDecorator<IConnectGameService>((c, s) =>
                new SignalRConnectGameService(s,
                    c.Resolve<IHubContext<IConnectGameClient>>()),
                fromKey: "connectGameService");

            builder.RegisterType<DefaultPlayGamePublisher>()
                .Named<IPlayGamePublisher>("defaultPlayGamePublisher")
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterDecorator<IPlayGamePublisher>((c, s) =>
                new SignalRPlayGamePublisher(s,
                    c.Resolve<IHubContext<IPlayGameClient>>()),
                fromKey: "defaultPlayGamePublisher");
        }
    }
}