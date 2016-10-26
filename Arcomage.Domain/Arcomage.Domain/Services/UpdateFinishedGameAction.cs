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
        private readonly Rule rule;

        private readonly IGameAction onFinishedGameAction;

        private readonly IGameAction onNotFinishedGameAction;

        public UpdateFinishedGameAction(Rule rule, IGameAction onFinishedGameAction, IGameAction onNotFinishedGameAction)
        {
            this.rule = rule;
            this.onFinishedGameAction = onFinishedGameAction;
            this.onNotFinishedGameAction = onNotFinishedGameAction;
        }

        public void Execute(Game game, int cardIndex)
        {
            game.IsFinished = rule.IsWin(game) != null;

            if (game.IsFinished)
                onFinishedGameAction.Execute(game, cardIndex);
            else
                onNotFinishedGameAction.Execute(game, cardIndex);
        }
    }
}
