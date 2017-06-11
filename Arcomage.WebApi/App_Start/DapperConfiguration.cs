using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Task Configure(IAppBuilder app, IContainer container)
        {
            logger.Info("Конфигурация Dapper");

            SqlMapper.AddTypeHandler(new GameTypeHandler());

            return Task.CompletedTask;
        }
    }
}
