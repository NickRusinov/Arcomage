using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Services
{
    public class UpdateFinishedGameAction : IGameAction
    {
        private readonly GameCondition gameCondition;

        public UpdateFinishedGameAction(GameCondition gameCondition)
        {
            this.gameCondition = gameCondition;
        }

        public void Execute(Game game, int cardIndex)
        {
            game.IsFinished = gameCondition.IsWin(game) != null;
        }
    }
}
