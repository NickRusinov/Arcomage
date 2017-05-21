using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network
{
    public class User
    {
        public static readonly User ComputerUser =
            new User { Id = new Guid(0xe9a872c8, 0x560b, 0x48f6, 0xb3, 0xfb, 0xe8, 0x25, 0x08, 0x99, 0xbc, 0x8b), Name = "Computer" };
        
        public Guid Id { get; set; }

        public string Name { get; set; }

        public UserState State { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
