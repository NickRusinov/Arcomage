using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    public class WhenReplacedPlayerAction : IPlayAction
    {
        private readonly IPlayAction whenReplacedPlayerAction;

        private Player previousPlayer;

        public WhenReplacedPlayerAction(IPlayAction whenReplacedPlayerAction)
        {
            this.whenReplacedPlayerAction = whenReplacedPlayerAction;
        }

        public void Execute(Game game, Player player)
        {
            if (previousPlayer != player)
            {
                previousPlayer = player;
                whenReplacedPlayerAction.Execute(game, player);
            }
        }
    }
}
