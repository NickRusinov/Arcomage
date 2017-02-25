using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Arcomage.WebApi.Models.About;

namespace Arcomage.WebApi.Controllers
{
    public class AboutController : ApiController
    {
        [HttpGet, Route("~/api/version")]
        public VersionModel GetVersion()
        {
            var versionModel = new VersionModel();
            versionModel.Version = 0;

            return versionModel;
        }
    }
}
