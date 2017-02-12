using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using static System.Math;

namespace Arcomage.Domain.Buildings
{
    /// <summary>
    /// Класс, описывающий значения одного из строений игрока
    /// </summary>
    [Serializable]
    public class Building
    {
        /// <summary>
        /// Значение высоты строения
        /// </summary>
        private int height;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="Building"/>
        /// </summary>
        /// <param name="height">Значение высоты строения</param>
        public Building(int height)
        {
            Contract.Requires(height >= 0);

            this.height = height;
        }

        /// <summary>
        /// Значение высоты строения
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = Max(value, 0); }
        }
    }
}
