using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;

namespace Arcomage.WebApi
{
    public class UnityAuthorizationMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> nextMiddleware;

        public UnityAuthorizationMiddleware(Func<IDictionary<string, object>, Task> nextMiddleware)
        {
            this.nextMiddleware = nextMiddleware;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var owinContext = new OwinContext(environment);
            var authenticate = owinContext.Request.Headers.Get("UnityAuthorization");

            if (authenticate != null)
            {
#warning Hardcode user
                var applicationIdentity = new ApplicationIdentity(Guid.Parse("EB3AB862-E0D0-413B-B732-6BDD86B3A1A2"), "Debug User", "Debug Email");
                var applicationPrincipal = new ApplicationPrincipal(applicationIdentity);

                owinContext.Authentication.User = applicationPrincipal;
            }

            await nextMiddleware.Invoke(environment);
        }
    }
}