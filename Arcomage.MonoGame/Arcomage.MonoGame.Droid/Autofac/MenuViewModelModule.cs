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
                .OnActivated(aea => aea.Instance.BackCommand = aea.Context.Resolve<ExitCommand>())
                .OnActivated(aea => aea.Instance.UpdateCommand = aea.Context.Resolve<Command>())
                .OnActivated(aea => aea.Instance.PlayButton = aea.Context.ResolveNamed<ButtonViewModel>("MenuPlayButton"))
                .OnActivated(aea => aea.Instance.SettingsButton = aea.Context.ResolveNamed<ButtonViewModel>("MenuSettingsButton"))
                .OnActivated(aea => aea.Instance.ExitButton = aea.Context.ResolveNamed<ButtonViewModel>("MenuExitButton"))
                .InstancePerLifetimeScope();

            builder.RegisterType<ButtonViewModel>()
                .Named<ButtonViewModel>("MenuPlayButton")
                .OnActivated(aea => aea.Instance.Identifier = "Play")
                .OnActivated(aea => aea.Instance.Command = aea.Context.Resolve<PlayCommand>());

            builder.RegisterType<ButtonViewModel>()
                .Named<ButtonViewModel>("MenuSettingsButton")
                .OnActivated(aea => aea.Instance.Identifier = "Settings")
                .OnActivated(aea => aea.Instance.Command = aea.Context.Resolve<SettingsCommand>());

            builder.RegisterType<ButtonViewModel>()
                .Named<ButtonViewModel>("MenuExitButton")
                .OnActivated(aea => aea.Instance.Identifier = "Exit")
                .OnActivated(aea => aea.Instance.Command = aea.Context.Resolve<ExitCommand>());
        }
    }
}