using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Internal;
using Arcomage.Domain.Players;
using Arcomage.Domain.Services;

namespace Arcomage.Domain.ArtificialIntelligence
{
    /// <summary>
    /// Стандартная реализация алгоритма ИИ для компьютерного игрока
    /// </summary>
    [Serializable]
    public class ArtificialIntelligence : IArtificialIntelligence
    {
        /// <summary>
        /// Игровой цикл
        /// </summary>
        private readonly GameLoop gameLoop;

        /// <summary>
        /// Критерий возможности активации карты
        /// </summary>
        private readonly IPlayCardCriteria playCardCriteria;

        /// <summary>
        /// Критерий возможности сброса карты
        /// </summary>
        private readonly IDiscardCardCriteria discardCardCriteria;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="ArtificialIntelligence"/>
        /// </summary>
        /// <param name="gameLoop">Игровой цикл</param>
        /// <param name="playCardCriteria">Критерий возможности активации карты</param>
        /// <param name="discardCardCriteria">Критерий возможности сброса карты</param>
        public ArtificialIntelligence(GameLoop gameLoop, IPlayCardCriteria playCardCriteria, IDiscardCardCriteria discardCardCriteria)
        {
            Contract.Requires(gameLoop != null);
            Contract.Requires(playCardCriteria != null);
            Contract.Requires(discardCardCriteria != null);

            this.gameLoop = gameLoop;
            this.playCardCriteria = playCardCriteria;
            this.discardCardCriteria = discardCardCriteria;
        }

        /// <inheritdoc/>
        public Task<PlayResult> Execute(Game game, Player player)
        {
            var isFirstPlayer = ReferenceEquals(game.Players.FirstPlayer, player);

            var comparer = new GameComparer(
                isFirstPlayer ? PlayerKind.First : PlayerKind.Second,
                isFirstPlayer ? PlayerKind.Second : PlayerKind.First);
            
            return Task.Factory.StartNew(() => GetPossiblePlay(game)
                .OrderByDescending(p => p.Key, comparer)
                .Select(p => new PlayResult?(p.Value))
                .FirstOrDefault() ?? new PlayResult(0, false));
        }
        
        /// <summary>
        /// Получает возможные варианты ходов
        /// </summary>
        /// <param name="game">Контекст игры</param>
        /// <returns>Коллекция возможных вариантов ходов</returns>
        private IEnumerable<KeyValuePair<Game, PlayResult>> GetPossiblePlay(Game game)
        {
            for (var i = 0; i < game.Players.CurrentPlayer.Hand.Cards.Count; ++i)
            {
                var cloneGame = FrameworkExtensions.Copy(game);
                var playResult = new PlayResult(i, true);

                if (playCardCriteria.CanPlayCard(cloneGame, cloneGame.Players.CurrentPlayer, i))
                {
                    gameLoop.Update(cloneGame, playResult);

                    yield return new KeyValuePair<Game, PlayResult>(cloneGame, playResult);
                }
            }

            for (var i = 0; i < game.Players.CurrentPlayer.Hand.Cards.Count; ++i)
            {
                var cloneGame = FrameworkExtensions.Copy(game);
                var playResult = new PlayResult(i, false);

                if (discardCardCriteria.CanDiscardCard(cloneGame, cloneGame.Players.CurrentPlayer, i))
                {
                    gameLoop.Update(cloneGame, playResult);

                    yield return new KeyValuePair<Game, PlayResult>(cloneGame, playResult);
                }
            }
        }
    }
}
