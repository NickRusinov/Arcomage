using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Rules;
using Arcomage.MonoGame.Droid.ViewModels;
using AutoMapper;

namespace Arcomage.MonoGame.Droid.AutoMapper
{
    public class BuildingsProfile : Profile
    {
        public BuildingsProfile()
        {
            CreateMap<Buildings, BuildingsViewModel>()
                .ConstructUsingServiceLocator();

            CreateMap<ClassicRule, BuildingsViewModel>()
                .ForMember(bvm => bvm.MaxWall, mce => mce.MapFrom(gc => gc.MaxTower))
                .ConstructUsingServiceLocator();
        }
    }
}