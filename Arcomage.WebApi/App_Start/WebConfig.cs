using System;
using System.Collections.Generic;
using System.Linq;
using static System.Configuration.ConfigurationManager;
using static System.StringComparison;

namespace Arcomage.WebApi
{
    public class WebConfig
    {
        public static readonly string ApplicationConnectionString = 
            ConnectionStrings["ApplicationConnectionString"].ConnectionString;
        
        public static readonly bool UnityAuthorizationAllow = 
            bool.TrueString.Equals(AppSettings["UnityAuthorizationAllow"], OrdinalIgnoreCase);

        public static readonly bool AndroidAuthorizationAllow =
            bool.TrueString.Equals(AppSettings["AndroidAuthorizationAllow"], OrdinalIgnoreCase);
    }
}
