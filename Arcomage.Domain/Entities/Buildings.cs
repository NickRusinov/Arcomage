using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Arcomage.Domain.Entities
{
    /// <summary>
    /// Класс, описывающий строения игрока
    /// </summary>
    [Serializable]
    public class Buildings
    {
        /// <summary>
        /// Высота стены
        /// </summary>
        private int wall;

        /// <summary>
        /// Высота башни
        /// </summary>
        private int tower;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="Buildings"/>
        /// </summary>
        /// <param name="wall">Высота стены</param>
        /// <param name="tower">Высота башни</param>
        public Buildings(int wall, int tower)
        {
            Contract.Requires(wall >= 0);
            Contract.Requires(tower >= 0);

            this.wall = wall;
            this.tower = tower;
        }

        /// <summary>
        /// Высота стены
        /// </summary>
        public int Wall
        {
            get { return wall; }
            set { wall = Max(value, 0); }
        }

        /// <summary>
        /// Высота башни
        /// </summary>
        public int Tower
        {
            get { return tower; }
            set { tower = Max(value, 0); }
        }

        /// <summary>
        /// Суммарная высота башни и стены
        /// </summary>
        public int Full
        {
            get { return Wall + Tower; }
            set { SetFull(Max(value, 0)); }
        }

        /// <summary>
        /// Устанавливает суммарную высоту стены и башни, так что, при увеличении <paramref name="value"/> 
        /// увеличивается стена, а при уменьшении <paramref name="value"/> сначала уменьшается стена и, если стена 
        /// уменьшена до 0, уменьшается башня
        /// </summary>
        /// <param name="value">Устанавливаемое уммарное значение стены и башни</param>
        private void SetFull(int value)
        {
            Contract.Requires(value >= 0);

            Tower = Min(Tower, value);
            Wall = value - Tower;
        }
    }
}
