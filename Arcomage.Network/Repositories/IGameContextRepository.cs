using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Repositories
{
    public interface IGameContextRepository
    {
        Task<bool> Add(GameContext gameContext);

        Task<GameContext> GetById(Guid id);

        Task<GameContext> GetByUserId(Guid id);
    }
}
