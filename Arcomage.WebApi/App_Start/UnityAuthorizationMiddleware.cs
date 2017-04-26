using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Network.Requests;
using Autofac;
using MediatR;
using Microsoft.Owin;

namespace Arcomage.WebApi
{
    public class UnityAuthorizationMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> nextMiddleware;

        private readonly ILifetimeScope lifetimeScope;

        public UnityAuthorizationMiddleware(Func<IDictionary<string, object>, Task> nextMiddleware, ILifetimeScope lifetimeScope)
        {
            this.nextMiddleware = nextMiddleware;
            this.lifetimeScope = lifetimeScope;
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var owinContext = new OwinContext(environment);
            var authenticate = owinContext.Request.Headers.Get("UnityAuthorization");

            if (authenticate != null)
            {
                using (var innerLifetimeScope = lifetimeScope.BeginLifetimeScope())
                {
                    var mediator = innerLifetimeScope.Resolve<IMediator>();
                    var userContext = await mediator.Send(new GetOrAddUserRequest("Unity Player"));

                    var applicationIdentity = new ApplicationIdentity(userContext);
                    var applicationPrincipal = new ApplicationPrincipal(applicationIdentity);

                    owinContext.Authentication.User = applicationPrincipal;
                }
            }

            await nextMiddleware.Invoke(environment);
        }
    }
}