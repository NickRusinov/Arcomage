using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.ArtificialIntelligence;
using Autofac;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class ArtificialIntelligenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FakeArtificialIntelligence>()
                .As<IArtificialIntelligence>()
                .InstancePerLifetimeScope();
        }
    }
}