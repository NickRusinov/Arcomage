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
            logger.Info("Конфигурация приложения");

            var container = new AutofacConfiguration().Configure(app);

            new AutoMapperConfiguration().Configure(app, container);
            new HangfireConfiguration().Configure(app, container);
            new AuthorizationConfiguration().Configure(app, container);
            new SignalRConfiguration().Configure(app, container);
            new WebApiConfiguration().Configure(app, container);
        }
    }
}
