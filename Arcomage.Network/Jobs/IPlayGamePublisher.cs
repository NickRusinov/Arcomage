using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;

namespace Arcomage.Network.Jobs
{
    public interface IPlayGamePublisher
    {
        Task OnStart(GameContext gameContext, Game game);

        Task OnFinish(GameContext gameContext, Game game);

        Task OnBeforePlay(GameContext gameContext, Game game);

        Task OnAfterPlay(GameContext gameContext, Game game);
    }
}
