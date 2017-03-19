using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi.Hubs
{
    public abstract class ApplicationHub<T> : Hub<T>
        where T : class
    {
        protected ApplicationPrincipal Principal => (ApplicationPrincipal)Context.User;

        protected ApplicationIdentity Identity => (ApplicationIdentity)Context.User.Identity;
    }
}