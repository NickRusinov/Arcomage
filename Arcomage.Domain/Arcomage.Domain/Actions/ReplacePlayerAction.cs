using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Actions
{
    public class ReplacePlayerAction : IPlayAction, ICardAction
    {
        public void PlayExecute(Game game, Player player, int cardIndex) => Execute(game, player);

        public void DiscardExecute(Game game, Player player, int cardIndex) => Execute(game, player);

        public void Execute(Game game, Player player)
        {
            if (game.PlayAgain-- == 0)
                game.PlayerMode = game.PlayerMode.GetAdversary();
        }
    }
}
