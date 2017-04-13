using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Arcomage.WebApi.Client.Controllers;
using Arcomage.WebApi.Client.Hubs;
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

            builder.RegisterAssemblyTypes(typeof(ApplicationControllerClient).Assembly)
                .AssignableTo<ApplicationControllerClient>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ApplicationHubClient).Assembly)
                .AssignableTo<ApplicationHubClient>()
                .InstancePerLifetimeScope();

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
            builder.Register(c => c.Resolve<Scene>().GetComponent<UnitySceneManager>())
                .AsSelf().AsImplementedInterfaces();

            Container = builder.Build();
        }

        public IContainer Container { get; private set; }
    }
}
