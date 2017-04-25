using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network
{
    public class UserContext
    {
        public static UserContext New()
        {
            return new UserContext
            {
                Id = Guid.NewGuid(),
                State = UserState.None,
            };
        }

        public Guid Id { get; set; }

        public UserState State { get; set; }
    }
}
