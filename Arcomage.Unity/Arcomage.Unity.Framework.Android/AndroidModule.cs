using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace Arcomage.Unity.Framework.Android
{
    public class AndroidModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AndroidAuthorization>()
                .As<Authorization>();

            builder.RegisterType<AndroidLogger>()
                .As<Logger>();
        }
    }
}
