﻿using System;
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

            if (WebConfig.UnityAuthorizationAllow && authenticate != null)
            {
                using (var innerLifetimeScope = lifetimeScope.BeginLifetimeScope())
                {
                    var mediator = innerLifetimeScope.Resolve<IMediator>();
                    var getOrAddUserRequest = new GetOrAddUserRequest("Unity Player");
                    var user = await mediator.Send(getOrAddUserRequest);

                    var applicationIdentity = new ApplicationIdentity(user);
                    var applicationPrincipal = new ApplicationPrincipal(applicationIdentity);

                    owinContext.Authentication.User = applicationPrincipal;
                }
            }

            await nextMiddleware.Invoke(environment);
        }
    }
}
