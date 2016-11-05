using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    public class CompositePlayAction : IPlayAction
    {
        private readonly IReadOnlyCollection<IPlayAction> playActionCollection;

        public CompositePlayAction(IReadOnlyCollection<IPlayAction> playActionCollection)
        {
            this.playActionCollection = playActionCollection;
        }

        public CompositePlayAction(params IPlayAction[] playActionCollection)
            : this(playActionCollection as IReadOnlyCollection<IPlayAction>)
        {
            
        }

        public void Execute(Game game, Player player)
        {
            foreach (var playAction in playActionCollection)
                playAction.Execute(game, player);
        }
    }
}
