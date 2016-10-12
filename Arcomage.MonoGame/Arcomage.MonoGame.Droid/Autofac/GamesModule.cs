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
    public class GamesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Game>()
                .AsSelf()
                .OnActivating(Activate)
                .InstancePerLifetimeScope();
        }

        private static void Activate(IActivatingEventArgs<Game> activated)
        {
            activated.Instance.FirstPlayer = activated.Context.ResolveKeyed<Player>(FirstPlayer);
            activated.Instance.SecondPlayer = activated.Context.ResolveKeyed<Player>(SecondPlayer);
            activated.Instance.CardDeck = activated.Context.Resolve<CardDeck>();
        }
    }
}