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
            Id = Guid.Empty;
        }

        public ApplicationIdentity(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; }

        public override string Name { get; }

        public string Email { get; }

#warning Model in infrastructure logic
        public UserContext UserContext => new UserContext { Id = Id };

        public override bool IsAuthenticated => Id != Guid.Empty;
    }
}