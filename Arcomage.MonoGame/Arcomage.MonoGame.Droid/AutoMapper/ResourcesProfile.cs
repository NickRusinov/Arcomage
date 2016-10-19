using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.MonoGame.Droid.ViewModels;
using AutoMapper;

namespace Arcomage.MonoGame.Droid.AutoMapper
{
    public class ResourcesProfile : Profile
    {
        public ResourcesProfile()
        {
            CreateMap<Resources, ResourcesViewModel>()
                .ConstructUsingServiceLocator();
        }
    }
}