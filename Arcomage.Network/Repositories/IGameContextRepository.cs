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

        Task<bool> Save(GameContext gameContext);

        Task<bool> Update(GameContext gameContext, params Action<GameContext>[] update);

        Task<GameContext> GetById(Guid id);

        Task<GameContext> GetByUserId(Guid id, GameState state);
    }
}
