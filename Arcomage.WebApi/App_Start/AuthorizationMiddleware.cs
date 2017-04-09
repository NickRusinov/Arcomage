using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace Arcomage.WebApi
{
    public class AuthorizationMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> nextMiddleware;

        public AuthorizationMiddleware(Func<IDictionary<string, object>, Task> nextMiddleware)
        {
            this.nextMiddleware = nextMiddleware;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var owinContext = new OwinContext(environment);

#warning Hardcode user
            var identity = new ApplicationIdentity(Guid.Parse("EB3AB862-E0D0-413B-B732-6BDD86B3A1A2"), "Debug User", "Debug Email");
            owinContext.Authentication.User = new ApplicationPrincipal(identity);

            await nextMiddleware.Invoke(environment);
        }
    }
}