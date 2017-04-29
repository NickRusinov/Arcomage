using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.WebApi.Client.Controllers;
using Arcomage.WebApi.Client.Hubs;
using Autofac;

namespace Arcomage.Unity.Configuration
{
    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(ApplicationControllerClient).Assembly)
                .AssignableTo<ApplicationControllerClient>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ApplicationHubClient).Assembly)
                .AssignableTo<ApplicationHubClient>()
                .InstancePerLifetimeScope();
        }
    }
}
