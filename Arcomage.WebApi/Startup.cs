using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using Owin;

namespace Arcomage.WebApi
{
    public class Startup
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void Configuration(IAppBuilder app)
        {
            logger.Info("Запуск приложения");

            var configureTask = Configure(app);
            logger.SwallowAsync(configureTask).GetAwaiter().GetResult();
        }

        private async Task Configure(IAppBuilder app)
        {
            logger.Info("Начало конфигурации приложения");

            var container = await new AutofacConfiguration().Configure(app);

            await new AutoMapperConfiguration().Configure(app, container);
            await new DapperConfiguration().Configure(app, container);
            await new MigrationsConfiguration().Configure(app, container);
            await new QuartzConfiguration().Configure(app, container);
            await new AuthorizationConfiguration().Configure(app, container);
            await new SignalRConfiguration().Configure(app, container);
            await new WebApiConfiguration().Configure(app, container);

            logger.Info("Завершение конфигурации приложения");
        }
    }
}
