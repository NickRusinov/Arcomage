using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.CardDecks;
using Arcomage.Domain.Entities;
using Autofac;
using static Arcomage.MonoGame.Droid.CardDeckMode;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class CardDecksModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(cc => cc.ResolveKeyed<CardDeck>(cc.Resolve<Settings>().CardDeck))
                .As<CardDeck>();

            builder.RegisterType<ClassicCardDeck>()
                .Keyed<CardDeck>(Classic)
                .WithProperty(nameof(CardDeck.Identifier), nameof(Classic))
                .InstancePerLifetimeScope();

            builder.RegisterType<InfinityCardDeck>()
                .Keyed<CardDeck>(Infinity)
                .WithProperty(nameof(CardDeck.Identifier), nameof(Infinity))
                .InstancePerLifetimeScope();
        }
    }
}