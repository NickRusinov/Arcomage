using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.MonoGame.Droid.ViewModels;
using AutoMapper;

namespace Arcomage.MonoGame.Droid.AutoMapper
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<Card, CardViewModel>()
                .ForMember(cvm => cvm.Price, mce => mce.MapFrom(c => c.ResourcePrice))
                .ForMember(cvm => cvm.Resource, mce => mce.ResolveUsing(c => GetCardResource(c.GetType().BaseType.Name)))
                .ConstructUsingServiceLocator();
        }

        private static string GetCardResource(string cardTypeName)
        {
            if (cardTypeName.EndsWith("Card"))
                return cardTypeName.Substring(0, cardTypeName.Length - 4);

            return cardTypeName;
        }
    }
}