using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;

namespace Arcomage.WebApi
{
    public class SignalRConfiguration
    {
        public void Configure(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}