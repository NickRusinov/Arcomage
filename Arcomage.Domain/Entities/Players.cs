using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace Arcomage.Domain.Entities
{
    /// <summary>
    /// Класс, описывающий двух игроков
    /// </summary>
    [Serializable]
    public class Players
    {
        /// <summary>
        /// Инициализирует экземпляр класса <see cref="Players"/>
        /// </summary>
        /// <param name="kind">Номер текущего игрока</param>
        /// <param name="firstPlayer">Первый игрок</param>
        /// <param name="secondPlayer">Второй игрок</param>
        public Players(PlayerKind kind, Player firstPlayer, Player secondPlayer)
        {
            Contract.Requires(Enum.IsDefined(typeof(PlayerKind), kind));
            Contract.Requires(firstPlayer != null);
            Contract.Requires(secondPlayer != null);

            Kind = kind;
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
        }

        /// <summary>
        /// Номер текущего игрока
        /// </summary>
        public PlayerKind Kind { get; set; }

        /// <summary>
        /// Первый игрок
        /// </summary>
        public Player FirstPlayer { get; }

        /// <summary>
        /// Второй игрок
        /// </summary>
        public Player SecondPlayer { get; }

        /// <summary>
        /// Текущий игрок
        /// </summary>
        public Player CurrentPlayer => this[Kind];

        /// <summary>
        /// Соперник по отношению к текущему игроку
        /// </summary>
        public Player AdversaryPlayer => this[NextPlayerKind(Kind)];
        
        /// <summary>
        /// Получение одного из игроков по его номеру
        /// </summary>
        /// <param name="kind">Номер игрока</param>
        /// <returns>Один из игроков</returns>
        public Player this[PlayerKind kind]
        {
            get { return GetPlayer(kind); }
        }

        /// <summary>
        /// Получение одного из игроков по его номеру
        /// </summary>
        /// <param name="kind">Номер игрока</param>
        /// <returns>Один из игроков</returns>
        private Player GetPlayer(PlayerKind kind)
        {
            Contract.Requires(Enum.IsDefined(typeof(PlayerKind), kind));
            Contract.Ensures(Contract.Result<Player>() != null);

            switch (kind)
            {
                case PlayerKind.First:
                    return FirstPlayer;

                case PlayerKind.Second:
                    return SecondPlayer;

                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Получение следующего за указанным номера игрока
        /// </summary>
        /// <param name="kind">Номер игрока</param>
        /// <returns>Номер следующего игрока</returns>
        public static PlayerKind NextPlayerKind(PlayerKind kind)
        {
            Contract.Requires(Enum.IsDefined(typeof(PlayerKind), kind));
            Contract.Ensures(Enum.IsDefined(typeof(PlayerKind), Contract.Result<PlayerKind>()));

            switch (kind)
            {
                case PlayerKind.First:
                    return PlayerKind.Second;

                case PlayerKind.Second:
                    return PlayerKind.First;

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
