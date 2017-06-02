using System;
using System.Collections.Generic;
using System.Linq;
using SignalR.Extras.Autofac;

namespace Arcomage.WebApi.Hubs
{
    public abstract class ApplicationHub<T> : LifetimeHub<T>
        where T : class
    {
        protected ApplicationPrincipal Principal => (ApplicationPrincipal)Context.User;

        protected ApplicationIdentity Identity => (ApplicationIdentity)Context.User.Identity;
    }
}