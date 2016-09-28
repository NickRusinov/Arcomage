using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain
{
    public interface IActivable
    {
        void Activate(Game game);
    }
}
