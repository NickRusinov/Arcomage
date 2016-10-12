using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Autofac;
using Autofac.Core;
using static Arcomage.Domain.Entities.PlayerMode;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class CardSetsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CardSet>()
                .Keyed<CardSet>(FirstPlayer)
                .OnActivating(aea => Activate(aea, 6))
                .InstancePerLifetimeScope();

            builder.RegisterType<CardSet>()
                .Keyed<CardSet>(SecondPlayer)
                .OnActivating(aea => Activate(aea, 6))
                .InstancePerLifetimeScope();
        }

        private static void Activate(IActivatingEventArgs<CardSet> activated, int cardCount)
        {
            activated.Instance.Cards = Enumerable.Repeat(activated.Context.Resolve<CardDeck>(), cardCount)
                .Select(cd => cd.PopCard(null))
                .ToList();
        }
    }
}