using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Services
{
    public interface IPlayGameService
    {
        Task PlayCard(UserContext userContext, int cardIndex);

        Task DiscardCard(UserContext userContext, int cardIndex);
    }
}
