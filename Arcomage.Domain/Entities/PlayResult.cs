using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    /// <summary>
    /// Результат хода игрока
    /// </summary>
    [Serializable]
    public struct PlayResult
    {
        /// <summary>
        /// Представляет отказ от возможности сделать ход
        /// </summary>
        public static readonly PlayResult None = new PlayResult();

        /// <summary>
        /// Инициализирует экземпляр структуры <see cref="PlayResult"/>
        /// </summary>
        /// <param name="card">Номер карты на руках игрока</param>
        /// <param name="isPlay">true для активации карты, и false для ее сброса</param>
        public PlayResult(int card, bool isPlay)
            : this()
        {
            Contract.Requires(card >= 0);

            Card = card;
            IsPlay = isPlay;
            IsDiscard = !isPlay;
        }

        /// <summary>
        /// Номер карты на руках игрока
        /// </summary>
        public int Card { get; }

        /// <summary>
        /// Решение о активации карты
        /// </summary>
        public bool IsPlay { get; }

        /// <summary>
        /// Решение о сбросе карты
        /// </summary>
        public bool IsDiscard { get; }

        /// <summary>
        /// Оператор преобразования результата хода игрока в булевое значение. Если <paramref name="x"/> равен 
        /// <see cref="None"/>, возвращается значение false, и true в противном случае
        /// </summary>
        /// <param name="x">Результат хода игрока</param>
        public static implicit operator bool(PlayResult x) => !Equals(x, None);
    }
}
