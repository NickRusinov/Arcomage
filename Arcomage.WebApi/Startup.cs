using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Owin;

namespace Arcomage.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = new AutofacConfiguration().Configure(app);

            new AuthorizationConfiguration().Configure(app, container);
            new WebApiConfiguration().Configure(app, container);
            new SignalRConfiguration().Configure(app, container);
        }
    }
}
