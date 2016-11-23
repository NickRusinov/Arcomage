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
        private readonly ICollection<IPlayAction> playActionCollection;

        public CompositePlayAction(ICollection<IPlayAction> playActionCollection)
        {
            this.playActionCollection = playActionCollection;
        }

        public CompositePlayAction(params IPlayAction[] playActionCollection)
            : this(playActionCollection as ICollection<IPlayAction>)
        {
            
        }

        public void Execute(Game game, Player player)
        {
            foreach (var playAction in playActionCollection)
                playAction.Execute(game, player);
        }
    }
}
