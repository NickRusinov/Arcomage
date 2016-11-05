using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Actions;

namespace Arcomage.MonoGame.Droid
{
    public class ShowFinishedGameAction : IPlayAction
    {
        public void Execute(Game game, Player player)
        {
            // TODO Show Win Or Lose Page
        }
    }
}