using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Players;
using Autofac;
using Autofac.Core;
using static Arcomage.Domain.Entities.PlayerMode;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class PlayersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<HumanPlayer>()
                .Keyed<Player>(FirstPlayer)
                .OnActivating(aea => Activate(aea, FirstPlayer))
                .OnActivating(aea => aea.Instance.Identifier = aea.Context.Resolve<Settings>().FirstPlayer)
                .InstancePerLifetimeScope();

            builder.RegisterType<ComputerPlayer>()
                .Keyed<Player>(SecondPlayer)
                .OnActivating(aea => Activate(aea, SecondPlayer))
                .OnActivating(aea => aea.Instance.Identifier = aea.Context.Resolve<Settings>().SecondPlayer)
                .InstancePerLifetimeScope();
        }

        private static void Activate(IActivatingEventArgs<Player> activated, PlayerMode playerMode)
        {
            activated.Instance.Buildings = activated.Context.Resolve<GameCondition>().CreateBuildings();
            activated.Instance.Resources = activated.Context.Resolve<GameCondition>().CreateResources();
            activated.Instance.CardSet = activated.Context.ResolveKeyed<CardSet>(playerMode);
        }
    }
}