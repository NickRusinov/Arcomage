using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network
{
    [Flags]
    public enum GameState
    {
        None      = 0x0000_0000,

        Playing   = 0x0000_0001,

        Finished  = 0x0000_0002,

        Cancelled = 0x0000_0004,

        All      = Playing | Finished | Cancelled,
    }
}
