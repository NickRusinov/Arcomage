using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using AutoMapper.Configuration;
using NLog;
using Owin;

namespace Arcomage.WebApi
{
    public class AutoMapperConfiguration
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public Task Configure(IAppBuilder app, IContainer container)
        {
            logger.Info("Конфигурация AutoMapper");

            var configuration = new MapperConfigurationExpression();
            configuration.ConstructServicesUsing(container.Resolve);
            configuration.AddProfiles(Assembly.GetExecutingAssembly());

            Mapper.Initialize(configuration);
            Mapper.AssertConfigurationIsValid();

            return Task.CompletedTask;
        }
    }
}