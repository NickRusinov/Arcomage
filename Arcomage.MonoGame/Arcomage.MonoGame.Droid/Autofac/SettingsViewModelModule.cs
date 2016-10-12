using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class SettingsViewModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Settings>()
                .AsSelf()
                .SingleInstance();
        }
    }
}