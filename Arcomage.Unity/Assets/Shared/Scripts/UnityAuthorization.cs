using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Shared.Scripts
{
    public class UnityAuthorization : Authorization
    {
        public override string GetAuthorizationHeader()
        {
            return "UnityAuthorization";
        }

        public override string GetAuthorizationToken()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
