using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Shared.Scripts;
using Autofac;

namespace Arcomage.Unity.Configuration
{
    public class SceneModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => c.Resolve<Scene>().GetComponent<UnityHttpClientFactory>())
                .AsSelf().AsImplementedInterfaces();

            builder.Register(c => c.Resolve<Scene>().GetComponent<UnityHubConnectionFactory>())
                .AsSelf().AsImplementedInterfaces();

            builder.Register(c => c.Resolve<Scene>().GetComponent<UnityDispatcher>())
                .AsSelf().AsImplementedInterfaces();

            builder.Register(c => c.Resolve<Scene>().GetComponent<UnitySceneManager>())
                .AsSelf().AsImplementedInterfaces();
        }
    }
}
