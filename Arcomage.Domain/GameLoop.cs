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
        private readonly Game game;

        private readonly IPlayAction playAction;

        private readonly ICardAction cardAction;

        private Task<PlayResult> playResultTask;

        public GameLoop(Game game, IPlayAction playAction, ICardAction cardAction)
        {
            this.game = game;
            this.playAction = playAction;
            this.cardAction = cardAction;
        }

        public GameResult Update()
        {
            if (playResultTask == null && !game.Result)
            {
                playAction.Execute(game, game.GetCurrentPlayer());
            }

            if (playResultTask == null && !game.Result)
            { 
                playResultTask = game.GetCurrentPlayer().Play(game);
            }

            if (playResultTask?.IsCompleted == true && !game.Result)
            {
                if (playResultTask.Result.IsPlay)
                    cardAction.PlayExecute(game, game.GetCurrentPlayer(), playResultTask.Result.Card);

                if (playResultTask.Result.IsDiscard)
                    cardAction.DiscardExecute(game, game.GetCurrentPlayer(), playResultTask.Result.Card);

                playResultTask = null;
            }

            return game.Result;
        }
    }
}
