using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network
{
    [Flags]
    public enum UserState
    {
        None       = 0x0000_0000,

        Connecting = 0x0000_0001,

        Playing    = 0x0000_0002,

        All        = Connecting | Playing,
    }
}
