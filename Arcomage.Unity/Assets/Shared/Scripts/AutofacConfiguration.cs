using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Arcomage.WebApi.Client.Controllers;
using Arcomage.WebApi.Client.Hubs;
using Autofac;
using Autofac.Features.ResolveAnything;
using MediatR;

namespace Arcomage.Unity.Shared.Scripts
{
    public class AutofacConfiguration
    {
        public IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            builder.Register(c => new Mediator(
                    BuildSingleInstanceFactory(c.Resolve<IComponentContext>()),
                    BuildMultiInstanceFactory(c.Resolve<IComponentContext>())))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

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

#if UNITY_EDITOR

            builder.RegisterType<UnityAuthorization>()
                .As<Authorization>();
            builder.RegisterType<UnityLogger>()
                .As<Logger>();

#elif UNITY_ANDROID

            builder.RegisterType<AndroidAuthorization>()
                .As<Authorization>();
            builder.RegisterType<AndroidLogger>()
                .As<Logger>();

#endif

            return builder.Build();
        }

        private static SingleInstanceFactory BuildSingleInstanceFactory(IComponentContext context)
        {
            return t => context.Resolve(t);
        }

        private static MultiInstanceFactory BuildMultiInstanceFactory(IComponentContext context)
        {
            return t => ((IEnumerable)context.Resolve(typeof(IEnumerable<>).MakeGenericType(t))).Cast<object>();
        }
    }
}
