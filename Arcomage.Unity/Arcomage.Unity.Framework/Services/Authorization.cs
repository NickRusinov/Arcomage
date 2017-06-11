using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Framework.Services
{
    public abstract class Authorization
    {
        public abstract string GetAuthorizationHeader();

        public abstract string GetAuthorizationToken();
    }
}
