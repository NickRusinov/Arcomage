using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.MonoGame.Droid.ViewModels;
using AutoMapper;

namespace Arcomage.MonoGame.Droid.AutoMapper
{
    public class HistoryProfile : Profile
    {
        public HistoryProfile()
        {
            CreateMap<History, HistoryViewModel>()
                .ForMember(hvm => hvm.CardCollection, mce => mce.MapFrom(h => h.Cards))
                .ConstructUsingServiceLocator();
        }
    }
}