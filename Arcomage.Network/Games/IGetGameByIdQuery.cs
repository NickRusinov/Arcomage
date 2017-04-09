using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Games
{
    public interface IGetGameByIdQuery
    {
        Task<GameContext> Get(Guid gameId);
    }
}
