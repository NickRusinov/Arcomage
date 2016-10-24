using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.ArtificialIntelligence
{
    public interface IArtificialIntelligence
    {
        void Execute(Game game);
    }
}
