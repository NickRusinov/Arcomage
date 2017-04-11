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
    public class SingleGameExecutor : GameExecutor
    {
        private readonly Game game;

        private readonly IPlayAction playAction;

        private readonly SingleViewModelUpdater updater;

        public SingleGameExecutor(Game game, IPlayAction playAction, SingleViewModelUpdater updater)
        {
            this.game = game;
            this.playAction = playAction;
            this.updater = updater;
        }

        public override IEnumerator Execute()
        {
            updater.Update(game);

            yield return null;

            while (!game.Rule.IsWin(game))
            {
                var task = playAction.Play(game);
                updater.Update(game);

                yield return new TaskYieldInstruction(task);
                updater.Update(game);

                yield return null;
            }
        }
    }
}
