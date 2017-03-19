using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Arcomage.WebApi.Controllers
{
    public abstract class ApplicationApiController : ApiController
    {
        public ApplicationPrincipal Principal => (ApplicationPrincipal)User;

        public ApplicationIdentity Identity => (ApplicationIdentity)User.Identity;
    }
}
