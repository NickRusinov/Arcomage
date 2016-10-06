using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Services
{
    public interface IGameAction
    {
        void Execute(int cardIndex);
    }
}
