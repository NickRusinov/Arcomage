using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;

namespace Arcomage.Network.Jobs
{
    public class DecoratorPlayGamePublisher : IPlayGamePublisher
    {
        private readonly IPlayGamePublisher playGamePublisher;

        public DecoratorPlayGamePublisher(IPlayGamePublisher playGamePublisher)
        {
            this.playGamePublisher = playGamePublisher;
        }

        public virtual Task OnAfterPlay(GameContext gameContext, Game game)
        {
            return playGamePublisher.OnAfterPlay(gameContext, game);
        }

        public virtual Task OnBeforePlay(GameContext gameContext, Game game)
        {
            return playGamePublisher.OnBeforePlay(gameContext, game);
        }

        public virtual Task OnFinish(GameContext gameContext, Game game)
        {
            return playGamePublisher.OnFinish(gameContext, game);
        }

        public virtual Task OnStart(GameContext gameContext, Game game)
        {
            return playGamePublisher.OnStart(gameContext, game);
        }
    }
}
