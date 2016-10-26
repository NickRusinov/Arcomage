using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Decks;
using Arcomage.Domain.Entities;
using Autofac;
using static Arcomage.MonoGame.Droid.DeckMode;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class DeckModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(cc => cc.ResolveKeyed<Deck>(cc.Resolve<Settings>().DeckMode))
                .As<Deck>();

            builder.RegisterType<ClassicDeck>()
                .Keyed<Deck>(Classic)
                .WithProperty(nameof(Deck.Identifier), nameof(Classic))
                .InstancePerLifetimeScope();

            builder.RegisterType<InfinityDeck>()
                .Keyed<Deck>(Infinity)
                .WithProperty(nameof(Deck.Identifier), nameof(Infinity))
                .InstancePerLifetimeScope();
        }
    }
}