using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Users
{
    public interface IGetUserByIdQuery
    {
        Task<UserContext> Get(Guid userId);
    }
}
