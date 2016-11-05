using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    public abstract class UniformCardAction : ICardAction
    {
        public void PlayExecute(Game game, Player player, int cardIndex) => Execute(game, player, cardIndex);

        public void DiscardExecute(Game game, Player player, int cardIndex) => Execute(game, player, cardIndex);

        protected abstract void Execute(Game game, Player player, int cardIndex);
    }
}
