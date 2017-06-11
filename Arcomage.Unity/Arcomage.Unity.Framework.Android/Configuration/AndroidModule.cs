using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Framework.Android.Services;
using Arcomage.Unity.Framework.Services;
using Autofac;

namespace Arcomage.Unity.Framework.Android.Configuration
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
