using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Arcomage.Network;

namespace Arcomage.WebApi
{
    public class ApplicationIdentity : ClaimsIdentity
    {
        public ApplicationIdentity()
        {
            UserContext = null;
        }

        public ApplicationIdentity(UserContext userContext)
        {
            UserContext = userContext;
        }

        public UserContext UserContext { get; }

        public Guid Id => UserContext.Id;

        public override string Name => UserContext.Name;

        public override bool IsAuthenticated => UserContext != null;
    }
}