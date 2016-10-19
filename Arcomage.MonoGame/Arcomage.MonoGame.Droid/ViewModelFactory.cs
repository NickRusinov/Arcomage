using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.MonoGame.Droid.ViewModels;
using Autofac;
using AutoMapper;

namespace Arcomage.MonoGame.Droid
{
    public class ViewModelFactory
    {
        public static ViewModelFactory Instance { get; set; }

        private readonly IContainer container;

        private readonly IMapper mapper;

        public ViewModelFactory(IContainer container, IMapper mapper)
        {
            this.container = container;
            this.mapper = mapper;
        }

        public MenuViewModel CreateMenuViewModel()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var menuViewModel = scope.Resolve<MenuViewModel>();

                return menuViewModel;
            }
        }

        public GameViewModel CreateGameViewModel()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var gameViewModel = scope.Resolve<GameViewModel>();
                gameViewModel = mapper.Map(scope.Resolve<Game>(), gameViewModel);
                gameViewModel = mapper.Map(scope.Resolve<GameCondition>(), gameViewModel);

                return gameViewModel;
            }
        }
    }
}