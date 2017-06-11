using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Framework;
using Arcomage.Unity.Framework.Services;
using Arcomage.Unity.Shared.Scripts;
using Autofac;

namespace Arcomage.Unity.Configuration
{
    public class SceneModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new UnityHttpClientFactory(AppSettings.Url, c.Resolve<Authorization>(), 
                    c.Resolve<Scene>()))
                .AsSelf().AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.Register(c => new UnityHubConnectionFactory(AppSettings.Url, c.Resolve<Authorization>()))
                .AsSelf().AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnityDispatcher>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitySceneManager>()
                .InstancePerLifetimeScope();
        }
    }
}
