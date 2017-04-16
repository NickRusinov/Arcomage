using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Services
{
    public interface IPlayGameService
    {
        Task PlayCard(Guid userId, int cardIndex);

        Task DiscardCard(Guid userId, int cardIndex);
    }
}
