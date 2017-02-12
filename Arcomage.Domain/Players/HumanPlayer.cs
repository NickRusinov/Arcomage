using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Buildings;
using Arcomage.Domain.Hands;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Players
{
    /// <summary>
    /// Описывает игрока, которым управляет человек
    /// </summary>
    [Serializable]
    public class HumanPlayer : Player
    {
        /// <summary>
        /// Объект, предоставляющий объект <see cref="Task"/>, ожидающий ход игрока
        /// </summary>
        [NonSerialized]
        private TaskCompletionSource<PlayResult> playResultSource;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="HumanPlayer"/>
        /// </summary>
        /// <param name="buildings">Строения игрока</param>
        /// <param name="resources">Ресурсы игрока</param>
        /// <param name="hand">Карты в руке игрока</param>
        public HumanPlayer(BuildingSet buildings, ResourceSet resources, Hand hand)
        {
            Contract.Requires(buildings != null);
            Contract.Requires(resources != null);
            Contract.Requires(hand != null);

            Buildings = buildings;
            Resources = resources;
            Hand = hand;
        }

        /// <inheritdoc/>
        public override BuildingSet Buildings { get; }

        /// <inheritdoc/>
        public override ResourceSet Resources { get; }

        /// <inheritdoc/>
        public override Hand Hand { get; }

        /// <inheritdoc/>
        public override Task<PlayResult> Play(Game game)
        {
            playResultSource = new TaskCompletionSource<PlayResult>();

            return playResultSource.Task;
        }

        /// <summary>
        /// Устанавливает результат хода игрока под управлением человека
        /// </summary>
        /// <param name="playResult">Ход игрока</param>
        public void SetPlayResult(PlayResult playResult)
        {
            playResultSource?.TrySetResult(playResult);
        }
    }
}
