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
        private readonly Game game;

        private readonly GameCondition gameCondition;

        public UpdateFinishedGameAction(Game game, GameCondition gameCondition)
        {
            this.game = game;
            this.gameCondition = gameCondition;
        }

        public void Execute(int cardIndex)
        {
            game.IsFinished = gameCondition.IsWin(game) != null;
        }
    }
}
