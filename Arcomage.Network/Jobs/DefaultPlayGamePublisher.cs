using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;

namespace Arcomage.Network.Jobs
{
    public class DefaultPlayGamePublisher : IPlayGamePublisher
    {
        public virtual Task OnStart(GameContext gameContext, Game game)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnFinish(GameContext gameContext, Game game)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnBeforePlay(GameContext gameContext, Game game)
        {
            return Task.CompletedTask;
        }

        public virtual Task OnAfterPlay(GameContext gameContext, Game game)
        {
            return Task.CompletedTask;
        }
    }
}
