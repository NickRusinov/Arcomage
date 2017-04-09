using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;

namespace Arcomage.Network.Domain
{
    public interface IGetGameByIdQuery
    {
        Task<Game> Get(Guid gameId);
    }
}
