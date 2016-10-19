using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.Commands;
using Arcomage.MonoGame.Droid.ViewModels;
using Autofac;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class GameViewModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
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