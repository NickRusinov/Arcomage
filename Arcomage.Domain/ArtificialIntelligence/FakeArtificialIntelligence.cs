using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Actions;
using Arcomage.Domain.Players;
using static Arcomage.Domain.Extensions;

namespace Arcomage.Domain.ArtificialIntelligence
{
    /// <summary>
    /// Самая простая реализация ИИ для компьютерного игрока
    /// </summary>
    [Serializable]
    public class FakeArtificialIntelligence : IArtificialIntelligence
    {
        private readonly IPlayAction playAction;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="FakeArtificialIntelligence"/>
        /// </summary>
        public FakeArtificialIntelligence(IPlayAction playAction)
        {
            this.playAction = playAction;
        }
        
        /// <inheritdoc/>
        public async Task<PlayResult> Execute(Game game, Player player)
        {
            await Delay(TimeSpan.FromSeconds(1));

            if (playAction.CanPlay(game, player, new PlayResult(0, true)))
                return new PlayResult(0, true);

            return new PlayResult(0, false);
        }
    }
}
