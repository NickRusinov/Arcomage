using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;

namespace Arcomage.Network.Repositories
{
    public interface IGameRepository
    {
        Task<bool> Add(Guid id, Game game);

        Task<Game> GetById(Guid id);
    }
}
