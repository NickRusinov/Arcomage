using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace Arcomage.WebApi
{
    public class AndroidAuthorizationMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> nextMiddleware;

        public AndroidAuthorizationMiddleware(Func<IDictionary<string, object>, Task> nextMiddleware)
        {
            this.nextMiddleware = nextMiddleware;
        }
        
        public async Task Invoke(IDictionary<string, object> environment)
        {
            var owinContext = new OwinContext(environment);
            var authenticate = owinContext.Request.Headers.Get("AndroidAuthorization");

            if (authenticate != null)
            {
#warning Hardcode user
                var applicationIdentity = new ApplicationIdentity(Guid.Parse("EB3AB862-E0D0-413B-B732-6BDD86B3A1A2"), "Debug User", authenticate);
                var applicationPrincipal = new ApplicationPrincipal(applicationIdentity);

                owinContext.Authentication.User = applicationPrincipal;
            }

            await nextMiddleware.Invoke(environment);
        }
    }
}