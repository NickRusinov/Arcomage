using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Services;
using Arcomage.MonoGame.Droid.Commands;
using Arcomage.MonoGame.Droid.ViewModels;
using Autofac;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class GameViewModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(cc => 
                new PlayCardCommand(
                    cc.Resolve<Game>(), 
                    cc.ResolveNamed<IGameAction>("FirstPlayCardGameAction"),
                    cc.Resolve<IPlayCardCriteria>()))
                .AsSelf();

            builder.Register(cc => 
                new DiscardCardCommand(
                    cc.Resolve<Game>(), 
                    cc.ResolveNamed<IGameAction>("FirstDiscardCardGameAction"),
                    cc.Resolve<IDiscardCardCriteria>()))
                .AsSelf();

            builder.RegisterType<GameViewModel>()
                .AsSelf()
                .OnActivating(aea => aea.Instance.BackCommand = aea.Context.Resolve<MenuCommand>())
                .InstancePerLifetimeScope();

            builder.RegisterType<CardViewModel>()
                .AsSelf()
                .OnActivating(aea => aea.Instance.PlayCommand = aea.Context.Resolve<PlayCardCommand>())
                .OnActivating(aea => aea.Instance.DiscardCommand = aea.Context.Resolve<DiscardCardCommand>());
        }
    }
}