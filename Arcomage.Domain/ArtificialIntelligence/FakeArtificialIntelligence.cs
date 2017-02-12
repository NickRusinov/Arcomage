using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Internal;
using Arcomage.Domain.Players;
using Arcomage.Domain.Services;

namespace Arcomage.Domain.ArtificialIntelligence
{
    /// <summary>
    /// Самая простая реализация ИИ для компьютерного игрока
    /// </summary>
    [Serializable]
    public class FakeArtificialIntelligence : IArtificialIntelligence
    {
        /// <summary>
        /// Критерий возможности активации карты
        /// </summary>
        private readonly IPlayCardCriteria playCardCriteria;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="FakeArtificialIntelligence"/>
        /// </summary>
        /// <param name="playCardCriteria">Критерий возможности активации карты</param>
        public FakeArtificialIntelligence(IPlayCardCriteria playCardCriteria)
        {
            this.playCardCriteria = playCardCriteria;
        }
        
        /// <inheritdoc/>
        public Task<PlayResult> Execute(Game game, Player player)
        {
            return FrameworkExtensions.Delay(1000)
                .ContinueWith(t =>
                {
                    if (playCardCriteria.CanPlayCard(game, player, 0))
                        return new PlayResult(0, true);

                    return new PlayResult(0, false);
                });
        }
    }
}
