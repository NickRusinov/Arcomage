using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Arcomage.Network;
using Arcomage.Network.Handlers;
using Arcomage.Network.Repositories;
using Arcomage.WebApi.Handlers;
using Autofac;

namespace Arcomage.WebApi
{
    public class NetworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConcurrentDictionary<Guid, GameContext>>()
                .UsingConstructor()
                .SingleInstance();

            builder.RegisterType<ConcurrentDictionary<Guid, User>>()
                .UsingConstructor()
                .SingleInstance();

            builder.RegisterAssemblyTypes(typeof(GameContext).Assembly)
                .InNamespaceOf<MemoryGameContextRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(GameContext).Assembly)
                .InNamespaceOf<PlayGameRequestHandler>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .InNamespaceOf<SignalRStartGameNotificationHandler>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}