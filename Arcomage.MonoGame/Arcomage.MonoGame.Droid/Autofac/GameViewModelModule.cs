using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.MonoGame.Droid.ViewModels;
using Autofac;
using AutoMapper;

namespace Arcomage.MonoGame.Droid.Autofac
{
    public class GameViewModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(cc => Mapper.Map(cc.Resolve<GameCondition>(), Mapper.Map(cc.Resolve<Game>(), new GameViewModel())))
                .As<GameViewModel>()
                .InstancePerLifetimeScope();
        }
    }
}