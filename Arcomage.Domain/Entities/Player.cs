using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    /// <summary>
    /// Класс, описывающий одного из игроков
    /// </summary>
    [Serializable]
    public abstract class Player
    {
        /// <summary>
        /// Строения игрока
        /// </summary>
        public abstract Buildings Buildings { get; }

        /// <summary>
        /// Ресурсы игрока
        /// </summary>
        public abstract Resources Resources { get; }

        /// <summary>
        /// Карты в руке игрока
        /// </summary>
        public abstract Hand Hand { get; }

        /// <summary>
        /// Выполняет ход игрока. Возвращает объект, который может быть использован для ожидания завершения хода 
        /// игрока и получения результата хода
        /// </summary>
        /// <param name="game">Контекст игры</param>
        /// <returns>Результат хода игрока</returns>
        public abstract Task<PlayResult> Play(Game game);
    }
}
