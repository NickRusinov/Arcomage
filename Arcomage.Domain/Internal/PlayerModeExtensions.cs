using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Internal
{
    internal static class PlayerModeExtensions
    {
        public static PlayerMode GetAdversary(this PlayerMode playerMode)
        {
            return (PlayerMode)((int)(playerMode + 1) % 2);
        }
    }
}
