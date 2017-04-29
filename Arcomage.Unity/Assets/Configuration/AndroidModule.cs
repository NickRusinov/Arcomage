using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Shared.Scripts;
using Autofac;

namespace Arcomage.Unity.Configuration
{
    public class AndroidModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            builder.RegisterType<AndroidAuthorization>()
                .As<Authorization>();

            builder.RegisterType<AndroidLogger>()
                .As<Logger>();
#endif
        }
    }
}
