using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Framework.Editor.Services;
using Arcomage.Unity.Framework.Services;
using Autofac;

namespace Arcomage.Unity.Framework.Editor.Configuration
{
    public class UnityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnityAuthorization>()
                .As<Authorization>();

            builder.RegisterType<UnityLogger>()
                .As<Logger>();
        }
    }
}
