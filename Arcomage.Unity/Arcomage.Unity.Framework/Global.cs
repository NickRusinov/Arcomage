using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using MediatR;

namespace Arcomage.Unity.Framework
{
    public class Global : IDisposable
    {
        private static IContainer container;

        public static Global Instance { get; set; }

        public static Scene Scene => Instance.lifetimeScope.Resolve<Scene>();

        public static ILifetimeScope Scope => Instance.lifetimeScope.Resolve<ILifetimeScope>();

        public static IMediator Mediator => Instance.lifetimeScope.Resolve<IMediator>();

        public static Authorization Authorization => Instance.lifetimeScope.Resolve<Authorization>();

        public static Logger Logger => Instance.lifetimeScope.Resolve<Logger>();

        public static void UseContainer(IContainer container) => Global.container = container;

        private readonly ILifetimeScope lifetimeScope;
        
        public Global(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope;
        }

        public static Global BeginLifetimeScope(Scene scene)
        {
            return new Global(container.BeginLifetimeScope(b => b.RegisterInstance(scene)));
        }

        public void Dispose()
        {
            lifetimeScope.Dispose();
        }
    }
}
