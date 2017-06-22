using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.Domain
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
        /// <param name="isPlay">Карта активарована</param>
        /// <param name="isDiscard">Карта сброшена</param>
        /// <param name="isTimeout">Карта сброшена по таймауту</param>
        public PlayResult(int card, bool isPlay, bool isDiscard, bool isTimeout)
            : this()
        {
            Contract.Requires(card >= 0);

            Card = card;
            IsPlay = isPlay;
            IsDiscard = isDiscard;
            IsTimeout = isTimeout;
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
        /// Карта сброшена по таймауту
        /// </summary>
        public bool IsTimeout { get; }

        /// <summary>
        /// Оператор преобразования результата хода игрока в булевое значение. Если <paramref name="x"/> равен 
        /// <see cref="None"/>, возвращается значение false, и true в противном случае
        /// </summary>
        /// <param name="x">Результат хода игрока</param>
        public static implicit operator bool(PlayResult x) => !Equals(x, None);
    }
}
