using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Arcomage.WebApi
{
    public class ApplicationUserIdProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {
            return ((ApplicationIdentity)request.User.Identity).Id.ToString();
        }
    }
}