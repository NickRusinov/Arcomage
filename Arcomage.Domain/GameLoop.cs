using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain
{
    /// <summary>
    /// Игровой цикл игры
    /// </summary>
    public class GameLoop
    {
        /// <summary>
        /// Действия, выполняемые до получения хода игроком
        /// </summary>
        private readonly IBeforePlayAction beforePlayAction;

        /// <summary>
        /// Действия, выполянемые после совершения хода игроком
        /// </summary>
        private readonly IAfterPlayAction afterPlayAction;

        private Task<PlayResult> playResultTask;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="GameLoop"/>
        /// </summary>
        /// <param name="beforePlayAction">Действия, выполняемые до получения хода игроком</param>
        /// <param name="afterPlayAction">Действия, выполянемые после совершения хода игроком</param>
        public GameLoop(IBeforePlayAction beforePlayAction, IAfterPlayAction afterPlayAction)
        {
            this.beforePlayAction = beforePlayAction;
            this.afterPlayAction = afterPlayAction;
        }

        /// <summary>
        /// Выполянет одну итерацию игрового цикла
        /// </summary>
        /// <param name="game">Контекст игры</param>
        /// <returns>Результат игры</returns>
        public GameResult Update(Game game)
        {
            var gameResult = game.Rule.IsWin(game);
            if (playResultTask == null && !gameResult)
            {
                beforePlayAction.Play(game);
            }

            gameResult = game.Rule.IsWin(game);
            if (playResultTask == null && !gameResult)
            {
                var cts = new CancellationTokenSource();

                var playTask = game.Players.CurrentPlayer.Play(game, cts.Token);
                var timerTask = game.Timer.Start(cts.Token);
                cts.CancelWhenAny(playTask, timerTask);

                playResultTask = playTask.DefaultIfCancel(new PlayResult(0, false));
            }

            gameResult = game.Rule.IsWin(game);
            if (playResultTask?.IsCompleted == true && !gameResult)
            {
                afterPlayAction.Play(game, playResultTask.Result);
                playResultTask = null;
            }

            gameResult = game.Rule.IsWin(game);
            return gameResult;
        }

        /// <summary>
        /// Выполняет одну предварительную операцию игрвого цикла. Используется алгоритмами ИИ для предпросмотра 
        /// возможного хода
        /// </summary>
        /// <param name="game">Контекст игры</param>
        /// <param name="playResult">Ход игрока</param>
        /// <returns>Результат игры</returns>
        internal GameResult Update(Game game, PlayResult playResult)
        {
            var gameResult = game.Rule.IsWin(game);
            if (!gameResult)
                afterPlayAction.Play(game, playResult);

            gameResult = game.Rule.IsWin(game);
            if (!gameResult)
                beforePlayAction.Play(game);

            gameResult = game.Rule.IsWin(game);
            return gameResult;
        }
    }
}
