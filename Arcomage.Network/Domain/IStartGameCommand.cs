using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Domain
{
    public interface IStartGameCommand
    {
        Task Start(GameContext gameContext);
    }
}
