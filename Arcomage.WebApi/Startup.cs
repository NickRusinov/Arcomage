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
            new WebApiConfiguration().Configure(app);
            new SignalRConfiguration().Configure(app);
        }
    }
}
