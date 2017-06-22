using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Players;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Увеличивает значение счетчика последовательных пропущенных ходов игрока, если карта была сброшена по таймауту
    /// </summary>
    [Serializable]
    public class TimeoutCardAction : IPlayAction
    {
        /// <summary>
        /// Следующее в цепочке выполняемое игровое действие
        /// </summary>
        private readonly IPlayAction nextAction;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="TimeoutCardAction"/>
        /// </summary>
        /// <param name="nextAction">Следующее в цепочке выполняемое игровое действие</param>
        public TimeoutCardAction(IPlayAction nextAction)
        {
            this.nextAction = nextAction;
        }

        /// <inheritdoc/>
        public Task<GameResult> Play(Game game, Player player, PlayResult playResult)
        {
            if (playResult.IsTimeout)
                player.Timeout++;
            else
                player.Timeout = 0;

            return nextAction.Play(game, player, playResult);
        }

        /// <inheritdoc/>
        public bool CanPlay(Game game, Player player, PlayResult playResult)
        {
            return nextAction.CanPlay(game, player, playResult);
        }
    }
}
