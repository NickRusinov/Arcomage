using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.MonoGame.Droid.ViewModels;
using Autofac;

namespace Arcomage.MonoGame.Droid
{
    public class ViewModelFactory
    {
        public static ViewModelFactory Instance { get; set; }

        private readonly IContainer container;

        public ViewModelFactory(IContainer container)
        {
            this.container = container;
        }

        public MenuViewModel CreateMenuViewModel()
        {
            using (var scope = container.BeginLifetimeScope())
                return scope.Resolve<MenuViewModel>();
        }

        public GameViewModel CreateGameViewModel()
        {
            using (var scope = container.BeginLifetimeScope())
                return scope.Resolve<GameViewModel>();
        }
    }
}