using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Queries
{
    public interface IGetConnectingUsersQuery
    {
        Task<IEnumerable<UserContext>> Handle();
    }
}
