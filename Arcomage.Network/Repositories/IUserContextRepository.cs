using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Repositories
{
    public interface IUserContextRepository
    {
        Task<UserContext> GetById(Guid id);
    }
}
