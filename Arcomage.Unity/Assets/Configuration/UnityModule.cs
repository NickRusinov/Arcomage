using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Shared.Scripts;
using Autofac;

namespace Arcomage.Unity.Configuration
{
    public class UnityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
#if UNITY_EDITOR
            builder.RegisterType<UnityAuthorization>()
                .As<Authorization>();

            builder.RegisterType<UnityLogger>()
                .As<Logger>();
#endif
        }
    }
}
