using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Arcomage.Domain.Buildings;
using Arcomage.Domain.Hands;
using Arcomage.Domain.Resources;

namespace Arcomage.Domain.Players
{
    /// <summary>
    /// Класс, описывающий одного из игроков
    /// </summary>
    [Serializable]
    public abstract class Player
    {
        /// <summary>
        /// Количество последовательных ходов игрока, пропущенных по таймауту
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Строения игрока
        /// </summary>
        public abstract BuildingSet Buildings { get; }

        /// <summary>
        /// Ресурсы игрока
        /// </summary>
        public abstract ResourceSet Resources { get; }

        /// <summary>
        /// Карты в руке игрока
        /// </summary>
        public abstract Hand Hand { get; }

        /// <summary>
        /// Выполняет ход игрока. Возвращает объект, который может быть использован для ожидания завершения хода 
        /// игрока и получения результата хода
        /// </summary>
        /// <param name="game">Контекст игры</param>
        /// <param name="token">Токен завершения хода по таймауту</param>
        /// <returns>Результат хода игрока</returns>
        public abstract Task<PlayResult> Play(Game game, CancellationToken token);
    }
}
