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
    public class HandModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Hand>()
                .Keyed<Hand>(FirstPlayer)
                .OnActivating(aea => Activate(aea, 6))
                .InstancePerLifetimeScope();

            builder.RegisterType<Hand>()
                .Keyed<Hand>(SecondPlayer)
                .OnActivating(aea => Activate(aea, 6))
                .InstancePerLifetimeScope();
        }

        private static void Activate(IActivatingEventArgs<Hand> activated, int cardCount)
        {
            activated.Instance.Cards = Enumerable.Repeat(activated.Context.Resolve<Deck>(), cardCount)
                .Select(cd => cd.PopCard(null))
                .ToList();
        }
    }
}