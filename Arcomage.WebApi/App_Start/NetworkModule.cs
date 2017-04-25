using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Arcomage.Domain;
using Arcomage.Network;
using Arcomage.Network.Jobs;
using Arcomage.Network.Queries;
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
            builder.RegisterType<ConcurrentDictionary<Guid, GameContext>>()
                .UsingConstructor()
                .SingleInstance();

            builder.RegisterType<ConcurrentDictionary<Guid, UserContext>>()
                .UsingConstructor()
                .SingleInstance();

            builder.RegisterType<ConcurrentDictionary<Guid, Game>>()
                .UsingConstructor()
                .SingleInstance();

            builder.RegisterAssemblyTypes(typeof(GameContext).Assembly)
                .InNamespaceOf<IPlayGameService>()
                .Except<CreateGameService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(GameContext).Assembly)
                .InNamespaceOf<IGameRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(GameContext).Assembly)
                .InNamespaceOf<IGetPlayingGameQuery>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<CreateGameService>()
                .Named<ICreateGameService>("CreateGameService")
                .InstancePerDependency();

            builder.RegisterDecorator<ICreateGameService>((c, s) =>
                new SignalRCreateGameService(s,
                    c.Resolve<IHubContext<IConnectGameClient>>()),
                fromKey: "CreateGameService", toKey: null);

            builder.RegisterType<DefaultPlayGamePublisher>()
                .Named<IPlayGamePublisher>("DefaultPlayGamePublisher")
                .InstancePerDependency();

            builder.RegisterDecorator<IPlayGamePublisher>((c, s) =>
                new SignalRPlayGamePublisher(s,
                    c.Resolve<IHubContext<IPlayGameClient>>()),
                fromKey: "DefaultPlayGamePublisher", toKey: "SignalRPlayGamePublisher");

            builder.RegisterDecorator<IPlayGamePublisher>((c, s) =>
                new GameStatePlayGamePublisher(s,
                    c.Resolve<IGameContextRepository>(),
                    c.Resolve<IUserContextRepository>()),
                fromKey: "SignalRPlayGamePublisher", toKey: null);
        }
    }
}