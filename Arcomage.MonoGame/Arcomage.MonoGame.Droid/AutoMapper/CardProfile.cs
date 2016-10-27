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
                .ForMember(cvm => cvm.Index, mce => mce.WithMappingOrder(0).ResolveUsing((c, cvm, i, rc) => rc.Options.GetIndex()))
                .ForMember(cvm => cvm.CanPlay, mce => mce.WithMappingOrder(1).ResolveUsing((c, cvm) => cvm.PlayCommand.CanExecute(cvm)))
                .ForMember(cvm => cvm.CanDiscard, mce => mce.WithMappingOrder(1).ResolveUsing((c, cvm) => cvm.DiscardCommand.CanExecute(cvm)))
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