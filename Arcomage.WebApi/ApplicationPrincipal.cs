using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Arcomage.WebApi
{
    public class ApplicationPrincipal : ClaimsPrincipal
    {
        public ApplicationPrincipal(IIdentity identity) 
            : base(identity)
        {

        }
    }
}