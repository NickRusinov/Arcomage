using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    public class UpdateFinishedAction : IPlayAction, ICardAction
    {
        private readonly Rule rule;

        public UpdateFinishedAction(Rule rule)
        {
            this.rule = rule;
        }

        public void PlayExecute(Game game, Player player, int cardIndex) => Execute(game, player);

        public void DiscardExecute(Game game, Player player, int cardIndex) => Execute(game, player);

        public void Execute(Game game, Player player)
        {
            game.Result = rule.IsWin(game);
        }
    }
}
