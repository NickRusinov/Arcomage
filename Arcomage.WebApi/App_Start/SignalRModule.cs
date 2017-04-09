using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Arcomage.WebApi.Hubs;
using Autofac;
using Autofac.Integration.SignalR;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace Arcomage.WebApi
{
    public class SignalRModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterHubs(ThisAssembly);

            builder.Register(c => GlobalHost.ConnectionManager)
                .AsImplementedInterfaces();

            builder.Register(c => GlobalHost.Configuration)
                .AsImplementedInterfaces();

            builder.Register(c => GlobalHost.DependencyResolver)
                .AsImplementedInterfaces();

            builder.Register(c => GlobalHost.HubPipeline)
                .AsImplementedInterfaces();

            builder.Register(c => GlobalHost.TraceManager)
                .AsImplementedInterfaces();
            
            builder.Register(c => c.Resolve<IConnectionManager>().GetHubContext<ConnectGameHub, IConnectGameClient>())
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<ApplicationUserIdProvider>()
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}