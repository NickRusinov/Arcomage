using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Arcomage.Domain;
using Arcomage.Network;
using Autofac;

namespace Arcomage.WebApi
{
    public class NetworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConcurrentDictionary<Guid, Game>>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<ConcurrentDictionary<Guid, GameContext>>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<ConcurrentDictionary<Guid, UserContext>>()
                .AsSelf()
#warning Hardcode user
                .OnActivating(ea => ea.Instance.TryAdd(Guid.Parse("EB3AB862-E0D0-413B-B732-6BDD86B3A1A2"), new UserContext { Id = Guid.Parse("EB3AB862-E0D0-413B-B732-6BDD86B3A1A2") }))
#warning Hardcode user
                .OnActivating(ea => ea.Instance.TryAdd(Guid.Parse("EB3AB862-E0D0-413B-B732-6BDD86B3A1A3"), new UserContext { Id = Guid.Parse("EB3AB862-E0D0-413B-B732-6BDD86B3A1A3") }))
                .SingleInstance();

            builder.RegisterAssemblyTypes(typeof(GameContext).Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}