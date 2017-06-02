using System;
using System.Collections.Generic;
using System.Linq;
using Arcomage.Network.PostgreSql.Infrastructure;
using Autofac;
using Dapper;
using NLog;
using Owin;

namespace Arcomage.WebApi
{
    public class DapperConfiguration
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void Configure(IAppBuilder app, IContainer container)
        {
            logger.Info("Конфигурация Dapper");

            SqlMapper.AddTypeHandler(new GameTypeHandler());
        }
    }
}