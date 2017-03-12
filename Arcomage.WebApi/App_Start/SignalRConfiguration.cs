using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Integration.SignalR;
using Microsoft.AspNet.SignalR;
using Owin;

namespace Arcomage.WebApi
{
    public class SignalRConfiguration
    {
        public void Configure(IAppBuilder app, IContainer container)
        {
            var hubConfiguration = new HubConfiguration();
            hubConfiguration.Resolver = new AutofacDependencyResolver(container);

            app.MapSignalR(hubConfiguration);
        }
    }
}