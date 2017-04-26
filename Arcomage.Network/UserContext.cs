using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network
{
    public class UserContext
    {
        public static UserContext New(string name)
        {
            return new UserContext
            {
                Id = Guid.NewGuid(),
                State = UserState.None,
                Name = name,
            };
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public UserState State { get; set; }
    }
}
