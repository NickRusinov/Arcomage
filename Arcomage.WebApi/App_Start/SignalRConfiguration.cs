using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.AspNet.SignalR;
using NLog;
using Owin;

namespace Arcomage.WebApi
{
    public class SignalRConfiguration
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void Configure(IAppBuilder app, IContainer container)
        {
            logger.Info("Конфигурация SignalR");

            var hubConfiguration = new HubConfiguration();
            hubConfiguration.Resolver = container.Resolve<IDependencyResolver>();

            app.MapSignalR(hubConfiguration);
        }
    }
}