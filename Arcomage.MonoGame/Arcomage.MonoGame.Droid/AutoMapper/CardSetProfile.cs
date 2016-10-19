using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.MonoGame.Droid.ViewModels;
using AutoMapper;

namespace Arcomage.MonoGame.Droid.AutoMapper
{
    public class CardSetProfile : Profile
    {
        public CardSetProfile()
        {
            CreateMap<CardSet, CardSetViewModel>()
                .ForMember(csvm => csvm.CardCollection, mce => mce.MapFrom(cs => cs.Cards))
                .ConstructUsingServiceLocator();
        }
    }
}