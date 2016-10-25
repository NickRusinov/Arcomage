using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.MonoGame.Droid.ViewModels;
using Autofac;
using AutoMapper;

namespace Arcomage.MonoGame.Droid.AutoMapper
{
    public class ObservableCollectionTypeConverter : ITypeConverter<IList<Card>, ObservableCollection<CardViewModel>>
    {
        private readonly ILifetimeScope lifetimeScope;

        public ObservableCollectionTypeConverter(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope;
        }

        public ObservableCollection<CardViewModel> Convert(IList<Card> source, ObservableCollection<CardViewModel> destination, ResolutionContext context)
        {
            destination = destination ?? new ObservableCollection<CardViewModel>(new CardViewModel[source.Count]);

            for (var i = 0; i < source.Count; ++i)
            {
                if (source[i].Identifier != destination[i]?.Identifier)
                    destination[i] = context.Mapper.Map<Card, CardViewModel>(source[i], moo => moo.ConstructServicesUsing(lifetimeScope.Resolve));
            }

            return destination;
        }
    }
}