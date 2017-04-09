using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Network.Domain
{
    public interface IPlayGameCommand
    {
        Task PlayCard(GameContext gameContext, UserContext userContext, int cardIndex);

        Task DiscardCard(GameContext gameContext, UserContext userContext, int cardIndex);
    }
}
