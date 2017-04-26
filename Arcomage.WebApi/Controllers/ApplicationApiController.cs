using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Arcomage.WebApi.Controllers
{
    public abstract class ApplicationApiController : ApiController
    {
        protected ApplicationPrincipal Principal => (ApplicationPrincipal)User;

        protected ApplicationIdentity Identity => (ApplicationIdentity)User.Identity;
    }
}
