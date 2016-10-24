using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.ArtificialIntelligence;
using Arcomage.Domain.Services;
using Autofac;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class ArtificialIntelligenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(cc => new FakeArtificialIntelligence(
                    cc.ResolveNamed<IGameAction>("SecondPlayCardGameAction"),
                    cc.ResolveNamed<IGameAction>("SecondDiscardCardGameAction")))
                .As<IArtificialIntelligence>()
                .InstancePerLifetimeScope();
        }
    }
}