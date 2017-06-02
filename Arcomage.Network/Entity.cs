using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
