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
        Created  = 0x0000_0001,

        Playing  = 0x0000_0002,

        Finished = 0x0000_0004,

        All      = Created | Playing | Finished,
    }
}
