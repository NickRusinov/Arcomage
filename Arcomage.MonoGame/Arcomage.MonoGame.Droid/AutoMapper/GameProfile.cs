using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.MonoGame.Droid.ViewModels;
using AutoMapper;

namespace Arcomage.MonoGame.Droid.AutoMapper
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameViewModel>()
                .ForMember(gvm => gvm.BuildingsLeft, mce => mce.MapFrom(g => g.FirstPlayer.Buildings))
                .ForMember(gvm => gvm.BuildingsRight, mce => mce.MapFrom(g => g.SecondPlayer.Buildings))
                .ForMember(gvm => gvm.ResourcesLeft, mce => mce.MapFrom(g => g.FirstPlayer.Resources))
                .ForMember(gvm => gvm.ResourcesRight, mce => mce.MapFrom(g => g.SecondPlayer.Resources))
                .ForMember(gvm => gvm.CardSet, mce => mce.MapFrom(g => g.FirstPlayer.CardSet))
                .ConstructUsingServiceLocator();

            CreateMap<Rule, GameViewModel>()
                .ForMember(gvm => gvm.BuildingsLeft, mce => mce.ResolveUsing(gc => gc))
                .ForMember(gvm => gvm.BuildingsRight, mce => mce.ResolveUsing(gc => gc))
                .ConstructUsingServiceLocator();
        }
    }
}