using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Players;
using Arcomage.Domain.Services;
using Arcomage.MonoGame.Droid.Commands;
using Arcomage.MonoGame.Droid.ViewModels;
using Autofac;
using static Arcomage.Domain.Entities.PlayerMode;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class GameViewModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(cc => 
                new PlayCardCommand(
                    cc.Resolve<Game>(), 
                    (HumanPlayer)cc.ResolveKeyed<Player>(FirstPlayer),
                    cc.Resolve<IPlayCardCriteria>()))
                .AsSelf();

            builder.Register(cc => 
                new DiscardCardCommand(
                    cc.Resolve<Game>(),
                    (HumanPlayer)cc.ResolveKeyed<Player>(FirstPlayer),
                    cc.Resolve<IDiscardCardCriteria>()))
                .AsSelf();

            builder.RegisterType<GameViewModel>()
                .AsSelf()
                .OnActivated(aea => aea.Instance.BackCommand = aea.Context.Resolve<MenuCommand>())
                .OnActivated(aea => aea.Instance.UpdateCommand = aea.Context.Resolve<UpdateCommand>())
                .InstancePerLifetimeScope();

            builder.RegisterType<CardViewModel>()
                .AsSelf()
                .OnActivated(aea => aea.Instance.PlayCommand = aea.Context.Resolve<PlayCardCommand>())
                .OnActivated(aea => aea.Instance.DiscardCommand = aea.Context.Resolve<DiscardCardCommand>());
        }
    }
}