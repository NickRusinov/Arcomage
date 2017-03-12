using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Integration.WebApi;

namespace Arcomage.WebApi
{
    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(ThisAssembly);
        }
    }
}