using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network
{
    public class UserContext
    {
        public static UserContext New(string name, UserKind kind)
        {
            return new UserContext
            {
                Id = Guid.NewGuid(),
                State = UserState.None,
                Name = name,
                Kind = kind,
            };
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public UserState State { get; set; }

        public UserKind Kind { get; set; }
    }
}
