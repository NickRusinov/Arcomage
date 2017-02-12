using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    /// <summary>
    /// Выполняет игровое действие только в случае смены игрока
    /// </summary>
    public class WhenReplacedPlayerAction : IBeforePlayAction
    {
        /// <summary>
        /// Действие, выполняемое в случае смены игрока
        /// </summary>
        private readonly IBeforePlayAction whenReplacedPlayerAction;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="WhenReplacedPlayerAction"/>
        /// </summary>
        /// <param name="whenReplacedPlayerAction">Действие, выполняемое в случае смены игрока</param>
        public WhenReplacedPlayerAction(IBeforePlayAction whenReplacedPlayerAction)
        {
            this.whenReplacedPlayerAction = whenReplacedPlayerAction;
        }

        /// <inheritdoc/>
        public void Play(Game game)
        {
            if (game.PreviousPlayer != game.Players.CurrentPlayer)
            {
                game.PreviousPlayer = game.Players.CurrentPlayer;
                whenReplacedPlayerAction.Play(game);
            }
        }
    }
}
