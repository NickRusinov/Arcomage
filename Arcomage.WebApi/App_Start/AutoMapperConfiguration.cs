using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using AutoMapper;
using AutoMapper.Configuration;
using Owin;

namespace Arcomage.WebApi
{
    public class AutoMapperConfiguration
    {
        public void Configure(IAppBuilder app, IContainer container)
        {
            var configuration = new MapperConfigurationExpression();
            configuration.ConstructServicesUsing(container.Resolve);
            configuration.AddProfiles(Assembly.GetExecutingAssembly());

            Mapper.Initialize(configuration);
            Mapper.AssertConfigurationIsValid();
        }
    }
}