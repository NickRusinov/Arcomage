using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Repositories
{
    public interface IUserContextRepository
    {
        Task<bool> Add(UserContext userContext);

        Task<bool> Save(UserContext userContext);

        Task<bool> Update(UserContext userContext, params Action<UserContext>[] update);

        Task<UserContext> GetById(Guid id);
    }
}
