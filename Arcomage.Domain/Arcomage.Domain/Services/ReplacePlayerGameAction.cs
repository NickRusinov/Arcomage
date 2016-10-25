using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Services
{
    public class ReplacePlayerGameAction : IGameAction
    {
        private readonly IGameAction onReplacePlayerGameAction;

        public ReplacePlayerGameAction(IGameAction onReplacePlayerGameAction)
        {
            this.onReplacePlayerGameAction = onReplacePlayerGameAction;
        }

        public void Execute(Game game, int cardIndex)
        {
            if (game.PlayAgainTurns-- == 0)
            {
                game.PlayerMode = game.PlayerMode.GetAdversary();
                onReplacePlayerGameAction.Execute(game, cardIndex);
            }
        }
    }
}
