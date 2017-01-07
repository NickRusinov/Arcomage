using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain
{
    public class GameLoop
    {
        private readonly IPlayAction playAction;

        private readonly ICardAction cardAction;

        private Task<PlayResult> playResultTask;

        public GameLoop(IPlayAction playAction, ICardAction cardAction)
        {
            this.playAction = playAction;
            this.cardAction = cardAction;
        }

        public GameResult Update(Game game)
        {
            if (playResultTask == null && !game.Result)
            {
                playAction.Execute(game, game.CurrentPlayer);
            }

            if (playResultTask == null && !game.Result)
            { 
                playResultTask = game.CurrentPlayer.Play(game);
            }

            if (playResultTask?.IsCompleted == true && !game.Result)
            {
                if (playResultTask.Result.IsPlay)
                    cardAction.PlayExecute(game, game.CurrentPlayer, playResultTask.Result.Card);

                if (playResultTask.Result.IsDiscard)
                    cardAction.DiscardExecute(game, game.CurrentPlayer, playResultTask.Result.Card);

                playResultTask = null;
            }

            return game.Result;
        }

        public GameResult Update(Game game, PlayResult playResult)
        {
            if (!game.Result && playResult.IsPlay)
                cardAction.PlayExecute(game, game.CurrentPlayer, playResult.Card);

            if (!game.Result && playResult.IsDiscard)
                cardAction.DiscardExecute(game, game.CurrentPlayer, playResult.Card);

            if (!game.Result)
                playAction.Execute(game, game.CurrentPlayer);

            return game.Result;
        }
    }
}
