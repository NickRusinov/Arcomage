using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;

namespace Arcomage.WebApi
{
    public class AutoMapperModule : ApplicationModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => Mapper.Instance);
        }
    }
}
