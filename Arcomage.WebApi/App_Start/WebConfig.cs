using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using static System.Configuration.ConfigurationManager;
using static System.StringComparison;

namespace Arcomage.WebApi
{
    public class WebConfig
    {
        public static readonly string ApplicationConnectionString = 
            ConnectionStrings["ApplicationConnectionString"].ConnectionString;

        public static readonly string HangfireDashboardUserName = 
            AppSettings["HangfireDashboardUserName"];

        public static readonly string HangfireDashboardUserPassword = 
            AppSettings["HangfireDashboardUserPassword"];

        public static readonly bool UnityAuthorizationAllow = 
            bool.TrueString.Equals(AppSettings["UnityAuthorizationAllow"], OrdinalIgnoreCase);

        public static readonly bool AndroidAuthorizationAllow =
            bool.TrueString.Equals(AppSettings["AndroidAuthorizationAllow"], OrdinalIgnoreCase);
    }
}
