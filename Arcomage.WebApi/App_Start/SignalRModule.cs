using System;
using System.Collections.Generic;
using System.Linq;
using Arcomage.WebApi.Hubs;
using Autofac;
using Autofac.Integration.SignalR;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using SignalR.Extras.Autofac;

namespace Arcomage.WebApi
{
    public class SignalRModule : ApplicationModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterHubs(ThisAssembly);
            builder.RegisterLifetimeHubManager();

            builder.RegisterType<AutofacDependencyResolver>()
                .AsImplementedInterfaces()
                .SingleInstance();
            
            builder.Register(c => c.Resolve<IDependencyResolver>().Resolve<IConnectionManager>()
                    .GetHubContext<ConnectGameHub, IConnectGameClient>())
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.Register(c => c.Resolve<IDependencyResolver>().Resolve<IConnectionManager>()
                    .GetHubContext<PlayGameHub, IPlayGameClient>())
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<ApplicationUserIdProvider>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}