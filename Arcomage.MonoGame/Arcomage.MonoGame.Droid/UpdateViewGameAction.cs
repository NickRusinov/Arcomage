using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Services;
using Arcomage.MonoGame.Droid.ViewModels;
using Autofac;
using AutoMapper;

namespace Arcomage.MonoGame.Droid
{
    public class UpdateViewGameAction : IGameAction
    {
        private readonly ILifetimeScope lifetimeScope;

        private readonly IMapper mapper;

        private readonly Game game;

        private readonly GameViewModel gameViewModel;

        public UpdateViewGameAction(ILifetimeScope lifetimeScope, IMapper mapper, Game game, GameViewModel gameViewModel)
        {
            this.lifetimeScope = lifetimeScope;
            this.mapper = mapper;
            this.game = game;
            this.gameViewModel = gameViewModel;
        }

        public void Execute(int cardIndex)
        {
            mapper.Map(game, gameViewModel, moo => moo.ConstructServicesUsing(lifetimeScope.Resolve));
        }
    }
}