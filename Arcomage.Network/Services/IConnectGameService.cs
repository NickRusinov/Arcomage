using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Services
{
    public interface IConnectGameService
    {
        Task<GameContext> ConnectGame(Guid userId);
    }
}
