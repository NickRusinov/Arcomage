using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Services
{
    public interface IDisconnectGameService
    {
        Task<GameContext> DisconnectGame(UserContext userContext);
    }
}
