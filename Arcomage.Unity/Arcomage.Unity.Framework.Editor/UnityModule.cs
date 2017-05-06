using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace Arcomage.Unity.Framework.Editor
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
