using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using Autofac.Features.ResolveAnything;

namespace Arcomage.Unity.Shared.Scripts
{
    public class GameApplication
    {
        public static readonly GameApplication Instance = new GameApplication();
        
        private GameApplication()
        {
            var builder = new ContainerBuilder();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            builder.RegisterType<Settings>()
                .SingleInstance();
            builder.Register(c => c.Resolve<Settings>().Single);
            builder.Register(c => c.Resolve<Settings>().Network);

            builder.Register(c => c.Resolve<Scene>().GetComponent<UnityHttpClientFactory>())
                .AsSelf().AsImplementedInterfaces();
            builder.Register(c => c.Resolve<Scene>().GetComponent<UnityHubConnectionFactory>())
                .AsSelf().AsImplementedInterfaces();
            builder.Register(c => c.Resolve<Scene>().GetComponent<UnityDispatcher>())
                .AsSelf().AsImplementedInterfaces();

            Container = builder.Build();
        }

        public IContainer Container { get; private set; }
    }
}
