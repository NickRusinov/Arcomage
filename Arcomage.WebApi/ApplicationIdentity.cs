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
            User = null;
        }

        public ApplicationIdentity(User user)
        {
            User = user;
        }

        public User User { get; }

        public Guid Id => User.Id;

        public override string Name => User.Name;

        public override bool IsAuthenticated => User != null;
    }
}