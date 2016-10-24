using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Services
{
    public class CompositeGameAction : IGameAction
    {
        private readonly IReadOnlyCollection<IGameAction> gameActionCollection;

        public CompositeGameAction(IReadOnlyCollection<IGameAction> gameActionCollection)
        {
            this.gameActionCollection = gameActionCollection;
        }

        public CompositeGameAction(params IGameAction[] gameActionCollection)
            : this(gameActionCollection as IReadOnlyCollection<IGameAction>)
        {
            
        }

        public void Execute(Game game, int cardIndex)
        {
            foreach (var gameAction in gameActionCollection)
                gameAction.Execute(game, cardIndex);
        }
    }
}
