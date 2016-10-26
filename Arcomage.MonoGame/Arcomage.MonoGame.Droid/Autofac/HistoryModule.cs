using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Autofac;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class HistoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<History>()
                .As<History>()
                .OnActivating(aea => aea.Instance.Cards = new List<Card>())
                .InstancePerLifetimeScope();
        }
    }
}