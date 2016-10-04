using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    public class WinResult : IIdentifiable
    {
        public string Identifier { get; set; }

        public PlayerMode WinPlayerMode { get; set; }

        public PlayerMode LosePlayerMode { get; set; }
    }
}
