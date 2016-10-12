using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.Commands;
using Arcomage.MonoGame.Droid.ViewModels;
using Autofac;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class MenuViewModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MenuViewModel>()
                .AsSelf()
                .OnActivating(aea => aea.Instance.PlayButton = aea.Context.ResolveNamed<ButtonViewModel>("MenuPlayButton"))
                .OnActivating(aea => aea.Instance.SettingsButton = aea.Context.ResolveNamed<ButtonViewModel>("MenuSettingsButton"))
                .OnActivating(aea => aea.Instance.ExitButton = aea.Context.ResolveNamed<ButtonViewModel>("MenuExitButton"))
                .InstancePerLifetimeScope();

            builder.RegisterType<ButtonViewModel>()
                .Named<ButtonViewModel>("MenuPlayButton")
                .OnActivating(aea => aea.Instance.Identifier = "Play")
                .OnActivating(aea => aea.Instance.Command = aea.Context.Resolve<PlayCommand>())
                .InstancePerLifetimeScope();

            builder.RegisterType<ButtonViewModel>()
                .Named<ButtonViewModel>("MenuSettingsButton")
                .OnActivating(aea => aea.Instance.Identifier = "Settings")
                .OnActivating(aea => aea.Instance.Command = aea.Context.Resolve<SettingsCommand>())
                .InstancePerLifetimeScope();

            builder.RegisterType<ButtonViewModel>()
                .Named<ButtonViewModel>("MenuExitButton")
                .OnActivating(aea => aea.Instance.Identifier = "Exit")
                .OnActivating(aea => aea.Instance.Command = aea.Context.Resolve<ExitCommand>())
                .InstancePerLifetimeScope();
        }
    }
}