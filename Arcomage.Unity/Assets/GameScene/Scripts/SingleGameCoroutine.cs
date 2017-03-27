using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain;
using Arcomage.Domain.Actions;
using Arcomage.Unity.Shared.Scripts;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class SingleGameCoroutine
    {
        private readonly Game game;

        private readonly IPlayAction playAction;

        public SingleGameCoroutine(Game game, IPlayAction playAction)
        {
            this.game = game;
            this.playAction = playAction;
        }

        public IEnumerator GameCoroutine()
        {
            while (!game.Rule.IsWin(game))
            {
                var task = playAction.Play(game);

                yield return new TaskYieldInstruction(task);
                yield return null;
            }
        }
    }
}
