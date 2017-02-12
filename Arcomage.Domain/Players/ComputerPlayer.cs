using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.ArtificialIntelligence;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Players
{
    /// <summary>
    /// Описывает игрока, которым управляет ИИ
    /// </summary>
    [Serializable]
    public class ComputerPlayer : Player
    {
        /// <summary>
        /// Алгоритм ИИ компьютерного игрока
        /// </summary>
        [NonSerialized]
        private readonly IArtificialIntelligence artificialIntelligence;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="ComputerPlayer"/>
        /// </summary>
        /// <param name="artificialIntelligence">Алгоритм ИИ компьютерного игрока</param>
        /// <param name="buildings">Строения игрока</param>
        /// <param name="resources">Ресурсы игрока</param>
        /// <param name="hand">Карты в руке игрока</param>
        public ComputerPlayer(IArtificialIntelligence artificialIntelligence, Buildings buildings, Resources resources, Hand hand)
        {
            Contract.Requires(artificialIntelligence != null);
            Contract.Requires(buildings != null);
            Contract.Requires(resources != null);
            Contract.Requires(hand != null);

            this.artificialIntelligence = artificialIntelligence;
            Buildings = buildings;
            Resources = resources;
            Hand = hand;
        }

        /// <inheritdoc/>
        public override Buildings Buildings { get; }

        /// <inheritdoc/>
        public override Resources Resources { get; }

        /// <inheritdoc/>
        public override Hand Hand { get; }
        
        /// <inheritdoc/>
        public override Task<PlayResult> Play(Game game)
        {
            return artificialIntelligence.Execute(game, this);
        }
    }
}
